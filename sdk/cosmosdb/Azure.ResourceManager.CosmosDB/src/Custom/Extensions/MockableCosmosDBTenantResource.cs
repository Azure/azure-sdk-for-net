// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    // MPG transforms @head + @@responseAsBool into a raw Response-returning method;
    // 1.4.0 GA shipped Response<bool>. Suppress the generated overload and re-emit the
    // bool-unwrapping signature (HTTP 200 -> true, 404 -> false).
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/59089 is resolved.
    [CodeGenSuppress("CheckNameExistsDatabaseAccount", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckNameExistsDatabaseAccountAsync", typeof(string), typeof(CancellationToken))]
    public partial class MockableCosmosDBTenantResource
    {
        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// </summary>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public virtual async Task<Response<bool>> CheckNameExistsDatabaseAccountAsync(string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));

            using DiagnosticScope scope = DatabaseAccountsClientDiagnostics.CreateScope("MockableCosmosDBTenantResource.CheckNameExistsDatabaseAccount");
            scope.Start();
            try
            {
                HttpMessage message = DatabaseAccountsRestClient.CreateCheckNameExistsDatabaseAccountRequest(accountName, new RequestContext { CancellationToken = cancellationToken });
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return message.Response.Status switch
                {
                    200 => Response.FromValue(true, message.Response),
                    404 => Response.FromValue(false, message.Response),
                    _ => throw new RequestFailedException(message.Response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// </summary>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="accountName"/> is null. </exception>
        public virtual Response<bool> CheckNameExistsDatabaseAccount(string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(accountName, nameof(accountName));

            using DiagnosticScope scope = DatabaseAccountsClientDiagnostics.CreateScope("MockableCosmosDBTenantResource.CheckNameExistsDatabaseAccount");
            scope.Start();
            try
            {
                HttpMessage message = DatabaseAccountsRestClient.CreateCheckNameExistsDatabaseAccountRequest(accountName, new RequestContext { CancellationToken = cancellationToken });
                Pipeline.Send(message, cancellationToken);
                return message.Response.Status switch
                {
                    200 => Response.FromValue(true, message.Response),
                    404 => Response.FromValue(false, message.Response),
                    _ => throw new RequestFailedException(message.Response),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
