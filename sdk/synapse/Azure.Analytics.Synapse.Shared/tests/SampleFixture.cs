// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Samples
{
    [LiveOnly]
    [NonParallelizable]
    public class SampleFixture: SamplesBase<SynapseTestEnvironment>
    {
        private SynapseTestEventListener _listener;

        [SetUp]
        public void SetUp() => _listener = new SynapseTestEventListener();

        [TearDown]
        public void TearDown() => _listener?.Dispose();
    }

#pragma warning disable SA1402 // File may only contain a single type
    public partial class Sample1_SubmitSparkJob : SampleFixture { }
    public partial class Sample2_ExecuteSparkStatement : SampleFixture { }
    public partial class Sample1_HelloWorld : SampleFixture { }
    public partial class Sample1_HelloWorldPipeline : SampleFixture { }
    public partial class Sample2_HelloWorldNotebook : SampleFixture { }
    public partial class Sample1_PipelineMonitoring : SampleFixture { }

#pragma warning restore SA1402 // File may only contain a single type
}
