// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.CosmosDB
{
    // Generator tag-helper fallback calls this.UpdateAsync(WaitUntil, <Data>, CT), but Cosmos DB
    // resources have no PATCH/Update operation. Shim an internal Update overload that throws
    // NotSupportedException; tag-resource happy path is unaffected.
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/58747 is resolved.
    public partial class CassandraViewResource
    {
        private const string TagFallbackUnsupportedMessage =
            "AddTag/SetTags/RemoveTag fall back to the resource PUT operation when the subscription does not have tag-resource privileges, but the underlying PUT body type for CassandraViewResource is a different model from its data type, so the fallback is not supported. See https://github.com/Azure/azure-sdk-for-net/issues/58747.";

        internal Task<ArmOperation<CassandraViewResource>> UpdateAsync(WaitUntil waitUntil, CassandraViewData data, CancellationToken cancellationToken = default) =>
            throw new NotSupportedException(TagFallbackUnsupportedMessage);

        internal ArmOperation<CassandraViewResource> Update(WaitUntil waitUntil, CassandraViewData data, CancellationToken cancellationToken = default) =>
            throw new NotSupportedException(TagFallbackUnsupportedMessage);
    }
}
