using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Dynamics
{
    public abstract class ObservableItem : INotifyPropertyChanged
    {
        private static readonly Dictionary<string, PropertyChangedEventArgs> eventArgCache;

        static ObservableItem() => eventArgCache = new Dictionary<string, PropertyChangedEventArgs>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                PropertyChangedEventArgs args = GetPropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {

            if (!(expression is LambdaExpression lambda))
            {
                return;
            }

            MemberExpression memberExpression = (lambda.Body is UnaryExpression) ? ((UnaryExpression)lambda.Body).Operand as MemberExpression : lambda.Body as MemberExpression;
            OnPropertyChanged(memberExpression != null ? memberExpression.Member.Name : string.Empty);
        }

        private static PropertyChangedEventArgs GetPropertyChangedEventArgs(string propertyName)
        {
            PropertyChangedEventArgs args;

            lock (typeof(ObservableItem))
            {
                if (!eventArgCache.TryGetValue(propertyName, out args))
                {
                    eventArgCache.Add(propertyName, new PropertyChangedEventArgs(propertyName));
                }

                args = eventArgCache[propertyName];
            }

            return args;
        }
    }
}
