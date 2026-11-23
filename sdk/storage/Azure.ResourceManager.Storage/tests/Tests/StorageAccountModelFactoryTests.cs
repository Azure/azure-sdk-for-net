// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountModelFactoryTests
    {
        [Test]
        public void DataCollaborationPolicyAcceptsZeroArguments()
        {
            var policy = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties();

            Assert.IsNull(policy.AllowStorageConnectors);
            Assert.IsNull(policy.AllowStorageDataShares);
            Assert.IsNull(policy.AllowCrossTenantDataSharing);
            Assert.IsNull(policy.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyPreservesOnePositionalArgument([Values(null, false, true)] bool? allowStorageConnectors)
        {
            var policy = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(allowStorageConnectors);

            Assert.AreEqual(allowStorageConnectors, policy.AllowStorageConnectors);
            Assert.IsNull(policy.AllowStorageDataShares);
            Assert.IsNull(policy.AllowCrossTenantDataSharing);
            Assert.IsNull(policy.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyPreservesTwoPositionalArguments(
            [Values(null, false, true)] bool? allowStorageConnectors,
            [Values(null, false, true)] bool? allowStorageDataShares)
        {
            var policy = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(allowStorageConnectors, allowStorageDataShares);

            Assert.AreEqual(allowStorageConnectors, policy.AllowStorageConnectors);
            Assert.AreEqual(allowStorageDataShares, policy.AllowStorageDataShares);
            Assert.IsNull(policy.AllowCrossTenantDataSharing);
            Assert.IsNull(policy.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyPreservesThreePositionalArguments(
            [Values(null, false, true)] bool? allowStorageConnectors,
            [Values(null, false, true)] bool? allowStorageDataShares,
            [Values(null, false, true)] bool? allowCrossTenantDataSharing)
        {
            var policy = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(
                allowStorageConnectors, allowStorageDataShares, allowCrossTenantDataSharing);

            Assert.AreEqual(allowStorageConnectors, policy.AllowStorageConnectors);
            Assert.AreEqual(allowStorageDataShares, policy.AllowStorageDataShares);
            Assert.AreEqual(allowCrossTenantDataSharing, policy.AllowCrossTenantDataSharing);
            Assert.IsNull(policy.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyAppendsBlobAccessPoints(
            [Values(null, false, true)] bool? allowStorageConnectors,
            [Values(null, false, true)] bool? allowStorageDataShares,
            [Values(null, false, true)] bool? allowCrossTenantDataSharing,
            [Values(null, false, true)] bool? allowBlobAccessPoints)
        {
            var policy = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(
                allowStorageConnectors, allowStorageDataShares, allowCrossTenantDataSharing, allowBlobAccessPoints);

            Assert.AreEqual(allowStorageConnectors, policy.AllowStorageConnectors);
            Assert.AreEqual(allowStorageDataShares, policy.AllowStorageDataShares);
            Assert.AreEqual(allowCrossTenantDataSharing, policy.AllowCrossTenantDataSharing);
            Assert.AreEqual(allowBlobAccessPoints, policy.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyAcceptsNamedAndMixedArguments()
        {
            var named = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(
                allowStorageConnectors: true,
                allowStorageDataShares: false,
                allowCrossTenantDataSharing: null,
                allowBlobAccessPoints: true);
            var mixed = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(
                default,
                allowBlobAccessPoints: true,
                allowStorageDataShares: false,
                allowCrossTenantDataSharing: true);
            var blobOnly = ArmStorageModelFactory.StorageDataCollaborationPolicyProperties(allowBlobAccessPoints: true);

            Assert.IsTrue(named.AllowStorageConnectors);
            Assert.IsFalse(named.AllowStorageDataShares);
            Assert.IsNull(named.AllowCrossTenantDataSharing);
            Assert.IsTrue(named.AllowBlobAccessPoints);
            Assert.IsNull(mixed.AllowStorageConnectors);
            Assert.IsFalse(mixed.AllowStorageDataShares);
            Assert.IsTrue(mixed.AllowCrossTenantDataSharing);
            Assert.IsTrue(mixed.AllowBlobAccessPoints);
            Assert.IsNull(blobOnly.AllowStorageConnectors);
            Assert.IsNull(blobOnly.AllowStorageDataShares);
            Assert.IsNull(blobOnly.AllowCrossTenantDataSharing);
            Assert.IsTrue(blobOnly.AllowBlobAccessPoints);
        }

        [Test]
        public void DataCollaborationPolicyPreservesLegacySignatureAndOptionalSuccessor()
        {
            MethodInfo legacy = typeof(ArmStorageModelFactory).GetMethod(
                nameof(ArmStorageModelFactory.StorageDataCollaborationPolicyProperties),
                new[] { typeof(bool?), typeof(bool?), typeof(bool?) });
            MethodInfo successor = typeof(ArmStorageModelFactory).GetMethod(
                nameof(ArmStorageModelFactory.StorageDataCollaborationPolicyProperties),
                new[] { typeof(bool?), typeof(bool?), typeof(bool?), typeof(bool?) });

            Assert.IsNotNull(legacy);
            Assert.IsNotNull(successor);
            string[] gaNames = { "allowStorageConnectors", "allowStorageDataShares", "allowCrossTenantDataSharing" };
            CollectionAssert.AreEqual(gaNames, legacy.GetParameters().Select(parameter => parameter.Name));
            Assert.IsTrue(legacy.GetParameters().All(parameter => !parameter.IsOptional && !parameter.HasDefaultValue));
            CollectionAssert.AreEqual(gaNames.Concat(new[] { "allowBlobAccessPoints" }),
                successor.GetParameters().Select(parameter => parameter.Name));
            Assert.IsTrue(successor.GetParameters().All(parameter => parameter.IsOptional && parameter.DefaultValue == null));
        }

        [Test]
        public void GaFactoriesAcceptZeroArguments()
        {
            Assert.IsNotNull(ArmStorageModelFactory.FileServiceData());
            Assert.IsNotNull(ArmStorageModelFactory.FileShareLimits());
            Assert.IsNotNull(ArmStorageModelFactory.StorageAccountData());
            Assert.IsNotNull(ArmStorageModelFactory.StoragePrivateEndpointConnectionData());
        }

        [Test]
        public void FileServicePreservesGaPositionalAndNamedArguments()
        {
            var sku = new StorageSku(StorageSkuName.StandardLrs);
            var protocolSettings = ArmStorageModelFactory.FileServiceProtocolSettings();
            var positional = ArmStorageModelFactory.FileServiceData(default, default, default, default, sku);
            var named = ArmStorageModelFactory.FileServiceData(
                name: "files",
                sku: sku, corsRules: Array.Empty<StorageCorsRule>(),
                shareDeleteRetentionPolicy: default, protocolSettings: protocolSettings);
            var full = ArmStorageModelFactory.FileServiceData(
                default, "files", default, default, sku, Array.Empty<StorageCorsRule>(), default, protocolSettings);

            Assert.AreSame(sku, positional.Sku);
            Assert.AreSame(sku, named.Sku);
            Assert.AreSame(protocolSettings, named.ProtocolSettings);
            Assert.AreSame(protocolSettings, full.ProtocolSettings);
            Assert.AreEqual("files", named.Name);
        }

        [Test]
        public void FileShareLimitsPreservesGaPositionalAndNamedArguments()
        {
            var positional = ArmStorageModelFactory.FileShareLimits(10, 20, 30);
            var named = ArmStorageModelFactory.FileShareLimits(maxProvisionedBandwidthMiBPerSec: 60);
            var full = ArmStorageModelFactory.FileShareLimits(10, 20, 30, 40, 50, 60);

            Assert.AreEqual(10, positional.MinProvisionedStorageGiB);
            Assert.AreEqual(30, positional.MinProvisionedIops);
            Assert.AreEqual(60, named.MaxProvisionedBandwidthMiBPerSec);
            Assert.AreEqual(50, full.MinProvisionedBandwidthMiBPerSec);
            Assert.IsNull(full.GuardrailIOScalar);
        }

        [Test]
        public void AccountDataPreservesGaPositionalAndNamedArguments()
        {
            var authentication = new FilesIdentityBasedAuthentication(default);
            var positional = ArmStorageModelFactory.StorageAccountData(
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                default, default, default, default, authentication);
            var named = ArmStorageModelFactory.StorageAccountData(
                default, name: "account", location: AzureLocation.EastUS,
                provisioningState: StorageAccountProvisioningState.Succeeded,
                azureFilesIdentityBasedAuthentication: authentication,
                isSftpEnabled: true, keyExpirationPeriodInDays: 42,
                zones: new[] { "1" });

            Assert.AreSame(authentication, positional.AzureFilesIdentityBasedAuthentication);
            Assert.AreSame(authentication, named.AzureFilesIdentityBasedAuthentication);
            Assert.IsNull(positional.TurboTier);
            Assert.AreEqual("account", named.Name);
            Assert.AreEqual(AzureLocation.EastUS, named.Location);
            Assert.AreEqual(StorageProvisioningState.Succeeded, named.ProvisioningState);
            Assert.IsTrue(named.IsSftpEnabled);
            Assert.AreEqual(42, named.KeyExpirationPeriodInDays);
            CollectionAssert.AreEqual(new[] { "1" }, named.Zones);
        }

        [Test]
        public void PrivateEndpointPreservesGaPositionalAndNamedArguments()
        {
            var connectionState = new StoragePrivateLinkServiceConnectionState { Description = "test" };
            var positional = ArmStorageModelFactory.StoragePrivateEndpointConnectionData(
                default, default, default, default, connectionState);
            var named = ArmStorageModelFactory.StoragePrivateEndpointConnectionData(
                name: "endpoint",
                connectionState: connectionState,
                provisioningState: StoragePrivateEndpointConnectionProvisioningState.Succeeded,
                privateEndpointId: default);

            Assert.AreSame(connectionState, positional.ConnectionState);
            Assert.AreSame(connectionState, named.ConnectionState);
            Assert.AreEqual("endpoint", named.Name);
            Assert.AreEqual(StoragePrivateEndpointConnectionProvisioningState.Succeeded, named.ProvisioningState);
        }

        [TestCase(nameof(ArmStorageModelFactory.FileServiceData), 8,
            "id,name,resourceType,systemData,sku,corsRules,shareDeleteRetentionPolicy,protocolSettings")]
        [TestCase(nameof(ArmStorageModelFactory.FileShareLimits), 6,
            "minProvisionedStorageGiB,maxProvisionedStorageGiB,minProvisionedIops,maxProvisionedIops,minProvisionedBandwidthMiBPerSec,maxProvisionedBandwidthMiBPerSec")]
        [TestCase(nameof(ArmStorageModelFactory.StoragePrivateEndpointConnectionData), 7,
            "id,name,resourceType,systemData,connectionState,provisioningState,privateEndpointId")]
        [TestCase(nameof(ArmStorageModelFactory.StorageAccountData), 57,
            "id,name,resourceType,systemData,tags,location,provisioningState,primaryEndpoints,primaryLocation,statusOfPrimary,lastGeoFailoverOn,secondaryLocation,statusOfSecondary,createdOn,customDomain,sasPolicy,keyCreationTime,secondaryEndpoints,encryption,accessTier,azureFilesIdentityBasedAuthentication,enableHttpsTrafficOnly,networkRuleSet,isSftpEnabled,isLocalUserEnabled,isExtendedGroupEnabled,isHnsEnabled,geoReplicationStats,isFailoverInProgress,largeFileSharesState,privateEndpointConnections,routingPreference,blobRestoreStatus,allowBlobPublicAccess,minimumTlsVersion,allowSharedKeyAccess,isNfsV3Enabled,allowCrossTenantReplication,isDefaultToOAuthAuthentication,publicNetworkAccess,immutableStorageWithVersioning,allowedCopyScope,storageAccountSkuConversionStatus,dnsEndpointType,isSkuConversionBlocked,isAccountMigrationInProgress,allowSharedKeyAccessForServices,dataCollaborationPolicyProperties,keyExpirationPeriodInDays,isIPv6EndpointToBePublished,isBlobEnabled,sku,kind,identity,extendedLocation,zones,zonePlacementPolicy")]
        public void GaFactoryParametersRemainOptional(string methodName, int parameterCount, string parameterNames)
        {
            MethodInfo method = typeof(ArmStorageModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(candidate => candidate.Name == methodName
                    && candidate.GetParameters().Length == parameterCount
                    && candidate.GetParameters().All(parameter => parameter.IsOptional));

            CollectionAssert.AreEqual(parameterNames.Split(','), method.GetParameters().Select(parameter => parameter.Name));
            Assert.IsTrue(method.GetParameters().All(parameter => parameter.DefaultValue == null));
        }

        [Test]
        public void PatchPreservesPositionalAuthentication()
        {
            var authentication = new FilesIdentityBasedAuthentication(default);
            var result = ArmStorageModelFactory.StorageAccountPatch(
                default, default, default, default, default, default, default, authentication);

            Assert.AreSame(authentication, result.AzureFilesIdentityBasedAuthentication);
            Assert.IsNull(result.TurboTier);
        }

        [Test]
        public void CreatePreservesPositionalAuthentication()
        {
            var authentication = new FilesIdentityBasedAuthentication(default);
            var result = ArmStorageModelFactory.StorageAccountCreateOrUpdateContent(
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, authentication);

            Assert.AreSame(authentication, result.AzureFilesIdentityBasedAuthentication);
            Assert.IsNull(result.TurboTier);
        }

        [Test]
        public void PatchPreservesPositionalDataCollaborationPolicy()
        {
            var policy = new StorageDataCollaborationPolicyProperties { AllowStorageConnectors = true };
            var result = ArmStorageModelFactory.StorageAccountPatch(
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                default, policy, 42);

            Assert.AreSame(policy, result.DataCollaborationPolicyProperties);
            Assert.AreEqual(42, result.KeyExpirationPeriodInDays);
            Assert.IsNull(result.AllowCrossTenantDelegationSas);
        }

        [Test]
        public void CreatePreservesPositionalDataCollaborationPolicy()
        {
            var policy = new StorageDataCollaborationPolicyProperties { AllowStorageConnectors = true };
            var result = ArmStorageModelFactory.StorageAccountCreateOrUpdateContent(
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default,
                policy, 42);

            Assert.AreSame(policy, result.DataCollaborationPolicyProperties);
            Assert.AreEqual(42, result.KeyExpirationPeriodInDays);
            Assert.IsNull(result.AllowCrossTenantDelegationSas);
        }

        [Test]
        public void PatchPreservesPositionalFlags()
        {
            var result = ArmStorageModelFactory.StorageAccountPatch(
                default, default, default, default, default, default, default, default, default, true);

            Assert.IsTrue(result.IsSftpEnabled);
            Assert.IsNull(result.EnableHttpsTrafficOnly);
        }

        [Test]
        public void CreatePreservesPositionalFlags()
        {
            var result = ArmStorageModelFactory.StorageAccountCreateOrUpdateContent(
                default, default, default, default, default, default, default, default,
                default, default, default, default, default, default, default, default, default, true);

            Assert.IsTrue(result.IsSftpEnabled);
            Assert.IsNull(result.EnableHttpsTrafficOnly);
        }

        [Test]
        public void FactoriesAcceptDefaultAndMixedNamedArguments()
        {
            Assert.IsNotNull(ArmStorageModelFactory.StorageAccountPatch());
            Assert.IsNotNull(ArmStorageModelFactory.StorageAccountCreateOrUpdateContent());

            var authentication = new FilesIdentityBasedAuthentication(default);
            var turboTier = new TurboTier { TargetPercent = 50 };
            var policy = new StorageDataCollaborationPolicyProperties { AllowBlobAccessPoints = true };
            var patch = ArmStorageModelFactory.StorageAccountPatch(
                default,
                azureFilesIdentityBasedAuthentication: authentication,
                isSftpEnabled: true,
                turboTier: turboTier,
                allowCrossTenantDelegationSas: true,
                dataCollaborationPolicyProperties: policy);
            var create = ArmStorageModelFactory.StorageAccountCreateOrUpdateContent(
                default,
                azureFilesIdentityBasedAuthentication: authentication,
                isSftpEnabled: true,
                turboTier: turboTier,
                allowCrossTenantDelegationSas: true,
                dataCollaborationPolicyProperties: policy);

            Assert.AreSame(authentication, patch.AzureFilesIdentityBasedAuthentication);
            Assert.AreSame(authentication, create.AzureFilesIdentityBasedAuthentication);
            Assert.AreSame(turboTier, patch.TurboTier);
            Assert.AreSame(turboTier, create.TurboTier);
            Assert.AreSame(policy, patch.DataCollaborationPolicyProperties);
            Assert.AreSame(policy, create.DataCollaborationPolicyProperties);
            Assert.IsTrue(patch.IsSftpEnabled);
            Assert.IsTrue(create.IsSftpEnabled);
            Assert.IsTrue(patch.AllowCrossTenantDelegationSas);
            Assert.IsTrue(create.AllowCrossTenantDelegationSas);
        }

        [TestCase(nameof(ArmStorageModelFactory.StorageAccountPatch),
            "sku,tags,identity,customDomain,encryption,sasPolicy,accessTier,azureFilesIdentityBasedAuthentication,enableHttpsTrafficOnly,isSftpEnabled,isLocalUserEnabled,isExtendedGroupEnabled,networkRuleSet,largeFileSharesState,routingPreference,allowBlobPublicAccess,minimumTlsVersion,allowSharedKeyAccess,allowCrossTenantReplication,isDefaultToOAuthAuthentication,publicNetworkAccess,immutableStorageWithVersioning,allowedCopyScope,dnsEndpointType,allowSharedKeyAccessForServices,dataCollaborationPolicyProperties,keyExpirationPeriodInDays,isIPv6EndpointToBePublished,isBlobEnabled,kind,zones,zonePlacementPolicy")]
        [TestCase(nameof(ArmStorageModelFactory.StorageAccountCreateOrUpdateContent),
            "sku,kind,location,extendedLocation,zones,zonePlacementPolicy,tags,identity,allowedCopyScope,publicNetworkAccess,sasPolicy,customDomain,encryption,networkRuleSet,accessTier,azureFilesIdentityBasedAuthentication,enableHttpsTrafficOnly,isSftpEnabled,isLocalUserEnabled,isExtendedGroupEnabled,isHnsEnabled,largeFileSharesState,routingPreference,allowBlobPublicAccess,minimumTlsVersion,allowSharedKeyAccess,isNfsV3Enabled,allowCrossTenantReplication,isDefaultToOAuthAuthentication,immutableStorageWithVersioning,dnsEndpointType,allowSharedKeyAccessForServices,dataCollaborationPolicyProperties,keyExpirationPeriodInDays,isIPv6EndpointToBePublished,isBlobEnabled")]
        public void NewParametersFollowTheGaParameterOrder(string methodName, string gaParameterNames)
        {
            MethodInfo method = typeof(ArmStorageModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(candidate => candidate.Name == methodName && candidate.GetParameters().All(parameter => parameter.IsOptional));
            string[] expected = gaParameterNames.Split(',').Concat(new[] { "turboTier", "allowCrossTenantDelegationSas" }).ToArray();

            CollectionAssert.AreEqual(expected, method.GetParameters().Select(parameter => parameter.Name));
        }

        [TestCase(nameof(ArmStorageModelFactory.StorageAccountPatch), 32)]
        [TestCase(nameof(ArmStorageModelFactory.StorageAccountCreateOrUpdateContent), 36)]
        public void HistoricalSignaturePreservesSuppliedValues(string methodName, int parameterCount)
        {
            MethodInfo method = typeof(ArmStorageModelFactory).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(candidate => candidate.Name == methodName && candidate.GetParameters().Length == parameterCount);
            ParameterInfo[] parameters = method.GetParameters();
            var authentication = new FilesIdentityBasedAuthentication(default);
            object[] arguments = parameters.Select(parameter =>
                parameter.ParameterType.IsValueType ? Activator.CreateInstance(parameter.ParameterType) : null).ToArray();
            arguments[Array.FindIndex(parameters, parameter => parameter.Name == "azureFilesIdentityBasedAuthentication")] = authentication;
            arguments[Array.FindIndex(parameters, parameter => parameter.Name == "isSftpEnabled")] = true;

            object result = method.Invoke(null, arguments);
            if (result is StorageAccountPatch patch)
            {
                Assert.AreSame(authentication, patch.AzureFilesIdentityBasedAuthentication);
                Assert.IsTrue(patch.IsSftpEnabled);
                Assert.IsNull(patch.TurboTier);
            }
            else
            {
                Assert.IsInstanceOf<StorageAccountCreateOrUpdateContent>(result);
                var create = (StorageAccountCreateOrUpdateContent)result;
                Assert.AreSame(authentication, create.AzureFilesIdentityBasedAuthentication);
                Assert.IsTrue(create.IsSftpEnabled);
                Assert.IsNull(create.TurboTier);
            }
        }
    }
}
