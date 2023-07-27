// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal static class SerializationHelpers
    {
        internal static Dictionary<string, object> ResponseToDictionary(Response response)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var property in document.RootElement.EnumerateObject())
            {
                dictionary.Add(property.Name, property.Value.GetObject());
            }
            return dictionary;
        }
    }
}
