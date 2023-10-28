// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public AnalyzeTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        [RecordedTest]
        public async Task AnalyzeFromUrl()
        {
            var client = GetClientWithKey();
            var allFeatures = new VisualFeatures[] { VisualFeatures.Caption, VisualFeatures.DenseCaptions, VisualFeatures.Objects, VisualFeatures.People, VisualFeatures.Read, VisualFeatures.SmartCrops, VisualFeatures.Tags };
            var someFeatures = new VisualFeatures[] { VisualFeatures.Caption, VisualFeatures.Read };

            foreach (var testFeatures in new VisualFeatures[][] { allFeatures, someFeatures })
            {
                var result = await client.AnalyzeAsync(new ImageUrl(TestEnvironment.TestImageInputUrl), testFeatures, null, null, new float[] { 0.9F, 1.33F });

                Assert.IsNotNull(result);
                var iaResult = result.Value;
                Assert.IsNotNull(iaResult);

                ValidateResponse(iaResult, testFeatures, false);
            }
        }

        [RecordedTest]
        public async Task AnalyzeFromStream()
        {
            var client = GetClientWithKey();
            var allFeatures = new VisualFeatures[] { VisualFeatures.Caption, VisualFeatures.DenseCaptions, VisualFeatures.Objects, VisualFeatures.People, VisualFeatures.Read, VisualFeatures.SmartCrops, VisualFeatures.Tags };
            var someFeatures = new VisualFeatures[] { VisualFeatures.Caption, VisualFeatures.Read };

            var fileLocation = TestEnvironment.TestImageInputPath;

            foreach (var testFeatures in new VisualFeatures[][] { allFeatures, someFeatures })
            {
                using var fileStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                var result = await client.AnalyzeAsync(BinaryData.FromStream(fileStream), testFeatures, null, null, new float[] { 0.9F, 1.33F });

                Assert.IsNotNull(result);
                var iaResult = result.Value;
                Assert.IsNotNull(iaResult);

                ValidateResponse(iaResult, testFeatures, false);
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

            var testFeatures = new VisualFeatures[] { VisualFeatures.Read };

            var result = await client.AnalyzeAsync(new ImageUrl(TestEnvironment.TestImageInputUrl), testFeatures, null, null, new float[] { 0.9F, 1.33F });

            Assert.IsNotNull(result);
            var iaResult = result.Value;
            Assert.IsNotNull(iaResult);

            ValidateResponse(iaResult, testFeatures, false);
        }

        private void ValidateResponse(ImageAnalysisResult iaResult, IEnumerable<VisualFeatures> testFeatures, bool genderNeutral)
        {
            ValidateMetaData(iaResult);

            var captionResult = iaResult.CaptionResult;
            if (testFeatures.Contains(VisualFeatures.Caption))
            {
                ValidateCaption(captionResult, genderNeutral);
            }
            else
            {
                Assert.IsNull(captionResult);
            }

            if (testFeatures.Contains(VisualFeatures.DenseCaptions))
            {
                ValidateDenseCaptions(iaResult);
            }
            else
            {
                Assert.IsNull(iaResult.DenseCaptionsResult);
            }

            var objectsResult = iaResult.ObjectsResult;
            if (testFeatures.Contains(VisualFeatures.Objects))
            {
                ValidateObjectsResult(objectsResult);
            }
            else
            {
                Assert.IsNull(objectsResult);
            }

            if (testFeatures.Contains(VisualFeatures.Tags))
            {
                ValidateTags(iaResult.TagsResult);
            }
            else
            {
                Assert.IsNull(iaResult.TagsResult);
            }

            if (testFeatures.Contains(VisualFeatures.People))
            {
                ValidatePeopleResult(iaResult);
            }
            else
            {
                Assert.IsNull(iaResult.PeopleResult);
            }

            if (testFeatures.Contains(VisualFeatures.SmartCrops))
            {
                ValidateSmartCrops(iaResult);
            }
            else
            {
                Assert.IsNull(iaResult.SmartCropsResult);
            }

            var readResult = iaResult.ReadResult;
            if (!testFeatures.Contains(VisualFeatures.Read))
            {
                Assert.IsNull(readResult);
            }
            else
            {
                Assert.IsNotNull(readResult);
                Assert.IsFalse(string.IsNullOrWhiteSpace(readResult.ModelVersion));
                Assert.IsFalse(string.IsNullOrEmpty(readResult.Content));
                foreach (var onePage in readResult.Pages)
                {
                    Assert.IsTrue(onePage.Height > 0 || onePage.Width > 0);
                    foreach (var oneLine in onePage.Lines)
                    {
                        Assert.IsNotNull(oneLine.BoundingBox);
                        bool nonZero = false;

                        foreach (var onePoint in oneLine.BoundingBox)
                        {
                            if (onePoint != 0)
                            {
                                nonZero = true;
                                break;
                            }
                        }
                        Assert.IsTrue(nonZero);

                        Assert.IsFalse(string.IsNullOrWhiteSpace(oneLine.Content));
                    }
                }
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
            var denseCaptionsResult = iaResult.DenseCaptionsResult;

            Assert.IsNotNull(denseCaptionsResult);
            Assert.Greater(denseCaptionsResult.Values.Count, 1);

            var firstCaption = denseCaptionsResult.Values[0];
            Assert.IsNotNull(firstCaption);
            Assert.IsNotNull(firstCaption.BoundingBox);
            Assert.IsTrue(firstCaption.BoundingBox.W == iaResult.Metadata.Width);
            Assert.IsTrue(firstCaption.BoundingBox.H == iaResult.Metadata.Height);
            Assert.IsNotNull(firstCaption.Text);
            if (iaResult.CaptionResult != null)
            {
                Assert.AreEqual(iaResult.CaptionResult.Text, firstCaption.Text);
            }

            var captions = new HashSet<string>();
            var boundingBoxes = new HashSet<BoundingBox>(new BoundingBoxComparer());

            foreach (var oneDenseCaption in denseCaptionsResult.Values)
            {
                Assert.IsNotNull(oneDenseCaption.BoundingBox);
                Assert.IsTrue(boundingBoxes.Add(oneDenseCaption.BoundingBox));
                ValidateBoxInResult(oneDenseCaption.BoundingBox, iaResult.Metadata);

                Assert.IsNotNull(oneDenseCaption.Text);
                Assert.IsTrue(captions.Add(oneDenseCaption.Text));

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
                Assert.IsTrue(oneObject.BoundingBox.X > 0 || oneObject.BoundingBox.Y > 0 || oneObject.BoundingBox.H > 0 || oneObject.BoundingBox.W > 0);
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
            var peopleResult = iaResult.PeopleResult;

            Assert.IsNotNull(peopleResult);
            Assert.Greater(peopleResult.Values.Count, 0);

            var boundingBoxes = new HashSet<BoundingBox>(new BoundingBoxComparer());

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

        private void ValidateSmartCrops(ImageAnalysisResult iaResult)
        {
            var smartCropsResult = iaResult.SmartCropsResult;
            Assert.IsNotNull(smartCropsResult);

            Assert.IsNotNull(smartCropsResult.Values);
            Assert.AreEqual(2, smartCropsResult.Values.Count);

            var boundingBoxes = new HashSet<BoundingBox>(new BoundingBoxComparer());

            foreach (var oneCrop in smartCropsResult.Values)
            {
                Assert.IsTrue(boundingBoxes.Add(oneCrop.BoundingBox));
                ValidateBoxInResult(oneCrop.BoundingBox, iaResult.Metadata);
            }
        }

        private void ValidateRead(ImageAnalysisResult result)
        {
            ReadResult readResult = result.ReadResult;
            Assert.IsNotNull(readResult);
            Assert.IsNotNull(readResult.Content);
            Assert.IsTrue(readResult.Content.Equals("Sample text\nHand writing\n123 456"));
            Assert.IsNotNull(readResult.ModelVersion);
            Assert.IsFalse(string.IsNullOrEmpty(readResult.ModelVersion));
            Assert.IsNotNull(readResult.Pages);
            Assert.AreEqual(readResult.Pages.Count, 1);

            DocumentPage page = readResult.Pages[0];
            Assert.IsNotNull(page);
            Assert.IsNotNull(page.Angle);
            Assert.AreEqual(page.PageNumber, 1);
            Assert.AreEqual(page.Height, result.Metadata.Height);
            Assert.AreEqual(page.Width, result.Metadata.Width);

            var words = page.Words;
            Assert.IsNotNull(words);
            Assert.AreEqual(words.Count, 6);

            DocumentWord word = words[0];
            Assert.IsNotNull(word);
            Assert.IsTrue(word.Content.Equals("Sample"));
            Assert.IsTrue(word.Confidence > 0.0);

            DocumentSpan span = word.Span;
            Assert.IsNotNull(span);
            Assert.AreEqual(span.Offset, 0);
            Assert.AreEqual(span.Length, 6);

            var polygon = word.BoundingBox;
            Assert.IsNotNull(polygon);
            Assert.AreEqual(polygon.Count, 8);
            for (int i = 0; i < polygon.Count; i++)
            {
                Assert.IsTrue(polygon[i] > 0.0);
            }

            var lines = page.Lines;
            Assert.IsNotNull(lines);
            Assert.AreEqual(lines.Count, 3);

            DocumentLine line = lines[0];
            Assert.IsNotNull(line);
            Assert.IsTrue(line.Content.Equals("Sample text"));

            var spans = line.Spans;
            Assert.IsNotNull(spans);
            Assert.AreEqual(spans.Count, 1);
            span = spans[0];
            Assert.IsNotNull(span);
            Assert.AreEqual(span.Offset, 0);
            Assert.AreEqual(span.Length, 11);

            polygon = line.BoundingBox;
            Assert.IsNotNull(polygon);
            Assert.AreEqual(polygon.Count, 8);
            for (int i = 0; i < polygon.Count; i++)
            {
                Assert.IsTrue(polygon[i] > 0.0);
            }
        }
        private void ValidateBoxInResult(BoundingBox box, ImageMetadata imageMetadata)
        {
            Assert.GreaterOrEqual(box.X, 0);
            Assert.LessOrEqual(box.X, imageMetadata.Width);
            Assert.GreaterOrEqual(box.Y, 0);
            Assert.LessOrEqual(box.Y, imageMetadata.Height);
            Assert.LessOrEqual(box.H, imageMetadata.Height - box.Y);
            Assert.LessOrEqual(box.W, imageMetadata.Width - box.X);
        }

        private class BoundingBoxComparer : IEqualityComparer<BoundingBox>
        {
            public bool Equals(BoundingBox b1, BoundingBox b2)
            {
                if (ReferenceEquals(b1, b2))
                    return true;

                if (b1 is null || b2 is null)
                    return false;

                return b1.X == b2.X
                    && b1.Y == b2.Y
                    && b1.H == b2.H
                    && b1.W == b2.W;
            }

            public int GetHashCode(BoundingBox obj)
            {
                return obj.X ^ obj.Y ^ obj.H ^ obj.W;
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
