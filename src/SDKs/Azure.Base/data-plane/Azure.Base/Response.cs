// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Buffers;
using Azure.Base.Http;
using System;
using System.Buffers.Text;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Azure
{
    public readonly struct Response: IDisposable
    {
        private readonly HttpPipelineResponse _httpResponse;

        public Response(HttpPipelineResponse httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException(nameof(httpResponse));
            }

            _httpResponse = httpResponse;
        }

        public int Status => _httpResponse.Status;

        public Stream ContentStream => _httpResponse.ResponseContentStream;

        public bool TryGetHeader(string name, out string values)
        {
            return _httpResponse.TryGetHeader(name, out values);
        }

        public void Dispose() => _httpResponse.Dispose();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => _httpResponse.ToString();
    }
}
