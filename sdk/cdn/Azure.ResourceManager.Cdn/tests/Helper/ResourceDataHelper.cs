// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Collections.Generic;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests.Helper
{
    public static class ResourceDataHelper
    {
        public static ProfileData CreateProfileData(SkuName skuName) => new ProfileData(Location.WestUS, new Sku { Name = skuName });

        public static ProfileData CreateAFDProfileData(SkuName skuName) => new ProfileData("Global", new Sku { Name = skuName });

        public static EndpointData CreateEndpointData() => new EndpointData(Location.WestUS)
        {
            IsHttpAllowed = true,
            IsHttpsAllowed = true,
            OptimizationType = OptimizationType.GeneralWebDelivery
        };

        public static AFDEndpointData CreateAFDEndpointData() => new AFDEndpointData(Location.WestUS)
        {
            OriginResponseTimeoutSeconds = 60
        };

        public static DeepCreatedOrigin CreateDeepCreatedOrigin() => new DeepCreatedOrigin("testOrigin")
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 3,
            Weight = 100
        };

        public static DeepCreatedOriginGroup CreateDeepCreatedOriginGroup() => new DeepCreatedOriginGroup("testOriginGroup")
        {
            HealthProbeSettings = new HealthProbeParameters
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = ProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            }
        };

        public static OriginData CreateOriginData() => new OriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net",
            Priority = 1,
            Weight = 150
        };

        public static AFDOriginData CreateAFDOriginData() => new AFDOriginData
        {
            HostName = "testsa4dotnetsdk.blob.core.windows.net"
        };

        public static OriginGroupData CreateOriginGroupData() => new OriginGroupData();

        public static AFDOriginGroupData CreateAFDOriginGroupData() => new AFDOriginGroupData
        {
            HealthProbeSettings = new HealthProbeParameters
            {
                ProbePath = "/healthz",
                ProbeRequestType = HealthProbeRequestType.Head,
                ProbeProtocol = ProbeProtocol.Https,
                ProbeIntervalInSeconds = 60
            },
            LoadBalancingSettings = new LoadBalancingSettingsParameters
            {
                SampleSize = 5,
                SuccessfulSamplesRequired = 4,
                AdditionalLatencyInMilliseconds = 200
            }
        };

        public static CustomDomainParameters CreateCustomDomainParameters(string hostName) => new CustomDomainParameters
        {
            HostName = hostName
        };

        public static AFDDomainData CreateAFDCustomDomainData(string hostName) => new AFDDomainData
        {
            HostName = hostName,
            TlsSettings = new AFDDomainHttpsParameters(AfdCertificateType.ManagedCertificate)
            {
                MinimumTlsVersion = AfdMinimumTlsVersion.TLS12
            },
            AzureDnsZone = new WritableSubResource
            {
                Id = "/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/cdntest/providers/Microsoft.Network/dnszones/azuretest.net"
            }
        };

        public static RuleData CreateRuleData() => new RuleData
        {
            Order = 1
        };

        public static DeliveryRuleCondition CreateDeliveryRuleCondition() => new DeliveryRuleRequestUriCondition(new RequestUriMatchConditionParameters(RequestUriMatchConditionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleRequestUriConditionParameters, RequestUriOperator.Any));

        public static DeliveryRuleOperation CreateDeliveryRuleOperation() => new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
        {
            CacheDuration = "00:00:20"
        });

        public static DeliveryRuleOperation UpdateDeliveryRuleOperation() => new DeliveryRuleCacheExpirationAction(new CacheExpirationActionParameters(CacheExpirationActionParametersOdataType.MicrosoftAzureCdnModelsDeliveryRuleCacheExpirationActionParameters, CacheBehavior.Override, CacheType.All)
        {
            CacheDuration = "00:00:30"
        });

        public static RouteData CreateRouteData(AFDOriginGroup originGroup) => new RouteData
        {
            OriginGroup = new WritableSubResource
            {
                Id = originGroup.Id
            },
            LinkToDefaultDomain = LinkToDefaultDomain.Enabled,
            EnabledState = EnabledState.Enabled
        };

        public static SecurityPolicyData CreateSecurityPolicyData(AFDEndpoint endpoint) => new SecurityPolicyData
        {
            Parameters = new SecurityPolicyWebApplicationFirewallParameters
            {
                WafPolicy = new WritableSubResource
                {
                    Id = "/subscriptions/f3d94233-a9aa-4241-ac82-2dfb63ce637a/resourceGroups/CdnTest/providers/Microsoft.Network/frontdoorWebApplicationFirewallPolicies/testAFDWaf"
                }
            }
        };

        public static SecretData CreateSecretData() => new SecretData
        {
            Parameters = new CustomerCertificateParameters(new WritableSubResource
            {
                Id = "/subscriptions/87082bb7-c39f-42d2-83b6-4980444c7397/resourceGroups/CdnTest/providers/Microsoft.KeyVault/vaults/testKV4AFD/certificates/testCert"
            })
            {
                UseLatestVersion = true
            }
        };

        public static CdnWebApplicationFirewallPolicyData CreateCdnWebApplicationFirewallPolicyData() => new CdnWebApplicationFirewallPolicyData("Global", new Sku
        {
            Name = SkuName.StandardMicrosoft
        });

        public static void AssertValidProfile(Profile model, Profile getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.FrontdoorId, getResult.Data.FrontdoorId);
        }

        public static void AssertProfileUpdate(Profile updatedProfile, ProfileUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedProfile.Data.Tags.Count, updateParameters.Tags.Count);
            foreach (var kv in updatedProfile.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }

        public static void AssertValidEndpoint(Endpoint model, Endpoint getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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

        public static void AssertEndpointUpdate(Endpoint updatedEndpoint, EndpointUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedEndpoint.Data.IsHttpAllowed, updateParameters.IsHttpAllowed);
            Assert.AreEqual(updatedEndpoint.Data.OriginPath, updateParameters.OriginPath);
            Assert.AreEqual(updatedEndpoint.Data.OriginHostHeader, updateParameters.OriginHostHeader);
        }

        public static void AssertValidAFDEndpoint(AFDEndpoint model, AFDEndpoint getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.OriginResponseTimeoutSeconds, getResult.Data.OriginResponseTimeoutSeconds);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
        }

        public static void AssertAFDEndpointUpdate(AFDEndpoint updatedAFDEndpoint, AFDEndpointUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedAFDEndpoint.Data.OriginResponseTimeoutSeconds, updateParameters.OriginResponseTimeoutSeconds);
            Assert.AreEqual(updatedAFDEndpoint.Data.Tags.Count, updateParameters.Tags.Count);
            foreach (var kv in updatedAFDEndpoint.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }

        public static void AssertValidOrigin(Origin model, Origin getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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

        public static void AssertOriginUpdate(Origin updatedOrigin, OriginUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedOrigin.Data.HttpPort, updateParameters.HttpPort);
            Assert.AreEqual(updatedOrigin.Data.HttpsPort, updateParameters.HttpsPort);
            Assert.AreEqual(updatedOrigin.Data.Priority, updateParameters.Priority);
            Assert.AreEqual(updatedOrigin.Data.Weight, updateParameters.Weight);
        }

        public static void AssertValidAFDOrigin(AFDOrigin model, AFDOrigin getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            if (model.Data.AzureOrigin != null || getResult.Data.AzureOrigin != null)
            {
                Assert.NotNull(model.Data.AzureOrigin);
                Assert.NotNull(getResult.Data.AzureOrigin);
                Assert.AreEqual(model.Data.AzureOrigin.Id, getResult.Data.AzureOrigin.Id);
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

        public static void AssertAFDOriginUpdate(AFDOrigin updatedAFDOrigin, AFDOriginUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedAFDOrigin.Data.Priority, updateParameters.Priority);
            Assert.AreEqual(updatedAFDOrigin.Data.Weight, updateParameters.Weight);
        }

        public static void AssertValidOriginGroup(OriginGroup model, OriginGroup getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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

        public static void AssertOriginGroupUpdate(OriginGroup updatedOriginGroup, OriginGroupUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbePath, updateParameters.HealthProbeSettings.ProbePath);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeRequestType, updateParameters.HealthProbeSettings.ProbeRequestType);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeProtocol, updateParameters.HealthProbeSettings.ProbeProtocol);
            Assert.AreEqual(updatedOriginGroup.Data.HealthProbeSettings.ProbeIntervalInSeconds, updateParameters.HealthProbeSettings.ProbeIntervalInSeconds);
        }

        public static void AssertValidAFDOriginGroup(AFDOriginGroup model, AFDOriginGroup getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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
            Assert.AreEqual(model.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes, getResult.Data.TrafficRestorationTimeToHealedOrNewEndpointsInMinutes);
            Assert.AreEqual(model.Data.SessionAffinityState, getResult.Data.SessionAffinityState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            //Todo: ResponseBasedAfdOriginErrorDetectionSettings
        }

        public static void AssertAFDOriginGroupUpdate(AFDOriginGroup updatedAFDOriginGroup, AFDOriginGroupUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedAFDOriginGroup.Data.LoadBalancingSettings.SampleSize, updateParameters.LoadBalancingSettings.SampleSize);
            Assert.AreEqual(updatedAFDOriginGroup.Data.LoadBalancingSettings.SuccessfulSamplesRequired, updateParameters.LoadBalancingSettings.SuccessfulSamplesRequired);
            Assert.AreEqual(updatedAFDOriginGroup.Data.LoadBalancingSettings.AdditionalLatencyInMilliseconds, updateParameters.LoadBalancingSettings.AdditionalLatencyInMilliseconds);
        }

        public static void AssertValidCustomDomain(CustomDomain model, CustomDomain getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.HostName, getResult.Data.HostName);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningState, getResult.Data.CustomHttpsProvisioningState);
            Assert.AreEqual(model.Data.CustomHttpsProvisioningSubstate, getResult.Data.CustomHttpsProvisioningSubstate);
            Assert.AreEqual(model.Data.ValidationData, getResult.Data.ValidationData);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
        }

        public static void AssertValidAFDCustomDomain(AFDDomain model, AFDDomain getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.TlsSettings.CertificateType, getResult.Data.TlsSettings.CertificateType);
            Assert.AreEqual(model.Data.TlsSettings.MinimumTlsVersion, getResult.Data.TlsSettings.MinimumTlsVersion);
            if (model.Data.TlsSettings.Secret != null || getResult.Data.TlsSettings.Secret != null)
            {
                Assert.NotNull(model.Data.TlsSettings.Secret);
                Assert.NotNull(getResult.Data.TlsSettings.Secret);
                Assert.AreEqual(model.Data.TlsSettings.Secret.Id, getResult.Data.TlsSettings.Secret.Id);
            }
            if (model.Data.AzureDnsZone != null || getResult.Data.AzureDnsZone != null)
            {
                Assert.NotNull(model.Data.AzureDnsZone);
                Assert.NotNull(getResult.Data.AzureDnsZone);
                Assert.AreEqual(model.Data.AzureDnsZone.Id, getResult.Data.AzureDnsZone.Id);
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
                Assert.AreEqual(model.Data.ValidationProperties.ExpirationDate, getResult.Data.ValidationProperties.ExpirationDate);
            }
        }

        public static void AssertAFDDomainUpdate(AFDDomain updatedAFDDomain, AFDDomainUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedAFDDomain.Data.TlsSettings.CertificateType, updateParameters.TlsSettings.CertificateType);
            Assert.AreEqual(updatedAFDDomain.Data.TlsSettings.MinimumTlsVersion, updateParameters.TlsSettings.MinimumTlsVersion);
        }

        public static void AssertValidRuleSet(RuleSet model, RuleSet getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertValidRule(Rule model, Rule getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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

        public static void AssertRuleUpdate(Rule updatedRule, RuleUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedRule.Data.Order, updateParameters.Order);
        }

        public static void AssertValidRoute(Route model, Route getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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
            Assert.AreEqual(model.Data.QueryStringCachingBehavior, getResult.Data.QueryStringCachingBehavior);
            Assert.AreEqual(model.Data.ForwardingProtocol, getResult.Data.ForwardingProtocol);
            Assert.AreEqual(model.Data.LinkToDefaultDomain, getResult.Data.LinkToDefaultDomain);
            Assert.AreEqual(model.Data.HttpsRedirect, getResult.Data.HttpsRedirect);
            Assert.AreEqual(model.Data.EnabledState, getResult.Data.EnabledState);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
        }

        public static void AssertRouteUpdate(Route updatedRoute, RouteUpdateParameters updateParameters)
        {
            Assert.AreEqual(updatedRoute.Data.EnabledState, updateParameters.EnabledState);
        }

        public static void AssertValidSecurityPolicy(SecurityPolicy model, SecurityPolicy getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Parameters.Type, getResult.Data.Parameters.Type);
        }

        public static void AssertSecurityPolicy(SecurityPolicy updatedSecurityPolicy, SecurityPolicyProperties updateParameters)
        {
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewallParameters)updatedSecurityPolicy.Data.Parameters).Associations.Count, 1);
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewallParameters)updatedSecurityPolicy.Data.Parameters).Associations[0].PatternsToMatch.Count, 1);
            Assert.AreEqual(((SecurityPolicyWebApplicationFirewallParameters)updatedSecurityPolicy.Data.Parameters).Associations[0].PatternsToMatch[0], ((SecurityPolicyWebApplicationFirewallParameters)updateParameters.Parameters).Associations[0].PatternsToMatch[0]);
        }

        public static void AssertValidPolicy(CdnWebApplicationFirewallPolicy model, CdnWebApplicationFirewallPolicy getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Etag, getResult.Data.Etag);
            Assert.AreEqual(model.Data.Sku.Name, getResult.Data.Sku.Name);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.ResourceState, getResult.Data.ResourceState);
            //Todo: PolicySettings, RateLimitRules, CustomRules, ManagedRules, EndpointLinks
        }

        public static void AssertPolicyUpdate(CdnWebApplicationFirewallPolicy updatedPolicy, CdnWebApplicationFirewallPolicyPatchParameters updateParameters)
        {
            Assert.AreEqual(updatedPolicy.Data.Tags.Count, updateParameters.Tags.Count);
            foreach (var kv in updatedPolicy.Data.Tags)
            {
                Assert.True(updateParameters.Tags.ContainsKey(kv.Key));
                Assert.AreEqual(kv.Value, updateParameters.Tags[kv.Key]);
            }
        }

        public static void AssertValidSecret(Secret model, Secret getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            Assert.AreEqual(model.Data.DeploymentStatus, getResult.Data.DeploymentStatus);
            Assert.AreEqual(model.Data.Parameters.Type, getResult.Data.Parameters.Type);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).SecretVersion, ((CustomerCertificateParameters)getResult.Data.Parameters).SecretVersion);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).CertificateAuthority, ((CustomerCertificateParameters)getResult.Data.Parameters).CertificateAuthority);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).UseLatestVersion, ((CustomerCertificateParameters)getResult.Data.Parameters).UseLatestVersion);
            Assert.AreEqual(((CustomerCertificateParameters)model.Data.Parameters).SecretSource.Id.ToString().ToLower(), ((CustomerCertificateParameters)getResult.Data.Parameters).SecretSource.Id.ToString().ToLower());
            Assert.True(((CustomerCertificateParameters)model.Data.Parameters).SubjectAlternativeNames.SequenceEqual(((CustomerCertificateParameters)getResult.Data.Parameters).SubjectAlternativeNames));
        }

        public static void AssertSecretUpdate(Secret updatedSecret, SecretProperties updateParameters)
        {
            Assert.AreEqual(((CustomerCertificateParameters)updatedSecret.Data.Parameters).UseLatestVersion, ((CustomerCertificateParameters)updateParameters.Parameters).UseLatestVersion);
        }
    }
}
