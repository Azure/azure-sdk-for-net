// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;
using System;
using System.ComponentModel;

#nullable disable
#pragma warning disable CS0618 // Compatibility shims intentionally reference obsolete members.

namespace Azure.Provisioning.Search
{
    public partial class SearchService
    {
        private BicepList<SearchPrivateEndpointConnectionData> _privateEndpointConnectionsCompat;
        private BicepValue<SearchServicePublicNetworkAccess> _publicNetworkAccess;
        private BicepList<SharedSearchServicePrivateLinkResourceData> _sharedPrivateLinkResourcesCompat;

        [CodeGenMember("PrivateEndpointConnections")]
        public BicepList<SearchPrivateEndpointConnection> PrivateEndpointConnectionResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                return Properties.PrivateEndpointConnections;
            }
        }
        public BicepList<SearchPrivateEndpointConnectionData> PrivateEndpointConnections
        {
            get { Initialize(); return _privateEndpointConnectionsCompat; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BicepList<SearchServiceIPRule> IPRules
        {
            get
            {
                if (NetworkRuleSet is null)
                {
                    NetworkRuleSet = new SearchServiceNetworkRuleSet();
                }
                return NetworkRuleSet.IPRules;
            }
            set
            {
                if (NetworkRuleSet is null)
                {
                    NetworkRuleSet = new SearchServiceNetworkRuleSet();
                }
                NetworkRuleSet.IPRules = value;
            }
        }
        #pragma warning restore CS0618

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use PublicInternetAccess instead.")]
        public BicepValue<SearchServicePublicNetworkAccess> PublicNetworkAccess
        {
            get { Initialize(); return _publicNetworkAccess; }
            set { Initialize(); _publicNetworkAccess.Assign(value); }
        }

        [CodeGenMember("SharedPrivateLinkResources")]
        public BicepList<SharedSearchServicePrivateLink> SharedPrivateLinkResourceItems
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                return Properties.SharedPrivateLinkResources;
            }
        }

        public BicepList<SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources
        {
            get { Initialize(); return _sharedPrivateLinkResourcesCompat; }
        }

        partial void DefineAdditionalProperties()
        {
            _privateEndpointConnectionsCompat = DefineListProperty<SearchPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
#pragma warning disable CS0618
            _publicNetworkAccess = DefineProperty<SearchServicePublicNetworkAccess>("PublicNetworkAccess", new string[] { "properties", "publicNetworkAccess" });
#pragma warning restore CS0618
            _sharedPrivateLinkResourcesCompat = DefineListProperty<SharedSearchServicePrivateLinkResourceData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
        }
    }
}
