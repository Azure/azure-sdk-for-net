// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Recording.RecordingProxy;

/// <summary>
/// Options for the test proxy client.
/// </summary>
public class ProxyClientOptions : ClientPipelineOptions
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="http">The HTTP endpoint.</param>
    /// <exception cref="ArgumentNullException">The endpoint was null.</exception>
    /// <exception cref="ArgumentException">The endpoint was not absolute.</exception>
    public ProxyClientOptions(Uri http)
    {
        if (http == null) throw new ArgumentNullException(nameof(http));
        else if (!http.IsAbsoluteUri) throw new ArgumentException("URI must be absolute", nameof(http));

        HttpEndpoint = http;
    }

    /// <summary>
    /// The HTTP endpoint to use
    /// </summary>
    public Uri HttpEndpoint { get; }
}
