// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Processor
{
    public class SessionProcessorNetworkRecoveryLiveTests : ServiceBusLiveTestBase
    {
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task NetworkLossStopsRenewalAndRecoversAfterActiveHandlerReturns(bool fixedSession, bool infiniteRenewal)
        {
            var connectionString = TestEnvironment.ServiceBusConnectionString;
            var host = ServiceBusConnectionStringProperties.Parse(connectionString).Endpoint.Host;
            var administration = new ServiceBusAdministrationClient(connectionString);
            var topic = $"recovery-{Guid.NewGuid():N}";
            await administration.CreateTopicAsync(topic);
            Exception failure = null;
            try
            {
                await administration.CreateSubscriptionAsync(new CreateSubscriptionOptions(topic, "session-subscription")
                {
                    RequiresSession = true,
                    LockDuration = TimeSpan.FromSeconds(10)
                });
                await using var producer = new ServiceBusClient(connectionString);
                await using var sender = producer.CreateSender(topic);
                await sender.SendMessageAsync(new ServiceBusMessage("seed") { MessageId = "seed", SessionId = "session" });
                await using var proxy = new ServiceBusTestProxy(host);
                await using var consumer = new ServiceBusClient(connectionString, new ServiceBusClientOptions
                {
                    TransportType = ServiceBusTransportType.AmqpWebSockets,
                    WebProxy = new WebProxy(proxy.Address)
                });
                var options = new ServiceBusSessionProcessorOptions
                {
                    AutoCompleteMessages = false,
                    MaxAutoLockRenewalDuration = infiniteRenewal ? Timeout.InfiniteTimeSpan : TimeSpan.FromMinutes(5),
                    MaxConcurrentSessions = 1,
                    MaxConcurrentCallsPerSession = 1
                };
                if (fixedSession)
                {
                    options.SessionIds.Add("session");
                }
                await using var processor = consumer.CreateSessionProcessor(topic, "session-subscription", options);
                using var listener = new TestEventListener();
                listener.EnableEvents(ServiceBusEventSource.Log, EventLevel.Verbose);
                var handlerEntered = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var releaseHandler = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var sentinelReceived = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                var held = 0;
                try
                {
                    processor.ProcessMessageAsync += OnMessage;
                    processor.ProcessErrorAsync += OnError;
                    await processor.StartProcessingAsync();
                    Assert.That(await Task.WhenAny(handlerEntered.Task, Task.Delay(TimeSpan.FromSeconds(60))), Is.SameAs(handlerEntered.Task));
                    var managers = (List<ReceiverManager>)typeof(ServiceBusProcessor)
                        .GetField("_receiverManagers", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(processor.InnerProcessor);
                    var manager = (SessionReceiverManager)managers.Single();
                    var receiver = manager.Receiver;
                    var renewal = (Task)typeof(SessionReceiverManager)
                        .GetField("_sessionLockRenewalTask", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(manager);

                    proxy.ResetConnections();
                    Assert.That(await Task.WhenAny(renewal, Task.Delay(TimeSpan.FromSeconds(15))), Is.SameAs(renewal),
                        "A real TCP reset must stop renewal even while no receive worker is available.");
                    await renewal;
                    Assert.That(receiver.InnerReceiver.IsSessionLinkClosed, Is.True);
                    Assert.That(manager.Receiver, Is.SameAs(receiver), "Do not replace a receiver while its handler is active.");
                    Assert.That(manager.SessionLockLostException, Is.TypeOf<ObjectDisposedException>());
                    Assert.That(manager.SessionLockCancellationToken.IsCancellationRequested, Is.True);
                    var renewalErrors = listener.EventsById(ServiceBusEventSource.ProcessorRenewSessionLockExceptionEvent)
                        .Count(e => e.Payload.Contains(processor.Identifier));
                    Assert.That(renewalErrors, Is.EqualTo(1));

                    await sender.SendMessageAsync(new ServiceBusMessage("sentinel") { MessageId = "sentinel", SessionId = "session" });
                    releaseHandler.TrySetResult(true);
                    Assert.That(await Task.WhenAny(sentinelReceived.Task, Task.Delay(TimeSpan.FromSeconds(60))), Is.SameAs(sentinelReceived.Task),
                        "The processor must reacquire the session and receive a new message after its handler returns.");
                    TestContext.Progress.WriteLine($"fixedSession={fixedSession}; infiniteRenewal={infiniteRenewal}; renewalErrors={renewalErrors}; recoveredSentinel=true");
                }
                finally
                {
                    releaseHandler.TrySetResult(true);
                    await processor.StopProcessingAsync();
                    processor.ProcessMessageAsync -= OnMessage;
                    processor.ProcessErrorAsync -= OnError;
                }

                async Task OnMessage(ProcessSessionMessageEventArgs args)
                {
                    if (Interlocked.CompareExchange(ref held, 1, 0) == 0)
                    {
                        handlerEntered.TrySetResult(true);
                        await releaseHandler.Task;
                        return;
                    }
                    await args.CompleteMessageAsync(args.Message);
                    if (args.Message.MessageId == "sentinel")
                    {
                        sentinelReceived.TrySetResult(true);
                    }
                }

                Task OnError(ProcessErrorEventArgs args)
                {
                    TestContext.Progress.WriteLine($"{args.ErrorSource}: {args.Exception.GetType().Name}");
                    return Task.CompletedTask;
                }
            }
            catch (Exception ex)
            {
                failure = ex;
                throw;
            }
            finally
            {
                try
                {
                    await administration.DeleteTopicAsync(topic);
                }
                catch (Exception cleanupException) when (failure != null)
                {
                    throw new AggregateException(failure, cleanupException);
                }
            }
        }
    }
}
