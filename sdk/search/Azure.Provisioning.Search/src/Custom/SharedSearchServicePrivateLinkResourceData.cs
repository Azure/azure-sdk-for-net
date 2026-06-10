// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Search
{
    /// <summary> Shared private link resource data. </summary>
    public partial class SharedSearchServicePrivateLinkResourceData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SharedSearchServicePrivateLinkResourceProperties _properties;
        private BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> _provisioningState;
        private BicepValue<SharedSearchServicePrivateLinkResourceStatus> _status;
        private SystemData _systemData;

        /// <summary> Creates a new SharedSearchServicePrivateLinkResourceData. </summary>
        public SharedSearchServicePrivateLinkResourceData()
        {
        }

        /// <summary> Gets the Id. </summary>
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

        /// <summary> Gets the Name. </summary>
        public BicepValue<string> Name { get { Initialize(); return _name; } }

        /// <summary> Gets or sets the Properties. </summary>
        public SharedSearchServicePrivateLinkResourceProperties Properties
        {
            get { Initialize(); return _properties; }
            set { Initialize(); AssignOrReplace(ref _properties, value); }
        }

        /// <summary> Gets or sets the ProvisioningState. </summary>
        public BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> ProvisioningState
        {
            get { Initialize(); return _provisioningState; }
            set { Initialize(); _provisioningState.Assign(value); }
        }

        /// <summary> Gets or sets the Status. </summary>
        public BicepValue<SharedSearchServicePrivateLinkResourceStatus> Status
        {
            get { Initialize(); return _status; }
            set { Initialize(); _status.Assign(value); }
        }

        /// <summary> Gets the SystemData. </summary>
        public SystemData SystemData { get { Initialize(); return _systemData; } }

        /// <inheritdoc/>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _properties = DefineModelProperty<SharedSearchServicePrivateLinkResourceProperties>(nameof(Properties), new string[] { "properties" });
            _provisioningState = DefineProperty<SharedSearchServicePrivateLinkResourceProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" });
            _status = DefineProperty<SharedSearchServicePrivateLinkResourceStatus>(nameof(Status), new string[] { "properties", "status" });
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
