// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.ElasticSan.Models;

namespace Azure.ResourceManager.ElasticSan
{
    /// Manually added back for completed compatibility
    public partial class ElasticSanSnapshotData
    {
        /// <summary> Initializes a new instance of <see cref="ElasticSanSnapshotData"/>. </summary>
        /// <param name="creationData"> Data used when creating a volume snapshot. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="creationData"/> is null. </exception>
        public ElasticSanSnapshotData(SnapshotCreationInfo creationData)
        {
            Argument.AssertNotNull(creationData, nameof(creationData));

            CreationData = creationData;
        }

        /// <summary> Data used when creating a volume snapshot. </summary>
        internal SnapshotCreationInfo CreationData { get; set; }
        /// <summary> Fully qualified resource ID of the volume. E.g. "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}/volumegroups/{volumeGroupName}/volumes/{volumeName}". </summary>
        public ResourceIdentifier CreationDataSourceId
        {
            get => CreationData is null ? default : CreationData.SourceId;
            set => CreationData = new SnapshotCreationInfo(value);
        }
    }
}
