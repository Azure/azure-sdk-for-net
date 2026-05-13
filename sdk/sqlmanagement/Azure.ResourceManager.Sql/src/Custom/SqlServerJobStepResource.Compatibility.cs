// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System.Globalization;
using Azure.Core;

namespace Azure.ResourceManager.Sql
{
    public partial class SqlServerJobStepResource
    {
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string jobAgentName, string jobName, string jobVersion, string stepName)
            => CreateResourceIdentifier(subscriptionId, resourceGroupName, serverName, jobAgentName, jobName, int.Parse(jobVersion, CultureInfo.InvariantCulture), stepName);
    }
}
