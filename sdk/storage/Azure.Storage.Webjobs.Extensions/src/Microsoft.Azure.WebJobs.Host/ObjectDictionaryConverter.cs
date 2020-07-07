// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host
{
    internal static class ObjectDictionaryConverter
    {
        public static IDictionary<string, object> AsDictionary(object values)
        {
            if (values == null)
            {
                return null;
            }

            IDictionary<string, object> valuesAsDictionary = values as IDictionary<string, object>;

            if (valuesAsDictionary != null)
            {
                return valuesAsDictionary;
            }

            IDictionary valuesAsNonGenericDictionary = values as IDictionary;

            if (valuesAsNonGenericDictionary != null)
            {
                throw new InvalidOperationException("Argument dictionaries must implement IDictionary<string, object>.");
            }

            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (PropertyHelper property in PropertyHelper.GetProperties(values))
            {
                // Extract the property values from the property helper
                // The advantage here is that the property helper caches fast accessors.
                dictionary.Add(property.Name, property.GetValue(values));
            }

            return dictionary;
        }
    }
}
