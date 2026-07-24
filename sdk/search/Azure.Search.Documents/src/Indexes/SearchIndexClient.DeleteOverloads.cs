// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes
{
    // The generated convenience overloads for the string-based delete operations
    // declare "MatchConditions matchConditions = default" which makes them
    // ambiguous with the hand-authored "Delete*(string, CancellationToken)"
    // overloads (for example "client.DeleteIndex("name")"). Suppress the
    // generated convenience overloads and re-declare them here with a required
    // "matchConditions" parameter so the friendly single-name overloads are no
    // longer ambiguous. The protocol overloads (..., RequestContext) are left
    // untouched.
    [CodeGenSuppress("DeleteIndex", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteIndexAsync", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSynonymMap", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSynonymMapAsync", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    public partial class SearchIndexClient
    {
        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response DeleteIndex(string indexName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));

            return DeleteIndex(indexName, matchConditions, cancellationToken.ToRequestContext());
        }

        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> DeleteIndexAsync(string indexName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(indexName, nameof(indexName));

            return await DeleteIndexAsync(indexName, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response DeleteSynonymMap(string synonymMapName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(synonymMapName, nameof(synonymMapName));

            return DeleteSynonymMap(synonymMapName, matchConditions, cancellationToken.ToRequestContext());
        }

        /// <summary> Deletes a synonym map. </summary>
        /// <param name="synonymMapName"> The name of the synonym map. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> DeleteSynonymMapAsync(string synonymMapName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(synonymMapName, nameof(synonymMapName));

            return await DeleteSynonymMapAsync(synonymMapName, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
