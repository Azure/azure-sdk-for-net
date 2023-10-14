// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest.Core;

namespace Azure.Core
{
    // Backwards adapter
    internal class PipelineRequestAdapter : PipelineRequest
    {
        private readonly Request _request;

        public PipelineRequestAdapter(Request request)
        {
            _request = request;
        }

        public override string Method
        {
            get => _request.Method.Method;
            set => _request.Method = RequestMethod.Parse(value);
        }
        public override Uri Uri
        {
            get => _request.Uri.ToUri();
            set => _request.Uri.Reset(value);
        }

        public override RequestBody? Content
        {
            get => _request.Content;
            set => _request.Content = (RequestContent?)value;
        }

        // TODO: implement this, will need a new adapter for headers
        public override MessageHeaders Headers => throw new NotImplementedException();

        public override void Dispose()
        {
            var request = _request;
            request?.Dispose();
        }
    }
}
