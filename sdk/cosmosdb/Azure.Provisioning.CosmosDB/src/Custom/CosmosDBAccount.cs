// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

public partial class CosmosDBAccount
{
    /// <summary>
    /// Get access keys for this CosmosDBAccount resource.
    /// </summary>
    /// <returns>The keys for this CosmosDBAccount resource.</returns>
    public CosmosDBAccountKeyList GetKeys()
    {
        CosmosDBAccountKeyList key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }
}
