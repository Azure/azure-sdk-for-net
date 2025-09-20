// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Base class for Voice Live Service integration tests.
    /// Provides common functionality for all test classes.
    /// </summary>
    [Category("Live")]
    [TestFixture]
    public abstract class VoiceLiveTestBase : TimeOutTestBase<Infrastructure.VoiceLiveTestEnvironment>
    {
        private readonly List<VoiceLiveSession> _sessions = new List<VoiceLiveSession>();
        private HashSet<string> _eventIDs = new HashSet<string>();
        protected VoiceLiveClient? Client { get; private set; }
        protected TimeSpan DefaultTimeout => TestEnvironment.DefaultTimeout;

        public VoiceLiveTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
            // Force Live mode - WebSocket tests cannot be recorded
        }

        [SetUp]
        public virtual void Setup()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);

            // Use API key if available, otherwise Azure AD
            if (!string.IsNullOrEmpty(TestEnvironment.ApiKey))
            {
                var credential = new AzureKeyCredential(TestEnvironment.ApiKey);
                Client = new VoiceLiveClient(endpoint, credential);
            }
            else
            {
                var credential = new DefaultAzureCredential();
                Client = new VoiceLiveClient(endpoint, credential);
            }
        }

        [TearDown]
        public virtual async Task Teardown()
        {
            // Clean up all sessions created during test
            foreach (var session in _sessions)
            {
                try
                {
                    await session.DisposeAsync();
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
            _sessions.Clear();
        }

        /// <summary>
        /// Creates a new Voice Live session with default or specified configuration.
        /// </summary>
        protected async Task<VoiceLiveSession> CreateSessionAsync(
            string model)
        {
            if (Client == null)
            {
                throw new InvalidOperationException("Client not initialized. Ensure Setup() has been called.");
            }
            model ??= TestEnvironment.RealtimeModel;

            var session = await Client.StartSessionAsync(model).ConfigureAwait(false);
            _sessions.Add(session); // Track for cleanup

            TestContext.WriteLine($"Session created");

            return session;
        }

        /// <summary>
        /// Creates a new Voice Live session with default or specified configuration.
        /// </summary>
        protected async Task<VoiceLiveSession> CreateSessionAsync(
            VoiceLiveSessionOptions options)
        {
            if (Client == null)
            {
                throw new InvalidOperationException("Client not initialized. Ensure Setup() has been called.");
            }

            options ??= new VoiceLiveSessionOptions();

            var session = await Client.StartSessionAsync(options).ConfigureAwait(false);
            _sessions.Add(session); // Track for cleanup

            TestContext.WriteLine($"Session created");

            return session;
        }

        /// <summary>
        /// Waits for a specific session update type to be received from the WebSocket.
        /// </summary>
        protected async Task<T> WaitForSessionUpdateAsync<T>(
            VoiceLiveSession session,
            TimeSpan timeout,
            Func<T, bool>? predicate = null) where T : SessionUpdate
        {
            // Implementation would depend on how the VoiceLiveSession exposes updates
            // This is a placeholder for the actual implementation

            var cts = new CancellationTokenSource(timeout);
            var sw = Stopwatch.StartNew();

            try
            {
                // A potential implementation might use a polling approach on some session state
                // This is highly dependent on the actual API design
                while (!cts.IsCancellationRequested)
                {
                    // We'd need to check for session updates based on the actual API design
                    // For now, this is just a placeholder
                    await Task.Delay(100, cts.Token);
                }

                TestContext.WriteLine($"Timeout waiting for {typeof(T).Name}");
                throw new TimeoutException($"Did not receive expected session update of type {typeof(T).Name} within {timeout.TotalSeconds} seconds.");
            }
            catch (OperationCanceledException)
            {
                TestContext.WriteLine($"Operation canceled while waiting for {typeof(T).Name}");
                throw;
            }
            finally
            {
                sw.Stop();
                TestContext.WriteLine($"Waited {sw.ElapsedMilliseconds}ms for {typeof(T).Name}");
            }
        }

        /// <summary>
        /// Loads test audio from the test data directory.
        /// </summary>
        protected byte[] LoadTestAudio(string filename)
        {
            var path = Path.Combine(TestEnvironment.TestAudioPath, filename);
            Assert.True(File.Exists(path), $"Test audio file not found: {path}");

            var data = File.ReadAllBytes(path);
            TestContext.WriteLine($"Loaded audio file: {filename} ({data.Length} bytes)");
            return data;
        }

        /// <summary>
        /// Sends audio and returns once the audio has been sent.
        /// </summary>
        protected async Task SendAudioAsync(
            VoiceLiveSession session,
            string audioFile)
        {
            var audio = LoadTestAudio(audioFile);
            await session.SendInputAudioAsync(audio);
            TestContext.WriteLine($"Sent audio file: {audioFile}");
        }

        /// <summary>
        /// Creates a voice provider configuration for testing.
        /// </summary>
        protected VoiceProvider CreateVoiceProvider(string voiceType = "azure-platform")
        {
            switch (voiceType)
            {
                case "azure-platform":
                    return new AzureStandardVoice("en-US-AriaNeural");

                case "azure-custom":
                    RequireFeature(TestEnvironment.HasCustomVoice,
                        "Custom voice not configured");
                    return new AzureCustomVoice(
                        TestEnvironment.CustomVoiceName,
                        TestEnvironment.CustomVoiceEndpointId);

                case "azure-personal":
                    RequireFeature(TestEnvironment.HasPersonalVoice,
                        "Personal voice not configured");
                    return new AzurePersonalVoice(
                        TestEnvironment.PersonalVoiceName,
                        new PersonalVoiceModels(TestEnvironment.PersonalVoiceModel));

                case "openai":
                    return new OpenAIVoice(OAIVoice.Alloy);

                default:
                    throw new ArgumentException($"Unknown voice type: {voiceType}");
            }
        }

        /// <summary>
        /// Creates turn detection configuration for testing.
        /// </summary>
        protected TurnDetection CreateTurnDetection(string detectionType = "server-vad")
        {
            switch (detectionType)
            {
                case "server-vad":
                    return new ServerVadTurnDetection
                    {
                        Threshold = 0.5f,
                        SilenceDurationMs = 500,
                        PrefixPaddingMs = 300
                    };

                case "azure-semantic":
                    return new AzureSemanticVadTurnDetection
                    {
                        Languages = { "en-US" },
                        Threshold = 0.7f
                    };

                case "azure-multilingual":
                    return new AzureSemanticVadMultilingualTurnDetection
                    {
                        Languages = { "en-US", "es-ES", "fr-FR" },
                        Threshold = 0.7f
                    };

                default:
                    throw new ArgumentException($"Unknown detection type: {detectionType}");
            }
        }

        /// <summary>
        /// Measures the time for an operation.
        /// </summary>
        protected async Task<TimeSpan> MeasureAsync(Func<Task> operation)
        {
            var sw = Stopwatch.StartNew();
            await operation();
            sw.Stop();

            TestContext.WriteLine($"Operation took {sw.ElapsedMilliseconds}ms");
            return sw.Elapsed;
        }

        /// <summary>
        /// Skips test if condition is not met.
        /// </summary>
        protected void RequireFeature(bool condition, string message)
        {
            if (!condition)
            {
                Assert.Ignore($"Skipping test: {message}");
            }
        }

        /// <summary>
        /// Executes a test with the fake WebSocket for unit testing.
        /// </summary>
        internal async Task WithFakeWebSocketAsync(Func<VoiceLiveSession, FakeWebSocket, Task> testAction)
        {
            var session = TestSessionFactory.CreateSessionWithFakeSocket(out var fakeSocket);

            try
            {
                await testAction(session, fakeSocket);
            }
            finally
            {
                await session.DisposeAsync();
            }
        }

        /// <summary>
        /// Waits for a specific message type to be sent through the fake WebSocket.
        /// </summary>
        internal async Task<JsonDocument> WaitForMessageTypeAsync(
            FakeWebSocket fakeSocket,
            string messageType,
            TimeSpan timeout)
        {
            var deadline = DateTime.UtcNow.Add(timeout);
            int lastCount = 0;

            while (DateTime.UtcNow < deadline)
            {
                var messages = TestUtilities.GetMessagesOfType(fakeSocket, messageType);

                if (messages.Count > lastCount && messages.Count > 0)
                {
                    return messages.Last();
                }

                lastCount = messages.Count;
                await Task.Delay(100);
            }

            TestContext.WriteLine($"Timeout waiting for message type: {messageType}");
            throw new TimeoutException($"Did not receive message of type {messageType} within {timeout.TotalSeconds} seconds.");
        }

        protected void EnsureEventIdsUnique(SessionUpdate sessionUpdate)
        {
            Assert.IsNotNull(sessionUpdate.EventId, $"Event ID was not specified on type {sessionUpdate.Type}");
            Assert.IsFalse(_eventIDs.Contains(sessionUpdate.EventId), $"EventId {sessionUpdate.EventId} was reused");
            _eventIDs.Add(sessionUpdate.EventId);
        }

        protected async Task<List<SessionUpdate>> CollectResponseUpdates(IAsyncEnumerator<SessionUpdate> updateEnumerator, CancellationToken cancellationToken)
        {
            List<SessionUpdate> responseUpdates = new List<SessionUpdate>();

            SessionUpdate currentUpdate;

            do
            {
                currentUpdate = await GetNextUpdate(updateEnumerator).ConfigureAwait(false);
                responseUpdates.Add(currentUpdate);
            } while (currentUpdate is not SessionUpdateResponseDone && !cancellationToken.IsCancellationRequested);

            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            return responseUpdates;
        }

        protected async Task<T> GetNextUpdate<T>(IAsyncEnumerator<SessionUpdate> updateEnumerator, bool checkEventId = true) where T : SessionUpdate
        {
            var currentUpdate = await GetNextUpdate(updateEnumerator, checkEventId).ConfigureAwait(false);
            return SafeCast<T>(currentUpdate);
        }

        protected T SafeCast<T>(object o) where T : class
        {
            Assert.IsTrue(o is T, $"Expected {typeof(T).Name} but got {o.GetType().Name}");
#pragma warning disable CS8603 // Possible null reference return. Assert 2 lines above prevents.
            return o as T;
#pragma warning restore CS8603 // Possible null reference return.
        }

        protected async Task<SessionUpdate> GetNextUpdate(IAsyncEnumerator<SessionUpdate> updateEnumerator, bool checkEventId = true)
        {
            var moved = await updateEnumerator.MoveNextAsync().ConfigureAwait(false);
            Assert.IsTrue(moved, "Failed to move to the next update.");
            var currentUpdate = updateEnumerator.Current;
            Assert.IsNotNull(currentUpdate);
            if (checkEventId)
            {
                EnsureEventIdsUnique(currentUpdate);
            }
            return currentUpdate;
        }
    }
}
