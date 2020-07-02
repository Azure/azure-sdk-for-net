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

        public const string CldEvntTopicKeyEnvironmentVariableName = "EVENT_GRID_CLOUD_EVENT_TOPIC_KEY";
        public const string CldEvntTopicEndpointEnvironmentVariableName = "EVENT_GRID_CLOUD_EVENT_TOPIC_ENDPOINT";

        public const string CstEvntTopicKeyEnvironmentVariableName = "EVENT_GRID_CUSTOM_EVENT_TOPIC_KEY";
        public const string CstEvntTopicEndpointEnvironmentVariableName = "EVENT_GRID_CUSTOM_EVENT_TOPIC_ENDPOINT";


        public string TopicHost => GetRecordedVariable(TopicEndpointEnvironmentVariableName);
        public string TopicKey => GetRecordedVariable(TopicKeyEnvironmentVariableName);

        public string DomainHost => GetRecordedVariable(DomainEndpointEnvironmentVariableName);
        public string DomainKey => GetRecordedVariable(DomainKeyEnvironmentVariableName);

        public string CloudEventTopicHost => GetRecordedVariable(CldEvntTopicEndpointEnvironmentVariableName);
        public string CloudEventTopicKey => GetRecordedVariable(CldEvntTopicKeyEnvironmentVariableName);

        public string CustomEventTopicHost => GetRecordedVariable(CstEvntTopicEndpointEnvironmentVariableName);
        public string CustomEventTopicKey => GetRecordedVariable(CstEvntTopicKeyEnvironmentVariableName);
    }
}
