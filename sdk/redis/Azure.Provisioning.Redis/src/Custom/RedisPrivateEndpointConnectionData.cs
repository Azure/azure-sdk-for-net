// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Redis
{
    /// <summary>
    /// A class representing the RedisPrivateEndpointConnection data model.
    /// The Private Endpoint Connection resource.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version. Please use RedisPrivateEndpointConnection instead.")]
    public partial class RedisPrivateEndpointConnectionData : ProvisionableConstruct
    {
        // The TypeSpec provisioning generator now emits RedisPrivateEndpointConnection as a child resource.
        // Preserve the old data model type for source and binary compatibility with Azure.Provisioning.Redis 1.1.0.
        private BicepValue<ResourceIdentifier> _privateEndpointId;
        private RedisPrivateLinkServiceConnectionState _redisPrivateLinkServiceConnectionState;
        private BicepValue<RedisPrivateEndpointConnectionProvisioningState> _redisProvisioningState;
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SystemData _systemData;

        /// <summary>
        /// Gets Id.
        /// </summary>
        public BicepValue<ResourceIdentifier> PrivateEndpointId
        {
            get
            {
                Initialize();
                return _privateEndpointId;
            }
        }

        /// <summary>
        /// A collection of information about the state of the connection between service consumer and provider.
        /// </summary>
        public RedisPrivateLinkServiceConnectionState RedisPrivateLinkServiceConnectionState
        {
            get
            {
                Initialize();
                return _redisPrivateLinkServiceConnectionState;
            }
            set
            {
                Initialize();
                AssignOrReplace(ref _redisPrivateLinkServiceConnectionState, value);
            }
        }

        /// <summary>
        /// The provisioning state of the private endpoint connection resource.
        /// </summary>
        public BicepValue<RedisPrivateEndpointConnectionProvisioningState> RedisProvisioningState
        {
            get
            {
                Initialize();
                return _redisProvisioningState;
            }
        }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        public BicepValue<ResourceIdentifier> Id
        {
            get
            {
                Initialize();
                return _id;
            }
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public BicepValue<string> Name
        {
            get
            {
                Initialize();
                return _name;
            }
        }

        /// <summary>
        /// Gets the SystemData.
        /// </summary>
        public SystemData SystemData
        {
            get
            {
                Initialize();
                return _systemData;
            }
        }

        /// <summary>
        /// Creates a new RedisPrivateEndpointConnectionData.
        /// </summary>
        public RedisPrivateEndpointConnectionData()
        {
        }

        /// <summary>
        /// Define all the provisionable properties of RedisPrivateEndpointConnectionData.
        /// </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), new string[] { "properties", "privateEndpoint", "id" }, isOutput: true);
            _redisPrivateLinkServiceConnectionState = DefineModelProperty<RedisPrivateLinkServiceConnectionState>(nameof(RedisPrivateLinkServiceConnectionState), new string[] { "properties", "privateLinkServiceConnectionState" });
            _redisProvisioningState = DefineProperty<RedisPrivateEndpointConnectionProvisioningState>(nameof(RedisProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
