// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    public class CallRecordingLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallRecordingLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task RecordingOperations()
        {
            if (SkipCallingServerInteractionLiveTests)
            {
                Assert.Ignore("Skip callingserver interaction live tests flag is on");
            }

            CallAutomationClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            string callConnectionId = "";
            bool stopRecording = false;
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetUser = TestEnvironment.TargetUserId;
                string ngrok = "https://localhost";
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(targetUser) };
                var callResponse = await client.CreateCallAsync(new CallSource(user), targets, new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(callResponse);
                Assert.NotNull(callResponse.Value);
                string callId = "serverCallId";
                callConnectionId = callResponse.Value.CallConnection.CallConnectionId;
                CallRecording callRecording = client.GetCallRecording();
                var recordingResponse = await callRecording.StartRecordingAsync(new ServerCallLocator(callId), new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);

                var recordingId = recordingResponse.Value.RecordingId;
                Assert.NotNull(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);

                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);
                Assert.NotNull(recordingResponse.Value.RecordingStatus);
                Assert.AreEqual(recordingResponse.Value.RecordingStatus, RecordingStatus.Active);

                await callRecording.PauseRecordingAsync(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);
                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);
                Assert.NotNull(recordingResponse.Value.RecordingStatus);
                Assert.AreEqual(recordingResponse.Value.RecordingStatus, RecordingStatus.Inactive);

                await callRecording.ResumeRecordingAsync(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);
                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);
                Assert.NotNull(recordingResponse.Value.RecordingStatus);
                Assert.AreEqual(recordingResponse.Value.RecordingStatus, RecordingStatus.Active);

                await callRecording.StopRecordingAsync(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);
                stopRecording = true;
                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && stopRecording)
                {
                    // recording stopped successfully
                    Assert.Pass();
                }
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                var callConnection = client.GetCallConnection(callConnectionId);
                await callConnection.HangUpAsync(true).ConfigureAwait(false);
            }
        }
    }
}
