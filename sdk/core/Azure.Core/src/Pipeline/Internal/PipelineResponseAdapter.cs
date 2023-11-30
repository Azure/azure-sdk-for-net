// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;

namespace Azure.Core
{
    internal class PipelineResponseAdapter : PipelineResponse
    {
        private readonly Response _response;

        public PipelineResponseAdapter(Response response)
        {
            _response = response;
        }

        public override int Status => _response.Status;

        public override string ReasonPhrase => _response.ReasonPhrase;

        public override Stream? ContentStream
        {
            get => _response.ContentStream;
            set => _response.ContentStream = value;
        }

        public override void Dispose()
        {
            var response = _response;
            response?.Dispose();
        }

        protected override MessageHeaders GetHeadersCore()
        {
            throw new NotImplementedException();
        }
    }
}
