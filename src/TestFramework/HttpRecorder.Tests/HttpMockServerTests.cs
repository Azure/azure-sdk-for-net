// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using Newtonsoft.Json.Linq;
using Xunit;

namespace HttpRecorder.Tests
{
    [Collection("SerialCollection1")]
    public class HttpMockServerTests : IDisposable
    {
        private string currentDir;

        public HttpMockServerTests()
        {
            currentDir = Directory.GetCurrentDirectory();// Environment.CurrentDirectory;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();
        }

        private FakeHttpClient CreateClient()
        {
            return new FakeHttpClient(new DelegatingHandler[] { HttpMockServer.CreateInstance(), GetRecordingHandler() });
        }

        private DelegatingHandler GetRecordingHandler()
        {
            var recordingHandler = new RecordedDelegatingHandler(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'error':'message'}")
            });
            recordingHandler.StatusCodeToReturn = HttpStatusCode.OK;
            return recordingHandler;
        }

        private FakeHttpClient CreateClientWithBadResult()
        {
            return new FakeHttpClient(new DelegatingHandler[] { HttpMockServer.CreateInstance(), GetRecordingHandlerWithBacdResponse() });
        }

        private DelegatingHandler GetRecordingHandlerWithBacdResponse()
        {
            var recordingHandlerWithBadResponse = new RecordedDelegatingHandler(new HttpResponseMessage(HttpStatusCode.Conflict));
            recordingHandlerWithBadResponse.StatusCodeToReturn = HttpStatusCode.Conflict;
            return recordingHandlerWithBadResponse;
        }

        [Fact]
        public void TestRecordingWithOneClientWritesFile()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client = CreateClient();
            var result = client.DoStuffA().Result;

            HttpMockServer.Flush(currentDir);

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json")));
        }

        [Fact]
        public void TestRecordingWithVariablesStoresVariable()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client = CreateClient();
            var result = client.DoStuffA().Result;
            HttpMockServer.Variables["varA"] = "varA-value";

            HttpMockServer.Flush(currentDir);

            HttpMockServer.Variables.Clear();

            var recording = RecordEntryPack.Deserialize(Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json"));

            Assert.Equal("varA-value", recording.Variables["varA"]);
        }

        [Fact]
        public void TestRecordingWithVariablesStoresAndRetrieves()
        {
            HttpMockServer.RecordsDirectory = currentDir;

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client = CreateClient();
            var result = client.DoStuffA().Result;
            HttpMockServer.Variables["varA"] = "varA-value";

            HttpMockServer.Flush(currentDir);

            HttpMockServer.Variables.Clear();

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);

            Assert.Equal("varA-value", HttpMockServer.Variables["varA"]);
        }

        [Fact]
        public void TestRecordingWithTwoClientsWritesFile()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            FakeHttpClient client2 = CreateClient();
            var result1 = client1.DoStuffA().Result;
            var result2 = client2.DoStuffA().Result;

            HttpMockServer.Flush(currentDir);

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json")));
        }

        [Fact]
        public void TestPlaybackWithOneClient()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var result1A = client1.DoStuffA().Result;
            var result1B = client1.DoStuffB().Result;
            string assetName1 = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            string assetName2 = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.None);
            FakeHttpClient client2 = CreateClientWithBadResult();
            var result2 = client2.DoStuffA().Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClientWithBadResult();
            var result3B = client3.DoStuffB().Result;
            var result3A = client3.DoStuffA().Result;
            string assetName1Playback = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            string assetName2Playback = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            HttpMockServer.Flush(currentDir);

            string result1AConent = JObject.Parse(result1A.Content.ReadAsStringAsync().Result).ToString();
            string result3AConent = JObject.Parse(result3A.Content.ReadAsStringAsync().Result).ToString();

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json")));
            Assert.Equal(result1A.StatusCode, result3A.StatusCode);
            Assert.Equal(result1A.RequestMessage.RequestUri.AbsoluteUri, result3A.RequestMessage.RequestUri.AbsoluteUri);
            Assert.Equal(result1AConent, result3AConent);
            Assert.Equal(HttpStatusCode.Conflict, result2.StatusCode);
            Assert.Equal(assetName1, assetName1Playback);
            Assert.Equal(assetName2, assetName2Playback);
        }

        [Fact]
        public void PlaybackWithDifferentBodyIsMatched()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultCOrig = client1.DoStuffC("test", "123", "abc").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            var resultCPlayback = client1.DoStuffC("different", "123", "abc").Result;
            HttpMockServer.Flush(currentDir);

            Assert.Equal(resultCOrig.RequestMessage.RequestUri, resultCPlayback.RequestMessage.RequestUri);
        }

        [Fact]
        public void PlaybackWithDifferentVersionInUrlDoesNotMatch()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultCOrig = client1.DoStuffC("test", "123", "abc").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            Assert.Throws<AggregateException>(() => client1.DoStuffC("test", "123", "xyz").Result);
        }

        [Fact]
        public void NotFoundExceptionContainUrlAndMethodName()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultCOrig = client1.DoStuffC("test", "123", "abc").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            try
            {
                var r = client1.DoStuffC("test", "123", "xyz").Result;
                Assert.False(true);
            }
            catch (AggregateException aggregateException)
            {
                var exception = aggregateException.InnerExceptions[0];

                //TODO: figure out whether exception message ever mentioned 'DoStuffC' 
                Assert.Equal("Unable to find a matching HTTP request for URL 'POST /path/to/resourceB?api-version=xyz (x-ms-version=123)'. Calling method Item().",
                    exception.Message);
            }
        }

        [Fact]
        public void PlaybackWithDifferentVersionInHeaderDoesNotMatch()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultCOrig = client1.DoStuffC("test", "123", "abc").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            Assert.Throws<AggregateException>(() => client1.DoStuffC("test", "456", "abc").Result);
        }

        [Fact]
        public void PlaybackWithSameContentTypeMatches()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultDOrig = client1.DoStuffD("text/json").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            var resultDPlayback = client1.DoStuffD("text/json").Result;

            Assert.Equal(resultDOrig.RequestMessage.RequestUri, resultDPlayback.RequestMessage.RequestUri);
        }

        [Fact(Skip = "Removed content check for now as it requires re-recording of all tests.")]
        public void PlaybackWithDifferentContentTypeDoesNotMatch()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var resultCOrig = client1.DoStuffD("text/json").Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClient();
            Assert.Throws<AggregateException>(() => client1.DoStuffD("text/xml").Result);
        }

        [Fact]
        public void TestRecordingWithTwoMethodsWritesFile()
        {
            HttpMockServer.Initialize(this.GetType(), "testA", HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            FakeHttpClient client2 = CreateClient();
            var result1 = client1.DoStuffA().Result;
            var result2 = client2.DoStuffA().Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), "testB", HttpRecorderMode.Record);
            FakeHttpClient client3 = CreateClient();
            var result3 = client3.DoStuffA().Result;
            HttpMockServer.Flush(currentDir);

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, "testA.json")));
            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, "testB.json")));
        }

        [Fact]
        public void TestRecordingWithTwoMethodsWithoutFlushing()
        {
            HttpMockServer.Initialize(this.GetType(), "testA", HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            FakeHttpClient client2 = CreateClient();
            var result1 = client1.DoStuffA().Result;
            var result2 = client2.DoStuffA().Result;

            HttpMockServer.Initialize(this.GetType(), "testB", HttpRecorderMode.Record);
            FakeHttpClient client3 = CreateClient();
            var result3 = client3.DoStuffA().Result;
            HttpMockServer.Flush(currentDir);

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, "testB.json")));
        }

        [Fact]
        public void TestRecordingWithTwoMethodsWritesAllData()
        {
            HttpMockServer.Initialize(this.GetType(), "testA", HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            FakeHttpClient client2 = CreateClient();
            var result1 = client1.DoStuffA().Result;
            var result2 = client2.DoStuffA().Result;
            var name = HttpMockServer.GetAssetName("testA", "tst");
            HttpMockServer.Flush(currentDir);
            RecordEntryPack pack = RecordEntryPack.Deserialize(Path.Combine(HttpMockServer.CallerIdentity, "testA.json"));

            Assert.NotNull(name);
            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, "testA.json")));
            Assert.Equal(2, pack.Entries.Count);
            Assert.Equal(1, pack.Names["testA"].Count);
        }

        [Fact]
        public void MissingFileOnPlaybackThrowsAnException()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            Assert.Throws<ArgumentException>(() => HttpMockServer.Initialize(this.GetType(), "testA", HttpRecorderMode.Playback));
        }

        [Fact]
        public void VariablePersistsInARecording()
        {
            HttpMockServer.RecordsDirectory = currentDir;

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            var result1 = client1.DoStuffA().Result;
            var value1 = HttpMockServer.GetVariable("varA", "tst123");
            Assert.Equal("tst123", value1);

            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            var value2 = HttpMockServer.GetVariable("varA", "tst456");
            Assert.Equal("tst123", value2);
        }

        [Fact]
        public void NoneModeCreatesNoFiles()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.None);
            FakeHttpClient client = CreateClient();
            var result = client.DoStuffA().Result;

            HttpMockServer.Flush(currentDir);

            Assert.False(File.Exists(TestUtilities.GetCurrentMethodName() + ".json"));
        }

        [Fact]
        public void TestRecordingWithExplicitDir()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            HttpMockServer.RecordsDirectory = Path.GetTempPath();

            FakeHttpClient client = CreateClient();
            var result = client.DoStuffA().Result;

            HttpMockServer.Flush();

            Assert.True(File.Exists(Path.Combine(Path.GetTempPath(), this.GetType().Name, TestUtilities.GetCurrentMethodName() + ".json")));
            HttpMockServer.RecordsDirectory = currentDir;
        }

        [Fact]
        public void TestPlaybackWithAssetInUrlClient()
        {
            HttpMockServer.RecordsDirectory = currentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient client1 = CreateClient();
            string assetName1 = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            string assetName2 = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            var result1A = client1.DoStuffX(assetName1).Result;
            var result1B = client1.DoStuffX(assetName2).Result;
            HttpMockServer.Flush(currentDir);

            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient client3 = CreateClientWithBadResult();
            string assetName1Playback = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            string assetName2Playback = HttpMockServer.GetAssetName(TestUtilities.GetCurrentMethodName(), "tst");
            var result3A = client3.DoStuffX(assetName1Playback).Result;
            var result3B = client3.DoStuffX(assetName2Playback).Result;
            HttpMockServer.Flush(currentDir);

            string result1AConent = JObject.Parse(result1A.Content.ReadAsStringAsync().Result).ToString();
            string result3AConent = JObject.Parse(result3A.Content.ReadAsStringAsync().Result).ToString();

            Assert.True(File.Exists(Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json")));
            Assert.Equal(result1A.StatusCode, result3A.StatusCode);
            Assert.Equal(result1A.RequestMessage.RequestUri.AbsoluteUri, result3A.RequestMessage.RequestUri.AbsoluteUri);
            Assert.Equal(result1AConent, result3AConent);
            Assert.Equal(assetName1, assetName1Playback);
            Assert.Equal(assetName2, assetName2Playback);
        }

        public void Dispose()
        {
            string outputDir = Path.Combine(currentDir, this.GetType().Name);
            if (Directory.Exists(outputDir))
            {
                try
                {
                    Directory.Delete(outputDir, true);
                }
                catch
                {
                    
                }
            }

            HttpMockServer.RecordsDirectory = "SessionRecords";
        }
    }
}
