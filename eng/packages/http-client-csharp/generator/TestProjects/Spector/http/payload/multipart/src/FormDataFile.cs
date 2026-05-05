// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using Azure;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Payload.MultiPart;
using Payload.MultiPart.Models;

namespace Payload.MultiPart._FormData.File
{
    public partial class FormDataFile
    {
        /// <summary> Upload a file with content type <c>image/png</c>. </summary>
        public virtual Response UploadFileSpecificContentType(UploadFileSpecificContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return UploadFileSpecificContentType(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Upload a file with content type <c>image/png</c>. </summary>
        public virtual async Task<Response> UploadFileSpecificContentTypeAsync(UploadFileSpecificContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await UploadFileSpecificContentTypeAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Upload a file that requires a filename. </summary>
        public virtual Response UploadFileRequiredFilename(UploadFileRequiredFilenameRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return UploadFileRequiredFilename(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Upload a file that requires a filename. </summary>
        public virtual async Task<Response> UploadFileRequiredFilenameAsync(UploadFileRequiredFilenameRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await UploadFileRequiredFilenameAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Upload an array of files. </summary>
        public virtual Response UploadFileArray(UploadFileArrayRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return UploadFileArray(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Upload an array of files. </summary>
        public virtual async Task<Response> UploadFileArrayAsync(UploadFileArrayRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await UploadFileArrayAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
