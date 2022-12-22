namespace Azure.Communication.MediaComposition
{
    public partial class ActivePresenter : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public ActivePresenter(string call) { }
        public string Call { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudiencePosition : System.IEquatable<Azure.Communication.MediaComposition.AudiencePosition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudiencePosition(string value) { throw null; }
        public static Azure.Communication.MediaComposition.AudiencePosition Bottom { get { throw null; } }
        public static Azure.Communication.MediaComposition.AudiencePosition Left { get { throw null; } }
        public static Azure.Communication.MediaComposition.AudiencePosition Right { get { throw null; } }
        public static Azure.Communication.MediaComposition.AudiencePosition Top { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.AudiencePosition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.AudiencePosition left, Azure.Communication.MediaComposition.AudiencePosition right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.AudiencePosition (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.AudiencePosition left, Azure.Communication.MediaComposition.AudiencePosition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoGridInputGroup : Azure.Communication.MediaComposition.InputGroup
    {
        public AutoGridInputGroup(System.Collections.Generic.IEnumerable<string> inputIds) { }
        public System.Collections.Generic.IList<string> InputIds { get { throw null; } }
    }
    public partial class AutoGridLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout
    {
        public AutoGridLayout(System.Collections.Generic.IEnumerable<string> inputIds) { }
        public bool? HighlightDominantSpeaker { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputIds { get { throw null; } }
    }
    public partial class CompositionStreamState
    {
        public CompositionStreamState() { }
        public Azure.Communication.MediaComposition.StreamStatus? Status { get { throw null; } set { } }
    }
    public partial class CustomLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout
    {
        public CustomLayout(System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> inputGroups) { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> InputGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.LayoutLayer> Layers { get { throw null; } }
    }
    public partial class DominantSpeaker : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public DominantSpeaker(string call) { }
        public string Call { get { throw null; } set { } }
    }
    public partial class GridInputGroup : Azure.Communication.MediaComposition.InputGroup
    {
        public GridInputGroup(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> inputIds, int rows, int columns) { }
        public int Columns { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> InputIds { get { throw null; } }
        public int Rows { get { throw null; } set { } }
    }
    public partial class GridLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout
    {
        public GridLayout(int rows, int columns, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> inputIds) { }
        public int Columns { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> InputIds { get { throw null; } }
        public int Rows { get { throw null; } set { } }
    }
    public partial class GroupCallInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public GroupCallInput(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class GroupCallOutput : Azure.Communication.MediaComposition.Models.MediaOutput
    {
        public GroupCallOutput(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public abstract partial class InputGroup
    {
        protected InputGroup() { }
        public string Height { get { throw null; } set { } }
        public string Layer { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.InputPosition Position { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.ScalingMode? ScalingMode { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputGroupType : System.IEquatable<Azure.Communication.MediaComposition.InputGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputGroupType(string value) { throw null; }
        public static Azure.Communication.MediaComposition.InputGroupType AutoGridBased { get { throw null; } }
        public static Azure.Communication.MediaComposition.InputGroupType GridBased { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.InputGroupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.InputGroupType left, Azure.Communication.MediaComposition.InputGroupType right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.InputGroupType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.InputGroupType left, Azure.Communication.MediaComposition.InputGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LayerVisibility : System.IEquatable<Azure.Communication.MediaComposition.LayerVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LayerVisibility(string value) { throw null; }
        public static Azure.Communication.MediaComposition.LayerVisibility Hidden { get { throw null; } }
        public static Azure.Communication.MediaComposition.LayerVisibility Visible { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.LayerVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.LayerVisibility left, Azure.Communication.MediaComposition.LayerVisibility right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.LayerVisibility (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.LayerVisibility left, Azure.Communication.MediaComposition.LayerVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LayoutType : System.IEquatable<Azure.Communication.MediaComposition.LayoutType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LayoutType(string value) { throw null; }
        public static Azure.Communication.MediaComposition.LayoutType AutoGrid { get { throw null; } }
        public static Azure.Communication.MediaComposition.LayoutType Custom { get { throw null; } }
        public static Azure.Communication.MediaComposition.LayoutType Grid { get { throw null; } }
        public static Azure.Communication.MediaComposition.LayoutType Presentation { get { throw null; } }
        public static Azure.Communication.MediaComposition.LayoutType Presenter { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.LayoutType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.LayoutType left, Azure.Communication.MediaComposition.LayoutType right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.LayoutType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.LayoutType left, Azure.Communication.MediaComposition.LayoutType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MediaComposition
    {
        public MediaComposition() { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> Inputs { get { throw null; } }
        public Azure.Communication.MediaComposition.Models.MediaCompositionLayout Layout { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> Outputs { get { throw null; } }
        public Azure.Communication.MediaComposition.CompositionStreamState StreamState { get { throw null; } set { } }
    }
    public partial class MediaCompositionClient
    {
        protected MediaCompositionClient() { }
        public MediaCompositionClient(string connectionString) { }
        public MediaCompositionClient(string connectionString, Azure.Communication.MediaComposition.MediaCompositionClientOptions options) { }
        public MediaCompositionClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.MediaComposition.MediaCompositionClientOptions options = null) { }
        public MediaCompositionClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.MediaComposition.MediaCompositionClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> Create(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> inputs, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> CreateAsync(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> inputs, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> Get(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> GetAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> RemoveInputs(string mediaCompositionId, System.Collections.Generic.IEnumerable<string> inputIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> RemoveInputsAsync(string mediaCompositionId, System.Collections.Generic.IEnumerable<string> inputIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> RemoveOutputs(string mediaCompositionId, System.Collections.Generic.IEnumerable<string> outputIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> RemoveOutputsAsync(string mediaCompositionId, System.Collections.Generic.IEnumerable<string> outputIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState> Start(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState>> StartAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState> Stop(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState>> StopAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> UpdateLayout(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> UpdateLayoutAsync(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> UpsertInputs(string mediaCompositionId, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> UpsertInputsAsync(string mediaCompositionId, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaComposition> UpsertOutputs(string mediaCompositionId, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaComposition>> UpsertOutputsAsync(string mediaCompositionId, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaCompositionClientOptions : Azure.Core.ClientOptions
    {
        public MediaCompositionClientOptions(Azure.Communication.MediaComposition.MediaCompositionClientOptions.ServiceVersion version = Azure.Communication.MediaComposition.MediaCompositionClientOptions.ServiceVersion.V2022_07_16_Preview) { }
        public enum ServiceVersion
        {
            V2022_07_16_Preview = 1,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaInputType : System.IEquatable<Azure.Communication.MediaComposition.MediaInputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaInputType(string value) { throw null; }
        public static Azure.Communication.MediaComposition.MediaInputType ActivePresenter { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType DominantSpeaker { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType GroupCall { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType Image { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType Participant { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType Room { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType Rtmp { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType ScreenShare { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType Srt { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaInputType TeamsMeeting { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.MediaInputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.MediaInputType left, Azure.Communication.MediaComposition.MediaInputType right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.MediaInputType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.MediaInputType left, Azure.Communication.MediaComposition.MediaInputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MediaOutputType : System.IEquatable<Azure.Communication.MediaComposition.MediaOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MediaOutputType(string value) { throw null; }
        public static Azure.Communication.MediaComposition.MediaOutputType GroupCall { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaOutputType Room { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaOutputType Rtmp { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaOutputType Srt { get { throw null; } }
        public static Azure.Communication.MediaComposition.MediaOutputType TeamsMeeting { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.MediaOutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.MediaOutputType left, Azure.Communication.MediaComposition.MediaOutputType right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.MediaOutputType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.MediaOutputType left, Azure.Communication.MediaComposition.MediaOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PresentationLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout
    {
        public PresentationLayout(string presenterId, System.Collections.Generic.IEnumerable<string> audienceIds) { }
        public System.Collections.Generic.IList<string> AudienceIds { get { throw null; } }
        public Azure.Communication.MediaComposition.AudiencePosition? AudiencePosition { get { throw null; } set { } }
        public string PresenterId { get { throw null; } set { } }
    }
    public partial class PresenterLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout
    {
        public PresenterLayout(string presenterId, string supportId) { }
        public string PresenterId { get { throw null; } set { } }
        public double? SupportAspectRatio { get { throw null; } set { } }
        public string SupportId { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.SupportPosition? SupportPosition { get { throw null; } set { } }
    }
    public partial class RoomInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public RoomInput(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class RoomOutput : Azure.Communication.MediaComposition.Models.MediaOutput
    {
        public RoomOutput(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class RtmpInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public RtmpInput(string streamKey, Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.RtmpMode? Mode { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamKey { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RtmpMode : System.IEquatable<Azure.Communication.MediaComposition.RtmpMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RtmpMode(string value) { throw null; }
        public static Azure.Communication.MediaComposition.RtmpMode Pull { get { throw null; } }
        public static Azure.Communication.MediaComposition.RtmpMode Push { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.RtmpMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.RtmpMode left, Azure.Communication.MediaComposition.RtmpMode right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.RtmpMode (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.RtmpMode left, Azure.Communication.MediaComposition.RtmpMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RtmpOutput : Azure.Communication.MediaComposition.Models.MediaOutput
    {
        public RtmpOutput(string streamKey, Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.RtmpMode? Mode { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamKey { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScalingMode : System.IEquatable<Azure.Communication.MediaComposition.ScalingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScalingMode(string value) { throw null; }
        public static Azure.Communication.MediaComposition.ScalingMode Crop { get { throw null; } }
        public static Azure.Communication.MediaComposition.ScalingMode Fit { get { throw null; } }
        public static Azure.Communication.MediaComposition.ScalingMode Stretch { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.ScalingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.ScalingMode left, Azure.Communication.MediaComposition.ScalingMode right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.ScalingMode (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.ScalingMode left, Azure.Communication.MediaComposition.ScalingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScreenShare : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public ScreenShare(string call) { }
        public string Call { get { throw null; } set { } }
    }
    public partial class SrtInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public SrtInput(Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
    }
    public partial class SrtOutput : Azure.Communication.MediaComposition.Models.MediaOutput
    {
        public SrtOutput(Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StreamStatus : System.IEquatable<Azure.Communication.MediaComposition.StreamStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StreamStatus(string value) { throw null; }
        public static Azure.Communication.MediaComposition.StreamStatus NotStarted { get { throw null; } }
        public static Azure.Communication.MediaComposition.StreamStatus Running { get { throw null; } }
        public static Azure.Communication.MediaComposition.StreamStatus Stopped { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.StreamStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.StreamStatus left, Azure.Communication.MediaComposition.StreamStatus right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.StreamStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.StreamStatus left, Azure.Communication.MediaComposition.StreamStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SupportPosition : System.IEquatable<Azure.Communication.MediaComposition.SupportPosition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SupportPosition(string value) { throw null; }
        public static Azure.Communication.MediaComposition.SupportPosition BottomLeft { get { throw null; } }
        public static Azure.Communication.MediaComposition.SupportPosition BottomRight { get { throw null; } }
        public static Azure.Communication.MediaComposition.SupportPosition TopLeft { get { throw null; } }
        public static Azure.Communication.MediaComposition.SupportPosition TopRight { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.SupportPosition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.SupportPosition left, Azure.Communication.MediaComposition.SupportPosition right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.SupportPosition (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.SupportPosition left, Azure.Communication.MediaComposition.SupportPosition right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TeamsMeetingInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public TeamsMeetingInput(string teamsJoinUrl) { }
        public string TeamsJoinUrl { get { throw null; } set { } }
    }
    public partial class TeamsMeetingOutput : Azure.Communication.MediaComposition.Models.MediaOutput
    {
        public TeamsMeetingOutput(string teamsJoinUrl) { }
        public string TeamsJoinUrl { get { throw null; } set { } }
    }
}
namespace Azure.Communication.MediaComposition.Models
{
    public partial class ImageInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public ImageInput(string uri) { }
        public string Uri { get { throw null; } set { } }
    }
    public partial class InputPosition
    {
        public InputPosition(int x, int y) { }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
    }
    public partial class LayoutLayer
    {
        public LayoutLayer(int zIndex) { }
        public Azure.Communication.MediaComposition.LayerVisibility? Visibility { get { throw null; } set { } }
        public int ZIndex { get { throw null; } set { } }
    }
    public partial class LayoutResolution
    {
        public LayoutResolution(int width, int height) { }
        public int Height { get { throw null; } set { } }
        public int Width { get { throw null; } set { } }
    }
    public abstract partial class MediaCompositionLayout
    {
        internal MediaCompositionLayout() { }
        public string PlaceholderImageUri { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.ScalingMode? ScalingMode { get { throw null; } set { } }
    }
    public abstract partial class MediaInput
    {
        internal MediaInput() { }
        public string PlaceholderImageUri { get { throw null; } set { } }
    }
    public abstract partial class MediaOutput
    {
        internal MediaOutput() { }
    }
    public partial class ParticipantInput : Azure.Communication.MediaComposition.Models.MediaInput
    {
        public ParticipantInput(Azure.Communication.CommunicationIdentifier id, string call) { }
        public string Call { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Id { get { throw null; } }
    }
}
