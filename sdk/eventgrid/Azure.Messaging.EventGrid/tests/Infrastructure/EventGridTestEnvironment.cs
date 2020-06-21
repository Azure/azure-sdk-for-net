// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridTestEnvironment : TestEnvironment
    {
        public EventGridTestEnvironment() : base("eventgrid")
        {
        }

        public const string TopicKeyEnvironmentVariableName = "EVENT_GRID_TOPIC_KEY";
        public const string TopicEndpointEnvironmentVariableName = "EVENT_GRID_TOPIC_ENDPOINT";
        public const string DomainKeyEnvironmentVariableName = "EVENT_GRID_DOMAIN_KEY";
        public const string DomainEndpointEnvironmentVariableName = "EVENT_GRID_DOMAIN_ENDPOINT";

        public static EventGridTestEnvironment Instance { get; } = new EventGridTestEnvironment();
        public string TopicHost => new Uri(GetRecordedVariable(TopicEndpointEnvironmentVariableName)).Host;
        public string TopicKey => GetRecordedVariable(TopicKeyEnvironmentVariableName);
        public string DomainHost => new Uri(GetRecordedVariable(DomainEndpointEnvironmentVariableName)).Host;
        public string DomainKey => GetRecordedVariable(DomainKeyEnvironmentVariableName);
    }
}
