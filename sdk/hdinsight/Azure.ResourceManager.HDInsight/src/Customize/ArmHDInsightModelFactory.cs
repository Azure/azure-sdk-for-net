// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.HDInsight.Models
{
    public static partial class ArmHDInsightModelFactory
    {
        // Add this overload due to the property order change after the TypeSpec conversion.
        /// <summary> Initializes a new instance of <see cref="HDInsight.HDInsightApplicationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> The ETag for the application. </param>
        /// <param name="tags"> The tags for the application. </param>
        /// <param name="properties"> The properties of the application. </param>
        /// <returns> A new <see cref="HDInsight.HDInsightApplicationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HDInsightApplicationData HDInsightApplicationData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ETag? etag = null, IDictionary<string, string> tags = null, HDInsightApplicationProperties properties = null)
            => HDInsightApplicationData(id, name, resourceType, systemData, properties, etag, tags);

        // Add this overload due to the property order change after the TypeSpec conversion.
        /// <summary> Initializes a new instance of <see cref="HDInsight.HDInsightClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> The ETag for the resource. </param>
        /// <param name="zones"> The availability zones. </param>
        /// <param name="properties"> The properties of the cluster. </param>
        /// <param name="identity"> The identity of the cluster, if configured. </param>
        /// <returns> A new <see cref="HDInsight.HDInsightClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HDInsightClusterData HDInsightClusterData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ETag? etag = null, IEnumerable<string> zones = null, HDInsightClusterProperties properties = null, ManagedServiceIdentity identity = null)
            => HDInsightClusterData(id, name, resourceType, systemData, tags, location, properties, etag, zones, identity);
    }
}
