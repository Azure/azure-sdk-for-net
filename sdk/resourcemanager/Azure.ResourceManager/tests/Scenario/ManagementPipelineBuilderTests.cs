// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using NUnit.Framework;

namespace Azure.Core.Tests.Management
{
    internal class ManagementPipelineBuilderTests : ClientTestBase
    {
        public ManagementPipelineBuilderTests(bool isAsync)
           : base(isAsync)
        {
        }

        [Test]
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

        [Test]
        [SyncOnly]
        public void AddPerCallPolicyViaClient()
        {
            var options = new ArmClientOptions();
            var dummyPolicy = new DummyPolicy();
            options.AddPolicy(dummyPolicy, HttpPipelinePosition.PerCall);
            var client = InstrumentClient(new ArmClient(new MockCredential(), null, options));

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
