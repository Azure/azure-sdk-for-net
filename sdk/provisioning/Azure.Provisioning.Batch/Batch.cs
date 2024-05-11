// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Provisioning.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace Azure.Provisioning.Batch
{
    /// <summary>
    /// Represents an Azure Batch account.
    /// </summary>
    public class BatchAccount : Resource<BatchAccountData>
    {
        //https://learn.microsoft.com/en-us/azure/templates/microsoft.batch/batchaccounts?pivots=deployment-language-bicep
        private const string ResourceTypeName = "Microsoft.Batch/batchAccounts";
        internal const string DefaultVersion = "2023-11-01";

        private static BatchAccountData Empty(string name) => ArmBatchModelFactory.BatchAccountData();

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchAccount"/>.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <param name="location"></param>
        public BatchAccount(
            IConstruct scope,
            ResourceGroup? parent = null,
            string name = "batch",
            string version = DefaultVersion,
            AzureLocation? location = default)
            : this (scope, parent, name, version, false, (name) => ArmBatchModelFactory.BatchAccountData(
                    name: name,
                    resourceType: ResourceTypeName,
                    location: location ?? Environment.GetEnvironmentVariable("AZURE_LOCATION") ?? AzureLocation.WestUS))
        {
            AssignProperty(data => data.Name, GetAzureName(scope, name));
        }

        private BatchAccount(
            IConstruct scope,
            ResourceGroup? parent,
            string name,
            string version = DefaultVersion,
            bool isExisting = false,
            Func<string, BatchAccountData>? creator = null)
            : base(scope, parent, name, ResourceTypeName, version, creator ?? Empty, isExisting)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BatchAccount"/> class referencing an existing resource.
        /// </summary>
        /// <param name="scope">The scope.</param>
        /// <param name="name">The resource name.</param>
        /// <param name="parent">The resource group.</param>
        /// <returns>The Batch instance.</returns>
        public static BatchAccount FromExisting(IConstruct scope, string name, ResourceGroup? parent = null)
            => new BatchAccount(scope, parent: parent, name: name, isExisting: true);

        protected override string GetAzureName(IConstruct scope, string resourceName) =>
            GetGloballyUniqueName(resourceName);
    }
}
