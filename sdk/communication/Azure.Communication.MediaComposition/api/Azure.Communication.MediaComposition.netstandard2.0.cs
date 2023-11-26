namespace Azure.Communication.MediaComposition
{
    public partial class ActivePresenter : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ActivePresenter>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ActivePresenter>
    {
        public ActivePresenter(string call) { }
        public string Call { get { throw null; } set { } }
        Azure.Communication.MediaComposition.ActivePresenter System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ActivePresenter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ActivePresenter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.ActivePresenter System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ActivePresenter>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ActivePresenter>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ActivePresenter>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AutoGridInputGroup : Azure.Communication.MediaComposition.InputGroup, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridInputGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridInputGroup>
    {
        public AutoGridInputGroup(System.Collections.Generic.IEnumerable<string> inputIds) { }
        public System.Collections.Generic.IList<string> InputIds { get { throw null; } }
        Azure.Communication.MediaComposition.AutoGridInputGroup System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridInputGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridInputGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.AutoGridInputGroup System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridInputGroup>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridInputGroup>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridInputGroup>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoGridLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridLayout>
    {
        public AutoGridLayout(System.Collections.Generic.IEnumerable<string> inputIds) { }
        public bool? HighlightDominantSpeaker { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputIds { get { throw null; } }
        Azure.Communication.MediaComposition.AutoGridLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.AutoGridLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.AutoGridLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.AutoGridLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompositionStreamState : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CompositionStreamState>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CompositionStreamState>
    {
        public CompositionStreamState() { }
        public Azure.Communication.MediaComposition.StreamStatus? Status { get { throw null; } set { } }
        Azure.Communication.MediaComposition.CompositionStreamState System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CompositionStreamState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CompositionStreamState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.CompositionStreamState System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CompositionStreamState>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CompositionStreamState>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CompositionStreamState>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CustomLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CustomLayout>
    {
        public CustomLayout(System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> inputGroups) { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.InputGroup> InputGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.LayoutLayer> Layers { get { throw null; } }
        Azure.Communication.MediaComposition.CustomLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CustomLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.CustomLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.CustomLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CustomLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CustomLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.CustomLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DominantSpeaker : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.DominantSpeaker>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.DominantSpeaker>
    {
        public DominantSpeaker(string call) { }
        public string Call { get { throw null; } set { } }
        Azure.Communication.MediaComposition.DominantSpeaker System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.DominantSpeaker>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.DominantSpeaker>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.DominantSpeaker System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.DominantSpeaker>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.DominantSpeaker>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.DominantSpeaker>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GridInputGroup : Azure.Communication.MediaComposition.InputGroup, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridInputGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridInputGroup>
    {
        public GridInputGroup(System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> inputIds, int rows, int columns) { }
        public int Columns { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> InputIds { get { throw null; } }
        public int Rows { get { throw null; } set { } }
        Azure.Communication.MediaComposition.GridInputGroup System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridInputGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridInputGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.GridInputGroup System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridInputGroup>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridInputGroup>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridInputGroup>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GridLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridLayout>
    {
        public GridLayout(int rows, int columns, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> inputIds) { }
        public int Columns { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<string>> InputIds { get { throw null; } }
        public int Rows { get { throw null; } set { } }
        Azure.Communication.MediaComposition.GridLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GridLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.GridLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GridLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupCallInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallInput>
    {
        public GroupCallInput(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.Communication.MediaComposition.GroupCallInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.GroupCallInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupCallOutput : Azure.Communication.MediaComposition.Models.MediaOutput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallOutput>
    {
        public GroupCallOutput(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.Communication.MediaComposition.GroupCallOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.GroupCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.GroupCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.GroupCallOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InputGroup : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.InputGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.InputGroup>
    {
        protected InputGroup() { }
        public string Height { get { throw null; } set { } }
        public string Layer { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.InputPosition Position { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.ScalingMode? ScalingMode { get { throw null; } set { } }
        public string Width { get { throw null; } set { } }
        Azure.Communication.MediaComposition.InputGroup System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.InputGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.InputGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.InputGroup System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.InputGroup>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.InputGroup>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.InputGroup>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class MediaComposition : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.MediaComposition>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.MediaComposition>
    {
        public MediaComposition() { }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaInput> Inputs { get { throw null; } }
        public Azure.Communication.MediaComposition.Models.MediaCompositionLayout Layout { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.MediaComposition.Models.MediaOutput> Outputs { get { throw null; } }
        public Azure.Communication.MediaComposition.CompositionStreamState StreamState { get { throw null; } set { } }
        Azure.Communication.MediaComposition.MediaComposition System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.MediaComposition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.MediaComposition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.MediaComposition System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.MediaComposition>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.MediaComposition>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.MediaComposition>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class PresentationLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresentationLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresentationLayout>
    {
        public PresentationLayout(string presenterId, System.Collections.Generic.IEnumerable<string> audienceIds) { }
        public System.Collections.Generic.IList<string> AudienceIds { get { throw null; } }
        public Azure.Communication.MediaComposition.AudiencePosition? AudiencePosition { get { throw null; } set { } }
        public string PresenterId { get { throw null; } set { } }
        Azure.Communication.MediaComposition.PresentationLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresentationLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresentationLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.PresentationLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresentationLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresentationLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresentationLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PresenterLayout : Azure.Communication.MediaComposition.Models.MediaCompositionLayout, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresenterLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresenterLayout>
    {
        public PresenterLayout(string presenterId, string supportId) { }
        public string PresenterId { get { throw null; } set { } }
        public double? SupportAspectRatio { get { throw null; } set { } }
        public string SupportId { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.SupportPosition? SupportPosition { get { throw null; } set { } }
        Azure.Communication.MediaComposition.PresenterLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresenterLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.PresenterLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.PresenterLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresenterLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresenterLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.PresenterLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoomInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomInput>
    {
        public RoomInput(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.Communication.MediaComposition.RoomInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.RoomInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoomOutput : Azure.Communication.MediaComposition.Models.MediaOutput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomOutput>
    {
        public RoomOutput(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.Communication.MediaComposition.RoomOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RoomOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.RoomOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RoomOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RtmpInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpInput>
    {
        public RtmpInput(string streamKey, Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.RtmpMode? Mode { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamKey { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.RtmpInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.RtmpInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RtmpOutput : Azure.Communication.MediaComposition.Models.MediaOutput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpOutput>
    {
        public RtmpOutput(string streamKey, Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.RtmpMode? Mode { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamKey { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.RtmpOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.RtmpOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.RtmpOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.RtmpOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ScreenShare : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ScreenShare>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ScreenShare>
    {
        public ScreenShare(string call) { }
        public string Call { get { throw null; } set { } }
        Azure.Communication.MediaComposition.ScreenShare System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ScreenShare>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.ScreenShare>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.ScreenShare System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ScreenShare>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ScreenShare>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.ScreenShare>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SrtInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtInput>
    {
        public SrtInput(Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.SrtInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.SrtInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SrtOutput : Azure.Communication.MediaComposition.Models.MediaOutput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtOutput>
    {
        public SrtOutput(Azure.Communication.MediaComposition.Models.LayoutResolution resolution, string streamUrl) { }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public string StreamUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.SrtOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.SrtOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.SrtOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.SrtOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TeamsMeetingInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingInput>
    {
        public TeamsMeetingInput(string teamsJoinUrl) { }
        public string TeamsJoinUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.TeamsMeetingInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.TeamsMeetingInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TeamsMeetingOutput : Azure.Communication.MediaComposition.Models.MediaOutput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>
    {
        public TeamsMeetingOutput(string teamsJoinUrl) { }
        public string TeamsJoinUrl { get { throw null; } set { } }
        Azure.Communication.MediaComposition.TeamsMeetingOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.TeamsMeetingOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.TeamsMeetingOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.Communication.MediaComposition.Models
{
    public partial class ImageInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ImageInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ImageInput>
    {
        public ImageInput(string uri) { }
        public string Uri { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.ImageInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ImageInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ImageInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.ImageInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ImageInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ImageInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ImageInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputPosition : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.InputPosition>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.InputPosition>
    {
        public InputPosition(int x, int y) { }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.InputPosition System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.InputPosition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.InputPosition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.InputPosition System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.InputPosition>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.InputPosition>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.InputPosition>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LayoutLayer : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutLayer>
    {
        public LayoutLayer(int zIndex) { }
        public Azure.Communication.MediaComposition.LayerVisibility? Visibility { get { throw null; } set { } }
        public int ZIndex { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.LayoutLayer System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.LayoutLayer System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutLayer>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutLayer>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutLayer>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LayoutResolution : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutResolution>
    {
        public LayoutResolution(int width, int height) { }
        public int Height { get { throw null; } set { } }
        public int Width { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.LayoutResolution System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.LayoutResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.LayoutResolution System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutResolution>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutResolution>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.LayoutResolution>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaCompositionLayout : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>
    {
        internal MediaCompositionLayout() { }
        public string PlaceholderImageUri { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.Models.LayoutResolution Resolution { get { throw null; } set { } }
        public Azure.Communication.MediaComposition.ScalingMode? ScalingMode { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.MediaCompositionLayout System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.MediaCompositionLayout System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaCompositionLayout>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaInput : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaInput>
    {
        internal MediaInput() { }
        public string PlaceholderImageUri { get { throw null; } set { } }
        Azure.Communication.MediaComposition.Models.MediaInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.MediaInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MediaOutput : System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaOutput>
    {
        internal MediaOutput() { }
        Azure.Communication.MediaComposition.Models.MediaOutput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.MediaOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.MediaOutput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaOutput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaOutput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.MediaOutput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParticipantInput : Azure.Communication.MediaComposition.Models.MediaInput, System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ParticipantInput>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ParticipantInput>
    {
        public ParticipantInput(Azure.Communication.CommunicationIdentifier id, string call) { }
        public string Call { get { throw null; } set { } }
        public Azure.Communication.CommunicationIdentifier Id { get { throw null; } }
        Azure.Communication.MediaComposition.Models.ParticipantInput System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ParticipantInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.MediaComposition.Models.ParticipantInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.ModelReaderWriterOptions options) { }
        Azure.Communication.MediaComposition.Models.ParticipantInput System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ParticipantInput>.Create(System.BinaryData data, System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ParticipantInput>.GetFormatFromOptions(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.MediaComposition.Models.ParticipantInput>.Write(System.ClientModel.ModelReaderWriterOptions options) { throw null; }
    }
}
