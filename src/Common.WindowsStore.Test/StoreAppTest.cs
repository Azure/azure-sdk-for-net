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
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Management;
using Windows.Security.Cryptography.Certificates;
using Windows.Storage;

namespace Microsoft.WindowsAzure.Common.WindowsStoreApp.Test
{
    [TestClass]
    public class StoreAppTest
    {
        private static string _certificateString;
        private static string _subscription;
        private static string _certificatePassword;
        
        [TestInitialize]
        public void Setup()
        {
            GetCertificate().Wait();
        }

        [TestMethod]
        public void ManagementClientReturnsLocationList()
        {
            // Import certificate
            CertificateEnrollmentManager.ImportPfxDataAsync(_certificateString, _certificatePassword, ExportOption.NotExportable,
                                                                KeyProtectionLevel.NoConsent, InstallOptions.None,
                                                                "test").AsTask().Wait();

            var credentials = new CertificateCloudCredentials(_subscription);
            var client = new ManagementClient(credentials);
            var result = client.Locations.List();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsTrue(result.Locations.Count > 0);
        }

        private static async Task GetCertificate()
        {
            const string path = "certificate.keys";
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            var file = await folder.GetFileAsync(path);
            var lines = await FileIO.ReadLinesAsync(file);
            foreach (var line in lines)
            {
                if (line.StartsWith("TEST_CERTIFICATE="))
                {
                    _certificateString = line.Substring("TEST_CERTIFICATE=".Length);
                }
                if (line.StartsWith("TEST_CERTIFICATE_PASSWORD="))
                {
                    _certificatePassword = line.Substring("TEST_CERTIFICATE_PASSWORD=".Length);
                }
                if (line.StartsWith("TEST_SUBSCRIPTION="))
                {
                    _subscription = line.Substring("TEST_SUBSCRIPTION=".Length);
                }
            }
        }
    }
}
