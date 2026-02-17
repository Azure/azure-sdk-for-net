// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    // CUSTOM:
    // - Support returning Stream for Query operations.
    internal partial class BlockBlobRestClient
    {
        /// <summary> The Query operation enables users to select/project on blob data by providing simple query expressions. </summary>
        /// <param name="queryRequest"> The query request. </param>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="encryptionKey"> Optional.  Version 2019-07-07 and later.  Specifies the encryption key to use to encrypt the data provided in the request. If not specified, the request will be encrypted with the root account key. </param>
        /// <param name="encryptionKeySha256"> Optional.  Version 2019-07-07 and later.  Specifies the SHA256 hash of the encryption key used to encrypt the data provided in the request. This header is only used for encryption with a customer-provided key. If the request is authenticated with a client token, this header should be specified using the SHA256 hash of the encryption key. </param>
        /// <param name="encryptionAlgorithm"> Optional.  Version 2019-07-07 and later.  Specifies the algorithm to use for encryption. If not specified, the default is AES256. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="ifTags"> Specify a SQL where clause on blob tags to operate only on blobs with a matching value. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Stream> Query(QueryRequest queryRequest, string snapshot = default, int? timeout = default, string leaseId = default, string encryptionKey = default, string encryptionKeySha256 = default, EncryptionAlgorithmTypeInternal? encryptionAlgorithm = default, RequestConditions requestConditions = default, string ifTags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlockBlobRestClient.Query");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateQueryRequest(queryRequest, snapshot, timeout, leaseId, encryptionKey, encryptionKeySha256, encryptionAlgorithm?.ToSerialString(), requestConditions, ifTags, context);
                Response response = Pipeline.ProcessMessage(message, context);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The Query operation enables users to select/project on blob data by providing simple query expressions. </summary>
        /// <param name="queryRequest"> The query request. </param>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="encryptionKey"> Optional.  Version 2019-07-07 and later.  Specifies the encryption key to use to encrypt the data provided in the request. If not specified, the request will be encrypted with the root account key. </param>
        /// <param name="encryptionKeySha256"> Optional.  Version 2019-07-07 and later.  Specifies the SHA256 hash of the encryption key used to encrypt the data provided in the request. This header is only used for encryption with a customer-provided key. If the request is authenticated with a client token, this header should be specified using the SHA256 hash of the encryption key. </param>
        /// <param name="encryptionAlgorithm"> Optional.  Version 2019-07-07 and later.  Specifies the algorithm to use for encryption. If not specified, the default is AES256. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="ifTags"> Specify a SQL where clause on blob tags to operate only on blobs with a matching value. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Stream>> QueryAsync(QueryRequest queryRequest, string snapshot = default, int? timeout = default, string leaseId = default, string encryptionKey = default, string encryptionKeySha256 = default, EncryptionAlgorithmTypeInternal? encryptionAlgorithm = default, RequestConditions requestConditions = default, string ifTags = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlockBlobRestClient.Query");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateQueryRequest(queryRequest, snapshot, timeout, leaseId, encryptionKey, encryptionKeySha256, encryptionAlgorithm?.ToSerialString(), requestConditions, ifTags, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Stream content = message.ExtractResponseContent();
                return Response.FromValue(content, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
