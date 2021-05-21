﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Azure.Communication.Identity.Samples
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
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CreateCommunicationIdentityClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClientAsync

            client = CreateClientWithConnectionString();

            #region  Snippet:CreateCommunicationUserAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region  Snippet:CreateCommunicationTokenAsync
            Response<AccessToken> tokenResponse = await client.GetTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
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
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CreateCommunicationIdentityClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClient
            client = CreateClientWithConnectionString();

            #region  Snippet:CreateCommunicationUser
            Response<CommunicationUserIdentifier> userResponse = client.CreateUser();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationToken

            #region  Snippet:CreateCommunicationToken
            Response<AccessToken> tokenResponse = client.GetToken(user, scopes: new[] { CommunicationTokenScope.Chat });
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
        public async Task CreateUserAndToken()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClientWithConnectionString();
            #region  Snippet:CreateCommunicationUserAndToken
            Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat });
            var (user, token) = response.Value;
            Console.WriteLine($"User id: {user.Id}");
            Console.WriteLine($"Token: {token.Token}");
            #endregion Snippet:CreateCommunicationToken
        }

        [Test]
        public async Task CreateIdentityWithToken()
        {
            #region Snippet:CreateCommunicationIdentityFromToken
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            /*@@*/ endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            TokenCredential tokenCredential = new DefaultAzureCredential();
            var client = new CommunicationIdentityClient(endpoint, tokenCredential);
            #endregion Snippet:CreateCommunicationIdentityFromToken

            client = CreateClientWithTokenCredential();
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
        public async Task CreateIdentityWithAccessKey()
        {
            #region Snippet:CreateCommunicationIdentityFromAccessKey
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            var accessKey = "<access_key>";
            /*@@*/ endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            /*@@*/ accessKey = TestEnvironment.LiveTestDynamicAccessKey;
            var client = new CommunicationIdentityClient(endpoint, new AzureKeyCredential(accessKey));
            #endregion Snippet:CreateCommunicationIdentityFromAccessKey

            client = CreateClientWithAzureKeyCredential();
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
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CommunicationIdentityClient_Troubleshooting
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            /*@@*/ client = CreateClientWithConnectionString();

            try
            {
                Response<CommunicationUserIdentifier> response = await client.CreateUserAsync();
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:CommunicationIdentityClient_Troubleshooting
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
