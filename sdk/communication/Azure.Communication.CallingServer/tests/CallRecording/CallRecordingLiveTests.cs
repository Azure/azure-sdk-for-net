// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.CallingServer
{
    internal class CallRecordingLiveTests : CallingServerClientLiveTestsBase
    {
        public CallRecordingLiveTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        public async Task RecordingOperations()
        {
            //if (SkipCallingServerInteractionLiveTests)
            //{
            //    Assert.Ignore("Skip callingserver interaction live tests flag is on");
            //}

            CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                string callLocatorId = "aHR0cHM6Ly9hcGkuZmxpZ2h0cHJveHkuc2t5cGUuY29tL2FwaS92Mi9jcC9jb252LXVzc2MtMDYuY29udi5za3lwZS5jb20vY29udi9pemF4eVdxOXZFT3FtSE14VktNeUtRP2k9MTYmZT02Mzc5NTA2NzA0OTI2OTM2MTU";
                string ngrok = "https://6961-2001-4898-80e8-9-b17d-4a04-3083-2cc4.ngrok.io";
                CallRecording callRecording = client.GetCallRecording();
                var recordingResponse = await callRecording.StartRecordingAsync(new ServerCallLocator(callLocatorId), new Uri(ngrok)).ConfigureAwait(false);
                Assert.NotNull(recordingResponse.Value);

                var recordingId = recordingResponse.Value.RecordingId;
                Assert.NotNull(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);

                //await callRecording.PauseRecordingAsync(recordingId);
                //await WaitForOperationCompletion().ConfigureAwait(false);
                //recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                //Assert.NotNull(recordingResponse.Value);
                //Assert.NotNull(recordingResponse.Value.RecordingStatus);
                //Assert.Equals(recordingResponse.Value.RecordingStatus ?? "", "inactive");

                //await callRecording.ResumeRecordingAsync(recordingId);
                //await WaitForOperationCompletion().ConfigureAwait(false);
                //recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
                //Assert.NotNull(recordingResponse.Value);
                //Assert.NotNull(recordingResponse.Value.RecordingStatus);
                //Assert.Equals(recordingResponse.Value.RecordingStatus ?? "", "active");

                await callRecording.StopRecordingAsync(recordingId);
                await WaitForOperationCompletion().ConfigureAwait(false);
                recordingResponse = await callRecording.GetRecordingStateAsync(recordingId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && wasConnected)
                {
                    Assert.Pass();
                }
                Assert.Fail($"Unexpected Error: {ex}");
            }
        }
    }
}
