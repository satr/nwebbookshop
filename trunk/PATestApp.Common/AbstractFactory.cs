using System;
using System.Collections.Generic;

namespace PATestApp.Common {
    public abstract class AbstractFactory {
        private static readonly Dictionary<Type, object> _prividers = new Dictionary<Type, object>();

        protected static T GetInstance<T>()
            where T: class, new()
        {
            var key = typeof(T);
            if (!_prividers.ContainsKey(key))
                _prividers.Add(key, new T());
            return (T) _prividers[key];
        }
    }
}
