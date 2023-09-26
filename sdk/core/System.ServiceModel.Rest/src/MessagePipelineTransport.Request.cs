// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        public MessagePipelineRequest()
        {
        }

        public override void SetContent(RequestBody content)
            => _content = content;

        public override void SetHeaderValue(string name, string value)
        {
            throw new NotImplementedException();
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
