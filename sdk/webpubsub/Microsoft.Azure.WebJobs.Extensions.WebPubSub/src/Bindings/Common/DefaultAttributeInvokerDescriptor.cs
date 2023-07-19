// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.WebJobs.Description;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Copy from: https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/Bindings/DefaultAttributeInvokerDescriptor.cs.
    /// </summary>
    // Helpers for providing default behavior for an IAttributeInvokeDescriptor that
    // convert between a TAttribute and a string representation (invoke string).
    // Properties with [AutoResolve] are the interesting ones to serialize and deserialize.
    // Assume any property without a [AutoResolve] attribute is read-only and so doesn't need to be included in the invoke string.
    internal static class DefaultAttributeInvokerDescriptor<TAttribute>
        where TAttribute : Attribute
    {
        public static TAttribute FromInvokeString(AttributeCloner<TAttribute> cloner, string invokeString)
        {
            if (invokeString == null)
            {
                throw new ArgumentNullException(nameof(invokeString));
            }

            // Instantiating new attributes can be tricky since sometimes the arg is to the ctor and sometimes
            // its a property setter. AttributeCloner already solves this, so use it here to do the actual attribute instantiation.
            // This has an instantiation problem similar to what Attribute Cloner has
            if (invokeString[0] == '{')
            {
                var propertyValues = JsonConvert.DeserializeObject<IDictionary<string, string>>(invokeString);

                var attr = cloner.New(propertyValues);
                return attr;
            }
            else
            {
                var attr = cloner.New(invokeString);
                return attr;
            }
        }

        public static string ToInvokeString(IDictionary<PropertyInfo, AutoResolveAttribute> resolvableProps, TAttribute source)
        {
            Dictionary<string, string> vals = new();
            foreach (var pair in resolvableProps.AsEnumerable())
            {
                var prop = pair.Key;
                var str = (string)prop.GetValue(source);
                if (!string.IsNullOrWhiteSpace(str))
                {
                    vals[prop.Name] = str;
                }
            }

            if (vals.Count == 0)
            {
                return string.Empty;
            }
            if (vals.Count == 1)
            {
                // Flat
                return vals.First().Value;
            }
            return JsonConvert.SerializeObject(vals);
        }
    }
}