// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
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

        protected string AudioPath = string.Empty;

        protected TimeSpan DefaultTimeout => TestEnvironment.DefaultTimeout;

        public VoiceLiveTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
            // Force Live mode - WebSocket tests cannot be recorded
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

        protected VoiceLiveClient GetLiveClient(VoiceLiveClientOptions? options = null)
        {
            var optionsLocal = options ?? new VoiceLiveClientOptions();

            optionsLocal.Diagnostics.IsLoggingContentEnabled = true;
            optionsLocal.Diagnostics.IsLoggingEnabled = true;

            return string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true), optionsLocal) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey), optionsLocal);
        }

        internal TestableVoiceLiveSession GetTestableSession(VoiceLiveClient client)
        {
            var testEndpoint = TestEnvironment.Endpoint.Replace("https:", "wss:").Replace("http:", "ws:");

            return string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new TestableVoiceLiveSession(client, new Uri(testEndpoint), new DefaultAzureCredential(true)) :
                new TestableVoiceLiveSession(client, new Uri(testEndpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
        }

        /// <summary>
        /// Loads test audio from the test data directory.
        /// </summary>
        protected byte[] LoadTestAudio(string filename)
        {
            var path = Path.Combine(AudioPath, filename);
            Assert.True(File.Exists(path), $"Test audio file not found: {path}");

            var data = File.ReadAllBytes(path);
            TestContext.WriteLine($"Loaded audio file: {filename} ({data.Length} bytes)");
            return data;
        }

        protected async Task<byte[]> GenerateTestAudio(string text)
        {
            var of = SpeechSynthesisOutputFormat.Riff24Khz16BitMonoPcm;
            var sc = SpeechConfig.FromEndpoint(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            sc.SetSpeechSynthesisOutputFormat(of);

            using (var outputStream = AudioOutputStream.CreatePullStream())
            using (var ac = AudioConfig.FromStreamOutput(outputStream))
            using (var speechSynthesizer = new SpeechSynthesizer(sc, ac))
            {
                var result = await speechSynthesizer.SpeakTextAsync(text).ConfigureAwait(false);
                if (result.Reason != ResultReason.SynthesizingAudioCompleted)
                {
                    throw new Exception($"Error {result.Reason} was not synthesis completed");
                }

                return result.AudioData;
            }
        }

        /// <summary>
        /// Sends audio and returns once the audio has been sent.
        /// </summary>
        protected async Task<(Task SilenceTask, CancellationTokenSource Cts)> SendAudioAsync(
            VoiceLiveSession session,
            string textToSend,
            CancellationToken cancellationToken = default)
        {
            var audio = await GenerateTestAudio(textToSend).ConfigureAwait(false);
            await session.SendInputAudioAsync(audio, cancellationToken).ConfigureAwait(false);
            TestContext.WriteLine($"Sent audio for: {textToSend}");

            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Start a task to send silence after audio is sent
            var sendSilenceTask = Task.Run(async () =>
            {
                try
                {
                    // Send silence to allow processing to complete
                    var silence = new byte[3200]; // 100ms of silence at 16kHz 16bit mono
                    while (!cts.Token.IsCancellationRequested)
                    {
                        await session.SendInputAudioAsync(silence, cts.Token).ConfigureAwait(false);
                        await Task.Delay(100, cts.Token).ConfigureAwait(false);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Expected when the cancellation token is canceled.
                }
                TestContext.WriteLine("Sent silence to complete processing.");
            }, cancellationToken);

            return (sendSilenceTask, cts);
        }

        protected void EnsureEventIdsUnique(SessionUpdate sessionUpdate)
        {
            Assert.IsNotNull(sessionUpdate.EventId, $"Event ID was not specified on type {sessionUpdate.Type}");
            Assert.IsFalse(_eventIDs.Contains(sessionUpdate.EventId), $"EventId {sessionUpdate.EventId} was reused");
            _eventIDs.Add(sessionUpdate.EventId);
        }

        protected Task<List<SessionUpdate>> CollectResponseUpdates(IAsyncEnumerator<SessionUpdate> updateEnumerator, CancellationToken cancellationToken)
        {
            return CollectUpdates<SessionUpdateResponseDone>(updateEnumerator, cancellationToken);
        }

        protected async Task<List<SessionUpdate>> CollectUpdates<T>(IAsyncEnumerator<SessionUpdate> updateEnumerator, CancellationToken cancellationToken)
        {
            List<SessionUpdate> responseUpdates = new List<SessionUpdate>();

            SessionUpdate currentUpdate;

            do
            {
                currentUpdate = await GetNextUpdate(updateEnumerator).ConfigureAwait(false);
                responseUpdates.Add(currentUpdate);
            } while (currentUpdate is not T && !cancellationToken.IsCancellationRequested);

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
