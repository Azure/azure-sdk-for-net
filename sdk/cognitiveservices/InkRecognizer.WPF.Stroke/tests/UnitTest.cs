// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace InkRecognizerTestWPF
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Azure.AI.InkRecognizer;
    using Azure.AI.InkRecognizer.Models;
    using Azure.AI.InkRecognizer.WPF.Stroke;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestInkRecognizerClient()
        {
            const string dummySubscriptionKey = "";
            const string url = "https://api.cognitive.microsoft.com/inkrecognizer";
            Uri endPoint = new Uri(url);

            var credential = new InkRecognizerCredential(dummySubscriptionKey);
            var inkRecognizerClient = new InkRecognizerClient(endPoint, credential);
            Assert.IsNotNull(inkRecognizerClient);
        }

        /// <summary>
        /// This is to test the store functionlaity.
        /// </summary>
        [TestMethod]
        public void TestInkStrokeStrore()
        {
            var inkStrokeStore = new InkStrokeStore();
            Assert.IsNotNull(inkStrokeStore);

            var stroke = TestUtils.CreateRandomStroke();
            Assert.IsNotNull(stroke);

            // Check default configurations of InkRecognizerStroke
            var strokeId1 = inkStrokeStore.AddStroke(stroke);
            var strokesFromStore = inkStrokeStore.GetStrokes();
            Assert.IsTrue(strokesFromStore.Count() == 1);

            var strokeFromStore = strokesFromStore.ElementAt(0);
            Assert.IsTrue(strokeFromStore.Id == strokeId1);
            Assert.IsTrue(strokeFromStore.Kind == InkStrokeKind.Unknown);

            // Change the configurations of InkRecognizerStroke
            var strokeId2 = inkStrokeStore.AddStroke(stroke, InkStrokeKind.InkDrawing, "en-GB");
            strokesFromStore = inkStrokeStore.GetStrokes();
            Assert.IsTrue(strokesFromStore.Count() == 2);

            strokeFromStore = strokesFromStore.ElementAt(1);
            Assert.IsTrue(strokeFromStore.Id == strokeId2);
            Assert.IsTrue(strokeFromStore.Kind == InkStrokeKind.InkDrawing);
            Assert.IsTrue(strokeFromStore.Language == "en-GB");

            // Check deletion of strokes from Stroke store
            inkStrokeStore.RemoveStroke(strokeId1);
            strokesFromStore = inkStrokeStore.GetStrokes();
            Assert.IsTrue(strokesFromStore.Count() == 1);
            Assert.IsTrue(strokeFromStore.Id == strokeId2);
            inkStrokeStore.RemoveStroke(strokeId2);
            strokesFromStore = inkStrokeStore.GetStrokes();
            Assert.IsTrue(strokesFromStore.Count() == 0);
        }

        [TestMethod]
        public void TestSimpleDrawing()
        {
            var drawingJson = TestUtils.GetSimpleJsonForDrawing();
            var root = InkRecognitionModelFactory.InkRecognitionRoot(drawingJson);
            TestRootForDrawing(root);

            var drawing = (InkDrawing) root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkDrawing).ElementAt(0);
            TestInkDrawing(drawing, root);
        }

        [TestMethod]
        public void TestSimpleWriting()
        {
            var writingJson = TestUtils.GetSimpleJsonForWriting();
            var root = InkRecognitionModelFactory.InkRecognitionRoot(writingJson);
            TestRootForWriting(root);

            var writingRegion = (RecognizedWritingRegion) root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedWritingRegion).ElementAt(0);
            TestWritingRegion(writingRegion, root);

            var paragraph = writingRegion.Paragraphs.ElementAt(0);
            TestParagraph(paragraph, writingRegion);

            var line = paragraph.Lines.ElementAt(0);
            TestLine(line, paragraph);

            var word = line.Words.ElementAt(0);
            TestWord(word, line);
        }

        [TestMethod]
        public void TestWritingWithBullet()
        {
            var bulletJson = TestUtils.GetJsonForWritingWithBullet();
            var root = InkRecognitionModelFactory.InkRecognitionRoot(bulletJson);

            var lines = root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedLine);
            Assert.IsTrue(lines.Count() == 2);

            var line = (RecognizedLine) lines.ElementAt(0);
            Assert.IsNotNull(line);
            var bullet = line.Bullet;
            Assert.IsNotNull(bullet);
            Assert.IsTrue(bullet.Id == 5);
            Assert.IsTrue(bullet.Kind == InkRecognitionUnitKind.InkBullet);
            Assert.IsTrue(bullet.Parent == line);
            Assert.IsTrue(bullet.Children.Count() == 0);
            Assert.IsTrue(bullet.RecognizedText == ".");

            var boundingRect = new RectangleF();
            boundingRect.Height = 4.6f;
            boundingRect.X = 26.6f;
            boundingRect.Y = 17.2f;
            boundingRect.Width = 4.6f;
            Assert.IsTrue(bullet.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(26.9f, 16.5f);
            var point2 = new PointF(31.6f, 17.2f);
            var point3 = new PointF(30.8f, 22.1f);
            var point4 = new PointF(26.1f, 21.3f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(bullet.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));
        }


        private void TestRootForDrawing(RecognitionRoot root)
        {
            Assert.IsNotNull(root);
            //Assert.IsTrue(root.Id == 0);
            //Assert.IsTrue(root.Kind == InkRecognitionUnitKind.RecognizedRoot);
            //Assert.IsNull(root.Parent);
            //Assert.IsTrue(root.Children.Count() == 1);
            //Assert.IsTrue(root.Children.ElementAt(0).Kind == InkRecognitionUnitKind.InkDrawing);

            var strokeIds = new List<long>() { 95 };
            //Assert.IsTrue(root.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 120.4f;
            boundingRect.X = 47.8f;
            boundingRect.Y = 18.2f;
            boundingRect.Width = 207.5f;
            //Assert.IsTrue(root.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(47.8f, 18.2f);
            var point2 = new PointF(254.5f, 18.25f);
            var point3 = new PointF(254.5f, 138.6f);
            var point4 = new PointF(47.8f, 138.6f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            //Assert.IsTrue(root.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));

            // Returns 1 InkRecognition unit: Drawing
            Assert.IsTrue(root.GetInkRecognitionUnits().Count() == 1);
            Assert.IsTrue(root.GetWords().Count() == 0);
            Assert.IsTrue(root.GetDrawings().Count() == 1);

            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedRoot).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedWritingRegion).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedParagraph).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedLine).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkWord).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkDrawing).Count() == 1);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkBullet).Count() == 0);
        }

        private void TestInkDrawing(InkDrawing drawing, RecognitionRoot root)
        {
            Assert.IsNotNull(drawing);
            Assert.IsTrue(drawing.Id == 1);
            Assert.IsTrue(drawing.Kind == InkRecognitionUnitKind.InkDrawing);
            //Assert.IsTrue(drawing.Parent == root);
            Assert.IsTrue(drawing.Children.Count() == 0);

            var point1 = new PointF(78.1f, 19.9f);
            var point2 = new PointF(103.8f, 66.5f);
            var point3 = new PointF(52.8f, 59.7f);
            var points = new List<PointF>() { point1, point2, point3 };
            Assert.IsTrue(drawing.Points.SequenceEqual(points));

            Assert.IsTrue(drawing.RecognizedShape == RecognizedShape.Triangle);
            var center = new PointF(78.2f, 48.7f);
            Assert.IsTrue(drawing.Center.Equals(center));
            Assert.IsTrue(drawing.RotationAngle == 0.0f);

            var boundingRect = new RectangleF();
            boundingRect.Height = 47.6f;
            boundingRect.X = 52.9f;
            boundingRect.Y = 19.4f;
            boundingRect.Width = 51.2f;
            Assert.IsTrue(drawing.BoundingBox.Equals(boundingRect));

            point1 = new PointF(79.5f, 18.7f);
            point2 = new PointF(103.5f, 67.0f);
            point3 = new PointF(64.3f, 86.4f);
            var point4 = new PointF(40.4f, 38.1f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(drawing.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));
        }

        private void TestRootForWriting(RecognitionRoot root)
        {
            Assert.IsNotNull(root);
            //Assert.IsTrue(root.Id == 0);
            //Assert.IsTrue(root.Kind == InkRecognitionUnitKind.RecognizedRoot);
            //Assert.IsNull(root.Parent);
            //Assert.IsTrue(root.Children.Count() == 1);
            //Assert.IsTrue(root.Children.ElementAt(0).Kind == InkRecognitionUnitKind.RecognizedWritingRegion);

            var strokeIds = new List<long>() { 95, 96, 97 };
            //Assert.IsTrue(root.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 33.8f;
            boundingRect.X = 37.9f;
            boundingRect.Y = 16.7f;
            boundingRect.Width = 34.8f;
            //Assert.IsTrue(root.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(40.1f, 12.8f);
            var point2 = new PointF(77.5f, 33.4f);
            var point3 = new PointF(66.8f, 53.6f);
            var point4 = new PointF(29.2f, 32.4f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            //Assert.IsTrue(root.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));

            // Returns 4 InkRecognition units: WritingRegion, Paragraph, Line, InkWord
            Assert.IsTrue(root.GetInkRecognitionUnits().Count() == 4);
            Assert.IsTrue(root.GetWords().Count() == 1);
            Assert.IsTrue(root.GetDrawings().Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkDrawing).Count() == 0);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedWritingRegion).Count() == 1);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedParagraph).Count() == 1);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.RecognizedLine).Count() == 1);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkWord).Count() == 1);
            Assert.IsTrue(root.GetInkRecognitionUnits(InkRecognitionUnitKind.InkBullet).Count() == 0);
        }

        private void TestWritingRegion(RecognizedWritingRegion writingRegion, RecognitionRoot root)
        {
            Assert.IsNotNull(writingRegion);
            Assert.IsTrue(writingRegion.Id == 1);
            Assert.IsTrue(writingRegion.Kind == InkRecognitionUnitKind.RecognizedWritingRegion);
           // Assert.IsTrue(writingRegion.Parent == root);
            Assert.IsTrue(writingRegion.Children.Count() == 1);
            Assert.IsTrue(writingRegion.Paragraphs.Count() == 1);
            Assert.IsTrue(writingRegion.RecognizedText == "hey");

            var strokeIds = new List<long>() { 95, 96, 97 };
            Assert.IsTrue(writingRegion.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 33.8f;
            boundingRect.X = 37.9f;
            boundingRect.Y = 16.7f;
            boundingRect.Width = 34.8f;
            Assert.IsTrue(writingRegion.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(40.1f, 12.8f);
            var point2 = new PointF(77.5f, 33.4f);
            var point3 = new PointF(66.8f, 53.6f);
            var point4 = new PointF(29.2f, 32.4f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(writingRegion.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));
        }

        private void TestParagraph(RecognizedParagraph paragraph, RecognizedWritingRegion writingRegion)
        {
            Assert.IsNotNull(paragraph);
            Assert.IsTrue(paragraph.Id == 2);
            Assert.IsTrue(paragraph.Kind == InkRecognitionUnitKind.RecognizedParagraph);
            Assert.IsTrue(paragraph.Parent == writingRegion);
            Assert.IsTrue(paragraph.Children.Count() == 1);
            Assert.IsTrue(paragraph.Lines.Count() == 1);
            Assert.IsTrue(paragraph.RecognizedText == "hey");

            var strokeIds = new List<long>() { 95, 96, 97 };
            Assert.IsTrue(paragraph.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 33.8f;
            boundingRect.X = 37.9f;
            boundingRect.Y = 16.7f;
            boundingRect.Width = 34.8f;
            Assert.IsTrue(paragraph.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(40.1f, 12.8f);
            var point2 = new PointF(77.5f, 33.4f);
            var point3 = new PointF(66.8f, 53.6f);
            var point4 = new PointF(29.2f, 32.4f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(paragraph.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));
        }

        private void TestLine(RecognizedLine line, RecognizedParagraph paragraph)
        {
            Assert.IsNotNull(line);
            Assert.IsTrue(line.Id == 3);
            Assert.IsTrue(line.Kind == InkRecognitionUnitKind.RecognizedLine);
            Assert.IsTrue(line.Parent == paragraph);
            Assert.IsTrue(line.Children.Count() == 1);
            Assert.IsTrue(line.Words.Count() == 1);
            Assert.IsNull(line.Bullet);
            Assert.IsTrue(line.RecognizedText == "hey");

            var strokeIds = new List<long>() { 95, 96, 97 };
            Assert.IsTrue(line.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 33.8f;
            boundingRect.X = 37.9f;
            boundingRect.Y = 16.7f;
            boundingRect.Width = 34.8f;
            Assert.IsTrue(line.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(40.1f, 12.8f);
            var point2 = new PointF(77.5f, 33.4f);
            var point3 = new PointF(66.8f, 53.6f);
            var point4 = new PointF(29.2f, 32.4f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(line.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));

            var alternates = new List<string>() { "hoy", "ney", "heif" };
            Assert.IsTrue(line.Alternates.SequenceEqual(alternates));
        }

        private void TestWord(InkWord word, RecognizedLine line)
        {
            Assert.IsNotNull(word);
            Assert.IsTrue(word.Id == 4);
            Assert.IsTrue(word.Kind == InkRecognitionUnitKind.InkWord);
            Assert.IsTrue(word.Parent == line);
            Assert.IsTrue(word.Children.Count() == 0);
            Assert.IsTrue(word.RecognizedText == "hey");

            var strokeIds = new List<long>() { 95, 96, 97 };
            Assert.IsTrue(word.StrokeIds.SequenceEqual(strokeIds));

            var boundingRect = new RectangleF();
            boundingRect.Height = 33.8f;
            boundingRect.X = 37.9f;
            boundingRect.Y = 16.7f;
            boundingRect.Width = 34.8f;
            Assert.IsTrue(word.BoundingBox.Equals(boundingRect));

            var point1 = new PointF(40.1f, 12.8f);
            var point2 = new PointF(77.5f, 33.4f);
            var point3 = new PointF(66.8f, 53.6f);
            var point4 = new PointF(29.2f, 32.4f);
            var rotatedBoundingRect = new List<PointF> { point1, point2, point3, point4 };
            Assert.IsTrue(word.RotatedBoundingBox.SequenceEqual(rotatedBoundingRect));

            var alternates = new List<string>() { "hoy", "ney", "heif" };
            Assert.IsTrue(word.Alternates.SequenceEqual(alternates));
        }
    }
}
