//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;

namespace Microsoft.WindowsAzure.Services.ServiceBus
{
    /// <summary>
    /// Shared constants.
    /// </summary>
    internal static class Constants
    {
        private const int ComErrorMask = unchecked((int)0x80040000);        // Mask for all COM error codes
        internal const int WrapErrorMask = ComErrorMask;                    // Mask for WRAP exceptions
        internal const int HttpErrorMask = ComErrorMask | 0x1000;           // Mask for HTTP exceptions

        internal const string ServiceBusServiceUri          = "https://{0}.servicebus.windows.net/";
        internal const string ServiceBusAuthenticationUri   = "https://{0}-sb.accesscontrol.windows.net/wrapv0.9/";
        internal const string ServiceBusScopeUri            = "http://{0}.servicebus.windows.net/";
        internal const string NamespaceExpression           = @"^(.+)\.servicebus\.windows\.net/?$";

        internal const string MessageDestination            = "{0}/messages/";
        internal const string UnlockedMessagePath           = "{0}/messages/head?timeout={1}";
        internal const string UnlockedSubscriptionMessagePath   = "{0}/subscriptions/{1}/messages/head?timeout={2}";
        internal const string LockedMessagePath             = "{0}/messages/{1}/{2}";
        internal const string LockedSubscriptionMessagePath = "{0}/subscriptions/{1}/messages/{2}/{3}";
        internal const string RangeQueryUri                 = "{0}?$skip={1}&$top={2}";

        internal const string QueuesPath                    = "$Resources/Queues";
        internal const string QueuePath                     = "{0}";                                    // <queue>

        internal const string TopicsPath                    = "$Resources/Topics";
        internal const string TopicPath                     = "{0}";                                    // <topic>

        internal const string SubscriptionsPath             = "{0}/subscriptions/";                     // <topic>/subscriptions
        internal const string SubscriptionPath              = "{0}/subscriptions/{1}";                 // <topic>/subscriptions/<subscription>

        internal const string RulesPath                     = "{0}/subscriptions/{1}/rules/";           // topics/<topic>/subscriptions/<subscription>/rules
        internal const string RulePath                      = "{0}/subscriptions/{1}/rules/{2}";        // <topic>/subscriptions/<subscription>/rules/<rule>

        internal const string WrapTokenAuthenticationString = "WRAP access_token=\"{0}\"";

        internal const string SerializationContentType      = "application/xml";
        internal const string BodyContentType               = "application/atom+xml";
        internal const string DefaultMessageContentType     = "text/plain";
        internal const string WrapAuthenticationContentType = "application/x-www-form-urlencoded";

        internal const string AcceptHeader                  = "Accept";                                 // "Accept" HTTP header name
        internal const string BrokerPropertiesHeader        = "BrokerProperties";                       // Header name for broker properties.

        internal const int CompatibilityLevel               = 20;                                       // Compatibility level for rules.

        internal const string JsonNullValue                 = "null";                                   // String representation of null value in Json.

        internal const string ContentTypeHeader             = "Content-Type";
        internal const string AtomFeedElementName           = "feed";                                   // Local name of the atom feed.

        // Connection strings
        internal const string EndpointKey                   = "Endpoint";
        internal const string SecretIssuerKey               = "SharedSecretIssuer";
        internal const string SecretValueKey                = "SharedSecretValue";
    }
}
