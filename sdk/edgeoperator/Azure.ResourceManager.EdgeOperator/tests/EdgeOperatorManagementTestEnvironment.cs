// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.EdgeOperator.Tests
{
    /// <summary>
    /// Test environment for the EdgeOperator management SDK.
    ///
    /// EdgeOperator is an Azure Local Disconnected Operations (ALDO) resource provider. Its ARM
    /// endpoint lives inside a disconnected AzureLocal stamp and is never reachable from public CI.
    /// The record/playback model handles this: recordings are captured once (Record mode) on a
    /// disconnected ALDO/irvm01 environment where the RP is reachable, sanitized, and committed.
    /// CI then runs Playback only and never contacts the ALDO backend.
    ///
    /// The ALDO ARM endpoint and token audience differ from public Azure, so they are read from
    /// environment variables and persisted with the recording via <see cref="TestEnvironment.GetRecordedOptionalVariable(string)"/>,
    /// which means Playback automatically reuses the value captured at Record time.
    /// </summary>
    public class EdgeOperatorManagementTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// The ALDO ARM (Admin/Operator) endpoint, e.g. the value returned by
        /// <c>az cloud show --query "endpoints.resourceManager"</c> on the AzureLocal cloud.
        /// Set <c>EDGEOPERATOR_ARM_ENDPOINT</c> before recording. Defaults to public ARM so the
        /// project still compiles and runs against public Azure if ever needed.
        /// </summary>
        public Uri ArmEndpoint =>
            new Uri(GetRecordedOptionalVariable("EDGEOPERATOR_ARM_ENDPOINT", options => options.IsSecret("https://sanitized.local/")) ?? "https://management.azure.com");

        /// <summary>
        /// The token audience (scope) for the ALDO ARM endpoint. Set
        /// <c>EDGEOPERATOR_ARM_AUDIENCE</c> before recording. Defaults to the public ARM audience.
        /// </summary>
        public string ArmAudience =>
            GetRecordedOptionalVariable("EDGEOPERATOR_ARM_AUDIENCE", options => options.IsSecret("https://sanitized.local/")) ?? "https://management.azure.com/";

        /// <summary>
        /// Record runs for this package are frequently executed from headless devbox terminals,
        /// where broker-based interactive auth fails before default credential fallback.
        /// Prefer Azure CLI auth in this environment.
        /// </summary>
        protected override Azure.Core.TokenCredential CreateDeveloperCredential()
        {
            return new ChainedTokenCredential(
                new AzureCliCredential(),
                base.CreateDeveloperCredential());
        }
    }
}
