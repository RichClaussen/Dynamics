using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Dynamics
{
    public class DynamicObservableCollection<T> : ObservableCollection<dynamic>, ITypedList where T : BindableExpandoBase
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            IEnumerable<PropertyDescriptor> properties = BindableExpandoBase.GetProperties(typeof(T));
            return new PropertyDescriptorCollection(properties.ToArray());
        }

        public string GetListName(PropertyDescriptor[] listAccessors) => null;
    }
}
