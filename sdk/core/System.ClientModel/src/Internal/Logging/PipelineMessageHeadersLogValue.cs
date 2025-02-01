// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace System.ClientModel.Internal;

internal class PipelineMessageHeadersLogValue : IReadOnlyList<KeyValuePair<string, string>>
{
    private readonly PipelineRequestHeaders? _requestHeaders;
    private readonly PipelineResponseHeaders? _responseHeaders;
    private readonly PipelineMessageSanitizer _sanitizer;

    private List<KeyValuePair<string, string>>? _values;
    private string? _formatted;

    public PipelineMessageHeadersLogValue(PipelineRequestHeaders headers, PipelineMessageSanitizer sanitizer)
    {
        _sanitizer = sanitizer;
        _requestHeaders = headers;
    }

    public PipelineMessageHeadersLogValue(PipelineResponseHeaders headers, PipelineMessageSanitizer sanitizer)
    {
        _sanitizer = sanitizer;
        _responseHeaders = headers;
    }

    private List<KeyValuePair<string, string>> Values
    {
        get
        {
            if (_values == null)
            {
                var values = new List<KeyValuePair<string, string>>();

                if (_requestHeaders != null)
                {
                    foreach (KeyValuePair<string, string> kvp in _requestHeaders)
                    {
                        values.Add(new KeyValuePair<string, string>(kvp.Key, _sanitizer.SanitizeHeader(kvp.Key, kvp.Value)));
                    }
                }
                else if (_responseHeaders != null)
                {
                    foreach (KeyValuePair<string, string> kvp in _responseHeaders)
                    {
                        values.Add(new KeyValuePair<string, string>(kvp.Key, _sanitizer.SanitizeHeader(kvp.Key, kvp.Value)));
                    }
                }

                _values = values;
            }

            return _values;
        }
    }

    public KeyValuePair<string, string> this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return Values[index];
        }
    }

    public int Count => Values.Count;

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    public override string ToString()
    {
        if (_formatted == null)
        {
            var builder = new StringBuilder();

            foreach (KeyValuePair<string, string> header in Values)
            {
                builder.Append(header.Key);
                builder.Append(':');
                builder.Append(_sanitizer.SanitizeHeader(header.Key, header.Value));
                builder.Append(Environment.NewLine);
            }

            _formatted = builder.ToString();
        }

        return _formatted;
    }
}
