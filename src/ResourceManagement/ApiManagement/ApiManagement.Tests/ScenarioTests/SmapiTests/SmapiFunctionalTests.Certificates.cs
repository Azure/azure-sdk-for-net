//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void CertificatesCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "CertificatesCreateListUpdateDelete");

            try
            {
                // list certificates: there should be none
                var listResponse = ApiManagementClient.Certificates.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.Equal(0, listResponse.Result.TotalCount);
                Assert.Equal(0, listResponse.Result.Values.Count);

                // create new certificate
                string certificateId = TestUtilities.GenerateName("certificateId");

                byte[] rawBytes;
                const string certPath = "./Resources/testcertificate.pfx";
                using (var certStream = File.OpenRead(certPath))
                {
                    rawBytes = new byte[certStream.Length];
                    certStream.Read(rawBytes, 0, rawBytes.Length);
                }

                string certificatePassword = "powershelltest";
                string certificateData = Convert.ToBase64String(rawBytes);

                var cert = new X509Certificate2(rawBytes, certificatePassword);

                var createResponse = ApiManagementClient.Certificates.CreateOrUpdate(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    certificateId,
                    new CertificateCreateOrUpdateParameters
                    {
                        Data = certificateData,
                        Password = certificatePassword
                    },
                    null);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get the certificate to check is was created
                var getResponse = ApiManagementClient.Certificates.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    certificateId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(certificateId, getResponse.Value.Id);
                Assert.Equal(cert.Subject, getResponse.Value.Subject, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(cert.Thumbprint, getResponse.Value.Thumbprint, StringComparer.OrdinalIgnoreCase);
                //Assert.Equal(cert.NotAfter, getResponse.Value.ExpirationDate);

                // list certificates
                listResponse = ApiManagementClient.Certificates.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.Equal(1, listResponse.Result.TotalCount);
                Assert.Equal(1, listResponse.Result.Values.Count);

                // remove the certificate
                var deleteResponse = ApiManagementClient.Certificates.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    certificateId,
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);

                // list again to see it was removed
                listResponse = ApiManagementClient.Certificates.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.Equal(0, listResponse.Result.TotalCount);
                Assert.Equal(0, listResponse.Result.Values.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}