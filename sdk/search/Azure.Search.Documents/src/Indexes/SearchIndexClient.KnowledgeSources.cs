// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Indexes
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to manage knowledge sources on a Search service.
    /// </summary>
    public partial class SearchIndexClient
    {
        #region KnowledgeSources Operations

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BinaryData> GetKnowledgeSources(RequestContext context) =>
            GetKnowledgeSources(search: default, pageSize: default, searchType: default, context: context);

        /// <summary> Lists all knowledge sources available for a search service. </summary>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The response returned from the service. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BinaryData> GetKnowledgeSourcesAsync(RequestContext context) =>
            GetKnowledgeSourcesAsync(search: default, pageSize: default, searchType: default, context: context);

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeSource> CreateKnowledgeSource(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = CreateKnowledgeSource(knowledgeSource, cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>ls]
        public virtual async Task<Response<KnowledgeSource>> CreateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            Response response = await CreateKnowledgeSourceAsync(knowledgeSource, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSource)response, response);
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeSource> CreateOrUpdateKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return CreateOrUpdateKnowledgeSource(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken);
        }

        /// <summary> Creates a new knowledge source or updates an knowledge source if it already exists. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to create or update. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <exception cref="ArgumentNullException"><paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<KnowledgeSource>> CreateOrUpdateKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await CreateOrUpdateKnowledgeSourceAsync(knowledgeSource?.Name, knowledgeSource, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response DeleteKnowledgeSource(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return DeleteKnowledgeSource(knowledgeSource?.Name, matchConditions, cancellationToken);
        }

        /// <summary> Deletes an existing knowledge source. </summary>
        /// <param name="knowledgeSource"> The definition of the knowledge source to delete. </param>
        /// <param name="onlyIfUnchanged">
        /// True to throw a <see cref="RequestFailedException"/> if the <see cref="KnowledgeSource.ETag"/> does not match the current service version;
        /// otherwise, the current service version will be overwritten.
        /// </param>
        /// <param name="cancellationToken">Optional <see cref="CancellationToken"/> to propagate notifications that the operation should be canceled.</param>
        /// <returns>The <see cref="Response"/> from the server.</returns>
        /// <exception cref="ArgumentNullException"> <paramref name="knowledgeSource"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response> DeleteKnowledgeSourceAsync(KnowledgeSource knowledgeSource, bool onlyIfUnchanged = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(knowledgeSource, nameof(knowledgeSource));

            MatchConditions matchConditions = onlyIfUnchanged ? new MatchConditions { IfMatch = knowledgeSource?.ETag } : null;
            return await DeleteKnowledgeSourceAsync(knowledgeSource?.Name, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Uploads a file to a File knowledge source for processing and indexing. </summary>
        /// <param name="sourceName"> The name of the knowledge source. </param>
        /// <param name="fileName"> The name to associate with the uploaded file, such as <c>installation-guide.pdf</c>. </param>
        /// <param name="file"> The file content to upload. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/>, <paramref name="fileName"/> or <paramref name="file"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sourceName"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        [ForwardsClientCalls]
        public virtual Response<KnowledgeSourceFile> UploadKnowledgeSourceFile(string sourceName, string fileName, BinaryData file, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(file, nameof(file));

            Response result = UploadKnowledgeSourceFile(sourceName, CreateContentDisposition(fileName), RequestContent.Create(file), cancellationToken.ToRequestContext());
            return Response.FromValue((KnowledgeSourceFile)result, result);
        }

        /// <summary> Uploads a file to a File knowledge source for processing and indexing. </summary>
        /// <param name="sourceName"> The name of the knowledge source. </param>
        /// <param name="fileName"> The name to associate with the uploaded file, such as <c>installation-guide.pdf</c>. </param>
        /// <param name="file"> The file content to upload. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceName"/>, <paramref name="fileName"/> or <paramref name="file"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sourceName"/> or <paramref name="fileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<KnowledgeSourceFile>> UploadKnowledgeSourceFileAsync(string sourceName, string fileName, BinaryData file, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sourceName, nameof(sourceName));
            Argument.AssertNotNullOrEmpty(fileName, nameof(fileName));
            Argument.AssertNotNull(file, nameof(file));

            Response result = await UploadKnowledgeSourceFileAsync(sourceName, CreateContentDisposition(fileName), RequestContent.Create(file), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((KnowledgeSourceFile)result, result);
        }

        /// <summary>
        /// Builds the <c>Content-Disposition</c> header value required by the service, which must follow
        /// the format <c>attachment; filename="&lt;filename&gt;"</c>.
        /// </summary>
        /// <param name="fileName"> The name to associate with the uploaded file. </param>
        /// <returns> The <c>Content-Disposition</c> header value. </returns>
        private static string CreateContentDisposition(string fileName)
        {
            if (fileName.IndexOf('\r') >= 0 || fileName.IndexOf('\n') >= 0)
            {
                throw new ArgumentException("File name cannot contain carriage return or line feed characters.", nameof(fileName));
            }

            // Escape backslashes and quotes so they survive the quoted-string form of the header.
            string escapedFileName = fileName.Replace("\\", "\\\\").Replace("\"", "\\\"");
            return $"attachment; filename=\"{escapedFileName}\"";
        }

        #endregion
    }
}
