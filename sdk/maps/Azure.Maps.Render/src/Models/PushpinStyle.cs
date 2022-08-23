// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Azure.Core;

namespace Azure.Maps.Render
{
    /// <summary> Pushpin style settings. </summary>
    public class PushpinStyle
    {
        /// <summary>
        /// Pushpin style including pin and label color, scale, rotation and position settings
        /// </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="pinPositions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pinPositions"/> length is 0. </exception>
        public PushpinStyle(
            IList<PinPosition> pinPositions,
            Point? pinAnchorShift = null,
            Color? pinColor = null,
            double? pinScale = null,
            Uri? customPinImage = null,
            Point? labelAnchorShift = null,
            Color? labelColor = null,
            double? labelScale = null,
            int? rotation = null)
        {
            Argument.AssertNotNull(pinPositions, nameof(pinPositions));
            if (pinPositions.Count == 0)
            {
                throw new ArgumentException("pinPositions should not be empty list.");
            }

            this.PinPositions = pinPositions;
            this.PinAnchorShiftInPixels = pinAnchorShift;
            this.PinColor = pinColor;
            this.PinScale = pinScale;
            this.CustomPinImage = customPinImage;
            this.LabelAnchorShiftInPixels = labelAnchorShift;
            this.LabelColor = labelColor;
            this.LabelScale = labelScale;
            this.RotationInDegrees = rotation;
        }

        /// <summary> Pushpin coordinate on the map. </summary>
        public IList<PinPosition> PinPositions { get; }

        /// <summary>
        /// To override the anchor location of the pin image,
        /// user can designate how to shift or move the anchor location by pixels
        /// </summary>
        public Point? PinAnchorShiftInPixels { get; set; }

        /// <summary> Pushpin color including opacity information. </summary>
        public Color? PinColor { get; set; }

        /// <summary>
        /// Pushpin scale, value should greater than zero. A value of 1 is the standard scale.
        /// Values larger than 1 will make the pins larger, and values smaller than 1 will make them smaller.
        /// </summary>
        public double? PinScale { get; set; }

        /// <summary>
        /// Custom pushpin image, can only be <see cref="Uri" /> format.
        /// </summary>
        public Uri? CustomPinImage { get; set; }

        /// <summary>
        /// The anchor location of label for built-in pushpins is at the top center
        /// of custom pushpins. To override the anchor location of the pin image,
        /// user can designate how to shift or move the anchor location by pixels
        /// </summary>
        public Point? LabelAnchorShiftInPixels { get; set; }

        /// <summary> Label color information. Opacity value other than 1 be ignored. </summary>
        public Color? LabelColor { get; set; }

        /// <summary>
        /// Label scale, should greater than 0. A value of 1 is the standard scale.
        /// Values larger than 1 will make the label larger.
        /// </summary>
        public double? LabelScale { get; set; }

        /// <summary>
        /// A number of degrees of clockwise rotation.
        /// Use a negative number to rotate counter-clockwise.
        /// Value can be -360 to 360.
        /// </summary>
        public int? RotationInDegrees { get; set; }

        /// <summary> Convert PushpinStyle to endpoint-specific string format. </summary>
        public override string ToString() {
            StringBuilder sb = new StringBuilder(256);

            if (this.CustomPinImage == null)
            {
                sb.Append("default");
            }
            else
            {
                sb.Append("custom");
            }

            if (PinColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|co{0:X2}{1:X2}{2:X2}",
                    PinColor?.R, PinColor?.G, PinColor?.A);

                if (PinColor?.A != 255)
                {
                    double alpha = Convert.ToInt32(PinColor?.A, CultureInfo.InvariantCulture) / 255.0;
                    sb.AppendFormat(CultureInfo.InvariantCulture, "|al{0:0.###}", alpha);
                }
            }

            if (PinScale != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|sc{0:0.##}", PinScale);
            }

            if (PinAnchorShiftInPixels != null)
            {
                sb.Append($"|an{PinAnchorShiftInPixels?.X} {PinAnchorShiftInPixels?.Y}");
            }

            if (RotationInDegrees != null)
            {
                sb.Append($"|ro{RotationInDegrees}");
            }

            if (LabelColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|lc{0:X2}{1:X2}{2:X2}",
                    LabelColor?.R, LabelColor?.G, LabelColor?.B);
            }

            if (LabelScale != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|ls{0:0.##}", LabelScale);
            }

            if (LabelAnchorShiftInPixels != null)
            {
                sb.Append($"|la{LabelAnchorShiftInPixels?.X} {LabelAnchorShiftInPixels?.Y}");
            }

            // The following are pin point positions
            sb.Append('|');

            foreach (var pos in PinPositions)
            {
                sb.Append($"|{pos}");
            }

            // The following is custom pushpin URL
            if (this.CustomPinImage != null)
            {
                sb.Append($"||{CustomPinImage.AbsoluteUri}");
            }

            return sb.ToString();
        }
    }
}
