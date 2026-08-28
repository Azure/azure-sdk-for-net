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
        /// <summary> Gets the private endpoint connection resources. </summary>
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

        /// <summary> Gets the private endpoint connection data. </summary>
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

        /// <summary> Gets or sets the disabled data exfiltration options. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsoleted and will be removed in a future version, please use DataExfiltrationProtections instead.")]
        public BicepList<SearchDisabledDataExfiltrationOption> DisabledDataExfiltrationOptions
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                return Properties.DisabledDataExfiltrationOptions;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SearchServiceProperties();
                }
                Properties.DisabledDataExfiltrationOptions = value;
            }
        }

        /// <summary> Gets or sets the IP rules. </summary>
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

        /// <summary> Gets or sets the public network access setting. </summary>
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

        /// <summary> Gets the shared private link resource items. </summary>
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

        /// <summary> Gets the shared private link resource data. </summary>
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
