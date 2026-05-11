// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.TypeSpec.Generator.AspNetServer.AzureSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Sql;

namespace Azure.TypeSpec.Generator.AspNetServer.AzureSql.Controllers
{
    /// <summary>
    /// Hand-written controller that consumes the generated server contract.
    /// </summary>
    public sealed class DatabasesController : DatabasesControllerBase
    {
        /// <inheritdoc/>
        public override Task<ActionResult<Database>> GetAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<ActionResult<Database>>(Ok(CreateDatabase(subscriptionId, resourceGroupName, databaseName)));
        }

        /// <inheritdoc/>
        public override Task<ActionResult<Database>> CreateOrUpdateAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            Database resource,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            resource.Id = BuildDatabaseId(subscriptionId, resourceGroupName, databaseName);
            resource.Name = databaseName;
            resource.Type = "Microsoft.Sql/databases";

            return Task.FromResult<ActionResult<Database>>(Ok(resource));
        }

        /// <inheritdoc/>
        public override Task<IActionResult> DeleteAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<IActionResult>(NoContent());
        }

        /// <inheritdoc/>
        public override Task<ActionResult<Database>> UpdateAsync(
            string subscriptionId,
            string resourceGroupName,
            string databaseName,
            DatabaseUpdate properties,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var database = CreateDatabase(subscriptionId, resourceGroupName, databaseName);
            database.Tags = properties.Tags ?? database.Tags;
            database.Properties.Collation = properties.Properties?.Collation ?? database.Properties.Collation;
            database.Properties.MaxSizeBytes = properties.Properties?.MaxSizeBytes ?? database.Properties.MaxSizeBytes;
            database.Properties.ElasticPoolId = properties.Properties?.ElasticPoolId ?? database.Properties.ElasticPoolId;

            return Task.FromResult<ActionResult<Database>>(Ok(database));
        }

        /// <inheritdoc/>
        public override Task<ActionResult<DatabaseListResult>> ListByResourceGroupAsync(
            string subscriptionId,
            string resourceGroupName,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = new DatabaseListResult
            {
                Value =
                [
                    CreateDatabase(subscriptionId, resourceGroupName, "database1"),
                    CreateDatabase(subscriptionId, resourceGroupName, "database2")
                ]
            };

            return Task.FromResult<ActionResult<DatabaseListResult>>(Ok(result));
        }

        private static Database CreateDatabase(string subscriptionId, string resourceGroupName, string databaseName)
        {
            return new Database
            {
                Id = BuildDatabaseId(subscriptionId, resourceGroupName, databaseName),
                Name = databaseName,
                Type = "Microsoft.Sql/databases",
                Location = "westus",
                Tags = new Dictionary<string, string>
                {
                    ["scenario"] = "existing-project"
                },
                Properties = new DatabaseProperties
                {
                    Collation = "SQL_Latin1_General_CP1_CI_AS",
                    MaxSizeBytes = 268435456000,
                    Status = "Online",
                    ProvisioningState = ProvisioningState.Succeeded
                }
            };
        }

        private static string BuildDatabaseId(string subscriptionId, string resourceGroupName, string databaseName)
        {
            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/databases/{databaseName}";
        }
    }
}
