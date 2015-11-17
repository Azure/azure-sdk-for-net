// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public static partial class DocumentsOperationsExtensions
    {
        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <remarks>
        /// The non-generic overloads of the Index, IndexAsync, and IndexWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static DocumentIndexResult Index(
            this IDocumentsOperations operations, 
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).IndexAsync(batch, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <remarks>
        /// The non-generic overloads of the Index, IndexAsync, and IndexWithHttpMessagesAsync methods make a
        /// best-effort attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        public static async Task<DocumentIndexResult> IndexAsync(
            this IDocumentsOperations operations,
            IndexBatch batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DocumentIndexResult> result = await operations.IndexWithHttpMessagesAsync(batch, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static DocumentIndexResult Index<T>(
            this IDocumentsOperations operations,
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
            where T : class
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).IndexAsync<T>(batch, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Sends a batch of upload, merge, and/or delete actions to the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798935.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="batch">
        /// The batch of index actions.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="IndexBatchException">
        /// Thrown when some of the indexing actions failed, but other actions succeeded and modified the state of
        /// the index. This can happen when the Search Service is under heavy indexing load. It is important to
        /// explicitly catch this exception and check its
        /// <c cref="IndexBatchException.IndexingResults">IndexResult</c> property. This property reports the status
        /// of each indexing action in the batch, making it possible to determine the state of the index after a
        /// partial failure.
        /// </exception>
        /// <returns>
        /// Response containing the status of operations for all actions in the batch.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Index and IndexAsync methods support mapping of Azure Search field types to
        /// .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<DocumentIndexResult> IndexAsync<T>(
            this IDocumentsOperations operations,
            IndexBatch<T> batch,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            AzureOperationResponse<DocumentIndexResult> result = await operations.IndexWithHttpMessagesAsync<T>(batch, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
