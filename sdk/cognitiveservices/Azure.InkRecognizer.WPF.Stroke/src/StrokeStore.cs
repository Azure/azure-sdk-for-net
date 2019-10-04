// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Azure.AI.InkRecognizer;

#pragma warning disable AZC0001 // https://github.com/Azure/azure-sdk-tools/issues/213
namespace Azure.AI.InkRecognizer.WPF.Stroke
//namespace Azure.Data.InkRecognizer.WPF.Stroke
{
    /// <summary>
    /// This is the class for the InkRecognizer GUI. This is based on the WPF Framework.
    /// </summary>
    public class InkStrokeStore
    {
       private readonly List<InkRecognizer.InkStroke> _strokes;
       private int _strokeCounter = 0;

        // Default DPI setting
        private float dpiX = 96.0f;
        private float dpiY = 96.0f;

        /// <summary>
        ///Initialize a new instance of the class 
        /// </summary>
        public InkStrokeStore()
        {
            try
            {
                var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
                var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

                dpiX = (dpiXProperty != null) ? (int)dpiXProperty.GetValue(null, null) : dpiX;
                dpiY = (dpiYProperty != null) ? (int)dpiYProperty.GetValue(null, null) : dpiY;
            }
            catch (Exception)
            {
                /* Incase of error, revert to default DPI settings */
                dpiX = 96.0f;
                dpiY = 96.0f;
            }

            _strokes = new List<Azure.AI.InkRecognizer.InkStroke>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stroke"></param>
        /// <param name="strokeKind"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public long AddStroke(
            System.Windows.Ink.Stroke stroke,
            InkStrokeKind strokeKind = InkStrokeKind.Unknown,
            string language=null)
        {
            var points = stroke.StylusPoints;
            var strokeId = _strokeCounter;

            var inkRecognizerStroke = new InkRecognizerStroke(points, dpiX, dpiY, strokeId);
            inkRecognizerStroke.Kind = strokeKind;
            inkRecognizerStroke.Language = language;

            _strokes.Add(inkRecognizerStroke.GetNativeStroke());

            _strokeCounter++;
            return inkRecognizerStroke.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strokeId"></param>
        public void RemoveStroke(long strokeId)
        {
            var strokeToRemove = _strokes.Find(stroke => stroke.Id == strokeId);
            _strokes.Remove(strokeToRemove);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Azure.AI.InkRecognizer.InkStroke> GetStrokes()
        {
            return _strokes;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InkRecognizerStroke 
    {
        private List<InkPoint> _inkPoints;
        private InkStroke _inkStroke;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="DpiX"></param>
        /// <param name="DpiY"></param>
        /// <param name="strokeId"></param>
        public InkRecognizerStroke(
            IEnumerable<System.Windows.Input.StylusPoint> points,
            float DpiX,
            float DpiY,
            int strokeId)
        {
            _inkPoints = ConvertPixelsToMillimeters(points, DpiX, DpiY);
            Id = strokeId;
            Kind = InkStrokeKind.Unknown;
            _inkStroke = new InkStroke(_inkPoints, Language, Id, Kind);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public InkStroke GetNativeStroke()
        {
            return _inkStroke;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InkPoint> GetInkPoints()
        {
            return _inkPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public InkStrokeKind Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointsInPixels"></param>
        /// <param name="DpiX"></param>
        /// <param name="DpiY"></param>
        /// <returns></returns>
        private List<InkPoint> ConvertPixelsToMillimeters(
            IEnumerable<System.Windows.Input.StylusPoint> pointsInPixels,
            float DpiX,
            float DpiY)
        {
            var transformedInkPoints = new List<InkPoint>();
            const float inchToMillimeterFactor = 25.4f;

            foreach (var point in pointsInPixels)
            {
                var transformedX = (point.X / DpiX) * inchToMillimeterFactor;
                var transformedY = (point.Y / DpiY) * inchToMillimeterFactor;
                var transformedInkPoint = new InkPoint((float)transformedX, (float)transformedY);
                transformedInkPoints.Add(transformedInkPoint);
            }
            return transformedInkPoints;
        }
    }
}
