using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public static class ExtMethod
    {
        /// <summary>
        /// Checks if IEnumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsAny<T>(this IEnumerable<T> collection)
        {
            return (collection != null && collection.Any());
        }


        /// <summary>
        /// Creates comma seperated string of all EnvironmentNames enum values
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static string ListValues(this EnvironmentNames env)
        {
            List<string> enumValues = (from ev in typeof(EnvironmentNames).GetMembers(BindingFlags.Public | BindingFlags.Static) select ev.Name).ToList();
            return string.Join(",", enumValues.Select((item) => item));
        }


        /// <summary>
        /// Allows you to clear only values or key/value both
        /// </summary>
        /// <param name="dictionary">Dictionary<string,string> that to be cleared</param>
        /// <param name="clearValuesOnly">True: Clears only values, False: Clear keys and values</param>
        public static void Clear(this Dictionary<string, string> dictionary, bool clearValuesOnly)
        {
            //TODO: can be implemented for generic dictionary, but currently there is no requirement, else the overload
            //will be reflected for the entire solution for any kind of Dictionary, so currently only scoping to Dictionary<string,string>
            if (clearValuesOnly)
            {
                foreach (string key in dictionary.Keys.ToList<string>())
                {
                    dictionary[key] = string.Empty;
                }
            }
            else
            {
                dictionary.Clear();
            }
        }
    }
}
