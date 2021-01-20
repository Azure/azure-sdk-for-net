// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ContainerInstance.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ContainerInstance.Tests.Tests
{
    /// <summary>
    /// Tests for container instance operation SDK.
    /// </summary>
    public partial class OperationsTests : ContainerInstanceManagementClientBase
    {
        public OperationsTests(bool isAsync) : base(isAsync)
        {
        }
        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task OperationsListTest()
        {
            var operations = await Operations.ListAsync().ToEnumerableAsync();
            Assert.NotNull(operations);
        }
    }
}
