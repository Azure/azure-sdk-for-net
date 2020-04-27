// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.UnitTests.Infrastructure;

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
        const int NumberOfSessions = 5;
        const int MessagesPerSession = 10;

        readonly SessionPumpHost sessionPumpHost;
        readonly ReceiveMode receiveMode;
        readonly MessageSender sender;
        readonly SessionHandlerOptions sessionHandlerOptions;
        ConcurrentDictionary<string, int> sessionMessageMap;
        int totalMessageCount;

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
            sessionMessageMap = new ConcurrentDictionary<string, int>();
        }

        public void RegisterSessionHandler(SessionHandlerOptions handlerOptions)
        {
            sessionPumpHost.OnSessionHandler(OnSessionHandler, sessionHandlerOptions);
        }

        public async Task SendSessionMessages()
        {
            await TestUtility.SendSessionMessagesAsync(sender, NumberOfSessions, MessagesPerSession);
        }

        public async Task OnSessionHandler(IMessageSession session, Message message, CancellationToken token)
        {
            Assert.NotNull(session);
            Assert.NotNull(message);

            Interlocked.Increment(ref totalMessageCount);
            TestUtility.Log($"Received Session: {session.SessionId} message: SequenceNumber: {message.SystemProperties.SequenceNumber}");

            if (receiveMode == ReceiveMode.PeekLock && !sessionHandlerOptions.AutoComplete)
            {
                await session.CompleteAsync(message.SystemProperties.LockToken);
            }

            sessionMessageMap.AddOrUpdate(session.SessionId, 1, (_, current) => current + 1);
        }

        public async Task VerifyRun()
        {
            // Wait for the OnMessage Tasks to finish
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 180)
            {
                if (totalMessageCount == MessagesPerSession * NumberOfSessions)
                {
                    TestUtility.Log($"All '{totalMessageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            foreach (KeyValuePair<string, int> keyValuePair in sessionMessageMap)
            {
                TestUtility.Log($"Session: {keyValuePair.Key}, Messages Received in this Session: {keyValuePair.Value}");
            }

            Assert.True(sessionMessageMap.Keys.Count == NumberOfSessions);
            Assert.True(totalMessageCount == MessagesPerSession * NumberOfSessions);
        }

        public void ClearData()
        {
            totalMessageCount = 0;
            sessionMessageMap = new ConcurrentDictionary<string, int>();
        }
    }
}