// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using System;
using System.ComponentModel;

#nullable disable

namespace Azure.Provisioning.Search
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SharedSearchServicePrivateLink instead.")]
    public partial class SharedSearchServicePrivateLinkResourceData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SharedSearchServicePrivateLinkResourceProperties _properties;
#pragma warning disable CS0618 // Compatibility shim intentionally references obsolete types.
        private BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> _provisioningState;
        private BicepValue<SharedSearchServicePrivateLinkResourceStatus> _status;
#pragma warning restore CS0618
        private SystemData _systemData;

        public SharedSearchServicePrivateLinkResourceData()
        {
        }

        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

        public BicepValue<string> Name { get { Initialize(); return _name; } }

        public SharedSearchServicePrivateLinkResourceProperties Properties
        {
            get { Initialize(); return _properties; }
            set { Initialize(); AssignOrReplace(ref _properties, value); }
        }

        public BicepValue<SharedSearchServicePrivateLinkResourceProvisioningState> ProvisioningState
        {
            get { Initialize(); return _provisioningState; }
            set { Initialize(); _provisioningState.Assign(value); }
        }

        public BicepValue<SharedSearchServicePrivateLinkResourceStatus> Status
        {
            get { Initialize(); return _status; }
            set { Initialize(); _status.Assign(value); }
        }

        public SystemData SystemData { get { Initialize(); return _systemData; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _properties = DefineModelProperty<SharedSearchServicePrivateLinkResourceProperties>(nameof(Properties), new string[] { "properties" });
#pragma warning disable CS0618
            _provisioningState = DefineProperty<SharedSearchServicePrivateLinkResourceProvisioningState>(nameof(ProvisioningState), new string[] { "properties", "provisioningState" });
            _status = DefineProperty<SharedSearchServicePrivateLinkResourceStatus>(nameof(Status), new string[] { "properties", "status" });
#pragma warning restore CS0618
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
