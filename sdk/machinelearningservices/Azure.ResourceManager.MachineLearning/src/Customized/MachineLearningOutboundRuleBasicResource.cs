// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy MachineLearning-prefixed child resource getters and related legacy resource helpers.
    public partial class MachineLearningOutboundRuleBasicResource
    {
        // Customized: preserve legacy outbound rule resource ID shape.
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleName)
        {
            const string legacyManagedNetworkName = "default";
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, workspaceName, legacyManagedNetworkName, ruleName);
        }
    }
}
