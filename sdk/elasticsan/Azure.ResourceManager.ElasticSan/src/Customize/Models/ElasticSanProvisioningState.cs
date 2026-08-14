// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.ElasticSan.Models
{
    // Manually added back for completed compatibility
    public readonly partial struct ElasticSanProvisioningState
    {
        private const string SoftDeletingValue = "SoftDeleting";

        /// <summary> SoftDeleting. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanProvisioningState SoftDeleting { get; } = new ElasticSanProvisioningState(SoftDeletingValue);
    }
}
