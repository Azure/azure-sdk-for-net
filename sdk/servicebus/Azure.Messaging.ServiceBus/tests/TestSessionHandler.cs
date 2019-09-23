// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    internal class TestSessionHandler
    {
        private const int NumberOfSessions = 5;
        private const int MessagesPerSession = 10;
        private readonly SessionPumpHost sessionPumpHost;
        private readonly ReceiveMode receiveMode;
        private readonly MessageSender sender;
        private readonly SessionHandlerOptions sessionHandlerOptions;
        private ConcurrentDictionary<string, int> sessionMessageMap;
        private int totalMessageCount;

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
        }

        public void RegisterSessionHandler(SessionHandlerOptions handlerOptions)
        {
            this.sessionPumpHost.RegisterSessionHandler(this.OnSessionHandler, this.sessionHandlerOptions);
        }

        public async Task SendSessionMessages()
        {
            await TestUtility.SendSessionMessagesAsync(this.sender, NumberOfSessions, MessagesPerSession);
        }

        public async Task OnSessionHandler(MessageSession session, ReceivedMessage message, CancellationToken token)
        {
            Assert.NotNull(session);
            Assert.NotNull(message);

            Interlocked.Increment(ref this.totalMessageCount);
            TestUtility.Log($"Received Session: {session.SessionId} message: SequenceNumber: {message.SequenceNumber}");

            if (this.receiveMode == ReceiveMode.PeekLock && !this.sessionHandlerOptions.AutoComplete)
            {
                await session.CompleteAsync(message.LockToken);
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