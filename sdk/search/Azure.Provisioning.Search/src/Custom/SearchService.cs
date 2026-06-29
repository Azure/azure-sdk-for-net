// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

#nullable disable

namespace Azure.Provisioning.Search
{
    public partial class SearchService
    {
        private BicepList<SearchPrivateEndpointConnectionData> _privateEndpointConnectionsCompat;
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
            _sharedPrivateLinkResourcesCompat = DefineListProperty<SharedSearchServicePrivateLinkResourceData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
        }
    }
}
