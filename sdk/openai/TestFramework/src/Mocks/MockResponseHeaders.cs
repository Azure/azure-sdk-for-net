// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace OpenAI.TestFramework.Mocks;

/// <summary>
/// Mock implementation of response headers.
/// </summary>
public class MockResponseHeaders : PipelineResponseHeaders
{
    private MockHeaders _headers = new();

    /// <inheritdoc />
    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        => _headers.GetEnumerator();

    /// <inheritdoc />
    public override bool TryGetValue(string name, out string? value)
        => _headers.TryGetValue(name, out value);

    /// <inheritdoc />
    public override bool TryGetValues(string name, out IEnumerable<string>? values)
        => _headers.TryGetValues(name, out values);
}
