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
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx) { Value = "https://sanitized.communication.azure.com" });
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIRoomsIdReplacerRegEx) { Value = "emails/operations/sanitizedId?api" });
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Operation-Location") { Value = "https://sanitized.communication.azure.com/emails/operations/sanitizedId?api-version=2023-03-31" });
        }

        protected EmailClient CreateEmailClient()
        {
            #region Snippet:Azure_Communication_Email_CreateEmailClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@EmailClient emailClient = new EmailClient(connectionString);
            #endregion Snippet:Azure_Communication_Email_CreateEmailClient

            var connectionString = TestEnvironment.CommunicationConnectionStringEmail;
            var emailClient = new EmailClient(connectionString, CreateEmailClientOptionsWithCorrelationVectorLogs());

            return InstrumentClient(emailClient);
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
                tokenCredential = new DefaultAzureCredential();
                #region Snippet:Azure_Communication_Email_CreateEmailClientWithToken
                //@@ string endpoint = "<endpoint_url>";
                //@@ var tokenCredential = new DefaultAzureCredential();
                //@@ EmailClient emailClient = new EmailClient(new Uri(endpoint), tokenCredential);
                #endregion Snippet:Azure_Communication_Email_CreateEmailClientWithToken
            }

            EmailClient emailClient = new EmailClient(endpoint, tokenCredential, CreateEmailClientOptionsWithCorrelationVectorLogs());
            return InstrumentClient(emailClient);
        }

        protected EmailClientOptions CreateEmailClientOptionsWithCorrelationVectorLogs()
        {
            var emailClientOptions = new EmailClientOptions();
            emailClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(emailClientOptions);
        }
    }
}
