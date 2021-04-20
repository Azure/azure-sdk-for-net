// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;

namespace Azure.Communication.Calling.Server.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_CallClient
    {
        public CallClient CreateCallClient()
        {
            #region Snippet:Azure_Communication_Call_Tests_Samples_CreateCallClient
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
            CallClient client = new CallClient(connectionString);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateCallClient
            return client;
        }
        public CallClient CreateCallClientWithToken()
        {
            #region Snippet:Azure_Communication_Call_Tests_Samples_CreateCallClientWithToken
            string endpoint = "<endpoint_url>";
            TokenCredential tokenCredential = new DefaultAzureCredential();
            CallClient client = new CallClient(new Uri(endpoint), tokenCredential);
            #endregion Snippet:Azure_Communication_Call_Tests_Samples_CreateCallClientWithToken
            return client;
        }
    }
}
