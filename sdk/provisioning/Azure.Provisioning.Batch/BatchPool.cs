// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace Azure.Provisioning.Batch
{
    /// <summary>
    /// Represents a Batch pool.
    /// </summary>
    public class BatchPool : Resource<BatchAccountPoolData>
    {
        private const string ResourceTypeName = "Microsoft.Batch/batchAccounts/pools";

        private static readonly Func<string, BatchAccountPoolData> Empty = (name) =>
            ArmBatchModelFactory.BatchAccountPoolData();

        public BatchPool(IConstruct scope, BatchAccount? parent = null, string name = "pool",
            string version = BatchAccount.DefaultVersion, AzureLocation? location = default)
            : this(scope, parent, name, version, false, (name) => ArmBatchModelFactory.BatchAccountPoolData(
                name: name,
                resourceType: ResourceTypeName))
        {
        }

        private BatchPool(IConstruct scope, BatchAccount? parent, string name,
            string version = BatchAccount.DefaultVersion, bool isExisting = true,
            Func<string, BatchAccountPoolData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        public static BatchPool FromExisting(IConstruct scope, string name, BatchAccount parent)
            => new BatchPool(scope, parent: parent, name: name, isExisting: true);

        protected override Resource? FindParentInScope(IConstruct scope)
        {
            return scope.GetSingleResource<BatchAccount>() ?? new BatchAccount(scope);
        }
    }
}
