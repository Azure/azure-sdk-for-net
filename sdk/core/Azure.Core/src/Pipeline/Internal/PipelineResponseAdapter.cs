// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.ClientModel.Core;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class PipelineResponseAdapter : MessageResponse
    {
        private readonly Response _response;

        public PipelineResponseAdapter(Response response)
        {
            _response = response;
        }

        public override int Status => _response.Status;

        public override string ReasonPhrase => _response.ReasonPhrase;

        public override RequestBody? Body
        {
            get
            {
                if (_response.ContentStream is null)
                {
                    return null;
                }

                return new ResponseContent(_response);
            }

            protected set
            {
                if (value is not null)
                {
                    _response.ContentStream = (Stream)value;
                }
            }
        }

        // TODO: implement
        public override MessageHeaders Headers => throw new NotSupportedException();

        public override void Dispose()
        {
            var response = _response;
            response?.Dispose();
        }
    }
}
