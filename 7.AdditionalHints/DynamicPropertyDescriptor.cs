using System;
using System.ComponentModel;

namespace Dynamics
{
    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private readonly Type type;
        private readonly string displayName;

        public DynamicPropertyDescriptor(string name, Type type)
            : this(name, type, name) { }

        public DynamicPropertyDescriptor(string name, Type type, string displayName)
            : base(name, null)
        {
            this.type = type;
            this.displayName = displayName;
        }

        public override string DisplayName => string.Format("«{0}»", displayName);

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
