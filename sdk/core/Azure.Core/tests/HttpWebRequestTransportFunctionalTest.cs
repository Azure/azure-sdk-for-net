// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Core.Pipeline;

namespace Azure.Core.Tests
{
#if NETFRAMEWORK
    public class HttpWebRequestTransportFunctionalTest : TransportFunctionalTests
    {
        public HttpWebRequestTransportFunctionalTest(bool isAsync) : base(isAsync)
        {
        }

        protected override HttpPipelineTransport GetTransport(bool https = false)
        {
            if (https)
            {
                return new HttpWebRequestTransport(request => request.ServerCertificateValidationCallback += (_, _, _, _) => true);
            }

            return new HttpWebRequestTransport();
        }
    }
#endif
}