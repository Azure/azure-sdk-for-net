// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System.Net.Http;

namespace Hyak.Common.Platform
{
    internal class HttpTransportHandlerProvider : IHttpTransportHandlerProvider
    {
        public HttpMessageHandler CreateHttpTransportHandler()
        {
            return new HttpClientHandler
                        { 
                            ClientCertificateOptions = ClientCertificateOption.Automatic
                        };
        }
    }
}