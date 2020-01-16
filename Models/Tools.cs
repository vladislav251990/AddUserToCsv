using System;
using System.Collections.Generic;

namespace UserAdding.Models
{
    /// <summary>
    /// Converters, service methods
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Convert Dictionary object to object of given class 
        /// </summary>
        public static T DictionaryToObject<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }


            return (T)obj;
        }
    }
}
