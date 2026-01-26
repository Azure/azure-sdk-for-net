// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosTargetMetadataResource
    {
        /// <summary> Gets a collection of ChaosCapabilityMetadataResources in the ChaosTargetMetadata. </summary>
        /// <returns> An object representing collection of ChaosCapabilityMetadataResources and their operations over a ChaosCapabilityMetadataResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ChaosCapabilityMetadataCollection GetAllChaosCapabilityMetadata()
        {
            return GetChaosCapabilityMetadatas();
        }
    }
}
