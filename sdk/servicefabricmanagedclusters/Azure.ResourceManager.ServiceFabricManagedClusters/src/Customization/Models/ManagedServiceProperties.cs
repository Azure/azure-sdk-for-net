// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    public partial class ManagedServiceProperties : ManagedServiceBaseProperties
    {
        /// <summary> Initializes a new instance of <see cref="ManagedServiceProperties"/>. </summary>
        /// <param name="serviceTypeName"> The name of the service type. </param>
        /// <param name="partitionDescription"> Describes how the service is partitioned. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceTypeName"/> or <paramref name="partitionDescription"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceProperties(string serviceTypeName, ManagedServicePartitionScheme partitionDescription)
        {
            Argument.AssertNotNull(serviceTypeName, nameof(serviceTypeName));
            Argument.AssertNotNull(partitionDescription, nameof(partitionDescription));

            ServiceTypeName = serviceTypeName;
            PartitionDescription = partitionDescription;
            ServiceKind = "unknown";
        }
    }
}
