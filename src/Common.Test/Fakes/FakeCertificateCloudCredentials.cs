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

using System;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Common.Internals;

namespace Microsoft.WindowsAzure.Common.Test.Fakes
{
    public class FakeCertificateCloudCredentials : SubscriptionCloudCredentials
    {
        public X509Certificate2 ManagementCertificate { get; private set; }

        public FakeCertificateCloudCredentials()
        {
        }

        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            FakeHttpHandler handler = client.GetHttpPipeline().OfType<FakeHttpHandler>().FirstOrDefault();

            if (handler == null)
            {
                throw new PlatformNotSupportedException("error");
            }
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }

        public override string SubscriptionId
        {
            get { return ""; }
        }
    }
}
