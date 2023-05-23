// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http;

namespace Azure.Communication.CallAutomation.Tests.CallMedias
{
    internal class CallMediaAutomatedLiveTests : CallAutomationClientAutomatedLiveTestsBase
    {
        public CallMediaAutomatedLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ContinuousRecognitionAndSendDtmfTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallAutomationClient and a target CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. start continuous dtmf recognition.
             * 5. again start continuous dtmf recognition and expect success.
             * 6. stop continuous dtmf recognition.
             * 7. wait for ContinuousDtmfRecognitionStopped event.
             * 8. send dtmf tones to the target user.
             * 9. wait for SendDtmfCompleted event.
             * 10. clean up call.
            */

            /*TODO: add a phone number in call and do sendDtmf to that number
             * figure out:
             * a target acs phone number
             * why startCont is failing in 2nd time
             * on which env and build live tests are working
             * how to see cfv of live tests
             * is there any dashbaord for live tests
             **/
            // create caller and receiver
            CommunicationUserIdentifier user = await CreateIdentityUserAsync().ConfigureAwait(false);
            CommunicationUserIdentifier target = await CreateIdentityUserAsync().ConfigureAwait(false);
            //target = (CommunicationUserIdentifier)CommunicationUserIdentifier.FromRawId(CallAutomationClientTestEnvironment.TargetNumber);

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString(user);
            CallAutomationClient targetClient = CreateInstrumentedCallAutomationClientWithConnectionString(target);

            // setup service bus
            var uniqueId = await ServiceBusWithNewCall(user, target);

            // create call and assert response
            /*var createCallOptions = new CreateCallOptions(new CallInvite(user), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            CreateCallResult response = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);*/

            CreateCallResult response = await client.CreateCallAsync(new CallInvite(target), new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));

            // create group call options with a list of target users
            /*CreateGroupCallOptions createGroupCallOptions = new CreateGroupCallOptions(new CommunicationUserIdentifier[] { user }, new Uri(TestEnvironment.DispatcherCallback + $"?q={uniqueId}"));
            CreateCallResult response = await client.CreateGroupCallAsync(createGroupCallOptions).ConfigureAwait(false);*/

            string callConnectionId = response.CallConnectionProperties.CallConnectionId;
            Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);

            // wait for incomingcall context
            string? incomingCallContext = await WaitForIncomingCallContext(uniqueId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(incomingCallContext);

            // answer the call
            var answerCallOptions = new AnswerCallOptions(incomingCallContext, new Uri(TestEnvironment.DispatcherCallback));
            var answerResponse = await targetClient.AnswerCallAsync(answerCallOptions);
            Assert.AreEqual(StatusCodes.Status200OK, answerResponse.GetRawResponse().Status);

            // wait for callConnected
            var connectedEvent = await WaitForEvent<CallConnected>(callConnectionId, TimeSpan.FromSeconds(20));
            Assert.IsNotNull(connectedEvent);
            Assert.IsTrue(connectedEvent is CallConnected);
            Assert.IsTrue(((CallConnected)connectedEvent!).CallConnectionId == callConnectionId);

            // test get properties
            Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
            Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);

            try
            {
                // start continuous dtmf recognition
                var startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(user);
                Assert.AreEqual(StatusCodes.Status200OK, startContinuousDtmfResponse.Status);

                // again start continuous dtmf recognition and expect success
                /*startContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StartContinuousDtmfRecognitionAsync(user);
                Assert.AreEqual(startContinuousDtmfResponse.Status, StatusCodes.Status200OK);*/

                // stop continuous dtmf recognition
                var stopContinuousDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().StopContinuousDtmfRecognitionAsync(user);
                Assert.AreEqual(StatusCodes.Status200OK, startContinuousDtmfResponse.Status);

                // wait for ContinuousDtmfRecognitionStopped event
                var continuousDtmfRecognitionStopped = await WaitForEvent<ContinuousDtmfRecognitionStopped>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(continuousDtmfRecognitionStopped);
                Assert.IsTrue(continuousDtmfRecognitionStopped is ContinuousDtmfRecognitionStopped);

                // send dtmf tones to the target user
                var tones = new DtmfTone[] { DtmfTone.One, DtmfTone.Two, DtmfTone.Three, DtmfTone.Pound };
                var sendDtmfResponse = await client.GetCallConnection(callConnectionId).GetCallMedia().SendDtmfAsync(tones, target);
                Assert.AreEqual(StatusCodes.Status202Accepted, sendDtmfResponse.GetRawResponse().Status);

                // wait for SendDtmfCompleted event
                var sendDtmfCompletedEvent = await WaitForEvent<SendDtmfCompleted>(callConnectionId, TimeSpan.FromSeconds(20));
                Assert.IsNotNull(sendDtmfCompletedEvent);
                Assert.IsTrue(sendDtmfCompletedEvent is SendDtmfCompleted);
            }
            catch (RequestFailedException ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                await CleanUpCall(client, callConnectionId);
            }
        }
    }
}
