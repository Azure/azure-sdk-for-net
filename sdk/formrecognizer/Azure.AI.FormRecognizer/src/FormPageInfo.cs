// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormPageInfo
    {
        internal FormPageInfo(ReadResult_internal readResult)
        {
            PageNumber = readResult.Page;
            Angle = readResult.Angle;
            Width = readResult.Width;
            Height = readResult.Height;
            Unit = readResult.Unit;
        }

        /// <summary> The 1-based page number in the input document. </summary>
        public int PageNumber { get; set; }

        /// <summary> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </summary>
        public float Angle { get; set; }

        /// <summary> The width of the image/PDF in pixels/inches, respectively. </summary>
        public float Width { get; set; }

        /// <summary> The height of the image/PDF in pixels/inches, respectively. </summary>
        public float Height { get; set; }

        /// <summary> The unit used by the width, height and boundingBox properties. For images, the unit is &quot;pixel&quot;. For PDF, the unit is &quot;inch&quot;. </summary>
        public LengthUnit Unit { get; set; }
    }
}
