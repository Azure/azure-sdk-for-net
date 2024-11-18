// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class CallRecordingTests : CallAutomationTestBase
    {
        private const string RecordingId = "sampleRecordingId";
        private const string DummyRecordingStatusResponse = "{" +
                                        "\"recordingId\": \"dummyRecordingId\"," +
                                        "\"recordingState\": \"active\"" +
                                        "}";

        private static readonly CallLocator _callLocator = new ServerCallLocator(ServerCallId);
        private static readonly Uri _callBackUri = new Uri("https://somecallbackurl");

        [TestCaseSource(nameof(TestData_OperationsWithStatus))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecordingOperations_WithRecordingStatus_Success(Func<CallRecording, RecordingStateResult> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            RecordingStateResult result = operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsAsyncWithStatus))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RecordingOperationsAsync_WithRecordingStatus_Success(Func<CallRecording, Task<Response<RecordingStateResult>>> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            Response<RecordingStateResult> result = await operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.Value.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsSuccess))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecordingOperations_ReturnsSuccess(int expectedStatusCode, HttpStatusCode httpStatusCode, Func<CallRecording, Response> operation)
        {
            CallRecording callRecording = getMockCallRecording(expectedStatusCode);

            Response response = operation(callRecording);
            Assert.AreEqual(expectedStatusCode, response.Status);
        }

        [TestCaseSource(nameof(TestData_OperationsAsyncSuccess))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RecordingOperationsAsync_ReturnsSuccess(int expectedStatusCode, HttpStatusCode httpStatusCode, Func<CallRecording, Task<Response>> operation)
        {
            CallRecording callRecording = getMockCallRecording(expectedStatusCode);

            Response response = await operation(callRecording);
            Assert.AreEqual(expectedStatusCode, response.Status);
        }

        [TestCaseSource(nameof(TestData_Operations404))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecordingOperation_Returns404NotFound(Func<CallRecording, TestDelegate> operation)
        {
            CallRecording callRecording = getMockCallRecording(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(operation(callRecording));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_OperationsAsync404))]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void RecordingOperationAsync_Returns404NotFound(Func<CallRecording, AsyncTestDelegate> operation)
        {
            CallRecording callRecording = getMockCallRecording(404);

            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(operation(callRecording));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        private CallRecording getMockCallRecording(int statusCode, string? responseContent = null)
        {
            CallAutomationClient serverCallRestClient = CreateMockCallAutomationClient(statusCode, responseContent: responseContent);
            return serverCallRestClient.GetCallRecording();
        }

        private static IEnumerable<object?[]> TestData_OperationsSuccess()
        {
            Func<CallRecording, Response> stopRecording = callRecording => callRecording.StopRecording(RecordingId);
            Func<CallRecording, Response> pauseRecording = callRecording => callRecording.PauseRecording(RecordingId);
            Func<CallRecording, Response> resumeRecording = callRecording => callRecording.ResumeRecording(RecordingId);
            return new[]
            {
                new object?[]
                {
                    202,
                    HttpStatusCode.Accepted,
                    resumeRecording,
                },
                new object?[]
                {
                    202,
                    HttpStatusCode.Accepted,
                    pauseRecording,
                },
                new object?[]
                {
                    204,
                    HttpStatusCode.NoContent,
                    stopRecording,
                }
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsyncSuccess()
        {
            Func<CallRecording, Task<Response>> stopRecordingAsync = callRecording => callRecording.StopRecordingAsync(RecordingId);
            Func<CallRecording, Task<Response>> pauseRecordingAsync = callRecording => callRecording.PauseRecordingAsync(RecordingId);
            Func<CallRecording, Task<Response>> resumeRecordingAsync = callRecording => callRecording.ResumeRecordingAsync(RecordingId);
            return new[]
            {
                new object?[]
                {
                    202,
                    HttpStatusCode.Accepted,
                    resumeRecordingAsync,
                },
                new object?[]
                {
                    202,
                    HttpStatusCode.Accepted,
                    pauseRecordingAsync,
                },
                new object?[]
                {
                    204,
                    HttpStatusCode.NoContent,
                    stopRecordingAsync,
                }
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsWithStatus()
        {
            return new[]
            {
                new Func<CallRecording, RecordingStateResult>?[]
                {
                   callRecording => callRecording.StartRecording(new StartRecordingOptions(_callLocator) { RecordingStateCallbackEndpoint = _callBackUri })
                },
                new Func<CallRecording, RecordingStateResult>?[]
                {
                   callRecording => callRecording.GetRecordingState(RecordingId)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsyncWithStatus()
        {
            return new[]
            {
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.StartRecordingAsync(new StartRecordingOptions(_callLocator) { RecordingStateCallbackEndpoint = _callBackUri })
                },
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.GetRecordingStateAsync(RecordingId)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_Operations404()
        {
            return new[]
            {
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () =>
                        callRecording.StartRecording(
                            new StartRecordingOptions(_callLocator)
                            {
                                RecordingStateCallbackEndpoint = _callBackUri
                            })
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.StartRecording(new StartRecordingOptions(_callLocator)
                    {
                        RecordingContent = RecordingContent.AudioVideo,
                        RecordingChannel = RecordingChannel.Mixed,
                        RecordingFormat = RecordingFormat.Mp4,
                        ChannelAffinity = new List<ChannelAffinity> { new() { Channel = 0, Participant = new CommunicationUserIdentifier("test") }}
                    })
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.StopRecording(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.PauseRecording(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.ResumeRecording(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.GetRecordingState(RecordingId)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsync404()
        {
            return new[]
            {
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StartRecordingAsync(new StartRecordingOptions(_callLocator)
                   {
                       RecordingStateCallbackEndpoint = _callBackUri
                   }).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StartRecordingAsync(new StartRecordingOptions(_callLocator)
                   {
                       RecordingStateCallbackEndpoint = _callBackUri,
                       RecordingContent = RecordingContent.AudioVideo,
                       RecordingChannel = RecordingChannel.Mixed,
                       RecordingFormat = RecordingFormat.Mp4,
                       ChannelAffinity = new List<ChannelAffinity> { new() { Channel = 0, Participant = new CommunicationUserIdentifier("test") }}
                   }).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StopRecordingAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.PauseRecordingAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.ResumeRecordingAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.GetRecordingStateAsync(RecordingId).ConfigureAwait(false),
                },
            };
        }
    }
}
