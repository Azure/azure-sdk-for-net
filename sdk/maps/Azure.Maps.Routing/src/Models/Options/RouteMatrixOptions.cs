// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Maps.Common;

namespace Azure.Maps.Routing
{
    /// <summary> Options for rendering static images. </summary>
    public class RouteMatrixOptions
    {
        /// <summary>
        /// Initializes a new <see cref="RouteMatrixOptions"/> instance for mocking.
        /// </summary>
        protected RouteMatrixOptions()
        {
        }

        /// <summary> Initializes a new <see cref="RouteMatrixOptions"/> instance. </summary>
        /// <param name="query"> The route matrix to query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> is null. </exception>
        public RouteMatrixOptions(RouteMatrixQuery query)
        {
            Argument.AssertNotNull(query, nameof(query));

            this.Query = query;
        }

        /// <summary> An object with a matrix of coordinates. </summary>
        public RouteMatrixQuery Query { get; private set; }

        /// <summary> Specifies whether to return additional travel times using different types of traffic information (none, historic, live) as well as the default best-estimate travel time. Allowed values: <c>TravelTimeType.None</c> or <c>TravelTimeType.All</c>. </summary>
        public TravelTimeType? TravelTimeType { get; set; }

        /// <summary>
        /// Specifies which of the section types is reported in the route response.
        /// For example if <c>sectionType = SectionType.Pedestrian</c> the sections which are suited for pedestrians only are returned. Multiple types can be used.
        /// The default sectionType refers to the travelMode input. By default travelMode is set to car.
        /// Allowed values: <c>SectionType.CarOrTrain</c>, <c>SectionType.Country</c>, <c>SectionType.Ferry</c>, <c>SectionType.MotorWay</c>, <c>SectionType.Pedestrian</c>, <c>SectionType.TollRoad</c>, <c>SectionType.TollVignette</c>, <c>SectionType.Traffic</c>, <c>SectionType.TravelModel</c>, <c>SectionType.Tunnel</c>, <c>SectionType.Carpool</c>, or <c>SectionType.Urban</c>
        /// </summary>
        public IList<SectionType> SectionFilter { get; } = new List<SectionType>();

        /// <summary> The date and time of arrival at the destination point. It must be specified as a dateTime. When a time zone offset is not specified it will be assumed to be that of the destination point. The arriveAt value must be in the future. The arriveAt parameter cannot be used in conjunction with DepartAt, MinDeviationDistance or MinDeviationTime. </summary>
        public DateTimeOffset? ArriveAt { get; set; }

        /// <summary> The date and time of departure from the origin point. Departure times apart from now must be specified as a dateTime. When a time zone offset is not specified, it will be assumed to be that of the origin point. The departAt value must be in the future in the date-time format (1996-12-19T16:39:57-08:00). </summary>
        public DateTimeOffset? DepartAt { get; set; }

        /// <summary> Weight per axle of the vehicle in kg. A value of 0 means that weight restrictions per axle are not considered. </summary>
        public int? VehicleAxleWeightInKilograms { get; set; }

        /// <summary> Length of the vehicle in meters. A value of 0 means that length restrictions are not considered. </summary>
        public double? VehicleLengthInMeters { get; set; }

        /// <summary> Height of the vehicle in meters. A value of 0 means that height restrictions are not considered. </summary>
        public double? VehicleHeightInMeters { get; set; }

        /// <summary> Width of the vehicle in meters. A value of 0 means that width restrictions are not considered. </summary>
        public double? VehicleWidthInMeters { get; set; }

        /// <summary>
        /// Maximum speed of the vehicle in km/hour. The max speed in the vehicle profile is used to check whether a vehicle is allowed on motorways.
        /// <list type="bullet">
        /// <item><description> A value of 0 means that an appropriate value for the vehicle will be determined and applied during route planning. </description></item>
        /// <item><description> A non-zero value may be overridden during route planning. For example, the current traffic flow is 60 km/hour. If the vehicle  maximum speed is set to 50 km/hour, the routing engine will consider 60 km/hour as this is the current situation.  If the maximum speed of the vehicle is provided as 80 km/hour but the current traffic flow is 60 km/hour, then routing engine will again use 60 km/hour. </description></item>
        /// </list>
        /// </summary>
        public int? VehicleMaxSpeedInKilometersPerHour { get; set; }

