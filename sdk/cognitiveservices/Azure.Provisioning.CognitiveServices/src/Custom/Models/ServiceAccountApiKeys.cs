// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CognitiveServices
{
    /// <summary> The access keys for the cognitive services account. </summary>
    public partial class ServiceAccountApiKeys : ProvisionableConstruct
    {
        private BicepValue<string> _key1;
        private BicepValue<string> _key2;

        /// <summary> Creates a new ServiceAccountApiKeys. </summary>
        public ServiceAccountApiKeys()
        {
        }

        /// <summary> Gets the value of key 1. </summary>
        public BicepValue<string> Key1
        {
            get
            {
                Initialize();
                return _key1;
            }
        }

        /// <summary> Gets the value of key 2. </summary>
        public BicepValue<string> Key2
        {
            get
            {
                Initialize();
                return _key2;
            }
        }

        /// <summary> Define all the provisionable properties of ServiceAccountApiKeys. </summary>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _key1 = DefineProperty<string>(nameof(Key1), new string[] { "key1" }, isOutput: true);
            _key2 = DefineProperty<string>(nameof(Key2), new string[] { "key2" }, isOutput: true);
        }
    }
}
