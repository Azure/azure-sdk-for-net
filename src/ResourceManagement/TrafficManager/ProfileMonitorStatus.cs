// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.TrafficManager.Fluent
{
    /// <summary>
    /// Traffic manager profile statuses.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnRyYWZmaWNtYW5hZ2VyLlByb2ZpbGVNb25pdG9yU3RhdHVz
    public class ProfileMonitorStatus : ExpandableStringEnum<ProfileMonitorStatus>
    {
        public static readonly ProfileMonitorStatus Inactive = Parse("Inactive");
        public static readonly ProfileMonitorStatus Disabled = Parse("Disabled");
        public static readonly ProfileMonitorStatus Online = Parse("Online");
        public static readonly ProfileMonitorStatus Degraded = Parse("Degraded");
        public static readonly ProfileMonitorStatus CheckingEndpoint = Parse("CheckingEndpoint");
    }
}
