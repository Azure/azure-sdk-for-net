// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> Pushpin style settings. </summary>
    public class ImagePushpinStyle
    {
        /// <summary>
        /// Pushpin style including pin and label color, scale, rotation and position settings
        /// </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="pushpinPositions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pushpinPositions"/> length is 0. </exception>
        public ImagePushpinStyle(IList<PushpinPosition> pushpinPositions)
        {
            Argument.AssertNotNull(pushpinPositions, nameof(pushpinPositions));
            if (pushpinPositions.Count == 0)
            {
                throw new ArgumentException("pushpinPositions should not be empty list.");
            }

            PushpinPositions = pushpinPositions;
        }

        /// <summary> Pushpin coordinate on the map. </summary>
        public IList<PushpinPosition> PushpinPositions { get; }

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
        public Uri? CustomPinImageUri { get; set; }

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

        /// <summary> Convert ImagePushpinStyle to endpoint-specific string format. </summary>
        internal string ToQueryString() {
            StringBuilder sb = new StringBuilder(256);

            if (CustomPinImageUri == null)
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

            foreach (var pos in PushpinPositions)
            {
                sb.Append($"|{pos.ToQueryString()}");
            }

            // The following is custom pushpin URL
            if (CustomPinImageUri != null)
            {
                sb.Append($"||{CustomPinImageUri.AbsoluteUri}");
            }

            return sb.ToString();
        }
    }
}
