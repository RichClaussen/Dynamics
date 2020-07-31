using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Dynamics
{
    public class DynamicObservableCollection<T> : ObservableCollection<dynamic>, ITypedList where T : BindableExpandoBase
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            IDictionary<string, PropertyDescriptor> properties = BindableExpandoBase.BindableTypes[typeof(T)];

            var propertyDescriptors = new List<PropertyDescriptor>();
            propertyDescriptors.AddRange(properties.Values);

            return new PropertyDescriptorCollection(propertyDescriptors.ToArray());
        }

        public string GetListName(PropertyDescriptor[] listAccessors) => "master list";
    }
}
