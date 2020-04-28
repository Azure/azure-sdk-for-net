// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.UnitTests.Infrastructure;

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    internal class TestSessionHandler
    {
	    private const int NumberOfSessions = 5;
	    private const int MessagesPerSession = 10;

	    private readonly SessionPumpHost _sessionPumpHost;
	    private readonly ReceiveMode _receiveMode;
	    private readonly MessageSender _sender;
	    private readonly SessionHandlerOptions _sessionHandlerOptions;
	    private ConcurrentDictionary<string, int> _sessionMessageMap;
	    private int _totalMessageCount;

        public TestSessionHandler(
            ReceiveMode receiveMode,
            SessionHandlerOptions sessionHandlerOptions,
            MessageSender sender,
            SessionPumpHost sessionPumpHost)
        {
            _receiveMode = receiveMode;
            _sessionHandlerOptions = sessionHandlerOptions;
            _sender = sender;
            _sessionPumpHost = sessionPumpHost;
            _sessionMessageMap = new ConcurrentDictionary<string, int>();
        }

        public void RegisterSessionHandler(SessionHandlerOptions handlerOptions)
        {
            _sessionPumpHost.OnSessionHandler(OnSessionHandler, _sessionHandlerOptions);
        }

        public async Task SendSessionMessages()
        {
            await TestUtility.SendSessionMessagesAsync(_sender, NumberOfSessions, MessagesPerSession);
        }

        public async Task OnSessionHandler(IMessageSession session, Message message, CancellationToken token)
        {
            Assert.NotNull(session);
            Assert.NotNull(message);

            Interlocked.Increment(ref _totalMessageCount);
            TestUtility.Log($"Received Session: {session.SessionId} message: SequenceNumber: {message.SystemProperties.SequenceNumber}");

            if (_receiveMode == ReceiveMode.PeekLock && !_sessionHandlerOptions.AutoComplete)
            {
                await session.CompleteAsync(message.SystemProperties.LockToken);
            }

            _sessionMessageMap.AddOrUpdate(session.SessionId, 1, (_, current) => current + 1);
        }

        public async Task VerifyRun()
        {
            // Wait for the OnMessage Tasks to finish
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds <= 180)
            {
                if (_totalMessageCount == MessagesPerSession * NumberOfSessions)
                {
                    TestUtility.Log($"All '{_totalMessageCount}' messages Received.");
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            foreach (var keyValuePair in _sessionMessageMap)
            {
                TestUtility.Log($"Session: {keyValuePair.Key}, Messages Received in this Session: {keyValuePair.Value}");
            }

            Assert.True(_sessionMessageMap.Keys.Count == NumberOfSessions);
            Assert.True(_totalMessageCount == MessagesPerSession * NumberOfSessions);
        }

        public void ClearData()
        {
            _totalMessageCount = 0;
            _sessionMessageMap = new ConcurrentDictionary<string, int>();
        }
    }
}