using System;
using System.ComponentModel;

namespace Dynamics
{
    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private readonly Type type;

        public DynamicPropertyDescriptor(string name, Type type, Attribute[] attrs) : base(name, attrs) => this.type = type;

        public override bool CanResetValue(object component) => false;

        public override void ResetValue(object component) { }

        public override object GetValue(object component) => null;

        public override void SetValue(object component, object value) { }

        public override bool ShouldSerializeValue(object component) => false;

        public override Type ComponentType => GetType();

        public override bool IsReadOnly => true;

        public override Type PropertyType => type;
    }
}
