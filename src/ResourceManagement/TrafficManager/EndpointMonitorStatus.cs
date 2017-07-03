// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    /// <summary>
    /// Traffic manager profile endpoint monitor statuses.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLkVuZHBvaW50TW9uaXRvclN0YXR1cw==
    public partial class EndpointMonitorStatus : ExpandableStringEnum<EndpointMonitorStatus>
    {
        public static readonly EndpointMonitorStatus Inactive = Parse("Inactive");
        public static readonly EndpointMonitorStatus Disabled = Parse("Disabled");
        public static readonly EndpointMonitorStatus Online = Parse("Online");
        public static readonly EndpointMonitorStatus Degraded = Parse("Degraded");
        public static readonly EndpointMonitorStatus CheckingEndpoint = Parse("CheckingEndpoint");
        public static readonly EndpointMonitorStatus Stopped = Parse("Stopped");
    }
}
