// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SerialConsole.Tests
{
    [TestFixture]
    [Ignore("SerialConsole scenario recording is pending; requires a configured Record-mode authentication environment.")]
    public class SerialPortTests : SerialConsoleManagementTestBase
    {
        public SerialPortTests()
            : base(true)
        {
        }

        [Test]
        [RecordedTest]
        public async Task GetBySubscriptions_GetsSerialPorts()
        {
            var result = await DefaultSubscription.GetBySubscriptionsAsync();

            Assert.That(result.Value, Is.Not.Null);
        }
    }
}
