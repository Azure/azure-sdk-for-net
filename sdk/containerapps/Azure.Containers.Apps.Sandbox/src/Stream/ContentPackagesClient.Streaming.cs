// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Containers.Apps.Sandbox
{
    [CodeGenSuppress("UploadContentPackage", typeof(BinaryData), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UploadContentPackageAsync", typeof(BinaryData), typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class ContentPackagesClient
    {
        /// <summary> Uploads a content package from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual Response<ContentPackage> UploadContentPackage(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = UploadContentPackage(requestContent, contentType, labels, cancellationToken.ToRequestContext());
            return Response.FromValue((ContentPackage)response, response);
        }

        /// <summary> Uploads a content package from a readable, seekable stream. The caller retains ownership of the stream. </summary>
        public virtual async Task<Response<ContentPackage>> UploadContentPackageAsync(Stream content, string contentType = default, string labels = default, CancellationToken cancellationToken = default)
        {
            using RequestContent requestContent = StreamRequestContent.Create(content);
            Response response = await UploadContentPackageAsync(requestContent, contentType, labels, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((ContentPackage)response, response);
        }
    }
}
