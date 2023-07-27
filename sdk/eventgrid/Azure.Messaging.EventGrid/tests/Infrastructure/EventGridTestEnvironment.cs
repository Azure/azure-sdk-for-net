// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridTestEnvironment : TestEnvironment
    {
        public string TopicHost => GetRecordedVariable("EVENT_GRID_TOPIC_ENDPOINT");
        public string TopicKey => GetRecordedVariable("EVENT_GRID_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string DomainHost => GetRecordedVariable("EVENT_GRID_DOMAIN_ENDPOINT");
        public string DomainKey => GetRecordedVariable("EVENT_GRID_DOMAIN_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CloudEventDomainHost => GetRecordedVariable("EVENT_GRID_CLOUD_EVENT_DOMAIN_ENDPOINT");
        public string CloudEventDomainKey => GetRecordedVariable("EVENT_GRID_CLOUD_EVENT_DOMAIN_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CloudEventTopicHost => GetRecordedVariable("EVENT_GRID_CLOUD_EVENT_TOPIC_ENDPOINT");
        public string CloudEventTopicKey => GetRecordedVariable("EVENT_GRID_CLOUD_EVENT_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CustomEventTopicHost => GetRecordedVariable("EVENT_GRID_CUSTOM_EVENT_TOPIC_ENDPOINT");
        public string CustomEventTopicKey => GetRecordedVariable("EVENT_GRID_CUSTOM_EVENT_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string PartnerNamespaceHost => GetRecordedVariable("EVENT_GRID_PARTNER_NAMESPACE_ENDPOINT");
        public string PartnerNamespaceKey => GetRecordedVariable("EVENT_GRID_PARTNER_NAMESPACE_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string PartnerChannelName => GetRecordedVariable("EVENT_GRID_PARTNER_CHANNEL_NAME");
    }
}
