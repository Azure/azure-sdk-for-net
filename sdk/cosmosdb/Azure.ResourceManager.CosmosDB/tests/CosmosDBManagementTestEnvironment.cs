// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    public class CosmosDBManagementTestEnvironment : TestEnvironment
    {
        public CosmosDBManagementTestEnvironment() : base("cosmosdb")
        {
        }
    }
}
