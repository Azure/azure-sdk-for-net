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
        #endregion
    }
}
