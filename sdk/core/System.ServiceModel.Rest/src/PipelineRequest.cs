﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core;

public class PipelineRequest
{
    private HttpMethod? _method;
    private Uri? _uri;

    // TODO: optimize
    // Azure.Core has ArrayBackedPropertyBag and IgnoreCaseString
    // TODO: Azure.Core header dictionary stores a collection of values for a header.
    private Dictionary<string, string>? _headers;

    public PipelineRequest()
    {
    }

    // TODO: generator constraint requires us to make this settable, revisit later?
    public virtual HttpMethod Method
    {
        get
        {
            if (_method is null)
            {
                throw new InvalidOperationException("'Method' must be initialized before use.");
            }

            return _method;
        }

        set => _method = value;
    }

    public virtual Uri Uri
    {
        get
        {
            if (_uri is null)
            {
                throw new InvalidOperationException("'Uri' must be initialized before use.");
            }

            return _uri;
        }

        set => _uri = value;
    }

    // Note: we don't dipose the request's Content, because for protocol methods
    // the caller creates these.
    // TODO: do we do the right thing for convenience methods?
    public virtual RequestBody? Content { get; set; }

    public virtual void SetHeaderValue(string name, string value)
    {
        _headers ??= new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        _headers[name] = value;
    }

    internal virtual void SetTransportHeaders(HttpRequestMessage request)
    {
        if (_headers is null) return;

        foreach (var header in _headers)
        {
            // TODO: optimize
            if (!request.Headers.TryAddWithoutValidation(header.Key, header.Value))
            {
                if (request.Content != null &&
                    !request.Content.Headers.TryAddWithoutValidation(header.Key, header.Value))
                {
                    throw new InvalidOperationException($"Unable to add header {header.Key} to header collection.");
                }
            }
        }
    }
}