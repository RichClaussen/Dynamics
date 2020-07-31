using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Dynamics
{
    public class DynamicObservableCollection : ObservableCollection<dynamic>, ITypedList
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            var descriptors = new PropertyDescriptor[]
            {
                new DynamicPropertyDescriptor("Performer", typeof(string), null),
                new DynamicPropertyDescriptor("Title", typeof(string), null),
                new DynamicPropertyDescriptor("Length", typeof(TimeSpan), null),
                new DynamicPropertyDescriptor("FOOBAR", typeof(string), null),
                new DynamicPropertyDescriptor("Duck", typeof(TimeSpan), null),
            };

            return new PropertyDescriptorCollection(descriptors);
        }

        public string GetListName(PropertyDescriptor[] listAccessors) => "master list";
    }
}
