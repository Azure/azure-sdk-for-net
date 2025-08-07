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
using Castle.Core.Resource;

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
                        /*Registration = new ContainerAppRegistration()
                        {
                            AppId = "123",
                            AppSecretSettingName = "facebook-secret",
                        },*/
                    },
                },
            };
            return data;
        }

        public static void AssertContainerAppAuthConfigData(ContainerAppAuthConfigData data1, ContainerAppAuthConfigData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.GlobalValidation.UnauthenticatedClientAction, data2.GlobalValidation.UnauthenticatedClientAction);
            Assert.AreEqual(data1.Platform.IsEnabled, data2.Platform.IsEnabled);
            Assert.AreEqual(data1.GlobalValidation.UnauthenticatedClientAction, data2.GlobalValidation.UnauthenticatedClientAction);
        }
        #endregion

        #region containerapp
        public static ContainerAppData GetContainerAppData(ContainerAppManagedEnvironmentResource envResource)
        {
            ContainerAppData data = new ContainerAppData(AzureLocation.WestUS)
            {
                WorkloadProfileName = "gp1",
                ManagedEnvironmentId = new ResourceIdentifier(envResource.Data.Id),
                Configuration = new ContainerAppConfiguration
                {
                    Ingress = new ContainerAppIngressConfiguration
                    {
                        External = true,
                        TargetPort = 3000,
                    },
                },
                Template = new ContainerAppTemplate
                {
                    Containers =
                        {
                            new ContainerAppContainer
                            {
                                Image = $"mcr.microsoft.com/k8se/quickstart-jobs:latest",
                                Name = "appcontainer",
                                Resources = new AppContainerResources
                                {
                                    Cpu = 0.25,
                                    Memory = "0.5Gi"
                                }
                            }
                        },
                    Scale = new ContainerAppScale
                    {
                        MinReplicas = 1,
                        MaxReplicas = 5,
                        Rules =
                            {
                                new ContainerAppScaleRule
                                {
                                    Name = "httpscale",
                                    Custom = new ContainerAppCustomScaleRule
                                    {
                                        CustomScaleRuleType = "http",
                                        Metadata =
                                        {
                                            { "concurrentRequests", "50" }
                                        }
                                    }
                                }
                            }
                    },
                }
            };
            return data;
        }

        public static void AssertContainerAppData(ContainerAppData data1,  ContainerAppData data2)
        {
            AssertResource(data1, data2);
            //Assert.AreEqual(data1.Configuration.Dapr.AppId, data2.Configuration.Dapr.AppId);
            Assert.AreEqual(data1.CustomDomainVerificationId, data2.CustomDomainVerificationId);
            Assert.AreEqual(data1.EnvironmentId, data2.EnvironmentId);
        }
        #endregion

        #region Certificate
        public static ContainerAppCertificateData GetCertificateData()
        {
            ContainerAppCertificateData data = new ContainerAppCertificateData(AzureLocation.EastUS)
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

        #region Connectedenviroment
        public static ContainerAppConnectedEnvironmentData GetEnvironmentData(ResourceIdentifier customlocationId)
        {
            ContainerAppConnectedEnvironmentData data = new ContainerAppConnectedEnvironmentData(AzureLocation.NorthCentralUS)
            {
                StaticIP = IPAddress.Parse("1.2.3.4"),
                DaprAIConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://northcentralus-0.in.applicationinsights.azure.com/",
                CustomDomainConfiguration = new ContainerAppCustomDomainConfiguration()
                {
                    DnsSuffix = "www.my-name.com",
                    CertificateValue = Convert.FromBase64String("Y2VydA=="),
                    CertificatePassword = "private key password",
                },
                ExtendedLocation = new ContainerAppExtendedLocation()
                {
                    Name = customlocationId,
                    ExtendedLocationType = ContainerAppExtendedLocationType.CustomLocation
                }
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
        public static ContainerAppConnectedEnvironmentStorageData GetConnectedEnvironmentStorageData()
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

        public static void AssertConnectedEnviromentStorageData(ContainerAppConnectedEnvironmentStorageData data1, ContainerAppConnectedEnvironmentStorageData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccountName, data2.ConnectedEnvironmentStorageAzureFile.AccountName);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccountKey, data2.ConnectedEnvironmentStorageAzureFile.AccountKey);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.ShareName, data2.ConnectedEnvironmentStorageAzureFile.ShareName);
            Assert.AreEqual(data1.ConnectedEnvironmentStorageAzureFile.AccessMode, data2.ConnectedEnvironmentStorageAzureFile.AccessMode);
        }
        #endregion

        #region ContainerAppManagedEnvironmentStorageData
        public static ContainerAppManagedEnvironmentStorageData GetManagedEnvironmentStorageData()
        {
            ContainerAppManagedEnvironmentStorageData data = new ContainerAppManagedEnvironmentStorageData()
            {
                ManagedEnvironmentStorageAzureFile = new ContainerAppAzureFileProperties()
                {
                    AccountName = "account1",
                    AccountKey = "key",
                    AccessMode = ContainerAppAccessMode.ReadOnly,
                    ShareName = "share1",
                },
            };
            return data;
        }

        public static void AssertManagedEnviromentStorageData(ContainerAppManagedEnvironmentStorageData data1, ContainerAppManagedEnvironmentStorageData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.ManagedEnvironmentStorageAzureFile.AccountName, data2.ManagedEnvironmentStorageAzureFile.AccountName);
            Assert.AreEqual(data1.ManagedEnvironmentStorageAzureFile.AccountKey, data2.ManagedEnvironmentStorageAzureFile.AccountKey);
            Assert.AreEqual(data1.ManagedEnvironmentStorageAzureFile.ShareName, data2.ManagedEnvironmentStorageAzureFile.ShareName);
            Assert.AreEqual(data1.ManagedEnvironmentStorageAzureFile.AccessMode, data2.ManagedEnvironmentStorageAzureFile.AccessMode);
        }
        #endregion

        #region ContainerAppJobData
        public static ContainerAppJobData GetJobData(string envId)
        {
            ContainerAppJobData data = new ContainerAppJobData(new AzureLocation("West US"))
            {
                EnvironmentId = envId,
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
Image = "repo/testcontainerappjob-1102:v4",
Name = "testinitcontainerappsjob-1102",
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
Cpu = 0.25,
Memory = "0.5Gi",
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
Image = "repo/testcontainerappsjob-1102:v1",
Name = "testcontainerappsjob-1102",
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
            ContainerAppManagedCertificateData data = new ContainerAppManagedCertificateData(new AzureLocation("West US"))
            {
                Properties = new ManagedCertificateProperties()
                {
                    SubjectName = "appcontainer1102.gentledune-1bbbb9be.westus.azurecontainerapps.io",
                    DomainControlValidation = ManagedCertificateDomainControlValidation.Cname,
                },
            };
            return data;
        }

        public static void AssertCertificateData(ContainerAppManagedCertificateData data1, ContainerAppManagedCertificateData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Location, data2.Location);
            Assert.AreEqual(data1.Properties.SubjectName, data2.Properties.SubjectName);
            Assert.AreEqual(data1.Properties.DomainControlValidation, data2.Properties.DomainControlValidation);
        }
        #endregion

        #region ContainerAppManagedEnvironmentData
        public static ContainerAppManagedEnvironmentData GetManagedEnvironmentData()
        {
            ContainerAppManagedEnvironmentData data = new ContainerAppManagedEnvironmentData(AzureLocation.WestUS)
            {
                WorkloadProfiles =
                {
                    new ContainerAppWorkloadProfile("Consumption", "Consumption"),
                    new ContainerAppWorkloadProfile("gp1", "D4")
                    {
                        MinimumCount = 1,
                        MaximumCount = 3
                    }
                }
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
                Branch = "<< REDACTED >>",
                GitHubActionConfiguration = new ContainerAppGitHubActionConfiguration()
                {
                    RegistryInfo = new ContainerAppRegistryInfo()
                    {
                        RegistryServer = "<< REDACTED >>",
                        RegistryUserName = "<< REDACTED >>",
                        RegistryPassword = "<< REDACTED >>",
                    },
                    AzureCredentials = new ContainerAppCredentials()
                    {
                        ClientId = "<< REDACTED >>",
                        ClientSecret = "<< REDACTED >>",
                        TenantId = Guid.Parse("<< REDACTED >>"),
                        Kind = "feaderated",
                    },
                    ContextPath = "./",
                    Image = "image/tag",
                    GitHubPersonalAccessToken = "test"
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
            Assert.AreEqual(data1.GitHubActionConfiguration.AzureCredentials.ClientSecret, data2.GitHubActionConfiguration.AzureCredentials.ClientSecret);
        }
        #endregion

        # region SessionPoolData
        public static SessionPoolData GetSessionPoolData(ResourceIdentifier envId)
        {
            SessionPoolData data = new SessionPoolData(AzureLocation.WestUS)
            {
                EnvironmentId = envId,
                PoolManagementType = PoolManagementType.Dynamic,
                ContainerType = ContainerType.CustomContainer,
                ScaleConfiguration = new SessionPoolScaleConfiguration() { MaxConcurrentSessions = 10, ReadySessionInstances = 10 },
                DynamicPoolConfiguration = new DynamicPoolConfiguration()
                {
                    LifecycleConfiguration = new SessionPoolLifecycleConfiguration()
                    {
                        CooldownPeriodInSeconds = 1000,
                        LifecycleType = SessionPoolLifecycleType.Timed,
                    }
                },
                CustomContainerTemplate = new CustomContainerTemplate(
                    ingress: new SessionIngress() { TargetPort = 80 },
                    registryCredentials: null,
                    containers: new List<SessionContainer>()
                    {
                        new SessionContainer()
                        {
                            Image = "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest",
                            Name = "testcontainerappsjob-1102",
                            Resources = new SessionContainerResources()
                            {
                                Cpu = 0.25,
                                Memory = "0.5Gi",
                            }
                        }
                    },
                    serializedAdditionalRawData: new Dictionary<string, BinaryData>()
                    )
            };
            return data;
        }

        public static void AssertSessionPoolData(SessionPoolData data1, SessionPoolData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.Name, data2.Name);
            Assert.AreEqual(data1.Secrets, data2.Secrets);
            Assert.AreEqual(data1.ContainerType, data2.ContainerType);
        }
        # endregion
    }
}
