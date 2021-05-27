// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests
{
    public class ConversationClientsTests
    {
        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecording_Passes(string expectedConversationId, Uri expectedCallbackUri)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response<StartCallRecordingResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.StartRecordingAsync(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, Uri callBackUri, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedCallbackUri, callBackUri);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<StartCallRecordingResponse>>().Object;
                });

            Response<StartCallRecordingResponse> actualResponse = await mockConversationClient.Object.StartRecordingAsync(expectedConversationId, expectedCallbackUri, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public async Task StopRecording_Passes(string expectedConversationId, string expectedRecordingId)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.StopRecordingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, string recordingId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedRecordingId, recordingId);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockConversationClient.Object.StopRecordingAsync(expectedConversationId, expectedRecordingId, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public async Task PauseRecording_Passes(string expectedConversationId, string expectedRecordingId)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.PauseRecordingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, string recordingId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedRecordingId, recordingId);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockConversationClient.Object.PauseRecordingAsync(expectedConversationId, expectedRecordingId, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public async Task ResumeRecording_Passes(string expectedConversationId, string expectedRecordingId)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.ResumeRecordingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, string recordingId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedRecordingId, recordingId);
                    return expectedResponse = new Mock<Response>().Object;
                });

            Response actualResponse = await mockConversationClient.Object.ResumeRecordingAsync(expectedConversationId, expectedRecordingId, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingState_Passes(string expectedConversationId, string expectedRecordingId)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response<GetCallRecordingStateResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.GetRecordingStateAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, string recordingId, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedRecordingId, recordingId);
                    return expectedResponse = new Mock<Response<GetCallRecordingStateResponse>>().Object;
                });

            Response<GetCallRecordingStateResponse> actualResponse = await mockConversationClient.Object.GetRecordingStateAsync(expectedConversationId, expectedRecordingId, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [TestCaseSource(nameof(TestData_PlayAudioWithoutRequest))]
        public async Task PlayAudioAsync_Passes(string expectedConversationId, Uri expectedAudioFileUri, string expectedOperationContext)
        {
            Mock<ConversationClient> mockConversationClient = new Mock<ConversationClient>();
            Response<PlayAudioResponse>? expectedResponse = default;
            CancellationToken cancellationToken = new CancellationTokenSource().Token;
            var callExpression = BuildExpression(x => x.PlayAudioAsync(It.IsAny<string>(), It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

            mockConversationClient
                .Setup(callExpression)
                .ReturnsAsync((string conversationId, Uri audioFileUri, string operationContext, CancellationToken token) =>
                {
                    Assert.AreEqual(expectedConversationId, conversationId);
                    Assert.AreEqual(expectedAudioFileUri, audioFileUri);
                    Assert.AreEqual(expectedOperationContext, operationContext);
                    Assert.AreEqual(cancellationToken, token);
                    return expectedResponse = new Mock<Response<PlayAudioResponse>>().Object;
                });

            Response<PlayAudioResponse> actualResponse = await mockConversationClient.Object.PlayAudioAsync(expectedConversationId, expectedAudioFileUri, expectedOperationContext, cancellationToken);

            mockConversationClient.Verify(callExpression, Times.Once());
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        private static IEnumerable<object?[]> TestData_StartRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    new Uri("https://somecallbackurl"),
                },
            };
        }

        private static IEnumerable<object?[]> TestData_StopRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PauseRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_ResumeRecording()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_GetRecordingState()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    "sampleRecordingId",
                },
            };
        }

        private static IEnumerable<object?[]> TestData_PlayAudioWithoutRequest()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                    "sampleOperationContext",
                }
            };
        }

        private static Expression<Func<ConversationClient, TResult>> BuildExpression<TResult>(Expression<Func<ConversationClient, TResult>> expression)
            => expression;
    }
}
