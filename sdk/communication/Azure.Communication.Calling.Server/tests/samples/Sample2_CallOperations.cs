// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Call.Models;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.Calling.Server.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample2_CallOperations : SamplesBase<CallTestEnvironment>
    {
        public async Task CreateCallAsync()
        {
            // Create a call client
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
            CallClient callClient = new CallClient(connectionString);

            var source = new CommunicationUserIdentifier("d7f75b6e-1cc6-4e9a-95bc-fdfc2647182f");

            var target1 = new CommunicationUserIdentifier("d7f75b6e-1cc6-4e9a-95bc-fdfc2647182f");
            var target2 = new PhoneNumberIdentifier("{number form Acs resource}");
            var targets = new List<CommunicationIdentifier>() { target1, target2 };

            string subject = "test";
            Uri callbackUri = new Uri("callbackUri");
            List<CreateCallRequestRequestedModalitiesItem> requestedModalities = new List<CreateCallRequestRequestedModalitiesItem>() { CreateCallRequestRequestedModalitiesItem.Video };
            List<CreateCallRequestRequestedCallEventsItem>? requestedCallEvents = new List<CreateCallRequestRequestedCallEventsItem>() { CreateCallRequestRequestedCallEventsItem.CallStarted };

            #region Snippet:Azure_Communication_Call_Tests_Samples_CreateCall
            CreateCallResponse callResponse = await callClient.CreateCallAsync(source, targets, subject, callbackUri, requestedModalities, requestedCallEvents);
            #endregion Snippet:Azure_Communication_Call_Tests_Samples_CreateCall

            string callId = callResponse.CallId;
        }

        public async Task DeleteCallAsync()
        {
            // Create a call client
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
            CallClient callClient = new CallClient(connectionString);

            #region Snippet:Azure_Communication_Call_Tests_Samples_DeleteCall
            await callClient.DeleteCallAsync("callId");
            #endregion Snippet:Azure_Communication_Call_Tests_Samples_DeleteCall
        }

        public async Task HangupAsync()
        {
            // Create a call client
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
            CallClient callClient = new CallClient(connectionString);

            #region Snippet:Azure_Communication_Call_Tests_Samples_Hangup
            await callClient.HangupAsync("callId", new HangUpCallRequest());
            #endregion Snippet:Azure_Communication_Call_Tests_Samples_Hangup
        }
    }
}
