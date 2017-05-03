// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.StorageAccount.Definition;
    using Microsoft.Rest;

    /// <summary>
    /// Members of IStorageAccounts that are in Beta.
    /// </summary>
    public interface IStorageAccountsBeta  : IBeta
    {
        /// <summary>
        /// Checks that account name is valid and is not in use asynchronously.
        /// </summary>
        /// <param name="name">The account name to check.</param>
        /// <return>Whether the name is available and other info if not.</return>
        Task<Microsoft.Azure.Management.Storage.Fluent.CheckNameAvailabilityResult> CheckNameAvailabilityAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}