// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Search
{
    [CodeGenSuppress("PrivateEndpointConnections")]
    [CodeGenSuppress("SharedPrivateLinkResources")]
    [CodeGenSuppress("IsUpgradeAvailable")]
    public partial class SearchService
    {
        private BicepList<SearchDisabledDataExfiltrationOption> _disabledDataExfiltrationOptions;
        private BicepList<SearchServiceIPRule> _iPRules;
        private BicepValue<bool> _isUpgradeAvailableCompat;
        private BicepList<SearchPrivateEndpointConnectionData> _privateEndpointConnectionsCompat;
        private BicepValue<SearchServicePublicNetworkAccess> _publicNetworkAccess;
        private BicepValue<DateTimeOffset> _serviceUpgradeOn;
        private BicepList<SharedSearchServicePrivateLinkResourceData> _sharedPrivateLinkResourcesCompat;

        /// <summary> Gets or sets the disabled data exfiltration options. </summary>
        public BicepList<SearchDisabledDataExfiltrationOption> DisabledDataExfiltrationOptions
        {
            get { Initialize(); return _disabledDataExfiltrationOptions; }
            set { Initialize(); _disabledDataExfiltrationOptions.Assign(value); }
        }

        /// <summary> Gets or sets the IP rules. </summary>
        public BicepList<SearchServiceIPRule> IPRules
        {
            get { Initialize(); return _iPRules; }
            set { Initialize(); _iPRules.Assign(value); }
        }

        /// <summary> Gets a value indicating whether an upgrade is available. </summary>
        public BicepValue<bool> IsUpgradeAvailable
        {
            get { Initialize(); return _isUpgradeAvailableCompat; }
        }

        /// <summary> Gets the private endpoint connections. </summary>
        public BicepList<SearchPrivateEndpointConnectionData> PrivateEndpointConnections
        {
            get { Initialize(); return _privateEndpointConnectionsCompat; }
        }

        /// <summary> Gets or sets the public network access setting. </summary>
        public BicepValue<SearchServicePublicNetworkAccess> PublicNetworkAccess
        {
            get { Initialize(); return _publicNetworkAccess; }
            set { Initialize(); _publicNetworkAccess.Assign(value); }
        }

        /// <summary> Gets the service upgrade time. </summary>
        public BicepValue<DateTimeOffset> ServiceUpgradeOn
        {
            get { Initialize(); return _serviceUpgradeOn; }
        }

        /// <summary> Gets the shared private link resources. </summary>
        public BicepList<SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources
        {
            get { Initialize(); return _sharedPrivateLinkResourcesCompat; }
        }

        partial void DefineAdditionalProperties()
        {
            _disabledDataExfiltrationOptions = DefineListProperty<SearchDisabledDataExfiltrationOption>(nameof(DisabledDataExfiltrationOptions), new string[] { "properties", "disabledDataExfiltrationOptions" });
            _iPRules = DefineListProperty<SearchServiceIPRule>(nameof(IPRules), new string[] { "properties", "networkRuleSet", "ipRules" });
            _isUpgradeAvailableCompat = DefineProperty<bool>(nameof(IsUpgradeAvailable), new string[] { "properties", "upgradeAvailable" }, isOutput: true);
            _privateEndpointConnectionsCompat = DefineListProperty<SearchPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
            _publicNetworkAccess = DefineProperty<SearchServicePublicNetworkAccess>(nameof(PublicNetworkAccess), new string[] { "properties", "publicNetworkAccess" });
            _serviceUpgradeOn = DefineProperty<DateTimeOffset>(nameof(ServiceUpgradeOn), new string[] { "properties", "serviceUpgradeDate" }, isOutput: true);
            _sharedPrivateLinkResourcesCompat = DefineListProperty<SharedSearchServicePrivateLinkResourceData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
        }
    }
}
