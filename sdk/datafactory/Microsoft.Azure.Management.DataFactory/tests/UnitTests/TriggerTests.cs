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
    public class TriggerTests : BaseUnitTest
    {
        // Enable Xunit test output logger.
        protected readonly ITestOutputHelper logger = new TestOutputHelper();

        public TriggerTests(ITestOutputHelper logger)
            : base()
        {
            this.logger = logger;
        }

        [Theory]
        [ClassData(typeof(TriggerJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void Trigger_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<TriggerResource>(jsonSample);
        }

        [Theory]
        [ClassData(typeof(TriggerRunJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void TriggerRun_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<TriggerRunsQueryResponse>(jsonSample);
        }
    }
}
