// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public class LROCheck : HttpPipelineSynchronousPolicy
    {
        public override void OnReceivedResponse(HttpMessage message)
        {
            if (message.Request.Uri.ToString().Contains("Microsoft.OperationalInsights"))
            {
                //string locationUri;
                //var oldHeader = message.Response.Headers;
                //var headerList = new List<HttpHeader>();
                //if (oldHeader.TryGetValue("Location", out locationUri))
                //{
                //    if (locationUri.Contains("/operationresults/"))
                //    {
                //        foreach (var item in oldHeader)
                //        {
                //            if (!item.Name.Equals("Location"))
                //            {
                //                headerList.Add(item);
                //            }
                //        }
                //    }
                //}
                message.Response = new OverrideHeaderResponse(message.Response);
            }
        }

        private class OverrideHeaderResponse : Response
        {
            private const string HeaderToOmit = "Location";
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
                if (name == HeaderToOmit)
                    return false;
                return _headers.Contains(name);
            }

            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                return _headers;
            }

            protected override bool TryGetHeader(string name, [NotNullWhen(true)] out string value)
            {
                if (name == HeaderToOmit)
                {
                    value = null;
                    return false;
                }
                return _headers.TryGetValue(name, out value);
            }

            protected override bool TryGetHeaderValues(string name, [NotNullWhen(true)] out IEnumerable<string> values)
            {
                if (name == HeaderToOmit)
                {
                    values = null;
                    return false;
                }
                return _headers.TryGetValues(name, out values);
            }
        }
    }
}
