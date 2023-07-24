// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.AppContainers.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Azure.ResourceManager.AppContainers.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region ContainerAppAuthConfigData
        public static ContainerAppAuthConfigData GetContainerAppAuthConfigData()
        {
            ContainerAppAuthConfigData data = new ContainerAppAuthConfigData()
            {
                Platform = new ContainerAppAuthPlatform()
                {
                    IsEnabled = true,
                },
                GlobalValidation = new ContainerAppGlobalValidation()
                {
                    UnauthenticatedClientAction = ContainerAppUnauthenticatedClientActionV2.AllowAnonymous,
                },
                IdentityProviders = new ContainerAppIdentityProvidersConfiguration()
                {
                    Facebook = new ContainerAppFacebookConfiguration()
                    {
                        Registration = new ContainerAppRegistration()
                        {
                            AppId = "123",
                            AppSecretSettingName = "facebook-secret",
                        },
                    },
                },
            };
            return data;
        }

        public static void AssertContainerAppAuthConfigData(ContainerAppAuthConfigData data1, ContainerAppAuthConfigData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.HttpSettings.RequireHttps, data2.HttpSettings.RequireHttps);
            Assert.AreEqual(data1.GlobalValidation.UnauthenticatedClientAction, data2.GlobalValidation.UnauthenticatedClientAction);
            Assert.AreEqual(data1.Login.AllowedExternalRedirectUrls, data2.Login.AllowedExternalRedirectUrls);
        }
        #endregion

        #region containerapp
        public static ContainerAppData GetContainerAppData()
        {
            ContainerAppData data = new ContainerAppData(new AzureLocation("East US"))
            {
                EnvironmentId = new ResourceIdentifier("/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube"),
                WorkloadProfileName = "My-GP-01",
                Configuration = new ContainerAppConfiguration()
                {
                    Ingress = new ContainerAppIngressConfiguration()
                    {
                        External = true,
                        TargetPort = 3000,
                        Traffic =
{
new ContainerAppRevisionTrafficWeight()
{
RevisionName = "testcontainerApp0-ab1234",
Weight = 100,
Label = "production",
}
},
                        CustomDomains =
{
new ContainerAppCustomDomain("www.my-name.com")
{
BindingType = ContainerAppCustomDomainBindingType.SniEnabled,
CertificateId = new ResourceIdentifier("/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-name-dot-com"),
},new ContainerAppCustomDomain("www.my-other-name.com")
{
BindingType = ContainerAppCustomDomainBindingType.SniEnabled,
CertificateId = new ResourceIdentifier("/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube/certificates/my-certificate-for-my-other-name-dot-com"),
}
},
                        IPSecurityRestrictions =
{
new ContainerAppIPSecurityRestrictionRule("Allow work IP A subnet","192.168.1.1/32",ContainerAppIPRuleAction.Allow)
{
Description = "Allowing all IP's within the subnet below to access containerapp",
},new ContainerAppIPSecurityRestrictionRule("Allow work IP B subnet","192.168.1.1/8",ContainerAppIPRuleAction.Allow)
{
Description = "Allowing all IP's within the subnet below to access containerapp",
}
},
                        StickySessionsAffinity = Affinity.Sticky,
                        ClientCertificateMode = ContainerAppIngressClientCertificateMode.Accept,
                        CorsPolicy = new ContainerAppCorsPolicy(new string[]
            {
"https://a.test.com","https://b.test.com"
            })
                        {
                            AllowedMethods =
{
"GET","POST"
},
                            AllowedHeaders =
{
"HEADER1","HEADER2"
},
                            ExposeHeaders =
{
"HEADER3","HEADER4"
},
                            MaxAge = 1234,
                            AllowCredentials = true,
                        },
                    },
                    Dapr = new ContainerAppDaprConfiguration()
                    {
                        IsEnabled = true,
                        AppProtocol = ContainerAppProtocol.Http,
                        AppPort = 3000,
                        HttpReadBufferSize = 30,
                        HttpMaxRequestSize = 10,
                        LogLevel = ContainerAppDaprLogLevel.Debug,
                        IsApiLoggingEnabled = true,
                    },
                    MaxInactiveRevisions = 10,
                },
                Template = new ContainerAppTemplate()
                {
                    InitContainers =
{
new ContainerAppInitContainer()
{
Image = "repo/testcontainerApp0:v4",
Name = "testinitcontainerApp0",
Command =
{
"/bin/sh"
},
Args =
{
"-c","while true; do echo hello; sleep 10;done"
},
Resources = new AppContainerResources()
{
Cpu = 0.2,
Memory = "100Mi",
},
}
},
                    Containers =
{
new ContainerAppContainer()
{
Probes =
{
new ContainerAppProbe()
{
HttpGet = new ContainerAppHttpRequestInfo(8080)
{
HttpHeaders =
{
new ContainerAppHttpHeaderInfo("Custom-Header","Awesome")
},
Path = "/health",
},
InitialDelaySeconds = 3,
PeriodSeconds = 3,
ProbeType = ContainerAppProbeType.Liveness,
}
},
Image = "repo/testcontainerApp0:v1",
Name = "testcontainerApp0",
}
},
                    Scale = new ContainerAppScale()
                    {
                        MinReplicas = 1,
                        MaxReplicas = 5,
                        Rules =
{
new ContainerAppScaleRule()
{
Name = "httpscalingrule",
Custom = new ContainerAppCustomScaleRule()
{
CustomScaleRuleType = "http",
Metadata =
{
["concurrentRequests"] = "50",
},
},
}
},
                    },
                },
            };
            return data;
        }

        public static void AssertContainerAppData(ContainerAppData data1,  ContainerAppData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Configuration.Dapr.AppId, data2.Configuration.Dapr.AppId);
            Assert.AreEqual(data1.CustomDomainVerificationId, data2.CustomDomainVerificationId);
            Assert.AreEqual(data1.EnvironmentId, data2.EnvironmentId);
        }
        #endregion

        #region Certificate
        public static ContainerAppCertificateData GetCertificateData()
        {
            ContainerAppCertificateData data = new ContainerAppCertificateData(new AzureLocation("East US"))
            {
                Properties = new ContainerAppCertificateProperties()
                {
                    Password = "private key password",
                    Value = Convert.FromBase64String("Y2VydA=="),
                },
            };
            return data;
        }
        public static void GetCertificateData(ContainerAppCertificateData data1, ContainerAppCertificateData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Properties.Value, data2.Properties.Value);
            Assert.AreEqual(data1.Properties.Issuer, data2.Properties.Issuer);
            Assert.AreEqual(data1.Properties.Password, data2.Properties.Password);
            Assert.AreEqual(data1.Properties.Thumbprint, data2.Properties.Thumbprint);
        }
        #endregion

        #region enviroment
        public static ContainerAppConnectedEnvironmentData GetEnvironmentData()
        {
            ContainerAppConnectedEnvironmentData data = new ContainerAppConnectedEnvironmentData(new AzureLocation("East US"))
            {
                StaticIP = IPAddress.Parse("1.2.3.4"),
                DaprAIConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://northcentralus-0.in.applicationinsights.azure.com/",
                CustomDomainConfiguration = new ContainerAppCustomDomainConfiguration()
                {
                    DnsSuffix = "www.my-name.com",
                    CertificateValue = Convert.FromBase64String("Y2VydA=="),
                    CertificatePassword = "private key password",
                },
            };
            return data;
        }

        public static void AssertEnviroment(ContainerAppConnectedEnvironmentData data1, ContainerAppConnectedEnvironmentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.DaprAIConnectionString, data2.DaprAIConnectionString);
            Assert.AreEqual(data1.DefaultDomain , data2.DefaultDomain);
            Assert.AreEqual(data1.DeploymentErrors, data2.DeploymentErrors);
            Assert.AreEqual(data1.ExtendedLocation, data2.ExtendedLocation);
        }
        #endregion

        #region ContainerAppDaprComponentData
        public static ContainerAppDaprComponentData GetComponentData()
        {
            ContainerAppDaprComponentData data = new ContainerAppDaprComponentData()
            {
                ComponentType = "state.azure.cosmosdb",
                Version = "v1",
                IgnoreErrors = false,
                InitTimeout = "50s",
                Secrets =
{
new ContainerAppWritableSecret()
{
Name = "masterkey",
Value = "keyvalue",
}
},
                Metadata =
{
new ContainerAppDaprMetadata()
{
Name = "url",
Value = "<COSMOS-URL>",
},new ContainerAppDaprMetadata()
{
Name = "database",
Value = "itemsDB",
},new ContainerAppDaprMetadata()
{
Name = "collection",
Value = "items",
},new ContainerAppDaprMetadata()
{
Name = "masterkey",
SecretRef = "masterkey",
}
},
                Scopes =
{
"container-app-1","container-app-2"
},
            };
            return data;
        }

        public static void AssertCompoment(ContainerAppDaprComponentData data1, ContainerAppDaprComponentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ComponentType, data2.ComponentType);
            Assert.AreEqual(data1.Metadata.Count, data2.Metadata.Count);
            Assert.AreEqual(data1.Version, data2.Version);
            Assert.AreEqual(data1.IgnoreErrors, data2.IgnoreErrors);
            Assert.AreEqual(data1.InitTimeout, data2.InitTimeout);
        }
        #endregion

        #region ContainerAppConnectedEnvironmentStorageData
        public static ContainerAppConnectedEnvironmentStorageData GetEnvironmentStorageData()
        {
            ContainerAppConnectedEnvironmentStorageData data = new ContainerAppConnectedEnvironmentStorageData()
            {
                ConnectedEnvironmentStorageAzureFile = new ContainerAppAzureFileProperties()
                {
                    AccountName = "account1",
                    AccountKey = "key",
                    AccessMode = ContainerAppAccessMode.ReadOnly,
                    ShareName = "share1",
                },
            };
            return data;
        }

        public static void AssertEnviromentStorageData(ContainerAppConnectedEnvironmentStorageData data1, ContainerAppConnectedEnvironmentStorageData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccountName, data2.ConnectedEnvironmentStorageAzureFile.AccountName);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccountKey, data2.ConnectedEnvironmentStorageAzureFile.AccountKey);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.ShareName, data2.ConnectedEnvironmentStorageAzureFile.ShareName);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccessMode, data2.ConnectedEnvironmentStorageAzureFile.AccessMode);
        }
        #endregion

        #region ContainerAppJobData
        public static ContainerAppJobData GetJobData()
        {
            ContainerAppJobData data = new ContainerAppJobData(new AzureLocation("East US"))
            {
                EnvironmentId = "/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/rg/providers/Microsoft.App/managedEnvironments/demokube",
                Configuration = new ContainerAppJobConfiguration(ContainerAppJobTriggerType.Manual, 10)
                {
                    ReplicaRetryLimit = 10,
                    ManualTriggerConfig = new JobConfigurationManualTriggerConfig()
                    {
                        ReplicaCompletionCount = 1,
                        Parallelism = 4,
                    },
                },
                Template = new ContainerAppJobTemplate()
                {
                    InitContainers =
{
new ContainerAppInitContainer()
{
Image = "repo/testcontainerAppsJob0:v4",
Name = "testinitcontainerAppsJob0",
Command =
{
"/bin/sh"
},
Args =
{
"-c","while true; do echo hello; sleep 10;done"
},
Resources = new AppContainerResources()
{
Cpu = 0.2,
Memory = "100Mi",
},
}
},
                    Containers =
{
new ContainerAppContainer()
{
Probes =
{
new ContainerAppProbe()
{
HttpGet = new ContainerAppHttpRequestInfo(8080)
{
HttpHeaders =
{
new ContainerAppHttpHeaderInfo("Custom-Header","Awesome")
},
Path = "/health",
},
InitialDelaySeconds = 5,
PeriodSeconds = 3,
ProbeType = ContainerAppProbeType.Liveness,
}
},
Image = "repo/testcontainerAppsJob0:v1",
Name = "testcontainerAppsJob0",
}
},
                },
            };
            return data;
        }

        public static void AssertContainerAppJobData(ContainerAppJobData data1, ContainerAppJobData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.EnvironmentId, data2.EnvironmentId);
            Assert.AreEqual(data1.Configuration.TriggerType, data2.Configuration.TriggerType);
            Assert.AreEqual(data1.Configuration.ReplicaRetryLimit, data2.Configuration.ReplicaRetryLimit);
            Assert.AreEqual(data1.Configuration.ManualTriggerConfig.ReplicaCompletionCount, data2.Configuration.ManualTriggerConfig.ReplicaCompletionCount);
        }
        #endregion

        #region ContainerAppManagedCertificateData
        public static ContainerAppManagedCertificateData GetManagedCertificateData()
        {
            ContainerAppManagedCertificateData data = new ContainerAppManagedCertificateData(new AzureLocation("East US"))
            {
                Properties = new ManagedCertificateProperties()
                {
                    SubjectName = "my-subject-name.company.country.net",
                    DomainControlValidation = ManagedCertificateDomainControlValidation.Cname,
                },
            };
            return data;
        }
        #endregion

        #region ContainerAppManagedEnvironmentData
        public static ContainerAppManagedEnvironmentData GetManagedEnvironmentData()
        {
            ContainerAppManagedEnvironmentData data = new ContainerAppManagedEnvironmentData(new AzureLocation("East US"))
            {
                DaprAIConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://northcentralus-0.in.applicationinsights.azure.com/",
                VnetConfiguration = new ContainerAppVnetConfiguration()
                {
                    InfrastructureSubnetId = new ResourceIdentifier("/subscriptions/34adfa4f-cedf-4dc0-ba29-b6d1a69ab345/resourceGroups/RGName/providers/Microsoft.Network/virtualNetworks/VNetName/subnets/subnetName1"),
                },
                AppLogsConfiguration = new ContainerAppLogsConfiguration()
                {
                    LogAnalyticsConfiguration = new ContainerAppLogAnalyticsConfiguration()
                    {
                        CustomerId = "string",
                        SharedKey = "string",
                    },
                },
                IsZoneRedundant = true,
                CustomDomainConfiguration = new ContainerAppCustomDomainConfiguration()
                {
                    DnsSuffix = "www.my-name.com",
                    CertificateValue = Convert.FromBase64String("Y2VydA=="),
                    CertificatePassword = "1234",
                },
                WorkloadProfiles =
{
new ContainerAppWorkloadProfile("My-GP-01","GeneralPurpose")
{
MinimumNodeCount = 3,
MaximumNodeCount = 12,
},new ContainerAppWorkloadProfile("My-MO-01","MemoryOptimized")
{
MinimumNodeCount = 3,
MaximumNodeCount = 6,
},new ContainerAppWorkloadProfile("My-CO-01","ComputeOptimized")
{
MinimumNodeCount = 3,
MaximumNodeCount = 6,
},new ContainerAppWorkloadProfile("My-consumption-01","Consumption")
},
                InfrastructureResourceGroup = "myInfrastructureRgName",
            };
            return data;
        }

        public static void AssertContainerAppManagedEnvironmentData(ContainerAppManagedEnvironmentData data1, ContainerAppManagedEnvironmentData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data2.DaprAIConnectionString, data1.DaprAIConnectionString);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.IsZoneRedundant, data2.IsZoneRedundant);
            Assert.AreEqual(data1.CustomDomainConfiguration.SubjectName, data2.CustomDomainConfiguration.SubjectName);
            Assert.AreEqual(data1.CustomDomainConfiguration.DnsSuffix, data2.CustomDomainConfiguration.DnsSuffix);
        }
        #endregion

        #region ContainerAppDaprComponentData
        #endregion
        #region ContainerAppSourceControlData
        public static ContainerAppSourceControlData GetSourceControlData()
        {
            ContainerAppSourceControlData data = new ContainerAppSourceControlData()
            {
                RepoUri = new Uri("https://github.com/xwang971/ghatest"),
                Branch = "master",
                GitHubActionConfiguration = new ContainerAppGitHubActionConfiguration()
                {
                    RegistryInfo = new ContainerAppRegistryInfo()
                    {
                        RegistryServer = "xwang971reg.azurecr.io",
                        RegistryUserName = "xwang971reg",
                        RegistryPassword = "<registrypassword>",
                    },
                    AzureCredentials = new ContainerAppCredentials()
                    {
                        ClientId = "<clientid>",
                        ClientSecret = "<clientsecret>",
                        TenantId = Guid.Parse("<tenantid>"),
                    },
                    ContextPath = "./",
                    Image = "image/tag",
                },
            };
            return data;
        }

        public static void AssertContainerAppSourceControlData(ContainerAppSourceControlData data1, ContainerAppSourceControlData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Branch, data2.Branch);
            Assert.AreEqual(data1.RepoUri, data2.RepoUri);
            Assert.AreEqual(data1.GitHubActionConfiguration.RegistryInfo.RegistryUserName, data2.GitHubActionConfiguration.RegistryInfo.RegistryUserName);
            Assert.AreEqual(data1.GitHubActionConfiguration.RegistryInfo.RegistryPassword, data2.GitHubActionConfiguration.RegistryInfo.RegistryPassword);
            Assert.AreEqual(data1.GitHubActionConfiguration.AzureCredentials.ClientId, data2.GitHubActionConfiguration.AzureCredentials.TenantId);
            Assert.AreEqual(data1.GitHubActionConfiguration.AzureCredentials.ClientSecret, data2.GitHubActionConfiguration.AzureCredentials.ClientSecret)
        }
        #endregion
    }
}
