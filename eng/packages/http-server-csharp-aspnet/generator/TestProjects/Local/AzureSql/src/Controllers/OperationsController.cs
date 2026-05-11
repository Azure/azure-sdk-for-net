// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CommonTypes;
using Azure.TypeSpec.Generator.AspNetServer.AzureSql.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azure.TypeSpec.Generator.AspNetServer.AzureSql.Controllers
{
    /// <summary>
    /// Hand-written controller that consumes the generated server contract.
    /// </summary>
    public sealed class OperationsController : OperationsControllerBase
    {
        /// <inheritdoc/>
        public override Task<ActionResult<OperationListResult>> ListAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = new OperationListResult
            {
                Value =
                [
                    new Operation
                    {
                        Name = "Microsoft.Sql/databases/read",
                        IsDataAction = false,
                        Origin = Origin.UserSystem,
                        Display = new OperationDisplay
                        {
                            Provider = "Microsoft SQL",
                            Resource = "Databases",
                            Operation = "Get database",
                            Description = "Gets an Azure SQL database."
                        }
                    },
                    new Operation
                    {
                        Name = "Microsoft.Sql/databases/write",
                        IsDataAction = false,
                        Origin = Origin.UserSystem,
                        ActionType = ActionType.Internal,
                        Display = new OperationDisplay
                        {
                            Provider = "Microsoft SQL",
                            Resource = "Databases",
                            Operation = "Create or update database",
                            Description = "Creates or updates an Azure SQL database."
                        }
                    }
                ]
            };

            return Task.FromResult<ActionResult<OperationListResult>>(Ok(result));
        }
    }
}
