// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using NUnit.Framework;
using static Azure.Core.Tests.Management.ManagementPipelineBuilderTests;

namespace Azure.Core.Tests.Management
{
    internal class ManagementPipelineBuilderTests : RecordedTestBase<MgmtPipelineTestEnvironment>
    {
        internal class MgmtPipelineTestEnvironment : TestEnvironment { }

        public ManagementPipelineBuilderTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [SyncOnly]
        public void AddPerCallPolicy()
        {
            var options = new ArmClientOptions();
            var dummyPolicy = new DummyPolicy();
            options.AddPolicy(dummyPolicy, HttpPipelinePosition.PerCall);
            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(new MockCredential(), "http://foo.com/.default"));

            var perCallPolicyField = pipeline.GetType().GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            var policies = (ReadOnlyMemory<HttpPipelinePolicy>)perCallPolicyField.GetValue(pipeline);
            Assert.IsNotNull(policies.ToArray().FirstOrDefault(p => p.GetType() == typeof(DummyPolicy)));
        }

        [RecordedTest]
        [SyncOnly]
        [PlaybackOnly("Not intended for live tests")]
        public void AddPerCallPolicyViaClient()
        {
            var options = InstrumentClientOptions(new ArmClientOptions());
            var dummyPolicy = new DummyPolicy();
            options.AddPolicy(dummyPolicy, HttpPipelinePosition.PerCall);
            var client = InstrumentClient(new ArmClient(TestEnvironment.Credential, null, options));

            var pipelineProperty = client.GetType().GetProperty("Pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty);
            var pipeline = pipelineProperty.GetValue(client) as HttpPipeline;

            var perCallPolicyField = pipeline.GetType().GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            var policies = (ReadOnlyMemory<HttpPipelinePolicy>)perCallPolicyField.GetValue(pipeline);
            Assert.IsNotNull(policies.ToArray().FirstOrDefault(p => p.GetType() == typeof(DummyPolicy)));
        }

        private class DummyPolicy : HttpPipelineSynchronousPolicy
        {
            public int numMsgGot = 0;

            public override void OnReceivedResponse(HttpMessage message)
            {
                Interlocked.Increment(ref numMsgGot);
            }
        }
    }
}
