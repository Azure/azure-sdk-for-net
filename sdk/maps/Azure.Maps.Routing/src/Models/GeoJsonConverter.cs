// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Routing.Models
{
    internal class GeoJsonConverter
    {
        public static GeoJsonPoint GeoPointToGeoJsonPoint(GeoPoint geoPoint)
        {
            return new GeoJsonPoint(new List<double>() {
                geoPoint.Coordinates.Longitude, geoPoint.Coordinates.Latitude
            });
        }

        public static GeoJsonMultiPoint GeoPointCollectionToGeoJsonMultiPoint(GeoPointCollection geoPointCollection)
        {
            IList<IList<double>> multiPoint = new List<IList<double>>();
            foreach (var geoPoint in geoPointCollection)
            {
                multiPoint.Add(new List<double>() {
                    geoPoint.Coordinates.Longitude, geoPoint.Coordinates.Latitude
                });
            }
            return new GeoJsonMultiPoint(multiPoint);
        }

        public static GeoJsonPolygon GeoPolygonToGeoJsonPolygon(GeoPolygon geoPolygon)
        {
            IList<IList<IList<double>>> polygon = new List<IList<IList<double>>>();
            foreach (var coordinates in geoPolygon.Coordinates)
            {
                IList<IList<double>> polygonCoordinates = new List<IList<double>>();
                foreach (var coord in coordinates)
                {
                    polygonCoordinates.Add(new List<double>() {
                        coord.Longitude, coord.Latitude
                    });
                }
                polygon.Add(polygonCoordinates);
            }
            return new GeoJsonPolygon(polygon);
        }

        public static GeoJsonMultiPolygon GeoPolygonCollectionToGeoJsonMultiPolygon(GeoPolygonCollection geoPolygonCollection)
        {
            IList<IList<IList<IList<double>>>> polygons = new List<IList<IList<IList<double>>>>();
            foreach (var geoPolygon in geoPolygonCollection.Coordinates)
            {
                IList<IList<IList<double>>> polygon = new List<IList<IList<double>>>();
                foreach (var coordinates in geoPolygon)
                {
                    IList<IList<double>> polygonCoordinates = new List<IList<double>>();
                    foreach (var coord in coordinates)
                    {
                        polygonCoordinates.Add(new List<double>() {
                            coord.Longitude, coord.Latitude
                        });
                    }
                    polygon.Add(polygonCoordinates);
                }
                polygons.Add(polygon);
            }
            return new GeoJsonMultiPolygon(polygons);
        }

        public static GeoJsonLineString GeoLineStringToGeoJsonLineString(GeoLineString geoLineString)
        {
            IList<IList<double>> lineString = new List<IList<double>>();
            foreach (var coordinate in geoLineString.Coordinates)
            {
                lineString.Add(new List<double>() {
                    coordinate.Longitude, coordinate.Latitude
                });
            }
            return new GeoJsonLineString(lineString);
        }

        public static GeoJsonMultiLineString GeoLineStringCollectionToGeoJsonMultiLineString(GeoLineStringCollection geoLineStringCollection)
        {
            IList<IList<IList<double>>> multiLineString = new List<IList<IList<double>>>();
            foreach (var geoLineString in geoLineStringCollection)
            {
                IList<IList<double>> lineString = new List<IList<double>>();
                foreach (var coordinate in geoLineString.Coordinates)
                {
                    lineString.Add(new List<double>() {
                        coordinate.Longitude, coordinate.Latitude
                    });
                }
                multiLineString.Add(lineString);
            }
            return new GeoJsonMultiLineString(multiLineString);
        }
    }
}
