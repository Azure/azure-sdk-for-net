// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// A collection of extension methods for GeographyFactory.
    /// </summary>
    /// <remarks>
    /// GeographyFactory does not contain overloads for adding existing Geographies during the Build process. For example,
    /// you cannot simply add a GeographyPolygon to a GeographyMultiPolygon. Instead you must enumerate an existing
    /// GeographyPolygon's rings and add them iteratively while creating a GeographyMultiPolygon. The methods of this
    /// class properly iterate creating Geographies which are composed of other Geographies.
    /// </remarks>
    internal static class GeographyFactoryExtensions
    {
        public static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, Geography geography)
        {
            if (geography is GeographyPoint point)
            {
                factory = factory.Add(point);
            }

            else if (geography is GeographyLineString lineString)
            {
                factory = factory.Add(lineString);
            }

            else if (geography is GeographyPolygon polygon)
            {
                factory = factory.Add(polygon);
            }

            else if (geography is GeographyMultiPoint multiPoint)
            {
                factory = factory.Add(multiPoint);
            }

            else if (geography is GeographyMultiLineString multiLineString)
            {
                factory = factory.Add(multiLineString);
            }

            else if (geography is GeographyMultiPolygon multiPolygon)
            {
                factory = factory.Add(multiPolygon);
            }

            else if (geography is GeographyCollection geographyCollection)
            {
                factory = factory.Add(geographyCollection);
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyPoint point)
        {
            factory = factory.Point(point.Latitude, point.Longitude);

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyLineString lineString)
        {
            factory = factory.LineString();

            foreach (GeographyPoint point in lineString.Points)
            {
                factory = factory.LineTo(point.Latitude, point.Longitude);
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyPolygon polygon)
        {
            factory = factory.Polygon();

            foreach (GeographyLineString ring in polygon.Rings)
            {
                factory = factory.Ring(ring.Points[0].Latitude, ring.Points[0].Longitude);

                for (int i = 1; i < ring.Points.Count; i++)
                {
                    factory = factory.LineTo(ring.Points[i].Latitude, ring.Points[i].Longitude);
                }
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyMultiPoint multiPoint)
        {
            foreach (GeographyPoint point in multiPoint.Points)
            {
                factory = factory.Add(point);
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyMultiLineString multiLineString)
        {
            foreach (GeographyLineString lineString in multiLineString.LineStrings)
            {
                factory = factory.Add(lineString);
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyMultiPolygon multiPolygon)
        {
            foreach (GeographyPolygon polygon in multiPolygon.Polygons)
            {
                factory = factory.Add(polygon);
            }

            return factory;
        }

        private static GeographyFactory<GeographyCollection> Add(this GeographyFactory<GeographyCollection> factory, GeographyCollection geographyCollection)
        {
            factory = factory.Collection();

            foreach (Geography geography in geographyCollection.Geographies)
            {
                factory = factory.Add(geography);
            }

            return factory;
        }

        public static GeographyLineString Create(this GeographyFactory<GeographyLineString> factory, List<GeographyPoint> points)
        {
            if (points.Count < 2)
            {
                throw new JsonSerializationException($"Deserialization failed: GeoJson type '{GeoJsonConstants.LineStringTypeName}' must contain at least two points.");
            }

            foreach (GeographyPoint point in points)
            {
                factory = factory.LineTo(point.Latitude, point.Longitude);
            }

            GeographyLineString result = factory.Build();

            return result;
        }

        public static GeographyPolygon Create(this GeographyFactory<GeographyPolygon> factory, List<List<GeographyPoint>> points)
        {
            foreach (List<GeographyPoint> pointList in points)
            {
                if (pointList.Count < 4)
                {
                    throw new JsonSerializationException($"Deserialization failed: GeoJson type '{GeoJsonConstants.PolygonTypeName}' must contain at least four points.");
                }

                else if (!pointList.First().Equals(pointList.Last()))
                {
                    throw new JsonSerializationException($"Deserialization failed: GeoJson type '{GeoJsonConstants.PolygonTypeName}' has an invalid ring, its first and last points do not match.");
                }

                factory = factory.Ring(pointList[0].Latitude, pointList[0].Longitude);

                for (int i = 1; i < pointList.Count - 1; i++)
                {
                    factory = factory.LineTo(pointList[i].Latitude, pointList[i].Longitude);
                }
            }

            var result = factory.Build();

            return result;
        }

        public static GeographyMultiPoint Create(this GeographyFactory<GeographyMultiPoint> factory, List<GeographyPoint> points)
        {
            foreach (GeographyPoint point in points)
            {
                factory = factory.Point(point.Latitude, point.Longitude);
            }

            GeographyMultiPoint result = factory.Build();

            return result;
        }

        public static GeographyMultiLineString Create(this GeographyFactory<GeographyMultiLineString> factory, List<List<GeographyPoint>> listOfPointList)
        {
            foreach (List<GeographyPoint> points in listOfPointList)
            {
                if (points.Count < 2)
                {
                    throw new JsonSerializationException($"Deserialization failed: GeoJson type '{GeoJsonConstants.MultiLineStringTypeName}' must contain at least two points.");
                }

                factory = factory.LineString();

                foreach (GeographyPoint point in points)
                {
                    factory = factory.LineTo(point.Latitude, point.Longitude);
                }
            }

            GeographyMultiLineString result = factory.Build();

            return result;
        }

        public static GeographyMultiPolygon Create(this GeographyFactory<GeographyMultiPolygon> factory, List<List<List<GeographyPoint>>> points)
        {
            foreach (List<List<GeographyPoint>> polygon in points)
            {
                factory = factory.Polygon();

                foreach (List<GeographyPoint> ring in polygon)
                {
                    factory = factory.Ring(ring[0].Latitude, ring[0].Longitude);

                    for (int i = 1; i < ring.Count - 1; i++)
                    {
                        factory = factory.LineTo(ring[i].Latitude, ring[i].Longitude);
                    }
                }
            }

            GeographyMultiPolygon result = factory.Build();

            return result;
        }

        public static GeographyCollection Create(this GeographyFactory<GeographyCollection> factory, List<Geography> geographies)
        {
            foreach (Geography geography in geographies)
            {
                factory.Add(geography);
            }

            return factory.Build();
        }
    }
}
