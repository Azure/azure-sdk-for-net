// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    // MPG transforms @head + @@responseAsBool into a raw Response-returning method emitted on
    // the extension class only; the mockable does not receive a CheckNameExistsDatabaseAccount
    // overload of its own, so we simply add the bool-unwrapping signature here (HTTP 200 -> true,
    // 404 -> false) to preserve the 1.4.0 GA Response<bool> contract for mock scenarios.
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/59089 is resolved.
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
