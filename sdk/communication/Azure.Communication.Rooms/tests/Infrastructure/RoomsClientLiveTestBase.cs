// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Communication.Identity;
using static Azure.Communication.Rooms.RoomsClientOptions;
using Azure.Core.TestFramework.Models;
using Azure.Communication.Tests;
using Azure.Identity;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTestBase : RecordedTestBase<RoomsClientTestEnvironment>
    {
        private const string DateTimeStampRegEx = @"[0-9]*-[0-9]*-[0-9]*T[0-9]*:[0-9]*:[0-9]*.[0-9]*Z";
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string URIIdentityReplacerRegEx = @"/identities/([^/?]+)";
        private const string URIRoomsIdReplacerRegEx = @"/rooms/\d*";

        public RoomsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            IgnoredHeaders.Add("Repeatability-Request-ID");
            IgnoredHeaders.Add("Repeatability-First-Sent");
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..appId");
            JsonPathSanitizers.Add("$..userId");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(DateTimeStampRegEx, SanitizeValue));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIIdentityReplacerRegEx, "/identities/Sanitized"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIRoomsIdReplacerRegEx, "/rooms/Sanitized"));
        }

        /// <summary>
        /// Creates a <see cref="RoomsClient" /> based on provided authMethod
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="RoomsClient" />.</returns>
        protected RoomsClient CreateClient(AuthMethod authMethod = AuthMethod.ConnectionString, bool isInstrumented = true, ServiceVersion apiVersion = ServiceVersion.V2023_10_30_Preview)
        {
            return authMethod switch
            {
                AuthMethod.ConnectionString => CreateClientWithConnectionString(isInstrumented, apiVersion),
                AuthMethod.KeyCredential => CreateClientWithAzureKeyCredential(isInstrumented, apiVersion),
                AuthMethod.TokenCredential => CreateClientWithTokenCredential(isInstrumented, apiVersion),
                _ => throw new ArgumentOutOfRangeException(nameof(authMethod))
            };
        }

        /// <summary>
        /// Creates a <see cref="RoomsClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="RoomsClient" />.</returns>
        protected RoomsClient CreateClientWithConnectionString(bool isInstrumented = true, ServiceVersion apiVersion = ServiceVersion.V2023_10_30_Preview)
        {
            var client = new RoomsClient(
                    TestEnvironment.CommunicationConnectionStringRooms,
                    CreateRoomsClientOptionsWithCorrelationVectorLogs(apiVersion));

            // We always create the instrumented client to suppress the instrumentation check
            var instrumentedClient = InstrumentClient(client);
            return isInstrumented ? instrumentedClient : client;
        }

        /// <summary>
        /// Creates a <see cref="RoomsClient" /> with the azure key credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="RoomsClient" />.</returns>
        protected RoomsClient CreateClientWithAzureKeyCredential(bool isInstrumented = true, ServiceVersion apiVersion = ServiceVersion.V2023_10_30_Preview)
        {
            var client = new RoomsClient(
                    TestEnvironment.CommunicationRoomsEndpoint,
                     new AzureKeyCredential(TestEnvironment.CommunicationRoomsAccessKey),
                    CreateRoomsClientOptionsWithCorrelationVectorLogs(apiVersion));

            return isInstrumented ? InstrumentClient(client) : client;
        }

        /// <summary>
        /// Creates a <see cref="RoomsClient" /> with the token credential
        /// and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="RoomsClient" />.</returns>
        protected RoomsClient CreateClientWithTokenCredential(bool isInstrumented = true, ServiceVersion apiVersion = ServiceVersion.V2023_10_30_Preview)
        {
            var client = new RoomsClient(
                    TestEnvironment.CommunicationRoomsEndpoint,
                    (Mode == RecordedTestMode.Playback) ? new MockCredential() : new DefaultAzureCredential(),
                    CreateRoomsClientOptionsWithCorrelationVectorLogs(apiVersion));

            return isInstrumented ? InstrumentClient(client) : client;
        }

        protected RoomsClient CreateInstrumentedRoomsClient(ServiceVersion version)
        {
            var connectionString = TestEnvironment.CommunicationConnectionStringRooms;
            RoomsClient client = new RoomsClient(connectionString, CreateRoomsClientOptionsWithCorrelationVectorLogs(version));

            #region Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient
            //@@var connectionString = Environment.GetEnvironmentVariable("connection_string") // Find your Communication Services resource in the Azure portal
            //@@RoomsClient client = new RoomsClient(connectionString);
            #endregion Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient

            return InstrumentClient(client);
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.CommunicationConnectionStringRooms,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01))));

        private RoomsClientOptions CreateRoomsClientOptionsWithCorrelationVectorLogs(ServiceVersion version)
        {
            RoomsClientOptions roomsClientOptions = new RoomsClientOptions(version);
            roomsClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(roomsClientOptions);
        }
    }
}
