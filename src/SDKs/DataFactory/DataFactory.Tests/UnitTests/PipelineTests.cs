// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.JsonSamples;
using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory.Models;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DataFactory.Tests.UnitTests
{
    public class PipelineTests : BaseUnitTest
    {
        // Enable Xunit test output logger.
        protected readonly ITestOutputHelper logger = new TestOutputHelper();

        public PipelineTests(ITestOutputHelper logger)
            : base()
        {
            this.logger = logger;
        }

        [Theory]
        [ClassData(typeof(PipelineJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void Pipeline_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<PipelineResource>(jsonSample);
        }
    }
}
