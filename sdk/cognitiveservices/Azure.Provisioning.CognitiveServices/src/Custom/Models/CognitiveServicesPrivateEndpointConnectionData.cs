// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.CognitiveServices
{
    /// <summary> Compatibility model for the private endpoint connection data shape exposed by previous Azure.Provisioning.CognitiveServices releases. Use <see cref="CognitiveServicesPrivateEndpointConnection"/> instead. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsolete and will be removed in a future release. Use CognitiveServicesPrivateEndpointConnection instead.")]
    public partial class CognitiveServicesPrivateEndpointConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SystemData _systemData;
        private BicepValue<ETag> _eTag;
        private BicepValue<AzureLocation> _location;
        private CognitiveServicesPrivateLinkServiceConnectionState _connectionState;
        private BicepValue<CognitiveServicesPrivateEndpointConnectionProvisioningState> _provisioningState;
        private BicepList<string> _groupIds;
        private BicepValue<ResourceIdentifier> _privateEndpointId;

        /// <summary> Creates a new CognitiveServicesPrivateEndpointConnectionData. </summary>
        public CognitiveServicesPrivateEndpointConnectionData()
        {
        }

        /// <summary> Gets the Id. </summary>
        public BicepValue<ResourceIdentifier> Id
        {
            get
            {
                Initialize();
                return _id;
            }
        }

        /// <summary> Gets the Name. </summary>
        public BicepValue<string> Name
        {
            get
            {
                Initialize();
                return _name;
            }
        }

        /// <summary> Gets the SystemData. </summary>
        public SystemData SystemData
        {
            get
            {
                Initialize();
                return _systemData;
            }
        }

        /// <summary> Gets the ETag. </summary>
        public BicepValue<ETag> ETag
        {
            get
            {
                Initialize();
                return _eTag;
            }
        }

        /// <summary> Gets or sets the Location. </summary>
        public BicepValue<AzureLocation> Location
        {
            get
            {
                Initialize();
                return _location;
            }
            set
            {
                Initialize();
                _location.Assign(value);
            }
        }

        /// <summary> Gets or sets the ConnectionState. </summary>
        public CognitiveServicesPrivateLinkServiceConnectionState ConnectionState
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

        /// <summary> Gets the ProvisioningState. </summary>
        public BicepValue<CognitiveServicesPrivateEndpointConnectionProvisioningState> ProvisioningState
        {
            get
            {
                Initialize();
                return _provisioningState;
            }
        }

        /// <summary> Gets or sets the GroupIds. </summary>
        public BicepList<string> GroupIds
        {
            get
            {
                Initialize();
                return _groupIds;
            }
            set
            {
                Initialize();
                _groupIds.Assign(value);
            }
        }

        /// <summary> Gets the Id. </summary>
        public BicepValue<ResourceIdentifier> PrivateEndpointId
        {
            get
            {
                Initialize();
                return _privateEndpointId;
            }
        }

        /// <summary> Define all the provisionable properties for CognitiveServicesPrivateEndpointConnectionData. </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
            _eTag = DefineProperty<ETag>(nameof(ETag), new string[] { "etag" }, isOutput: true);
            _location = DefineProperty<AzureLocation>(nameof(Location), new string[] { "location" });
            _connectionState = DefineModelProperty<CognitiveServicesPrivateLinkServiceConnectionState>(nameof(ConnectionState), new string[] { "properties", "privateLinkServiceConnectionState" }, isRequired: true);
            _provisioningState = DefineProperty<CognitiveServicesPrivateEndpointConnectionProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" }, isOutput: true);
            _groupIds = DefineListProperty<string>(nameof(GroupIds), new string[] { "properties", "groupIds" });
            _privateEndpointId = DefineProperty<ResourceIdentifier>(nameof(PrivateEndpointId), new string[] { "properties", "privateEndpoint", "id" }, isOutput: true);
        }
    }
}
