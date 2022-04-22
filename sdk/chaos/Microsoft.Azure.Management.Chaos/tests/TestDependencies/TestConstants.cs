// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Chaos.Tests.TestDependencies
{
    internal class TestConstants
    {
        internal const string DefaultTestSubscriptionId = "fb74b135-894b-4c1d-9b2e-8a3c231abc14";
        internal const string ResourceGroupName = "chaos-dotnet-e2e-tests";
        internal const string ExperimentName = "put-experiment-validation";
        internal const string Region = "westus2";
        internal const string BranchName = "Branch1";
        internal const string StepName = "Step1";
        internal const string ExperimentResourceType = "Microsoft.Chaos/experiments";
        internal const string ExperimentIdentityPrincipalId = "1152b2ed-b85e-4ee6-b702-91a71a2a8482";
        internal const string ExperimentIdentityTenantId = "238a6217-a411-432a-8d7a-1fbf3f1497be";
        internal const string TargetTypeName = "microsoft-cosmosdb";
        internal const string CapabilityTypeName = "Failover-1.0";
        internal const string ParentProvicerNamespace = "Microsoft.DocumentDB";
        internal const string ParentProvicerType = "databaseAccounts";
        internal const string ParentResourceName = "chaos-sdk-e2e-validation-westus2";
    }
}
