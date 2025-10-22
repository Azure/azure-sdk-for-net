// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.CallRecordings
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
        private static readonly ChannelAffinity channelAffinity = new ChannelAffinity(participant: new PhoneNumberIdentifier("+1234567"));
        private static readonly List<ChannelAffinity> testChannelAffinities = new List<ChannelAffinity>() { channelAffinity };

        [TestCaseSource(nameof(TestData_OperationsWithStatus))]
        public void RecordingOperations_WithRecordingStatus_Success(Func<CallRecording, RecordingStateResult> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            RecordingStateResult result = operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsAsyncWithStatus))]
        public async Task RecordingOperationsAsync_WithRecordingStatus_Success(Func<CallRecording, Task<Response<RecordingStateResult>>> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            Response<RecordingStateResult> result = await operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.Value.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsWithCallConnectionIdWithStatus))]
        public void RecordingOperations_WithCallConnectionId_WithRecordingStatus_Success(Func<CallRecording, RecordingStateResult> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            RecordingStateResult result = operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsAsyncWithCallConnectionIdWithStatus))]
        public async Task RecordingOperationsAsync_WithCallConnectionId_WithRecordingStatus_Success(Func<CallRecording, Task<Response<RecordingStateResult>>> operation)
        {
            CallRecording callRecording = getMockCallRecording(200, responseContent: DummyRecordingStatusResponse);

            Response<RecordingStateResult> result = await operation(callRecording);
            Assert.AreEqual("dummyRecordingId", result.Value.RecordingId);
            Assert.AreEqual(RecordingState.Active, result.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_OperationsSuccess))]
        public void RecordingOperations_ReturnsSuccess(int expectedStatusCode, HttpStatusCode httpStatusCode, Func<CallRecording, Response> operation)
        {
            CallRecording callRecording = getMockCallRecording(expectedStatusCode);

            Response response = operation(callRecording);
            Assert.AreEqual(expectedStatusCode, response.Status);
        }

        [TestCaseSource(nameof(TestData_OperationsAsyncSuccess))]
        public async Task RecordingOperationsAsync_ReturnsSuccess(int expectedStatusCode, HttpStatusCode httpStatusCode, Func<CallRecording, Task<Response>> operation)
        {
            CallRecording callRecording = getMockCallRecording(expectedStatusCode);

            Response response = await operation(callRecording);
            Assert.AreEqual(expectedStatusCode, response.Status);
        }

        [TestCaseSource(nameof(TestData_Operations404))]
        public void RecordingOperation_Returns404NotFound(Func<CallRecording, TestDelegate> operation)
        {
            CallRecording callRecording = getMockCallRecording(404);
            RequestFailedException? ex = Assert.Throws<RequestFailedException>(operation(callRecording));
            Assert.NotNull(ex);
            Assert.AreEqual(ex?.Status, 404);
        }

        [TestCaseSource(nameof(TestData_OperationsAsync404))]
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

        private static IEnumerable<object?[]> TestData_OperationsWithCallConnectionIdWithStatus()
        {
            return new[]
            {
                new Func<CallRecording, RecordingStateResult>?[]
                {
                   callRecording => callRecording.Start(new StartRecordingOptions(CallConnectionId)
        {
            RecordingStateCallbackUri = _callBackUri,
                       ChannelAffinity = testChannelAffinities
                   })
                },
                new Func<CallRecording, RecordingStateResult>?[]
                {
                   callRecording => callRecording.GetState(RecordingId)
}
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsyncWithCallConnectionIdWithStatus()
        {
            return new[]
            {
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.StartAsync(new StartRecordingOptions(CallConnectionId) {
                       RecordingStateCallbackUri = _callBackUri,
                       ChannelAffinity = testChannelAffinities
                   })
                },
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.GetStateAsync(RecordingId)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsSuccess()
        {
            Func<CallRecording, Response> stopRecording = callRecording => callRecording.Stop(RecordingId);
            Func<CallRecording, Response> pauseRecording = callRecording => callRecording.Pause(RecordingId);
            Func<CallRecording, Response> resumeRecording = callRecording => callRecording.Resume(RecordingId);
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
            Func<CallRecording, Task<Response>> stopRecordingAsync = callRecording => callRecording.StopAsync(RecordingId);
            Func<CallRecording, Task<Response>> pauseRecordingAsync = callRecording => callRecording.PauseAsync(RecordingId);
            Func<CallRecording, Task<Response>> resumeRecordingAsync = callRecording => callRecording.ResumeAsync(RecordingId);
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
                   callRecording => callRecording.Start(new StartRecordingOptions(_callLocator) { RecordingStateCallbackUri = _callBackUri, ChannelAffinity = testChannelAffinities})
                },
                new Func<CallRecording, RecordingStateResult>?[]
                {
                   callRecording => callRecording.GetState(RecordingId)
                }
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsyncWithStatus()
        {
            return new[]
            {
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.StartAsync(new StartRecordingOptions(_callLocator) { RecordingStateCallbackUri = _callBackUri, ChannelAffinity = testChannelAffinities})
                },
                new Func<CallRecording, Task<Response<RecordingStateResult>>>?[]
                {
                   callRecording => callRecording.GetStateAsync(RecordingId)
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
                        callRecording.Start(
                            new StartRecordingOptions(_callLocator)
                            {
                                RecordingStateCallbackUri = _callBackUri,
                                ChannelAffinity = testChannelAffinities
                            })
                },
               new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () =>
                        callRecording.Start(
                            new StartRecordingOptions("callconnectionid")
                            {
                                RecordingStateCallbackUri = _callBackUri,
                                ChannelAffinity = testChannelAffinities
                            })
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.Start(new StartRecordingOptions(_callLocator)
                    {
                        RecordingContent = RecordingContent.AudioVideo,
                        RecordingChannel = RecordingChannel.Mixed,
                        RecordingFormat = RecordingFormat.Mp4,
                        AudioChannelParticipantOrdering = { new CommunicationUserIdentifier("test") },
                        ChannelAffinity = testChannelAffinities,
                        PauseOnStart = false
                    })
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.Stop(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.Pause(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.Resume(RecordingId)
                },
                new Func<CallRecording, TestDelegate>?[]
                {
                    callRecording => () => callRecording.GetState(RecordingId)
                },
            };
        }

        private static IEnumerable<object?[]> TestData_OperationsAsync404()
        {
            return new[]
            {
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StartAsync(new StartRecordingOptions(_callLocator)
                   {
                       RecordingStateCallbackUri = _callBackUri
                   }).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StartAsync(new StartRecordingOptions(_callLocator)
                   {
                       RecordingStateCallbackUri = _callBackUri,
                       RecordingContent = RecordingContent.AudioVideo,
                       RecordingChannel = RecordingChannel.Mixed,
                       RecordingFormat = RecordingFormat.Mp4,
                       ChannelAffinity = testChannelAffinities,
                       PauseOnStart = false,
                       AudioChannelParticipantOrdering = { new CommunicationUserIdentifier("test"),}
                   }).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.StopAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.PauseAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.ResumeAsync(RecordingId).ConfigureAwait(false),
                },
                new Func<CallRecording, AsyncTestDelegate>?[]
                {
                   callRecording => async () => await callRecording.GetStateAsync(RecordingId).ConfigureAwait(false),
                },
            };
        }
    }
}
