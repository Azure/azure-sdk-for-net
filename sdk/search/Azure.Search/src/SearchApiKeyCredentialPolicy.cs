// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Search
{
    /// <summary>
    /// Pipeline policy used to authenticate requests to the Search Service by
    /// adding the Search API key.
    /// </summary>
    /// <remarks>
    /// This derives from <see cref="HttpPipelineSynchronousPolicy"/> because
    /// we're only setting a header which doesn't have any async code paths.
    /// If in the future we need to add additional features, we can just
    /// override the Process/ProcessAsync virtual methods.
    /// </remarks>
    internal class SearchApiKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Gets the <see cref="SearchApiKeyCredential"/> used to authenticate
        /// requests.
        /// </summary>
        public SearchApiKeyCredential Credential { get; }

        /// <summary>
        /// Creates a new instance of the
        /// <see cref="SearchApiKeyCredentialPolicy"/> class.
        /// </summary>
        /// <param name="credential">
        /// The <see cref="SearchApiKeyCredential"/> used to authenticate
        /// requests.
        /// </param>
        public SearchApiKeyCredentialPolicy(SearchApiKeyCredential credential)
        {
            Debug.Assert(credential != null);
            Credential = credential;
        }

        /// <summary>
        /// Apply the API key used to authenticate each request.
        /// </summary>
        /// <param name="message">The request message.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);
            message.Request.Headers.SetValue(Constants.ApiKeyHeaderName, Credential.ApiKey);
        }
    }
}
