// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrder.Tests.Tests
{
    [TestFixture]
    public class OperationsTests : EdgeOrderManagementClientBase
    {
        public OperationsTests() : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task ListOperationsTest()
        {
            var operations = EdgeOrderManagementOperations.ListOperationsAsync();
            var operationsResult = await operations.ToEnumerableAsync();

            Assert.NotNull(operationsResult);
            Assert.IsTrue(operationsResult.Count >= 1);
        }
    }
}
