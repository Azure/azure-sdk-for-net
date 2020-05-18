using System.Collections;
using System.Collections.Generic;
using System.Linq;
#pragma warning disable 1591

namespace Azure.Core.Spatial
{

    /// <summary>
    ///
    /// </summary>
    public readonly struct Position
    {
        /// <summary>
        ///
        /// </summary>
        public double? Altitude { get; }
        /// <summary>
        ///
        /// </summary>
        public double Longitude { get; }
        /// <summary>
        ///
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public Position(double longitude, double latitude) : this(longitude, latitude, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="altitude"></param>
        public Position(double longitude, double latitude, double? altitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }
    }

    public readonly struct CoordinateReferenceSystem
    {

    }

    public readonly struct BoundingBox
    {

    }

    public class Geometry
    {
        public GeomertyMetadata? Metadata { get; }

        public Geometry(GeomertyMetadata? metadata)
        {
            Metadata = metadata;
        }
    }

    public class GeomertyMetadata
    {
        public GeomertyMetadata(BoundingBox? boundingBox, CoordinateReferenceSystem? coordinateReferenceSystem, IReadOnlyDictionary<string, object>? additionalProperties)
        {
            AdditionalProperties = additionalProperties;
            BoundingBox = boundingBox;
            CoordinateReferenceSystem = coordinateReferenceSystem;
        }

        public IDictionary<string, object> AdditionalProperties { get; }
        public BoundingBox? BoundingBox { get; }
        public CoordinateReferenceSystem CoordinateReferenceSystem { get; set; }
    }

    public class Point
    {
        public Point(Position position)
        {
            Position = position;
        }

        public Position Position { get; }
    }

    public class LinearRing
    {
        public LinearRing(IEnumerable<Point> positions)
        {
            Positions = positions.ToList();
        }

        public IReadOnlyList<Point> Positions { get; }
    }

    public class Polygon
    {
        public Polygon(IEnumerable<LinearRing> rings)
        {

        }
    }
}