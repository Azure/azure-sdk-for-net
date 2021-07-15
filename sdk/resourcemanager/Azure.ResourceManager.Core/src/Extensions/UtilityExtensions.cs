// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class containing utility extensions
    /// </summary>
    public static class UtilityExtensions
    {
        /// <summary>
        /// An extension method for supporting replacing one dictionary content with another one.
        /// This is used to support resource tags.
        /// </summary>
        /// <param name="dest"> The destination dictionary in which the content will be replaced. </param>
        /// <param name="src"> The source dictionary from which the content is copied from. </param>
        /// <returns> The destination dictionary that has been altered. </returns>
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv.Key, kv.Value);
            }

            return dest;
        }
    }
}
