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

namespace Payload.MultiPart._FormData.HttpParts
{
    public partial class FormDataHttpParts
    {
        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        public virtual Response JsonArrayAndFileArray(ComplexHttpPartsModelRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return JsonArrayAndFileArray(requestContent, content.MediaType, cancellationToken.ToRequestContext());
        }

        /// <summary> Test content-type: multipart/form-data for mixed scenarios. </summary>
        public virtual async Task<Response> JsonArrayAndFileArrayAsync(ComplexHttpPartsModelRequest body, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(body, nameof(body));

            MultiPartFormContent content = body.ToMultipartContent();
            using RequestContent requestContent = RequestContent.Create(content);
            return await JsonArrayAndFileArrayAsync(requestContent, content.MediaType, cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }
    }
}
