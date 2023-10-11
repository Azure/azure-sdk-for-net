// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.ContentSafety
{
    /// <summary> The ContentSafety service client. </summary>
    public partial class ContentSafetyClient
    {
        /// <summary>
        /// Create Or Update Text Blocklist.
        /// </summary>
        /// <param name="blocklistName"> Text blocklist name. </param>
        /// <param name="resource"> The content to send as the body of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Updates a text blocklist, if blocklistName does not exist, create a new blocklist. </remarks>
        public virtual async Task<Response<TextBlocklist>> CreateOrUpdateTextBlocklistAsync(string blocklistName, TextBlocklist resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(blocklistName, nameof(blocklistName));
            Argument.AssertNotNull(resource, nameof(resource));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = resource.ToRequestContent();
            Response response = await CreateOrUpdateTextBlocklistAsync(blocklistName, content, context).ConfigureAwait(false);
            return Response.FromValue(TextBlocklist.FromResponse(response), response);
        }

        /// <summary>
        /// Create Or Update Text Blocklist.
        /// </summary>
        /// <param name="blocklistName"> Text blocklist name. </param>
        /// <param name="resource"> The content to send as the body of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Updates a text blocklist, if blocklistName does not exist, create a new blocklist. </remarks>
        public virtual Response<TextBlocklist> CreateOrUpdateTextBlocklist(string blocklistName, TextBlocklist resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(blocklistName, nameof(blocklistName));
            Argument.AssertNotNull(resource, nameof(resource));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = resource.ToRequestContent();
            Response response = CreateOrUpdateTextBlocklist(blocklistName, content, context);
            return Response.FromValue(TextBlocklist.FromResponse(response), response);
        }
    }
}
