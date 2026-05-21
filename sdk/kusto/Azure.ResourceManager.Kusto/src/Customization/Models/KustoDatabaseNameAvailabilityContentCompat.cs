// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoDatabaseNameAvailabilityContent
    {
        /// <summary> The type of resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public KustoDatabaseResourceType ResourceType =>
            Type == Models.Type.MicrosoftKustoClustersAttachedDatabaseConfigurations
                ? KustoDatabaseResourceType.MicrosoftKustoClustersAttachedDatabaseConfigurations
                : KustoDatabaseResourceType.MicrosoftKustoClustersDatabases;

        /// <summary> Initializes a new instance of <see cref="KustoDatabaseNameAvailabilityContent"/>. </summary>
        /// <param name="name"> Resource name. </param>
        /// <param name="resourceType"> The type of resource. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KustoDatabaseNameAvailabilityContent(string name, KustoDatabaseResourceType resourceType) : this(name, Models.Type.MicrosoftKustoClustersDatabases)
        {
        }
    }
}
