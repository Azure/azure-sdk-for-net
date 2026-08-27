// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.ServiceBus
{
    // The TypeSpec provisioning generator now emits ServiceBusPrivateEndpointConnection as a child resource.
    // Preserve the old data model type for source and binary compatibility with Azure.Provisioning.ServiceBus 1.1.0.
    /// <summary>
    /// A class representing the ServiceBusPrivateEndpointConnection data model.
    /// Properties of the private endpoint connection.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version. Please use ServiceBusPrivateEndpointConnection instead.")]
    public partial class ServiceBusPrivateEndpointConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _privateEndpointId;
        private ServiceBusPrivateLinkServiceConnectionState _connectionState;
        private BicepValue<ServiceBusPrivateEndpointConnectionProvisioningState> _provisioningState;
        private BicepValue<AzureLocation> _location;
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SystemData _systemData;

        /// <summary> Gets or sets the private endpoint resource identifier. </summary>
        public BicepValue<ResourceIdentifier> PrivateEndpointId
        {
            get
            {
                Initialize();
                return _privateEndpointId;
            }
            set
            {
                Initialize();
                _privateEndpointId.Assign(value);
            }
        }

        /// <summary> Gets or sets details about the state of the connection. </summary>
        public ServiceBusPrivateLinkServiceConnectionState ConnectionState
        {
            get
            {
                Initialize();
                return _connectionState;
            }
            set
            {
                Initialize();
                AssignOrReplace(ref _connectionState, value);
            }
        }

        /// <summary> Gets or sets the provisioning state of the private endpoint connection. </summary>
        public BicepValue<ServiceBusPrivateEndpointConnectionProvisioningState> ProvisioningState
        {
            get
            {
                Initialize();
                return _provisioningState;
            }
            set
            {
                Initialize();
                _provisioningState.Assign(value);
            }
        }

        /// <summary> Gets the geo-location where the resource lives. </summary>
        public BicepValue<AzureLocation> Location
        {
            get
            {
                Initialize();
                return _location;
            }
        }

        /// <summary> Gets the resource identifier. </summary>
        public BicepValue<ResourceIdentifier> Id
        {
            get
            {
                Initialize();
                return _id;
            }
        }

        /// <summary> Gets the resource name. </summary>
        public BicepValue<string> Name
        {
            get
            {
                Initialize();
                return _name;
            }
        }

        /// <summary> Gets the system metadata. </summary>
        public SystemData SystemData
        {
            get
            {
                Initialize();
                return _systemData;
            }
        }

        /// <summary> Creates a new ServiceBusPrivateEndpointConnectionData. </summary>
        public ServiceBusPrivateEndpointConnectionData()
        {
        }

        /// <summary> Defines all provisionable properties of ServiceBusPrivateEndpointConnectionData. </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), new string[] { "properties", "privateEndpoint", "id" });
            _connectionState = DefineModelProperty<ServiceBusPrivateLinkServiceConnectionState>(nameof(ConnectionState), new string[] { "properties", "privateLinkServiceConnectionState" });
            _provisioningState = DefineProperty<ServiceBusPrivateEndpointConnectionProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" });
            _location = DefineProperty<AzureLocation>(nameof(Location), new string[] { "location" }, isOutput: true);
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
