 // Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.AppConfiguration;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.AppConfiguration.Tests
{
    public abstract class AppConfigurationClientBase : ManagementRecordedTestBase<AppConfigurationManagementTestEnvironment>
    {
        public ArmClient ArmClient { get; set; }
        public string Location { get; set; }
        public string KeyUuId { get; set; }
        public string LabelUuId { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string TestContentType { get; set; }
        public string TestValue { get; set; }
        public string ResourceGroupPrefix { get; set; }

        protected AppConfigurationClientBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreTestInLiveMode();
        }

        protected AppConfigurationClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        {
            IgnoreTestInLiveMode();
        }

        protected void Initialize()
        {
            Location = "eastus";
            KeyUuId = "test_key_a6af8952-54a6-11e9-b600-2816a84d0309";
            LabelUuId = "1d7b2b28-549e-11e9-b51c-2816a84d0309";
            Key = "PYTHON_UNIT_" + KeyUuId;
            Label = "test_label1_" + LabelUuId;
            TestContentType = "test content type";
            TestValue = "test value";
            ResourceGroupPrefix = "Default-AppConfiguration-";
            ArmClient = GetArmClient();
        }

        private void IgnoreTestInLiveMode()
        {
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Ignore();
            }
        }

        private void IgnoreApiVersionForResourceProviders()
        {
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                @"/subscriptions/[^/]+/providers/Microsoft.Resources\?api-version=(?<group>[a-z0-9-]+)", "**"
            )
            {
                GroupForReplace = "group"
            });
        }
    }
}
