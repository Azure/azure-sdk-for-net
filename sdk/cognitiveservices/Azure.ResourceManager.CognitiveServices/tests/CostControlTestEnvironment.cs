// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;

namespace Azure.ResourceManager.CognitiveServices.Tests
{
    public class CostControlTestEnvironment : CognitiveServicesManagementTestEnvironment
    {
        public string CostControlSubscriptionId => GetRecordedVariable(
            "SUBSCRIPTION_ID",
            options => options.IsSecret("00000000-0000-0000-0000-000000000000"));

        public string CostControlResourceGroup => GetRecordedVariable(
            "AZURE_RESOURCE_GROUP",
            options => options.IsSecret("sanitized-resource-group"));

        public string CostControlAccountName => GetRecordedVariable(
            "AZURE_COGNITIVE_SERVICES_ACCOUNT",
            options => options.IsSecret("sanitized-cognitive-account"));

        protected override TokenCredential CreateDeveloperCredential() => new AzureCliCredential();
    }
}