// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class CustomAssessmentAutomationTests : SecurityCenterManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private CustomAssessmentAutomationCollection _customAssessmentAutomationCollection;
        private const string _compressedQuery = "DQAKAEkAYQBtAF8ARwByAG8AdQBwAA0ACgB8ACAAZQB4AHQAZQBuAGQAIABIAGUAYQBsAHQAaABTAHQAYQB0AHUAcwAgAD0AIABpAGYAZgAoAHQAbwBzAHQAcgBpAG4AZwAoAFIAZQBjAG8AcgBkAC4AVQBzAGUAcgBOAGEAbQBlACkAIABjAG8AbgB0AGEAaQBuAHMAIAAnAHUAcwBlAHIAJwAsACAAJwBVAE4ASABFAEEATABUAEgAWQAnACwAIAAnAEgARQBBAEwAVABIAFkAJwApAA0ACgA=";

        public CustomAssessmentAutomationTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _customAssessmentAutomationCollection = _resourceGroup.GetCustomAssessmentAutomations();
        }

        [RecordedTest]
        [Ignore(" Azure.RequestFailedException : The location property is required for this definition.")]
        public async Task CreateOrUpdate()
        {
            string customAssessmentAutomationName = Recording.GenerateAssetName("customAssessmentAutomation");
            var data = new CustomAssessmentAutomationCreateOrUpdateContent()
            {
                CompressedQuery = _compressedQuery,
                SupportedCloud = CustomAssessmentAutomationSupportedCloud.Aws,
                Severity = CustomAssessmentSeverity.Medium,
                DisplayName  = "Password Policy",
                Description = "Data should be encrypted",
                RemediationDescription = "Encrypt store by...",
            };
            var customAssessmentAutomation = await _customAssessmentAutomationCollection.CreateOrUpdateAsync(WaitUntil.Completed, customAssessmentAutomationName,data);
            Assert.IsNotNull(customAssessmentAutomation);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _customAssessmentAutomationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
