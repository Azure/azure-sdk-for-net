// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Agents.Persistent.Tests;

internal class CustomHeadersPolicy : HttpPipelineSynchronousPolicy
{
    private readonly Dictionary<string, string> _headers = [];
    /// <summary>
    /// Create a new custom header policy with x-ms-enable-preview true header.
    /// </summary>
    public CustomHeadersPolicy()
    {
        _headers.Add("x-ms-enable-preview", "true");
    }

    /// <summary>
    /// Add the custom header.
    /// </summary>
    /// <param name="name">The header name.</param>
    /// <param name="value">The header value.</param>
    public void AddHeader(string name, string value)
    {
        _headers.Add(name, value);
    }

    /// <summary>
    /// Apply policy to the request.
    /// </summary>
    /// <param name="message">The message to apply policy to.</param>
    public override void OnSendingRequest(HttpMessage message)
    {
        foreach (KeyValuePair<string, string> header in _headers) {
            message.Request.Headers.Add(header.Key, header.Value);
        }
    }
}
