// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample24_NonExclusiveSessions : ServiceBusLiveTestBase
    {
        [Test]
        public async Task TakeOverNonExclusiveSession()
        {
            await using var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false,
                enableSession: true,
                lockDuration: TimeSpan.FromMinutes(5),
                usePremiumNamespace: true);

            #region Snippet:ServiceBusTakeOverNonExclusiveSession
#if SNIPPET
            string fullyQualifiedNamespace = "<premium_fully_qualified_namespace>";
            string queueName = "<session_enabled_queue_name>";
            var credential = new DefaultAzureCredential();
#else
            string fullyQualifiedNamespace = TestEnvironment.PremiumFullyQualifiedNamespace;
            string queueName = scope.QueueName;
            var credential = TestEnvironment.Credential;
#endif
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);
            await using ServiceBusSender sender = client.CreateSender(queueName);
            string sessionId = Guid.NewGuid().ToString();

            await sender.SendMessageAsync(new ServiceBusMessage("work to hand off") { SessionId = sessionId });

            // Keep the first receiver open while the second takes over its session.
            await using ServiceBusSessionReceiver firstReceiver = await client.AcceptSessionAsync(
                queueName, sessionId,
                new ServiceBusSessionReceiverOptions { EnableNonExclusiveSession = true });

            if (firstReceiver.IsSessionExclusive || firstReceiver.SessionLockToken == null)
            {
                throw new InvalidOperationException("The service did not grant a non-exclusive session lock.");
            }

            ServiceBusReceivedMessage message = await firstReceiver.ReceiveMessageAsync(
                maxWaitTime: TimeSpan.FromSeconds(10));
            if (message == null)
            {
                throw new InvalidOperationException("Timed out waiting for the session message.");
            }

            Console.WriteLine(message.Body);

            // The token is sensitive: share it only with a trusted receiver with Listen rights.
            // It is a string on the receiver but a Guid in the takeover options.
            Guid lockToken = Guid.Parse(firstReceiver.SessionLockToken);
            await using ServiceBusSessionReceiver nextReceiver = await client.AcceptSessionAsync(
                queueName, sessionId,
                new ServiceBusSessionReceiverOptions
                {
                    EnableNonExclusiveSession = true,
                    SessionLockToken = lockToken
                });

            if (nextReceiver.IsSessionExclusive || nextReceiver.SessionLockToken != firstReceiver.SessionLockToken)
            {
                throw new InvalidOperationException("The session was not taken over with the expected lock token.");
            }

            // The replacement link can be ready before its management operations are.
            // Wait for the new holder to become active before settling the handed-off message.
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            while (true)
            {
                try
                {
                    await nextReceiver.GetSessionStateAsync(timeout.Token);
                    break;
                }
                catch (ServiceBusException ex) when (
                    ex.Reason == ServiceBusFailureReason.SessionLockLost && !timeout.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(100), timeout.Token);
                }
            }

            await nextReceiver.CompleteMessageAsync(message);
            #endregion

            Assert.That(message.Body.ToString(), Is.EqualTo("work to hand off"));
        }
    }
}
