//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.Platform
{
    internal class HttpTransportHandlerProvider : IHttpTransportHandlerProvider
    {
        public HttpMessageHandler CreateHttpTransportHandler()
        {
            var httpHandler = new HttpClientHandler();
            // When ClientCertificateOptions is set to Automatic, HttpClient will use all certificates with
            // EKU 1.3.6.1.5.5.7.3.2 and CERT_DIGITAL_SIGNATURE_KEY_USAGE from current user MY store
            httpHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
            return httpHandler;
        }
    }
}
