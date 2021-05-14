// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication.NetworkTraversal.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace Azure.Communication.NetworkTraversal.Samples
{
    /// <summary>
    /// Basic Azure Communication.NetworkTraversal samples.
    /// </summary>
    public partial class Sample1_CommunicationRelayClient : CommunicationRelayClientLiveTestBase
    {
        public Sample1_CommunicationRelayClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task GetRelayConfigurationAsync()
        {
            var connectionString = TestEnvironment.ConnectionString;
            #region Snippet:CreateCommunicationIdentityClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var communicationIdentityClient = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClient

            #region Snippet:CreateCommunicationRelayClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationRelayClient(connectionString);
            #endregion Snippet:CreateCommunicationRelayClientAsync

            #region Snippet:CreateCommunicationUserAsync
            Response<CommunicationUserIdentifier> userResponse = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationUserAsync

            #region Snippet:CreateTURNTokenAsync
            Response<CommunicationRelayConfiguration> turnTokenResponse = await client.GetRelayConfigurationAsync(user);
            DateTimeOffset turnTokenExpiresOn = turnTokenResponse.Value.ExpiresOn;
            IReadOnlyList<CommunicationTurnServer> turnServers = turnTokenResponse.Value.TurnServers;
            Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
            foreach (CommunicationTurnServer turnServer in turnServers)
            {
                foreach (string url in turnServer.Urls)
                {
                    Console.WriteLine($"TURN Url: {url}");
                }
                Console.WriteLine($"TURN Username: {turnServer.Username}");
                Console.WriteLine($"TURN Credential: {turnServer.Credential}");
            }
            #endregion Snippet:CreateTURNTokenAsync                                                                       1~
        }

        [Test]
        [SyncOnly]
        public void GetRelayConfiguration()
        {
            var connectionString = TestEnvironment.ConnectionString;
            #region Snippet:CreateCommunicationIdentityClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var communicationIdentityClient = new CommunicationIdentityClient(connectionString);
            #endregion Snippet:CreateCommunicationIdentityClient

            #region Snippet:CreateCommunicationRelayClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationRelayClient(connectionString);
            #endregion Snippet:CreateCommunicationRelayClientAsync

            #region Snippet:CreateCommunicationUser
            Response<CommunicationUserIdentifier> userResponse = communicationIdentityClient.CreateUser();
            CommunicationUserIdentifier user = userResponse.Value;
            Console.WriteLine($"User id: {user.Id}");
            #endregion Snippet:CreateCommunicationUser

            #region Snippet:CreateTURNToken
            Response<CommunicationRelayConfiguration> turnTokenResponse = client.GetRelayConfiguration(user);
            DateTimeOffset turnTokenExpiresOn = turnTokenResponse.Value.ExpiresOn;
            IReadOnlyList<CommunicationTurnServer> turnServers = turnTokenResponse.Value.TurnServers;
            Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
            foreach (CommunicationTurnServer turnServer in turnServers)
            {
                foreach (string url in turnServer.Urls)
                {
                    Console.WriteLine($"TURN Url: {url}");
                }
                Console.WriteLine($"TURN Username: {turnServer.Username}");
                Console.WriteLine($"TURN Credential: {turnServer.Credential}");
            }
            #endregion Snippet:CreateTURNToken
        }
    }
}
