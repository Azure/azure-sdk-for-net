// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Security;
using System.Threading;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientLiveTestBase : RecordedTestBase<CommunicationIdentityClientTestEnvironment>
    {
        public CommunicationIdentityClientLiveTestBase(bool isAsync) : base(isAsync)
            => Sanitizer = new CommunicationIdentityClientRecordedTestSanitizer();

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationIdentityClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    new AzureKeyCredential(TestEnvironment.LiveTestDynamicAccessKey),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        protected CommunicationIdentityClient CreateClientWithTokenCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        private CommunicationIdentityClientOptions CreateIdentityClientOptionsWithCorrelationVectorLogs()
        {
            CommunicationIdentityClientOptions communicationIdentityClientOptions = new CommunicationIdentityClientOptions();
            communicationIdentityClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(communicationIdentityClientOptions);
        }

        protected async Task<string> generateTeamsToken()
        {
            string token;
            if (Mode == RecordedTestMode.Playback)
            {
                token = "Sanitized";
            }
            else
            {
                IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder.Create(TestEnvironment.CommunicationM365AppId)
                                                    .WithAuthority(TestEnvironment.CommunicationM365AadAuthority + "/" + TestEnvironment.CommunicationM365AadTenant)
                                                    .WithRedirectUri(TestEnvironment.CommunicationM365RedirectUri)
                                                    .Build();
                string[] scopes = { TestEnvironment.CommunicationM365Scope };
                SecureString communicationMsalPassword = new SecureString();
                foreach (char c in TestEnvironment.CommunicationMsalPassword)
                {
                    communicationMsalPassword.AppendChar(c);
                }
                AuthenticationResult result = await publicClientApplication.AcquireTokenByUsernamePassword(
                    scopes,
                    TestEnvironment.CommunicationMsalUsername,
                    communicationMsalPassword).ExecuteAsync(CancellationToken.None).ConfigureAwait(false);
                token = result.AccessToken;
            }
            return token;
        }
    }
}
