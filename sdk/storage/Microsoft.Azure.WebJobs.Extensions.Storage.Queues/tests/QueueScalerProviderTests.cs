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

        [Test]
        public void ResolveProperties_LowercasesQueueName()
        {
            var metadata = new QueueScalerProvider.QueueMetadata
            {
                Connection = "AnyConnection",
                QueueName = "%MY_QUEUE%" // token to resolve
            };
            var resolver = new TestNameResolver();

            // Act
            metadata.ResolveProperties(resolver);

            // Assert
            Assert.AreEqual("mixedcasequeuename", metadata.QueueName);
        }
    }
}
