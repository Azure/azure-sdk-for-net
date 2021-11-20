// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Search.Models
{
    [CodeGenModel("BoundingBox")]
    public partial class BoundingBox
    {
        /// <summary> Initializes a new instance of BoundingBox. </summary>
        /// <param name="northWest"> BoundingBox north-west point. </param>
        /// <param name="southEast"> BoundingBox south-east point. </param>
        public BoundingBox(LatLong northWest, LatLong southEast)
        {
            this.TopLeft = northWest;
            this.BottomRight = southEast;
        }

        /// <summary> Initializes a new instance of BoundingBox. </summary>
        /// <param name="north"> BoundingBox north latitude. </param>
        /// <param name="east"> BoundingBox east longitude. </param>
        /// <param name="south"> BoundingBox south latitude. </param>
        /// <param name="west"> BoundingBox west longitude. </param>
        public BoundingBox(double north, double east, double south, double west)
        {
            this.TopLeft = new LatLong(north, west);
            this.BottomRight = new LatLong(south, east);
        }

        /// <summary> Latitude property. </summary>
        [CodeGenMember("TopLeft")]
        public LatLong TopLeft { get; }

        /// <summary> Longitude property. </summary>
        [CodeGenMember("BottomRight")]
        public LatLong BottomRight { get; }

        /// <summary> Bounding Box north west point </summary>
        public LatLong NorthWest => this.TopLeft;

        /// <summary> Bounding Box north west point </summary>
        public LatLong SouthEast => this.BottomRight;

        /// <summary> Bounding Box south west point </summary>
        public LatLong BottomLeft => new LatLong(this.BottomRight.Lat, this.TopLeft.Lon);

        /// <summary> Bounding Box top right point </summary>
        public LatLong TopRight => new LatLong(this.TopLeft.Lat, this.BottomRight.Lon);

        /// <summary> Bounding Box south west point </summary>
        public LatLong SouthWest => new LatLong(this.BottomRight.Lat, this.TopLeft.Lon);

        /// <summary> Bounding Box north east point </summary>
        public LatLong NorthEast => new LatLong(this.TopLeft.Lat, this.BottomRight.Lon);

        /// <summary> Bounding Box north latitude </summary>
        public double Top => this.TopLeft.Lat;

        /// <summary> Bounding Box north latitude </summary>
        public double North => this.TopLeft.Lat;

        /// <summary> Bounding Box south latitude </summary>
        public double Bottom => this.BottomRight.Lat;

        /// <summary> Bounding Box south latitude </summary>
        public double South => this.BottomRight.Lat;

        /// <summary> Bounding Box west longtide </summary>
        public double Left => this.TopLeft.Lon;

        /// <summary> Bounding Box south latitude </summary>
        public double West => this.TopLeft.Lon;

        /// <summary> Bounding Box east longtide </summary>
        public double Right => this.BottomRight.Lon;

        /// <summary> Bounding Box east latitude </summary>
        public double East => this.BottomRight.Lon;
    }
}
