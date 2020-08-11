// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Operations for managing skillsets. 
    /// </summary>
    public static partial class SkillsetsOperationsExtensions
    {
        /// <summary>
        /// Creates a new skillset or updates a skillset if it
        /// already exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='skillset'>
        /// The definition of the skillset to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        public static Skillset CreateOrUpdate(this ISkillsetsOperations operations, Skillset skillset, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition))
        {
            return operations.CreateOrUpdateAsync(skillset, searchRequestOptions, accessCondition).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new skillset or updates a skillset if it
        /// already exists.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='skillset'>
        /// The definition of the skillset to create or update.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='accessCondition'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Skillset> CreateOrUpdateAsync(this ISkillsetsOperations operations, Skillset skillset, SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), AccessCondition accessCondition = default(AccessCondition), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(skillset, searchRequestOptions, accessCondition, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Determines whether or not the given skillset exists in the search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="skillsetName">
        /// The name of the skillset.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// <c>true</c> if the skillset exists; <c>false</c> otherwise.
        /// </returns>
        public static bool Exists(
            this ISkillsetsOperations operations,
            string skillsetName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return operations.ExistsAsync(skillsetName, searchRequestOptions).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determines whether or not the given skillset exists in the search service.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="skillsetName">
        /// The name of the skillset.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// <c>true</c> if the skillset exists; <c>false</c> otherwise.
        /// </returns>
        public static async Task<bool> ExistsAsync(
            this ISkillsetsOperations operations,
            string skillsetName,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<bool> result = await operations.ExistsWithHttpMessagesAsync(skillsetName, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}