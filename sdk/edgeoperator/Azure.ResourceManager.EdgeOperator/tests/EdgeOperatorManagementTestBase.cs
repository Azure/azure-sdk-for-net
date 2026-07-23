// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOperator.Tests
{
    public class EdgeOperatorManagementTestBase : ManagementRecordedTestBase<EdgeOperatorManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected EdgeOperatorManagementTestBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            ConfigureAldoSanitizers();
        }

        protected EdgeOperatorManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            ConfigureAldoSanitizers();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient(CreateAldoClientOptions());
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        /// <summary>
        /// Builds <see cref="ArmClientOptions"/> pointed at the ALDO ARM endpoint instead of
        /// public Azure. During Playback the endpoint value comes from the recorded environment
        /// variables, so recorded request URIs match without contacting the disconnected backend.
        /// </summary>
        private ArmClientOptions CreateAldoClientOptions()
        {
            return new ArmClientOptions
            {
                Environment = new ArmEnvironment(TestEnvironment.ArmEndpoint, TestEnvironment.ArmAudience),
            };
        }

        /// <summary>
        /// ALDO-specific sanitization applied to recordings before they are committed. The base
        /// framework already scrubs auth headers and subscription IDs; these entries remove
        /// stamp/host details unique to the disconnected environment.
        /// </summary>
        private void ConfigureAldoSanitizers()
        {
            // Scrub the ALDO stamp identifier from request/response bodies.
            JsonPathSanitizers.Add("$..stampId");
            // Scrub the resourceId of the disconnected operations resource used as billing target.
            JsonPathSanitizers.Add("$..resourceId");
        }
    }
}
