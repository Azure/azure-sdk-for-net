// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SqlScriptClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SqlScriptClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public SqlScriptClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SqlScriptClient CreateClient()
        {
            return InstrumentClient(new SqlScriptClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }
    }
}
