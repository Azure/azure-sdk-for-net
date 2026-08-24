// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class StorageAccountLocalUser
{
    // TypeSpec generation does not synthesize the listKeys Bicep expression helper.
    // Preserve the shipped helper and its secure output model.
    /// <summary> Get access keys for this StorageAccountLocalUser resource. </summary>
    /// <returns>The keys for this StorageAccountLocalUser resource.</returns>
    public LocalUserKeys GetKeys()
    {
        LocalUserKeys key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }
}
