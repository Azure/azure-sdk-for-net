// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

// The unbranded SCM generator currently mishandles `@@responseAsBool` on a `@head` op:
//   * it adds a spurious `string accept` parameter to both the public method and the
//     RestClient builder (HEAD has nothing to negotiate, original swagger has no Accept),
//   * the generated method body deserializes via `ModelReaderWriter.Read<bool>(...)`
//     (bool is not IPersistableModel; trips IL2026/IL3050 under net10.0 trim/AOT),
//   * and emits `if (response.Value == null)` for a value-type T (CS0472).
// This produces 10 build errors. Until the generator is fixed, suppress the broken
// overloads and re-emit the historical AutoRest-compatible signature here, mapping
// HTTP 200 -> true and 404 -> false directly off the response status code.
//
// Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59089

namespace Azure.ResourceManager.CosmosDB.Mocking
{
    [CodeGenSuppress("CheckNameExistsDatabaseAccount", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CheckNameExistsDatabaseAccountAsync", typeof(string), typeof(string), typeof(CancellationToken))]
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
