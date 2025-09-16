// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;

namespace Azure.Communication.Rooms.Tests
{
    public class RoomsClientTestEnvironment : CommunicationTestEnvironment
    {
        public const string CommunicationConnectionStringRoomsVariableName = "COMMUNICATION_CONNECTION_STRING_ROOMS";
        private const string TrafficManagerUrl = "https://flighting-api.scheduler.teams.microsoft.com";

        public string CommunicationConnectionStringRooms => GetRecordedVariable(
            CommunicationConnectionStringRoomsVariableName,
            options => options.HasSecretConnectionStringParameter("accessKey", SanitizedValue.Base64));

        public Uri CommunicationRoomsEndpoint => new(Core.ConnectionString.Parse(CommunicationConnectionStringRooms).GetRequired("endpoint"));

        public string CommunicationRoomsAccessKey => Core.ConnectionString.Parse(CommunicationConnectionStringRooms).GetRequired("accesskey");

        public Uri CommunicationRoomsTrafficManagerUrl => new(TrafficManagerUrl);
    }
}
