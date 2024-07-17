// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MySql.MySqlFlexibleServers
{
    internal class LroReplaceAzureAsyncOperationPolicy : HttpPipelineSynchronousPolicy
    {
        private const string AzureAsyncOperation = "Azure-AsyncOperation";
        private const string AzureAsyncOperationReplacement = "Location";

        public override void OnReceivedResponse(HttpMessage message)
        {
            if (message.Response.Headers.Contains(AzureAsyncOperation))
            {
                message.Response = new OverrideHeaderResponse(message.Response);
            }
        }

        private class OverrideHeaderResponse : Response
        {
            private readonly Response _original;
            private readonly ResponseHeaders _headers;

            public OverrideHeaderResponse(Response original)
            {
                _original = original;
                _headers = original.Headers;
            }

            public override int Status => _original.Status;

            public override string ReasonPhrase => _original.ReasonPhrase;

            public override Stream ContentStream
            {
                get => _original.ContentStream;
                set => _original.ContentStream = value;
            }

            public override string ClientRequestId
            {
                get => _original.ClientRequestId; set => _original.ClientRequestId = value;
            }

            public override void Dispose()
            {
                _original.Dispose();
            }

            protected override bool ContainsHeader(string name)
            {
                return _headers.Contains(name);
            }

            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                return _headers;
            }

            protected override bool TryGetHeader(string name, out string value)
            {
                if (name == AzureAsyncOperation)
                {
                    return TryGetHeader(AzureAsyncOperationReplacement, out value);
                }
                return _headers.TryGetValue(name, out value);
            }

            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                if (name == AzureAsyncOperation)
                {
                    return TryGetHeaderValues(AzureAsyncOperationReplacement, out values);
                }
                return _headers.TryGetValues(name, out values);
            }
        }
    }
}
