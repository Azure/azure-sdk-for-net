// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent
{
    [CodeGenClient("Files")]
    public partial class PersistentAgentsFiles
    {
        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PersistentAgentFileInfo> UploadFile(
            string filePath,
            PersistentAgentFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = System.IO.File.OpenRead(filePath);
            return UploadFile(stream, purpose, filePath, cancellationToken);
        }

        /// <summary>
        /// Uploads a file from a local file path accessible to <see cref="System.IO.File"/>.
        /// </summary>
        /// <param name="filePath"> The local file path. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PersistentAgentFileInfo>> UploadFileAsync(
            string filePath,
            PersistentAgentFilePurpose purpose,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            using FileStream stream = System.IO.File.OpenRead(filePath);
            return await UploadFileAsync(stream, purpose, filePath, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<Response<PersistentAgentFileInfo>> UploadFileAsync(Stream data, PersistentAgentFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UploadFileAsync(content, content.ContentType, context).ConfigureAwait(false);
            return Response.FromValue(PersistentAgentFileInfo.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="data"> The file data, in bytes. </param>
        /// <param name="purpose"> The intended purpose of the uploaded file. Use `assistants` for Agents and Message files, `vision` for Agents image file inputs, `batch` for Batch API, and `fine-tune` for Fine-tuning. </param>
        /// <param name="filename"> The name of the file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual Response<PersistentAgentFileInfo> UploadFile(Stream data, PersistentAgentFilePurpose purpose, string filename, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));

            UploadFileRequest uploadFileRequest = new UploadFileRequest(data, purpose, filename, null);
            using MultipartFormDataRequestContent content = uploadFileRequest.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UploadFile(content, content.ContentType, context);
            return Response.FromValue(PersistentAgentFileInfo.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="body"> Multipart body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        internal virtual async Task<Response<PersistentAgentFileInfo>> UploadFileAsync(UploadFileRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UploadFileAsync(content, content.ContentType, context).ConfigureAwait(false);
            return Response.FromValue(PersistentAgentFileInfo.FromResponse(response), response);
        }

        /// <summary> Uploads a file for use by other operations. </summary>
        /// <param name="body"> Multipart body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        internal virtual Response<PersistentAgentFileInfo> UploadFile(UploadFileRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            using MultipartFormDataRequestContent content = body.ToMultipartRequestContent();
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UploadFile(content, content.ContentType, context);
            return Response.FromValue(PersistentAgentFileInfo.FromResponse(response), response);
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Limits files in the response to those with the specified purpose. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<PersistentAgentFileInfo>> GetFiles(PersistentAgentFilePurpose? purpose = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetFiles");
            scope.Start();
            Response<InternalFileListResponse> baseResponse = InternalListFiles(purpose, cancellationToken);
            return Response.FromValue(baseResponse.Value?.Data, baseResponse.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Limits files in the response to those with the specified purpose. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<PersistentAgentFileInfo>>> GetFilesAsync(
            PersistentAgentFilePurpose? purpose = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.GetFiles");
            scope.Start();
            Response<InternalFileListResponse> baseResponse = await InternalListFilesAsync(purpose, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(baseResponse.Value?.Data, baseResponse.GetRawResponse());
        }

        /// <summary> Delete a previously uploaded file. </summary>
        /// <param name="fileId"> The ID of the file to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> DeleteFile(string fileId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteFile");
            scope.Start();
            Response<InternalFileDeletionStatus> baseResponse = InternalDeleteFile(fileId, cancellationToken);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }

        /// <summary> Delete a previously uploaded file. </summary>
        /// <param name="fileId"> The ID of the file to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> DeleteFileAsync(string fileId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("PersistentAgentsClient.DeleteFile");
            scope.Start();
            Response<InternalFileDeletionStatus> baseResponse = await InternalDeleteFileAsync(fileId, cancellationToken).ConfigureAwait(false);
            bool simplifiedValue =
                baseResponse.GetRawResponse() != null
                && !baseResponse.GetRawResponse().IsError
                && baseResponse.Value != null
                && baseResponse.Value.Deleted;
            return Response.FromValue(simplifiedValue, baseResponse.GetRawResponse());
        }
    }
}
