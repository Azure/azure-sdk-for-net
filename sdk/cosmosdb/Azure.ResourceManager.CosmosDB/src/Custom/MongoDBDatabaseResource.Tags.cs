// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.CosmosDB
{
    // Workaround for generator bug: BaseTagMethodProvider emits AddTag/SetTags/RemoveTag
    // helpers whose fallback branch (when CanUseTagResource() returns false) calls
    // this.UpdateAsync(WaitUntil, <ResourceData>, CancellationToken). For Cosmos DB
    // resources the spec uses Azure.ResourceManager.Legacy.CreateOrUpdateAsync<Resource,
    // Request = SeparateBody> with no PATCH operation, so either:
    //   * the real UpdateAsync overload takes a different `CreateUpdate` body type
    //     (CS1503), or
    //   * for the merged umbrella ThroughputSetting resources there is no UpdateAsync
    //     at all (CS1061).
    // Add a private/internal Update overload that matches the signature called by the
    // generated tag helpers and throws NotSupportedException, so the generated code
    // compiles. The tag-resource happy path (CanUseTagResourceAsync == true) still
    // works as expected; only the legacy PUT-based fallback is unsupported. Tracked
    // at https://github.com/Azure/azure-sdk-for-net/issues/58747.
    public partial class MongoDBDatabaseResource
    {
        private const string TagFallbackUnsupportedMessage =
            "AddTag/SetTags/RemoveTag fall back to the resource PUT operation when the subscription does not have tag-resource privileges, but the underlying PUT body type for MongoDBDatabaseResource is a different model from its data type, so the fallback is not supported. See https://github.com/Azure/azure-sdk-for-net/issues/58747.";

        internal Task<ArmOperation<MongoDBDatabaseResource>> UpdateAsync(WaitUntil waitUntil, MongoDBDatabaseData data, CancellationToken cancellationToken = default) =>
            throw new NotSupportedException(TagFallbackUnsupportedMessage);

        internal ArmOperation<MongoDBDatabaseResource> Update(WaitUntil waitUntil, MongoDBDatabaseData data, CancellationToken cancellationToken = default) =>
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
    }
}
