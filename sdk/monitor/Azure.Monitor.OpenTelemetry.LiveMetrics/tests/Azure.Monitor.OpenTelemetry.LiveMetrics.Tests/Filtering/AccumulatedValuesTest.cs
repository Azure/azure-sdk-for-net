namespace Microsoft.ApplicationInsights.Tests
{
    using System;

    using Microsoft.ApplicationInsights.Extensibility.Filtering;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccumulatedValuesTest
    {
        [TestMethod]
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
            Assert.AreEqual(2d, avg);
            Assert.AreEqual(4d, sum);
            Assert.AreEqual(1d, min);
            Assert.AreEqual(3d, max);

            Assert.AreEqual(2, avgCount);
            Assert.AreEqual(2, sumCount);
            Assert.AreEqual(2, minCount);
            Assert.AreEqual(2, maxCount);
        }

        [TestMethod]
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
            Assert.AreEqual(0, avg);
            Assert.AreEqual(0, sum);
            Assert.AreEqual(0, min);
            Assert.AreEqual(0, max);

            Assert.AreEqual(0, avgCount);
            Assert.AreEqual(0, sumCount);
            Assert.AreEqual(0, minCount);
            Assert.AreEqual(0, maxCount);
        }
    }
}