namespace Azure.Maps.Routing
{
    public partial class MapsRouteClientOptions : Azure.Core.ClientOptions
    {
        public MapsRouteClientOptions(Azure.Maps.Routing.MapsRouteClientOptions.ServiceVersion version = Azure.Maps.Routing.MapsRouteClientOptions.ServiceVersion.V1_0, System.Uri endpoint = null) { }
        public enum ServiceVersion
        {
            V1_0 = 1,
        }
    }
    public partial class MapsRoutingClient
    {
        protected MapsRoutingClient() { }
        public MapsRoutingClient(Azure.AzureKeyCredential credential) { }
        public MapsRoutingClient(Azure.AzureKeyCredential credential, Azure.Maps.Routing.MapsRouteClientOptions options) { }
        public MapsRoutingClient(Azure.Core.TokenCredential credential, string clientId) { }
        public MapsRoutingClient(Azure.Core.TokenCredential credential, string clientId, Azure.Maps.Routing.MapsRouteClientOptions options) { }
        public virtual Azure.Response<Azure.Maps.Routing.Models.RouteDirections> GetDirections(Azure.Maps.Routing.Models.RouteDirectionQuery routeDirectionQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Routing.Models.RouteDirections>> GetDirectionsAsync(Azure.Maps.Routing.Models.RouteDirectionQuery routeDirectionQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Routing.Models.RouteRangeResult> GetRouteRange(Azure.Maps.Routing.Models.RouteRangeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Routing.Models.RouteRangeResult>> GetRouteRangeAsync(Azure.Maps.Routing.Models.RouteRangeOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Maps.Routing.Models.RequestRouteDirectionsOperation RequestRouteDirectionsBatch(Azure.WaitUntil waitUntil, System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteDirectionQuery> routeDirectionsQueries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Maps.Routing.Models.RequestRouteDirectionsOperation> RequestRouteDirectionsBatchAsync(Azure.WaitUntil waitUntil, System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteDirectionQuery> routeDirectionsQueries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Maps.Routing.Models.RequestRouteMatrixOperation RequestRouteMatrix(Azure.WaitUntil waitUntil, Azure.Maps.Routing.Models.RouteMatrixOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Maps.Routing.Models.RequestRouteMatrixOperation> RequestRouteMatrixAsync(Azure.WaitUntil waitUntil, Azure.Maps.Routing.Models.RouteMatrixOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult> SyncRequestRouteDirectionsBatch(System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteDirectionQuery> routeDirectionQueries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult>> SyncRequestRouteDirectionsBatchAsync(System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteDirectionQuery> routeDirectionQueries, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult> SyncRequestRouteMatrix(Azure.Maps.Routing.Models.RouteMatrixOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult> SyncRequestRouteMatrix(Azure.Maps.Routing.Models.RouteMatrixQuery routeMatrixQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult>> SyncRequestRouteMatrixAsync(Azure.Maps.Routing.Models.RouteMatrixOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult>> SyncRequestRouteMatrixAsync(Azure.Maps.Routing.Models.RouteMatrixQuery routeMatrixQuery, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Maps.Routing.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlternativeRouteType : System.IEquatable<Azure.Maps.Routing.Models.AlternativeRouteType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlternativeRouteType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.AlternativeRouteType AnyRoute { get { throw null; } }
        public static Azure.Maps.Routing.Models.AlternativeRouteType BetterRoute { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.AlternativeRouteType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.AlternativeRouteType left, Azure.Maps.Routing.Models.AlternativeRouteType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.AlternativeRouteType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.AlternativeRouteType left, Azure.Maps.Routing.Models.AlternativeRouteType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BatchResult
    {
        internal BatchResult() { }
        public int? SuccessfulRequests { get { throw null; } }
        public int? TotalRequests { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DelayMagnitude : System.IEquatable<Azure.Maps.Routing.Models.DelayMagnitude>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DelayMagnitude(string value) { throw null; }
        public static Azure.Maps.Routing.Models.DelayMagnitude Major { get { throw null; } }
        public static Azure.Maps.Routing.Models.DelayMagnitude Minor { get { throw null; } }
        public static Azure.Maps.Routing.Models.DelayMagnitude Moderate { get { throw null; } }
        public static Azure.Maps.Routing.Models.DelayMagnitude Undefined { get { throw null; } }
        public static Azure.Maps.Routing.Models.DelayMagnitude Unknown { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.DelayMagnitude other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.DelayMagnitude left, Azure.Maps.Routing.Models.DelayMagnitude right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.DelayMagnitude (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.DelayMagnitude left, Azure.Maps.Routing.Models.DelayMagnitude right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DrivingSide : System.IEquatable<Azure.Maps.Routing.Models.DrivingSide>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DrivingSide(string value) { throw null; }
        public static Azure.Maps.Routing.Models.DrivingSide Left { get { throw null; } }
        public static Azure.Maps.Routing.Models.DrivingSide Right { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.DrivingSide other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.DrivingSide left, Azure.Maps.Routing.Models.DrivingSide right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.DrivingSide (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.DrivingSide left, Azure.Maps.Routing.Models.DrivingSide right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EffectiveSetting
    {
        internal EffectiveSetting() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuidanceInstructionType : System.IEquatable<Azure.Maps.Routing.Models.GuidanceInstructionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuidanceInstructionType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType DirectionInfo { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType LocationArrival { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType LocationDeparture { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType LocationWaypoint { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType RoadChange { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceInstructionType Turn { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.GuidanceInstructionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.GuidanceInstructionType left, Azure.Maps.Routing.Models.GuidanceInstructionType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.GuidanceInstructionType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.GuidanceInstructionType left, Azure.Maps.Routing.Models.GuidanceInstructionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GuidanceManeuver : System.IEquatable<Azure.Maps.Routing.Models.GuidanceManeuver>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GuidanceManeuver(string value) { throw null; }
        public static Azure.Maps.Routing.Models.GuidanceManeuver Arrive { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver ArriveLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver ArriveRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver BearLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver BearRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver Depart { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver EnterFreeway { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver EnterHighway { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver EnterMotorway { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver EntranceRamp { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver Follow { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver KeepLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver KeepRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver MakeUTurn { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver MotorwayExitLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver MotorwayExitRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver RoundaboutBack { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver RoundaboutCross { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver RoundaboutLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver RoundaboutRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver SharpLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver SharpRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver Straight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver SwitchMainRoad { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver SwitchParallelRoad { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver TakeExit { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver TakeFerry { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver TryMakeUTurn { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver TurnLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver TurnRight { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver WaypointLeft { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver WaypointReached { get { throw null; } }
        public static Azure.Maps.Routing.Models.GuidanceManeuver WaypointRight { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.GuidanceManeuver other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.GuidanceManeuver left, Azure.Maps.Routing.Models.GuidanceManeuver right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.GuidanceManeuver (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.GuidanceManeuver left, Azure.Maps.Routing.Models.GuidanceManeuver right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InclineLevel : System.IEquatable<Azure.Maps.Routing.Models.InclineLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InclineLevel(string value) { throw null; }
        public static Azure.Maps.Routing.Models.InclineLevel High { get { throw null; } }
        public static Azure.Maps.Routing.Models.InclineLevel Low { get { throw null; } }
        public static Azure.Maps.Routing.Models.InclineLevel Normal { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.InclineLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.InclineLevel left, Azure.Maps.Routing.Models.InclineLevel right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.InclineLevel (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.InclineLevel left, Azure.Maps.Routing.Models.InclineLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JunctionType : System.IEquatable<Azure.Maps.Routing.Models.JunctionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JunctionType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.JunctionType Bifurcation { get { throw null; } }
        public static Azure.Maps.Routing.Models.JunctionType Regular { get { throw null; } }
        public static Azure.Maps.Routing.Models.JunctionType Roundabout { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.JunctionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.JunctionType left, Azure.Maps.Routing.Models.JunctionType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.JunctionType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.JunctionType left, Azure.Maps.Routing.Models.JunctionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequestRouteDirectionsOperation : Azure.Operation<Azure.Maps.Routing.Models.RouteDirectionsBatchResult>
    {
        protected RequestRouteDirectionsOperation() { }
        public RequestRouteDirectionsOperation(Azure.Maps.Routing.MapsRoutingClient client, string id) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Maps.Routing.Models.RouteDirectionsBatchResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Routing.Models.RouteDirectionsBatchResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class RequestRouteMatrixOperation : Azure.Operation<Azure.Maps.Routing.Models.RouteMatrixResult>
    {
        protected RequestRouteMatrixOperation() { }
        public RequestRouteMatrixOperation(Azure.Maps.Routing.MapsRoutingClient client, string id) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Maps.Routing.Models.RouteMatrixResult Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult> WaitForCompletion(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult> WaitForCompletion(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Maps.Routing.Models.RouteMatrixResult>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseSectionType : System.IEquatable<Azure.Maps.Routing.Models.ResponseSectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseSectionType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.ResponseSectionType CarOrTrain { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Carpool { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Country { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Ferry { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Motorway { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Pedestrian { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType TollRoad { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType TollVignette { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Traffic { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType TravelMode { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Tunnel { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseSectionType Urban { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.ResponseSectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.ResponseSectionType left, Azure.Maps.Routing.Models.ResponseSectionType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.ResponseSectionType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.ResponseSectionType left, Azure.Maps.Routing.Models.ResponseSectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseTravelMode : System.IEquatable<Azure.Maps.Routing.Models.ResponseTravelMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseTravelMode(string value) { throw null; }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Bicycle { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Bus { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Car { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Motorcycle { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Other { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Pedestrian { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Taxi { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Truck { get { throw null; } }
        public static Azure.Maps.Routing.Models.ResponseTravelMode Van { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.ResponseTravelMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.ResponseTravelMode left, Azure.Maps.Routing.Models.ResponseTravelMode right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.ResponseTravelMode (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.ResponseTravelMode left, Azure.Maps.Routing.Models.ResponseTravelMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteAvoidType : System.IEquatable<Azure.Maps.Routing.Models.RouteAvoidType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteAvoidType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.RouteAvoidType AlreadyUsedRoads { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType BorderCrossings { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType Carpools { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType Ferries { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType Motorways { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType TollRoads { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteAvoidType UnpavedRoads { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.RouteAvoidType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.RouteAvoidType left, Azure.Maps.Routing.Models.RouteAvoidType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.RouteAvoidType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.RouteAvoidType left, Azure.Maps.Routing.Models.RouteAvoidType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouteData
    {
        internal RouteData() { }
        public Azure.Maps.Routing.Models.RouteGuidance Guidance { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteLeg> Legs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteSection> Sections { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteSummary Summary { get { throw null; } }
    }
    public partial class RouteDirectionOptions
    {
        public RouteDirectionOptions() { }
        public double? AccelerationEfficiency { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.AlternativeRouteType? AlternativeType { get { throw null; } set { } }
        public System.DateTimeOffset? ArriveAt { get { throw null; } set { } }
        public double? AuxiliaryPowerInKw { get { throw null; } set { } }
        public double? AuxiliaryPowerInLitersPerHour { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteAvoidType> Avoid { get { throw null; } }
        public bool? ComputeBestWaypointOrder { get { throw null; } set { } }
        public string ConstantSpeedConsumptionInKwHPerHundredKm { get { throw null; } set { } }
        public string ConstantSpeedConsumptionInLitersPerHundredKm { get { throw null; } set { } }
        public double? CurrentChargeInKwH { get { throw null; } set { } }
        public double? CurrentFuelInLiters { get { throw null; } set { } }
        public double? DecelerationEfficiency { get { throw null; } set { } }
        public System.DateTimeOffset? DepartAt { get { throw null; } set { } }
        public double? DownhillEfficiency { get { throw null; } set { } }
        public double? FuelEnergyDensityInMegajoulesPerLiter { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.InclineLevel? InclineLevel { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.RouteInstructionsType? InstructionsType { get { throw null; } set { } }
        public bool? IsCommercialVehicle { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public int? MaxAlternatives { get { throw null; } set { } }
        public double? MaxChargeInKwH { get { throw null; } set { } }
        public int? MinDeviationDistance { get { throw null; } set { } }
        public int? MinDeviationTime { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.RouteDirectionParameters RouteDirectionParameters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.RouteRepresentationForBestOrder? RouteRepresentationForBestOrder { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.RouteType? RouteType { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.SectionType? SectionFilter { get { throw null; } set { } }
        public bool? ShouldReportEffectiveSettings { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.TravelMode? TravelMode { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.TravelTimeType? TravelTimeType { get { throw null; } set { } }
        public double? UphillEfficiency { get { throw null; } set { } }
        public bool? UseTrafficData { get { throw null; } set { } }
        public int? VehicleAxleWeightInKilograms { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.VehicleEngineType? VehicleEngineType { get { throw null; } set { } }
        public int? VehicleHeading { get { throw null; } set { } }
        public double? VehicleHeightInMeters { get { throw null; } set { } }
        public double? VehicleLengthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.VehicleLoadType? VehicleLoadType { get { throw null; } set { } }
        public int? VehicleMaxSpeedInKmPerHour { get { throw null; } set { } }
        public int? VehicleWeightInKilograms { get { throw null; } set { } }
        public double? VehicleWidthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.WindingnessLevel? Windingness { get { throw null; } set { } }
    }
    public partial class RouteDirectionParameters
    {
        public RouteDirectionParameters() { }
        public System.Collections.Generic.IList<string> AllowVignette { get { throw null; } }
        public Azure.Core.GeoJson.GeoPolygonCollection AvoidAreas { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AvoidVignette { get { throw null; } }
        public Azure.Core.GeoJson.GeoCollection SupportingPoints { get { throw null; } set { } }
    }
    public partial class RouteDirectionQuery
    {
        protected RouteDirectionQuery() { }
        public RouteDirectionQuery(System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> routePoints, Azure.Maps.Routing.Models.RouteDirectionOptions options = null) { }
        public Azure.Maps.Routing.Models.RouteDirectionOptions RouteDirectionOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> RoutePoints { get { throw null; } }
    }
    public partial class RouteDirections
    {
        internal RouteDirections() { }
        public string FormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteOptimizedWaypoint> OptimizedWaypoints { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteReport Report { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteData> Routes { get { throw null; } }
    }
    public partial class RouteDirectionsBatchItemResponse : Azure.Maps.Routing.Models.RouteDirections
    {
        internal RouteDirectionsBatchItemResponse() { }
        public Azure.ResponseError ResponseError { get { throw null; } }
    }
    public partial class RouteDirectionsBatchResult : Azure.Maps.Routing.Models.BatchResult
    {
        internal RouteDirectionsBatchResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteDirectionsBatchItemResponse> Results { get { throw null; } }
    }
    public partial class RouteGuidance
    {
        internal RouteGuidance() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteInstructionGroup> InstructionGroups { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteInstruction> Instructions { get { throw null; } }
    }
    public partial class RouteInstruction
    {
        internal RouteInstruction() { }
        public string CombinedMessage { get { throw null; } }
        public string CountryCode { get { throw null; } }
        public Azure.Maps.Routing.Models.DrivingSide? DrivingSide { get { throw null; } }
        public string ExitNumber { get { throw null; } }
        public Azure.Maps.Routing.Models.GuidanceInstructionType? InstructionType { get { throw null; } }
        public Azure.Maps.Routing.Models.JunctionType? JunctionType { get { throw null; } }
        public Azure.Maps.Routing.Models.GuidanceManeuver? Maneuver { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition Point { get { throw null; } }
        public int? PointIndex { get { throw null; } }
        public bool? PossibleCombineWithNext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RoadNumbers { get { throw null; } }
        public string RoundaboutExitNumber { get { throw null; } }
        public int? RouteOffsetInMeters { get { throw null; } }
        public string SignpostText { get { throw null; } }
        public string StateCode { get { throw null; } }
        public string Street { get { throw null; } }
        public int? TravelTimeInSeconds { get { throw null; } }
        public int? TurnAngleInDegrees { get { throw null; } }
    }
    public partial class RouteInstructionGroup
    {
        internal RouteInstructionGroup() { }
        public int? FirstInstructionIndex { get { throw null; } }
        public int? GroupLengthInMeters { get { throw null; } }
        public string GroupMessage { get { throw null; } }
        public int? LastInstructionIndex { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteInstructionsType : System.IEquatable<Azure.Maps.Routing.Models.RouteInstructionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteInstructionsType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.RouteInstructionsType Coded { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteInstructionsType Tagged { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteInstructionsType Text { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.RouteInstructionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.RouteInstructionsType left, Azure.Maps.Routing.Models.RouteInstructionsType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.RouteInstructionsType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.RouteInstructionsType left, Azure.Maps.Routing.Models.RouteInstructionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouteLeg
    {
        internal RouteLeg() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPosition> Points { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteLegSummary Summary { get { throw null; } }
    }
    public partial class RouteLegSummary
    {
        internal RouteLegSummary() { }
        public System.DateTimeOffset? ArrivalTime { get { throw null; } }
        public double? BatteryConsumptionInKwH { get { throw null; } }
        public System.DateTimeOffset? DepartureTime { get { throw null; } }
        public double? FuelConsumptionInLiters { get { throw null; } }
        public int? HistoricTrafficTravelTimeInSeconds { get { throw null; } }
        public int? LengthInMeters { get { throw null; } }
        public int? LiveTrafficIncidentsTravelTimeInSeconds { get { throw null; } }
        public int? NoTrafficTravelTimeInSeconds { get { throw null; } }
        public int? TrafficDelayInSeconds { get { throw null; } }
        public int? TravelTimeInSeconds { get { throw null; } }
    }
    public partial class RouteMatrix
    {
        internal RouteMatrix() { }
        public int? StatusCode { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteLegSummary Summary { get { throw null; } }
    }
    public partial class RouteMatrixOptions
    {
        protected RouteMatrixOptions() { }
        public RouteMatrixOptions(Azure.Maps.Routing.Models.RouteMatrixQuery query) { }
        public System.DateTimeOffset? ArriveAt { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteAvoidType> Avoid { get { throw null; } }
        public System.DateTimeOffset? DepartAt { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.InclineLevel? InclineLevel { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.RouteMatrixQuery Query { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteType? RouteType { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.SectionType? SectionFilter { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.TravelMode? TravelMode { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.TravelTimeType? TravelTimeType { get { throw null; } set { } }
        public bool? UseTrafficData { get { throw null; } set { } }
        public int? VehicleAxleWeightInKilograms { get { throw null; } set { } }
        public double? VehicleHeightInMeters { get { throw null; } set { } }
        public double? VehicleLengthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.VehicleLoadType? VehicleLoadType { get { throw null; } set { } }
        public int? VehicleMaxSpeedInKmPerHour { get { throw null; } set { } }
        public int? VehicleWeightInKilograms { get { throw null; } set { } }
        public double? VehicleWidthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.WindingnessLevel? Windingness { get { throw null; } set { } }
    }
    public partial class RouteMatrixQuery
    {
        public RouteMatrixQuery() { }
        public System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> Destinations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.GeoJson.GeoPosition> Origins { get { throw null; } set { } }
    }
    public partial class RouteMatrixResult
    {
        internal RouteMatrixResult() { }
        public string FormatVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteMatrix>> Matrix { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteMatrixSummary Summary { get { throw null; } }
    }
    public partial class RouteMatrixSummary
    {
        internal RouteMatrixSummary() { }
        public int? SuccessfulRoutes { get { throw null; } }
        public int? TotalRoutes { get { throw null; } }
    }
    public static partial class RouteModelFactory
    {
        public static Azure.Maps.Routing.Models.EffectiveSetting EffectiveSetting(string key = null, string value = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteData RouteData(Azure.Maps.Routing.Models.RouteSummary summary = null, System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteLeg> legs = null, System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteSection> sections = null, Azure.Maps.Routing.Models.RouteGuidance guidance = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteDirections RouteDirections(string formatVersion = null, System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteData> routes = null, System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteOptimizedWaypoint> optimizedWaypoints = null, Azure.Maps.Routing.Models.RouteReport report = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteGuidance RouteGuidance(System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteInstruction> instructions = null, System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteInstructionGroup> instructionGroups = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteInstructionGroup RouteInstructionGroup(int? firstInstructionIndex = default(int?), int? lastInstructionIndex = default(int?), int? groupLengthInMeters = default(int?), string groupMessage = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteLegSummary RouteLegSummary(int? lengthInMeters = default(int?), int? travelTimeInSeconds = default(int?), int? trafficDelayInSeconds = default(int?), System.DateTimeOffset? departureTime = default(System.DateTimeOffset?), System.DateTimeOffset? arrivalTime = default(System.DateTimeOffset?), int? noTrafficTravelTimeInSeconds = default(int?), int? historicTrafficTravelTimeInSeconds = default(int?), int? liveTrafficIncidentsTravelTimeInSeconds = default(int?), double? fuelConsumptionInLiters = default(double?), double? batteryConsumptionInKwH = default(double?)) { throw null; }
        public static Azure.Maps.Routing.Models.RouteMatrixResult RouteMatrixResult(string formatVersion = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteMatrix>> matrix = null, Azure.Maps.Routing.Models.RouteMatrixSummary summary = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteMatrixSummary RouteMatrixSummary(int? successfulRoutes = default(int?), int? totalRoutes = default(int?)) { throw null; }
        public static Azure.Maps.Routing.Models.RouteOptimizedWaypoint RouteOptimizedWaypoint(int? providedIndex = default(int?), int? optimizedIndex = default(int?)) { throw null; }
        public static Azure.Maps.Routing.Models.RouteRangeResult RouteRangeResult(string formatVersion = null, Azure.Maps.Routing.Models.RouteRange reachableRange = null, Azure.Maps.Routing.Models.RouteReport report = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteReport RouteReport(System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.EffectiveSetting> effectiveSettings = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteSection RouteSection(int? startPointIndex = default(int?), int? endPointIndex = default(int?), Azure.Maps.Routing.Models.ResponseSectionType? sectionType = default(Azure.Maps.Routing.Models.ResponseSectionType?), Azure.Maps.Routing.Models.ResponseTravelMode? travelMode = default(Azure.Maps.Routing.Models.ResponseTravelMode?), Azure.Maps.Routing.Models.TrafficIncidentCategory? simpleCategory = default(Azure.Maps.Routing.Models.TrafficIncidentCategory?), int? effectiveSpeedInKmh = default(int?), int? delayInSeconds = default(int?), Azure.Maps.Routing.Models.DelayMagnitude? delayMagnitude = default(Azure.Maps.Routing.Models.DelayMagnitude?), Azure.Maps.Routing.Models.RouteSectionTec tec = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteSectionTec RouteSectionTec(int? effectCode = default(int?), System.Collections.Generic.IEnumerable<Azure.Maps.Routing.Models.RouteSectionTecCause> causes = null) { throw null; }
        public static Azure.Maps.Routing.Models.RouteSectionTecCause RouteSectionTecCause(int? mainCauseCode = default(int?), int? subCauseCode = default(int?)) { throw null; }
    }
    public partial class RouteOptimizedWaypoint
    {
        internal RouteOptimizedWaypoint() { }
        public int? OptimizedIndex { get { throw null; } }
        public int? ProvidedIndex { get { throw null; } }
    }
    public partial class RouteRange
    {
        internal RouteRange() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.GeoJson.GeoPosition> Boundary { get { throw null; } }
        public Azure.Core.GeoJson.GeoPosition Center { get { throw null; } }
    }
    public partial class RouteRangeOptions
    {
        protected RouteRangeOptions() { }
        public RouteRangeOptions(Azure.Core.GeoJson.GeoPosition routeRangePoint) { }
        public RouteRangeOptions(double longitude, double latitude) { }
        public double? AccelerationEfficiency { get { throw null; } set { } }
        public double? AuxiliaryPowerInKw { get { throw null; } set { } }
        public double? AuxiliaryPowerInLitersPerHour { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Maps.Routing.Models.RouteAvoidType> Avoid { get { throw null; } }
        public string ConstantSpeedConsumptionInKwHPerHundredKm { get { throw null; } set { } }
        public string ConstantSpeedConsumptionInLitersPerHundredKm { get { throw null; } set { } }
        public double? CurrentChargeInKwH { get { throw null; } set { } }
        public double? CurrentFuelInLiters { get { throw null; } set { } }
        public double? DecelerationEfficiency { get { throw null; } set { } }
        public System.DateTimeOffset? DepartAt { get { throw null; } set { } }
        public double? DistanceBudgetInMeters { get { throw null; } set { } }
        public double? DownhillEfficiency { get { throw null; } set { } }
        public double? EnergyBudgetInKwH { get { throw null; } set { } }
        public double? FuelBudgetInLiters { get { throw null; } set { } }
        public double? FuelEnergyDensityInMegajoulesPerLiter { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.InclineLevel? InclineLevel { get { throw null; } set { } }
        public bool? IsCommercialVehicle { get { throw null; } set { } }
        public double? MaxChargeInKwH { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<double> Query { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteType? RouteType { get { throw null; } set { } }
        public System.TimeSpan? TimeBudget { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.TravelMode? TravelMode { get { throw null; } set { } }
        public double? UphillEfficiency { get { throw null; } set { } }
        public bool? UseTrafficData { get { throw null; } set { } }
        public int? VehicleAxleWeightInKilograms { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.VehicleEngineType? VehicleEngineType { get { throw null; } set { } }
        public double? VehicleHeightInMeters { get { throw null; } set { } }
        public double? VehicleLengthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.VehicleLoadType? VehicleLoadType { get { throw null; } set { } }
        public int? VehicleMaxSpeedInKmPerHour { get { throw null; } set { } }
        public int? VehicleWeightInKilograms { get { throw null; } set { } }
        public double? VehicleWidthInMeters { get { throw null; } set { } }
        public Azure.Maps.Routing.Models.WindingnessLevel? Windingness { get { throw null; } set { } }
    }
    public partial class RouteRangeResult
    {
        internal RouteRangeResult() { }
        public string FormatVersion { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteRange ReachableRange { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteReport Report { get { throw null; } }
    }
    public partial class RouteReport
    {
        internal RouteReport() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.EffectiveSetting> EffectiveSettings { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteRepresentationForBestOrder : System.IEquatable<Azure.Maps.Routing.Models.RouteRepresentationForBestOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteRepresentationForBestOrder(string value) { throw null; }
        public static Azure.Maps.Routing.Models.RouteRepresentationForBestOrder None { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteRepresentationForBestOrder Polyline { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteRepresentationForBestOrder SummaryOnly { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.RouteRepresentationForBestOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.RouteRepresentationForBestOrder left, Azure.Maps.Routing.Models.RouteRepresentationForBestOrder right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.RouteRepresentationForBestOrder (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.RouteRepresentationForBestOrder left, Azure.Maps.Routing.Models.RouteRepresentationForBestOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouteSection
    {
        internal RouteSection() { }
        public int? DelayInSeconds { get { throw null; } }
        public Azure.Maps.Routing.Models.DelayMagnitude? DelayMagnitude { get { throw null; } }
        public int? EffectiveSpeedInKmh { get { throw null; } }
        public int? EndPointIndex { get { throw null; } }
        public Azure.Maps.Routing.Models.ResponseSectionType? SectionType { get { throw null; } }
        public Azure.Maps.Routing.Models.TrafficIncidentCategory? SimpleCategory { get { throw null; } }
        public int? StartPointIndex { get { throw null; } }
        public Azure.Maps.Routing.Models.RouteSectionTec Tec { get { throw null; } }
        public Azure.Maps.Routing.Models.ResponseTravelMode? TravelMode { get { throw null; } }
    }
    public partial class RouteSectionTec
    {
        internal RouteSectionTec() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Maps.Routing.Models.RouteSectionTecCause> Causes { get { throw null; } }
        public int? EffectCode { get { throw null; } }
    }
    public partial class RouteSectionTecCause
    {
        internal RouteSectionTecCause() { }
        public int? MainCauseCode { get { throw null; } }
        public int? SubCauseCode { get { throw null; } }
    }
    public partial class RouteSummary
    {
        internal RouteSummary() { }
        public System.DateTimeOffset? ArrivalTime { get { throw null; } }
        public System.DateTimeOffset? DepartureTime { get { throw null; } }
        public int? LengthInMeters { get { throw null; } }
        public System.TimeSpan? TravelTimeDuration { get { throw null; } }
        public int? TravelTimeInSeconds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouteType : System.IEquatable<Azure.Maps.Routing.Models.RouteType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouteType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.RouteType Economy { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteType Fastest { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteType Shortest { get { throw null; } }
        public static Azure.Maps.Routing.Models.RouteType Thrilling { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.RouteType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.RouteType left, Azure.Maps.Routing.Models.RouteType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.RouteType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.RouteType left, Azure.Maps.Routing.Models.RouteType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SectionType : System.IEquatable<Azure.Maps.Routing.Models.SectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SectionType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.SectionType CarOrTrain { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Carpool { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Country { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Ferry { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Motorway { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Pedestrian { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType TollRoad { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType TollVignette { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Traffic { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType TravelMode { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Tunnel { get { throw null; } }
        public static Azure.Maps.Routing.Models.SectionType Urban { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.SectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.SectionType left, Azure.Maps.Routing.Models.SectionType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.SectionType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.SectionType left, Azure.Maps.Routing.Models.SectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficIncidentCategory : System.IEquatable<Azure.Maps.Routing.Models.TrafficIncidentCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficIncidentCategory(string value) { throw null; }
        public static Azure.Maps.Routing.Models.TrafficIncidentCategory Jam { get { throw null; } }
        public static Azure.Maps.Routing.Models.TrafficIncidentCategory Other { get { throw null; } }
        public static Azure.Maps.Routing.Models.TrafficIncidentCategory RoadClosure { get { throw null; } }
        public static Azure.Maps.Routing.Models.TrafficIncidentCategory RoadWork { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.TrafficIncidentCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.TrafficIncidentCategory left, Azure.Maps.Routing.Models.TrafficIncidentCategory right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.TrafficIncidentCategory (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.TrafficIncidentCategory left, Azure.Maps.Routing.Models.TrafficIncidentCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TravelMode : System.IEquatable<Azure.Maps.Routing.Models.TravelMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TravelMode(string value) { throw null; }
        public static Azure.Maps.Routing.Models.TravelMode Bicycle { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Bus { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Car { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Motorcycle { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Pedestrian { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Taxi { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Truck { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelMode Van { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.TravelMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.TravelMode left, Azure.Maps.Routing.Models.TravelMode right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.TravelMode (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.TravelMode left, Azure.Maps.Routing.Models.TravelMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TravelTimeType : System.IEquatable<Azure.Maps.Routing.Models.TravelTimeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TravelTimeType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.TravelTimeType All { get { throw null; } }
        public static Azure.Maps.Routing.Models.TravelTimeType None { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.TravelTimeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.TravelTimeType left, Azure.Maps.Routing.Models.TravelTimeType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.TravelTimeType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.TravelTimeType left, Azure.Maps.Routing.Models.TravelTimeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VehicleEngineType : System.IEquatable<Azure.Maps.Routing.Models.VehicleEngineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VehicleEngineType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.VehicleEngineType Combustion { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleEngineType Electric { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.VehicleEngineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.VehicleEngineType left, Azure.Maps.Routing.Models.VehicleEngineType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.VehicleEngineType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.VehicleEngineType left, Azure.Maps.Routing.Models.VehicleEngineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VehicleLoadType : System.IEquatable<Azure.Maps.Routing.Models.VehicleLoadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VehicleLoadType(string value) { throw null; }
        public static Azure.Maps.Routing.Models.VehicleLoadType OtherHazmatExplosive { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType OtherHazmatGeneral { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType OtherHazmatHarmfulToWater { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass1 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass2 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass3 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass4 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass5 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass6 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass7 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass8 { get { throw null; } }
        public static Azure.Maps.Routing.Models.VehicleLoadType USHazmatClass9 { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.VehicleLoadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.VehicleLoadType left, Azure.Maps.Routing.Models.VehicleLoadType right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.VehicleLoadType (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.VehicleLoadType left, Azure.Maps.Routing.Models.VehicleLoadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindingnessLevel : System.IEquatable<Azure.Maps.Routing.Models.WindingnessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindingnessLevel(string value) { throw null; }
        public static Azure.Maps.Routing.Models.WindingnessLevel High { get { throw null; } }
        public static Azure.Maps.Routing.Models.WindingnessLevel Low { get { throw null; } }
        public static Azure.Maps.Routing.Models.WindingnessLevel Normal { get { throw null; } }
        public bool Equals(Azure.Maps.Routing.Models.WindingnessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Maps.Routing.Models.WindingnessLevel left, Azure.Maps.Routing.Models.WindingnessLevel right) { throw null; }
        public static implicit operator Azure.Maps.Routing.Models.WindingnessLevel (string value) { throw null; }
        public static bool operator !=(Azure.Maps.Routing.Models.WindingnessLevel left, Azure.Maps.Routing.Models.WindingnessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
}
