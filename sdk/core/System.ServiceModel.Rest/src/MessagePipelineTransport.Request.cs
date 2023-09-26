// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Rest.Core;
using System.ServiceModel.Rest.Experimental.Core;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
public partial class MessagePipelineTransport : PipelineTransport<PipelineMessage>, IDisposable
{
    private sealed class MessagePipelineRequest : PipelineRequest
    {
        private Uri? _uri;
        private RequestBody? _content;

        // TODO: optimize
        // Azure.Core has ArrayBackedPropertyBag and IgnoreCaseString
        // TODO: Azure.Core header dictionary stores a collection of values for a header.
        private Dictionary<string, string>? _headers;

        public MessagePipelineRequest()
        {
        }

        public override void SetContent(RequestBody content)
            => _content = content;

        public override void SetHeaderValue(string name, string value)
        {
            _headers ??= new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            _headers[name] = value;
        }

        public override void SetUri(RequestUri uri)
            => _uri = uri.ToUri();

        public override bool TryGetContent(out RequestBody? content)
        {
            if (_content == null)
            {
                content = default;
                return false;
            }

            content = _content;
            return true;
        }

        public override bool TryGetUri(out Uri? uri)
        {
            if (_uri == null)
            {
                uri = default;
                return false;
            }

            uri = _uri;
            return true;
        }

        internal override void SetRequestHeaders(HttpRequestMessage request)
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

        public override void Dispose()
        {
            // TODO: get this pattern right
            if (_content is not null)
            {
                RequestBody body = _content as RequestBody;
                body.Dispose();
            }
        }
    }
}
