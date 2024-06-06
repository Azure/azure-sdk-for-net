// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Storage.Test.Shared
{
    public class TenantConfigurationBuilder
    {
        /// <summary>
        /// Reference to the base test class all tests that touch the wire inherit from.
        /// </summary>
        /// <remarks>
        /// The base test classes have functionality we can't fully abandon just yet,
        /// so we need to hold onto a reference to them to access critical functionality.
        /// </remarks>
        public RecordedTestBase AzureCoreRecordedTestBase { get; }

        /// <summary>
        /// Recording reference. Unsafe to access until [Setup] step.
        /// </summary>
        public TestRecording Recording => AzureCoreRecordedTestBase.Recording;

        /// <summary>
        /// Test mode reference. Safe to access even when <see cref="Recording"/> is not.
        /// </summary>
        public RecordedTestMode Mode => AzureCoreRecordedTestBase.Mode;

        /// <summary>
        /// Gets a cache used for storing deserialized tenant configurations.
        /// Do not get values from this directly; use GetTestConfig.
        private readonly Dictionary<string, TenantConfiguration> _playbackConfigCache =
            new Dictionary<string, TenantConfiguration>();

        /// <summary>
        /// Gets a cache used for storing serialized tenant configurations.  Do
        /// not get values from this directly; use GetTestConfig.
        /// </summary>
        private readonly Dictionary<string, string> _recordingConfigCache =
            new Dictionary<string, string>();

        public TenantConfigurationBuilder(RecordedTestBase recordedTestBase)
        {
            AzureCoreRecordedTestBase = recordedTestBase;
        }

        /// <summary>
        /// Clears caches for recording playback.
        /// </summary>
        public void ClearPlaybackCache() =>
            _playbackConfigCache.Clear();

        /// <summary>
        /// Gets the tenant to use by default for our tests.
        /// </summary>
        public TenantConfiguration TestConfigDefault => GetTestConfig(
                "Storage_TestConfigDefault",
                () => TestConfigurations.DefaultTargetTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require Read Access
        /// Geo-Redundant Storage to be setup.
        /// </summary>
        public TenantConfiguration TestConfigSecondary => GetTestConfig(
                "Storage_TestConfigSecondary",
                () => TestConfigurations.DefaultSecondaryTargetTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require Premium SSDs.
        /// </summary>
        public TenantConfiguration TestConfigPremiumBlob => GetTestConfig(
                "Storage_TestConfigPremiumBlob",
                () => TestConfigurations.DefaultTargetPremiumBlobTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require preview features.
        /// </summary>
        public TenantConfiguration TestConfigPreviewBlob => GetTestConfig(
                "Storage_TestConfigPreviewBlob",
                () => TestConfigurations.DefaultTargetPreviewBlobTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigOAuth => GetTestConfig(
                "Storage_TestConfigOAuth",
                () => TestConfigurations.DefaultTargetOAuthTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigHierarchicalNamespace => GetTestConfig(
                "Storage_TestConfigHierarchicalNamespace",
                () => TestConfigurations.DefaultTargetHierarchicalNamespaceTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigManagedDisk => GetTestConfig(
                "Storage_TestConfigManagedDisk",
                () => TestConfigurations.DefaultTargetManagedDiskTenant);

        /// <summary>
        /// Gets the tenant to use for any tests that require authentication
        /// with Azure AD.
        /// </summary>
        public TenantConfiguration TestConfigSoftDelete => GetTestConfig(
                "Storage_TestConfigSoftDelete",
                () => TestConfigurations.DefaultTargetSoftDeleteTenant);

        /// <summary>
        /// Gets the tenant to use for any tests premium files.
        /// </summary>
        public TenantConfiguration TestConfigPremiumFile => GetTestConfig(
                "Storage_TestConfigPremiumFile",
                () => TestConfigurations.DefaultPremiumFileTenant);

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                    TestConfigDefault.AccountName,
                    TestConfigDefault.AccountKey);

        public StorageSharedKeyCredential GetNewHnsSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);

        /// <summary>
        /// Get or create a test configuration tenant to use with our tests.
        ///
        /// If we're recording, we'll save a sanitized version of the test
        /// configuarion.  If we're playing recorded tests, we'll use the
        /// serialized test configuration.  If we're running the tests live,
        /// we'll just return the value.
        ///
        /// While we cache things internally, DO NOT cache them elsewhere
        /// because we need each test to have its configuration recorded.
        /// </summary>
        /// <param name="name">The name of the session record variable.</param>
        /// <param name="getTenant">
        /// A function to get the tenant.  This is wrapped in a Func becuase
        /// we'll throw Assert.Inconclusive if you try to access a tenant with
        /// an invalid config file.
        /// </param>
        /// <returns>A test tenant to use with our tests.</returns>
        private TenantConfiguration GetTestConfig(string name, Func<TenantConfiguration> getTenant)
        {
            TenantConfiguration config;
            string text;
            switch (Mode)
            {
                case RecordedTestMode.Playback:
                    if (!_playbackConfigCache.TryGetValue(name, out config))
                    {
                        text = Recording.GetVariable(name, null);
                        config = TenantConfiguration.Parse(text);
                        _playbackConfigCache[name] = config;
                    }
                    break;
                case RecordedTestMode.Record:
                    config = getTenant();
                    if (!_recordingConfigCache.TryGetValue(name, out text))
                    {
                        text = TenantConfiguration.Serialize(config, true);
                        _recordingConfigCache[name] = text;
                    }
                    Recording.GetVariable(name, text);
                    break;
                default:
                    config = getTenant();
                    break;
            }
            return config;
        }

        private class StorageTestTokenCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}
