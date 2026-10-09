// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.RedisEnterprise
{
    /// <summary> The secret access keys used for authenticating connections to Redis. </summary>
    public partial class RedisEnterpriseDataAccessKeys : ProvisionableConstruct
    {
        private BicepValue<string> _primaryKey;
        private BicepValue<string> _secondaryKey;

        /// <summary> Creates a new RedisEnterpriseDataAccessKeys. </summary>
        public RedisEnterpriseDataAccessKeys()
        {
        }

        /// <summary> Gets the current primary key that clients can use to authenticate. </summary>
        public BicepValue<string> PrimaryKey
        {
            get { Initialize(); return _primaryKey; }
        }

        /// <summary> Gets the current secondary key that clients can use to authenticate. </summary>
        public BicepValue<string> SecondaryKey
        {
            get { Initialize(); return _secondaryKey; }
        }

        /// <inheritdoc />
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _primaryKey = DefineProperty<string>(nameof(PrimaryKey), new string[] { "primaryKey" }, isOutput: true);
            _secondaryKey = DefineProperty<string>(nameof(SecondaryKey), new string[] { "secondaryKey" }, isOutput: true);
        }
    }
}
