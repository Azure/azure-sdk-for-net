// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Back-compat ctor overload: 1.4.0 GA exposed a 2-arg ctor (without identity);
    // the generator now emits only the 3-arg form including identity. Re-expose the
    // 2-arg form so existing callers keep compiling.
    public partial class CosmosDBAccountCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="locations"> An array that contains the georeplication locations enabled for the Cosmos DB account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locations"/> is null. </exception>
        public CosmosDBAccountCreateOrUpdateContent(AzureLocation location, IEnumerable<CosmosDBAccountLocation> locations)
            : this(location, locations, default)
        {
        }
    }
}
