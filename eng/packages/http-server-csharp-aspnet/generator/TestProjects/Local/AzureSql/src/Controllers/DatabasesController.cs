// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Sql;
using V20260201Controllers = Azure.TypeSpec.Generator.AspNetServer.AzureSql.Generated.V20260201.Controllers;
using V20260201Models = Azure.TypeSpec.Generator.AspNetServer.AzureSql.Generated.V20260201.Models;

namespace Azure.TypeSpec.Generator.AspNetServer.AzureSql.Controllers
{
    /// <summary>
    /// Hand-written controller that implements operations impacted in 2026-02-01.
    /// </summary>
    [ApiVersion("2026-02-01")]
    public sealed class DatabasesController : V20260201Controllers.DatabasesControllerBase
    {
        /// <inheritdoc/>
        [MapToApiVersion("2026-02-01")]
        public override Task<ActionResult<V20260201Models.Database>> GetAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<ActionResult<V20260201Models.Database>>(Ok(CreateDatabase(subscriptionId, resourceGroupName, databaseName)));
        }

        /// <inheritdoc/>
        [MapToApiVersion("2026-02-01")]
        public override Task<ActionResult<V20260201Models.Database>> CreateOrUpdateAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            V20260201Models.Database resource,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            resource.Id = BuildDatabaseId(subscriptionId, resourceGroupName, databaseName);
            resource.Name = databaseName;
            resource.Type = "Microsoft.Sql/databases";

            return Task.FromResult<ActionResult<V20260201Models.Database>>(Ok(resource));
        }

        /// <inheritdoc/>
        [MapToApiVersion("2026-02-01")]
        public override Task<ActionResult<V20260201Models.Database>> UpdateAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            V20260201Models.DatabaseUpdate properties,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var database = CreateDatabase(subscriptionId, resourceGroupName, databaseName);
            database.Tags = properties.Tags ?? database.Tags;
            database.Properties.Collation = properties.Properties?.Collation ?? database.Properties.Collation;
            database.Properties.MaxSizeBytes = properties.Properties?.MaxSizeBytes ?? database.Properties.MaxSizeBytes;
            database.Properties.ElasticPoolId = properties.Properties?.ElasticPoolId ?? database.Properties.ElasticPoolId;

            return Task.FromResult<ActionResult<V20260201Models.Database>>(Ok(database));
        }

        /// <inheritdoc/>
        [MapToApiVersion("2026-02-01")]
        public override Task<ActionResult<V20260201Models.DatabaseListResult>> ListByResourceGroupAsync(
            string subscriptionId,
            string resourceGroupName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = new V20260201Models.DatabaseListResult
            {
                Value =
                [
                    CreateDatabase(subscriptionId, resourceGroupName, "database1"),
                    CreateDatabase(subscriptionId, resourceGroupName, "database2")
                ]
            };

            return Task.FromResult<ActionResult<V20260201Models.DatabaseListResult>>(Ok(result));
        }

        private static V20260201Models.Database CreateDatabase(string subscriptionId, string resourceGroupName, string databaseName)
        {
            return new V20260201Models.Database
            {
                Id = BuildDatabaseId(subscriptionId, resourceGroupName, databaseName),
                Name = databaseName,
                Type = "Microsoft.Sql/databases",
                Location = "westus",
                Tags = CreateTags(),
                Properties = new V20260201Models.DatabaseProperties
                {
                    Collation = "SQL_Latin1_General_CP1_CI_AS",
                    MaxSizeBytes = 268435456000,
                    Status = "Online",
                    ProvisioningState = ProvisioningState.Succeeded,
                    ElasticPoolId = "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Sql/elasticPools/pool1"
                }
            };
        }

        private static Dictionary<string, string> CreateTags()
        {
            return new Dictionary<string, string>
            {
                ["scenario"] = "existing-project"
            };
        }

        private static string BuildDatabaseId(string subscriptionId, string resourceGroupName, string databaseName)
        {
            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/databases/{databaseName}";
        }
    }
}
