// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;

namespace Azure.Communication.Email.Tests
{
    internal class EmailClientLiveTestBase : RecordedTestBase<EmailClientTestEnvironment>
    {
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string URIRoomsIdReplacerRegEx = @"emails/operations/.*?api";

        public EmailClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            SanitizedHeaders.Add("Operation-Id");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIRoomsIdReplacerRegEx, "emails/operations/sanitizedId?api"));
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Operation-Location", "https://sanitized.communication.azure.com/emails/operations/sanitizedId?api-version=2023-01-15-preview"));
        }

        protected EmailClient CreateEmailClient()
        {
            #region Snippet:Azure_Communication_Email_CreateEmailClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@EmailClient client = new EmailClient(connectionString);
            #endregion Snippet:Azure_Communication_Email_CreateEmailClient

            var connectionString = TestEnvironment.CommunicationConnectionStringEmail;
            var client = new EmailClient(connectionString, CreateEmailClientOptionsWithCorrelationVectorLogs());

            return InstrumentClient(client);
        }

        public EmailClient CreateSmsClientWithToken()
        {
            Uri endpoint = TestEnvironment.CommunicationEmailEndpoint;
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                #region Snippet:Azure_Communication_Email_CreateEmailClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ TokenCredential tokenCredential = new DefaultAzureCredential();
                /*@@*/
                tokenCredential = new DefaultAzureCredential();
                //@@ EmailClient client = new EmailClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_Email_CreateEmailClientWithToken
            }

            EmailClient client = new EmailClient(endpoint, tokenCredential, CreateEmailClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(client);
        }

        protected EmailClientOptions CreateEmailClientOptionsWithCorrelationVectorLogs()
        {
            var emailClientOptions = new EmailClientOptions();
            emailClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(emailClientOptions);
        }
    }
}
