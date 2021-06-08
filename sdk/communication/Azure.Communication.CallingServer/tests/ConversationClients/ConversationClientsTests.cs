// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Tests.ConversationClients;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    public class ConversationClientsTests : ConversationClientBaseTests
    {
        private const string DummyStartRecordingResponse = "{" +
                                                "\"recordingId\": \"dummyRecordingId\"" +
                                                "}";
        private const string DummyRecordingStateResponse = "{" +
                                                "\"recordingState\": \"active\"" +
                                                "}";

        private const string DummyPlayAudioResponse = "{" +
                                                "\"id\": \"dummyId\"," +
                                                "\"status\": \"running\"," +
                                                "\"operationContext\": \"dummyOperationContext\"," +
                                                "\"resultInfo\": {" +
                                                "\"code\": 200," +
                                                "\"subcode\": 200," +
                                                "\"message\": \"dummyMessage\"" +
                                                  "}" +
                                                "}";

        [TestCaseSource(nameof(TestData_StartRecording))]
        public void StartRecording_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ConversationClient _convClient = CreateMockConversationClient(200, DummyStartRecordingResponse);
            StartCallRecordingResponse response = _convClient.StartRecording(sampleConversationId, sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", response.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StartRecording))]
        public async Task StartRecordingAsync_Returns200Ok(string sampleConversationId, Uri sampleCallBackUri)
        {
            ConversationClient _convClient = CreateMockConversationClient(200, DummyStartRecordingResponse);
            Response<StartCallRecordingResponse> response = await _convClient.StartRecordingAsync(sampleConversationId, sampleCallBackUri);
            Assert.AreEqual("dummyRecordingId", response.Value.RecordingId);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public void StopRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = _convClient.StopRecording(sampleConversationId, sampleRecordingId);
            var temp = response.Status;
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_StopRecording))]
        public async Task StopRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = await _convClient.StopRecordingAsync(sampleConversationId, sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public void PauseRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = _convClient.PauseRecording(sampleConversationId, sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_PauseRecording))]
        public async Task PauseRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = await _convClient.PauseRecordingAsync(sampleConversationId, sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public void ResumeRecording_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = _convClient.ResumeRecording(sampleConversationId, sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_ResumeRecording))]
        public async Task ResumeRecordingAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200);
            Response response = await _convClient.ResumeRecordingAsync(sampleConversationId, sampleRecordingId);
            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public void GetRecordingState_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200, DummyRecordingStateResponse);
            GetCallRecordingStateResponse response = _convClient.GetRecordingState(sampleConversationId, sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.RecordingState);
        }

        [TestCaseSource(nameof(TestData_GetRecordingState))]
        public async Task GetRecordingStateAsync_Return200Ok(string sampleConversationId, string sampleRecordingId)
        {
            ConversationClient _convClient = CreateMockConversationClient(200, DummyRecordingStateResponse);
            Response<GetCallRecordingStateResponse> response = await _convClient.GetRecordingStateAsync(sampleConversationId, sampleRecordingId);
            Assert.AreEqual(CallRecordingState.Active, response.Value.RecordingState);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public void PlayAudio_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ConversationClient _convClient = CreateMockConversationClient(202, DummyPlayAudioResponse);
            PlayAudioResponse response = _convClient.PlayAudio(sampleConversationId, sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        [TestCaseSource(nameof(TestData_PlayAudio))]
        public async Task PlayAudioAsync_Return202Accepted(string sampleConversationId, Uri sampleAudioFileUri, string sampleAudioFileId, Uri sampleCallbackUri, string sampleOperationContext)
        {
            ConversationClient _convClient = CreateMockConversationClient(202, DummyPlayAudioResponse);
            Response<PlayAudioResponse> response = await _convClient.PlayAudioAsync(sampleConversationId, sampleAudioFileUri, sampleAudioFileId, sampleCallbackUri, sampleOperationContext);
            VerifyPlayAudioResponse(response);
        }

        private void VerifyPlayAudioResponse(PlayAudioResponse response)
        {
            Assert.AreEqual("dummyId", response.Id);
            Assert.AreEqual(OperationStatus.Running, response.Status);
            Assert.AreEqual("dummyOperationContext", response.OperationContext);
            Assert.AreEqual(200, response.ResultInfo.Code);
            Assert.AreEqual("dummyMessage", response.ResultInfo.Message);
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

        private static IEnumerable<object?[]> TestData_PlayAudio()
        {
            return new List<object?[]>(){
                new object?[] {
                    "sampleConversationId",
                    new Uri("https://av.ngrok.io/audio/sample-message.wav"),
                    "sampleAudioFileId",
                    new Uri("https://av.ngrok.io/someCallbackUri"),
                    "sampleOperationContext",
                }
            };
        }

        private static Expression<Func<ConversationClient, TResult>> BuildExpression<TResult>(Expression<Func<ConversationClient, TResult>> expression)
            => expression;
    }
}
