// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    internal class AnalyzeTests : ImageAnalysisTestBase
    {
        public AnalyzeTests(bool isAsync) : base(isAsync)
        { }

        public AnalyzeTests(bool isAsync, RecordedTestMode? mode = RecordedTestMode.Live) : base(isAsync, mode)
        {
        }

        [RecordedTest]
        public async Task AnalyzeFromUrl()
        {
            var client = GetClientWithKey();
            var allFeatures = VisualFeatures.Caption | VisualFeatures.DenseCaptions | VisualFeatures.Objects | VisualFeatures.People | VisualFeatures.Read | VisualFeatures.SmartCrops | VisualFeatures.Tags;
            var someFeatures = VisualFeatures.Caption | VisualFeatures.Read;

            foreach (var testFeatures in new VisualFeatures[] { allFeatures, someFeatures })
            {
                var result = await client.AnalyzeAsync(TestEnvironment.TestImageInputUrl, testFeatures, new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

                Assert.IsNotNull(result);
                var iaResult = result.Value;
                Assert.IsNotNull(iaResult);

                ValidateResponse(iaResult, testFeatures, false, 2);
            }
        }

        [RecordedTest]
        public async Task AnalyzeFromUrlDefaultParams()
        {
            var client = GetClientWithKey();
            var testFeatures = VisualFeatures.Caption | VisualFeatures.Read;

            var result = await client.AnalyzeAsync(TestEnvironment.TestImageInputUrl, testFeatures);

            Assert.IsNotNull(result);
            var iaResult = result.Value;
            Assert.IsNotNull(iaResult);

            ValidateResponse(iaResult, testFeatures, false, 0);
        }

        [RecordedTest]
        public async Task AnalyzeFromStream()
        {
            var client = GetClientWithKey();
            var allFeatures = VisualFeatures.Caption | VisualFeatures.DenseCaptions | VisualFeatures.Objects | VisualFeatures.People | VisualFeatures.Read | VisualFeatures.SmartCrops | VisualFeatures.Tags;
            var someFeatures = VisualFeatures.Caption | VisualFeatures.Read;

            var fileLocation = TestEnvironment.TestImageInputPath;

            foreach (var testFeatures in new VisualFeatures[] { allFeatures, someFeatures })
            {
                using var fileStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                var result = await client.AnalyzeAsync(BinaryData.FromStream(fileStream), testFeatures, new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

                Assert.IsNotNull(result);
                var iaResult = result.Value;
                Assert.IsNotNull(iaResult);

                ValidateResponse(iaResult, testFeatures, false, 2);
            }
        }

        [RecordedTest]
        public async Task AnalyzeUndocumentedParameters()
        {
            var clientOptions = new ImageAnalysisClientOptions()
            {
                Diagnostics = { IsLoggingContentEnabled = true },
            };

            clientOptions.AddPolicy(new QueryAddPolicy("readSlim", "true"), HttpPipelinePosition.BeforeTransport);
            clientOptions.AddPolicy(new QueryAddPolicy("readLanguageDetection", "false"), HttpPipelinePosition.BeforeTransport);

            var client = GetClientWithKey(null, clientOptions);

            var testFeatures = VisualFeatures.Read;

            var result = await client.AnalyzeAsync(TestEnvironment.TestImageInputUrl, testFeatures, new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

            Assert.IsNotNull(result);
            var iaResult = result.Value;
            Assert.IsNotNull(iaResult);

            ValidateResponse(iaResult, testFeatures, false, 2);
        }

        private void ValidateResponse(ImageAnalysisResult iaResult, VisualFeatures testFeatures, bool genderNeutral, int smartCropsSpecified)
        {
            ValidateMetaData(iaResult);

            var captionResult = iaResult.Caption;
            if (testFeatures.HasFlag(VisualFeatures.Caption))
            {
                ValidateCaption(captionResult, genderNeutral);
            }
            else
            {
                Assert.IsNull(captionResult);
            }

            if (testFeatures.HasFlag(VisualFeatures.DenseCaptions))
            {
                ValidateDenseCaptions(iaResult);
            }
            else
            {
                Assert.IsNull(iaResult.DenseCaptions);
            }

            var objectsResult = iaResult.Objects;
            if (testFeatures.HasFlag(VisualFeatures.Objects))
            {
                ValidateObjectsResult(objectsResult);
            }
            else
            {
                Assert.IsNull(objectsResult);
            }

            if (testFeatures.HasFlag(VisualFeatures.Tags))
            {
                ValidateTags(iaResult.Tags);
            }
            else
            {
                Assert.IsNull(iaResult.Tags);
            }

            if (testFeatures.HasFlag(VisualFeatures.People))
            {
                ValidatePeopleResult(iaResult);
            }
            else
            {
                Assert.IsNull(iaResult.People);
            }

            if (testFeatures.HasFlag(VisualFeatures.SmartCrops))
            {
                ValidateSmartCrops(iaResult, smartCropsSpecified);
            }
            else
            {
                Assert.IsNull(iaResult.SmartCrops);
            }

            var readResult = iaResult.Read;
            if (!testFeatures.HasFlag(VisualFeatures.Read))
            {
                Assert.IsNull(readResult);
            }
            else
            {
                ValidateRead(iaResult);
            }
        }

        private void ValidateMetaData(ImageAnalysisResult iaResult)
        {
            Assert.Greater(iaResult.Metadata.Height, 0);
            Assert.Greater(iaResult.Metadata.Width, 0);
            Assert.IsFalse(string.IsNullOrWhiteSpace(iaResult.ModelVersion));
        }

        private void ValidateCaption(CaptionResult captionResult, bool genderNeutral)
        {
            Assert.IsNotNull(captionResult);
            Assert.Greater(captionResult.Confidence, 0);
            Assert.Less(captionResult.Confidence, 1);
            Assert.True(captionResult.Text.ToLower().Contains(genderNeutral ? "person" : "woman"));
            Assert.True(captionResult.Text.ToLower().Contains("table"));
            Assert.True(captionResult.Text.ToLower().Contains("laptop"));
        }

        private void ValidateDenseCaptions(ImageAnalysisResult iaResult)
        {
            var denseCaptionsResult = iaResult.DenseCaptions;

            Assert.IsNotNull(denseCaptionsResult);
            Assert.Greater(denseCaptionsResult.Values.Count, 1);

            var firstCaption = denseCaptionsResult.Values[0];
            Assert.IsNotNull(firstCaption);
            Assert.IsNotNull(firstCaption.BoundingBox);
            Assert.IsTrue(firstCaption.BoundingBox.Width == iaResult.Metadata.Width);
            Assert.IsTrue(firstCaption.BoundingBox.Height == iaResult.Metadata.Height);
            Assert.IsNotNull(firstCaption.Text);
            if (iaResult.Caption != null)
            {
                Assert.AreEqual(iaResult.Caption.Text, firstCaption.Text);
            }

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var oneDenseCaption in denseCaptionsResult.Values)
            {
                Assert.IsNotNull(oneDenseCaption.BoundingBox);
                Assert.IsTrue(boundingBoxes.Add(oneDenseCaption.BoundingBox));
                ValidateBoxInResult(oneDenseCaption.BoundingBox, iaResult.Metadata);

                Assert.IsNotNull(oneDenseCaption.Text);
                Assert.IsFalse(string.IsNullOrEmpty(oneDenseCaption.Text));

                Assert.Greater(oneDenseCaption.Confidence, 0);
                Assert.Less(oneDenseCaption.Confidence, 1);
            }
        }

        private void ValidateObjectsResult(ObjectsResult objectsResult)
        {
            Assert.IsNotNull(objectsResult);
            Assert.Greater(objectsResult.Values.Count, 0);

            foreach (var oneObject in objectsResult.Values)
            {
                Assert.IsNotNull(oneObject.BoundingBox);
                Assert.IsTrue(oneObject.BoundingBox.X > 0 || oneObject.BoundingBox.Y > 0 || oneObject.BoundingBox.Height > 0 || oneObject.BoundingBox.Width > 0);
                Assert.IsNotNull(oneObject.Tags);
                foreach (var oneTag in oneObject.Tags)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(oneTag.Name));
                    Assert.Greater(oneTag.Confidence, 0);
                    Assert.Less(oneTag.Confidence, 1);
                }
            }

            Assert.Greater(objectsResult.Values.Select(v => v.Tags.Select(t => t.Name.Equals("person", StringComparison.OrdinalIgnoreCase))).Count(), 0);
        }

        private void ValidatePeopleResult(ImageAnalysisResult iaResult)
        {
            var peopleResult = iaResult.People;

            Assert.IsNotNull(peopleResult);
            Assert.Greater(peopleResult.Values.Count, 0);

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var onePerson in peopleResult.Values)
            {
                Assert.IsNotNull(onePerson.BoundingBox);
                Assert.IsTrue(boundingBoxes.Add(onePerson.BoundingBox));
                ValidateBoxInResult(onePerson.BoundingBox, iaResult.Metadata);

                Assert.Greater(onePerson.Confidence, 0);
                Assert.Less(onePerson.Confidence, 1);
            }
        }

        private void ValidateTags(TagsResult tagsResult)
        {
            Assert.IsNotNull(tagsResult);
            Assert.IsNotNull(tagsResult.Values);
            Assert.Greater(tagsResult.Values.Count, 0);

            int found = 0;
            var tagNames = new HashSet<string>();

            foreach (var oneTag in tagsResult.Values)
            {
                Assert.Greater(oneTag.Confidence, 0);
                Assert.Less(oneTag.Confidence, 1);

                Assert.IsFalse(string.IsNullOrWhiteSpace(oneTag.Name));
                if (oneTag.Name.Equals("person", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("woman", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("laptop", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("cat", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("canidae", StringComparison.OrdinalIgnoreCase))
                {
                    found++;
                }

                Assert.IsTrue(tagNames.Add(oneTag.Name));
            }

            Assert.GreaterOrEqual(found, 2);
        }

        private void ValidateSmartCrops(ImageAnalysisResult iaResult, int smartCropsSpecified)
        {
            var smartCropsResult = iaResult.SmartCrops;
            Assert.IsNotNull(smartCropsResult);

            Assert.IsNotNull(smartCropsResult.Values);
            Assert.AreEqual(0 != smartCropsSpecified ? smartCropsSpecified : 1, smartCropsResult.Values.Count);

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var oneCrop in smartCropsResult.Values)
            {
                Assert.IsTrue(boundingBoxes.Add(oneCrop.BoundingBox));
                ValidateBoxInResult(oneCrop.BoundingBox, iaResult.Metadata);
            }
        }

        private void ValidateRead(ImageAnalysisResult result)
        {
            ReadResult readResult = result.Read;
            Assert.IsNotNull(readResult);

            StringBuilder allText = new StringBuilder();
            int words = 0;
            int lines = 0;

            var pagePolygon = new ImagePoint[] { new ImagePoint(0, 0),
                                                 new ImagePoint(0, result.Metadata.Height),
                                                 new ImagePoint(result.Metadata.Width, result.Metadata.Height),
                                                 new ImagePoint(result.Metadata.Width, 0) };
            foreach (var block in readResult.Blocks)
                foreach (var oneLine in block.Lines)
                {
                    Assert.True(oneLine.BoundingPolygon.All(p => IsInPolygon(p, pagePolygon)));

                    words += oneLine.Words.Count;
                    lines++;
                    allText.AppendLine(oneLine.Text);
                    foreach (var word in oneLine.Words)
                    {
                        // Assert.True(word.BoundingPolygon.All(p => IsInPolygon(p, oneLine.BoundingPolygon)));
                        Assert.Greater(word.Confidence, 0);
                        Assert.Less(word.Confidence, 1);
                        Assert.True(oneLine.Text.Contains(word.Text));
                    }
                }

            Assert.AreEqual(words, 6);
            Assert.AreEqual(lines, 3);
            Assert.AreEqual(allText.ToString(), $"Sample text{Environment.NewLine}Hand writing{Environment.NewLine}123 456{Environment.NewLine}");
        }

        private void ValidateBoxInResult(ImageBoundingBox box, ImageMetadata imageMetadata)
        {
            Assert.GreaterOrEqual(box.X, 0);
            Assert.LessOrEqual(box.X, imageMetadata.Width);
            Assert.GreaterOrEqual(box.Y, 0);
            Assert.LessOrEqual(box.Y, imageMetadata.Height);
            Assert.LessOrEqual(box.Height, imageMetadata.Height - box.Y);
            Assert.LessOrEqual(box.Width, imageMetadata.Width - box.X);
        }

        private static bool IsInPolygon(ImagePoint suspectPoint, IEnumerable<ImagePoint> polygon)
        {
            int intersectCount = 0;
            ImagePoint[] points = new ImagePoint[polygon.Count() + 1];
            polygon.ToArray().CopyTo(points, 0);
            points[points.Length - 1] = points[0];

            for (int i = 0; i < points.Length - 1; i++)
            {
                ImagePoint p1 = points[i];
                ImagePoint p2 = points[i + 1];

                if (((p1.Y > suspectPoint.Y) != (p2.Y > suspectPoint.Y)) &&
                    (suspectPoint.X < (p2.X - p1.X) * (suspectPoint.Y - p1.Y) / (p2.Y - p1.Y) + p1.X))
                {
                    intersectCount++;
                }
            }

            bool result = intersectCount % 2 != 0;

            if (!result)
            {
                Console.WriteLine("Point {0} is not in polygon {1}", suspectPoint, string.Join(" ", polygon));
            }

            return result;
        }

        private class BoundingBoxComparer : IEqualityComparer<ImageBoundingBox>
        {
            public bool Equals(ImageBoundingBox b1, ImageBoundingBox b2)
            {
                if (ReferenceEquals(b1, b2))
                    return true;

                if (b1 is null || b2 is null)
                    return false;

                return b1.X == b2.X
                    && b1.Y == b2.Y
                    && b1.Height == b2.Height
                    && b1.Width == b2.Width;
            }

            public int GetHashCode(ImageBoundingBox obj)
            {
                return obj.X ^ obj.Y ^ obj.Height ^ obj.Width;
            }
        }

        private class QueryAddPolicy : HttpPipelinePolicy
        {
            private string name;
            private string value;

            public QueryAddPolicy(string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.AppendQuery(name, value);
                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.Uri.AppendQuery(name, value);
                return ProcessNextAsync(message, pipeline);
            }
        }
    }
}
