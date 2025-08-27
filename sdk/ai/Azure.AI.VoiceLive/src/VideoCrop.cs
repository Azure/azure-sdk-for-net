// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Azure.AI.VoiceLive
{
    /// <summary> Defines a video crop rectangle. </summary>
    public partial class VideoCrop
    {
        /// <summary> Initializes a new instance of <see cref="VideoCrop"/>. </summary>
        /// <param name="topLeftInternal"> Top-left corner of the crop region. </param>
        /// <param name="bottomRightInternal"> Bottom-right corner of the crop region. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="topLeftInternal"/> or <paramref name="bottomRightInternal"/> is null. </exception>
        internal VideoCrop(IList<int> topLeftInternal, IList<int> bottomRightInternal)
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
        internal IList<int> TopLeftInternal
        {
            get
            {
                return new List<int>(new int[] { TopLeft.X, TopLeft.Y });
            }
            set
            {
                TopLeft = ToPoint(value);
            }
        }

        /// <summary> Bottom-right corner of the crop region. </summary>
        internal IList<int> BottomRightInternal
        {
            get
            {
                return new List<int>(new int[] { BottomRight.X, BottomRight.Y });
            }
            set
            {
                BottomRight = ToPoint(value);
            }
        }

        private static Point ToPoint(IList<int> list)
        {
            if (null == list)
            {
                throw new ArgumentNullException(nameof(list));
            }

            var listAsArray = list.ToArray();

            if (listAsArray.Length != 2)
            {
                throw new ArgumentException($"List had {listAsArray.Length} elements, which was not 2");
            }

            return new Point(listAsArray[0], listAsArray[1]);
        }

        /// <summary> Top-left corner of the crop region. </summary>
        public Point TopLeft { get; set; }

        /// <summary> Bottom-right corner of the crop region. </summary>
        public Point BottomRight { get; set; }
    }
}
