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
    /// <summary> Private endpoint connection data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchPrivateEndpointConnection instead.")]
    public partial class SearchPrivateEndpointConnectionData : ProvisionableConstruct
    {
        private BicepValue<ResourceIdentifier> _id;
        private BicepValue<string> _name;
        private SearchServicePrivateEndpointConnectionProperties _properties;
        private SystemData _systemData;

        /// <summary> Creates a new SearchPrivateEndpointConnectionData. </summary>
        public SearchPrivateEndpointConnectionData()
        {
        }

        /// <summary> Gets the resource id. </summary>
        public BicepValue<ResourceIdentifier> Id { get { Initialize(); return _id; } }

        /// <summary> Gets the resource name. </summary>
        public BicepValue<string> Name { get { Initialize(); return _name; } }

        /// <summary> Gets or sets the private endpoint connection properties. </summary>
        public SearchServicePrivateEndpointConnectionProperties Properties
        {
            get { Initialize(); return _properties; }
            set { Initialize(); AssignOrReplace(ref _properties, value); }
        }

        /// <summary> Gets the system data. </summary>
        public SystemData SystemData { get { Initialize(); return _systemData; } }

        /// <inheritdoc/>
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
