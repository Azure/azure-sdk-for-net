// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.ServiceModel.Rest.Core;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class PipelineResponseAdapter : PipelineResponse
    {
        private readonly Response _response;
        private readonly ResponseContent _content;

        public PipelineResponseAdapter(Response response)
        {
            _response = response;
            _content = new ResponseContent(response);
        }

        public override int Status => _response.Status;

        public override string ReasonPhrase => _response.ReasonPhrase;

        public override MessageContent Content
        {
            get => _content;
            protected set => _response.ContentStream = value;
        }

        // TODO: implement
        public override MessageHeaders Headers => throw new NotImplementedException();

        public override void Dispose()
        {
            var response = _response;
            response?.Dispose();
        }
    }
}
