// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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

        [SetUp]
        public virtual void Setup()
        {
            var root = VoiceLiveTestEnvironment.RepositoryRoot;
            var assetsPath = base.AssetsJsonPath;

            var assetsJson = JsonDocument.Parse(File.ReadAllText(assetsPath));

            var tag = assetsJson.RootElement.GetProperty("Tag");

            var tagString = tag.ToString();

            string crumb = string.Empty;

            foreach (var breadcrumb in Directory.EnumerateFiles(Path.Combine(root, ".assets", "breadcrumb")))
            {
                var contents = File.ReadAllText(breadcrumb);
                var splitContents = contents.Trim().Split(';');
                if (3 == splitContents.Length && splitContents[2] == tagString)
                {
                    crumb = splitContents[1];
                    break;
                }
            }

            var assetsContentPath = Path.Combine(root, ".assets", crumb, "net", "sdk", "ai", "Azure.AI.VoiceLive");

            AudioPath = Path.Combine(assetsContentPath, "audio");
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
            return string.IsNullOrEmpty(TestEnvironment.ApiKey) ?
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new DefaultAzureCredential(true), options) :
                new VoiceLiveClient(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey), options);
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
            var path = Path.GetTempFileName();
            var of = SpeechSynthesisOutputFormat.Riff24Khz16BitMonoPcm;
            var sc = SpeechConfig.FromEndpoint(new Uri(TestEnvironment.Endpoint), new AzureKeyCredential(TestEnvironment.ApiKey));
            sc.SetSpeechSynthesisOutputFormat(of);
            using (var ac = AudioConfig.FromWavFileOutput(path))
            using (var synthsizer = new SpeechSynthesizer(sc, ac))
            {
                var result = await synthsizer.SpeakTextAsync(text).ConfigureAwait(false);
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
        protected async Task SendAudioAsync(
            VoiceLiveSession session,
            string textToSend)
        {
            var audio = await GenerateTestAudio(textToSend).ConfigureAwait(false);
            await session.SendInputAudioAsync(audio).ConfigureAwait(false);
            TestContext.WriteLine($"Sent audio for: {textToSend}");
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
