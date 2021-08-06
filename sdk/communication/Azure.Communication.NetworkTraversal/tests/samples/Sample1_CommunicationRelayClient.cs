﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Communication.NetworkTraversal.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;

            var communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUserIdentifier> response = await communicationIdentityClient.CreateUserAsync();
            var user = response.Value;

            #region Snippet:CreateCommunicationRelayClientAsync
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationRelayClient(connectionString);
            #endregion Snippet:CreateCommunicationRelayClientAsync
            client = CreateClientWithConnectionString();

            #region Snippet:GetRelayConfigurationAsync
            Response<CommunicationRelayConfiguration> relayConfiguration = await client.GetRelayConfigurationAsync(user);
            DateTimeOffset turnTokenExpiresOn = relayConfiguration.Value.ExpiresOn;
            IReadOnlyList<CommunicationIceServer> iceServers = relayConfiguration.Value.IceServers;
            Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
            foreach (CommunicationIceServer iceServer in iceServers)
            {
                foreach (string url in iceServer.Urls)
                {
                    Console.WriteLine($"ICE Server Url: {url}");
                }
                Console.WriteLine($"ICE Server Username: {iceServer.Username}");
                Console.WriteLine($"ICE Server Credential: {iceServer.Credential}");
            }
            #endregion Snippet:GetRelayConfigurationAsync
        }

        [Test]
        [SyncOnly]
        public void GetRelayConfiguration()
        {
            var connectionString = TestEnvironment.LiveTestDynamicConnectionString;

            var communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUserIdentifier> response = communicationIdentityClient.CreateUser();
            var user = response.Value;

            #region Snippet:CreateCommunicationRelayClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new CommunicationRelayClient(connectionString);
            #endregion Snippet:CreateCommunicationRelayClient
            client = CreateClientWithConnectionString();

            #region Snippet:GetRelayConfiguration
            Response<CommunicationRelayConfiguration> relayConfiguration = client.GetRelayConfiguration(user);
            DateTimeOffset turnTokenExpiresOn = relayConfiguration.Value.ExpiresOn;
            IReadOnlyList<CommunicationIceServer> iceServers = relayConfiguration.Value.IceServers;
            Console.WriteLine($"Expires On: {turnTokenExpiresOn}");
            foreach (CommunicationIceServer iceServer in iceServers)
            {
                foreach (string url in iceServer.Urls)
                {
                    Console.WriteLine($"ICE Server Url: {url}");
                }
                Console.WriteLine($"ICE Server Username: {iceServer.Username}");
                Console.WriteLine($"ICE Server Credential: {iceServer.Credential}");
            }
            #endregion Snippet:GetRelayConfiguration
        }

        [Test]
        public async Task CreateCommunicationRelayWithToken()
        {
            #region Snippet:CreateCommunicationRelayFromToken
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            /*@@*/ endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            TokenCredential tokenCredential = new DefaultAzureCredential();
            var client = new CommunicationRelayClient(endpoint, tokenCredential);
            #endregion Snippet:CreateCommunicationRelayFromToken

            var communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUserIdentifier> response = await communicationIdentityClient.CreateUserAsync();
            var user = response.Value;

            client = CreateClientWithTokenCredential();
            try
            {
                Response<CommunicationRelayConfiguration> relayConfigurationResponse = await client.GetRelayConfigurationAsync(user);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CreateCommunicationRelayWithAccessKey()
        {
            #region Snippet:CreateCommunicationRelayFromAccessKey
            var endpoint = new Uri("https://my-resource.communication.azure.com");
            var accessKey = "<access_key>";
            /*@@*/ endpoint = TestEnvironment.LiveTestDynamicEndpoint;
            /*@@*/ accessKey = TestEnvironment.LiveTestDynamicAccessKey;
            var client = new CommunicationRelayClient(endpoint, new AzureKeyCredential(accessKey));
            #endregion Snippet:CreateCommunicationRelayFromAccessKey

            var communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            Response<CommunicationUserIdentifier> response = await communicationIdentityClient.CreateUserAsync();
            var user = response.Value;

            client = CreateClientWithAzureKeyCredential();
            try
            {
                Response<CommunicationRelayConfiguration> relayConfigurationResponse = await client.GetRelayConfigurationAsync(user);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
