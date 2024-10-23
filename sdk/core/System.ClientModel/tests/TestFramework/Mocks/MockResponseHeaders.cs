// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace ClientModel.Tests.Mocks;

public class MockResponseHeaders : PipelineResponseHeaders
{
    private readonly Dictionary<string, string> _headers;

    public MockResponseHeaders(Dictionary<string, string>? headers = default)
    {
        _headers = headers ?? new Dictionary<string, string>();
    }

    public void SetHeader(string name, string value)
        => _headers[name] = value;

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        IEnumerator<KeyValuePair<string, string>> enumerator = _headers.GetEnumerator();
        return enumerator;
    }

    public override bool TryGetValue(string name, out string? value)
    {
        return _headers.TryGetValue(name, out value);
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        throw new NotImplementedException();
    }
}
