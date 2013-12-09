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
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Common.Test.Fakes;
using Xunit;

namespace Microsoft.WindowsAzure.Common.Test
{
    public class RetryHandlerTest
    {
        [Fact]
        public void ClientAddHandlerToPipelineAddsHandler()
        {
            var fakeClient = new FakeServiceClient(new CertificateCloudCredentials("1EAAFA05-0632-4EF4-85DF-09E871CE66D8", 
                new X509Certificate2()));
            var result1 = fakeClient.DoStuff();
            Assert.Equal(200, (int)result1.Result.StatusCode);

            fakeClient.AddHandlerToPipeline(new BadResponseDelegatingHandler());

            var result2 = fakeClient.DoStuff();
            Assert.Equal(500, (int)result2.Result.StatusCode);
        }
    }
}
