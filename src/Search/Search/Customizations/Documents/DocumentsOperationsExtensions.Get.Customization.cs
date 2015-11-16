// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Azure;

    public static partial class DocumentsOperationsExtensions
    {
        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document. All retrievable fields are included in the result by default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static Document Get(
            this IDocumentsOperations operations, 
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).GetAsync(key, selectedFields, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See 
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will be missing from the
        /// returned document.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The non-generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods make a best-effort
        /// attempt to map JSON types in the response payload to .NET types. See
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more information.
        /// </remarks>
        public static async Task<Document> GetAsync(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions), 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<Document> result = await operations.GetWithHttpMessagesAsync(key, selectedFields ?? DocumentsOperations.SelectAll, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object. All retrievable fields are included in the result by
        /// default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static T Get<T>(
            this IDocumentsOperations operations, 
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions))
            where T : class
        {
            return Task.Factory.StartNew(s => ((IDocumentsOperations)s).GetAsync<T>(key, selectedFields, searchRequestOptions), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Retrieves a document from the Azure Search index.
        /// <see href="https://msdn.microsoft.com/library/azure/dn798929.aspx"/>
        /// </summary>
        /// <typeparam name="T">
        /// The CLR type that maps to the index schema. Instances of this type can be retrieved as documents
        /// from the index.
        /// </typeparam>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name="key">
        /// The key of the document to retrieve; See
        /// <see href="https://msdn.microsoft.com/library/azure/dn857353.aspx"/> for the rules for constructing valid
        /// document keys.
        /// </param>
        /// <param name="selectedFields">
        /// List of field names to retrieve for the document; Any field not retrieved will have null or default as its
        /// corresponding property value in the returned object. All retrievable fields are included in the result by
        /// default.
        /// </param>
        /// <param name='searchRequestOptions'>
        /// Additional parameters for the operation
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The requested document.
        /// </returns>
        /// <remarks>
        /// The generic overloads of the Get, GetAsync, and GetWithHttpMessagesAsync methods support mapping of Azure
        /// Search field types to .NET types via the type parameter T. See 
        /// <see cref="IDocumentsOperations.GetWithHttpMessagesAsync&lt;T&gt;(string, System.Collections.Generic.IEnumerable&lt;string&gt;, SearchRequestOptions, System.Collections.Generic.Dictionary&lt;string, System.Collections.Generic.List&lt;string&gt;&gt;, CancellationToken)"/>
        /// for more details on the type mapping.
        /// </remarks>
        public static async Task<T> GetAsync<T>(
            this IDocumentsOperations operations,
            string key,
            IEnumerable<string> selectedFields = null,
            SearchRequestOptions searchRequestOptions = default(SearchRequestOptions),
            CancellationToken cancellationToken = default(CancellationToken)) where T : class
        {
            AzureOperationResponse<T> result = await operations.GetWithHttpMessagesAsync<T>(key, selectedFields ?? DocumentsOperations.SelectAll, searchRequestOptions, null, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}
