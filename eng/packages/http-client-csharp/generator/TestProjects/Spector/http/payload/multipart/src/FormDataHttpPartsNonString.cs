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

namespace Payload.MultiPart._FormData.HttpParts.NonString
{
    public partial class FormDataHttpPartsNonString
    {
        /// <summary> Test content-type: multipart/form-data with a non-string (float) part. </summary>
        public virtual Response Float(FloatRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return Float(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data with a non-string (float) part. </summary>
        public virtual async Task<Response> FloatAsync(FloatRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await FloatAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
