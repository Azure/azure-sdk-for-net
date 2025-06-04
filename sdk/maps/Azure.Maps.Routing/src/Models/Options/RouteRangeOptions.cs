// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Maps.Common;

namespace Azure.Maps.Routing
{
    /// <summary> Options for rendering static images. </summary>
    public class RouteRangeOptions
    {
        /// <summary>
        /// Initializes a new <see cref="RouteRangeOptions"/> instance for mocking.
        /// </summary>
        protected RouteRangeOptions()
        {
        }

        /// <summary> RouteRangeOptions constructor. </summary>
        /// <param name="longitude"> The longitude for route range query coordinate. </param>
        /// <param name="latitude"> The latitude for route range query coordinate. </param>
        public RouteRangeOptions(double longitude, double latitude)
        {
            Query = new List<double>() { latitude, longitude };
        }

        /// <summary> RouteRangeOptions constructor. </summary>
        /// <param name="routeRangePoint"> A coordinate (GeoPosition) for the route range query. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="routeRangePoint"/> is null. </exception>
        public RouteRangeOptions(GeoPosition routeRangePoint)
        {
            Argument.AssertNotNull(routeRangePoint, nameof(routeRangePoint));

            Query = new List<double>() {
                routeRangePoint.Latitude,
                routeRangePoint.Longitude
            };
        }

        /// <summary> The Coordinate from which the range calculation should start. </summary>
        public IEnumerable<double> Query { get; private set; }

        /// <summary> Fuel budget in liters that determines maximal range which can be travelled using the specified Combustion Consumption Model. </summary>
        public double? FuelBudgetInLiters { get; set; }

        /// <summary> Electric energy budget in kilowatt hours (kWh) that determines maximal range which can be travelled using the specified Electric Consumption Model.&lt;br&gt; When EnergyBudgetInKilowattHours is used, it is mandatory to specify a detailed Electric Consumption Model. </summary>
        public double? EnergyBudgetInKilowattHours { get; set; }

        /// <summary> Time budget in `TimeSpan` that determines maximal range which can be travelled using driving time. The Consumption Model will only affect the range when routeType is eco. </summary>
        public TimeSpan? TimeBudget { get; set; }

        /// <summary> Distance budget in meters that determines maximal range which can be travelled using driving distance.  The Consumption Model will only affect the range when routeType is eco. </summary>
        public double? DistanceBudgetInMeters { get; set; }

        /// <summary> The date and time of departure from the origin point. Departure times apart from now must be specified as a dateTime. When a time zone offset is not specified, it will be assumed to be that of the origin point. The departAt value must be in the future in the date-time format (1996-12-19T16:39:57-08:00). </summary>
        public DateTimeOffset? DepartAt { get; set; }

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

        /// <summary> Degree of hilliness for thrilling route. This parameter can only be used in conjunction with `routeType`=thrilling. </summary>
        public InclineLevel? InclineLevel { get; set; }

        /// <summary> Level of turns for thrilling route. This parameter can only be used in conjunction with `routeType`=thrilling. </summary>
        public WindingnessLevel? Windingness { get; set; }

        /// <summary> Weight per axle of the vehicle in kg. A value of 0 means that weight restrictions per axle are not considered. </summary>
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
        /// <item><description> If no detailed Consumption Model is specified and the value of <c>vehicleWeight</c> is non-zero, then weight restrictions are considered. </description></item>
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
        /// <item><description> by linear interpolation, if the given speed lies in between two speeds in the list. </description></item>
        /// <item><description> by linear extrapolation otherwise, assuming a constant (ΔConsumption/ΔSpeed) determined by the nearest two points in the list. </description></item>
        /// </list>
        /// The list must contain between 1 and 25 points (inclusive), and may not contain duplicate points for the same speed. If it only contains a single point, then the consumption rate of that point is used without further processing.
        /// Consumption specified for the largest speed must be greater than or equal to that of the penultimate largest speed. This ensures that extrapolation does not lead to negative consumption rates.
        /// Similarly, consumption values specified for the two smallest speeds in the list cannot lead to a negative consumption rate for any smaller speed.
        /// The valid range for the consumption values(expressed in l/100km) is between 0.01 and 100000.0.
        /// Sensible Values : 50,6.3:130,11.5
        /// <c>Note</c> : This parameter is required for The Combustion Consumption Model.
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
        /// The range of values allowed are 0.0 to 1/<c>decelerationEfficiency</c>.
        /// Sensible Values : for Combustion Model : 0.33, for Electric Model : 0.66
        /// </summary>
        public double? AccelerationEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting kinetic energy to saved (not consumed) fuel when the vehicle decelerates (i.e. ChemicalEnergySaved/KineticEnergyLost). ChemicalEnergySaved_ is obtained by converting saved (not consumed) fuel to energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <see cref="AccelerationEfficiency" />.
        /// The range of values allowed are 0.0 to 1/<see cref="AccelerationEfficiency" />.
        /// Sensible Values : for Combustion Model : 0.83, for Electric Model : 0.91
        /// </summary>
        public double? DecelerationEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting chemical energy stored in fuel to potential energy when the vehicle gains elevation (i.e. PotentialEnergyGained/ChemicalEnergyConsumed). ChemicalEnergyConsumed_ is obtained by converting consumed fuel to chemical energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <see cref="DownhillEfficiency" />.
        /// The range of values allowed are 0.0 to 1/<see cref="DownhillEfficiency" />.
        /// Sensible Values : for Combustion Model : 0.27, for Electric Model : 0.74
        /// </summary>
        public double? UphillEfficiency { get; set; }

        /// <summary>
        /// Specifies the efficiency of converting potential energy to saved (not consumed) fuel when the vehicle loses elevation (i.e. ChemicalEnergySaved/PotentialEnergyLost). ChemicalEnergySaved_ is obtained by converting saved (not consumed) fuel to energy using <c>fuelEnergyDensityInMJoulesPerLiter</c>.
        /// Must be paired with <see cref="UphillEfficiency" />.
        /// The range of values allowed are 0.0 to 1/<see cref="UphillEfficiency" />.
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
        /// This parameter is required for Electric consumption model.
        /// </summary>
        public string ConstantSpeedConsumptionInKilowattHoursPerHundredKilometer { get; set; }

        /// <summary>
        /// Specifies the current electric energy supply in kilowatt hours (kWh).
        /// This parameter co-exists with <c>MaxChargeInKilowattHours</c> parameter.
        /// The range of values allowed are 0.0 to <c>MaxChargeInKilowattHours</c>.
        /// Sensible Values : 43
        /// </summary>
        public double? CurrentChargeInKilowattHours { get; set; }

        /// <summary>
        /// Specifies the maximum electric energy supply in kilowatt hours (kWh) that may be stored in the vehicle's battery.
        /// This parameter co-exists with <c>CurrentChargeInKilowattHours</c> parameter.
        /// Minimum value has to be greater than or equal to <c>CurrentChargeInKilowattHours</c>.
        /// Sensible Values : 85
        /// </summary>
        public double? MaxChargeInKilowattHours { get; set; }

        /// <summary>
        /// Specifies the amount of power consumed for sustaining auxiliary systems, in kilowatts (kW).
        /// It can be used to specify consumption due to devices and systems such as AC systems, radio, heating, etc.
        /// Sensible Values : 1.7
        /// </summary>
        public double? AuxiliaryPowerInKilowatts { get; set; }
    }
}
