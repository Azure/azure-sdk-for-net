// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.TestFramework;

internal class MockPipelineResponseHeaders : PipelineResponseHeaders
{
    private readonly Dictionary<string, List<string>> _headers;

    public MockPipelineResponseHeaders(Dictionary<string, List<string>> headers)
    {
        _headers = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public override bool TryGetValue(string name, out string? value)
    {
        throw new NotImplementedException();
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValuesList(string name, out List<string>? values)
    {
        throw new NotImplementedException();
    }

    public void SetHeader(string name, string value)
    {
        if (!_headers.TryGetValue(name, out List<string>? values))
        {
            _headers[name] = values = new List<string>();
        }
        values.Add(value);
    }
}
