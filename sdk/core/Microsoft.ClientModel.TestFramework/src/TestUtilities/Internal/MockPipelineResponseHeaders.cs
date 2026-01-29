// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Microsoft.ClientModel.TestFramework.Mocks;

internal class MockPipelineResponseHeaders : PipelineResponseHeaders
{
    private readonly Dictionary<string, List<string>> _headers = new(System.StringComparer.OrdinalIgnoreCase);

    public MockPipelineResponseHeaders()
    {
    }

    public override IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        foreach (var header in _headers)
        {
            var combinedValue = string.Join(",", header.Value);
            yield return new KeyValuePair<string, string>(header.Key, combinedValue);
        }
    }

    public override bool TryGetValue(string name, out string? value)
    {
        if (_headers.TryGetValue(name, out List<string>? values) && values.Count > 0)
        {
            value = string.Join(",", values);
            return true;
        }

        value = null;
        return false;
    }

    public override bool TryGetValues(string name, out IEnumerable<string>? values)
    {
        if (_headers.TryGetValue(name, out List<string>? valuesList))
        {
            values = valuesList;
            return true;
        }

        values = null;
        return false;
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
