// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Administration.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Azure.Communication.Administration.Samples
{
    /// <summary>
    /// Basic Azure Communication Identity samples.
    /// </summary>
    public partial class Sample1_CommunicationIdentityClient : CommunicationIdentityClientLiveTestBase
    {
        public Sample1_CommunicationIdentityClient(bool isAsync): base(isAsync)
            => Matcher.ExcludeHeaders.Add("x-ms-content-sha256");

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
            Response<CommunicationUser> userResponse = await client.CreateUserAsync();
            CommunicationUser user = userResponse.Value;
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
            Response<CommunicationUser> userResponse = client.CreateUser();
            CommunicationUser user = userResponse.Value;
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
                Response<CommunicationUser> response = await client.CreateUserAsync();
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
