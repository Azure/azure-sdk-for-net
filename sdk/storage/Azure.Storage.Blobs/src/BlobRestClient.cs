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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Blobs
{
    // CUSTOM:
    // - Maintain optionality of immutabilityPolicyExpiry for back-compatibility.
    // - Maintain behavior of 304 response for Download operation.
    // - Suppress generated Download methods in favor of custom implementations that return Stream.
    [CodeGenSuppress("Download", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestConditions), typeof(RequestContext))]
    [CodeGenSuppress("DownloadAsync", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(RequestConditions), typeof(RequestContext))]
    [CodeGenSuppress("Download", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(EncryptionAlgorithmTypeInternal?), typeof(string), typeof(RequestConditions), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadAsync", typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(bool?), typeof(bool?), typeof(string), typeof(string), typeof(string), typeof(EncryptionAlgorithmTypeInternal?), typeof(string), typeof(RequestConditions), typeof(CancellationToken))]
    internal partial class BlobRestClient
    {
        private static ResponseClassifier _pipelineMessageClassifier200206304;
        private static ResponseClassifier PipelineMessageClassifier200206304 => _pipelineMessageClassifier200206304 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 206, 304 });

        /// <summary> The Download operation reads or downloads a blob from the system, including its metadata and properties. You can also call Download to read a snapshot. </summary>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="versionId"> The version id parameter is an opaque DateTime value that, when present, specifies the version of the blob to operate on. It's for service version 2019-10-10 and newer. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="range"> Return only the bytes of the blob in the specified range. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="rangeGetContentMd5"> When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="rangeGetContentCrc64"> Optional.  When this header is set to true and specified together with the Range header, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="structuredBodyType"> Specifies the response content should be returned as a structured message and specifies the message schema version and properties. </param>
        /// <param name="encryptionKey"> Optional.  Version 2019-07-07 and later.  Specifies the encryption key to use to encrypt the data provided in the request. If not specified, the request will be encrypted with the root account key. </param>
        /// <param name="encryptionKeySha256"> Optional.  Version 2019-07-07 and later.  Specifies the SHA256 hash of the encryption key used to encrypt the data provided in the request. This header is only used for encryption with a customer-provided key. If the request is authenticated with a client token, this header should be specified using the SHA256 hash of the encryption key. </param>
        /// <param name="encryptionAlgorithm"> Optional.  Version 2019-07-07 and later.  Specifies the algorithm to use for encryption. If not specified, the default is AES256. </param>
        /// <param name="ifTags"> Specify a SQL where clause on blob tags to operate only on blobs with a matching value. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Stream> Download(string snapshot = default, string versionId = default, int? timeout = default, string range = default, string leaseId = default, bool? rangeGetContentMd5 = default, bool? rangeGetContentCrc64 = default, string structuredBodyType = default, string encryptionKey = default, string encryptionKeySha256 = default, EncryptionAlgorithmTypeInternal? encryptionAlgorithm = default, string ifTags = default, RequestConditions requestConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlobRestClient.Download");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadRequest(snapshot, versionId, timeout, range, leaseId, rangeGetContentMd5, rangeGetContentCrc64, structuredBodyType, encryptionKey, encryptionKeySha256, encryptionAlgorithm?.ToSerialString(), ifTags, requestConditions, context);
                message.BufferResponse = false;
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

        /// <summary> The Download operation reads or downloads a blob from the system, including its metadata and properties. You can also call Download to read a snapshot. </summary>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="versionId"> The version id parameter is an opaque DateTime value that, when present, specifies the version of the blob to operate on. It's for service version 2019-10-10 and newer. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="range"> Return only the bytes of the blob in the specified range. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="rangeGetContentMd5"> When set to true and specified together with the Range, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="rangeGetContentCrc64"> Optional.  When this header is set to true and specified together with the Range header, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="structuredBodyType"> Specifies the response content should be returned as a structured message and specifies the message schema version and properties. </param>
        /// <param name="encryptionKey"> Optional.  Version 2019-07-07 and later.  Specifies the encryption key to use to encrypt the data provided in the request. If not specified, the request will be encrypted with the root account key. </param>
        /// <param name="encryptionKeySha256"> Optional.  Version 2019-07-07 and later.  Specifies the SHA256 hash of the encryption key used to encrypt the data provided in the request. This header is only used for encryption with a customer-provided key. If the request is authenticated with a client token, this header should be specified using the SHA256 hash of the encryption key. </param>
        /// <param name="encryptionAlgorithm"> Optional.  Version 2019-07-07 and later.  Specifies the algorithm to use for encryption. If not specified, the default is AES256. </param>
        /// <param name="ifTags"> Specify a SQL where clause on blob tags to operate only on blobs with a matching value. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Stream>> DownloadAsync(string snapshot = default, string versionId = default, int? timeout = default, string range = default, string leaseId = default, bool? rangeGetContentMd5 = default, bool? rangeGetContentCrc64 = default, string structuredBodyType = default, string encryptionKey = default, string encryptionKeySha256 = default, EncryptionAlgorithmTypeInternal? encryptionAlgorithm = default, string ifTags = default, RequestConditions requestConditions = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlobRestClient.Download");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadRequest(snapshot, versionId, timeout, range, leaseId, rangeGetContentMd5, rangeGetContentCrc64, structuredBodyType, encryptionKey, encryptionKeySha256, encryptionAlgorithm?.ToSerialString(), ifTags, requestConditions, context);
                message.BufferResponse = false;
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

        /// <summary>
        /// [Protocol Method] Set the immutability policy of a blob
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="immutabilityPolicyExpiry"> Specifies the date time when the blobs immutability policy is set to expire. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="immutabilityPolicyMode"> Specifies the immutability policy mode to set on the blob. </param>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="versionId"> The version id parameter is an opaque DateTime value that, when present, specifies the version of the blob to operate on. It's for service version 2019-10-10 and newer. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response SetImmutabilityPolicy(DateTimeOffset? immutabilityPolicyExpiry, int? timeout, RequestConditions requestConditions, string immutabilityPolicyMode, string snapshot, string versionId, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlobRestClient.SetImmutabilityPolicy");
            scope.Start();
            try
            {
                if (requestConditions?.IfMatch != null)
                {
                    throw new ArgumentException("Service does not support the If-Match header for this operation.");
                }
                if (requestConditions?.IfNoneMatch != null)
                {
                    throw new ArgumentException("Service does not support the If-None-Match header for this operation.");
                }
                if (requestConditions?.IfModifiedSince != null)
                {
                    throw new ArgumentException("Service does not support the If-Modified-Since header for this operation.");
                }

                using HttpMessage message = CreateSetImmutabilityPolicyRequest(immutabilityPolicyExpiry, timeout, requestConditions, immutabilityPolicyMode, snapshot, versionId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Set the immutability policy of a blob
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="immutabilityPolicyExpiry"> Specifies the date time when the blobs immutability policy is set to expire. </param>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. For more information, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations"&gt;Setting Timeouts for Blob Service Operations.&lt;/a&gt;. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="immutabilityPolicyMode"> Specifies the immutability policy mode to set on the blob. </param>
        /// <param name="snapshot"> The snapshot parameter is an opaque DateTime value that, when present, specifies the blob snapshot to retrieve. For more information on working with blob snapshots, see &lt;a href="https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/creating-a-snapshot-of-a-blob"&gt;Creating a Snapshot of a Blob.&lt;/a&gt;. </param>
        /// <param name="versionId"> The version id parameter is an opaque DateTime value that, when present, specifies the version of the blob to operate on. It's for service version 2019-10-10 and newer. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> SetImmutabilityPolicyAsync(DateTimeOffset? immutabilityPolicyExpiry, int? timeout, RequestConditions requestConditions, string immutabilityPolicyMode, string snapshot, string versionId, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("BlobRestClient.SetImmutabilityPolicy");
            scope.Start();
            try
            {
                if (requestConditions?.IfMatch != null)
                {
                    throw new ArgumentException("Service does not support the If-Match header for this operation.");
                }
                if (requestConditions?.IfNoneMatch != null)
                {
                    throw new ArgumentException("Service does not support the If-None-Match header for this operation.");
                }
                if (requestConditions?.IfModifiedSince != null)
                {
                    throw new ArgumentException("Service does not support the If-Modified-Since header for this operation.");
                }

                using HttpMessage message = CreateSetImmutabilityPolicyRequest(immutabilityPolicyExpiry, timeout, requestConditions, immutabilityPolicyMode, snapshot, versionId, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDownloadRequest(string snapshot, string versionId, int? timeout, string range, string leaseId, bool? rangeGetContentMd5, bool? rangeGetContentCrc64, string structuredBodyType, string encryptionKey, string encryptionKeySha256, string encryptionAlgorithm, string ifTags, RequestConditions requestConditions, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            if (snapshot != null)
            {
                uri.AppendQuery("snapshot", snapshot, true);
            }
            if (versionId != null)
            {
                uri.AppendQuery("versionid", versionId, true);
            }
            if (timeout != null)
            {
                uri.AppendQuery("timeout", TypeFormatters.ConvertToString(timeout), true);
            }
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200206304);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            if (_version != null)
            {
                request.Headers.SetValue("x-ms-version", _version);
            }
            if (range != null)
            {
                request.Headers.SetValue("Range", range);
            }
            if (leaseId != null)
            {
                request.Headers.SetValue("x-ms-lease-id", leaseId);
            }
            if (rangeGetContentMd5 != null)
            {
                request.Headers.SetValue("x-ms-range-get-content-md5", TypeFormatters.ConvertToString(rangeGetContentMd5));
            }
            if (rangeGetContentCrc64 != null)
            {
                request.Headers.SetValue("x-ms-range-get-content-crc64", TypeFormatters.ConvertToString(rangeGetContentCrc64));
            }
            if (structuredBodyType != null)
            {
                request.Headers.SetValue("x-ms-structured-body", structuredBodyType);
            }
            if (encryptionKey != null)
            {
                request.Headers.SetValue("x-ms-encryption-key", encryptionKey);
            }
            if (encryptionKeySha256 != null)
            {
                request.Headers.SetValue("x-ms-encryption-key-sha256", encryptionKeySha256);
            }
            if (encryptionAlgorithm != null)
            {
                request.Headers.SetValue("x-ms-encryption-algorithm", encryptionAlgorithm);
            }
            if (ifTags != null)
            {
                request.Headers.SetValue("x-ms-if-tags", ifTags);
            }
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            request.Headers.SetValue("Accept", "application/octet-stream");
            return message;
        }

        internal HttpMessage CreateSetImmutabilityPolicyRequest(DateTimeOffset? immutabilityPolicyExpiry, int? timeout, RequestConditions requestConditions, string immutabilityPolicyMode, string snapshot, string versionId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendQuery("comp", "immutabilityPolicies", true);
            if (timeout != null)
            {
                uri.AppendQuery("timeout", TypeFormatters.ConvertToString(timeout), true);
            }
            if (snapshot != null)
            {
                uri.AppendQuery("snapshot", snapshot, true);
            }
            if (versionId != null)
            {
                uri.AppendQuery("versionid", versionId, true);
            }
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Put;
            if (_version != null)
            {
                request.Headers.SetValue("x-ms-version", _version);
            }
            if (requestConditions != null)
            {
                request.Headers.Add(requestConditions, "R");
            }
            if (immutabilityPolicyExpiry != null)
            {
                request.Headers.SetValue("x-ms-immutability-policy-until-date", TypeFormatters.ConvertToString(immutabilityPolicyExpiry, SerializationFormat.DateTime_RFC7231));
            }
            if (immutabilityPolicyMode != null)
            {
                request.Headers.SetValue("x-ms-immutability-policy-mode", immutabilityPolicyMode);
            }
            return message;
        }
    }
}
