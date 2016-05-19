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

using Hyak.Common;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Compute.Testing
{
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class ExtensionImageReproTests : TestBase, IUseFixture<TestFixtureData>
    {
        private TestFixtureData fixture;

        public void SetFixture(TestFixtureData data)
        {
            data.Instantiate(TestUtilities.GetCallingClass());
            fixture = data;
        }

        [Fact]
        public void CanRegisterUpdateAndUnregisterExtensionImage()
        {
            TestLogTracingInterceptor.Current.Start();
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var mgmt = fixture.GetManagementClient();
                var compute = fixture.GetComputeManagementClient();
                var storage = fixture.GetStorageManagementClient();

                string versionStr = "74.59.0.0";
                string verUpdtStr = "74.60.0.0";

                const string publicSchemaStr = @"<?xml version=""1.0"" encoding=""utf-8""?>"
                    + @"<xs:schema attributeFormDefault=""unqualified"""
                    + @"  elementFormDefault=""qualified"""
                    + @"  xmlns:xs=""http://www.w3.org/2001/XMLSchema"">"
                    + @"  <xs:element name=""PublicConfig"">"
                    + @"    <xs:complexType>"
                    + @"      <xs:sequence>"
                    + @"        <xs:element name=""UserName"" type=""xs:string"" />"
                    + @"      </xs:sequence>"
                    + @"    </xs:complexType>"
                    + @"  </xs:element>"
                    + @"</xs:schema>";

                const string privateSchemaStr = @"<?xml version=""1.0"" encoding=""utf-8""?>"
                    + @"<xs:schema attributeFormDefault=""unqualified"""
                    + @"  elementFormDefault=""qualified"""
                    + @"  xmlns:xs=""http://www.w3.org/2001/XMLSchema"">"
                    + @"  <xs:element name=""PrivateConfig"">"
                    + @"    <xs:complexType>"
                    + @"      <xs:sequence>"
                    + @"        <xs:element name=""Password"" type=""xs:string"" />"
                    + @"      </xs:sequence>"
                    + @"    </xs:complexType>"
                    + @"  </xs:element>"
                    + @"</xs:schema>";

                const string sampleConfigStr = "TestSampleConfig";

                try
                {
                    string storageName = TestUtilities.GenerateName("teststorage");
                    string providerName = TestUtilities.GenerateName("testprovider");
                    string extensionName = TestUtilities.GenerateName("testextension");
                    string location = mgmt.GetDefaultLocation("Storage", "Compute");

                    const string usWestLocStr = "West US";
                    if (mgmt.Locations.List().Any(
                        c => string.Equals(c.Name, usWestLocStr, StringComparison.OrdinalIgnoreCase)))
                    {
                        location = usWestLocStr;
                    }

                    // create a storage account
                    var storageAccountResult = storage.StorageAccounts.Create(
                        new StorageAccountCreateParameters
                        {
                            Location = location,
                            Name = storageName,
                            AccountType = "Standard_LRS"
                        });

                    // get the storage account
                    var keyResult = storage.StorageAccounts.GetKeys(storageName);

                    // build the connection string
                    const string containerStr = "ext";
                    Uri blobUri = StorageTestUtilities.UploadFileToBlobStorage(storageName, containerStr, @".\RemoteAccessPlugin.zip");
                    bool isPublisher = false;
                    const string errorCodeStr = "ForbiddenError";

                    try
                    {
                        var parameters = new ExtensionImageRegisterParameters
                            {
                                ProviderNameSpace = providerName,
                                Type = extensionName,
                                Version = versionStr,
                                HostingResources = "VmRole",
                                MediaLink = blobUri,
                                Label = providerName,
                                Description = providerName,
                                BlockRoleUponFailure = false,
                                Certificate = new ExtensionCertificateConfiguration
                                {
                                    StoreLocation = "LocalMachine",
                                    StoreName = "My",
                                    ThumbprintAlgorithm = "sha1",
                                    ThumbprintRequired = true
                                },
                                LocalResources = new List<ExtensionLocalResourceConfiguration>
                                {
                                    new ExtensionLocalResourceConfiguration
                                    {
                                        Name = "Test1",
                                        SizeInMB = 100
                                    },
                                    new ExtensionLocalResourceConfiguration
                                    {
                                        Name = "Test2",
                                        SizeInMB = 200
                                    }
                                },
                                DisallowMajorVersionUpgrade = true,
                                SampleConfig = sampleConfigStr,
                                PublishedDate = DateTime.Now,
                                Eula = new Uri("http://test.com"),
                                PrivacyUri = new Uri("http://test.com"),
                                HomepageUri = new Uri("http://test.com"),
                                IsInternalExtension = true,
                                PrivateConfigurationSchema = privateSchemaStr,
                                PublicConfigurationSchema = publicSchemaStr,
                                ExtensionEndpoints = new ExtensionEndpointConfiguration
                                {
                                    InputEndpoints = new List<ExtensionEndpointConfiguration.InputEndpoint>
                                    {
                                        new ExtensionEndpointConfiguration.InputEndpoint
                                        {
                                            Name = "Test1",
                                            Port = 1111,
                                            LocalPort = "*",
                                            Protocol = "tcp"
                                        },
                                        new ExtensionEndpointConfiguration.InputEndpoint
                                        {
                                            Name = "Test2",
                                            Port = 2222,
                                            LocalPort = "22222",
                                            Protocol = "tcp"
                                        }
                                    },
                                    InternalEndpoints = new List<ExtensionEndpointConfiguration.InternalEndpoint>
                                    {
                                        new ExtensionEndpointConfiguration.InternalEndpoint
                                        {
                                            Name = "Test1",
                                            Port = 1111,
                                            Protocol = "tcp"
                                        },
                                        new ExtensionEndpointConfiguration.InternalEndpoint
                                        {
                                            Name = "Test2",
                                            Port = 2222,
                                            Protocol = "tcp"
                                        },
                                    },
                                    InstanceInputEndpoints = new List<ExtensionEndpointConfiguration.InstanceInputEndpoint>
                                    {
                                        new ExtensionEndpointConfiguration.InstanceInputEndpoint
                                        {
                                            Name = "Test1",
                                            Protocol = "tcp",
                                            LocalPort = "111",
                                            FixedPortMin = 100,
                                            FixedPortMax = 1000
                                        },
                                        new ExtensionEndpointConfiguration.InstanceInputEndpoint
                                        {
                                            Name = "Test2",
                                            Protocol = "tcp",
                                            LocalPort = "22",
                                            FixedPortMin = 2000,
                                            FixedPortMax = 10000
                                        }
                                    }
                                },
                                IsJsonExtension = false,
                                CompanyName = providerName,
                                SupportedOS = ExtensionImageSupportedOperatingSystemType.Windows,
                                Regions = usWestLocStr,
                            };

                        compute.ExtensionImages.Register(parameters);

                        isPublisher = true;

                        bool found = false;
                        const int maxRetryTimes = 60;
                        int retryTime = 0;
                        VirtualMachineExtensionListResponse.ResourceExtension ext = null;
                        while (!found && retryTime < maxRetryTimes)
                        {
                            Thread.Sleep(TimeSpan.FromMinutes(1.0));

                            ext = compute.VirtualMachineExtensions
                                            .ListVersions(providerName, extensionName)
                                            .FirstOrDefault(e => string.Equals(e.Version, versionStr));

                            if (ext != null)
                            {
                                found = true;
                            }

                            retryTime++;
                        }

                        if (found)
                        {
                            Assert.True(ext != null);

                            Assert.Equal<string>(ext.Name, parameters.Type);
                            Assert.Equal<string>(ext.Publisher, parameters.ProviderNameSpace);
                            Assert.Equal<string>(ext.Description, parameters.Description);
                            Assert.Equal<string>(ext.SampleConfig, parameters.SampleConfig);
                            Assert.Equal<string>(ext.PrivateConfigurationSchema, parameters.PrivateConfigurationSchema);
                            Assert.Equal<string>(ext.PublicConfigurationSchema, parameters.PublicConfigurationSchema);
                            Assert.Equal<string>(ext.Eula.ToString(), parameters.Eula.ToString());
                            Assert.Equal<string>(ext.PrivacyUri.ToString(), parameters.PrivacyUri.ToString());
                            Assert.Equal<string>(ext.HomepageUri.ToString(), parameters.HomepageUri.ToString());
                            Assert.Equal<bool?>(ext.IsInternalExtension, parameters.IsInternalExtension);
                            Assert.Equal<bool?>(ext.DisallowMajorVersionUpgrade, parameters.DisallowMajorVersionUpgrade);
                            Assert.Equal<bool?>(ext.IsInternalExtension, parameters.IsInternalExtension);
                            Assert.Equal<string>(ext.CompanyName, parameters.CompanyName);
                            Assert.Equal<string>(ext.SupportedOS, parameters.SupportedOS);

                            Assert.True(parameters.IsJsonExtension != null && !parameters.IsJsonExtension.Value
                                    && (ext.IsJsonExtension == null || !ext.IsJsonExtension.Value));
                        }
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        var parameters = new ExtensionImageUpdateParameters
                        {
                            ProviderNameSpace = providerName,
                            Type = extensionName,
                            Version = verUpdtStr,
                            HostingResources = "VmRole",
                            MediaLink = blobUri,
                            Label = providerName,
                            Description = providerName,
                            BlockRoleUponFailure = false,
                            Certificate = new ExtensionCertificateConfiguration
                            {
                                StoreLocation = "LocalMachine",
                                StoreName = "My",
                                ThumbprintAlgorithm = "sha1",
                                ThumbprintRequired = true
                            },
                            LocalResources = new List<ExtensionLocalResourceConfiguration>
                            {
                                new ExtensionLocalResourceConfiguration
                                {
                                    Name = "Test1",
                                    SizeInMB = 100
                                },
                                new ExtensionLocalResourceConfiguration
                                {
                                    Name = "Test2",
                                    SizeInMB = 200
                                }
                            },
                            DisallowMajorVersionUpgrade = true,
                            SampleConfig = sampleConfigStr,
                            PublishedDate = DateTime.Now,
                            Eula = new Uri("http://test.com"),
                            PrivacyUri = new Uri("http://test.com"),
                            HomepageUri = new Uri("http://test.com"),
                            IsInternalExtension = true,
                            PrivateConfigurationSchema = privateSchemaStr,
                            PublicConfigurationSchema = publicSchemaStr,
                            ExtensionEndpoints = new ExtensionEndpointConfiguration
                            {
                                InputEndpoints = new List<ExtensionEndpointConfiguration.InputEndpoint>
                                {
                                    new ExtensionEndpointConfiguration.InputEndpoint
                                    {
                                        Name = "Test1",
                                        Port = 1111,
                                        LocalPort = "11111",
                                        Protocol = "tcp"
                                    },
                                    new ExtensionEndpointConfiguration.InputEndpoint
                                    {
                                        Name = "Test2",
                                        Port = 2222,
                                        LocalPort = "*",
                                        Protocol = "tcp"
                                    }
                                },
                                InternalEndpoints = new List<ExtensionEndpointConfiguration.InternalEndpoint>
                                {
                                    new ExtensionEndpointConfiguration.InternalEndpoint
                                    {
                                        Name = "Test1",
                                        Port = 1111,
                                        Protocol = "tcp"
                                    },
                                    new ExtensionEndpointConfiguration.InternalEndpoint
                                    {
                                        Name = "Test2",
                                        Port = 2222,
                                        Protocol = "tcp"
                                    }
                                },
                                InstanceInputEndpoints = new List<ExtensionEndpointConfiguration.InstanceInputEndpoint>
                                {
                                    new ExtensionEndpointConfiguration.InstanceInputEndpoint
                                    {
                                        Name = "Test1",
                                        Protocol = "tcp",
                                        LocalPort = "11",
                                        FixedPortMin = 100,
                                        FixedPortMax = 1000
                                    },
                                    new ExtensionEndpointConfiguration.InstanceInputEndpoint
                                    {
                                        Name = "Test2",
                                        Protocol = "tcp",
                                        LocalPort = "22",
                                        FixedPortMin = 2000,
                                        FixedPortMax = 10000
                                    }
                                }
                            },
                            IsJsonExtension = false,
                            CompanyName = providerName,
                            SupportedOS = ExtensionImageSupportedOperatingSystemType.Windows,
                            Regions = usWestLocStr,
                        };

                        compute.ExtensionImages.Update(parameters);

                        bool found = false;
                        const int maxRetryTimes = 60;
                        int retryTime = 0;
                        VirtualMachineExtensionListResponse.ResourceExtension ext = null;
                        while (!found && retryTime < maxRetryTimes)
                        {
                            Thread.Sleep(TimeSpan.FromMinutes(1.0));

                            ext = compute.VirtualMachineExtensions
                                            .ListVersions(providerName, extensionName)
                                            .FirstOrDefault(e => string.Equals(e.Version, verUpdtStr));

                            if (ext != null)
                            {
                                found = true;
                            }

                            retryTime++;
                        }

                        if (found)
                        {
                            Assert.True(ext != null);

                            Assert.Equal<string>(ext.Name, parameters.Type);
                            Assert.Equal<string>(ext.Publisher, parameters.ProviderNameSpace);
                            Assert.Equal<string>(ext.Description, parameters.Description);
                            Assert.Equal<string>(ext.PrivateConfigurationSchema, parameters.PrivateConfigurationSchema);
                            Assert.Equal<string>(ext.PublicConfigurationSchema, parameters.PublicConfigurationSchema);
                            Assert.Equal<string>(ext.Eula.ToString(), parameters.Eula.ToString());
                            Assert.Equal<string>(ext.PrivacyUri.ToString(), parameters.PrivacyUri.ToString());
                            Assert.Equal<string>(ext.HomepageUri.ToString(), parameters.HomepageUri.ToString());
                            Assert.Equal<bool?>(ext.IsInternalExtension, parameters.IsInternalExtension);
                            Assert.Equal<bool?>(ext.DisallowMajorVersionUpgrade, parameters.DisallowMajorVersionUpgrade);
                            Assert.Equal<bool?>(ext.IsInternalExtension, parameters.IsInternalExtension);
                            Assert.Equal<string>(ext.CompanyName, parameters.CompanyName);
                            Assert.Equal<string>(ext.SupportedOS, parameters.SupportedOS);

                            Assert.True(parameters.IsJsonExtension != null && !parameters.IsJsonExtension.Value
                                    && (ext.IsJsonExtension == null || !ext.IsJsonExtension.Value));
                        }
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    try
                    {
                        compute.ExtensionImages.Unregister(
                            providerName,
                            extensionName,
                            versionStr);

                        compute.ExtensionImages.Unregister(
                            providerName,
                            extensionName,
                            verUpdtStr);
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }

                    // List Publisher Extensions
                    try
                    {
                        compute.HostedServices.ListPublisherExtensions();
                    }
                    catch (CloudException e)
                    {
                        Assert.True(!isPublisher && e != null && e.Error.Code.Equals(errorCodeStr));
                    }
                }
                finally
                {
                    undoContext.Dispose();
                    mgmt.Dispose();
                    compute.Dispose();
                    storage.Dispose();
                    TestLogTracingInterceptor.Current.Stop();
                }
            }
        }
    }
}
