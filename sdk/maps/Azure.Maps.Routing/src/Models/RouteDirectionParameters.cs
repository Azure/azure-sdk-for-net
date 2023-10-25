// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Routing.Models;

namespace Azure.Maps.Routing
{
    /// <summary> Post body parameters for Route directions. </summary>
    [CodeGenModel("RouteDirectionParameters")]
    public partial class RouteDirectionParameters
    {
        /// <summary> Initializes a new instance of RouteDirectionParameters. </summary>
        public RouteDirectionParameters()
        {
            AvoidVignette = new ChangeTrackingList<string>();
            AllowVignette = new ChangeTrackingList<string>();
        }

        [CodeGenMember("SupportingPoints")]
        internal GeoJsonGeometryCollection _GeoJsonSupportingPoints { get; private set; }

        private GeoCollection _SupportingPoints;
        /// <summary>
        /// A GeoJSON collection representing sequence of coordinates used as input for route reconstruction and for calculating zero or more alternative routes to this reference route.
        /// <list type="bullet">
        /// <item><description> The provided sequence of supporting points is used as input for route reconstruction. </description></item>
        /// <item><description> The alternative routes are calculated between the origin and destination points specified in the base path parameter locations. </description></item>
        /// <item><description> If both <c>MinDeviationDistance</c> and <c>MinDeviationTime</c> are set to zero, then these origin and destination points are expected to be at (or very near) the beginning and end of the reference route, respectively. </description></item>
        /// <item><description> Intermediate locations (waypoints) are not supported when using <c>SupportingPoints</c>. </description></item>
        /// <item><description> The reference route may contain traffic incidents of type _ROAD_CLOSURE_, which are ignored for the calculation of the reference route's travel time and traffic delay. </description></item>
        /// </list>
        ///  Current support type: <c>GeoPoint</c>, <c>GeoPointColletion</c>, <c>GeoPolygon</c>, <c>GeoPolygonCollection</c>, <c>GeoLineString</c>, <c>GeoLineStringCollection</c>
        ///  Please refer to <see ref="https://docs.microsoft.com/azure/azure-maps/how-to-use-best-practices-for-routing#calculate-and-bias-alternative-routes-using-supporting-points">Supporting Points</see> for details.
        /// </summary>
        /// <exception cref="ArgumentException"> Unsupported GeoCollection type when assign to <c>SupportingPoints</c>. </exception>
        public GeoCollection SupportingPoints {
            get => _SupportingPoints;
            set
            {
                _SupportingPoints = value;
                List<GeoJsonGeometry> geometries = new List<GeoJsonGeometry>();
                foreach (var supportingPoint in _SupportingPoints)
                {
                    GeoJsonGeometry geometry;
                    if (supportingPoint is GeoPoint) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoPointToGeoJsonPoint((GeoPoint)supportingPoint);
                    } else if (supportingPoint is GeoPointCollection) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoPointCollectionToGeoJsonMultiPoint((GeoPointCollection)supportingPoint);
                    } else if (supportingPoint is GeoPolygon) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoPolygonToGeoJsonPolygon((GeoPolygon)supportingPoint);
                    } else if (supportingPoint is GeoPolygonCollection) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoPolygonCollectionToGeoJsonMultiPolygon((GeoPolygonCollection)supportingPoint);
                    } else if (supportingPoint is GeoLineString) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoLineStringToGeoJsonLineString((GeoLineString)supportingPoint);
                    } else if (supportingPoint is GeoLineStringCollection) {
                        geometry = (GeoJsonGeometry)GeoJsonConverter.GeoLineStringCollectionToGeoJsonMultiLineString((GeoLineStringCollection)supportingPoint);
                    } else {
                        throw new ArgumentException("Unsupported GeoJson type.", nameof(value));
                    }
                    geometries.Add(geometry);
                }
                _GeoJsonSupportingPoints = new GeoJsonGeometryCollection(geometries);
            }
        }

        [CodeGenMember("AvoidAreas")]
        internal GeoJsonMultiPolygon _GeoJsonAvoidAreas { get; private set; }

        private GeoPolygonCollection _AvoidAreas;

        /// <summary> A GeoJSON PolygonCollection representing list of areas to avoid. Only rectangle polygons are supported. The maximum size of a rectangle is about 160x160 km. Maximum number of avoided areas is <c>10</c>. It cannot cross the 180th meridian. It must be between -80 and +80 degrees of latitude. </summary>
        public GeoPolygonCollection AvoidAreas {
            get => _AvoidAreas;
            set
            {
                _AvoidAreas = value;
                // Convert GeoPolygonCollection to GeoJsonMultiPolygon and store in AvoidAreas
                IList<IList<IList<IList<double>>>> coordinates = new List<IList<IList<IList<double>>>>();
                foreach (var avoidArea in _AvoidAreas)
                {
                    IList<IList<IList<double>>> coordArray = new List<IList<IList<double>>>();
                    foreach (var layer1 in avoidArea.Coordinates)
                    {
                        IList<IList<double>> coord = new List<IList<double>>();
                        foreach (var layer2 in layer1)
                        {
                            coord.Add(new List<double>() {layer2.Longitude, layer2.Latitude});
                        }
                        coordArray.Add(coord);
                    }
                    coordinates.Add(coordArray);
                }
                _GeoJsonAvoidAreas = new GeoJsonMultiPolygon(coordinates);
            }
        }
    }
}
