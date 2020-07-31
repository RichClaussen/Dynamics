using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

namespace Dynamics
{
    public class BindableExpandoBase : ExpandoBase
    {
        private static readonly object objLock = new object();
        public static IDictionary<Type, IDictionary<string, PropertyDescriptor>> BindableTypes { get; private set; }

        private readonly Type type;

        static BindableExpandoBase() => BindableTypes = new Dictionary<Type, IDictionary<string, PropertyDescriptor>>();

        protected BindableExpandoBase()
        {
            type = GetType();
            lock (objLock)
            {
                if (!BindableTypes.Keys.Contains(type))
                {
                    var properties = new Dictionary<string, PropertyDescriptor>();
                    BindableTypes.Add(type, properties);
                }
            }

            foreach (PropertyInfo property in type.GetProperties())
            {
                AddProperty(property.Name, property.PropertyType);
            }
        }

        private void AddProperty(string name, Type type)
        {
            lock (objLock)
            {
                IDictionary<string, PropertyDescriptor> typeProperties = BindableTypes[this.type];
                if (!typeProperties.Keys.Contains(name))
                {
                    typeProperties.Add(name, new DynamicPropertyDescriptor(name, type));
                }
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool isRetrieved = base.TryGetMember(binder, out result);

            if (!isRetrieved)
            {
                lock (objLock)
                {
                    IDictionary<string, PropertyDescriptor> typeProperties = BindableTypes[type];
                    isRetrieved = typeProperties.Keys.Contains(binder.Name);
                    result = "--";
                }
            }

            return isRetrieved;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bool isAdded = base.TrySetMember(binder, value);

            if (isAdded)
            {
                AddProperty(binder.Name, value.GetType());
            }

            return isAdded;
        }
    }
}
