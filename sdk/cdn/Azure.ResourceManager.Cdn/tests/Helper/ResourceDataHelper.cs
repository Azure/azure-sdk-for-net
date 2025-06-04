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
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.Kind, getResult.Data.Kind);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.FrontDoorId, getResult.Data.FrontDoorId);
            Assert.AreEqual(model.Data.OriginResponseTimeoutSeconds, getResult.Data.OriginResponseTimeoutSeconds);
        }

        public static void AssertProfileUpdate(ProfileResource updatedProfile, ProfilePatch updateOptions)
        {
            Assert.AreEqual(updatedProfile.Data.Tags.Count, updateOptions.Tags.Count);
            foreach (var kv in updatedProfile.Data.Tags)
            {
                Assert.True(updateOptions.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateOptions.Tags[kv.Key]);
            }
        }

        public static void AssertProfileUpdate(ProfileResource updatedProfile, string key, string value)
        {
            Assert.GreaterOrEqual(updatedProfile.Data.Tags.Count, 1);
            Assert.IsTrue(updatedProfile.Data.Tags.ContainsKey(key));
            Assert.AreEqual(updatedProfile.Data.Tags[key], value);
        }

        public static void AssertValidEndpoint(CdnEndpointResource model, CdnEndpointResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.OriginPath, getResult.Data.OriginPath);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.IsCompressionEnabled, getResult.Data.IsCompressionEnabled);
            Assert.AreEqual(model.Data.IsHttpAllowed, getResult.Data.IsHttpAllowed);
            Assert.AreEqual(model.Data.IsHttpsAllowed, getResult.Data.IsHttpsAllowed);
            Assert.AreEqual(model.Data.QueryStringCachingBehavior, getResult.Data.QueryStringCachingBehavior);
            Assert.AreEqual(model.Data.OptimizationType, getResult.Data.OptimizationType);
            Assert.AreEqual(model.Data.ProbePath, getResult.Data.ProbePath);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ContentTypesToCompress, GeoFilters, DefaultOriginGroup, UrlSigningKeys, DeliveryPolicy, WebApplicationFirewallPolicyLink, Origins, OriginGroups
        }

        public static void AssertEndpointUpdate(CdnEndpointResource updatedEndpoint, CdnEndpointPatch updateOptions)
        {
            Assert.AreEqual(updatedEndpoint.Data.IsHttpAllowed, updateOptions.IsHttpAllowed);
            Assert.AreEqual(updatedEndpoint.Data.OriginPath, updateOptions.OriginPath);
            Assert.AreEqual(updatedEndpoint.Data.OriginHostHeader, updateOptions.OriginHostHeader);
        }

        public static void AssertValidAfdEndpoint(FrontDoorEndpointResource model, FrontDoorEndpointResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
        }

        public static void AssertAfdEndpointUpdate(FrontDoorEndpointResource updatedAfdEndpoint, FrontDoorEndpointPatch updateOptions)
        {
            Assert.AreEqual(updatedAfdEndpoint.Data.Tags.Count, updateOptions.Tags.Count);
            foreach (var kv in updatedAfdEndpoint.Data.Tags)
            {
                Assert.True(updateOptions.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateOptions.Tags[kv.Key]);
            }
        }

        public static void AssertValidOrigin(CdnOriginResource model, CdnOriginResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.HttpPort, getResult.Data.HttpPort);
            Assert.AreEqual(model.Data.HttpsPort, getResult.Data.HttpsPort);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.Priority, getResult.Data.Priority);
            Assert.AreEqual(model.Data.Weight, getResult.Data.Weight);
            Assert.AreEqual(model.Data.Enabled, getResult.Data.Enabled);
            Assert.AreEqual(model.Data.PrivateLinkAlias, getResult.Data.PrivateLinkAlias);
            Assert.AreEqual(model.Data.PrivateLinkResourceId, getResult.Data.PrivateLinkResourceId);
            Assert.AreEqual(model.Data.PrivateLinkLocation, getResult.Data.PrivateLinkLocation);
            Assert.AreEqual(model.Data.PrivateLinkApprovalMessage, getResult.Data.PrivateLinkApprovalMessage);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.PrivateEndpointStatus, getResult.Data.PrivateEndpointStatus);
        }

        public static void AssertOriginUpdate(CdnOriginResource updatedOrigin, CdnOriginPatch updateOptions)
        {
            Assert.AreEqual(updatedOrigin.Data.HttpPort, updateOptions.HttpPort);
            Assert.AreEqual(updatedOrigin.Data.HttpsPort, updateOptions.HttpsPort);
            Assert.AreEqual(updatedOrigin.Data.Priority, updateOptions.Priority);
            Assert.AreEqual(updatedOrigin.Data.Weight, updateOptions.Weight);
        }

        public static void AssertValidAfdOrigin(FrontDoorOriginResource model, FrontDoorOriginResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            if (model.Data.Origin != null || getResult.Data.Origin != null)
            {
                Assert.NotNull(model.Data.Origin);
                Assert.NotNull(getResult.Data.Origin);
                Assert.AreEqual(model.Data.Origin.Id, getResult.Data.Origin.Id);
            }
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.HttpPort, getResult.Data.HttpPort);
            Assert.AreEqual(model.Data.HttpsPort, getResult.Data.HttpsPort);
            Assert.AreEqual(model.Data.OriginHostHeader, getResult.Data.OriginHostHeader);
            Assert.AreEqual(model.Data.Priority, getResult.Data.Priority);
            Assert.AreEqual(model.Data.Weight, getResult.Data.Weight);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            //Todo:SharedPrivateLinkResource
        }

        public static void AssertAfdOriginUpdate(FrontDoorOriginResource updatedAfdOrigin, FrontDoorOriginPatch updateOptions)
        {
            Assert.AreEqual(updatedAfdOrigin.Data.Priority, updateOptions.Priority);
            Assert.AreEqual(updatedAfdOrigin.Data.Weight, updateOptions.Weight);
        }

        public static void AssertValidOriginGroup(CdnOriginGroupResource model, CdnOriginGroupResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.NotNull(model.Data.HealthProbeSettings);
                Assert.NotNull(getResult.Data.HealthProbeSettings);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeIntervalInSeconds, getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbePath, getResult.Data.HealthProbeSettings.ProbePath);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeProtocol, getResult.Data.HealthProbeSettings.ProbeProtocol);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeRequestType, getResult.Data.HealthProbeSettings.ProbeRequestType);
            }
            Assert.AreEqual(model.Data.Origins.Count, getResult.Data.Origins.Count);
            for (int i = 0; i < model.Data.Origins.Count; ++i)
            {
                Assert.AreEqual(model.Data.Origins[i].Id, getResult.Data.Origins[i].Id);
            }
            Assert.AreEqual(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            //Todo: ResponseBasedOriginErrorDetectionSettings
        }

        public static void AssertOriginGroupUpdate(CdnOriginGroupResource updatedOriginGroup, CdnOriginGroupPatch updateOptions)
        {
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbePath, updateOptions.HealthProbeSettings.ProbePath);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeRequestType, updateOptions.HealthProbeSettings.ProbeRequestType);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeProtocol, updateOptions.HealthProbeSettings.ProbeProtocol);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeIntervalInSeconds, updateOptions.HealthProbeSettings.ProbeIntervalInSeconds);
        }

        public static void AssertValidAfdOriginGroup(FrontDoorOriginGroupResource model, FrontDoorOriginGroupResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            if (model.Data.LoadBalancingSettings != null || getResult.Data.LoadBalancingSettings != null)
            {
                Assert.NotNull(model.Data.LoadBalancingSettings);
                Assert.NotNull(getResult.Data.LoadBalancingSettings);
                Assert.AreEqual(model.Data.LoadBalancingSettings.SampleSize, getResult.Data.LoadBalancingSettings.SampleSize);
                Assert.AreEqual(model.Data.LoadBalancingSettings.SuccessfulSamplesRequired, getResult.Data.LoadBalancingSettings.SuccessfulSamplesRequired);
                Assert.AreEqual(model.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, getResult.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds);
            }
            if (model.Data.HealthProbeSettings != null || getResult.Data.HealthProbeSettings != null)
            {
                Assert.NotNull(model.Data.HealthProbeSettings);
                Assert.NotNull(getResult.Data.HealthProbeSettings);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeIntervalInSeconds, getResult.Data.HealthProbeSettings.ProbeIntervalInSeconds);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbePath, getResult.Data.HealthProbeSettings.ProbePath);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeProtocol, getResult.Data.HealthProbeSettings.ProbeProtocol);
                Assert.AreEqual(model.Data.HealthProbeSettings.ProbeRequestType, getResult.Data.HealthProbeSettings.ProbeRequestType);
            }
            Assert.AreEqual(model.Data.TrafficRestorationTimeInMinutes, getResult.Data.TrafficRestorationTimeInMinutes);
            Assert.AreEqual(model.Data.SessionAffinityState, getResult.Data.SessionAffinityState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            //Todo: ResponseBasedAfdOriginErrorDetectionSettings
        }

        public static void AssertAfdOriginGroupUpdate(FrontDoorOriginGroupResource updatedAfdOriginGroup, FrontDoorOriginGroupPatch updateOptions)
        {
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.SampleSize, updateOptions.LoadBalancingSettings.SampleSize);
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.SuccessfulSamplesRequired, updateOptions.LoadBalancingSettings.SuccessfulSamplesRequired);
            Assert.AreEqual(updatedAfdOriginGroup.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, updateOptions.LoadBalancingSettings.AdditionalLatencyInMilliseconds);
        }

        public static void AssertValidCustomDomain(CdnCustomDomainResource model, CdnCustomDomainResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningState, getResult.Data.CustomHttpsProvisioningState);
            Assert.AreEqual(model.Data.CustomHttpsAvailabilityState, getResult.Data.CustomHttpsAvailabilityState);
            Assert.AreEqual(model.Data.ValidationData, getResult.Data.ValidationData);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
        }

        public static void AssertValidAfdCustomDomain(FrontDoorCustomDomainResource model, FrontDoorCustomDomainResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.TlsSettings.CertificateType, getResult.Data.TlsSettings.CertificateType);
            Assert.AreEqual(model.Data.TlsSettings.MinimumTlsVersion, getResult.Data.TlsSettings.MinimumTlsVersion);
            if (model.Data.TlsSettings.Secret != null || getResult.Data.TlsSettings.Secret != null)
            {
                Assert.NotNull(model.Data.TlsSettings.Secret);
                Assert.NotNull(getResult.Data.TlsSettings.Secret);
                Assert.AreEqual(model.Data.TlsSettings.Secret.Id, getResult.Data.TlsSettings.Secret.Id);
            }
            if (model.Data.DnsZone != null || getResult.Data.DnsZone != null)
            {
                Assert.NotNull(model.Data.DnsZone);
                Assert.NotNull(getResult.Data.DnsZone);
                Assert.AreEqual(model.Data.DnsZone.Id, getResult.Data.DnsZone.Id);
            }
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.DomainValidationState, getResult.Data.DomainValidationState);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            if (model.Data.ValidationProperties != null || getResult.Data.ValidationProperties != null)
            {
                Assert.NotNull(model.Data.ValidationProperties);
                Assert.NotNull(getResult.Data.ValidationProperties);
                Assert.AreEqual(model.Data.ValidationProperties.ValidationToken, getResult.Data.ValidationProperties.ValidationToken);
                Assert.AreEqual(model.Data.ValidationProperties.ExpiresOn, getResult.Data.ValidationProperties.ExpiresOn);
            }
        }

        public static void AssertAfdDomainUpdate(FrontDoorCustomDomainResource updatedAfdDomain, FrontDoorCustomDomainPatch updateOptions)
        {
            Assert.AreEqual(updatedAfdDomain.Data.TlsSettings.CertificateType, updateOptions.TlsSettings.CertificateType);
            Assert.AreEqual(updatedAfdDomain.Data.TlsSettings.MinimumTlsVersion, updateOptions.TlsSettings.MinimumTlsVersion);
        }

        public static void AssertValidAfdRuleSet(FrontDoorRuleSetResource model, FrontDoorRuleSetResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertValidAfdRule(FrontDoorRuleResource model, FrontDoorRuleResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Order, getResult.Data.Order);
            Assert.AreEqual(model.Data.Conditions.Count, getResult.Data.Conditions.Count);
            for (int i = 0; i < model.Data.Conditions.Count; ++i)
            {
                Assert.AreEqual(model.Data.Conditions[i].Name, getResult.Data.Conditions[i].Name);
            }
            Assert.AreEqual(model.Data.Actions.Count, getResult.Data.Actions.Count);
            for (int i = 0; i < model.Data.Actions.Count; ++i)
            {
                Assert.AreEqual(model.Data.Actions[i].Name, getResult.Data.Actions[i].Name);
            }
            Assert.AreEqual(model.Data.MatchProcessingBehavior, getResult.Data.MatchProcessingBehavior);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertAfdRuleUpdate(FrontDoorRuleResource updatedRule, FrontDoorRulePatch updateOptions)
        {
            Assert.AreEqual(updatedRule.Data.Order, updateOptions.Order);
        }

        public static void AssertValidAfdRoute(FrontDoorRouteResource model, FrontDoorRouteResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.CustomDomains.Count, getResult.Data.CustomDomains.Count);
            for (int i = 0; i < model.Data.CustomDomains.Count; ++i)
            {
                Assert.AreEqual(model.Data.CustomDomains[i].Id, getResult.Data.CustomDomains[i].Id);
            }
            Assert.AreEqual(model.Data.OriginGroup.Id, getResult.Data.OriginGroup.Id);
            Assert.AreEqual(model.Data.OriginPath, getResult.Data.OriginPath);
            Assert.AreEqual(model.Data.RuleSets.Count, getResult.Data.RuleSets.Count);
            for (int i = 0; i < model.Data.RuleSets.Count; ++i)
            {
                Assert.AreEqual(model.Data.RuleSets[i].Id, getResult.Data.RuleSets[i].Id);
            }
            Assert.AreEqual(model.Data.SupportedProtocols.Count, getResult.Data.SupportedProtocols.Count);
            for (int i = 0; i < model.Data.SupportedProtocols.Count; ++i)
            {
                Assert.AreEqual(model.Data.SupportedProtocols[i], getResult.Data.SupportedProtocols[i]);
            }
            Assert.AreEqual(model.Data.PatternsToMatch.Count, getResult.Data.PatternsToMatch.Count);
            for (int i = 0; i < model.Data.PatternsToMatch.Count; ++i)
            {
                Assert.AreEqual(model.Data.PatternsToMatch[i], getResult.Data.PatternsToMatch[i]);
            }
            Assert.AreEqual(model.Data.EndpointName, getResult.Data.EndpointName);
            Assert.AreEqual(model.Data.ForwardingProtocol, getResult.Data.ForwardingProtocol);
            Assert.AreEqual(model.Data.LinkToDefaultDomain, getResult.Data.LinkToDefaultDomain);
            Assert.AreEqual(model.Data.HttpsRedirect, getResult.Data.HttpsRedirect);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertAfdRouteUpdate(FrontDoorRouteResource updatedRoute, FrontDoorRoutePatch updateOptions)
        {
            Assert.AreEqual(updatedRoute.Data.EnabledState, updateOptions.EnabledState);
        }

        public static void AssertValidAfdSecurityPolicy(FrontDoorSecurityPolicyResource model, FrontDoorSecurityPolicyResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Properties.PolicyType, getResult.Data.Properties.PolicyType);
        }

        public static void AssertAfdSecurityPolicyUpdate(FrontDoorSecurityPolicyResource updatedSecurityPolicy, FrontDoorSecurityPolicyPatch updateOptions)
        {
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewall)updatedSecurityPolicy.Data.Properties).Associations.Count, 1);
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewall)updatedSecurityPolicy.Data.Properties).Associations[0].Domains.Count, 2);
        }

        public static void AssertValidPolicy(CdnWebApplicationFirewallPolicyResource model, CdnWebApplicationFirewallPolicyResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ETag, getResult.Data.ETag);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            //Todo: PolicySettings, RateLimitRules, CustomRules, ManagedRules, EndpointLinks
        }

        public static void AssertPolicyUpdate(CdnWebApplicationFirewallPolicyResource updatedPolicy, string key, string value)
        {
            Assert.GreaterOrEqual(updatedPolicy.Data.Tags.Count, 1);
            Assert.IsTrue(updatedPolicy.Data.Tags.ContainsKey(key));
            Assert.AreEqual(updatedPolicy.Data.Tags[key], value);
        }

        public static void AssertValidAfdSecret(FrontDoorSecretResource model, FrontDoorSecretResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Properties.SecretType, getResult.Data.Properties.SecretType);
            Assert.AreEqual(((CustomerCertificateProperties)model.Data.Properties).SecretVersion, ((CustomerCertificateProperties)getResult.Data.Properties).SecretVersion);
            Assert.AreEqual(((CustomerCertificateProperties)model.Data.Properties).CertificateAuthority, ((CustomerCertificateProperties)getResult.Data.Properties).CertificateAuthority);
            Assert.AreEqual(((CustomerCertificateProperties)model.Data.Properties).UseLatestVersion, ((CustomerCertificateProperties)getResult.Data.Properties).UseLatestVersion);
            Assert.AreEqual(((CustomerCertificateProperties)model.Data.Properties).SecretSource.Id.Name.ToString().ToLower(), ((CustomerCertificateProperties)getResult.Data.Properties).SecretSource.Id.Name.ToString().ToLower());
            Assert.True(((CustomerCertificateProperties)model.Data.Properties).SubjectAlternativeNames.SequenceEqual(((CustomerCertificateProperties)getResult.Data.Properties).SubjectAlternativeNames));
        }
    }
}
