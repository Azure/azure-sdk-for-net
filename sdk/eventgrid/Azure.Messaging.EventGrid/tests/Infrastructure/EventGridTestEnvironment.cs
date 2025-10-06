// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridTestEnvironment : TestEnvironment
    {
        public string TopicHost => GetRecordedVariable("EVENTGRID_TOPIC_ENDPOINT");
        public string TopicKey => GetRecordedVariable("EVENTGRID_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string DomainHost => GetRecordedVariable("EVENTGRID_DOMAIN_ENDPOINT");
        public string DomainKey => GetRecordedVariable("EVENTGRID_DOMAIN_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CloudEventDomainHost => GetRecordedVariable("EVENTGRID_CLOUD_EVENT_DOMAIN_ENDPOINT");
        public string CloudEventDomainKey => GetRecordedVariable("EVENTGRID_CLOUD_EVENT_DOMAIN_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CloudEventTopicHost => GetRecordedVariable("EVENTGRID_CLOUD_EVENT_TOPIC_ENDPOINT");
        public string CloudEventTopicKey => GetRecordedVariable("EVENTGRID_CLOUD_EVENT_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string CustomEventTopicHost => GetRecordedVariable("EVENTGRID_CUSTOM_EVENT_TOPIC_ENDPOINT");
        public string CustomEventTopicKey => GetRecordedVariable("EVENTGRID_CUSTOM_EVENT_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));

        public string PartnerNamespaceHost => GetRecordedVariable("EVENTGRID_PARTNER_NAMESPACE_TOPIC_ENDPOINT");
        public string PartnerNamespaceKey => GetRecordedVariable("EVENTGRID_PARTNER_NAMESPACE_TOPIC_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string PartnerChannelName => GetRecordedVariable("EVENTGRID_PARTNER_CHANNEL_NAME");

        public string NamespaceKey => GetRecordedVariable("EVENTGRID_KEY", options => options.IsSecret(SanitizedValue.Base64));
        public string NamespaceTopicHost => GetRecordedVariable("EVENTGRID_ENDPOINT");
        public string NamespaceTopicName => GetRecordedVariable("EVENTGRID_TOPIC_NAME");
        public string NamespaceSubscriptionName => GetRecordedVariable("EVENTGRID_EVENT_SUBSCRIPTION_NAME");
    }
}
