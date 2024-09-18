// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.IoTOperations;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class IoTOperationsManagementTestBase : ManagementRecordedTestBase<IoTOperationsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected IoTOperationsManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
        }

        protected IoTOperationsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public Task CreateCommonTestResources()
        {
            Client = new ArmClient(new DefaultAzureCredential());
            return Task.CompletedTask;
        }
    }
}
