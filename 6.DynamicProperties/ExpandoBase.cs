using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dynamics
{
    public class ExpandoBase : DynamicObject
    {
        private readonly IDictionary<string, object> dictionary;

        public ExpandoBase() => dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (dictionary.ContainsKey(binder.Name))
            {
                result = dictionary[binder.Name];
                return true;
            }

            return base.TryGetMember(binder, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (!dictionary.ContainsKey(binder.Name))
            {
                dictionary.Add(binder.Name, value);
            }
            else
            {
                dictionary[binder.Name] = value;
            }

            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (dictionary.ContainsKey(binder.Name) && dictionary[binder.Name] is Delegate)
            {
                var del = dictionary[binder.Name] as Delegate;
                result = del.DynamicInvoke(args);

                return true;
            }

            return base.TryInvokeMember(binder, args, out result);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            if (dictionary.ContainsKey(binder.Name))
            {
                dictionary.Remove(binder.Name);
                return true;
            }

            return base.TryDeleteMember(binder);
        }

        public override IEnumerable<string> GetDynamicMemberNames() => dictionary.Keys;
    }
}
