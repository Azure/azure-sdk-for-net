// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppConfiguration
{
    /// <summary> An API key used for authenticating with a configuration store endpoint. </summary>
    public partial class AppConfigurationStoreApiKey : ProvisionableConstruct
    {
        private BicepValue<string> _id;
        private BicepValue<string> _name;
        private BicepValue<string> _value;
        private BicepValue<string> _connectionString;
        private BicepValue<DateTimeOffset> _lastModifiedOn;
        private BicepValue<bool> _isReadOnly;

        /// <summary> Creates a new AppConfigurationStoreApiKey. </summary>
        public AppConfigurationStoreApiKey()
        {
        }

        /// <summary> Gets the key ID. </summary>
        public BicepValue<string> Id
        {
            get { Initialize(); return _id; }
        }

        /// <summary> Gets the name describing the key usage. </summary>
        public BicepValue<string> Name
        {
            get { Initialize(); return _name; }
        }

        /// <summary> Gets the key value used for authentication. </summary>
        public BicepValue<string> Value
        {
            get { Initialize(); return _value; }
        }

        /// <summary> Gets a connection string for supporting clients. </summary>
        public BicepValue<string> ConnectionString
        {
            get { Initialize(); return _connectionString; }
        }

        /// <summary> Gets the last time the key was modified. </summary>
        public BicepValue<DateTimeOffset> LastModifiedOn
        {
            get { Initialize(); return _lastModifiedOn; }
        }

        /// <summary> Gets whether the key can only be used for read operations. </summary>
        public BicepValue<bool> IsReadOnly
        {
            get { Initialize(); return _isReadOnly; }
        }

        /// <inheritdoc />
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _id = DefineProperty<string>(nameof(Id), new string[] { "id" }, isOutput: true);
            _name = DefineProperty<string>(nameof(Name), new string[] { "name" }, isOutput: true);
            _value = DefineProperty<string>(nameof(Value), new string[] { "value" }, isOutput: true, isSecure: true);
            _connectionString = DefineProperty<string>(nameof(ConnectionString), new string[] { "connectionString" }, isOutput: true, isSecure: true);
            _lastModifiedOn = DefineProperty<DateTimeOffset>(nameof(LastModifiedOn), new string[] { "lastModified" }, isOutput: true);
            _isReadOnly = DefineProperty<bool>(nameof(IsReadOnly), new string[] { "readOnly" }, isOutput: true);
        }
    }
}
