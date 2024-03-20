// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.AI.Language.Conversations;

// TODO: change namespace
namespace Azure.Core;

internal class ClientUriBuilder
{
    private UriBuilder? _uriBuilder;
    private StringBuilder? _pathBuilder;
    private StringBuilder? _queryBuilder;

    private UriBuilder UriBuilder => _uriBuilder ??= new();
    private StringBuilder PathBuilder => _pathBuilder ??= new(UriBuilder.Path);
    private StringBuilder QueryBuilder => _queryBuilder ??= new(UriBuilder.Query);

    public ClientUriBuilder()
    {
    }

    public void Reset(Uri uri)
    {
        _uriBuilder = new(uri);
        _pathBuilder = new(_uriBuilder.Path);
        _queryBuilder = new(_uriBuilder.Query);
    }

    public void AppendPath(string value, bool escape)
    {
        Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

        if (escape)
        {
            value = Uri.EscapeDataString(value);
        }

        PathBuilder.Append(value);
        UriBuilder.Path = PathBuilder.ToString();
    }

    public void AppendQuery(string name, string value, bool escape)
    {
        Argument.AssertNotNullOrWhiteSpace(name, nameof(name));
        Argument.AssertNotNullOrWhiteSpace(value, nameof(value));

        if (QueryBuilder.Length is 0)
        {
            QueryBuilder.Append('?');
        }
        else
        {
            QueryBuilder.Append('&');
        }

        if (escape)
        {
            value = Uri.EscapeDataString(value);
        }

        QueryBuilder.Append(name);
        QueryBuilder.Append('=');
        QueryBuilder.Append(value);
    }

    public void AppendPath(bool value, bool escape = false)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(float value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(double value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(int value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(byte[] value, string format, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendPath(IEnumerable<string> value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(DateTimeOffset value, string format, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendPath(TimeSpan value, string format, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendPath(Guid value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendPath(long value, bool escape = true)
    {
        AppendPath(TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, bool value, bool escape = false)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, float value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, DateTimeOffset value, string format, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendQuery(string name, TimeSpan value, string format, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendQuery(string name, double value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, decimal value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, int value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, long value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, TimeSpan value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQuery(string name, byte[] value, string format, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
    }

    public void AppendQuery(string name, Guid value, bool escape = true)
    {
        AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
    }

    public void AppendQueryDelimited<T>(string name, IEnumerable<T> value, string delimiter, bool escape = true)
    {
        var stringValues = value.Select(v => TypeFormatters.ConvertToString(v));
        AppendQuery(name, string.Join(delimiter, stringValues), escape);
    }

    public void AppendQueryDelimited<T>(string name, IEnumerable<T> value, string delimiter, string format, bool escape = true)
    {
        IEnumerable<string> stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
        AppendQuery(name, string.Join(delimiter, stringValues), escape);
    }

    public Uri ToUri()
    {
        if (_pathBuilder is not null)
        {
            UriBuilder.Path = _pathBuilder.ToString();
        }

        if (_queryBuilder is not null)
        {
            UriBuilder.Query = _queryBuilder.ToString();
        }

        return UriBuilder.Uri;
    }
}
