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

                Assert.That(result, Is.Not.Null);
                var iaResult = result.Value;
                Assert.That(iaResult, Is.Not.Null);

                ValidateResponse(iaResult, testFeatures, false, 2);
            }
        }

        [RecordedTest]
        public async Task AnalyzeFromUrlEntraId()
        {
            var client = GetClientWithDefaultCred();
            var allFeatures = VisualFeatures.Objects | VisualFeatures.People | VisualFeatures.Read | VisualFeatures.SmartCrops | VisualFeatures.Tags;
            var someFeatures = VisualFeatures.Read;

            foreach (var testFeatures in new VisualFeatures[] { allFeatures, someFeatures })
            {
                var result = await client.AnalyzeAsync(TestEnvironment.TestImageInputUrl, testFeatures, new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

                Assert.That(result, Is.Not.Null);
                var iaResult = result.Value;
                Assert.That(iaResult, Is.Not.Null);

                ValidateResponse(iaResult, testFeatures, false, 2);
            }
        }

        [RecordedTest]
        public async Task AnalyzeFromUrlDefaultParams()
        {
            var client = GetClientWithKey();
            var testFeatures = VisualFeatures.Caption | VisualFeatures.Read;

            var result = await client.AnalyzeAsync(TestEnvironment.TestImageInputUrl, testFeatures);

            Assert.That(result, Is.Not.Null);
            var iaResult = result.Value;
            Assert.That(iaResult, Is.Not.Null);

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

                Assert.That(result, Is.Not.Null);
                var iaResult = result.Value;
                Assert.That(iaResult, Is.Not.Null);

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

            Assert.That(result, Is.Not.Null);
            var iaResult = result.Value;
            Assert.That(iaResult, Is.Not.Null);

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
                Assert.That(captionResult, Is.Null);
            }

            if (testFeatures.HasFlag(VisualFeatures.DenseCaptions))
            {
                ValidateDenseCaptions(iaResult);
            }
            else
            {
                Assert.That(iaResult.DenseCaptions, Is.Null);
            }

            var objectsResult = iaResult.Objects;
            if (testFeatures.HasFlag(VisualFeatures.Objects))
            {
                ValidateObjectsResult(objectsResult);
            }
            else
            {
                Assert.That(objectsResult, Is.Null);
            }

            if (testFeatures.HasFlag(VisualFeatures.Tags))
            {
                ValidateTags(iaResult.Tags);
            }
            else
            {
                Assert.That(iaResult.Tags, Is.Null);
            }

            if (testFeatures.HasFlag(VisualFeatures.People))
            {
                ValidatePeopleResult(iaResult);
            }
            else
            {
                Assert.That(iaResult.People, Is.Null);
            }

            if (testFeatures.HasFlag(VisualFeatures.SmartCrops))
            {
                ValidateSmartCrops(iaResult, smartCropsSpecified);
            }
            else
            {
                Assert.That(iaResult.SmartCrops, Is.Null);
            }

            var readResult = iaResult.Read;
            if (!testFeatures.HasFlag(VisualFeatures.Read))
            {
                Assert.That(readResult, Is.Null);
            }
            else
            {
                ValidateRead(iaResult);
            }
        }

        private void ValidateMetaData(ImageAnalysisResult iaResult)
        {
            Assert.That(iaResult.Metadata.Height, Is.GreaterThan(0));
            Assert.That(iaResult.Metadata.Width, Is.GreaterThan(0));
            Assert.That(string.IsNullOrWhiteSpace(iaResult.ModelVersion), Is.False);
        }

        private void ValidateCaption(CaptionResult captionResult, bool genderNeutral)
        {
            Assert.That(captionResult, Is.Not.Null);
            Assert.That(captionResult.Confidence, Is.GreaterThan(0));
            Assert.That(captionResult.Confidence, Is.LessThan(1));
            Assert.That(captionResult.Text.ToLower().Contains(genderNeutral ? "person" : "woman"), Is.True);
            Assert.That(captionResult.Text.ToLower().Contains("table"), Is.True);
            Assert.That(captionResult.Text.ToLower().Contains("laptop"), Is.True);
        }

        private void ValidateDenseCaptions(ImageAnalysisResult iaResult)
        {
            var denseCaptionsResult = iaResult.DenseCaptions;

            Assert.That(denseCaptionsResult, Is.Not.Null);
            Assert.That(denseCaptionsResult.Values.Count, Is.GreaterThan(1));

            var firstCaption = denseCaptionsResult.Values[0];
            Assert.That(firstCaption, Is.Not.Null);
            Assert.That(firstCaption.BoundingBox, Is.Not.Null);
            Assert.That(firstCaption.BoundingBox.Width, Is.EqualTo(iaResult.Metadata.Width));
            Assert.That(firstCaption.BoundingBox.Height, Is.EqualTo(iaResult.Metadata.Height));
            Assert.That(firstCaption.Text, Is.Not.Null);
            if (iaResult.Caption != null)
            {
                Assert.That(firstCaption.Text, Is.EqualTo(iaResult.Caption.Text));
            }

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var oneDenseCaption in denseCaptionsResult.Values)
            {
                Assert.That(oneDenseCaption.BoundingBox, Is.Not.Null);
                Assert.That(boundingBoxes.Add(oneDenseCaption.BoundingBox), Is.True);
                ValidateBoxInResult(oneDenseCaption.BoundingBox, iaResult.Metadata);

                Assert.That(oneDenseCaption.Text, Is.Not.Null);
                Assert.That(string.IsNullOrEmpty(oneDenseCaption.Text), Is.False);

                Assert.That(oneDenseCaption.Confidence, Is.GreaterThan(0));
                Assert.That(oneDenseCaption.Confidence, Is.LessThan(1));
            }
        }

        private void ValidateObjectsResult(ObjectsResult objectsResult)
        {
            Assert.That(objectsResult, Is.Not.Null);
            Assert.That(objectsResult.Values.Count, Is.GreaterThan(0));

            foreach (var oneObject in objectsResult.Values)
            {
                Assert.That(oneObject.BoundingBox, Is.Not.Null);
                Assert.That(oneObject.BoundingBox.X > 0 || oneObject.BoundingBox.Y > 0 || oneObject.BoundingBox.Height > 0 || oneObject.BoundingBox.Width > 0, Is.True);
                Assert.That(oneObject.Tags, Is.Not.Null);
                foreach (var oneTag in oneObject.Tags)
                {
                    Assert.That(string.IsNullOrWhiteSpace(oneTag.Name), Is.False);
                    Assert.That(oneTag.Confidence, Is.GreaterThan(0));
                    Assert.That(oneTag.Confidence, Is.LessThan(1));
                }
            }

            Assert.That(objectsResult.Values.Select(v => v.Tags.Select(t => t.Name.Equals("person", StringComparison.OrdinalIgnoreCase))).Count(), Is.GreaterThan(0));
        }

        private void ValidatePeopleResult(ImageAnalysisResult iaResult)
        {
            var peopleResult = iaResult.People;

            Assert.That(peopleResult, Is.Not.Null);
            Assert.That(peopleResult.Values.Count, Is.GreaterThan(0));

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var onePerson in peopleResult.Values)
            {
                Assert.That(onePerson.BoundingBox, Is.Not.Null);
                Assert.That(boundingBoxes.Add(onePerson.BoundingBox), Is.True);
                ValidateBoxInResult(onePerson.BoundingBox, iaResult.Metadata);

                Assert.That(onePerson.Confidence, Is.GreaterThan(0));
                Assert.That(onePerson.Confidence, Is.LessThan(1));
            }
        }

        private void ValidateTags(TagsResult tagsResult)
        {
            Assert.That(tagsResult, Is.Not.Null);
            Assert.That(tagsResult.Values, Is.Not.Null);
            Assert.That(tagsResult.Values.Count, Is.GreaterThan(0));

            int found = 0;
            var tagNames = new HashSet<string>();

            foreach (var oneTag in tagsResult.Values)
            {
                Assert.That(oneTag.Confidence, Is.GreaterThan(0));
                Assert.That(oneTag.Confidence, Is.LessThan(1));

                Assert.That(string.IsNullOrWhiteSpace(oneTag.Name), Is.False);
                if (oneTag.Name.Equals("person", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("woman", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("laptop", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("cat", StringComparison.OrdinalIgnoreCase) ||
                    oneTag.Name.Equals("canidae", StringComparison.OrdinalIgnoreCase))
                {
                    found++;
                }

                Assert.That(tagNames.Add(oneTag.Name), Is.True);
            }

            Assert.That(found, Is.GreaterThanOrEqualTo(2));
        }

        private void ValidateSmartCrops(ImageAnalysisResult iaResult, int smartCropsSpecified)
        {
            var smartCropsResult = iaResult.SmartCrops;
            Assert.That(smartCropsResult, Is.Not.Null);

            Assert.That(smartCropsResult.Values, Is.Not.Null);
            Assert.That(smartCropsResult.Values.Count, Is.EqualTo(0 != smartCropsSpecified ? smartCropsSpecified : 1));

            var boundingBoxes = new HashSet<ImageBoundingBox>(new BoundingBoxComparer());

            foreach (var oneCrop in smartCropsResult.Values)
            {
                Assert.That(boundingBoxes.Add(oneCrop.BoundingBox), Is.True);
                ValidateBoxInResult(oneCrop.BoundingBox, iaResult.Metadata);
            }
        }

        private void ValidateRead(ImageAnalysisResult result)
        {
            ReadResult readResult = result.Read;
            Assert.That(readResult, Is.Not.Null);

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
                    Assert.That(oneLine.BoundingPolygon.All(p => IsInPolygon(p, pagePolygon)), Is.True);

                    words += oneLine.Words.Count;
                    lines++;
                    allText.AppendLine(oneLine.Text);
                    foreach (var word in oneLine.Words)
                    {
                        // Assert.True(word.BoundingPolygon.All(p => IsInPolygon(p, oneLine.BoundingPolygon)));
                        Assert.That(word.Confidence, Is.GreaterThan(0));
                        Assert.That(word.Confidence, Is.LessThan(1));
                        Assert.That(oneLine.Text.Contains(word.Text), Is.True);
                    }
                }

            Assert.That(words, Is.EqualTo(6));
            Assert.That(lines, Is.EqualTo(3));
            Assert.That($"Sample text{Environment.NewLine}Hand writing{Environment.NewLine}123 456{Environment.NewLine}", Is.EqualTo(allText.ToString()));
        }

        private void ValidateBoxInResult(ImageBoundingBox box, ImageMetadata imageMetadata)
        {
            Assert.That(box.X, Is.GreaterThanOrEqualTo(0));
            Assert.That(box.X, Is.LessThanOrEqualTo(imageMetadata.Width));
            Assert.That(box.Y, Is.GreaterThanOrEqualTo(0));
            Assert.That(box.Y, Is.LessThanOrEqualTo(imageMetadata.Height));
            Assert.That(box.Height, Is.LessThanOrEqualTo(imageMetadata.Height - box.Y));
            Assert.That(box.Width, Is.LessThanOrEqualTo(imageMetadata.Width - box.X));
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
