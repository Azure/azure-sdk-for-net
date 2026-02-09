// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests
{
    [TestFixture]
    public class QueueScalerProviderTests
    {
        [TestCase("%MY_QUEUE%", "mixedcasequeuename", TestName = "TokenResolvedAndLowercased")]
        [TestCase("MixedCaseQueueName", "mixedcasequeuename", TestName = "DirectMixedCaseLowercased")]
        [TestCase("alreadylowercase", "alreadylowercase", TestName = "AlreadyLowercaseUnchanged")]
        [TestCase("", "", TestName = "EmptyStringRemainsEmpty")]
        [TestCase(null, null, TestName = "NullRemainsNull")]
        public void ResolveProperties_LowercasesQueueName(string queueName, string expectedOutput)
        {
            var metadata = new QueueScalerProvider.QueueMetadata
            {
                Connection = "AnyConnection",
                QueueName = queueName
            };
            var resolver = new TestNameResolver();

            // Act
            metadata.ResolveProperties(resolver);

            // Assert
            Assert.AreEqual(expectedOutput, metadata.QueueName);
        }

        private class TestNameResolver : INameResolver
        {
            public string Resolve(string name)
            {
                if (string.Equals(name, "MY_QUEUE", StringComparison.OrdinalIgnoreCase))
                {
                    return "MixedCaseQueueName"; // will be lowercased by ResolveProperties
                }
                return null;
            }
        }
    }
}
