// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        [OneTimeSetUp]
        public void SetExceptionList()
        {
            ExceptionList = new string[]
            {
                "CosmosDBTablePropertiesResource",
                "RestorableMongoDBCollection",
                // MPG migration: model types that happen to end with Resource/Collection but are not ARM resources/collections.
                "ARMProxyResource",
                "CassandraViewGetPropertiesResource",
                "CosmosDBMongoCollection",
                "CosmosDBMongoVCoreCollection",
                "PhysicalPartitionStorageInfoCollection",
                "PhysicalPartitionThroughputInfoResource",
                "RedistributeThroughputPropertiesResource",
            };
        }
    }
}
