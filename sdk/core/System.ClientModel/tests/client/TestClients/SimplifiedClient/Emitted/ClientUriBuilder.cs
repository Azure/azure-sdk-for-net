// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace ClientModel.ReferenceClients.SimplifiedClient;

internal partial class ClientUriBuilder
{
    private UriBuilder? _uriBuilder;
    private StringBuilder? _pathBuilder;
    private StringBuilder? _queryBuilder;

    public ClientUriBuilder()
    {
    }

    private UriBuilder UriBuilder => _uriBuilder ??= new UriBuilder();

    private StringBuilder PathBuilder => _pathBuilder ??= new StringBuilder(UriBuilder.Path);

    private StringBuilder QueryBuilder => _queryBuilder ??= new StringBuilder(UriBuilder.Query);

    public void Reset(Uri uri)
    {
        _uriBuilder = new UriBuilder(uri);
        _pathBuilder = new StringBuilder(UriBuilder.Path);
        _queryBuilder = new StringBuilder(UriBuilder.Query);
    }

    public void AppendPath(string value, bool escape)
    {
        if (escape)
        {
            value = Uri.EscapeDataString(value);
        }
        if (PathBuilder.Length > 0 && PathBuilder[PathBuilder.Length - 1] == '/' && value[0] == '/')
        {
            PathBuilder.Remove(PathBuilder.Length - 1, 1);
        }
        PathBuilder.Append(value);
        UriBuilder.Path = PathBuilder.ToString();
    }

    public void AppendQuery(string name, string value, bool escape)
    {
        if (QueryBuilder.Length > 0)
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

    public Uri ToUri()
    {
        if (_pathBuilder != null)
        {
            UriBuilder.Path = _pathBuilder.ToString();
        }
        if (_queryBuilder != null)
        {
            UriBuilder.Query = _queryBuilder.ToString();
        }
        return UriBuilder.Uri;
    }
}
