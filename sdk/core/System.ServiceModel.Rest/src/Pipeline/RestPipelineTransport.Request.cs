// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;

namespace System.ServiceModel.Rest.Core.Pipeline;

public partial class RestPipelineTransport
{
    private sealed class RestPipelineTransportRequest : PipelineRequest
    {
        private HttpMethod? _method;
        private Uri? _uri;

        // TODO: optimize
        // Azure.Core has ArrayBackedPropertyBag and IgnoreCaseString
        // TODO: Azure.Core header dictionary stores a collection of values for a header.
        private Dictionary<string, string>? _headers;

        public override void SetContent(BinaryData content)
        {
            throw new NotImplementedException();
        }

        public override void SetHeaderValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public override void SetMethod(string method)
            => _method = new HttpMethod(method);

        public override Uri SetUri(Uri uri)
            => _uri = uri;
    }
}
