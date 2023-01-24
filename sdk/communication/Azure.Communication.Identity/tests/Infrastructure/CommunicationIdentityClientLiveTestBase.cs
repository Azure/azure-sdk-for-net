// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Identity;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Security;
using System.Threading;
using Azure.Core.TestFramework.Models;
using System;
using Azure.Communication.Tests;

namespace Azure.Communication.Identity.Tests
{
    public class CommunicationIdentityClientLiveTestBase : RecordedTestBase<CommunicationIdentityClientTestEnvironment>
    {
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string URIIdentityReplacerRegEx = @"/identities/([^/?]+)";

        public CommunicationIdentityClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..appId");
            JsonPathSanitizers.Add("$..userId");
            JsonPathSanitizers.Add("$..id");
            SanitizedHeaders.Add("x-ms-content-sha256");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIIdentityReplacerRegEx, "/identities/Sanitized"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        private CommunicationIdentityClient CreateClientWithConnectionString()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        private CommunicationIdentityClient CreateClientWithAzureKeyCredential()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    new AzureKeyCredential(TestEnvironment.LiveTestDynamicAccessKey),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs()));

        private CommunicationIdentityClient CreateClientWithTokenCredential()
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

        protected CommunicationIdentityClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString)
            => authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod)),
            };

        protected async Task<GetTokenForTeamsUserOptions> CreateTeamsUserParams()
        {
            GetTokenForTeamsUserOptions options = new GetTokenForTeamsUserOptions("Sanitized", "Sanitized", "Sanitized");
            if (!TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest && Mode != RecordedTestMode.Playback)
            {
                IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder.Create(TestEnvironment.CommunicationM365AppId)
                                                    .WithAuthority(TestEnvironment.CommunicationM365AadAuthority + "/" + TestEnvironment.CommunicationM365AadTenant)
                                                    .WithRedirectUri(TestEnvironment.CommunicationM365RedirectUri)
                                                    .Build();
                string[] scopes = {
                    "https://auth.msft.communication.azure.com/Teams.ManageCalls",
                    "https://auth.msft.communication.azure.com/Teams.ManageChats"
                };

                AuthenticationResult result = await publicClientApplication.AcquireTokenByUsernamePassword(
                    scopes,
                    TestEnvironment.CommunicationMsalUsername,
                    TestEnvironment.CommunicationMsalPassword).ExecuteAsync(CancellationToken.None).ConfigureAwait(false);
                options = new GetTokenForTeamsUserOptions(result.AccessToken, TestEnvironment.CommunicationM365AppId, result.UniqueId);
            }
            return options;
        }
    }
}
