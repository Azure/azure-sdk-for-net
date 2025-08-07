// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity.Models;
using Azure.Communication.Identity.Tests;
using Azure.Communication.Tests;
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
            => IgnoredHeaders.Add("x-ms-content-sha256");

        [Test]
        [AsyncOnly]
        public async Task UserAndCustomExpirationTokenLifecycleAsync()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CreateCommunicationIdentityClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClientAsync

            client = CreateClient();

            #region  Snippet:CreateCommunicationUserAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationTokenAsync

            #region Snippet:CreateCommunicationTokenAsyncWithCustomExpiration
            TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
            Response<AccessToken> tokenResponse = await client.GetTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationTokenAsyncWithCustomExpiration

            #region Snippet:RevokeCommunicationUserTokenAsync
            Response revokeResponse = await client.RevokeTokensAsync(user);
            #endregion Snippet:RevokeCommunicationUserTokenAsync

            #region Snippet:DeleteACommunicationUserAsync
            Response deleteResponse = await client.DeleteUserAsync(user);
            #endregion Snippet:DeleteACommunicationUserAsync
        }

        [Test]
        [AsyncOnly]
        public async Task UserAndTokenLifeCycleAsync()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);

            client = CreateClient();

            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");

            #region  Snippet:CreateCommunicationTokenAsync
            Response<AccessToken> tokenResponse = await client.GetTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationTokenAsync

            Response revokeResponse = await client.RevokeTokensAsync(user);
            Response deleteResponse = await client.DeleteUserAsync(user);
        }

        [Test]
        [SyncOnly]
        public void UserAndCustomExpirationTokenLifeCycle()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CreateCommunicationIdentityClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClient
            client = CreateClient();

            #region  Snippet:CreateCommunicationUser
            Response<CommunicationUserIdentifier> userResponse = client.CreateUser();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationToken

            #region  Snippet:CreateCommunicationTokenWithCustomExpiration
            TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
            Response<AccessToken> tokenResponse = client.GetToken(user, scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationTokenWithCustomExpiration
        }

        [Test]
        [SyncOnly]
        public void UserAndTokenLifeCycle()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();

            Response<CommunicationUserIdentifier> userResponse = client.CreateUser();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");

            #region  Snippet:CreateCommunicationToken
            Response<AccessToken> tokenResponse = client.GetToken(user, scopes: new[] { CommunicationTokenScope.Chat });
            string token = tokenResponse.Value.Token;
            DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"Token: {token}");
            Console.WriteLine($"Expires On: {expiresOn}");
            #endregion Snippet:CreateCommunicationToken

            Response revokeResponse = client.RevokeTokens(user);
            Response deleteResponse = client.DeleteUser(user);
        }

        [Test]
        public async Task CreateUserAndTokenWithCustomExpirationAsync()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region Snippet:CreateCommunicationUserAndTokenWithCustomExpirationAsync
            TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
            Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
            var (user, token) = response.Value;
            Console.WriteLine($"User id: {user.Id}");
            Console.WriteLine($"Token: {token.Token}");
            #endregion Snippet:CreateCommunicationUserAndTokenWithCustomExpirationAsync
        }

        [Test]
        [SyncOnly]
        public void CreateUserAndTokenWithCustomExpiration()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region Snippet:CreateCommunicationUserAndTokenWithCustomExpiration
            TimeSpan tokenExpiresIn = TimeSpan.FromHours(1);
            Response<CommunicationUserIdentifierAndToken> response = client.CreateUserAndToken(customId: "alice@contoso.com", scopes: new[] { CommunicationTokenScope.Chat }, tokenExpiresIn);
            var (user, token) = response.Value;
            Console.WriteLine($"User id: {user.Id}");
            Console.WriteLine($"Token: {token.Token}");
            #endregion Snippet:CreateCommunicationUserAndTokenWithCustomExpiration
        }

        [Test]
        public async Task CreateUserAndToken()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region  Snippet:CreateCommunicationUserAndToken
            Response<CommunicationUserIdentifierAndToken> response = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.Chat });
            var (user, token) = response.Value;
            Console.WriteLine($"User id: {user.Id}");
            Console.WriteLine($"Token: {token.Token}");
            #endregion Snippet:CreateCommunicationToken
        }

        [Test]
        [SyncOnly]
        public void CreateCommunicationUserWithCustomId()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region  Snippet:CreateCommunicationUserWithCustomId
            Response<CommunicationUserIdentifier> userResponse = client.CreateUser(customId: "alice@contoso.com");
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationUserWithCustomId
        }

        [Test]
        [AsyncOnly]
        public async Task CreateCommunicationUserWithCustomlIdAsync()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region  Snippet:CreateCommunicationUserWithCustomIdAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync(customId: "alice@contoso.com");
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationUserWithCustomIdAsync
        }

        [Test]
        [SyncOnly]
        public async Task GetUserDetail()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region  Snippet:GetUserDetail
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync(customId: "alice@contoso.com");
            CommunicationUserIdentifier user = userResponse.Value;
            var userDetails = client.GetUserDetail(user);
            Console.WriteLine($"User id: {userDetails.Value.User.Id}");
            Console.WriteLine($"Custom id: {userDetails.Value.CustomId}");
            Console.WriteLine($"Last token issued at: {userDetails.Value.LastTokenIssuedAt}");
            #endregion Snippet:GetUserDetail
        }

        [Test]
        [AsyncOnly]
        public async Task GetUserDetailAsync()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            var client = new CommunicationIdentityClient(connectionString);
            client = CreateClient();
            #region  Snippet:GetUserDetailAsync
            Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync(customId: "alice@contoso.com");
            CommunicationUserIdentifier user = userResponse.Value;
            var userDetails = await client.GetUserDetailAsync(user);
            Console.WriteLine($"User id: {userDetails.Value.User.Id}");
            Console.WriteLine($"Custom id: {userDetails.Value.CustomId}");
            Console.WriteLine($"Last token issued at: {userDetails.Value.LastTokenIssuedAt}");
            #endregion Snippet:GetUserDetailAsync
        }

        [Test]
        public async Task CreateIdentityWithToken()
        {
            #region Snippet:CreateCommunicationIdentityFromToken
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            /*@@*/ endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            TokenCredential tokenCredential = TestEnvironment.Credential;
            var client = new CommunicationIdentityClient(endpoint, tokenCredential);
            #endregion Snippet:CreateCommunicationIdentityFromToken

            client = CreateClient(AuthMethod.TokenCredential);
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

            client = CreateClient(AuthMethod.KeyCredential);
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
        [SyncOnly]
        public void GetTokenForTeamsUser()
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            var options = CreateTeamsUserParams().Result;
            var teamsUserAadToken = options.TeamsUserAadToken;
            var clientId = options.ClientId;
            var userObjectId = options.UserObjectId;

            var client = CreateClient();

            #region Snippet:GetTokenForTeamsUser
            Response<AccessToken> tokenResponse = client.GetTokenForTeamsUser(new GetTokenForTeamsUserOptions(teamsUserAadToken, clientId, userObjectId));
            string token = tokenResponse.Value.Token;
            Console.WriteLine($"Token: {token}");
            #endregion Snippet:GetTokenForTeamsUser
        }

        [Test]
        [AsyncOnly]
        public async Task GetTokenForTeamsUserAsync()
        {
            if (TestEnvironment.ShouldIgnoreIdentityExchangeTokenTest)
            {
                Assert.Pass("Ignore exchange teams token test if flag is enabled.");
            }

            var options = await CreateTeamsUserParams();
            var teamsUserAadToken = options.TeamsUserAadToken;
            var clientId = options.ClientId;
            var userObjectId = options.UserObjectId;

            var client = CreateClient();

            #region Snippet:GetTokenForTeamsUserAsync
            Response<AccessToken> tokenResponse = await client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(teamsUserAadToken, clientId, userObjectId));
            string token = tokenResponse.Value.Token;
            Console.WriteLine($"Token: {token}");
            #endregion Snippet:GetTokenForTeamsUserAsync
        }

        [Test]
        public async Task Troubleshooting()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;
            #region Snippet:CommunicationIdentityClient_Troubleshooting
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationIdentityClient(connectionString);
            /*@@*/ client = CreateClient();

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
