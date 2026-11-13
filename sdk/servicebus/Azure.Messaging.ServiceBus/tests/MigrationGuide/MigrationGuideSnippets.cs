// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.MigrationGuide
{
    [TestFixture]
    public class MigrationGuideSnippets
    {
        [Test]
        public async Task BatchMessageSettlement()
        {
            var receiver = Mock.Of<ServiceBusReceiver>();
            var messages = new List<ServiceBusReceivedMessage>();

            #region Snippet:MigrationGuideBatchMessageSettlement

            var tasks = new List<Task>();

            foreach (ServiceBusReceivedMessage message in messages)
            {
                tasks.Add(receiver.CompleteMessageAsync(message));
            }

            await Task.WhenAll(tasks);

            #endregion
        }
    }
}
