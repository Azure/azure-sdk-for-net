// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ClientModel.Internal;

namespace Azure.Core
{
    /// <summary>
    /// Provides a custom builder for Uniform Resource Identifiers (URIs) and modifies URIs for the <see cref="System.Uri" /> class.
    /// </summary>
    public class RequestUriBuilder : RequestUri
    {
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class RequestUriBuilderAdapter : RequestUriBuilder
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly RequestUri _uri;
        public RequestUriBuilderAdapter(RequestUri uri)
        {
            _uri = uri;
        }

        public override string? Scheme
        {
            get => _uri.Scheme;
            set => _uri.Scheme = value;
        }

        public override string? Host
        {
            get => _uri.Host;
            set => _uri.Host = value;
        }

        public override int Port
        {
            get => _uri.Port;
            set => _uri.Port = value;
        }

        public override string Path
        {
            get => _uri.Path;
            set => _uri.Path = value;
        }

        public override string Query
        {
            get => _uri.Query;
            set => _uri.Query = value;
        }

        public override void AppendPath(string value)
            => _uri.AppendPath(value);

        public override void AppendPath(string value, bool escape)
            => _uri.AppendPath(value, escape);

        public override void AppendPath(ReadOnlySpan<char> value, bool escape)
            => _uri.AppendPath(value, escape);

        public override void AppendQuery(ReadOnlySpan<char> name, ReadOnlySpan<char> value, bool escapeValue)
            => _uri.AppendQuery(name, value, escapeValue);

        public override void AppendQuery(string name, string value)
            => _uri.AppendQuery(name, value);

        public override void AppendQuery(string name, string value, bool escapeValue)
            => _uri.AppendQuery(name, value, escapeValue);

        public override void Reset(Uri value)
            => _uri.Reset(value);

        public override Uri ToUri()
            => _uri.ToUri();
    }
}
