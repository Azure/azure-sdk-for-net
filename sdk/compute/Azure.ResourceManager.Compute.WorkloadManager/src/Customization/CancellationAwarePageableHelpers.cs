// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Compute.WorkloadManager
{
    // Remove this workaround and the paging customizations once
    // https://github.com/Azure/azure-sdk-for-net/issues/63508 is fixed in the pinned generator.
    internal static class CancellationAwarePageableHelpers
    {
        internal static async IAsyncEnumerable<Page<T>> GetPagesAsync<T>(
            HttpPipeline pipeline,
            ClientDiagnostics diagnostics,
            string diagnosticScope,
            RequestContext context,
            Func<Uri, HttpMessage> createRequest,
            Func<Response, (IReadOnlyList<T> Values, Uri NextLink)> readResponse,
            string continuationToken,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            // The compiler combines this method token with the enumeration token without
            // mutating the captured RequestContext or sharing a linked source between enumerations.
            Uri nextLink = continuationToken != null ? new Uri(continuationToken, UriKind.RelativeOrAbsolute) : null;
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                HttpMessage message = createRequest(nextLink);
                Response response;
                using (DiagnosticScope scope = diagnostics.CreateScope(diagnosticScope))
                {
                    scope.Start();
                    try
                    {
                        // Keep the original context for request construction/error behavior and
                        // pass only the effective cancellation token separately to the pipeline.
                        await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                        response = message.Response;
                        if (response.IsError && ((context?.ErrorOptions ?? ErrorOptions.Default) & ErrorOptions.NoThrow) != ErrorOptions.NoThrow)
                            throw new RequestFailedException(response);
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }

                var result = readResponse(response);
                nextLink = result.NextLink;
                yield return Page<T>.FromValues(result.Values, nextLink?.IsAbsoluteUri == true ? nextLink.AbsoluteUri : nextLink?.OriginalString, response);
                if (nextLink == null)
                    yield break;
            }
        }
    }
}
