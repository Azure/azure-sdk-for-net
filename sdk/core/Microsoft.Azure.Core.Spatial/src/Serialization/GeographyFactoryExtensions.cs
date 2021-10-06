// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Spatial;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Core.Serialization
{
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
                throw new JsonException($"Deserialization of {nameof(GeographyLineString)} failed. {GeoJsonConstants.LineStringTypeName} must contain at least two points.");
            }

            foreach (GeographyPoint point in points)
            {
                factory = factory.LineTo(point.Latitude, point.Longitude);
            }

            GeographyLineString result = factory.Build();

            return result;
        }

        public static GeographyPolygon Create(this GeographyFactory<GeographyPolygon> factory, List<List<GeographyPoint>> listOfPointList)
        {
            foreach (List<GeographyPoint> pointList in listOfPointList)
            {
                if (pointList.Count < 4)
                {
                    throw new JsonException($"Deserialization of {nameof(GeographyPolygon)} failed. {GeoJsonConstants.PolygonTypeName} must have at least four points.");
                }

                else if (!pointList.First().Equals(pointList.Last()))
                {
                    throw new JsonException($"Deserialization of {nameof(GeographyPolygon)} failed. {GeoJsonConstants.PolygonTypeName} first and last point must be the same.");
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
                    throw new JsonException($"Deserialization of {nameof(GeographyMultiLineString)} failed. {GeoJsonConstants.MultiLineStringTypeName} must contain at least two points.");
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

        public static GeographyMultiPolygon Create(this GeographyFactory<GeographyMultiPolygon> factory, List<GeographyPolygon> polygons)
        {
            foreach (var polygon in polygons)
            {
                factory = factory.Polygon();

                foreach (GeographyLineString li in polygon.Rings)
                {
                    factory = factory.Ring(li.Points[0].Latitude, li.Points[0].Longitude);

                    for (int i = 1; i < li.Points.Count - 1; i++)
                    {
                        factory = factory.LineTo(li.Points[i].Latitude, li.Points[i].Longitude);
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
