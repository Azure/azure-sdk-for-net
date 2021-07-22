// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.Core.Tests.Management
{
    public class ManagementPipelineBuilderTests
    {
        [TestCase]
        public void AddPerCallPolicy()
        {
            var options = new ArmClientOptions();
            var dummyPolicy = new DummyPolicy();
            options.AddPolicy(dummyPolicy, HttpPipelinePosition.PerCall);
            var pipeline = ManagementPipelineBuilder.Build(new MockCredential(), new Uri("http://foo.com"), options);

            var perCallPolicyField = pipeline.GetType().GetField("_pipeline", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            var policies = (ReadOnlyMemory<HttpPipelinePolicy>)perCallPolicyField.GetValue(pipeline);
            Assert.IsNotNull(policies.ToArray().FirstOrDefault(p => p.GetType() == typeof(DummyPolicy)));
        }

        [TestCase]
        public void AddPerCallPolicyViaClient()
        {
            var options = new ArmClientOptions();
            var dummyPolicy = new DummyPolicy();
            options.AddPolicy(dummyPolicy, HttpPipelinePosition.PerCall);
            var client = new ArmClient(Guid.NewGuid().ToString(), new MockCredential(), options);

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
