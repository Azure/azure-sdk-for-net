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
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure;
namespace Microsoft.WindowsAzure.Testing
{
    public class TestBase
    {
        static TestBase()
        {
            CloudContext.Configuration.Tracing.AddTracingInterceptor(
                new TestingTracingInterceptor());
        }

        public virtual Uri TestBaseUri
        {
            get { return new Uri("https://management.core.windows.net"); }
        }

        public virtual string TestSubscriptionId
        {
            get { return "db1ab6f0-4769-4b27-930e-01e2ef9c123c"; }
        }

        public virtual X509Certificate2 TestManagementCertificate
        {
            get
            {
                string encodedCert = "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";
                return new X509Certificate2(Convert.FromBase64String(encodedCert));
            }
        }

        public virtual SubscriptionCloudCredentials GetTestCredentials()
        {
            return new CertificateCloudCredentials(TestSubscriptionId, TestManagementCertificate);
        }

        public static string Randomize(string name)
        {
            return name + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
        }

        public static void AssertThrownStatusCode(HttpStatusCode status, Action action)
        {
            try
            {
                action();
                Assert.Fail("Expected a CloudException with StatusCode " + status);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != status)
                {
                    throw;
                }
            }
        }

        public static void IgnoreExceptions(Action action)
        {
            try
            {
                action();
            }
            catch
            {
            }
        }
    }
}
