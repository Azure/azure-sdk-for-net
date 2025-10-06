// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using NUnit.Framework;
using OpenAI.TestFramework.Mocks;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Recording.Transforms;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework.Tests
{
    [NonParallelizable]
    public class ProxyServiceTests(bool isAsync) : ClientTestBase(isAsync)
    {
        #region Properties and setup/teardown methods

        public DirectoryInfo? RecordingDir { get; private set; }

        public FileInfo? RecordingFile { get; private set; }

        [SetUp]
        public void CreateRecordingFile()
        {
            RecordingDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "RecordingTests", Guid.NewGuid().ToString()));
            if (!RecordingDir.Exists)
            {
                RecordingDir.Create();
            }

            RecordingFile = new FileInfo(Path.Combine(RecordingDir.FullName, Path.GetRandomFileName() + ".json"));
        }

        [TearDown]
        public void DeleteRecordingFile()
        {
            if (RecordingFile != null)
            {
                RecordingFile.Delete();
            }

            if (RecordingDir != null)
            {
                RecordingDir.Delete(true);
            }
        }

        #endregion

        [Test]
        public async Task StartProxy()
        {
            using ProxyService proxy = await CreateProxyServiceAsync();

            Assert.That(proxy.HttpEndpoint, Is.Not.Null);
            Assert.That(proxy.HttpEndpoint.Port, Is.GreaterThan(0).And.LessThanOrEqualTo(ushort.MaxValue));
            Assert.That(proxy.HttpsEndpoint, Is.Not.Null);
            Assert.That(proxy.HttpsEndpoint.Port, Is.GreaterThan(0).And.LessThanOrEqualTo(ushort.MaxValue));

            ProxyClientResult<string> available = await proxy.Client.ListAvailableAsync(Token);
            Assert.That(available, Is.Not.Null);
            Assert.That(available.GetRawResponse(), Is.Not.Null);
            Assert.That(available.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(available.Value, Is.Not.Null);
            Assert.That(available.Value, Does.Contain("BodilessMatcher"));
        }

        [Test]
        public async Task AddSanitizers()
        {
            using ProxyService proxy = await CreateProxyServiceAsync();

            List<BaseSanitizer> sanitizers =
            [
                new BodyKeySanitizer("body.key"),
                new BodyRegexSanitizer("(.*)")
                {
                    GroupForReplace = "1",
                    Condition = new Recording.Condition()
                    {
                        ResponseHeader = new()
                        {
                            Key = "Content-Type",
                            ValueRegex = "json$"
                        },
                        UriRegex = "https://[^/]+/sub"
                    }
                },
                new HeaderRegexSanitizer("Authentication")
                {
                    Value = "replacement",
                    GroupForReplace = "1",
                    Regex = "^Bearer "
                },
                new UriRegexSanitizer("https://[^/]+/sub")
                {
                    GroupForReplace = "1",
                    Value = "replacement"
                }
            ];

            ProxyClientResult<IReadOnlyList<string>> result = await proxy.Client.AddSanitizersAsync(sanitizers, token: Token);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetRawResponse(), Is.Not.Null);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(result.Value, Is.Not.Null);
            Assert.That(result.Value, Has.Count.EqualTo(sanitizers.Count));
        }

        [Test]
        public async Task SetMatcher()
        {
            using ProxyService proxy = await CreateProxyServiceAsync();

            BaseMatcher[] matchers =
            [
                ExistingMatcher.Headerless,
                ExistingMatcher.Bodiless,
                new CustomMatcher()
                {
                    CompareBodies = false,
                    ExcludedHeaders = "Authorization",
                    IgnoredHeaders = "Content-Length,Content-Type",
                    IgnoredQueryParameters = "page,version",
                    IgnoreQueryOrdering = true,
                }
            ];

            foreach (var matcher in matchers)
            {
                ProxyClientResult result = await proxy.Client.SetMatcherAsync(matcher, token: Token);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.GetRawResponse(), Is.Not.Null);
                Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
            }
        }

        [Test]
        public async Task SetTransform()
        {
            using ProxyService proxy = await CreateProxyServiceAsync();

            HeaderTransform transform = new("X-Client-RequestId")
            {
                Value = "replacement",
                Condition = new()
                {
                    UriRegex = "http.*://[^/]+/(.*)"
                }
            };

            ProxyClientResult result = await proxy.Client.AddTransformAsync(transform, token: Token);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetRawResponse(), Is.Not.Null);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        }

        [Test]
        public async Task StartStopRecording()
        {
            const string key1 = "key1";
            string value1 = Guid.NewGuid().ToString();
            const string key2 = "the.others";
            string value2 = "value";

            using ProxyService proxy = await CreateProxyServiceAsync();

            RecordingStartInformation startInfo = new()
            {
                RecordingFile = RecordingFile!.FullName,
            };

            ProxyClientResult result = await proxy.Client.StartRecordingAsync(startInfo, token: Token);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.GetRawResponse(), Is.Not.Null);
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));

            string recordingId = result.RecordingId!;
            Assert.That(recordingId, Is.Not.Null);

            Dictionary<string, string> additional = new()
            {
                [key1] = value1,
                [key2] = value2,
            };

            result = await proxy.Client.StopRecordingAsync(recordingId, additional, false, Token);

            // At this point we should have a recording file
            string recordedJson = File.ReadAllText(RecordingFile.FullName);
            Assert.That(recordedJson, Does.Contain(key1)
                .And.Contain(value1)
                .And.Contain(key2)
                .And.Contain(value2));
        }

        [Test]
        public async Task RecordAndPlayback()
        {
            using ProxyService recordingProxyService = await CreateProxyServiceAsync();
            RecordingStartInformation startInfo = new() { RecordingFile = RecordingFile!.FullName };

            using MockRestService<string> mockRestService = new();
            TestRecordingOptions recordingOptions = new()
            {
                SanitizersToRemove =
                {
                    "AZSDK3430", // $..id
                }
            };

            string id1;
            string id2;

            // Start recording, and capture some requests
            {
                ProxyClientResult result = await recordingProxyService.Client.StartRecordingAsync(startInfo, Token);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.RecordingId, !Is.Null.Or.Empty);
                string recordingId = result.RecordingId!;

                await using TestRecording recording = new(recordingId, RecordedTestMode.Record, recordingProxyService);
                await recording.ApplyOptions(recordingOptions, Token);

                id1 = recording.Random.NewGuid().ToString();
                id2 = recording.Random.NewGuid().ToString();

                await SendRequestsAsync(recording, mockRestService.HttpEndpoint, id1, id2, Token);
            }

            // validate the service has what we expect
            var serviceIds = mockRestService.GetAll()
                .Select(e => e.id)
                .ToArray();
            Assert.That(serviceIds, Is.EquivalentTo(new[] { id1, id2 }));

            mockRestService.Reset();

            // Playback the recording
            {
                ProxyClientResult<IDictionary<string, string>> result = await recordingProxyService.Client.StartPlaybackAsync(startInfo, Token);
                Assert.That(result, Is.Not.Null);
                Assert.That(result.RecordingId, !Is.Null.Or.Empty);
                string recordingId = result.RecordingId!;

                await using TestRecording playback = new(recordingId, RecordedTestMode.Playback, recordingProxyService, result.Value);
                await playback.ApplyOptions(recordingOptions, Token);

                string id = playback.Random.NewGuid().ToString();
                Assert.That(id, Is.EqualTo(id1));
                id = playback.Random.NewGuid().ToString();
                Assert.That(id, Is.EqualTo(id2));

                await SendRequestsAsync(playback, mockRestService.HttpEndpoint, id1, id2, Token);
            }

            // since we are playing back, the service should not have been called
            Assert.That(mockRestService.GetAll().Count(), Is.EqualTo(0));

            static async Task SendRequestsAsync(TestRecording recording, Uri restEndpoint, string id1, string id2, CancellationToken token)
            {
                const string value1 = "The value for the first item";
                const string value2 = "The secondary value goes here";
                const string id3 = "random";
                const string value3 = "Sure why not";

                ClientPipelineOptions options = new();
                options.RetryPolicy = new TestClientRetryPolicy(0, TimeSpan.FromMilliseconds(100));
                options.Transport = new ProxyTransport(recording.GetProxyTransportOptions());

                using MockRestServiceClient<string> client = new(restEndpoint, options);

                ClientResult add = await client.AddAsync(id1, value1, token);
                Assert.That(add, Is.Not.Null);
                Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));

                add = await client.AddAsync(id2, value2, token);
                Assert.That(add, Is.Not.Null);
                Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));

                add = await client.AddAsync(id3, value3, token);
                Assert.That(add, Is.Not.Null);
                Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));

                ClientResult<string?> get = await client.GetAsync(id2, token);
                Assert.That(add, Is.Not.Null);
                Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(get.Value, Is.EqualTo(value2));

                get = await client.GetAsync(id3, token);
                Assert.That(add, Is.Not.Null);
                Assert.That(add.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(get.Value, Is.EqualTo(value3));

                ClientResult<bool> remove = await client.RemoveAsync(id3, token);
                Assert.That(remove.Value, Is.True);

                remove = await client.RemoveAsync("does.not.exist", token);
                Assert.That(remove.Value, Is.False);

                get = await client.GetAsync(id3, token);
                Assert.That(get, Is.Not.Null);
                Assert.That(get.GetRawResponse().Status, Is.EqualTo(404));
                Assert.That(get.Value, Is.Null);
            }
        }

        #region helper methods

        private async Task<ProxyService> CreateProxyServiceAsync()
        {
            ProxyService? proxy = null;
            try
            {
                proxy = await ProxyService.CreateNewAsync(
                    new ProxyServiceOptions()
                    {
                        DotnetExecutable = AssemblyHelper.GetDotnetExecutable()?.FullName!,
                        TestProxyDll = AssemblyHelper.GetAssemblyMetadata<ProxyService>("TestProxyPath")!,
                        StorageLocationDir = RecordingDir!.FullName
                    },
                    Token);

                Assert.That(proxy, Is.Not.Null);
                Assert.DoesNotThrow(proxy.ThrowOnErrors);
                Assert.That(proxy.Client, Is.Not.Null);

                var wrappedClient = WrapClient(proxy.Client);
                var setter = typeof(ProxyService).GetMethod("SetClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    ?? throw new InvalidOperationException("Could not find the ProxyService.SetClient method");
                setter.Invoke(proxy, [wrappedClient]);

                var ret = proxy;
                proxy = null;
                return ret;
            }
            finally
            {
                proxy?.Dispose();
            }
        }

        #endregion
    }
}
