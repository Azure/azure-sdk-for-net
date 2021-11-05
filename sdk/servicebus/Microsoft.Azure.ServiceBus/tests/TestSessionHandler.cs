// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    class TestSessionHandler
    {
        public const int NumberOfSessions = 5;
        public const int MessagesPerSession = 10;

        readonly SessionPumpHost sessionPumpHost;
        readonly ReceiveMode receiveMode;
        readonly MessageSender sender;
        readonly SessionHandlerOptions sessionHandlerOptions;
        ConcurrentDictionary<string, int> sessionMessageMap;
        int totalMessageCount;
        int receivedMessageCount;

        public int ReceivedMessageCount
        {
            get => receivedMessageCount;
        }

        public TestSessionHandler(
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            MessageSender sender,
            SessionPumpHost sessionPumpHost)
        {
            this.receiveMode = receiveMode;
            this.sessionHandlerOptions = sessionHandlerOptions;
            this.sender = sender;
            this.sessionPumpHost = sessionPumpHost;
            this.sessionMessageMap = new ConcurrentDictionary<string, int>();
            this.receivedMessageCount = 0;
        }

        public void RegisterSessionHandler(Func<IMessageSession, Message, CancellationToken, Task> handler, SessionHandlerOptions handlerOptions)
        {
            this.sessionPumpHost.OnSessionHandler(handler, handlerOptions);
        }

        public void RegisterSessionHandler(SessionHandlerOptions handlerOptions)
        {
            this.sessionPumpHost.OnSessionHandler(this.OnSessionHandler, this.sessionHandlerOptions);
        }

        public async Task UnregisterSessionHandler(TimeSpan inflightSessionHandlerTasksWaitTimeout)
        {
            await this.sessionPumpHost.UnregisterSessionHandlerAsync(inflightSessionHandlerTasksWaitTimeout).ConfigureAwait(false);
        }

        public void RegisterSessionHandlerAndRecordReceivedMessageCount(bool isPeekLockMode, int awaitTimeInSecs)
        {
            this.RegisterSessionHandler(
               async (session, message, token) =>
               {
                   await Task.Delay(TimeSpan.FromSeconds(awaitTimeInSecs));
                   TestUtility.Log($"Received Session: {session.SessionId} message: SequenceNumber: {message.SystemProperties.SequenceNumber}");

                   if (isPeekLockMode && !sessionHandlerOptions.AutoComplete)
                   {
                       await session.CompleteAsync(message.SystemProperties.LockToken);
                   }
                   Interlocked.Increment(ref this.receivedMessageCount);
               },
               sessionHandlerOptions);
        }

        public async Task WaitForAllMessagesReceived(int expectedCount)
        {
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 60)
            {
                if (this.receivedMessageCount == expectedCount)
                {
                    TestUtility.Log($"All '{expectedCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public async Task SendSessionMessages()
        {
            await TestUtility.SendSessionMessagesAsync(this.sender, NumberOfSessions, MessagesPerSession);
        }

        public async Task OnSessionHandler(IMessageSession session, Message message, CancellationToken token)
        {
            Assert.NotNull(session);
            Assert.NotNull(message);

            Interlocked.Increment(ref this.totalMessageCount);
            TestUtility.Log($"Received Session: {session.SessionId} message: SequenceNumber: {message.SystemProperties.SequenceNumber}");

            if (this.receiveMode == ReceiveMode.PeekLock && !this.sessionHandlerOptions.AutoComplete)
            {
                await session.CompleteAsync(message.SystemProperties.LockToken);
            }

            this.sessionMessageMap.AddOrUpdate(session.SessionId, 1, (_, current) => current + 1);
        }

        public async Task VerifyRun()
        {
            // Wait for the OnMessage Tasks to finish
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 180)
            {
                if (this.totalMessageCount == MessagesPerSession * NumberOfSessions)
                {
                    TestUtility.Log($"All '{this.totalMessageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            foreach (KeyValuePair<string, int> keyValuePair in this.sessionMessageMap)
            {
                TestUtility.Log($"Session: {keyValuePair.Key}, Messages Received in this Session: {keyValuePair.Value}");
            }

            Assert.True(this.sessionMessageMap.Keys.Count == NumberOfSessions);
            Assert.True(this.totalMessageCount == MessagesPerSession * NumberOfSessions);
        }

        public void ClearData()
        {
            this.totalMessageCount = 0;
            this.sessionMessageMap = new ConcurrentDictionary<string, int>();
        }
    }
}