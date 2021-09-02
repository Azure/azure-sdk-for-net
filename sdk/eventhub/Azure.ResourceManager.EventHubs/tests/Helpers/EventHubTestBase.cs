// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EventHubs.Tests.Helpers
{
    [ClientTestFixture]
    public class EventHubTestBase:ManagementRecordedTestBase<EventHubsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected EventHubTestBase(bool isAsync) : base(isAsync)
        {
        }
        public EventHubTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }
        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }
    }
}
