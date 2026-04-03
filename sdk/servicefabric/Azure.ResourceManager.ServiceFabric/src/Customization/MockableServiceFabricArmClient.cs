// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ServiceFabric.Mocking
{
    // Generator bug: Missing constructors for MockableServiceFabricArmClient.
    public partial class MockableServiceFabricArmClient
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected MockableServiceFabricArmClient()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MockableServiceFabricArmClient"/>. </summary>
        internal MockableServiceFabricArmClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
