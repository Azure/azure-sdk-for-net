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
    // overloads (for example "client.DeleteIndexer("name")"). Suppress the
    // generated convenience overloads and re-declare them here with a required
    // "matchConditions" parameter so the friendly single-name overloads are no
    // longer ambiguous. The protocol overloads (..., RequestContext) are left
    // untouched.
    [CodeGenSuppress("DeleteIndexer", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteIndexerAsync", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDataSourceConnection", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteDataSourceConnectionAsync", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSkillset", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSkillsetAsync", typeof(string), typeof(MatchConditions), typeof(CancellationToken))]
    public partial class SearchIndexerClient
    {
        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response DeleteIndexer(string indexerName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(indexerName, nameof(indexerName));

            return DeleteIndexer(indexerName, matchConditions, cancellationToken.ToRequestContext());
        }

        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> DeleteIndexerAsync(string indexerName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(indexerName, nameof(indexerName));

            return await DeleteIndexerAsync(indexerName, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Deletes a datasource. </summary>
        /// <param name="dataSourceConnectionName"> The name of the datasource. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response DeleteDataSourceConnection(string dataSourceConnectionName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataSourceConnectionName, nameof(dataSourceConnectionName));

            return DeleteDataSourceConnection(dataSourceConnectionName, matchConditions, cancellationToken.ToRequestContext());
        }

        /// <summary> Deletes a datasource. </summary>
        /// <param name="dataSourceConnectionName"> The name of the datasource. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> DeleteDataSourceConnectionAsync(string dataSourceConnectionName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dataSourceConnectionName, nameof(dataSourceConnectionName));

            return await DeleteDataSourceConnectionAsync(dataSourceConnectionName, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Deletes a skillset in a search service. </summary>
        /// <param name="skillsetName"> The name of the skillset. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response DeleteSkillset(string skillsetName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(skillsetName, nameof(skillsetName));

            return DeleteSkillset(skillsetName, matchConditions, cancellationToken.ToRequestContext());
        }

        /// <summary> Deletes a skillset in a search service. </summary>
        /// <param name="skillsetName"> The name of the skillset. </param>
        /// <param name="matchConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response> DeleteSkillsetAsync(string skillsetName, MatchConditions matchConditions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(skillsetName, nameof(skillsetName));

            return await DeleteSkillsetAsync(skillsetName, matchConditions, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
