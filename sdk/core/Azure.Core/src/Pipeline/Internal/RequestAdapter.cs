// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.ServiceModel.Rest.Core;

namespace Azure.Core
{
    internal class RequestAdapter : Request
    {
        private readonly PipelineRequest _request;
        private RequestUriBuilder? _uriBuilder;

        public RequestAdapter(PipelineRequest request)
        {
            _request = request;
        }

        internal PipelineRequest PipelineRequest => _request;

        public override RequestMethod Method
        {
            get => RequestMethod.Parse(_request.Method);
            set => _request.Method = value.Method;
        }

        public override RequestUriBuilder Uri
        {
            get
            {
                if (_uriBuilder == null)
                {
                    _uriBuilder = new RequestUriBuilder();
                    _uriBuilder.SetPipelineRequest(_request);
                }
                return _uriBuilder;
            }
            set
            {
                Argument.AssertNotNull(value, nameof(value));
                _uriBuilder = value;
                _uriBuilder.SetPipelineRequest(_request);
            }
        }

        public override void Dispose() => _request.Dispose();

        protected internal override void AddHeader(string name, string value)
            // TODO: I think we want to add `Add` to Headers.
            => _request.Headers.Set(name, value);

        protected internal override bool ContainsHeader(string name)
            => _request.Headers.TryGetHeader(name, out _);

        protected internal override IEnumerable<HttpHeader> EnumerateHeaders()
        {
            _request.Headers.TryGetHeaders(out IEnumerable<MessageHeader<string, object>> headers);
            foreach (var header in headers)
            {
                yield return new HttpHeader(header.Name, GetHeaderValueString(header.Name, header.Value));
            }
        }

        // TODO: avoid copying this?
        private static string GetHeaderValueString(string name, object value) => value switch
        {
            string s => s,
            List<string> l => string.Join(",", l),
            _ => throw new InvalidOperationException($"Unexpected type for header {name}: {value?.GetType()}")
        };

        protected internal override bool RemoveHeader(string name)
        // TODO: can this fail?  If so, come back and return something sensible.
        {
            _request.Headers.Remove(name);
            return true;
        }

        protected internal override bool TryGetHeader(string name, [NotNullWhen(true)] out string? value)
            => _request.Headers.TryGetHeader(name, out value);

        protected internal override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string>? values)
        {
            // TODO: we can optimize this, come back to it
            _request.Headers.TryGetHeaders(out IEnumerable<MessageHeader<string, object>> headers);

            var header = headers.Where(h => h.Name == name);
            if (header == null || !header.Any())
            {
                values = null;
                return false;
            }

            values = header.First().Value switch
            {
                string s => new string[] { s },
                List<string> l => l,
                _ => throw new InvalidOperationException($"Unexpected type for header {name}: {header.First().Value?.GetType()}")
            };
            return true;
        }
    }
}
