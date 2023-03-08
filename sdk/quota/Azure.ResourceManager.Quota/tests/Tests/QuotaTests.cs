// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class QuotaTests : QuotaManagementTestBase
    {
        private const string Scope = "subscriptions/9f6cce51-6baf-4de5-a3c4-6f58b85315b9/providers/Microsoft.Network/locations/westus";

        public QuotaTests() : base(true)
        {
        }

        [SetUp]
        public void Init()
        {
            CreateCommonClient();
        }

        [TestCase]
        public async Task ListQuotaRequests()
        {
            var response = await this.Client.GetQuotaRequestDetails(new Core.ResourceIdentifier(Scope)).GetAllAsync().ToEnumerableAsync();

            Assert.AreEqual(0, response.Count);
        }
    }
}
