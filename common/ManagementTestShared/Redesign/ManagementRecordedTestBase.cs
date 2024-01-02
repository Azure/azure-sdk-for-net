// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Castle.DynamicProxy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.ResourceManager.TestFramework
{
    public abstract class ManagementRecordedTestBase<TEnvironment> : RecordedTestBase<TEnvironment>
        where TEnvironment : TestEnvironment, new()
    {
        protected ResourceGroupCleanupPolicy ResourceGroupCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ResourceGroupCleanupPolicy OneTimeResourceGroupCleanupPolicy = new ResourceGroupCleanupPolicy();

        protected ManagementGroupCleanupPolicy ManagementGroupCleanupPolicy = new ManagementGroupCleanupPolicy();

        protected ManagementGroupCleanupPolicy OneTimeManagementGroupCleanupPolicy = new ManagementGroupCleanupPolicy();

        protected ResponseNullFilterPolicy NullFilterPolicy = new ResponseNullFilterPolicy();

        protected ArmClient GlobalClient { get; private set; }

        public TestEnvironment SessionEnvironment { get; private set; }

        public TestRecording SessionRecording { get; private set; }

        private ArmClient _cleanupClient;
        private WaitUntil _waitForCleanup;
        private ResourceType _resourceType;
        protected string ApiVersion { get; }

        protected ManagementRecordedTestBase(bool isAsync, RecordedTestMode? mode = default)
            : base(isAsync, mode)
        {
            AdditionalInterceptors = new[] { new ManagementInterceptor(this) };

            SessionEnvironment = new TEnvironment();
            SessionEnvironment.Mode = Mode;
            Initialize();
            IgnoredQueryParameters.Add("api-version");
        }

        protected ManagementRecordedTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode? mode = default)
            : this(isAsync, mode)
        {
            _resourceType = resourceType;
            ApiVersion = apiVersion;
        }

        protected void SetTagResourceUsage(ArmClient client, bool? useTagResource)
        {
            var target = client.GetType().GetField("__target", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(client);
            target.GetType().GetField("_canUseTagResource", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(target, useTagResource);
        }

        private void Initialize()
        {
            _waitForCleanup = Mode == RecordedTestMode.Live ? WaitUntil.Completed : WaitUntil.Started;
        }

        protected void IgnoreNetworkDependencyVersions()
        {
            // Ignore the api-version of Network operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers\/Microsoft.Network\/(.*?)\?api-version=(?<group>[a-z0-9-]+)", "**"
            )
            {
                GroupForReplace = "group"
            });
        }

        protected void IgnoreAuthorizationDependencyVersions()
        {
            // Ignore the api-version of Authorization operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers\/Microsoft.Authorization\/(.*?)\?api-version=(?<group>[a-z0-9-]+)", "**"
            )
            {
                GroupForReplace = "group"
            });
        }

        protected void IgnoreKeyVaultDependencyVersions()
        {
            // Ignore the api-version of KeyVault operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers\/Microsoft.KeyVault\/(.*?)\?api-version=(?<group>[a-z0-9-]+)", "**"
            )
            {
                GroupForReplace = "group"
            });
        }

        protected void IgnoreManagedIdentityDependencyVersions()
        {
            // Ignore the api-version of ManagedIdentity operations
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/providers\/Microsoft.ManagedIdentity\/(.*?)\?api-version=(?<group>[a-z0-9-]+)", "**"
            )
            {
                GroupForReplace = "group"
            });
        }

        private ArmClient GetCleanupClient()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                return new ArmClient(
                    TestEnvironment.Credential,
                    TestEnvironment.SubscriptionId,
                    new ArmClientOptions() { Environment = GetArmEnvironment(TestEnvironment) });
            }
            return null;
        }

        protected TClient InstrumentClientExtension<TClient>(TClient client) => (TClient)InstrumentClient(typeof(TClient), client, new IInterceptor[] { new ManagementInterceptor(this) });

        protected ArmClient GetArmClient(ArmClientOptions clientOptions = default, string subscriptionId = default, bool enableDeleteAfter = false)
        {
            var options = InstrumentClientOptions(clientOptions ?? new ArmClientOptions());
            options.Environment = GetArmEnvironment(TestEnvironment);
            options.AddPolicy(ResourceGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(ManagementGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(NullFilterPolicy, HttpPipelinePosition.PerRetry);
            if (enableDeleteAfter)
            {
                AddDeleteAfterTagPolicy deleteAfterTagPolicy = new AddDeleteAfterTagPolicy(Recording.UtcNow);
                options.AddPolicy(deleteAfterTagPolicy, HttpPipelinePosition.PerCall);
            }
            if (ApiVersion is not null)
                options.SetApiVersion(_resourceType, ApiVersion);

            return InstrumentClient(new ArmClient(
                TestEnvironment.Credential,
                subscriptionId ?? TestEnvironment.SubscriptionId,
                options), new IInterceptor[] { new ManagementInterceptor(this) });
        }

        private ArmEnvironment GetArmEnvironment(TestEnvironment environment)
        {
            var endpoint = environment.ResourceManagerUrl;
            if (string.IsNullOrEmpty(endpoint))
            {
                return ArmEnvironment.AzurePublicCloud;
            }

            var baseUri = new Uri(endpoint);

            if (baseUri == ArmEnvironment.AzurePublicCloud.Endpoint)
                return ArmEnvironment.AzurePublicCloud;

            if (baseUri == ArmEnvironment.AzureChina.Endpoint)
                return ArmEnvironment.AzureChina;

            if (baseUri == ArmEnvironment.AzureGermany.Endpoint)
                return ArmEnvironment.AzureGermany;

            if (baseUri == ArmEnvironment.AzureGovernment.Endpoint)
                return ArmEnvironment.AzureGovernment;

            return new ArmEnvironment(new Uri(endpoint), SessionEnvironment.ServiceManagementUrl ?? $"{endpoint}/.default");
        }

        [SetUp]
        protected void CreateCleanupClient()
        {
            _cleanupClient ??= GetCleanupClient();
        }

        [TearDown]
        protected void CleanupResourceGroups()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(ResourceGroupCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    try
                    {
                        SubscriptionResource sub = _cleanupClient.GetSubscriptions().Exists(TestEnvironment.SubscriptionId)
                            ? _cleanupClient.GetSubscriptions().Get(TestEnvironment.SubscriptionId)
                            : null;
                        sub?.GetResourceGroups().Get(resourceGroup).Value.Delete(_waitForCleanup);
                    }
                    catch (RequestFailedException e) when (e.Status == 404)
                    {
                        //we assume the test case cleaned it up if it no longer exists.
                    }
                });

                Parallel.ForEach(ManagementGroupCleanupPolicy.ManagementGroupsCreated, mgmtGroupId =>
                {
                    try
                    {
                        _cleanupClient.GetManagementGroupResource(new ResourceIdentifier(mgmtGroupId)).Delete(_waitForCleanup);
                    }
                    catch (RequestFailedException e) when (e.Status == 404 || e.Status == 403)
                    {
                        //we assume the test case cleaned it up if it no longer exists.
                    }
                });
            }
        }

        private async Task StartSessionRecordingAsync()
        {
            // Only create test recordings for the latest version of the service
            TestContext.TestAdapter test = TestContext.CurrentContext.Test;
            if (Mode != RecordedTestMode.Live &&
                test.Properties.ContainsKey("SkipRecordings"))
            {
                throw new IgnoreException((string)test.Properties.Get("SkipRecordings"));
            }
            SessionRecording = await CreateTestRecordingAsync(Mode, GetSessionFilePath());
            SessionEnvironment.SetRecording(SessionRecording);
            ValidateClientInstrumentation = SessionRecording.HasRequests;
        }

        protected async Task StopSessionRecordingAsync()
        {
            if (ValidateClientInstrumentation)
            {
                throw new InvalidOperationException("The test didn't instrument any clients but had recordings. Please call InstrumentClient for the client being recorded.");
            }

            if (SessionRecording != null)
            {
                await SessionRecording.DisposeAsync();
            }

            GlobalClient = null;
        }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            if (!HasOneTimeSetup())
                return;

            await StartSessionRecordingAsync();

            var options = InstrumentClientOptions(new ArmClientOptions(), SessionRecording);
            options.AddPolicy(OneTimeResourceGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.AddPolicy(OneTimeManagementGroupCleanupPolicy, HttpPipelinePosition.PerCall);
            options.Environment = GetArmEnvironment(SessionEnvironment);

            GlobalClient = InstrumentClient(new ArmClient(
                SessionEnvironment.Credential,
                SessionEnvironment.SubscriptionId,
                options), new IInterceptor[] { new ManagementInterceptor(this) });
        }

        private bool HasOneTimeSetup()
        {
            HashSet<Type> types = new HashSet<Type>();
            Type type = GetType();
            Type endType = typeof(ManagementRecordedTestBase<TEnvironment>);
            while (type != endType)
            {
                types.Add(type);
                type = type.BaseType;
            }

            var methods = GetType().GetMethods().Where(m => types.Contains(m.DeclaringType));
            foreach (var method in methods)
            {
                foreach (var attr in method.GetCustomAttributes(false))
                {
                    if (attr is OneTimeSetUpAttribute)
                        return true;
                }
            }
            return false;
        }

        [OneTimeTearDown]
        public void OneTimeCleanupResourceGroups()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                Parallel.ForEach(OneTimeResourceGroupCleanupPolicy.ResourceGroupsCreated, resourceGroup =>
                {
                    SubscriptionResource sub = _cleanupClient.GetSubscriptions().Exists(SessionEnvironment.SubscriptionId)
                        ? _cleanupClient.GetSubscriptions().Get(SessionEnvironment.SubscriptionId)
                        : null;
                    sub?.GetResourceGroups().Get(resourceGroup).Value.Delete(_waitForCleanup);
                });
                Parallel.ForEach(OneTimeManagementGroupCleanupPolicy.ManagementGroupsCreated, mgmtGroupId =>
                {
                    _cleanupClient.GetManagementGroupResource(new ResourceIdentifier(mgmtGroupId)).Delete(_waitForCleanup);
                });
            }

            if (!(GlobalClient is null))
                throw new InvalidOperationException("StopSessionRecording was never called please make sure you call that at the end of your OneTimeSetup");
        }
    }
}
