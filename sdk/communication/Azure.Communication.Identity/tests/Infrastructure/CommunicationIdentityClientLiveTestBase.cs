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
using static Azure.Communication.Identity.CommunicationIdentityClientOptions;
using NUnit.Framework.Constraints;

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
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIIdentityReplacerRegEx) { Value = "/identities/Sanitized" });
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx) { Value = "https://sanitized.communication.azure.com" });
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        private CommunicationIdentityClient CreateClientWithConnectionString(ServiceVersion? version)
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicConnectionString,
                    CreateIdentityClientOptionsWithCorrelationVectorLogs(version)));

        private CommunicationIdentityClient CreateClientWithAzureKeyCredential(ServiceVersion? version)
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    new AzureKeyCredential(TestEnvironment.LiveTestDynamicAccessKey),
                    CreateIdentityClientOptionsWithCorrelationVectorLogs(version)));

        private CommunicationIdentityClient CreateClientWithTokenCredential(ServiceVersion? version)
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestDynamicEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : TestEnvironment.Credential,
                    CreateIdentityClientOptionsWithCorrelationVectorLogs(version)));

        private CommunicationIdentityClientOptions CreateIdentityClientOptionsWithCorrelationVectorLogs(ServiceVersion? version)
        {
            CommunicationIdentityClientOptions communicationIdentityClientOptions = (version == null) ? new CommunicationIdentityClientOptions()
                : new CommunicationIdentityClientOptions((ServiceVersion)version);
            communicationIdentityClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(communicationIdentityClientOptions);
        }

        protected CommunicationIdentityClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString, ServiceVersion? version = default)
            => authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(version),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(version),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(version),
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

#pragma warning disable CS0618 // Suppress obsolete warning for test-only usage
                AuthenticationResult result = await publicClientApplication.AcquireTokenByUsernamePassword(
                    scopes,
                    TestEnvironment.CommunicationMsalUsername,
                    TestEnvironment.CommunicationMsalPassword).ExecuteAsync(CancellationToken.None).ConfigureAwait(false);
#pragma warning restore CS0618
                options = new GetTokenForTeamsUserOptions(result.AccessToken, TestEnvironment.CommunicationM365AppId, result.UniqueId);
            }
            return options;
        }
    }
}
