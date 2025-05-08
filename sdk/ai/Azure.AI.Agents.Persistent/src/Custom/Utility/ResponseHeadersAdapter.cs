// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;

#nullable enable

namespace Azure.AI.Agents.Persistent;

/// <summary>
/// Adapts an Azure.Core ResponseHeaders to an SCM PipelineResponseHeaders.
/// </summary>
internal class ResponseHeadersAdapter : PipelineResponseHeaders
{
    private readonly ResponseHeaders _azureHeaders;

    public ResponseHeadersAdapter(ResponseHeaders azureHeaders)
    {
        _azureHeaders = azureHeaders;
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        foreach (HttpHeader header in _azureHeaders)
        {
            yield return new KeyValuePair<string, string>(header.Name, header.Value);
        }
    }

    public override bool TryGetValue(string name, out string? value)
        => _azureHeaders.TryGetValue(name, out value);

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
        => _azureHeaders.TryGetValue(name, out values);
}
