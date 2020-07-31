using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Collections;

using Microsoft.CSharp.RuntimeBinder;

namespace Dynamics
{
    public class BindableExpandoBase : ExpandoBase
    {
        private static readonly object objLock = new object();
        private static IDictionary<Type, OrderedDictionary<string, PropertyDescriptor>> BindableTypes { get; set; }

        private readonly Type type;

        static BindableExpandoBase()
        {
            BindableTypes = new Dictionary<Type, OrderedDictionary<string, PropertyDescriptor>>();
        }

        protected BindableExpandoBase()
        {
            this.type = this.GetType();
            lock (objLock)
            {
                if (!BindableTypes.Keys.Contains(this.type))
                {
                    var properties = new OrderedDictionary<string, PropertyDescriptor>();
                    BindableTypes.Add(this.type, properties);
                }
            }

            foreach (var property in this.type.GetProperties())
            {
                AddProperty(property.Name, property.PropertyType, property.Name);
            }
        }

        public void AddProperty(string name, Type type, string displayName)
        {
            lock (objLock)
            {
                var typeProperties = BindableTypes[this.type];
                if (!typeProperties.Keys.Contains(name))
                {
                    typeProperties.Add(name, new DynamicPropertyDescriptor(name, type, displayName));
                }
            }
        }

        public void AddValue(string name, object value)
        {
            this.AddValue(name, name, value);
        }

        public void AddValue(string name, string displayName, object value)
        {
            this.AddProperty(name, value.GetType(), displayName);
            this.TrySetMember(name, value);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            bool isRetrieved = base.TryGetMember(binder, out result);

            if (!isRetrieved)
            {
                lock (objLock)
                {
                    var typeProperties = BindableTypes[this.type];
                    isRetrieved = typeProperties.Keys.Contains(binder.Name);
                }
            }

            return isRetrieved;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bool isAdded = base.TrySetMember(binder, value);

            if (isAdded) AddProperty(binder.Name, value.GetType(), binder.Name);

            return isAdded;
        }

        public static IEnumerable<PropertyDescriptor> GetProperties(Type type)
        {
            return (BindableTypes[type] as IDictionary<string, PropertyDescriptor>)
                   .Select(prop => prop.Value);
        }

        public static IEnumerable<PropertyDescriptor> GetOrderedProperties(Type type)
        {
            return (BindableTypes[type] as IEnumerable<KeyValuePair<string, PropertyDescriptor>>)
                   .Select(prop => prop.Value);
        }
    }
}
