// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.CosmosDB
{
    // MPG transforms @head + @@responseAsBool into a Response-returning method (no bool unwrap),
    // breaking the 1.4.0 GA Response<bool> contract.
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/59089 is resolved.
    public static partial class CosmosDBExtensions
    {
        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Task<Response<bool>> CheckNameExistsDatabaseAccountAsync(this TenantResource tenantResource, string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableCosmosDBTenantResource(tenantResource).CheckNameExistsDatabaseAccountAsync(accountName, cancellationToken);
        }

        /// <summary>
        /// Checks that the Azure Cosmos DB account name already exists. A valid account name may contain only
        /// lowercase letters, numbers, and the '-' character, and must be between 3 and 50 characters.
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="accountName"> Cosmos DB database account name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="accountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="accountName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public static Response<bool> CheckNameExistsDatabaseAccount(this TenantResource tenantResource, string accountName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableCosmosDBTenantResource(tenantResource).CheckNameExistsDatabaseAccount(accountName, cancellationToken);
        }
    }
}
