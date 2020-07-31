using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dynamics
{
    public class ExpandableBase : DynamicObject
    {
        private readonly IDictionary<string, object> dictionary;

        public ExpandableBase()
        {
            dictionary = new Dictionary<string, object>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (this.dictionary.ContainsKey(binder.Name))
            {
                result = this.dictionary[binder.Name];
                return true;
            }

            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!this.dictionary.ContainsKey(binder.Name))
            {
                this.dictionary.Add(binder.Name, value);
            }
            else
            {
                this.dictionary[binder.Name] = value;
            }

            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (this.dictionary.ContainsKey(binder.Name) && this.dictionary[binder.Name] is Delegate)
            {
                var del = this.dictionary[binder.Name] as Delegate;
                result = del.DynamicInvoke(args);

                return true;
            }

            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            if (this.dictionary.ContainsKey(binder.Name))
            {
                this.dictionary.Remove(binder.Name);
                return true;
            }

            return base.TryDeleteMember(binder);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return dictionary.Keys;
        }
    }
}
