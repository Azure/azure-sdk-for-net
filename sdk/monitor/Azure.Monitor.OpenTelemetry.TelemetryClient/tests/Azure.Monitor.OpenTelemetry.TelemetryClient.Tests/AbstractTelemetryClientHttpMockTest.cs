// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WireMock.Logging;
using WireMock.Server;
using Formatting = Newtonsoft.Json.Formatting;
using Request = WireMock.RequestBuilders.Request;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.TelemetryClient {
    public abstract class AbstractTelemetryClientHttpMockTest : IDisposable
    {
        protected const string NodeName = "node-01";

        private readonly WireMockServer _mockServer;
        protected readonly string _testConnectionString;

        public AbstractTelemetryClientHttpMockTest()
        {
            _mockServer = WireMockServer.Start();

            _testConnectionString =
                $"InstrumentationKey=12345678-1234-1234-1234-123456789012;IngestionEndpoint={_mockServer.Url}/v2.1/track;LiveEndpoint={_mockServer.Url}/live";

            _mockServer
                .Given(Request.Create()
                    .WithPath("/v2.1/track")
                    .UsingPost());
        }
        protected async Task VerifyTrackMethod(Action<TelemetryClient> clientConsumer, string expectedFileName,
            params Action<JObject>[] assertions
        )
        {
            // Arrange
            TelemetryConfiguration configuration = new() { ConnectionString = _testConnectionString };
            TelemetryClient client = new TelemetryClient(configuration);

            // Act
            clientConsumer(client);
            client.Flush();

            var telemetryRequests = await FindRequestsOfTrackEndpoint();

            var httpRequestsSent = FindHttpRequestsSent(telemetryRequests);

            // Assert
            Assert.Single(telemetryRequests);

            var telemetryRequest = telemetryRequests.First();

            if (telemetryRequest.RequestMessage.Body != null)
            {
                VerifyTrackHttpRequests(httpRequestsSent, telemetryRequest.RequestMessage.Body, Path.Combine("json",
                    expectedFileName), assertions);
            }
        }

        protected async Task<IEnumerable<ILogEntry>> FindRequestsOfTrackEndpoint()
        {
            var pollInterval = TimeSpan.FromMilliseconds(100);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var timeout = TimeSpan.FromSeconds(10);

            while (stopwatch.Elapsed < timeout)
            {
                var requests = _mockServer.LogEntries;
                var telemetryRequests = requests.Where(r =>
                    r.RequestMessage.Path.Contains("track")).ToList();

                if (telemetryRequests.Any())
                {
                    return telemetryRequests;
                }

                await Task.Delay(pollInterval);
            }

            return _mockServer.LogEntries;
        }

        private static string FindHttpRequestsSent(IEnumerable<ILogEntry> telemetryRequests)
        {
            string httpRequestsSent = "";

            foreach (var request in telemetryRequests)
            {
                if (request.RequestMessage.Body != null)
                {
                    httpRequestsSent += JToken.Parse(request.RequestMessage.Body).ToString(Formatting.Indented);
                }
            }

            return httpRequestsSent;
        }

        private static void VerifyTrackHttpRequests(string httpRequestsSent, string current, string expectedFileName,
            IEnumerable<Action<JObject>> assertions)
        {
            var expectedAsString = ReadFileAsString(expectedFileName);

            var currentJson = JObject.Parse(current);
            var expectedJSon = JObject.Parse(expectedAsString);

            TimeShouldBeProvided(currentJson);
            SdkVersionShouldBeProvided(currentJson);

            if (assertions != null)
            {
                foreach (var assertion in assertions)
                {
                    assertion.Invoke(currentJson);
                }
            }

            RemoveNonComparableProperties(currentJson, expectedJSon);

            var frameworkName = FindDotNetEnv();
            var message =
                $"Expected ({expectedFileName}, {frameworkName}) {expectedJSon.ToString(Formatting.Indented)}\nActual: {currentJson.ToString(Formatting.Indented)}\nHTTP requests sent: {httpRequestsSent}";
            Assert.True(JToken.DeepEquals(expectedJSon, currentJson), message);
        }

        private static string FindDotNetEnv()
        {
            var frameworkName = AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName;
            var version = Environment.Version;
            return ".Net env: " + Environment.NewLine + "* " + frameworkName + Environment.NewLine + "* " + version;
        }

        private static void RemoveNonComparableProperties(JObject currentJson, JObject expectedJSon)
        {
            currentJson.Remove("time");
            expectedJSon.Remove("time");
            RemoveSomeTags(currentJson);
            RemoveSomeTags(expectedJSon);
            RemoveIdFromBaseData(currentJson);
            RemoveIdFromBaseData(expectedJSon);
            RemoveExceptionId(currentJson);
            RemoveExceptionId(expectedJSon);
        }

        private static void RemoveSomeTags(JObject json)
        {
            if (json["tags"] is not JObject tags) return;
            tags.Remove("ai.cloud.role");
            tags.Remove("ai.cloud.roleInstance");
            tags.Remove("ai.internal.sdkVersion");
            tags.Remove("ai.internal.nodeName");
            tags.Remove("ai.operation.id");
        }

        private static void RemoveIdFromBaseData(JObject json)
        {
            if (json["data"]?["baseData"] is not JObject baseData) return;
            baseData.Remove("id");
        }

        private static void RemoveExceptionId(JObject json)
        {
            var exceptions = json["data"]?["baseData"]?["exceptions"] as JArray;

            if (exceptions == null) return;

            foreach (var exception in exceptions)
            {
                if (exception is JObject exceptionObject)
                {
                    exceptionObject.Remove("id");
                }
            }
        }

        private static void SdkVersionShouldBeProvided(JObject currentJson)
        {
            var tagsToken = currentJson["tags"];
            var sdkVersionToken = tagsToken?["ai.internal.sdkVersion"];
            var sdkVersionValue = sdkVersionToken?.ToString();
            Assert.False(string.IsNullOrEmpty(sdkVersionValue), "ai.internal.sdkVersion must not be null or empty");
        }

        private static void TimeShouldBeProvided(JObject currentJson)
        {
            var timeValue = currentJson["time"];
            Assert.False(string.IsNullOrEmpty(timeValue?.ToString()), "Time field must not be null or empty");
        }

        protected static void IdShouldBeProvidedInBaseData(JObject currentJson)
        {
            var baseData = currentJson["data"]?["baseData"] as JObject;

            if (baseData == null)
            {
                Assert.Fail("Should have baseData property.");
            }

            Assert.False(string.IsNullOrEmpty(baseData["id"]?.ToString()), "BaseData should have an id");
        }

        private static string ReadFileAsString(string file, [CallerFilePath] string filePath = "")
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            var fullPath = Path.Combine(directoryPath ?? string.Empty, file);
            return File.ReadAllText(fullPath);
        }

        protected static Action<JObject> NodeNameShouldBeEqualTo(string nodeName)
        {
            return json => { Assert.Equal(nodeName, (string)json["tags"]?["ai.internal.nodeName"]!); };
        }
        public void Dispose()
        {
            _mockServer?.Stop();
            _mockServer?.Dispose();
        }
    }
}
