// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;

#nullable disable

namespace Azure.Provisioning.Search
{
    public partial class SearchPrivateEndpointConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SearchServicePrivateEndpointConnectionProperties _properties;
        private SystemData _systemData;

        public SearchPrivateEndpointConnectionData()
        {
        }

        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

        public BicepValue<string> Name { get { Initialize(); return _name; } }

        public SearchServicePrivateEndpointConnectionProperties Properties
        {
            get { Initialize(); return _properties; }
            set { Initialize(); AssignOrReplace(ref _properties, value); }
        }

        public SystemData SystemData { get { Initialize(); return _systemData; } }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<ResourceIdentifier>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _properties = DefineModelProperty<SearchServicePrivateEndpointConnectionProperties>(nameof(Properties), new string[] { "properties" });
            _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
        }
    }
}
