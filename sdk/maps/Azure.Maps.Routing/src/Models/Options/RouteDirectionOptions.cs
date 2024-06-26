// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Maps.Routing
{
    /// <summary> Options for rendering static images. </summary>
    public class RouteDirectionOptions
    {
        /// <summary> Constructor of RouteDirectionOptions. </summary>
        public RouteDirectionOptions()
        {
        }

        /// <summary> Number of desired alternative routes to be calculated. Default: 0, minimum: 0 and maximum: 5. </summary>
        public int? MaxAlternatives { get; set; }

        /// <summary> Controls the optimality, with respect to the given planning criteria, of the calculated alternatives compared to the reference route. </summary>
        public AlternativeRouteType? AlternativeType { get; set; }

        /// <summary> All alternative routes returned will follow the reference route (see section POST Requests) from the origin point of the calculateRoute request for at least this number of meters. Can only be used when reconstructing a route. The minDeviationDistance parameter cannot be used in conjunction with arriveAt. </summary>
        public int? MinDeviationDistance { get; set; }

        /// <summary> The date and time of arrival at the destination point. It must be specified as a dateTime. When a time zone offset is not specified it will be assumed to be that of the destination point. The arriveAt value must be in the future. The arriveAt parameter cannot be used in conjunction with departAt, minDeviationDistance or minDeviationTime. </summary>
        public DateTimeOffset? ArriveAt { get; set; }

        /// <summary> The date and time of departure from the origin point. Departure times apart from now must be specified as a dateTime. When a time zone offset is not specified, it will be assumed to be that of the origin point. The departAt value must be in the future in the date-time format (1996-12-19T16:39:57-08:00). </summary>
        public DateTimeOffset? DepartAt { get; set; }

        /// <summary>
        /// All alternative routes returned will follow the reference route (see section POST Requests) from the origin point of the calculateRoute request for at least this number of seconds. Can only be used when reconstructing a route. The minDeviationTime parameter cannot be used in conjunction with arriveAt. Default value is 0. Setting )minDeviationTime_ to a value greater than zero has the following consequences:
        /// The origin point of the calculateRoute Request must be on (or very near) the input reference route.
        /// If this is not the case, an error is returned. However, the origin point does not need to be at the beginning of the input reference route (it can be thought of as the current vehicle position on the reference route).
        /// The reference route, returned as the first route in the calculateRoute response, will start at the origin point specified in the calculateRoute Request.
        /// The initial part of the input reference route up until the origin point will be excluded from the Response.
        /// The values of <c>minDeviationDistance</c> and <c>minDeviationTime</c> determine how far alternative routes will be guaranteed to follow the reference route from the origin point onwards.
        /// The route must use <c>departAt</c>.
        /// The <c>VehicleHeading</c> is ignored.
        /// </summary>
        public int? MinDeviationTime { get; set; }

        /// <summary> If specified, guidance instructions will be returned. Note that the instructionsType parameter cannot be used in conjunction with routeRepresentation=none. </summary>
        public RouteInstructionsType? InstructionsType { get; set; }

        /// <summary>
        /// The language parameter determines the language of the guidance messages. Proper nouns (the names of streets, plazas, etc.) are returned in the specified  language, or if that is not available, they are returned in an available language  that is close to it. Allowed values are (a subset of) the IETF language tags. The currently supported  languages are listed in the <see href="https://docs.microsoft.com/azure/azure-maps/supported-languages">Supported languages  section</see>.
        /// Default value: <see cref="RoutingLanguage.EnglishGreatBritain" />
        /// </summary>
        public RoutingLanguage Language { get; set; }

        /// <summary> Re-order the route waypoints using a fast heuristic algorithm to reduce the route length. Yields best results when used in conjunction with routeType _shortest_. Notice that origin and destination are excluded from the optimized waypoint indices. To include origin and destination in the response, please increase all the indices by 1 to account for the origin, and then add the destination as the final index. Possible values are true or false. True computes a better order if possible, but is not allowed to be used in conjunction with maxAlternatives value greater than 0 or in conjunction with circle waypoints. False will use the locations in the given order and not allowed to be used in conjunction with routeRepresentation _none_. </summary>
        public bool? ComputeBestWaypointOrder { get; set; }

        /// <summary> Specifies the representation of the set of routes provided as response. This parameter value can only be used in conjunction with computeBestOrder=true. </summary>
        public RouteRepresentationForBestOrder? RouteRepresentationForBestOrder { get; set; }

        /// <summary> Specifies whether to return additional travel times using different types of traffic information (none, historic, live) as well as the default best-estimate travel time. </summary>
        public TravelTimeType? TravelTimeType { get; set; }

        /// <summary> The directional heading of the vehicle in degrees starting at true North and continuing in clockwise direction. North is 0 degrees, east is 90 degrees, south is 180 degrees, west is 270 degrees. Possible values 0-359. </summary>
        public int? VehicleHeading { get; set; }

        /// <summary> Specifies which data should be reported for diagnosis purposes. If true, it will reports the effective parameters or data used when calling the API. In the case of defaulted parameters the default will be reflected where the parameter was not specified by the caller. </summary>
        public bool? ShouldReportEffectiveSettings { get; set; }

        /// <summary> Specifies which of the section types is reported in the route response. &lt;br&gt;&lt;br&gt;For example if sectionType = pedestrian the sections which are suited for pedestrians only are returned. Multiple types can be used. The default sectionType refers to the travelMode input. By default travelMode is set to car. </summary>
        public IList<SectionType> SectionFilter { get; } = new List<SectionType>();

        /// <summary> The type of route requested. </summary>
        public RouteType? RouteType { get; set; }

        /// <summary>
        /// Possible values:
        /// <list type="bullet">
        /// <item><description> <c>true</c> - Do consider all available traffic information during routing </description></item>
        /// <item><description> <c>false</c> - Ignore current traffic data during routing. Note that although the current traffic data is ignored </description></item>
        /// </list>
        /// During routing, the effect of historic traffic on effective road speeds is still incorporated.
        /// </summary>
        public bool? UseTrafficData { get; set; }

        /// <summary> Specifies something that the route calculation should try to avoid when determining the route. Can be specified multiple times in one request. In calculateReachableRange requests, the value alreadyUsedRoads must not be used. </summary>
        public IList<RouteAvoidType> Avoid { get; } = new List<RouteAvoidType>();

        /// <summary> The mode of travel for the requested route. If not defined, default is <c>car</c>. Note that the requested travelMode may not be available for the entire route. Where the requested travelMode is not available for a particular section, the travelMode element of the response for that section will be &quot;other&quot;. Note that travel modes bus, motorcycle, taxi and van are BETA functionality. Full restriction data is not available in all areas. In <c>calculateReachableRange</c> requests, the values bicycle and pedestrian must not be used. </summary>
        public TravelMode? TravelMode { get; set; }

        /// <summary> Degree of hilliness for thrilling route. This parameter can only be used in conjunction with <c>routeType.Thrilling</c>. </summary>
        public InclineLevel? InclineLevel { get; set; }

        /// <summary> Level of turns for thrilling route. This parameter can only be used in conjunction with <c>routeType.Thrilling</c>. </summary>
        public WindingnessLevel? Windingness { get; set; }

        /// <summary> Weight per axle of the vehicle in kilogram. A value of 0 means that weight restrictions per axle are not considered. </summary>
        public int? VehicleAxleWeightInKilograms { get; set; }

        /// <summary> Width of the vehicle in meters. A value of 0 means that width restrictions are not considered. </summary>
        public double? VehicleWidthInMeters { get; set; }

        /// <summary> Height of the vehicle in meters. A value of 0 means that height restrictions are not considered. </summary>
        public double? VehicleHeightInMeters { get; set; }

        /// <summary> Length of the vehicle in meters. A value of 0 means that length restrictions are not considered. </summary>
        public double? VehicleLengthInMeters { get; set; }

        /// <summary>
        /// Maximum speed of the vehicle in km/hour. The max speed in the vehicle profile is used to check whether a vehicle is allowed on motorways.
        /// <list type="bullet">
        /// <item><description> A value of 0 means that an appropriate value for the vehicle will be determined and applied during route planning. </description></item>
        /// <item><description> A non-zero value may be overridden during route planning. For example, the current traffic flow is 60 km/hour. If the vehicle  maximum speed is set to 50 km/hour, the routing engine will consider 60 km/hour as this is the current situation.  If the maximum speed of the vehicle is provided as 80 km/hour but the current traffic flow is 60 km/hour, then routing engine will again use 60 km/hour. </description></item>
        /// </list>
        /// </summary>
        public int? VehicleMaxSpeedInKilometersPerHour { get; set; }

        /// <summary>
        /// Weight of the vehicle in kilograms.
        /// <list type="bullet">
        /// <item><description> It is mandatory if any of the *Efficiency parameters are set. </description></item>
        /// <item><description> It must be strictly positive when used in the context of the Consumption Model. Weight restrictions are considered. </description></item>
        /// <item><description> If no detailed <c>Consumption Model</c> is specified and the value of <c>vehicleWeight</c> is non-zero, then weight restrictions are considered. </description></item>
        /// <item><description> In all other cases, this parameter is ignored. </description></item>
        /// </list>
        /// Sensible Values : for Combustion Model : 1600, for Electric Model : 1900
        /// </summary>
        public int? VehicleWeightInKilograms { get; set; }

        /// <summary> Whether the vehicle is used for commercial purposes. Commercial vehicles may not be allowed to drive on some roads. </summary>
        public bool? IsCommercialVehicle { get; set; }

        /// <summary> Types of cargo that may be classified as hazardous materials and restricted from some roads. Available vehicleLoadType values are US Hazmat classes 1 through 9, plus generic classifications for use in other countries/regions. Values beginning with USHazmat are for US routing while otherHazmat should be used for all other countries/regions. vehicleLoadType can be specified multiple times. This parameter is currently only considered for travelMode=truck. </summary>
        public VehicleLoadType? VehicleLoadType { get; set; }

        /// <summary> Engine type of the vehicle. When a detailed Consumption Model is specified, it must be consistent with the value of <c>vehicleEngineType</c>. </summary>
        public VehicleEngineType? VehicleEngineType { get; set; }

        /// <summary>
        /// Specifies the speed-dependent component of consumption.
        /// Provided as an unordered list of colon-delimited speed &amp; consumption-rate pairs. The list defines points on a consumption curve. Consumption rates for speeds not in the list are found as follows:
        /// <list type="bullet">
        /// <item><description> by linear interpolation, if the given speed lies in between two speeds in the list </description></item>
        /// <item><description> by linear extrapolation otherwise, assuming a constant (ΔConsumption/ΔSpeed) determined by the nearest two points in the list </description></item>
        /// </list>
        /// The list must contain between 1 and 25 points (inclusive), and may not contain duplicate points for the same speed. If it only contains a single point, then the consumption rate of that point is used without further processing.
        /// Consumption specified for the largest speed must be greater than or equal to that of the penultimate largest speed. This ensures that extrapolation does not lead to negative consumption rates.
        /// Similarly, consumption values specified for the two smallest speeds in the list cannot lead to a negative consumption rate for any smaller speed.
        /// The valid range for the consumption values(expressed in l/100km) is between 0.01 and 100000.0.
        /// Sensible Values : 50,6.3:130,11.5
        /// Note : This parameter is required for the Combustion Consumption Model
        /// </summary>
        public string ConstantSpeedConsumptionInLitersPerHundredKilometer { get; set; }

        /// <summary>
        /// Specifies the current supply of fuel in liters.
        /// Sensible Values : 55
        /// </summary>
        public double? CurrentFuelInLiters { get; set; }

        /// <summary>
        /// Specifies the amount of fuel consumed for sustaining auxiliary systems of the vehicle, in liters per hour.
        /// It can be used to specify consumption due to devices and systems such as AC systems, radio, heating, etc.
        /// Sensible Values : 0.2
        /// </summary>
        public double? AuxiliaryPowerInLitersPerHour { get; set; }

        /// <summary>
        /// Specifies the amount of chemical energy stored in one liter of fuel in megajoules (MJ). It is used in conjunction with the <c>Efficiency</c> parameters for conversions between saved or consumed energy and fuel. For example, energy density is 34.2 MJ/l for gasoline, and 35.8 MJ/l for Diesel fuel.
        /// This parameter is required if any <c>Efficiency</c> parameter is set.
        /// Sensible Values : 34.2
        /// </summary>
        public double? FuelEnergyDensityInMegajoulesPerLiter { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting chemical energy stored in fuel to kinetic energy when the vehicle accelerates (i.e. KineticEnergyGained/ChemicalEnergyConsumed). ChemicalEnergyConsumed_ is obtained by converting consumed fuel to chemical energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <c>decelerationEfficiency</c>.
        /// The range of values allowed are 0.0 to <c>1/decelerationEfficiency</c>.
        /// Sensible Values : for Combustion Model : 0.33, for Electric Model : 0.66
        /// </summary>
        public double? AccelerationEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting kinetic energy to saved (not consumed) fuel when the vehicle decelerates (i.e. ChemicalEnergySaved/KineticEnergyLost). ChemicalEnergySaved_ is obtained by converting saved (not consumed) fuel to energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <c>accelerationEfficiency</c>.
        /// The range of values allowed are 0.0 to <c>1/accelerationEfficiency</c>.
        /// Sensible Values : for Combustion Model : 0.83, for Electric Model : 0.91
        /// </summary>
        public double? DecelerationEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting chemical energy stored in fuel to potential energy when the vehicle gains elevation (i.e. PotentialEnergyGained/ChemicalEnergyConsumed). ChemicalEnergyConsumed_ is obtained by converting consumed fuel to chemical energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <c>downhillEfficiency</c>.
        /// The range of values allowed are 0.0 to 1/<c>downhillEfficiency</c>.
        /// Sensible Values : for Combustion Model : 0.27, for Electric Model : 0.74
        /// </summary>
        public double? UphillEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting potential energy to saved (not consumed) fuel when the vehicle loses elevation (i.e. ChemicalEnergySaved/PotentialEnergyLost). ChemicalEnergySaved_ is obtained by converting saved (not consumed) fuel to energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <c>uphillEfficiency</c>.
        /// The range of values allowed are 0.0 to 1/<c>uphillEfficiency</c>.
        /// Sensible Values : for Combustion Model : 0.51, for Electric Model : 0.73
        /// </summary>
        public double? DownhillEfficiency { get; set; }

        /// <summary>
        /// Specifies the speed-dependent component of consumption.
        /// Provided as an unordered list of speed/consumption-rate pairs. The list defines points on a consumption curve. Consumption rates for speeds not in the list are found as follows:
        /// <list type="bullet">
        /// <item><description> by linear interpolation, if the given speed lies in between two speeds in the list </description></item>
        /// <item><description> by linear extrapolation otherwise, assuming a constant (ΔConsumption/ΔSpeed) determined by the nearest two points in the list </description></item>
        /// </list>
        /// The list must contain between 1 and 25 points (inclusive), and may not contain duplicate points for the same speed. If it only contains a single point, then the consumption rate of that point is used without further processing.
        /// Consumption specified for the largest speed must be greater than or equal to that of the penultimate largest speed. This ensures that extrapolation does not lead to negative consumption rates.
        /// Similarly, consumption values specified for the two smallest speeds in the list cannot lead to a negative consumption rate for any smaller  speed.
        /// The valid range for the consumption values(expressed in kWh/100km) is between 0.01 and 100000.0.
        /// Sensible Values : 50,8.2:130,21.3
        /// This parameter is required for <c>Electric consumption model</c>.
        /// </summary>
        public string ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer { get; set; }

        /// <summary>
        /// Specifies the current electric energy supply in kilowatt hours (kWh).
        /// This parameter co-exists with <c>MaxChargeInKilowattHour</c> parameter.
        /// The range of values allowed are 0.0 to <c>MaxChargeInKilowattHour</c>.
        /// Sensible Values : 43
        /// </summary>
        public double? CurrentChargeInKilowattHours { get; set; }

        /// <summary>
        /// Specifies the maximum electric energy supply in kilowatt hours (kWh) that may be stored in the vehicle's battery.
        /// This parameter co-exists with <c>currentChargeInkilowattHour</c> parameter.
        /// Minimum value has to be greater than or equal to <c>currentChargeInkilowattHour</c>.
        /// Sensible Values : 85
        /// </summary>
        public double? MaxChargeInKilowattHours { get; set; }

        /// <summary>
        /// Specifies the amount of power consumed for sustaining auxiliary systems, in kilowatts (kW).
        /// It can be used to specify consumption due to devices and systems such as AC systems, radio, heating, etc.
        /// Sensible Values : 1.7
        /// </summary>
        public double? AuxiliaryPowerInKilowatts { get; set; }

        /// <summary>
        /// Used for reconstructing a route and for calculating zero or more alternative routes to this reference route.  The provided sequence of coordinates is used as input for route reconstruction. The alternative routes  are calculated between the origin and destination points specified in the base path parameter locations.  If both minDeviationDistance and minDeviationTime are set to zero, then these origin and destination points  are expected to be at (or very near) the beginning and end of the reference route, respectively. Intermediate  locations (waypoints) are not supported when using supportingPoints.
        /// Setting at least one of minDeviationDistance or minDeviationTime to a value greater than zero has the  following consequences:
        /// <list type="bullet">
        /// <item><description> The origin point of the calculateRoute request must be on (or very near) the input reference route. If  this is not the case, an error is returned. However, the origin point does not need to be at the beginning of  the input reference route (it can be thought of as the current vehicle position on the reference route). </description></item>
        /// <item><description> The reference route, returned as the first route in the calculateRoute response, will start at the origin  point specified in the calculateRoute request. The initial part of the input reference route up until the  origin point will be excluded from the response. </description></item>
        /// <item><description> The values of minDeviationDistance and minDeviationTime determine how far alternative routes will be  guaranteed to follow the reference route from the origin point onwards. </description></item>
        /// <item><description> The route must use departAt. </description></item>
        /// <item><description> The vehicleHeading is ignored. </description></item>
        /// </list>
        /// </summary>
        public RouteDirectionParameters RouteDirectionParameters { get; set; }
    }
}
