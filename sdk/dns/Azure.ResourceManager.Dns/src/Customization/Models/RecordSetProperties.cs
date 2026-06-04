// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources.Models;

[assembly: CodeGenSuppressType("RecordSetProperties")]

namespace Azure.ResourceManager.Dns.Models
{
    /// <summary> Represents the properties of the records in the record set. </summary>
    internal partial class RecordSetProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="RecordSetProperties"/>. </summary>
        public RecordSetProperties()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="RecordSetProperties"/>. </summary>
        /// <param name="metadata"> The metadata attached to the record set. </param>
        /// <param name="ttlInSeconds"> The TTL (time-to-live) of the records in the record set. </param>
        /// <param name="fqdn"> Fully qualified domain name of the record set. </param>
        /// <param name="provisioningState"> provisioning State of the record set. </param>
        /// <param name="targetResource"> A reference to an azure resource from where the dns resource value is taken. </param>
        /// <param name="trafficManagementProfile"> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal RecordSetProperties(IDictionary<string, string> metadata, long? ttlInSeconds, string fqdn, string provisioningState, WritableSubResource targetResource, WritableSubResource trafficManagementProfile, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Metadata = metadata;
            TtlInSeconds = ttlInSeconds;
            Fqdn = fqdn;
            ProvisioningState = provisioningState;
            TargetResource = targetResource;
            TrafficManagementProfile = trafficManagementProfile;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The metadata attached to the record set. </summary>
        public IDictionary<string, string> Metadata { get; } = new ChangeTrackingDictionary<string, string>();

        /// <summary> The TTL (time-to-live) of the records in the record set. </summary>
        public long? TtlInSeconds { get; set; }

        /// <summary> Fully qualified domain name of the record set. </summary>
        public string Fqdn { get; }

        /// <summary> provisioning State of the record set. </summary>
        public string ProvisioningState { get; }

        /// <summary> A reference to an azure resource from where the dns resource value is taken. </summary>
        public WritableSubResource TargetResource { get; set; }

        /// <summary> A reference to an azure traffic manager profile resource from where the dns resource value is taken. </summary>
        public WritableSubResource TrafficManagementProfile { get; set; }
    }
}
