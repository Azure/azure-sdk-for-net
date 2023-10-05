// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Linq;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Network;
using Xunit;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.ManagedServiceIdentity;
using ApiManagementManagement.Tests.Helpers;
using Microsoft.Azure.Management.Resources.Models;

namespace ApiManagement.Tests
{
    public class ApiManagementTestBase : TestBase
    {
        private const string SubIdKey = "SubId";
        private const string ServiceNameKey = "ServiceName";
        private const string ResourceGroupNameKey = "ResourceGroup";
        private const string LocationKey = "Location";
        private const string TestCertificateKey = "TestCertificate";
        private const string TestCertificatePasswordKey = "TestCertificatePassword";
        private const string TestKeyVaultSecretKey = "testKeyVaultSecretUrl";
        private const string TestBackupStorageAccount = "TestBackupStorageAccount";
        private const string TestBackupUserMsiClientId = "TestBackupUserMsiClientId";
        private const string TestBackupUserMsiResourceId = "TestBackupUserMsiResourceId";

        private static string[] CanaryRegions = new[] { "eastus2euap", "centraluseuap" };
        private const string EnvironmentKey = "Environment";

        public string location { get; set; }
        public string subscriptionId { get; set; }
        public ApiManagementClient client { get; set; }
        public ResourceManagementClient resourcesClient { get; set; }
        public StorageManagementClient storageClient { get; set; }
        public NetworkManagementClient networkClient { get; set; }
        public EventHubManagementClient eventHubClient { get; set; }
        public ManagedServiceIdentityClient managedIdentityClient { get; set; }
        public string rgName { get; internal set; }
        public Dictionary<string, string> tags { get; internal set; }
        public string serviceName { get; internal set; }
        public ApiManagementServiceResource serviceProperties { get; internal set; }
        public string base64EncodedTestCertificateData { get; internal set; }
        public string testCertificatePassword { get; internal set; }
        public string testKeyVaultSecretUrl { get; internal set; }
        public string testBackupStorageAccountName { get; internal set; }
        public string testBackupUserMsiClientId { get; internal set; }
        public string testBackupUserMsiId { get; internal set; }
        public string envName { get; internal set; }

        public ApiManagementTestBase(MockContext context)
        {
            this.client = context.GetServiceClient<ApiManagementClient>();
            this.resourcesClient = context.GetServiceClient<ResourceManagementClient>();
            this.storageClient = context.GetServiceClient<StorageManagementClient>();
            this.networkClient = context.GetServiceClient<NetworkManagementClient>();
            this.eventHubClient = context.GetServiceClient<EventHubManagementClient>();
            this.managedIdentityClient = context.GetServiceClient<ManagedServiceIdentityClient>();

            Initialize();
        }

