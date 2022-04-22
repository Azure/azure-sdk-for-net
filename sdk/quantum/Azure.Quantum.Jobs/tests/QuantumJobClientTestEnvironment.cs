// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientTestEnvironment : TestEnvironment
    {
        public string WorkspaceName => Environment.GetEnvironmentVariable("AZURE_QUANTUM_WORKSPACE_NAME") ?? QuantumJobClientRecordedTestSanitizer.WORKSPACE;
        public string WorkspaceLocation => Environment.GetEnvironmentVariable("AZURE_QUANTUM_WORKSPACE_LOCATION") ?? QuantumJobClientRecordedTestSanitizer.LOCATION;
        public string WorkspaceResourceGroup => Environment.GetEnvironmentVariable("AZURE_QUANTUM_WORKSPACE_RG") ?? QuantumJobClientRecordedTestSanitizer.RESOURCE_GROUP;
        public new string SubscriptionId => Environment.GetEnvironmentVariable("SUBSCRIPTION_ID") ?? QuantumJobClientRecordedTestSanitizer.ZERO_UID;

        public string GetRandomId(string idName)
        {
            var randomId = Guid.NewGuid().ToString("N");
            var randomIdVariableName = $"RANDOM_ID_{idName}";
            if (Mode == RecordedTestMode.Record)
            {
                Environment.SetEnvironmentVariable(randomIdVariableName, randomId);
            }
            return GetRecordedVariable(randomIdVariableName);
        }

        public TokenCredential Credential1
        {
            get
            {
                return new DefaultAzureCredential();
            }
        }

        public QuantumJobClientTestEnvironment()
            : base()
        {
            Environment.SetEnvironmentVariable("AZURE_AUTHORITY_HOST", AzureAuthorityHosts.AzurePublicCloud.ToString());
        }
    }
}