        /// <summary> Weight of the vehicle in kilograms. </summary>
        public int? VehicleWeightInKilograms { get; set; }

        /// <summary> Level of turns for thrilling route. This parameter can only be used in conjunction with `routeType`=thrilling. Allowed values: <c>WindingnessLevel.Low</c>, <c>WindingnessLevel.Normal</c>, or <c>WindingnessLevel.High</c>. </summary>
        public WindingnessLevel? Windingness { get; set; }

        /// <summary> Degree of hilliness for thrilling route. This parameter can only be used in conjunction with `routeType`=thrilling. Allowed values: <c>InclineLevel.Low</c>, <c>InclineLevel.Normal</c>, or <c>InclineLevel.High</c>. </summary>
        public InclineLevel? InclineLevel { get; set; }

        /// <summary> The mode of travel for the requested route. If not defined, default is <c>car</c>. Note that the requested travelMode may not be available for the entire route. Where the requested travelMode is not available for a particular section, the travelMode element of the response for that section will be "other". Note that travel modes bus, motorcycle, taxi and van are BETA functionality. Full restriction data is not available in all areas. In <c>CalculateReachableRange</c> requests, the values bicycle and pedestrian must not be used. Allowed values: <c>TravelModel.Car</c>, <c>TravelModel.Truck</c>, <c>TravelModel.Taxi</c>, <c>TravelModel.Bus</c>, <c>TravelModel.Van</c>, <c>TravelModel.Motorcycle</c>, <c>TravelModel.Bicycle</c>, or <c>TravelModel.Pedestrian</c>. </summary>
        public TravelMode? TravelMode { get; set; }

        /// <summary> Specifies something that the route calculation should try to avoid when determining the route. Can be specified multiple times in one request. In calculateReachableRange requests, the value alreadyUsedRoads must not be used. </summary>
        public IList<RouteAvoidType> Avoid { get; } = new List<RouteAvoidType>();

        /// <summary>
        /// Possible values:
        /// <list type="bullet">
        /// <item><description> <c>true</c> - Do consider all available traffic information during routing </description></item>
        /// <item><description> <c>false</c> - Ignore current traffic data during routing. Note that although the current traffic data is ignored </description></item>
        /// </list>
        /// During routing, the effect of historic traffic on effective road speeds is still incorporated.
        /// </summary>
        public bool? UseTrafficData { get; set; }

        /// <summary> The type of route requested. Allowed values: <c>RouteType.Fastest</c>, <c>RouteType.Shortest</c>, <c>RouteType.Economy</c>, or <c>RouteType.Thrilling</c>. </summary>
        public RouteType? RouteType { get; set; }

        /// <summary>
        /// Types of cargo that may be classified as hazardous materials and restricted from some roads. Available VehicleLoadType values are US Hazmat classes 1 through 9, plus generic classifications for use in other countries/regions. Values beginning with USHazmat are for US routing while otherHazmat should be used for all other countries/regions. VehicleLoadType can be specified multiple times. This parameter is currently only considered for <c>travelMode=truck</c>.
        /// Allowed values: <c>VehicleLoadType.USHazmatClass1</c>, <c>VehicleLoadType.USHazmatClass2</c>, <c>VehicleLoadType.USHazmatClass3</c>, <c>VehicleLoadType.USHazmatClass4</c>, <c>VehicleLoadType.USHazmatClass5</c>, <c>VehicleLoadType.USHazmatClass6</c>, <c>VehicleLoadType.USHazmatClass7</c>, <c>VehicleLoadType.USHazmatClass8</c>, <c>VehicleLoadType.USHazmatClass9</c>, <c>VehicleLoadType.OtherHazmatExplosive</c>, <c>VehicleLoadType.OtherHazmatGeneral</c>, or <c>VehicleLoadType.OtherHazmatHarmfulToWater</c>.
        /// </summary>
        public VehicleLoadType? VehicleLoadType { get; set; }
    }
}
