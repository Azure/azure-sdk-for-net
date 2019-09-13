// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.AI.InkRecognizer
{
    /// <summary>
    /// The InkPoint struct represents a single position on the path of an ink stroke. Clients of the InkRecognizer
    /// service are expected to add these to the ink strokes that get delivered to the InkRecognizerClient class 
    /// which will translate the strokes to JSON for delivery to the Ink Recognizer service.
    /// </summary>
    public struct InkPoint : IEquatable<InkPoint>
    {
        public float X { get; set; }
        public float Y { get; set; }

        public InkPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (other is InkPoint)
            {
                InkPoint otherPoint = (InkPoint)other;
                return Equals(otherPoint);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)(X * 1000) ^ (int)(Y*1000);
        }

        public bool Equals(InkPoint other)
        {
            if (X == other.X && Y == other.Y)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// The InkStrokeKind enum represents the class a stroke belongs to.The user of the Ink recognizer service
    /// is expected to set this value when it is known with absolute certainty. The default value is 
    /// InkStrokeKind.Unknown.
    /// </summary>
    public enum InkStrokeKind
    {
        /// <summary>
        /// The stroke kind is unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The stroke is part of a drawing
        /// </summary>
        InkDrawing = 1,

        /// <summary>
        /// The stroke is a word or part of a word
        /// </summary>
        InkWriting = 2
    }
    
    ///<summary>
    /// The InkStroke structure represents an ink stroke(a collection of points from the time user places
    /// his writing instrument on the writing surface until the instrument is lifted). Clients of the InkRecognizer
    /// services are expected to pass this struct to the InkRecognizerClient so it can use it to
    /// translate the ink to JSON for delivery to the Ink Recognizer service.
    ///</summary>
    public struct InkStroke : IEquatable<InkStroke>
    {
        private IEnumerable<InkPoint> _points;

        public InkStroke(IEnumerable<InkPoint> points, String language, long id, InkStrokeKind kind = InkStrokeKind.Unknown)
        {
            _points = points;
            Language = language;
            Id = id;
            Kind = kind;
        }
        
        public IEnumerable<InkPoint> GetInkPoints() { return _points; }
        public InkStrokeKind Kind { get; set; }
        public long Id { get; set; }
        public String Language { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if (other is InkStroke)
            {
                InkStroke otherStroke = (InkStroke)other;
                return Equals(otherStroke);
            }
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(InkStroke other)
        {
            if (Id == other.Id)
            {
                return true;
            }
            return false;
        }
    }
}
