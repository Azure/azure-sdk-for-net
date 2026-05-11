// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Patch model for NetApp accounts. </summary>
    public partial class NetAppAccountPatch : TrackedResourceData
    {
        /// <summary> Azure lifecycle management. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState { get; }

        /// <summary> Shows the status of disableShowmount for all volumes under the subscription, null equals false. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DisableShowmount { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal NetAppAccountPatch(ResourceIdentifier id, string name, ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, IEnumerable<NetAppAccountActiveDirectory> activeDirectories, NetAppAccountEncryption encryption, bool? disableShowmount, string nfsV4IdDomain, MultiAdStatus? multiAdStatus, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData, tags, location)
        {
            Identity = identity;
            ProvisioningState = provisioningState;
            ActiveDirectories = activeDirectories?.ToList();
            Encryption = encryption;
            DisableShowmount = disableShowmount;
            NfsV4IdDomain = nfsV4IdDomain;
            MultiAdStatus = multiAdStatus;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
