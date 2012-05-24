// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Client;
using System.Net;

namespace Microsoft.WindowsAzure.MediaServices.Client.Versioning
{
    internal class ServiceVersionAdapter
    {
        private readonly Version _serviceVersion;

        public ServiceVersionAdapter(Version serviceVersion)
        {
            _serviceVersion = serviceVersion;
        }

        public void Adapt(DataServiceContext context)
        {
            context.SendingRequest += AddRequestVersion;
        }

        private void AddRequestVersion(object sender, SendingRequestEventArgs e)
        {
            AddToRequestHeaders(e);
        }

        private void AddToRequestHeaders(SendingRequestEventArgs sendingRequestEventArgs)
        {
            AddVersionToRequest(sendingRequestEventArgs.Request);
        }

        public void AddVersionToRequest(WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Headers.Add("x-ms-version", _serviceVersion.ToString());
        }
    }
}
