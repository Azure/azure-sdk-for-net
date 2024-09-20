// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Maps.Common;

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
        public Point? PushpinAnchorShiftInPixels { get; set; }

        /// <summary> Pushpin color including opacity information. </summary>
        public Color? PushpinColor { get; set; }

        /// <summary>
        /// Pushpin scale ratio. Value should greater than zero. A value of 1 is the standard scale.
        /// Values larger than 1 will make the pins larger, and values smaller than 1 will make them smaller.
        /// </summary>
        public double? PushpinScaleRatio { get; set; }

        /// <summary>
        /// Custom pushpin image, can only be <see cref="Uri" /> format.
        /// </summary>
        public Uri? CustomPushpinImageUri { get; set; }

        /// <summary>
        /// The anchor location of label for built-in pushpins is at the top center
        /// of custom pushpins. To override the anchor location of the pin image,
        /// user can designate how to shift or move the anchor location by pixels
        /// </summary>
        public Point? LabelAnchorShiftInPixels { get; set; }

        /// <summary> Label color information. Opacity value other than 1 be ignored. </summary>
        public Color? LabelColor { get; set; }

        /// <summary>
        /// Label scale ratio. Should greater than 0. A value of 1 is the standard scale.
        /// Values larger than 1 will make the label larger.
        /// </summary>
        public double? LabelScaleRatio { get; set; }

        /// <summary>
        /// A number of degrees of clockwise rotation.
        /// Use a negative number to rotate counter-clockwise.
        /// Value can be -360 to 360.
        /// </summary>
        public int? RotationInDegrees { get; set; }

        /// <summary> Convert ImagePushpinStyle to endpoint-specific string format. </summary>
        internal string ToQueryString() {
            StringBuilder sb = new StringBuilder(256);

            if (CustomPushpinImageUri == null)
            {
                sb.Append("default");
            }
            else
            {
                sb.Append("custom");
            }

            if (PushpinColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|co{0:X2}{1:X2}{2:X2}",
                    PushpinColor?.R, PushpinColor?.G, PushpinColor?.B);

                if (PushpinColor?.A != 255)
                {
                    double alpha = Convert.ToInt32(PushpinColor?.A, CultureInfo.InvariantCulture) / 255.0;
                    sb.AppendFormat(CultureInfo.InvariantCulture, "|al{0:0.###}", alpha);
                }
            }

            if (PushpinScaleRatio != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|sc{0:0.##}", PushpinScaleRatio);
            }

            if (PushpinAnchorShiftInPixels != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|an{0} {1}", PushpinAnchorShiftInPixels?.X, PushpinAnchorShiftInPixels?.Y);
            }

            if (RotationInDegrees != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|ro{0}", RotationInDegrees);
            }

            if (LabelColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|lc{0:X2}{1:X2}{2:X2}",
                    LabelColor?.R, LabelColor?.G, LabelColor?.B);
            }

            if (LabelScaleRatio != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|ls{0:0.##}", LabelScaleRatio);
            }

            if (LabelAnchorShiftInPixels != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|la{0} {1}", LabelAnchorShiftInPixels?.X, LabelAnchorShiftInPixels?.Y);
            }

            // The following are pin point positions
            sb.Append('|');

            foreach (var pos in PushpinPositions)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|{0}", pos.ToQueryString());
            }

            // The following is custom pushpin URL
            if (CustomPushpinImageUri != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "||{0}", CustomPushpinImageUri.AbsoluteUri);
            }

            return sb.ToString();
        }
    }
}
