// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class RestorableDroppedDatabaseData
    {
        // Make the ctor public to keep backwards compatibility.
        /// <summary> Initializes a new instance of <see cref="RestorableDroppedDatabaseData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public RestorableDroppedDatabaseData(AzureLocation location) : base(location)
        {
        }
    }
}
