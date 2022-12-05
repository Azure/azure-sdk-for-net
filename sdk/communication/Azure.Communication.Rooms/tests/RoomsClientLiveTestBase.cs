// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Communication.Identity;
using System.Threading.Tasks;
using static Azure.Communication.Rooms.RoomsClientOptions;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientLiveTestBase : RecordedTestBase<RoomsClientTestEnvironment>
    {
        private const string DateTimeStampRegEx = @"[0-9]*-[0-9]*-[0-9]*T[0-9]*:[0-9]*:[0-9]*.[0-9]*Z";
        private const string URIDomainNameReplacerRegEx = @"https://([^/?]+)";
        private const string URIIdentityReplacerRegEx = @"/identities/([^/?]+)";
        private const string URIRoomsIdReplacerRegEx = @"/rooms/\d*";
        private const string RequestBodyIdReplacerRegex = @"8:acs:[a-zA-Z0-9-_]*";

        public RoomsClientLiveTestBase(bool isAsync) : base(isAsync)
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            IgnoredHeaders.Add("Repeatability-Request-ID");
            IgnoredHeaders.Add("Repeatability-First-Sent");
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..appId");
            JsonPathSanitizers.Add("$..userId");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(DateTimeStampRegEx, SanitizeValue));
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(RequestBodyIdReplacerRegex, SanitizeValue));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIIdentityReplacerRegEx, "/identities/Sanitized"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainNameReplacerRegEx, "https://sanitized.communication.azure.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIRoomsIdReplacerRegEx, "/rooms/Sanitized"));
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
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        private RoomsClientOptions CreateRoomsClientOptionsWithCorrelationVectorLogs(ServiceVersion version)
        {
            RoomsClientOptions roomsClientOptions = new RoomsClientOptions(version);
            roomsClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(roomsClientOptions);
        }
    }
}
