// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Maps.Rendering
{
    /// <summary> Path style settings. </summary>
    public class ImagePathStyle
    {
        /// <summary>
        /// Path style including line color, line opacity, circle position, color and opacity settings
        /// </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="pathPositions"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="pathPositions"/> length is 0. </exception>
        public ImagePathStyle(IList<GeoPosition> pathPositions)
        {
            Argument.AssertNotNull(pathPositions, nameof(pathPositions));
            if (pathPositions?.Count == 0)
            {
                throw new ArgumentException("pathPositions should not be empty list.");
            }

            PathPositions = pathPositions;
        }

        /// <summary> The point coordinate on the path. </summary>
        public IList<GeoPosition> PathPositions { get; }

        /// <summary> Line color of the path, including line opacity information. </summary>
        public Color? LineColor { get; set; }

        /// <summary> Fill color of the path, including line opacity information. </summary>
        public Color? FillColor { get; set; }

        /// <summary> Line width of the path in pixels. </summary>
        public int? LineWidthInPixels { get; set; }

        /// <summary> Circle radius in meters. </summary>
        public int? CircleRadiusInMeters { get; set; }

        /// <summary> Convert ImagePathStyle to endpoint-specific string format. </summary>
        internal string ToQueryString() {
            StringBuilder sb = new StringBuilder(256);

            if (LineColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "lc{0:X2}{1:X2}{2:X2}",
                    LineColor?.R, LineColor?.G, LineColor?.A);

                if (LineColor?.A != 255)
                {
                    double alpha = Convert.ToInt32(LineColor?.A, CultureInfo.InvariantCulture) / 255.0;
                    sb.AppendFormat(CultureInfo.InvariantCulture, "|la{0:0.###}", alpha);
                }
            }

            if (FillColor != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|fc{0:X2}{1:X2}{2:X2}",
                    FillColor?.R, FillColor?.G, FillColor?.A);

                if (FillColor?.A != 255)
                {
                    double alpha = Convert.ToInt32(FillColor?.A, CultureInfo.InvariantCulture) / 255.0;
                    sb.AppendFormat(CultureInfo.InvariantCulture, "|fa{0:0.###}", alpha);
                }
            }

            if (LineWidthInPixels != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|lw{0}", LineWidthInPixels);
            }

            if (CircleRadiusInMeters != null)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|ra{0}", CircleRadiusInMeters);
            }

            // The following are path positions composed by a list of GeoPositions
            sb.Append('|');

            foreach (var pos in PathPositions)
            {
                sb.AppendFormat(CultureInfo.InvariantCulture, "|{0} {1}", pos.Longitude, pos.Latitude);
            }

            return sb.ToString();
        }
    }
}
