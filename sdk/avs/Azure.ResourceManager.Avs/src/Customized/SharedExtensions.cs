// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Avs
{
    internal static class SharedExtensions
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> destination, IDictionary<string, string> source)
        {
            destination.Clear();
            foreach (KeyValuePair<string, string> item in source)
            {
                destination.Add(item);
            }

            return destination;
        }
    }
}
