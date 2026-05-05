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

namespace Payload.MultiPart._FormData
{
    public partial class FormData
    {
        /// <summary> Test content-type: multipart/form-data. </summary>
        /// <param name="body"> The strongly-typed request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Response Basic(MultiPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return Basic(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data. </summary>
        /// <param name="body"> The strongly-typed request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Response> BasicAsync(MultiPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await BasicAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with wire names. </summary>
        public virtual Response WithWireName(MultiPartRequestWithWireName body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return WithWireName(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with wire names. </summary>
        public virtual async Task<Response> WithWireNameAsync(MultiPartRequestWithWireName body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await WithWireNameAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with optional parts. </summary>
        public virtual Response OptionalParts(MultiPartOptionalRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return OptionalParts(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with optional parts. </summary>
        public virtual async Task<Response> OptionalPartsAsync(MultiPartOptionalRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await OptionalPartsAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        public virtual Response FileArrayAndBasic(ComplexPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return FileArrayAndBasic(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        public virtual async Task<Response> FileArrayAndBasicAsync(ComplexPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await FileArrayAndBasicAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with a JSON part and a binary part. </summary>
        public virtual Response JsonPart(JsonPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return JsonPart(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with a JSON part and a binary part. </summary>
        public virtual async Task<Response> JsonPartAsync(JsonPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await JsonPartAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with multiple binary parts. </summary>
        public virtual Response BinaryArrayParts(BinaryArrayPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return BinaryArrayParts(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with multiple binary parts. </summary>
        public virtual async Task<Response> BinaryArrayPartsAsync(BinaryArrayPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await BinaryArrayPartsAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with a single profile image and an optional picture. </summary>
        public virtual Response MultiBinaryParts(MultiBinaryPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return MultiBinaryParts(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with a single profile image and an optional picture. </summary>
        public virtual async Task<Response> MultiBinaryPartsAsync(MultiBinaryPartsRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await MultiBinaryPartsAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data; verifies file name and content type metadata. </summary>
        public virtual Response CheckFileNameAndContentType(MultiPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return CheckFileNameAndContentType(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data; verifies file name and content type metadata. </summary>
        public virtual async Task<Response> CheckFileNameAndContentTypeAsync(MultiPartRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await CheckFileNameAndContentTypeAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Test content-type: multipart/form-data with an anonymous body. </summary>
        public virtual Response AnonymousModel(AnonymousModelRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return AnonymousModel(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with an anonymous body. </summary>
        public virtual async Task<Response> AnonymousModelAsync(AnonymousModelRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await AnonymousModelAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
