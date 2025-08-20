// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Autorest.CSharp.Core;
using System.Threading;
using System;
using Azure.Core;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class VectorStores
    {
        private readonly VectorStoreFiles _filesClient;
        private readonly VectorStoreFileBatches _batchFileClient;
        /// <summary> Initializes a new instance of VectorStores. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="tokenCredential"> The token credential to copy. </param>
        /// <param name="endpoint"> Project endpoint in the form of: https://&lt;aiservices-id&gt;.services.ai.azure.com/api/projects/&lt;project-name&gt;. </param>
        /// <param name="apiVersion"> The API version to use for this operation. </param>
        /// <param name="files">The files client to be used for file operations. </param>
        /// <param name="fileBatches">Te file batches client used to for file batches operations. </param>
        internal VectorStores(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, TokenCredential tokenCredential, Uri endpoint, string apiVersion, VectorStoreFiles files, VectorStoreFileBatches fileBatches) : this (clientDiagnostics: clientDiagnostics, pipeline: pipeline, tokenCredential: tokenCredential, endpoint: endpoint, apiVersion: apiVersion)
        {
            _filesClient = files;
            _batchFileClient = fileBatches;
        }

        /// <summary> Returns a list of vector stores. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PersistentAgentsVectorStore> GetVectorStoresAsync(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetVectorStoresRequest(limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageableAsync<PersistentAgentsVectorStore>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgentsVectorStore.DeserializePersistentAgentsVectorStore(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
            );
        }

        /// <summary> Returns a list of vector stores. </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PersistentAgentsVectorStore> GetVectorStores(int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetVectorStoresRequest(limit, order?.ToString(), continuationToken, before, context);
            return new ContinuationTokenPageable<PersistentAgentsVectorStore>(
                createPageRequest: PageRequest,
                valueFactory: e => PersistentAgentsVectorStore.DeserializePersistentAgentsVectorStore(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context
            );
        }

        /// <summary>
        /// [Protocol Method] Returns a list of vector stores.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetVectorStoresAsync(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetVectorStoresRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VectorStoresClient.GetVectorStores", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Returns a list of vector stores.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetVectorStores(int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetVectorStores(int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetVectorStoresRequest(limit, order, after, before, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VectorStoresClient.GetVectorStores", "data", null, context);
        }

        /// <summary> Deletes the vector store object matching the specified ID. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteVectorStoreAsync(string vectorStoreId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

            Response<InternalVectorStoreDeletionStatus> response = await InternalDeleteVectorStoreAsync(vectorStoreId, cancellationToken).ConfigureAwait(false);
            bool isDeleted = response.GetRawResponse() != null
                && !response.GetRawResponse().IsError
                && response.Value != null
                && response.Value.Deleted;
            return Response.FromValue(isDeleted, response.GetRawResponse());
        }

        /// <summary> Deletes the vector store object matching the specified ID. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteVectorStore(string vectorStoreId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));

            Response<InternalVectorStoreDeletionStatus> response = InternalDeleteVectorStore(vectorStoreId, cancellationToken);
            bool isDeleted = response.GetRawResponse() !=null
                && !response.GetRawResponse().IsError
                && response.Value != null
                && response.Value.Deleted;
            return Response.FromValue(isDeleted, response.GetRawResponse());
        }

        ////////////////////////////////////////////////////////////////////////////
        // Batch File client methods
        ////////////////////////////////////////////////////////////////////////////

        /// <summary> Create a vector store file batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileIds"> List of file identifiers. </param>
        /// <param name="dataSources"> List of Azure assets. </param>
        /// <param name="chunkingStrategy"> The chunking strategy used to chunk the file(s). If not set, will use the auto strategy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, IEnumerable<string> fileIds = null, IEnumerable<VectorStoreDataSource> dataSources = null, VectorStoreChunkingStrategy chunkingStrategy = null, CancellationToken cancellationToken = default)
        {
            return await _batchFileClient.CreateVectorStoreFileBatchAsync(vectorStoreId: vectorStoreId, fileIds: fileIds, dataSources: dataSources, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Create a vector store file batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileIds"> List of file identifiers. </param>
        /// <param name="dataSources"> List of Azure assets. </param>
        /// <param name="chunkingStrategy"> The chunking strategy used to chunk the file(s). If not set, will use the auto strategy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, IEnumerable<string> fileIds = null, IEnumerable<VectorStoreDataSource> dataSources = null, VectorStoreChunkingStrategy chunkingStrategy = null, CancellationToken cancellationToken = default)
        {
            return _batchFileClient.CreateVectorStoreFileBatch(vectorStoreId: vectorStoreId, fileIds: fileIds, dataSources: dataSources, chunkingStrategy: chunkingStrategy, cancellationToken: cancellationToken);
        }

        /// <summary> Retrieve a vector store file batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, CancellationToken cancellationToken = default)
        {
            return await _batchFileClient.GetVectorStoreFileBatchAsync(vectorStoreId: vectorStoreId, batchId: batchId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Retrieve a vector store file batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default)
        {
            return _batchFileClient.GetVectorStoreFileBatch(vectorStoreId: vectorStoreId, batchId: batchId, cancellationToken: cancellationToken);
        }

        /// <summary> Cancel a vector store file batch. This attempts to cancel the processing of files in this batch as soon as possible. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, CancellationToken cancellationToken = default)
        {
            return await _batchFileClient.CancelVectorStoreFileBatchAsync(vectorStoreId: vectorStoreId, batchId: batchId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Cancel a vector store file batch. This attempts to cancel the processing of files in this batch as soon as possible. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default)
        {
            return _batchFileClient.CancelVectorStoreFileBatch(vectorStoreId: vectorStoreId, batchId: batchId, cancellationToken: cancellationToken);
        }

        ////////////////////////////////////////////////////////////////////////////
        // File client methods
        ////////////////////////////////////////////////////////////////////////////

        /// <summary> Create a vector store file by attaching a file to a vector store. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileId"> Identifier of the file. </param>
        /// <param name="dataSource"> Azure asset ID. </param>
        /// <param name="chunkingStrategy"> The chunking strategy used to chunk the file. If not set, uses the auto strategy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId = null, VectorStoreDataSource dataSource = null, VectorStoreChunkingStrategy chunkingStrategy = null, CancellationToken cancellationToken = default)
        {
            return await _filesClient.CreateVectorStoreFileAsync(vectorStoreId: vectorStoreId, fileId: fileId, dataSource: dataSource, chunkingStrategy: chunkingStrategy, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Create a vector store file by attaching a file to a vector store. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileId"> Identifier of the file. </param>
        /// <param name="dataSource"> Azure asset ID. </param>
        /// <param name="chunkingStrategy"> The chunking strategy used to chunk the file. If not set, uses the auto strategy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId = null, VectorStoreDataSource dataSource = null, VectorStoreChunkingStrategy chunkingStrategy = null, CancellationToken cancellationToken = default)
        {
            return _filesClient.CreateVectorStoreFile(vectorStoreId: vectorStoreId, fileId: fileId, dataSource: dataSource, chunkingStrategy: chunkingStrategy, cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves a vector store file. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileId"> Identifier of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = default)
        {
            return await _filesClient.GetVectorStoreFileAsync(vectorStoreId: vectorStoreId, fileId: fileId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Retrieves a vector store file. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileId"> Identifier of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default)
        {
            return _filesClient.GetVectorStoreFile(vectorStoreId: vectorStoreId, fileId: fileId, cancellationToken: cancellationToken);
        }

        public virtual async Task<Response<bool>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = default)
        {
            return await _filesClient.DeleteVectorStoreFileAsync(vectorStoreId: vectorStoreId, fileId: fileId, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes a vector store file. This removes the file‐to‐store link (does not delete the file itself). </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="fileId"> Identifier of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default)
        {
            return _filesClient.DeleteVectorStoreFile(vectorStoreId: vectorStoreId, fileId: fileId, cancellationToken: cancellationToken);
        }

        /// <summary> Returns a list of vector store files. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="filter"> Filter by file status. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual AsyncPageable<VectorStoreFile> GetVectorStoreFilesAsync(string vectorStoreId, VectorStoreFileStatusFilter? filter = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            return _filesClient.GetVectorStoreFilesAsync(vectorStoreId: vectorStoreId, filter: filter, limit: limit, order: order, after: after, before: before, cancellationToken: cancellationToken);
        }

        /// <summary> Returns a list of vector store files. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="filter"> Filter by file status. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Pageable<VectorStoreFile> GetVectorStoreFiles(string vectorStoreId, VectorStoreFileStatusFilter? filter = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            return _filesClient.GetVectorStoreFiles(vectorStoreId: vectorStoreId, filter: filter, limit: limit, order: order, after: after, before: before, cancellationToken: cancellationToken);
        }
    }
}
