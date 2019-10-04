// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.AI.InkRecognizer;
using System;
using System.Collections.Generic;
using Windows.Graphics.Display;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Azure.AI.UWP.Stroke
{
    /// <summary>
    /// This is the class for ink stroke
    /// </summary>
    public class InkStrokeStore
    {
        List<InkStroke> _strokes;
        uint _strokeCounter = 0;

        // Default DPI setting
        float dpiX = 96.0f;
        float dpiY = 96.0f;

        public InkStrokeStore()
        {
            try
            {
                var displayInfo = DisplayInformation.GetForCurrentView();

                // DisplayInfo.RawDpiX and DisplayInfo.RawDpiY returns 0 when monitor doesnt provide physical dimensions 
                // or when user is in clone or multiple-monitor setup. Fallback to default DPI setting in such cases.
                dpiX = (displayInfo.RawDpiX != 0) ? displayInfo.RawDpiX : dpiX;
                dpiY = (displayInfo.RawDpiY != 0) ? displayInfo.RawDpiY : dpiY;
            }
            catch (Exception)
            {
                /* Incase of error, revert to default DPI settings */
                dpiX = 96.0f;
                dpiY = 96.0f;
            }

            _strokes = new List<Azure.AI.InkRecognizer.InkStroke>();
        }

        public long AddStroke(
            Windows.UI.Input.Inking.InkStroke stroke,
            InkStrokeKind strokeKind = InkStrokeKind.Unknown,
            string language = null)
        {
            var points = stroke.GetInkPoints();

            var strokeId = _strokeCounter;

            // Use InkStroke.Id for Windows 10 Creators Update(v10.0.15063.0) and above
            if (stroke.GetType().GetProperty("Id") != null)
            {
                strokeId = stroke.Id;
            }

            var inkRecognizerStroke = new InkRecognizerStroke(points, dpiX, dpiY, strokeId);
            inkRecognizerStroke.Kind = strokeKind;
            inkRecognizerStroke.Language = language;

            _strokes.Add(inkRecognizerStroke.GetNativeStroke());

            _strokeCounter++;
            return inkRecognizerStroke.Id;
        }

        public void RemoveStroke(long strokeId)
        {
            var strokeToRemove = _strokes.Find(stroke => stroke.Id == strokeId);
            _strokes.Remove(strokeToRemove);
        }

        public IEnumerable<Azure.AI.InkRecognizer.InkStroke> GetStrokes()
        {
            return _strokes;
        }
    }

    /// <summary>
    /// This is an Inkrecognizer class
    /// </summary>
    public class InkRecognizerStroke
    {
        private List<Azure.AI.InkRecognizer.InkPoint> _inkPoints;
        private Azure.AI.InkRecognizer.InkStroke _inkStroke;

        /// <summary>
        /// This is for InkRecognize Strokes
        /// </summary>
        /// <param name="points"></param>
        /// <param name="DpiX"></param>
        /// <param name="DpiY"></param>
        /// <param name="strokeId"></param>
        public InkRecognizerStroke(
            IEnumerable<Windows.UI.Input.Inking.InkPoint> points,
            float DpiX,
            float DpiY,
            uint strokeId)
        {
            _inkPoints = ConvertPixelsToMillimeters(points, DpiX, DpiY);
            Id = (int)strokeId;
            Kind = InkStrokeKind.Unknown;
            _inkStroke = new InkStroke(_inkPoints, Language, Id, Kind);
        }

        public Azure.AI.InkRecognizer.InkStroke GetNativeStroke()
        {
            return _inkStroke;
        }

        public IEnumerable<Azure.AI.InkRecognizer.InkPoint> GetInkPoints()
        {
            return _inkPoints;
        }

        public long Id { get; }

        public InkStrokeKind Kind { get; set; }

        public string Language { get; set; } = null;

        private List<InkPoint> ConvertPixelsToMillimeters(
            IEnumerable<Windows.UI.Input.Inking.InkPoint> pointsInPixels,
            float DpiX,
            float DpiY)
        {
            var transformedInkPoints = new List<InkPoint>();
            const float inchToMillimeterFactor = 25.4f;

            foreach (var point in pointsInPixels)
            {
                var transformedX = (point.Position.X / DpiX) * inchToMillimeterFactor;
                var transformedY = (point.Position.Y / DpiY) * inchToMillimeterFactor;
                var transformedInkPoint = new InkPoint((float)transformedX, (float)transformedY);
                transformedInkPoints.Add(transformedInkPoint);
            }
            return transformedInkPoints;
        }
    }
}
