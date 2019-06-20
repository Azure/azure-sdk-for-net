

namespace HttpRecorder.Tests.MocServerTests
{
    using HttpRecorder.Tests;
    using HttpRecorder.Tests.DelegatingHandlers;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.IO;
    using System.Net.Http;
    using Xunit;

    public class BinaryDataTests : MoqServerTestBase
    {
        [Fact]
        public void RecordAndPlayBackAudioData()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient recordClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Audio));
            var result = recordClient.DoStuffA().Result;
            HttpMockServer.Flush(this.CurrentDir);

            string recordedFilePath = Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json");
            Assert.True(File.Exists(recordedFilePath));

            HttpMockServer.RecordsDirectory = this.CurrentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient playbackClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Audio));
            HttpResponseMessage playBackResult = playbackClient.DoStuffA().Result;

            Assert.True(RecorderUtilities.IsHttpContentBinary(playBackResult.Content), "Binary Data was not correctly serialized to recording file");
            HttpMockServer.Flush(CurrentDir);
        }

        [Fact]
        public void RecordAndPlayBackImageData()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient recordClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Image));
            var result = recordClient.DoStuffA().Result;
            HttpMockServer.Flush(this.CurrentDir);

            string recordedFilePath = Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json");
            Assert.True(File.Exists(recordedFilePath));

            HttpMockServer.RecordsDirectory = this.CurrentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient playbackClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Image));
            HttpResponseMessage playBackResult = playbackClient.DoStuffA().Result;

            Assert.True(RecorderUtilities.IsHttpContentBinary(playBackResult.Content), "Binary Data was not correctly serialized to recording file");
            HttpMockServer.Flush(CurrentDir);
        }


        [Fact]
        public void RecordAndPlayBackNullResponse()
        {
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Record);
            FakeHttpClient recordClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Null));
            var result = recordClient.DoStuffA().Result;
            HttpMockServer.Flush(this.CurrentDir);

            string recordedFilePath = Path.Combine(HttpMockServer.CallerIdentity, TestUtilities.GetCurrentMethodName() + ".json");
            Assert.True(File.Exists(recordedFilePath));

            HttpMockServer.RecordsDirectory = this.CurrentDir;
            HttpMockServer.Initialize(this.GetType(), TestUtilities.GetCurrentMethodName(), HttpRecorderMode.Playback);
            FakeHttpClient playbackClient = CreateClient(new BinaryDataDelegatingHandler(ContentMimeType.Null));
            HttpResponseMessage playBackResult = playbackClient.DoStuffA().Result;

            Assert.NotNull(playBackResult.Content);
            HttpMockServer.Flush(CurrentDir);
        }
    }
}
