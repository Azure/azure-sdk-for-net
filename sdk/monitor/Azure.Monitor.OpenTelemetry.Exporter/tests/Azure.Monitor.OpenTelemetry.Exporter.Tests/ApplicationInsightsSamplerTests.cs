// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ApplicationInsightsSamplerTests
    {
        [Fact]
        public void VerifyHashAlgorithmCorrectness()
        {
            byte[] testBytes = new byte[]
            {
                          0x8F, 0xFF, 0xFF, 0xFF,
                          0xFF, 0xFF, 0xFF, 0xFF,
                          0, 0, 0, 0, 0, 0, 0, 0,
            };
            byte[] testBytes2 = new byte[]
{
                          0x0F, 0x1F, 0x2F, 0x3F,
                          0x4F, 0x5F, 0x6F, 0x7F,
                          0x8F, 0x9F, 0xAF, 0xBF,
                          0xCF, 0xDF, 0xEF, 0xFF,
};
            ActivityTraceId testId = ActivityTraceId.CreateFromBytes(testBytes);
            ActivityTraceId testId2 = ActivityTraceId.CreateFromBytes(testBytes2);

            ActivityContext parentContext = new ActivityContext();
            SamplingParameters testParams = new SamplingParameters(parentContext, testId, "TestActivity", ActivityKind.Internal);
            SamplingParameters testParams2 = new SamplingParameters(parentContext, testId2, "TestActivity", ActivityKind.Internal);

            ApplicationInsightsSampler zeroSampler = new ApplicationInsightsSampler(0);
            ApplicationInsightsSampler oneSampler = new ApplicationInsightsSampler(1);

            // 0.86 is below the sample score for testId1, but strict enough to drop testId2
            ApplicationInsightsSampler ratioSampler = new ApplicationInsightsSampler(0.86f);

            Assert.Equal(SamplingDecision.Drop, zeroSampler.ShouldSample(testParams).Decision);
            Assert.Equal(SamplingDecision.Drop, zeroSampler.ShouldSample(testParams2).Decision);

            Assert.Equal(SamplingDecision.RecordAndSample, oneSampler.ShouldSample(testParams).Decision);
            Assert.Equal(SamplingDecision.RecordAndSample, oneSampler.ShouldSample(testParams2).Decision);

            Assert.Equal(SamplingDecision.Drop, ratioSampler.ShouldSample(testParams).Decision);
            Assert.Equal(SamplingDecision.RecordAndSample, ratioSampler.ShouldSample(testParams2).Decision);
        }

        [Fact]
        public void ApplicationInsightsSamplerGoodArgs()
        {
            ApplicationInsightsSampler pointFiveSampler = new ApplicationInsightsSampler(0.5f);
            Assert.NotNull(pointFiveSampler);

            ApplicationInsightsSampler zeroSampler = new ApplicationInsightsSampler(0f);
            Assert.NotNull(zeroSampler);

            ApplicationInsightsSampler oneSampler = new ApplicationInsightsSampler(1f);
            Assert.NotNull(oneSampler);
        }

        [Fact]
        public void ApplicationInsightsSamplerBadArgs()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ApplicationInsightsSampler(-2f));
            Assert.Throws<ArgumentOutOfRangeException>(() => new ApplicationInsightsSampler(2f));
        }

        [Fact]
        public void GetDescriptionMatchesSpec()
        {
            var expectedDescription = "ApplicationInsightsSampler{0.5}";
            Assert.Equal(expectedDescription, new ApplicationInsightsSampler(0.5f).Description);
        }
    }
}
