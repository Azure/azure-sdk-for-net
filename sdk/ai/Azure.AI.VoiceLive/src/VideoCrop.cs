// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Drawing;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Defines a video crop rectangle. </summary>
    public partial class VideoCrop
    {
        /// <summary> Initializes a new instance of <see cref="VideoCrop"/>. </summary>
        /// <param name="topLeftInternal"> Top-left corner of the crop region. </param>
        /// <param name="bottomRightInternal"> Bottom-right corner of the crop region. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topLeftInternal"/> or <paramref name="bottomRightInternal"/> is null. </exception>
        internal VideoCrop(Point2D topLeftInternal, Point2D bottomRightInternal)
        {
            Argument.AssertNotNull(topLeftInternal, nameof(topLeftInternal));
            Argument.AssertNotNull(bottomRightInternal, nameof(bottomRightInternal));

            TopLeftInternal = topLeftInternal;
            BottomRightInternal = bottomRightInternal;
        }

        /// <summary> Initializes a new instance of <see cref="VideoCrop"/>. </summary>
        /// <param name="topLeft"> Top-left corner of the crop region. </param>
        /// <param name="bottomRight"> Bottom-right corner of the crop region. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topLeft"/> or <paramref name="bottomRight"/> is null. </exception>
        public VideoCrop(Point topLeft, Point bottomRight)
        {
            Argument.AssertNotNull(topLeft, nameof(topLeft));
            Argument.AssertNotNull(bottomRight, nameof(bottomRight));

            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        /// <summary> Top-left corner of the crop region. </summary>
        internal Point2D TopLeftInternal
        {
            get
            {
                return new Point2D(TopLeft.X, TopLeft.Y);
            }
            set
            {
                TopLeft = new Point(value.X, value.Y);
            }
        }

        /// <summary> Bottom-right corner of the crop region. </summary>
        internal Point2D BottomRightInternal
        {
            get
            {
                return new Point2D(BottomRight.X, BottomRight.Y);
            }
            set
            {
                BottomRight = new Point(value.X, value.Y);
            }
        }

        /// <summary> Top-left corner of the crop region. </summary>
        public Point TopLeft { get; set; }

        /// <summary> Bottom-right corner of the crop region. </summary>
        public Point BottomRight { get; set; }
    }
}
