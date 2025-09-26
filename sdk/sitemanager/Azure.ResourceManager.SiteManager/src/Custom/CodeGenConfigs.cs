// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// we have this file here as a workaround before the new generator could be ready
// for multi-path resources with customized names.

using Azure.Core;

[assembly: CodeGenConfig("request-path-to-resource-name",
    new string[]
    {
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/sites/{siteName}",
        "ResourceGroupEdgeSite"
    })]
[assembly: CodeGenConfig("request-path-to-resource-name",
    new string[]
    {
        "/subscriptions/{subscriptionId}/providers/Microsoft.Edge/sites/{siteName}",
        "SubscriptionEdgeSite"
    })]
[assembly: CodeGenConfig("request-path-to-resource-name",
    new string[]
    {
        "/providers/Microsoft.Management/serviceGroups/{servicegroupName}/providers/Microsoft.Edge/sites/{siteName}",
        "ServiceGroupEdgeSite"
    })]
[assembly: CodeGenConfig("parameterized-scopes",
    new string[]
    {
        "/providers/Microsoft.Management/serviceGroups/{servicegroupName}"
    })]
