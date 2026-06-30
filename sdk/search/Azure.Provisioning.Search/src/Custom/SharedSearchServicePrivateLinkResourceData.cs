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
            get
            {
                if (Properties is null)
                {
                    Properties = new SharedSearchServicePrivateLinkResourceProperties();
                }
                return Properties.ProvisioningState;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SharedSearchServicePrivateLinkResourceProperties();
                }
                Properties.ProvisioningState = value;
            }
        }

        public BicepValue<SharedSearchServicePrivateLinkResourceStatus> Status
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new SharedSearchServicePrivateLinkResourceProperties();
                }
                return Properties.Status;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new SharedSearchServicePrivateLinkResourceProperties();
                }
                Properties.Status = value;
            }
        }

        public SystemData SystemData { get { Initialize(); return _systemData; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _properties = DefineModelProperty<SharedSearchServicePrivateLinkResourceProperties>(nameof(Properties), new string[] { "properties" });
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
