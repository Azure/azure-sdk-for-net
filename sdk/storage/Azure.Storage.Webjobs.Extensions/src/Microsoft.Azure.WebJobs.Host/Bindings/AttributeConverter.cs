// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    internal class AttributeCloner
    {        
        // This is separate from AttributeCloner<T>  since:
        // - this does not need to resolve any { } , %%. Those will be resolved later. 
        // - this method is not generic. 
        public static Attribute CreateDirect(Type attributeType, JObject properties)
        {
            Type t = attributeType;

            ConstructorInfo bestCtor = null;
            int longestMatch = -1;
            object[] ctorArgs = null;

            // Pick the ctor with the longest parameter list where all parameters are matched.
            var ctors = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            foreach (var ctor in ctors)
            {
                var ps = ctor.GetParameters();
                int len = ps.Length;

                List<object> possibleCtorArgs = new List<object>();

                bool hasAllParameters = true;
                for (int i = 0; i < len; i++)
                {
                    var p = ps[i];

                    JToken token;
                    if (!properties.TryGetValue(p.Name, StringComparison.OrdinalIgnoreCase, out token))
                    {
                        // Missing a parameter for this ctor; try the next one. 
                        hasAllParameters = false;
                        break;
                    }
                    else
                    {
                        var obj = ApplyNameResolver(token, p.ParameterType);
                        possibleCtorArgs.Add(obj);
                    }
                }

                if (hasAllParameters)
                {
                    if (len > longestMatch)
                    {
                        bestCtor = ctor;
                        ctorArgs = possibleCtorArgs.ToArray();
                        longestMatch = len;
                    }
                }
            }

            if (bestCtor == null)
            {
                // error!!!
                throw new InvalidOperationException("Can't figure out which ctor to call.");
            }

            // Apply writeable properties. 
            var newAttr = (Attribute)bestCtor.Invoke(ctorArgs);

            foreach (var prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.CanWrite)
                {
                    JToken token;
                    if (properties.TryGetValue(prop.Name, StringComparison.OrdinalIgnoreCase, out token))
                    {
                        var obj = ApplyNameResolver(token, prop.PropertyType);
                        prop.SetValue(newAttr, obj);
                    }
                }
            }

            return newAttr;
        }

        private static object ApplyNameResolver(
            JToken originalValue, 
            Type type)
        {
            var obj = originalValue.ToObject(type);
           return obj;           
        }
    }
}