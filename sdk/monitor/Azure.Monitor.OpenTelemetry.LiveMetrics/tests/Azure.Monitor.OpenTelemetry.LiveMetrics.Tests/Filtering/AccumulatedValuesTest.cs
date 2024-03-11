// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    using Xunit;

    public class AccumulatedValuesTest
    {
        [Fact]
        public void AccumulatedValuesAggregatesCorrectly()
        {
            // ARRANGE
            double[] accumulatedValues = { 1d, 3d };
            AccumulatedValues accumulatorAverage = new AccumulatedValues("Metric1", AggregationType.Avg);
            AccumulatedValues accumulatorSum = new AccumulatedValues("Metric1", AggregationType.Sum);
            AccumulatedValues accumulatorMin = new AccumulatedValues("Metric1", AggregationType.Min);
            AccumulatedValues accumulatorMax = new AccumulatedValues("Metric1", AggregationType.Max);

            // ACT
            ArrayHelpers.ForEach(accumulatedValues, accumulatorAverage.AddValue);
            ArrayHelpers.ForEach(accumulatedValues, accumulatorSum.AddValue);
            ArrayHelpers.ForEach(accumulatedValues, accumulatorMin.AddValue);
            ArrayHelpers.ForEach(accumulatedValues, accumulatorMax.AddValue);

            double avg = accumulatorAverage.CalculateAggregation(out long avgCount);
            double sum = accumulatorSum.CalculateAggregation(out long sumCount);
            double min = accumulatorMin.CalculateAggregation(out long minCount);
            double max = accumulatorMax.CalculateAggregation(out long maxCount);

            // ASSERT
            Assert.Equal(2d, avg);
            Assert.Equal(4d, sum);
            Assert.Equal(1d, min);
            Assert.Equal(3d, max);

            Assert.Equal(2, avgCount);
            Assert.Equal(2, sumCount);
            Assert.Equal(2, minCount);
            Assert.Equal(2, maxCount);
        }

        [Fact]
        public void AccumulatedValuesAggregatesCorrectlyForEmptyDataSet()
        {
            // ARRANGE
            AccumulatedValues accumulatorAverage = new AccumulatedValues("Metric1", AggregationType.Avg);
            AccumulatedValues accumulatorSum = new AccumulatedValues("Metric1", AggregationType.Sum);
            AccumulatedValues accumulatorMin = new AccumulatedValues("Metric1", AggregationType.Min);
            AccumulatedValues accumulatorMax = new AccumulatedValues("Metric1", AggregationType.Max);

            // ACT
            double avg = accumulatorAverage.CalculateAggregation(out long avgCount);
            double sum = accumulatorSum.CalculateAggregation(out long sumCount);
            double min = accumulatorMin.CalculateAggregation(out long minCount);
            double max = accumulatorMax.CalculateAggregation(out long maxCount);

            // ASSERT
            Assert.Equal(0, avg);
            Assert.Equal(0, sum);
            Assert.Equal(0, min);
            Assert.Equal(0, max);

            Assert.Equal(0, avgCount);
            Assert.Equal(0, sumCount);
            Assert.Equal(0, minCount);
            Assert.Equal(0, maxCount);
        }
    }
}