        private void Initialize()
        {
            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            tags = new Dictionary<string, string> { { "apiversion", $"{client.ApiVersion}" } };

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                if (!testEnv.ConnectionString.KeyValuePairs.TryGetValue(ServiceNameKey, out string apimServiceName))
                {
                    this.serviceName = TestUtilities.GenerateName("sdktestapim");
                }
                else
                {
                    this.serviceName = apimServiceName;
                }

                if (!testEnv.ConnectionString.KeyValuePairs.TryGetValue(LocationKey, out string apimLocation))
                {
                    this.location = GetLocation();
                }
                else
                {
                    this.location = apimLocation;
                }

                if (!testEnv.ConnectionString.KeyValuePairs.TryGetValue(ResourceGroupNameKey, out string resourceGroupName))
                {
                    rgName = TestUtilities.GenerateName("sdktestrg");
                }
                else
                {
                    this.rgName = resourceGroupName;
                }

                TryCreateResourceGroupIfNoExists(this.rgName);

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestCertificateKey, out string base64EncodedCertificate))
                {
                    this.base64EncodedTestCertificateData = base64EncodedCertificate;
                    HttpMockServer.Variables[TestCertificateKey] = base64EncodedTestCertificateData;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestCertificatePasswordKey, out string testCertificatePassword))
                {
                    this.testCertificatePassword = testCertificatePassword;
                    HttpMockServer.Variables[TestCertificatePasswordKey] = testCertificatePassword;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestKeyVaultSecretKey, out string testKeyVaultSecretUrl))
                {
                    this.testKeyVaultSecretUrl = testKeyVaultSecretUrl;
                    HttpMockServer.Variables[TestKeyVaultSecretKey] = testKeyVaultSecretUrl;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestBackupStorageAccount, out string testBackupStorageAccount))
                {
                    this.testBackupStorageAccountName = testBackupStorageAccount;
                    HttpMockServer.Variables[TestBackupStorageAccount] = testBackupStorageAccount;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestBackupUserMsiClientId, out string backupUserMsiClientId))
                {
                    this.testBackupUserMsiClientId = backupUserMsiClientId;
                    HttpMockServer.Variables[TestBackupUserMsiClientId] = backupUserMsiClientId;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(TestBackupUserMsiResourceId, out string backupUserMsiId))
                {
                    this.testBackupUserMsiId = backupUserMsiId;
                    HttpMockServer.Variables[TestBackupUserMsiResourceId] = backupUserMsiId;
                }

                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(EnvironmentKey, out string envName))
                {
                    this.envName = envName;
                    HttpMockServer.Variables[EnvironmentKey] = envName;
                }

                this.subscriptionId = testEnv.SubscriptionId;
                HttpMockServer.Variables[SubIdKey] = subscriptionId;
                HttpMockServer.Variables[ServiceNameKey] = this.serviceName;
                HttpMockServer.Variables[LocationKey] = this.location;
                HttpMockServer.Variables[ResourceGroupNameKey] = this.rgName;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                this.subscriptionId = testEnv.SubscriptionId;
                subscriptionId = HttpMockServer.Variables[SubIdKey];
                rgName = HttpMockServer.Variables[ResourceGroupNameKey];
                serviceName = HttpMockServer.Variables[ServiceNameKey];
                location = HttpMockServer.Variables[LocationKey];
                HttpMockServer.Variables.TryGetValue(TestCertificateKey, out var testcertificate);
                if (!string.IsNullOrEmpty(testcertificate))
                {
                    this.base64EncodedTestCertificateData = testcertificate;
                }
                HttpMockServer.Variables.TryGetValue(TestCertificatePasswordKey, out var testCertificatePwd);
                if (!string.IsNullOrEmpty(testCertificatePwd))
                {
                    this.testCertificatePassword = testCertificatePwd;
                }
                HttpMockServer.Variables.TryGetValue(TestKeyVaultSecretKey, out var testKVSecretUrl);
                if (!string.IsNullOrEmpty(testKVSecretUrl))
                {
                    this.testKeyVaultSecretUrl = testKVSecretUrl;
                }
                HttpMockServer.Variables.TryGetValue(TestBackupStorageAccount, out string testBackupStorageAccount);
                if (!string.IsNullOrEmpty(testBackupStorageAccount))
                {
                    this.testBackupStorageAccountName = testBackupStorageAccount;
                }
                HttpMockServer.Variables.TryGetValue(TestBackupUserMsiClientId, out string backupUserMsiClientId);
                if (!string.IsNullOrEmpty(backupUserMsiClientId))
                {
                    this.testBackupUserMsiClientId = backupUserMsiClientId;
                }
                HttpMockServer.Variables.TryGetValue(TestBackupUserMsiResourceId, out string backupUserMsiId);
                if (!string.IsNullOrEmpty(backupUserMsiId))
                {
                    this.testBackupUserMsiId = backupUserMsiId;
                }
                if (testEnv.ConnectionString.KeyValuePairs.TryGetValue(EnvironmentKey, out string envName))
                {
                    this.envName = envName;
                    HttpMockServer.Variables[EnvironmentKey] = envName;
                }
            }


            serviceProperties = new ApiManagementServiceResource
            {
                Sku = new ApiManagementServiceSkuProperties
                {
                    Name = SkuType.Developer,
                    Capacity = 1
                },
                Location = location,
                PublisherEmail = "apim@autorestsdk.com",
                PublisherName = "autorestsdk",
                Tags = tags,
                Identity = new ApiManagementServiceIdentity("SystemAssigned")
            };
        }

        public void TryCreateApiManagementService()
        {
            this.client.ApiManagementService.CreateOrUpdate(
                resourceGroupName: this.rgName,
                serviceName: this.serviceName,
                parameters: this.serviceProperties);

            var service = this.client.ApiManagementService.Get(this.rgName, this.serviceName);
            Assert.Equal(this.serviceName, service.Name);
        }

        private void TryCreateResourceGroupIfNoExists(string rgName)
        {
            var rg = resourcesClient.ResourceGroups.CheckExistence(rgName);
            if (!rg)
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(rgName, new Microsoft.Azure.Management.ResourceManager.Models.ResourceGroup { Location = this.location, Tags = tags });
            }
        }

        public string GetOpenIdMetadataEndpointUrl()
        {
            return "https://" + TestUtilities.GenerateName("provider") + "." + TestUtilities.GenerateName("endpoint");
        }

        public string GetLocation(string regionIn = "US")
        {
            var provider = this.resourcesClient.Providers.Get("Microsoft.ApiManagement");
            return provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "service")
                        return true;
                    else
                        return false;
                }
                ).First().Locations.Where(l => l.Contains(regionIn)).FirstOrDefault();
        }

        public string GetAdditionLocation(string masterLocation, string regionIn = "US")
        {
            if (CanaryRegions
                .Any(d => string.Equals(masterLocation.ToLowerAndRemoveWhiteSpaces(), d)))
            {
                return CanaryRegions.FirstOrDefault(d => !string.Equals(d, masterLocation.ToLowerAndRemoveWhiteSpaces()));
            }

            var provider = this.resourcesClient.Providers.Get("Microsoft.ApiManagement");
            return provider.ResourceTypes.Where(
                (resType) =>
                {
                    if (resType.ResourceType == "service")
                        return true;
                    else
                        return false;
                }
                ).First().Locations
                .Where(l => !string.Equals(l.ToLowerAndRemoveWhiteSpaces(), masterLocation.ToLowerAndRemoveWhiteSpaces()))
                .Where(l => l.Contains(regionIn))
                .FirstOrDefault();
        }

        public static byte[] RandomBytes(int length)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var bytes = new byte[length];
                Random rnd = new Random();
                rnd.NextBytes(bytes);
                HttpMockServer.Variables["RandomBytes"] = Convert.ToBase64String(bytes);
                return bytes;
            }
            else
            {
                return Convert.FromBase64String(HttpMockServer.Variables["RandomBytes"]);
            }
        }

        public OperationContract CreateOperationContract(string httpMethod)
        {
            return new OperationContract
            {
                DisplayName = "operation_" + TestUtilities.GenerateName(),
                Description = "description_" + TestUtilities.GenerateName(),
                UrlTemplate = "template_" + TestUtilities.GenerateName(),
                Method = httpMethod,
                Request = new RequestContract
                {
                    Description = "description_" + TestUtilities.GenerateName(),
                    Headers = new[]
                    {
                        new ParameterContract
                        {
                            Name = "param_" + TestUtilities.GenerateName(),
                            Description = "description_" + TestUtilities.GenerateName(),
                            Type = "int",
                            DefaultValue = "b",
                            Required = true,
                            Values = new[] { "a", "b", "c" }
                        },
                        new ParameterContract
                        {
                            Name = "param_" + TestUtilities.GenerateName(),
                            Description = "description_" + TestUtilities.GenerateName(),
                            Type = "bool",
                            DefaultValue = "e",
                            Required = false,
                            Values = new[] { "d", "e", "f" }
                        }
                    },
                    Representations = new[]
                    {
                        new RepresentationContract
                        {
                            ContentType = "text/plain",
                            Examples = new Dictionary<string, ParameterExampleContract>
                            {
                                ["default"] = new ParameterExampleContract
                                {
                                    Description = "My default request example",
                                    ExternalValue = "https://contoso.com",
                                    Summary = "Just an example",
                                    Value = "default"
                                }
                            }
                        },
                        new RepresentationContract
                        {
                            ContentType = "application/xml",
                                                        Examples = new Dictionary<string, ParameterExampleContract>
                            {
                                ["default"] = new ParameterExampleContract
                                {
                                    Description = "My default request example",
                                    ExternalValue = "https://contoso.com",
                                    Summary = "Just an example",
                                    Value = "default"
                                }
                            },
                        }
                    }
                },
                Responses = new[]
                {
                    new ResponseContract
                    {
                        StatusCode = 200,
                        Description = "description_" + TestUtilities.GenerateName(),
                        Representations = new[]
                        {
                            new RepresentationContract
                            {
                                ContentType = "application/json",
                            Examples = new Dictionary<string, ParameterExampleContract>
                            {
                                ["default"] = new ParameterExampleContract
                                {
                                    Description = "My default request example",
                                    ExternalValue = "https://contoso.com",
                                    Summary = "Just an example",
                                    Value = "default"
                                }
                            }                            },
                            new RepresentationContract
                            {
                                ContentType = "application/xml",
                            Examples = new Dictionary<string, ParameterExampleContract>
                            {
                                ["default"] = new ParameterExampleContract
                                {
                                    Description = "My default request example",
                                    ExternalValue = "https://contoso.com",
                                    Summary = "Just an example",
                                    Value = "default"
                                }
                            }                            }
                        }
                    }
                }
            };
        }
    }
}