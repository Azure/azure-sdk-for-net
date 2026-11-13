// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientLiveTestBase : RecordedTestBase<SmsClientTestEnvironment>
    {
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        public SmsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..from");
            JsonPathSanitizers.Add("$..to");
            JsonPathSanitizers.Add("$..repeatabilityRequestId");
            JsonPathSanitizers.Add("$..repeatabilityFirstSent");
            SanitizedHeaders.Add("x-ms-content-sha256");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx) { Value = "https://sanitized.communication.azure.com" });
        }

        [OneTimeSetUp]
        public void Setup()
        {
            if (TestEnvironment.ShouldIgnoreSMSTests)
            {
                Assert.Ignore("SMS tests are skipped " +
                    "because sms package is not included in the TEST_PACKAGES_ENABLED variable");
            }
        }

        public SmsClient CreateSmsClient()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            SmsClient client = new SmsClient(connectionString, CreateSmsClientOptionsWithCorrelationVectorLogs());

            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@SmsClient client = new SmsClient(connectionString);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            return InstrumentClient(client);
        }

        public SmsClient CreateSmsClientWithNullOptions()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            SmsClient client = new SmsClient(connectionString, null);

            return InstrumentClient(client);
        }

        public SmsClient CreateSmsClientWithoutOptions()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;
            SmsClient client = new SmsClient(connectionString);

            return InstrumentClient(client);
        }

        public SmsClient CreateSmsClientWithToken()
        {
            Uri endpoint = TestEnvironment.LiveTestStaticEndpoint;
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                /*@@*/
                tokenCredential = TestEnvironment.Credential;
                //@@ SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
            }
            SmsClient client = new SmsClient(endpoint, tokenCredential, CreateSmsClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(client);
        }

        private SmsClientOptions CreateSmsClientOptionsWithCorrelationVectorLogs()
        {
            SmsClientOptions smsClientOptions = new SmsClientOptions();
            smsClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(smsClientOptions);
        }
    }
}
