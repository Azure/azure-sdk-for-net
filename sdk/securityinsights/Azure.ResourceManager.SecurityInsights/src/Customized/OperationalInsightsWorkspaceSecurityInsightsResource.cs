// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class extending from the OperationalInsightsWorkspaceResource in Azure.ResourceManager.SecurityInsights along with the instance operations that can be performed on it.
    /// You can only construct an <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> from a <see cref="ResourceIdentifier"/> with a resource type of Microsoft.OperationalInsights/workspaces.
    /// </summary>
    public partial class OperationalInsightsWorkspaceSecurityInsightsResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="OperationalInsightsWorkspaceSecurityInsightsResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="workspaceName"> The workspaceName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
