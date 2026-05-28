using Microsoft.Azure.CognitiveServices.AnomalyDetector;
using Microsoft.Azure.CognitiveServices.AnomalyDetector.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;

namespace AnomalyDetectorSDK.Tests
{
    public class EntireSeriesDetectTests : BaseTests
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6208")]
        public void TestLastAnomalySeries()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TestLastAnomalySeries");
                IAnomalyDetectorClient client = GetAnomalyDetectorClient(HttpMockServer.CreateInstance());
                var series = new List<Point>{
                    new Point(DateTime.Parse("1962-01-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-02-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-03-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-04-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-05-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-06-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-07-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-08-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-09-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-10-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-11-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-12-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-01-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-02-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-03-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-04-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-05-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-06-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-07-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-08-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-09-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-10-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-11-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-12-01T00:00:00Z"), 0)
                };
                Request request = new Request(series, Granularity.Monthly);
                request.MaxAnomalyRatio = 0.25;
                request.Sensitivity = 95;
                var result = client.EntireDetectAsync(request).Result;
                Assert.True(result.IsAnomaly[series.Count - 1]);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6208")]
        public void TestRandomAnomalySeries()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TestRandomAnomalySeries");
                IAnomalyDetectorClient client = GetAnomalyDetectorClient(HttpMockServer.CreateInstance());
                var series = new List<Point>{
                    new Point(DateTime.Parse("1962-01-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-02-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-03-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-04-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-05-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-06-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-07-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-08-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-09-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-10-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-11-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1962-12-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-01-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-02-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-03-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-04-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-05-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-06-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-07-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-08-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-09-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-10-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-11-01T00:00:00Z"), 1),
                    new Point(DateTime.Parse("1963-12-01T00:00:00Z"), 1)
                };
                Request request = new Request(series, Granularity.Monthly);
                request.MaxAnomalyRatio = 0.25;
                request.Sensitivity = 95;
                int anomalyIndex = FakeRandom(0, series.Count - 1);
                request.Series[anomalyIndex].Value = 0;
                var result = client.EntireDetectAsync(request).Result;
                Assert.True(result.IsAnomaly[anomalyIndex]);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6208")]
        public void TestSineDistributionSeries()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TestSineDistributionSeries");
                IAnomalyDetectorClient client = GetAnomalyDetectorClient(HttpMockServer.CreateInstance());
                int len = 49;
                int frequency = 4;
                var startTime = DateTime.Parse("2018-05-01T00:00:00Z");

                var series = Enumerable.Range(0, len)
                    .Select(e => new Point(startTime.AddDays(e), Math.Sin(2 * Math.PI * frequency * e / (len - 1)))).ToList();
                Request request = new Request(series, Granularity.Daily);
                var result = client.EntireDetectAsync(request).Result;
                Assert.Equal(12, result.Period);

                int anomalyIndex = FakeRandom(12, 48);
                request.Series[anomalyIndex].Value = 2;
                result = client.EntireDetectAsync(request).Result;
                Assert.True(result.IsAnomaly[anomalyIndex]);
            }
        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6208")]
        public void TestNormalDistributionSeries()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TestNormalDistributionSeries");
                IAnomalyDetectorClient client = GetAnomalyDetectorClient(HttpMockServer.CreateInstance());

                var startTime = DateTime.Parse("2018-05-01T00:00:00Z");

                double sigma = 0.01;
                double step = 0.0008;
                int len = 99;
                double start = -(len / 2) * step;
                var singleTile = new List<double>();
                for (int i = 0; i < len; ++i)
                {
                    double x = start + step * i;
                    singleTile.Add(1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-x * x / (2 * sigma * sigma)));
                }

                var series = new List<Point>();
                for (int i = 0; i < len * 4; ++i)
                {
                    series.Add(new Point(startTime.AddDays(i), singleTile[i % len]));
                }

                Request request = new Request(series, Granularity.Daily);
                var result = client.EntireDetectAsync(request).Result;
                Assert.Equal(len, result.Period);
                Assert.DoesNotContain(true, result.IsAnomaly);

                int anomalyIndex = FakeRandom(len, len*4-1);
                request.Series[anomalyIndex].Value = 100;
                result = client.EntireDetectAsync(request).Result;
                Assert.True(result.IsAnomaly[anomalyIndex]);
            }
        }

        private int FakeRandom(int minValue, int maxValue)
        {
            return (minValue + maxValue) / 2;
        }
    }
}
