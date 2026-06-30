// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;

#nullable disable

namespace Azure.Provisioning.Search
{
    internal partial class SearchServiceProperties
    {
#pragma warning disable CS0618 // Compatibility shims intentionally reference obsolete types.
        private BicepList<SearchPrivateEndpointConnectionData> _privateEndpointConnectionData;
        private BicepList<SharedSearchServicePrivateLinkResourceData> _sharedPrivateLinkResourceData;
        private BicepValue<SearchServicePublicNetworkAccess> _publicNetworkAccess;
#pragma warning restore CS0618

#pragma warning disable CS0618 // Compatibility shim intentionally exposes obsolete type.
        internal BicepList<SearchPrivateEndpointConnectionData> PrivateEndpointConnectionData
        {
            get { Initialize(); return _privateEndpointConnectionData; }
        }
#pragma warning restore CS0618

#pragma warning disable CS0618 // Compatibility shim intentionally exposes obsolete type.
        internal BicepList<SharedSearchServicePrivateLinkResourceData> SharedPrivateLinkResourceData
        {
            get { Initialize(); return _sharedPrivateLinkResourceData; }
        }
#pragma warning restore CS0618

#pragma warning disable CS0618 // Compatibility shim intentionally exposes obsolete type.
        internal BicepValue<SearchServicePublicNetworkAccess> PublicNetworkAccess
        {
            get { Initialize(); return _publicNetworkAccess; }
            set { Initialize(); _publicNetworkAccess.Assign(value); }
        }
#pragma warning restore CS0618

        partial void DefineAdditionalProperties()
        {
#pragma warning disable CS0618 // Compatibility shims intentionally register obsolete types.
            _privateEndpointConnectionData = DefineListProperty<SearchPrivateEndpointConnectionData>("PrivateEndpointConnections", new string[] { "privateEndpointConnections" }, isOutput: true);
            _sharedPrivateLinkResourceData = DefineListProperty<SharedSearchServicePrivateLinkResourceData>("SharedPrivateLinkResources", new string[] { "sharedPrivateLinkResources" }, isOutput: true);
            _publicNetworkAccess = DefineProperty<SearchServicePublicNetworkAccess>("PublicNetworkAccess", new string[] { "publicNetworkAccess" });
#pragma warning restore CS0618
        }
    }
}
