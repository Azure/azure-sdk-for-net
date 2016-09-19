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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
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
                const string certPath = "./Resources/testcertificate.pfx";
                using (var certStream = File.OpenRead(certPath))
                {
                    certificate = new byte[certStream.Length];
                    certStream.Read(certificate, 0, certificate.Length);
                }

                var response = apiManagementClient.ResourceProvider.UploadCertificate(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceUploadCertificateParameters
                    {
                        CertificatePassword = "g0BdrCRORWI2ctk_g5Wdf5QpTsI9vxnw",
                        EncodedCertificate = Convert.ToBase64String(certificate),
                        Type = HostnameType.Portal
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.Value);
                Assert.Equal("CN=*.powershelltest.net", response.Value.Subject);
                Assert.Equal("E861A19B22EE98AC71F84AC00C5A05E2E7206820", response.Value.Thumbprint, StringComparer.OrdinalIgnoreCase);

                // now setup the hostname for proxy
                var proxyHostConfig = new HostnameConfiguration
                {
                    Type = HostnameType.Proxy,
                    Certificate = new CertificateInformation
                    {
                        Thumbprint = response.Value.Thumbprint,
                        Subject = response.Value.Subject,
                        Expiry = response.Value.Expiry
                    },
                    Hostname = "apimproxy.powershelltest.net"
                };

                var updateHostNameResponse = apiManagementClient.ResourceProvider.UpdateHostname(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceUpdateHostnameParameters
                    {
                        HostnamesToCreateOrUpdate = new List<HostnameConfiguration> {proxyHostConfig}
                    });

                Assert.NotNull(updateHostNameResponse);
                Assert.Equal(HttpStatusCode.OK, updateHostNameResponse.StatusCode);
                Assert.NotNull(updateHostNameResponse.Value);
                Assert.NotNull(updateHostNameResponse.Value.Properties);
                Assert.NotNull(updateHostNameResponse.Value.Properties.HostnameConfigurations);
                Assert.True(updateHostNameResponse.Value.Properties.HostnameConfigurations.Any());
                Assert.Equal("apimproxy.powershelltest.net",
                    updateHostNameResponse.Value.Properties.HostnameConfigurations[0].Hostname);
                Assert.Equal(HostnameType.Proxy,
                    updateHostNameResponse.Value.Properties.HostnameConfigurations[0].Type);
                Assert.Equal("E861A19B22EE98AC71F84AC00C5A05E2E7206820",
                    updateHostNameResponse.Value.Properties.HostnameConfigurations[0].Certificate.Thumbprint);
            }
        }
    }
}