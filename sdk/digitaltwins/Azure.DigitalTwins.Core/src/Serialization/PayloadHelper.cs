// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.DigitalTwins.Core.Serialization
{
    internal static class PayloadHelper
    {
        /// <summary>
        /// Adds the specified unescaped json entities into a json array.
        /// </summary>
        /// <param name="entities">The entities to add</param>
        /// <returns>A json array</returns>
        internal static string BuildArrayPayload(IEnumerable<string> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            return $"[{string.Join(",", entities)}]";
        }
    }
}
