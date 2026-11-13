// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Publisher was removed from stable APIs starting with 2026-02-01 and is now preview-only.
// This release targets a stable API, so its properties model is maintained as customization code.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Hci;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Publisher properties. </summary>
    internal partial class PublisherProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="PublisherProperties"/>. </summary>
        public PublisherProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="PublisherProperties"/>. </summary>
        /// <param name="provisioningState"> Provisioning State. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal PublisherProperties(string provisioningState, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            ProvisioningState = provisioningState;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> Provisioning State. </summary>
        [WirePath("provisioningState")]
        public string ProvisioningState { get; }
    }
}
