// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobVersionResource
    {
        /// <summary> Backward-compatible overload that accepts <see cref="int"/> for the job version. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, int jobVersion)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, jobAgentName, jobName, jobVersion.ToString(CultureInfo.InvariantCulture));
    }
}
