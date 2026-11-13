// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Files.Shares
{
    // CUSTOM:
    // - Suppress generated Download methods in favor of custom implementations that return Stream.
    [CodeGenSuppress("Download", typeof(int?), typeof(string), typeof(bool?), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadAsync", typeof(int?), typeof(string), typeof(bool?), typeof(string), typeof(string), typeof(CancellationToken))]
    internal partial class FileRestClient
    {
        /// <summary> Reads or downloads a file from the system, including its metadata and properties. </summary>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. </param>
        /// <param name="range"> Return only the bytes of the file in the specified range. </param>
        /// <param name="rangeGetContentMD5"> When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="structuredBodyType"> Specifies the response content should be returned as a structured message and specifies the message schema version and properties. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual Response<Stream> Download(int? timeout = default, string range = default, bool? rangeGetContentMD5 = default, string leaseId = default, string structuredBodyType = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("FileRestClient.Download");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadRequest(timeout, range, rangeGetContentMD5, leaseId, structuredBodyType, context);
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

        /// <summary> Reads or downloads a file from the system, including its metadata and properties. </summary>
        /// <param name="timeout"> The timeout parameter is expressed in seconds. </param>
        /// <param name="range"> Return only the bytes of the file in the specified range. </param>
        /// <param name="rangeGetContentMD5"> When this header is set to true and specified together with the Range header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MB in size. </param>
        /// <param name="leaseId"> If specified, the operation only succeeds if the resource's lease is active and matches this ID. </param>
        /// <param name="structuredBodyType"> Specifies the response content should be returned as a structured message and specifies the message schema version and properties. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        public virtual async Task<Response<Stream>> DownloadAsync(int? timeout = default, string range = default, bool? rangeGetContentMD5 = default, string leaseId = default, string structuredBodyType = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("FileRestClient.Download");
            scope.Start();
            try
            {
                RequestContext context = cancellationToken.ToRequestContext();
                using HttpMessage message = CreateDownloadRequest(timeout, range, rangeGetContentMD5, leaseId, structuredBodyType, context);
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
    }
}
