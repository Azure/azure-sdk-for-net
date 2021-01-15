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

            client = CreateClientWithConnectionString();

            #region  Snippet:CreateCommunicationUserAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync(scopes: new[] { CommunicationIdentityTokenScope.Chat });
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region  Snippet:CreateCommunicationTokenAsync
            Response<CommunicationIdentityAccessToken> tokenResponse = await client.IssueTokenAsync(user, scopes: new[] { CommunicationIdentityTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region Snippet:RevokeCommunicationUserTokenAsync
            Response revokeResponse = await client.RevokeTokensAsync(user);
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
            client = CreateClientWithConnectionString();

            #region  Snippet:CreateCommunicationUser
            Response<CommunicationUserIdentifier> userResponse = client.CreateUser(new[] { CommunicationIdentityTokenScope.Chat });
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationToken

            #region  Snippet:CreateCommunicationToken
            Response<CommunicationIdentityAccessToken> tokenResponse = client.IssueToken(user, scopes: new[] { CommunicationIdentityTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationToken

            #region Snippet:RevokeCommunicationUserToken
            Response revokeResponse = client.RevokeTokens(user);
            #endregion Snippet:RevokeCommunicationUserToken

            #region Snippet:DeleteACommunicationUser
            Response deleteResponse = client.DeleteUser(user);
            #endregion Snippet:DeleteACommunicationUser
        }

        [Test]
        public async Task CreateIdentityWithToken()
        {
            #region Snippet:CreateCommunicationIdentityFromToken
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            /*@@*/ endpoint = TestEnvironment.Endpoint;
            TokenCredential tokenCredential = new DefaultAzureCredential();
            var client = new CommunicationIdentityClient(endpoint, tokenCredential);
            #endregion Snippet:CreateCommunicationIdentityFromToken

            client = CreateClientWithTokenCredential();
            try
            {
                Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync(scopes: new[] { CommunicationIdentityTokenScope.Chat });
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
            /*@@*/ client = CreateClientWithConnectionString();

            try
            {
                Response<CommunicationUserIdentifier> response = await client.CreateUserAsync(scopes: new[] { CommunicationIdentityTokenScope.Chat });
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
