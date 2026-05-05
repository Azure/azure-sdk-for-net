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

namespace Payload.MultiPart._FormData.HttpParts.ContentType
{
    public partial class FormDataHttpPartsContentType
    {
        /// <summary> Test content-type: multipart/form-data with a specific image/jpg part. </summary>
        public virtual Response ImageJpegContentType(FileWithHttpPartSpecificContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return ImageJpegContentType(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with a specific image/jpg part. </summary>
        public virtual async Task<Response> ImageJpegContentTypeAsync(FileWithHttpPartSpecificContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await ImageJpegContentTypeAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data; the part requires a content type. </summary>
        public virtual Response RequiredContentType(FileWithHttpPartRequiredContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return RequiredContentType(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data; the part requires a content type. </summary>
        public virtual async Task<Response> RequiredContentTypeAsync(FileWithHttpPartRequiredContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await RequiredContentTypeAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with optional content type on the part. </summary>
        public virtual Response OptionalContentType(FileWithHttpPartOptionalContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return OptionalContentType(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with optional content type on the part. </summary>
        public virtual async Task<Response> OptionalContentTypeAsync(FileWithHttpPartOptionalContentTypeRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await OptionalContentTypeAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
