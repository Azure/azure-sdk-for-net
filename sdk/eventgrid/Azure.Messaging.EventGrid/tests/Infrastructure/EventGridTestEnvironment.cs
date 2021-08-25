// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridTestEnvironment : TestEnvironment
    {
        public const string TopicKeyEnvironmentVariableName = "EVENT_GRID_TOPIC_KEY";
        public const string TopicEndpointEnvironmentVariableName = "EVENT_GRID_TOPIC_ENDPOINT";

        public const string DomainKeyEnvironmentVariableName = "EVENT_GRID_DOMAIN_KEY";
        public const string DomainEndpointEnvironmentVariableName = "EVENT_GRID_DOMAIN_ENDPOINT";

        public const string CloudEventTopicKeyEnvironmentVariableName = "EVENT_GRID_CLOUD_EVENT_TOPIC_KEY";
        public const string CloudEventTopicEndpointEnvironmentVariableName = "EVENT_GRID_CLOUD_EVENT_TOPIC_ENDPOINT";

        public const string CustomEventTopicKeyEnvironmentVariableName = "EVENT_GRID_CUSTOM_EVENT_TOPIC_KEY";
        public const string CustomEventTopicEndpointEnvironmentVariableName = "EVENT_GRID_CUSTOM_EVENT_TOPIC_ENDPOINT";

        public string TopicHost => GetRecordedVariable(TopicEndpointEnvironmentVariableName);
        public string TopicKey => GetRecordedVariable(TopicKeyEnvironmentVariableName, options => options.IsSecret(SanitizedValue.Base64));

        public string DomainHost => GetRecordedVariable(DomainEndpointEnvironmentVariableName);
        public string DomainKey => GetRecordedVariable(DomainKeyEnvironmentVariableName, options => options.IsSecret(SanitizedValue.Base64));

        public string CloudEventTopicHost => GetRecordedVariable(CloudEventTopicEndpointEnvironmentVariableName);
        public string CloudEventTopicKey => GetRecordedVariable(CloudEventTopicKeyEnvironmentVariableName, options => options.IsSecret(SanitizedValue.Base64));

        public string CustomEventTopicHost => GetRecordedVariable(CustomEventTopicEndpointEnvironmentVariableName);
        public string CustomEventTopicKey => GetRecordedVariable(CustomEventTopicKeyEnvironmentVariableName, options => options.IsSecret(SanitizedValue.Base64));
    }
}
