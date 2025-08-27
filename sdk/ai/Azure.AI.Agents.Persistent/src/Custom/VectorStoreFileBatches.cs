// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Autorest.CSharp.Core;
using System.Threading;
using System;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    internal partial class VectorStoreFileBatches
    {
        /// <summary> Returns a list of vector store files in a batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="filter"> Filter by file status. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual AsyncPageable<VectorStoreFile> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, VectorStoreFileStatusFilter? filter = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
            Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetVectorStoreFileBatchFilesRequest(
                vectorStoreId: vectorStoreId,
                batchId: batchId,
                filter: filter?.ToString(),
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            return new ContinuationTokenPageableAsync<VectorStoreFile>(
                createPageRequest: PageRequest,
                valueFactory: e => VectorStoreFile.DeserializeVectorStoreFile(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary> Returns a list of vector store files in a batch. </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="filter"> Filter by file status. </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Pageable<VectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, VectorStoreFileStatusFilter? filter = null, int? limit = null, ListSortOrder? order = null, string after = null, string before = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
            Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage PageRequest(int? pageSizeHint, string continuationToken) => CreateGetVectorStoreFileBatchFilesRequest(
                vectorStoreId: vectorStoreId,
                batchId: batchId,
                filter: filter?.ToString(),
                limit: limit,
                order: order?.ToString(),
                after: continuationToken,
                before: before,
                context: context);
            return new ContinuationTokenPageable<VectorStoreFile>(
                createPageRequest: PageRequest,
                valueFactory: e => VectorStoreFile.DeserializeVectorStoreFile(e),
                pipeline: _pipeline,
                clientDiagnostics: ClientDiagnostics,
                scopeName: "ThreadMessagesClient.GetMessages",
                requestContext: context,
                after: after
            );
        }

        /// <summary>
        /// [Protocol Method] Returns a list of vector store files in a batch.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetVectorStoreFileBatchFilesAsync(string,string,VectorStoreFileStatusFilter?,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="filter"> Filter by file status. Allowed values: "in_progress" | "completed" | "failed" | "cancelled". </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual AsyncPageable<BinaryData> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
            Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetVectorStoreFileBatchFilesRequest(vectorStoreId, batchId, filter, limit, order, after, before, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VectorStoreFileBatchesClient.GetVectorStoreFileBatchFiles", "data", null, context);
        }

        /// <summary>
        /// [Protocol Method] Returns a list of vector store files in a batch.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetVectorStoreFileBatchFiles(string,string,VectorStoreFileStatusFilter?,int?,ListSortOrder?,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="vectorStoreId"> Identifier of the vector store. </param>
        /// <param name="batchId"> Identifier of the file batch. </param>
        /// <param name="filter"> Filter by file status. Allowed values: "in_progress" | "completed" | "failed" | "cancelled". </param>
        /// <param name="limit"> A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20. </param>
        /// <param name="order"> Sort order by the created_at timestamp of the objects. asc for ascending order and desc for descending order. Allowed values: "asc" | "desc". </param>
        /// <param name="after"> A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list. </param>
        /// <param name="before"> A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="vectorStoreId"/> or <paramref name="batchId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        internal virtual Pageable<BinaryData> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, RequestContext context)
        {
            // This method is not yet supported, because it is using generated implementation of parser,
            // which is currently do not support next token.
            Argument.AssertNotNullOrEmpty(vectorStoreId, nameof(vectorStoreId));
            Argument.AssertNotNullOrEmpty(batchId, nameof(batchId));

            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetVectorStoreFileBatchFilesRequest(vectorStoreId, batchId, filter, limit, order, after, before, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "VectorStoreFileBatchesClient.GetVectorStoreFileBatchFiles", "data", null, context);
        }
    }
}
