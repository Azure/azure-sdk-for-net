using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.SiteRecovery
{
    public static class QueryHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryObject"></param>
        /// <returns></returns>
        public static string ToJson(this object queryObject)
        {
            JObject calc = new JObject();
            ConvertToJson(queryObject,calc);
            return calc.ToString();
        }

        private static void ConvertToJson(object obj, JObject jObject)
        {
            if (obj == null)
            {
                return;
            }

            Type objType = obj.GetType();

            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                {
                    object propValue = property.GetValue(obj, null);

                    if (propValue != null)
                    {

                        // IList is the only one we are handling since it is the only once
                        // allowed in Hydra for now.
                        var elems = propValue as IList;
                        if (elems != null)
                        {
                            JArray jarray = new JArray();
                            foreach (var item in elems)
                            {
                                JObject jObjectList = new JObject();
                                Type itemType = item.GetType();

                                // For primitive types we directly put in array. Rest are again
                                // iterated upon to generate object.
                                if (itemType.IsPrimitive || itemType.Equals(typeof(string)))
                                {
                                    JValue jval = new JValue(item.ToString());
                                    jarray.Add(jval);
                                }
                                else
                                {
                                    ConvertToJson(item, jObjectList);
                                    jarray.Add(jObject);
                                }
                            }

                            jObject[property.Name] = jarray;
                        }
                        else
                        {
                            // This will not cut-off System.Collections because of the first check
                            if (property.PropertyType.Assembly == objType.Assembly)
                            {
                                ConvertToJson(propValue, jObject);
                            }
                            else
                            {
                                if (propValue.ToString().Contains("Hyak.Common.LazyList"))
                                {
                                    // Just skip the property.
                                }
                                else
                                {
                                    jObject[property.Name] = propValue.ToString();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
