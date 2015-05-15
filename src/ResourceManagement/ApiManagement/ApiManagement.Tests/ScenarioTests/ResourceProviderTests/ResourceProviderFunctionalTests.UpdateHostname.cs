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

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.ResourceProviderTests
{
    using System;
    using System.Net;
    using System.Reflection;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class ResourceProviderFunctionalTests
    {
        [Fact]
        public void UpdateHostname()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "UpdateHostname");

                TryCreateApiService();

                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());

                byte[] certificate;
                var assembly = Assembly.GetExecutingAssembly();
                const string certName = "_.preview.int-azure-api.net.pfx";
                using (var certStream = assembly.GetManifestResourceStream(string.Format("{0}.Resources.{1}", assembly.GetName().Name, certName)))
                {
                    certificate = new byte[certStream.Length];
                    certStream.Read(certificate, 0, certificate.Length);
                }

                var response = apiManagementClient.ApiManagement.UploadCertificate(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceUploadCertificateParameters
                    {
                        CertificatePassword = "Password!12",
                        EncodedCertificate = Convert.ToBase64String(certificate),
                        Type = HostnameType.Portal
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Value);
                Assert.Equal("CN=*.preview.int-azure-api.net", response.Value.Subject);
                Assert.Equal("A9B7C36DE11C29F38B9DCDA5D96BA36B9C777106", response.Value.Thumbprint, StringComparer.OrdinalIgnoreCase);

                // TODO: implement updatehostname verification
            }
        }
    }
}