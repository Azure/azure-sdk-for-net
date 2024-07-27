// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using OpenAI.TestFramework.Recording.Matchers;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Recording.Transforms;

namespace OpenAI.TestFramework.Tests
{
    [NonParallelizable]
    public class ProxyServiceTests(bool isAsync) : SyncAsyncTestBase(isAsync)
    {
        #region Properties and setup/teardown methods

        public DirectoryInfo? RecordingDir { get; private set; }

        public FileInfo? RecordingFile { get; private set; }

        public CancellationToken Token => TokenSource?.Token ?? default;

        public CancellationTokenSource? TokenSource { get; private set; }

        [SetUp]
        public void CreateRecordingFile()
        {
            RecordingDir = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "RecordingTests", Guid.NewGuid().ToString()));
            if (!RecordingDir.Exists)
            {
                RecordingDir.Create();
            }

            RecordingFile = new FileInfo(Path.Combine(RecordingDir.FullName, Path.GetRandomFileName() + ".json"));
            TokenSource = new CancellationTokenSource(System.Diagnostics.Debugger.IsAttached
                ? TimeSpan.FromMinutes(30)
                : TimeSpan.FromMinutes(1));
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

            TokenSource?.Dispose();
        }

        #endregion

        [TestCase]
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

        [TestCase]
        public async Task AddSanitizers()
        {
            using ProxyService proxy = await CreateProxyServiceAsync();

            List<BaseSanitizer> sanitizers =
            [
                new BodyKeySanitizer("body.key"),
                new BodyRegexSanitizer("(.*)")
                {
                    GroupForReplace = "1",
                    Condition = new Recording.Common.Condition()
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

        [TestCase]
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

        [TestCase]
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

        [TestCase]
        public async Task StartStopRecording()
        {
            const string key1 = "key1";
            string value1 = Guid.NewGuid().ToString();
            const string key2 = "the.others";
            string value2 = "value";

            using ProxyService proxy = await CreateProxyServiceAsync();

            StartInformation startInfo = new()
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

        #region helper methods

        private async Task<ProxyService> CreateProxyServiceAsync()
        {
            ProxyService? proxy = null;
            try
            {
                proxy = await ProxyService.CreateNewAsync(
                    new ProxyServiceOptions()
                    {
                        StorageLocationDir = RecordingDir!.FullName
                    },
                    Token);

                Assert.That(proxy, Is.Not.Null);
                Assert.DoesNotThrow(proxy.ThrowOnErrors);
                Assert.That(proxy.Client, Is.Not.Null);

                var wrappedClient = WrapForSyncAsync(proxy.Client);
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
