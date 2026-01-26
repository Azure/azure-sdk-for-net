// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Chaos
{
    public partial class ChaosTargetMetadataResource
    {
        /// <summary> Gets a collection of ChaosCapabilityMetadataResources in the ChaosTargetMetadata. </summary>
        /// <returns> An object representing collection of ChaosCapabilityMetadataResources and their operations over a ChaosCapabilityMetadataResource. </returns>
        public virtual ChaosCapabilityMetadataCollection GetAllChaosCapabilityMetadata()
        {
            return GetCachedClient(client => new ChaosCapabilityMetadataCollection(client, Id));
        }
    }
}
