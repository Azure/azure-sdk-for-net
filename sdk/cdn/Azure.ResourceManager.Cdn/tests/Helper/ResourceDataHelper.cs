// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Tests.Helper
{
    public static class ResourceDataHelper
    {
        public static ProfileData CreateProfileData(CdnSkuName skuName) => new ProfileData(AzureLocation.WestUS, new CdnSku { Name = skuName });

        public static ProfileData CreateAfdProfileData(CdnSkuName skuName) => new ProfileData("Global", new CdnSku { Name = skuName })
        {
            OriginResponseTimeoutSeconds = 60
        };

        public static CdnEndpointData CreateEndpointData() => new CdnEndpointData(AzureLocation.WestUS)
        {
            IsHttpAllowed = true,
            IsHttpsAllowed = true,
            OptimizationType = OptimizationType.GeneralWebDelivery
        };

        public static FrontDoorEndpointData CreateAfdEndpointData() => new FrontDoorEndpointData(AzureLocation.WestUS);

        public static DeepCreatedOrigin CreateDeepCreatedOrigin() => new DeepCreatedOrigin("testOrigin")
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 3,
            Weight = 100
        };

        public static DeepCreatedOriginGroup CreateDeepCreatedOriginGroup() => new DeepCreatedOriginGroup("testOriginGroup")
        {
            HealthProbeSettings = new HealthProbeSettings
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = HealthProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            }
        };

        public static CdnOriginData CreateOriginData() => new CdnOriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 1,
            Weight = 150
        };

        public static FrontDoorOriginData CreateAfdOriginData() => new FrontDoorOriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net"
        };

        public static CdnOriginGroupData CreateOriginGroupData() => new CdnOriginGroupData();

        public static FrontDoorOriginGroupData CreateAfdOriginGroupData() => new FrontDoorOriginGroupData
        {
            HealthProbeSettings = new HealthProbeSettings
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = HealthProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            },
            LoadBalancingSettings = new LoadBalancingSettings
            {
                SampleSize = 5,
                SuccessfulSamplesRequired = 4,
                AdditionalLatencyInMilliseconds = 200
            }
        };

        public static CdnCustomDomainCreateOrUpdateContent CreateCdnCustomDomainData(string hostName) => new CdnCustomDomainCreateOrUpdateContent
        {
            HostName = hostName
        };

        public static FrontDoorCustomDomainData CreateAfdCustomDomainData(string hostName) => new FrontDoorCustomDomainData
        {
            HostName = hostName,
            TlsSettings = new FrontDoorCustomDomainHttpsContent(FrontDoorCertificateType.ManagedCertificate)
            {
                MinimumTlsVersion = FrontDoorMinimumTlsVersion.Tls1_2
            },
            DnsZone = new WritableSubResource
            {
                Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/azure_cli_test/providers/Microsoft.Network/dnsZones/azuretest.net")
            }
        };

        public static FrontDoorRuleData CreateAfdRuleData() => new FrontDoorRuleData
        {
            Order = 1
        };

        public static DeliveryRuleCondition CreateDeliveryRuleCondition() => new DeliveryRuleRequestUriCondition(new RequestUriMatchCondition(RequestUriMatchConditionType.RequestUriCondition, RequestUriOperator.Any));

        public static DeliveryRuleAction CreateDeliveryRuleOperation() => new DeliveryRuleRouteConfigurationOverrideAction(new RouteConfigurationOverrideActionProperties(RouteConfigurationOverrideActionType.RouteConfigurationOverrideAction)
        {
            CacheConfiguration = new CacheConfiguration()
            {
                QueryStringCachingBehavior = RuleQueryStringCachingBehavior.IgnoreSpecifiedQueryStrings,
                QueryParameters = "a=test,b=test",
                IsCompressionEnabled = RuleIsCompressionEnabled.Enabled,
                CacheBehavior = RuleCacheBehavior.HonorOrigin
            }
        });

        public static FrontDoorRouteData CreateAfdRouteData(FrontDoorOriginGroupResource originGroup) => new FrontDoorRouteData
        {
            OriginGroup = new WritableSubResource
            {
                Id = originGroup.Id
            },
            LinkToDefaultDomain = LinkToDefaultDomain.Enabled,
            EnabledState = EnabledState.Enabled
        };

        public static FrontDoorSecurityPolicyData CreateAfdSecurityPolicyData(FrontDoorEndpointResource endpoint) => new FrontDoorSecurityPolicyData
        {
            Properties = new SecurityPolicyWebApplicationFirewall
            {
                WafPolicy = new WritableSubResource
                {
                    Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/azure_cli_test/providers/Microsoft.Network/FrontDoorWebApplicationFirewallPolicies/azureCliTest")
                }
            }
        };

        public static FrontDoorSecretData CreateAfdSecretData() => new FrontDoorSecretData
        {
            Properties = new CustomerCertificateProperties(new WritableSubResource
            {
                Id = new ResourceIdentifier("/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/CliDevReservedGroup/providers/Microsoft.KeyVault/vaults/clibyoc-int/secrets/localdev-multi")
            })
            {
                UseLatestVersion = true
            }
        };

        public static CdnWebApplicationFirewallPolicyData CreateCdnWebApplicationFirewallPolicyData() => new CdnWebApplicationFirewallPolicyData("Global", new CdnSku
        {
            Name = CdnSkuName.StandardMicrosoft
        });

        public static void AssertValidProfile(ProfileResource model, ProfileResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.Sku.Name, Is.EqualTo(model.Data.Sku.Name));
                Assert.That(getResult.Data.Kind, Is.EqualTo(model.Data.Kind));
                Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.FrontDoorId, Is.EqualTo(model.Data.FrontDoorId));
                Assert.That(getResult.Data.OriginResponseTimeoutSeconds, Is.EqualTo(model.Data.OriginResponseTimeoutSeconds));
            });
        }

        public static void AssertProfileUpdate(ProfileResource updatedProfile, ProfilePatch updateOptions)
        {
            Assert.That(updateOptions.Tags, Has.Count.EqualTo(updatedProfile.Data.Tags.Count));
            foreach (var kv in updatedProfile.Data.Tags)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(updateOptions.Tags.ContainsKey(kv.Key), Is.True);
                    Assert.That(updateOptions.Tags[kv.Key], Is.EqualTo(kv.Value));
                });
            }
        }

        public static void AssertProfileUpdate(ProfileResource updatedProfile, string key, string value)
        {
            Assert.That(updatedProfile.Data.Tags.Count, Is.GreaterThanOrEqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(updatedProfile.Data.Tags.ContainsKey(key), Is.True);
                Assert.That(value, Is.EqualTo(updatedProfile.Data.Tags[key]));
            });
        }

        public static void AssertValidEndpoint(CdnEndpointResource model, CdnEndpointResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.OriginPath, Is.EqualTo(model.Data.OriginPath));
                Assert.That(getResult.Data.OriginHostHeader, Is.EqualTo(model.Data.OriginHostHeader));
                Assert.That(getResult.Data.IsCompressionEnabled, Is.EqualTo(model.Data.IsCompressionEnabled));
                Assert.That(getResult.Data.IsHttpAllowed, Is.EqualTo(model.Data.IsHttpAllowed));
                Assert.That(getResult.Data.IsHttpsAllowed, Is.EqualTo(model.Data.IsHttpsAllowed));
                Assert.That(getResult.Data.QueryStringCachingBehavior, Is.EqualTo(model.Data.QueryStringCachingBehavior));
                Assert.That(getResult.Data.OptimizationType, Is.EqualTo(model.Data.OptimizationType));
                Assert.That(getResult.Data.ProbePath, Is.EqualTo(model.Data.ProbePath));
                Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
                Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            });
            //Todo: ContentTypesToCompress, GeoFilters, DefaultOriginGroup, UrlSigningKeys, DeliveryPolicy, WebApplicationFirewallPolicyLink, Origins, OriginGroups
        }

        public static void AssertEndpointUpdate(CdnEndpointResource updatedEndpoint, CdnEndpointPatch updateOptions)
        {
            Assert.Multiple(() =>
            {
                Assert.That(updateOptions.IsHttpAllowed, Is.EqualTo(updatedEndpoint.Data.IsHttpAllowed));
                Assert.That(updateOptions.OriginPath, Is.EqualTo(updatedEndpoint.Data.OriginPath));
                Assert.That(updateOptions.OriginHostHeader, Is.EqualTo(updatedEndpoint.Data.OriginHostHeader));
            });
        }

        public static void AssertValidAfdEndpoint(FrontDoorEndpointResource model, FrontDoorEndpointResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.EnabledState, Is.EqualTo(model.Data.EnabledState));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
                Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
            });
        }

        public static void AssertAfdEndpointUpdate(FrontDoorEndpointResource updatedAfdEndpoint, FrontDoorEndpointPatch updateOptions)
        {
            Assert.That(updateOptions.Tags, Has.Count.EqualTo(updatedAfdEndpoint.Data.Tags.Count));
            foreach (var kv in updatedAfdEndpoint.Data.Tags)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(updateOptions.Tags.ContainsKey(kv.Key), Is.True);
                    Assert.That(updateOptions.Tags[kv.Key], Is.EqualTo(kv.Value));
                });
            }
        }

        public static void AssertValidOrigin(CdnOriginResource model, CdnOriginResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
                Assert.That(getResult.Data.HttpPort, Is.EqualTo(model.Data.HttpPort));
                Assert.That(getResult.Data.HttpsPort, Is.EqualTo(model.Data.HttpsPort));
                Assert.That(getResult.Data.OriginHostHeader, Is.EqualTo(model.Data.OriginHostHeader));
                Assert.That(getResult.Data.Priority, Is.EqualTo(model.Data.Priority));
                Assert.That(getResult.Data.Weight, Is.EqualTo(model.Data.Weight));
                Assert.That(getResult.Data.Enabled, Is.EqualTo(model.Data.Enabled));
                Assert.That(getResult.Data.PrivateLinkAlias, Is.EqualTo(model.Data.PrivateLinkAlias));
                Assert.That(getResult.Data.PrivateLinkResourceId, Is.EqualTo(model.Data.PrivateLinkResourceId));
                Assert.That(getResult.Data.PrivateLinkLocation, Is.EqualTo(model.Data.PrivateLinkLocation));
                Assert.That(getResult.Data.PrivateLinkApprovalMessage, Is.EqualTo(model.Data.PrivateLinkApprovalMessage));
                Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.PrivateEndpointStatus, Is.EqualTo(model.Data.PrivateEndpointStatus));
            });
        }

        public static void AssertOriginUpdate(CdnOriginResource updatedOrigin, CdnOriginPatch updateOptions)
        {
            Assert.That(updateOptions.HttpPort, Is.EqualTo(updatedOrigin.Data.HttpPort));
            Assert.That(updateOptions.HttpsPort, Is.EqualTo(updatedOrigin.Data.HttpsPort));
            Assert.That(updateOptions.Priority, Is.EqualTo(updatedOrigin.Data.Priority));
            Assert.That(updateOptions.Weight, Is.EqualTo(updatedOrigin.Data.Weight));
        }

        public static void AssertValidAfdOrigin(FrontDoorOriginResource model, FrontDoorOriginResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            if (model.Data.Origin != null || getResult.Data.Origin != null)
            {
                Assert.That(model.Data.Origin, Is.Not.Null);
                Assert.That(getResult.Data.Origin, Is.Not.Null);
                Assert.That(getResult.Data.Origin.Id, Is.EqualTo(model.Data.Origin.Id));
            }
            Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
            Assert.That(getResult.Data.HttpPort, Is.EqualTo(model.Data.HttpPort));
            Assert.That(getResult.Data.HttpsPort, Is.EqualTo(model.Data.HttpsPort));
            Assert.That(getResult.Data.OriginHostHeader, Is.EqualTo(model.Data.OriginHostHeader));
            Assert.That(getResult.Data.Priority, Is.EqualTo(model.Data.Priority));
            Assert.That(getResult.Data.Weight, Is.EqualTo(model.Data.Weight));
            Assert.That(getResult.Data.EnabledState, Is.EqualTo(model.Data.EnabledState));
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            //Todo:SharedPrivateLinkResource
        }

        public static void AssertAfdOriginUpdate(FrontDoorOriginResource updatedAfdOrigin, FrontDoorOriginPatch updateOptions)
        {
            Assert.That(updateOptions.Priority, Is.EqualTo(updatedAfdOrigin.Data.Priority));
            Assert.That(updateOptions.Weight, Is.EqualTo(updatedAfdOrigin.Data.Weight));
        }

        public static void AssertValidOriginGroup(CdnOriginGroupResource model, CdnOriginGroupResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.That(model.Data.HealthProbeSettings, Is.Not.Null);
                Assert.That(getResult.Data.HealthProbeSettings, Is.Not.Null);
                Assert.That(getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds, Is.EqualTo(model.Data.HealthProbeSettings.ProbeIntervalInSeconds));
                Assert.That(getResult.Data.HealthProbeSettings.ProbePath, Is.EqualTo(model.Data.HealthProbeSettings.ProbePath));
                Assert.That(getResult.Data.HealthProbeSettings.ProbeProtocol, Is.EqualTo(model.Data.HealthProbeSettings.ProbeProtocol));
                Assert.That(getResult.Data.HealthProbeSettings.ProbeRequestType, Is.EqualTo(model.Data.HealthProbeSettings.ProbeRequestType));
            }
            Assert.That(getResult.Data.Origins, Has.Count.EqualTo(model.Data.Origins.Count));
            for (int i = 0; i < model.Data.Origins.Count; ++i)
            {
                Assert.That(getResult.Data.Origins[i].Id, Is.EqualTo(model.Data.Origins[i].Id));
            }
            Assert.That(getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, Is.EqualTo(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes));
            Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            //Todo: ResponseBasedOriginErrorDetectionSettings
        }

        public static void AssertOriginGroupUpdate(CdnOriginGroupResource updatedOriginGroup, CdnOriginGroupPatch updateOptions)
        {
            Assert.That(updateOptions.HealthProbeSettings.ProbePath, Is.EqualTo(updatedOriginGroup.Data.HealthProbeSettings.ProbePath));
            Assert.That(updateOptions.HealthProbeSettings.ProbeRequestType, Is.EqualTo(updatedOriginGroup.Data.HealthProbeSettings.ProbeRequestType));
            Assert.That(updateOptions.HealthProbeSettings.ProbeProtocol, Is.EqualTo(updatedOriginGroup.Data.HealthProbeSettings.ProbeProtocol));
            Assert.That(updateOptions.HealthProbeSettings.ProbeIntervalInSeconds, Is.EqualTo(updatedOriginGroup.Data.HealthProbeSettings.ProbeIntervalInSeconds));
        }

        public static void AssertValidAfdOriginGroup(FrontDoorOriginGroupResource model, FrontDoorOriginGroupResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            if (model.Data.LoadBalancingSettings != null || getResult.Data.LoadBalancingSettings != null)
            {
                Assert.That(model.Data.LoadBalancingSettings, Is.Not.Null);
                Assert.That(getResult.Data.LoadBalancingSettings, Is.Not.Null);
                Assert.That(getResult.Data.LoadBalancingSettings.SampleSize, Is.EqualTo(model.Data.LoadBalancingSettings.SampleSize));
                Assert.That(getResult.Data.LoadBalancingSettings.SuccessfulSamplesRequired, Is.EqualTo(model.Data.LoadBalancingSettings.SuccessfulSamplesRequired));
                Assert.That(getResult.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, Is.EqualTo(model.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds));
            }
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.That(model.Data.HealthProbeSettings, Is.Not.Null);
                Assert.That(getResult.Data.HealthProbeSettings, Is.Not.Null);
                Assert.That(getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds, Is.EqualTo(model.Data.HealthProbeSettings.ProbeIntervalInSeconds));
                Assert.That(getResult.Data.HealthProbeSettings.ProbePath, Is.EqualTo(model.Data.HealthProbeSettings.ProbePath));
                Assert.That(getResult.Data.HealthProbeSettings.ProbeProtocol, Is.EqualTo(model.Data.HealthProbeSettings.ProbeProtocol));
                Assert.That(getResult.Data.HealthProbeSettings.ProbeRequestType, Is.EqualTo(model.Data.HealthProbeSettings.ProbeRequestType));
            }
            Assert.That(getResult.Data.TrafficRestorationTimeInMinutes, Is.EqualTo(model.Data.TrafficRestorationTimeInMinutes));
            Assert.That(getResult.Data.SessionAffinityState, Is.EqualTo(model.Data.SessionAffinityState));
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            //Todo: ResponseBasedAfdOriginErrorDetectionSettings
        }

        public static void AssertAfdOriginGroupUpdate(FrontDoorOriginGroupResource updatedAfdOriginGroup, FrontDoorOriginGroupPatch updateOptions)
        {
            Assert.That(updateOptions.LoadBalancingSettings.SampleSize, Is.EqualTo(updatedAfdOriginGroup.Data.LoadBalancingSettings.SampleSize));
            Assert.That(updateOptions.LoadBalancingSettings.SuccessfulSamplesRequired, Is.EqualTo(updatedAfdOriginGroup.Data.LoadBalancingSettings.SuccessfulSamplesRequired));
            Assert.That(updateOptions.LoadBalancingSettings.AdditionalLatencyInMilliseconds, Is.EqualTo(updatedAfdOriginGroup.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds));
        }

        public static void AssertValidCustomDomain(CdnCustomDomainResource model, CdnCustomDomainResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
            Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
            Assert.That(getResult.Data.CustomHttpsProvisioningState, Is.EqualTo(model.Data.CustomHttpsProvisioningState));
            Assert.That(getResult.Data.CustomHttpsAvailabilityState, Is.EqualTo(model.Data.CustomHttpsAvailabilityState));
            Assert.That(getResult.Data.ValidationData, Is.EqualTo(model.Data.ValidationData));
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
        }

        public static void AssertValidAfdCustomDomain(FrontDoorCustomDomainResource model, FrontDoorCustomDomainResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.TlsSettings.CertificateType, Is.EqualTo(model.Data.TlsSettings.CertificateType));
            Assert.That(getResult.Data.TlsSettings.MinimumTlsVersion, Is.EqualTo(model.Data.TlsSettings.MinimumTlsVersion));
            if (model.Data.TlsSettings.Secret != null || getResult.Data.TlsSettings.Secret != null)
            {
                Assert.That(model.Data.TlsSettings.Secret, Is.Not.Null);
                Assert.That(getResult.Data.TlsSettings.Secret, Is.Not.Null);
                Assert.That(getResult.Data.TlsSettings.Secret.Id, Is.EqualTo(model.Data.TlsSettings.Secret.Id));
            }
            if (model.Data.DnsZone != null || getResult.Data.DnsZone != null)
            {
                Assert.That(model.Data.DnsZone, Is.Not.Null);
                Assert.That(getResult.Data.DnsZone, Is.Not.Null);
                Assert.That(getResult.Data.DnsZone.Id, Is.EqualTo(model.Data.DnsZone.Id));
            }
            Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            Assert.That(getResult.Data.DomainValidationState, Is.EqualTo(model.Data.DomainValidationState));
            Assert.That(getResult.Data.HostName, Is.EqualTo(model.Data.HostName));
            if (model.Data.ValidationProperties != null || getResult.Data.ValidationProperties != null)
            {
                Assert.That(model.Data.ValidationProperties, Is.Not.Null);
                Assert.That(getResult.Data.ValidationProperties, Is.Not.Null);
                Assert.That(getResult.Data.ValidationProperties.ValidationToken, Is.EqualTo(model.Data.ValidationProperties.ValidationToken));
                Assert.That(getResult.Data.ValidationProperties.ExpiresOn, Is.EqualTo(model.Data.ValidationProperties.ExpiresOn));
            }
        }

        public static void AssertAfdDomainUpdate(FrontDoorCustomDomainResource updatedAfdDomain, FrontDoorCustomDomainPatch updateOptions)
        {
            Assert.That(updateOptions.TlsSettings.CertificateType, Is.EqualTo(updatedAfdDomain.Data.TlsSettings.CertificateType));
            Assert.That(updateOptions.TlsSettings.MinimumTlsVersion, Is.EqualTo(updatedAfdDomain.Data.TlsSettings.MinimumTlsVersion));
        }

        public static void AssertValidAfdRuleSet(FrontDoorRuleSetResource model, FrontDoorRuleSetResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            });
        }

        public static void AssertValidAfdRule(FrontDoorRuleResource model, FrontDoorRuleResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.Order, Is.EqualTo(model.Data.Order));
                Assert.That(getResult.Data.Conditions, Has.Count.EqualTo(model.Data.Conditions.Count));
            });
            for (int i = 0; i < model.Data.Conditions.Count; ++i)
            {
                Assert.That(getResult.Data.Conditions[i].Name, Is.EqualTo(model.Data.Conditions[i].Name));
            }
            Assert.That(getResult.Data.Actions, Has.Count.EqualTo(model.Data.Actions.Count));
            for (int i = 0; i < model.Data.Actions.Count; ++i)
            {
                Assert.That(getResult.Data.Actions[i].Name, Is.EqualTo(model.Data.Actions[i].Name));
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.MatchProcessingBehavior, Is.EqualTo(model.Data.MatchProcessingBehavior));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            });
        }

        public static void AssertAfdRuleUpdate(FrontDoorRuleResource updatedRule, FrontDoorRulePatch updateOptions)
        {
            Assert.That(updateOptions.Order, Is.EqualTo(updatedRule.Data.Order));
        }

        public static void AssertValidAfdRoute(FrontDoorRouteResource model, FrontDoorRouteResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.CustomDomains, Has.Count.EqualTo(model.Data.CustomDomains.Count));
            });
            for (int i = 0; i < model.Data.CustomDomains.Count; ++i)
            {
                Assert.That(getResult.Data.CustomDomains[i].Id, Is.EqualTo(model.Data.CustomDomains[i].Id));
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.OriginGroup.Id, Is.EqualTo(model.Data.OriginGroup.Id));
                Assert.That(getResult.Data.OriginPath, Is.EqualTo(model.Data.OriginPath));
                Assert.That(getResult.Data.RuleSets, Has.Count.EqualTo(model.Data.RuleSets.Count));
            });
            for (int i = 0; i < model.Data.RuleSets.Count; ++i)
            {
                Assert.That(getResult.Data.RuleSets[i].Id, Is.EqualTo(model.Data.RuleSets[i].Id));
            }
            Assert.That(getResult.Data.SupportedProtocols, Has.Count.EqualTo(model.Data.SupportedProtocols.Count));
            for (int i = 0; i < model.Data.SupportedProtocols.Count; ++i)
            {
                Assert.That(getResult.Data.SupportedProtocols[i], Is.EqualTo(model.Data.SupportedProtocols[i]));
            }
            Assert.That(getResult.Data.PatternsToMatch, Has.Count.EqualTo(model.Data.PatternsToMatch.Count));
            for (int i = 0; i < model.Data.PatternsToMatch.Count; ++i)
            {
                Assert.That(getResult.Data.PatternsToMatch[i], Is.EqualTo(model.Data.PatternsToMatch[i]));
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.EndpointName, Is.EqualTo(model.Data.EndpointName));
                Assert.That(getResult.Data.ForwardingProtocol, Is.EqualTo(model.Data.ForwardingProtocol));
                Assert.That(getResult.Data.LinkToDefaultDomain, Is.EqualTo(model.Data.LinkToDefaultDomain));
                Assert.That(getResult.Data.HttpsRedirect, Is.EqualTo(model.Data.HttpsRedirect));
                Assert.That(getResult.Data.EnabledState, Is.EqualTo(model.Data.EnabledState));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
            });
        }

        public static void AssertAfdRouteUpdate(FrontDoorRouteResource updatedRoute, FrontDoorRoutePatch updateOptions)
        {
            Assert.That(updateOptions.EnabledState, Is.EqualTo(updatedRoute.Data.EnabledState));
        }

        public static void AssertValidAfdSecurityPolicy(FrontDoorSecurityPolicyResource model, FrontDoorSecurityPolicyResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
                Assert.That(getResult.Data.Properties.PolicyType, Is.EqualTo(model.Data.Properties.PolicyType));
            });
        }

        public static void AssertAfdSecurityPolicyUpdate(FrontDoorSecurityPolicyResource updatedSecurityPolicy, FrontDoorSecurityPolicyPatch updateOptions)
        {
            Assert.That(((SecurityPolicyWebApplicationFirewall)updatedSecurityPolicy.Data.Properties).Associations, Has.Count.EqualTo(1));
            Assert.That(((SecurityPolicyWebApplicationFirewall)updatedSecurityPolicy.Data.Properties).Associations[0].Domains, Has.Count.EqualTo(2));
        }

        public static void AssertValidPolicy(CdnWebApplicationFirewallPolicyResource model, CdnWebApplicationFirewallPolicyResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.ETag, Is.EqualTo(model.Data.ETag));
                Assert.That(getResult.Data.Sku.Name, Is.EqualTo(model.Data.Sku.Name));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.ResourceState, Is.EqualTo(model.Data.ResourceState));
            });
            //Todo: PolicySettings, RateLimitRules, CustomRules, ManagedRules, EndpointLinks
        }

        public static void AssertPolicyUpdate(CdnWebApplicationFirewallPolicyResource updatedPolicy, string key, string value)
        {
            Assert.That(updatedPolicy.Data.Tags.Count, Is.GreaterThanOrEqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(updatedPolicy.Data.Tags.ContainsKey(key), Is.True);
                Assert.That(value, Is.EqualTo(updatedPolicy.Data.Tags[key]));
            });
        }

        public static void AssertValidAfdSecret(FrontDoorSecretResource model, FrontDoorSecretResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
                Assert.That(getResult.Data.DeploymentStatus, Is.EqualTo(model.Data.DeploymentStatus));
                Assert.That(getResult.Data.Properties.SecretType, Is.EqualTo(model.Data.Properties.SecretType));
                Assert.That(((CustomerCertificateProperties)getResult.Data.Properties).SecretVersion, Is.EqualTo(((CustomerCertificateProperties)model.Data.Properties).SecretVersion));
                Assert.That(((CustomerCertificateProperties)getResult.Data.Properties).CertificateAuthority, Is.EqualTo(((CustomerCertificateProperties)model.Data.Properties).CertificateAuthority));
                Assert.That(((CustomerCertificateProperties)getResult.Data.Properties).UseLatestVersion, Is.EqualTo(((CustomerCertificateProperties)model.Data.Properties).UseLatestVersion));
                Assert.That(((CustomerCertificateProperties)getResult.Data.Properties).SecretSource.Id.Name.ToString().ToLower(), Is.EqualTo(((CustomerCertificateProperties)model.Data.Properties).SecretSource.Id.Name.ToString().ToLower()));
                Assert.That(((CustomerCertificateProperties)model.Data.Properties).SubjectAlternativeNames.SequenceEqual(((CustomerCertificateProperties)getResult.Data.Properties).SubjectAlternativeNames), Is.True);
            });
        }
    }
}
