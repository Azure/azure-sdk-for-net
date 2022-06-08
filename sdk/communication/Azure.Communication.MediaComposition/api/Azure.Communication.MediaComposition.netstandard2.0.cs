namespace Azure.Communication.MediaComposition
{
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
    public partial class AutoGridLayoutOptions
    {
        public AutoGridLayoutOptions(System.Collections.Generic.IEnumerable<string> inputIds) { }
        public bool? HighlightDominantSpeaker { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputIds { get { throw null; } }
    }
    public partial class CommunicationCallIdentifierModel
    {
        public CommunicationCallIdentifierModel(string call) { }
        public string Call { get { throw null; } set { } }
    }
    public partial class CommunicationIdentifierModel
    {
        public CommunicationIdentifierModel() { }
        public Azure.Communication.MediaComposition.CommunicationUserIdentifierModel CommunicationUser { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.MicrosoftTeamsUserIdentifierModel MicrosoftTeamsUser { get { throw null; } set { } }
    }
    public partial class CommunicationUserIdentifierModel
    {
        public CommunicationUserIdentifierModel(string id) { }
        public string Id { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompositionStreamState : System.IEquatable<Azure.Communication.MediaComposition.CompositionStreamState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompositionStreamState(string value) { throw null; }
        public static Azure.Communication.MediaComposition.CompositionStreamState NotStarted { get { throw null; } }
        public static Azure.Communication.MediaComposition.CompositionStreamState Running { get { throw null; } }
        public static Azure.Communication.MediaComposition.CompositionStreamState Stopped { get { throw null; } }
        public bool Equals(Azure.Communication.MediaComposition.CompositionStreamState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.MediaComposition.CompositionStreamState left, Azure.Communication.MediaComposition.CompositionStreamState right) { throw null; }
        public static implicit operator Azure.Communication.MediaComposition.CompositionStreamState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.MediaComposition.CompositionStreamState left, Azure.Communication.MediaComposition.CompositionStreamState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomLayoutOptions
    {
        public CustomLayoutOptions(System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> inputGroups) { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> InputGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.LayoutLayer> Layers { get { throw null; } }
    }
    public partial class GridLayoutOptions
    {
        public GridLayoutOptions(int rows, int columns, object inputIds) { }
        public int Columns { get { throw null; } set { } }
        public object InputIds { get { throw null; } set { } }
        public int Rows { get { throw null; } set { } }
    }
    public partial class GroupCall
    {
        public GroupCall(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class InputGroup
    {
        public InputGroup(object inputIds) { }
        public int? Columns { get { throw null; } set { } }
        public object Height { get { throw null; } set { } }
        public object InputIds { get { throw null; } set { } }
        public string Layer { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.InputPosition Position { get { throw null; } set { } }
        public int? Rows { get { throw null; } set { } }
        public object Width { get { throw null; } set { } }
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
    public partial class MediaCompositionBody
    {
        public MediaCompositionBody() { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaInput> Inputs { get { throw null; } }
        public Azure.Communication.MediaComposition.Models.MediaCompositionLayout Layout { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaOutput> Outputs { get { throw null; } }
        public Azure.Communication.MediaComposition.CompositionStreamState? StreamState { get { throw null; } set { } }
    }
    public partial class MediaCompositionClient
    {
        protected MediaCompositionClient() { }
        public MediaCompositionClient(string connectionString) { }
        public MediaCompositionClient(string connectionString, Azure.Communication.MediaComposition.MediaCompositionClientOptions options) { }
        public MediaCompositionClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.Communication.MediaComposition.MediaCompositionClientOptions options = null) { }
        public MediaCompositionClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.Communication.MediaComposition.MediaCompositionClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody> Create(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaInput> inputs, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody>> CreateAsync(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaInput> inputs, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaOutput> outputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody> Get(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody>> GetAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState> Start(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState>> StartAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState> Stop(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.CompositionStreamState>> StopAsync(string mediaCompositionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody> Update(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout = null, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaInput> inputs = null, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaOutput> outputs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.MediaComposition.MediaCompositionBody>> UpdateAsync(string mediaCompositionId, Azure.Communication.MediaComposition.Models.MediaCompositionLayout layout = null, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaInput> inputs = null, System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.MediaOutput> outputs = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MediaCompositionClientOptions : Azure.Core.ClientOptions
    {
        public MediaCompositionClientOptions(Azure.Communication.MediaComposition.MediaCompositionClientOptions.ServiceVersion version = Azure.Communication.MediaComposition.MediaCompositionClientOptions.ServiceVersion.V2022_06_26_Preview) { }
        public enum ServiceVersion
        {
            V2022_06_26_Preview = 1,
        }
    }
    public partial class MediaInput
    {
        public MediaInput() { }
        public Azure.Communication.MediaComposition.CommunicationCallIdentifierModel ActivePresenter { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.CommunicationCallIdentifierModel DominantSpeaker { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.GroupCall GroupCall { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.ImageInput Image { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.MediaInputType? Kind { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.ParticipantInput Participant { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.GroupCall Room { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.RtmpStream Rtmp { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.CommunicationCallIdentifierModel ScreenShare { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.SrtStream Srt { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.TeamsMeeting TeamsMeeting { get { throw null; } set { } }
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
    public partial class MediaOutput
    {
        public MediaOutput() { }
        public Azure.Communication.MediaComposition.GroupCall GroupCall { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.MediaOutputType? Kind { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.GroupCall Room { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.RtmpStream Rtmp { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.SrtStream Srt { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.TeamsMeeting TeamsMeeting { get { throw null; } set { } }
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
    public partial class MicrosoftTeamsUserIdentifierModel
    {
        public MicrosoftTeamsUserIdentifierModel(string userId) { }
        public string UserId { get { throw null; } set { } }
    }
    public partial class PresentationLayoutOptions
    {
        public PresentationLayoutOptions(string presenterId, System.Collections.Generic.IEnumerable<string> audienceIds) { }
        public System.Collections.Generic.IList<string> AudienceIds { get { throw null; } }
        public Azure.Communication.MediaComposition.AudiencePosition? AudiencePosition { get { throw null; } set { } }
        public string PresenterId { get { throw null; } set { } }
    }
    public partial class PresenterLayoutOptions
    {
        public PresenterLayoutOptions(string presenterId, string supportId) { }
        public string PresenterId { get { throw null; } set { } }
        public double? SupportAspectRatio { get { throw null; } set { } }
        public string SupportId { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.SupportPosition? SupportPosition { get { throw null; } set { } }
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
    public partial class RtmpStream
    {
        public RtmpStream(string streamKey, Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.RtmpMode? Mode { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamKey { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
    }
    public partial class SrtStream
    {
        public SrtStream(Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
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
    public partial class TeamsMeeting
    {
        public TeamsMeeting(string teamsJoinUrl) { }
        public string TeamsJoinUrl { get { throw null; } set { } }
    }
}
namespace Azure.Communication.MediaComposition.Models
{
    public partial class ImageInput
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
    public partial class MediaCompositionLayout
    {
        public MediaCompositionLayout() { }
        public Azure.Communication.MediaComposition.AutoGridLayoutOptions AutoGrid { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.CustomLayoutOptions Custom { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.GridLayoutOptions Grid { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.LayoutType? Kind { get { throw null; } set { } }
        public string PlaceholderImageUri { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.PresentationLayoutOptions Presentation { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.PresenterLayoutOptions Presenter { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
    }
    public partial class ParticipantInput
    {
        public ParticipantInput(Azure.Communication.MediaComposition.CommunicationIdentifierModel id, string call) { }
        public string Call { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.CommunicationIdentifierModel Id { get { throw null; } set { } }
        public string PlaceholderImageUri { get { throw null; } set { } }
    }
}
