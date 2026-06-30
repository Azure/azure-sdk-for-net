// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;
using System;
using System.ComponentModel;

#nullable disable

namespace Azure.Provisioning.Search
{
    public partial class SearchService
    {
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version, please use PrivateEndpointConnectionResources instead.")]
        public BicepList<SearchPrivateEndpointConnectionData> PrivateEndpointConnections
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                return Properties.PrivateEndpointConnectionData;
            }
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version, please use PublicInternetAccess instead.")]
        public BicepValue<SearchServicePublicNetworkAccess> PublicNetworkAccess
        {
            get
            {
                return Properties is null ? default : Properties.PublicNetworkAccess;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                Properties.PublicNetworkAccess = value;
            }
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version, please use SharedPrivateLinkResourceItems instead.")]
        public BicepList<SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResources
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                return Properties.SharedPrivateLinkResourceData;
            }
        }

        partial void DefineAdditionalProperties()
        {
        }
    }
}
