// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Administration.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Azure.Communication.Administration.Samples
{
    /// <summary>
    /// Basic Azure Communication Identity samples.
    /// </summary>
    public partial class Sample1_CommunicationIdentityClient : CommunicationIdentityClientLiveTestBase
    {
        public Sample1_CommunicationIdentityClient(bool isAsync) : base(isAsync)
            => Matcher.IgnoredHeaders.Add("x-ms-content-sha256");

        [Test]
        [AsyncOnly]
        public async Task UserAndTokenLifeCycleAsync()
        {
            var connectionString = TestEnvironment.ConnectionString;
            #region Snippet:CreateCommunicationIdentityClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClientAsync

            client = CreateInstrumentedCommunicationIdentityClient();

            #region  Snippet:CreateCommunicationUserAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region  Snippet:CreateCommunicationTokenAsync
            Response<CommunicationUserToken> tokenResponse = await client.IssueTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region Snippet:RevokeCommunicationUserTokenAsync
            Response revokeResponse = await client.RevokeTokensAsync(
                user,
                //@@ issuedBefore: DateTimeOffset.UtcNow.AddDays(-1) /* optional */);
                /*@@*/ issuedBefore: new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero));
            #endregion Snippet:RevokeCommunicationUserTokenAsync

            #region Snippet:DeleteACommunicationUserAsync
            Response deleteResponse = await client.DeleteUserAsync(user);
            #endregion Snippet:DeleteACommunicationUserAsync
        }

        [Test]
        [SyncOnly]
        public void UserAndTokenLifeCycle()
        {
            var connectionString = TestEnvironment.ConnectionString;
            #region Snippet:CreateCommunicationIdentityClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClient
            client = CreateInstrumentedCommunicationIdentityClient();

            #region  Snippet:CreateCommunicationUser
            Response<CommunicationUserIdentifier> userResponse = client.CreateUser();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationToken

            #region  Snippet:CreateCommunicationToken
            Response<CommunicationUserToken> tokenResponse = client.IssueToken(user, scopes: new[] { CommunicationTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationToken

            #region Snippet:RevokeCommunicationUserToken
            Response revokeResponse = client.RevokeTokens(
                user,
                //@@ issuedBefore: DateTimeOffset.UtcNow.AddDays(-1) /* optional */);
                /*@@*/ issuedBefore: new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero));
            #endregion Snippet:RevokeCommunicationUserToken

            #region Snippet:DeleteACommunicationUser
            Response deleteResponse = client.DeleteUser(user);
            #endregion Snippet:DeleteACommunicationUser
        }

        [Test]
        public async Task CreateIdentityWithToken()
        {
            var endpoint = TestEnvironment.EndpointString;
            #region Snippet:CreateCommunicationIdentityFromToken
            //@@var endpoint = "<endpoint_url>";
            TokenCredential tokenCredential = new DefaultAzureCredential();
            var client = new CommunicationIdentityClient(new Uri(endpoint), tokenCredential);
            #endregion Snippet:CreateCommunicationIdentityFromToken

            tokenCredential = (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential();
            client = CreateInstrumentedCommunicationIdentityClientWithToken(tokenCredential);
            try
            {
                Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task Troubleshooting()
        {
            var connectionString = TestEnvironment.ConnectionString;
            #region Snippet:CommunicationIdentityClient_Troubleshooting
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            /*@@*/ client = CreateInstrumentedCommunicationIdentityClient();

            try
            {
                Response<CommunicationUserIdentifier> response = await client.CreateUserAsync();
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
