// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Communication.AlphaIds.Tests
{
    public class AlphaIdsClientTestBase : RecordedTestBase<AlphaIdsClientTestEnvironment>
    {
        public AlphaIdsClientTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }

        protected AlphaIdsClient CreateAlphaIdsClientClient()
        {
            #region Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@AlphaIdsClient client = new AlphaIdsClient(connectionString);
            #endregion Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClient

            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new AlphaIdsClient(connectionString, CreateAlphaIdsClientOptionsWithCorrelationVectorLogs());

            return InstrumentClient(client);
        }

        public AlphaIdsClient CreateAlphaIdsClientWithToken()
        {
            Uri endpoint = TestEnvironment.LiveTestStaticEndpoint;
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                #region Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                /*@@*/
                tokenCredential = new DefaultAzureCredential();
                //@@ AlphaIdsClient client = new AlphaIdsClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_AlphaIds_CreateAlphaIdsClientWithToken
            }

            AlphaIdsClient client = new AlphaIdsClient(endpoint, tokenCredential, CreateAlphaIdsClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(client);
        }

        protected AlphaIdsClientOptions CreateAlphaIdsClientOptionsWithCorrelationVectorLogs()
        {
            var alphaIdsClientOptions = new AlphaIdsClientOptions();
            alphaIdsClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(alphaIdsClientOptions);
        }
    }
}
