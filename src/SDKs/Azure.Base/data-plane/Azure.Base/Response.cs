// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Pipeline;
using System;
using System.ComponentModel;
using System.IO;

namespace Azure
{
    public readonly struct Response: IDisposable
    {
        public HttpPipelineResponse HttpResponse { get; }

        public Response(HttpPipelineResponse httpResponse)
        {
            if (httpResponse == null)
            {
                throw new ArgumentNullException(nameof(httpResponse));
            }

            HttpResponse = httpResponse;
        }

        public int Status => HttpResponse.Status;

        public Stream ContentStream => HttpResponse.ResponseContentStream;

        public bool TryGetHeader(string name, out string values)
        {
            return HttpResponse.TryGetHeader(name, out values);
        }

        public void Dispose() => HttpResponse.Dispose();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => HttpResponse.ToString();
    }
}
