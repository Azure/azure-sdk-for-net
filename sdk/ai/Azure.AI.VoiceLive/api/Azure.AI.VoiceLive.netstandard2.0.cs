namespace Azure.AI.VoiceLive
{
    public partial class AnimationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AnimationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AnimationOptions>
    {
        public AnimationOptions() { }
        public int? EmotionDetectionIntervalMs { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.AnimationOutputType> Outputs { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.AnimationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AnimationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AnimationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AnimationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AnimationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AnimationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AnimationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AnimationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AnimationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AnimationOutputType
    {
        Blendshapes = 0,
        VisemeId = 1,
        Emotion = 2,
    }
    public partial class AssistantMessageItem : Azure.AI.VoiceLive.MessageItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AssistantMessageItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AssistantMessageItem>
    {
        public AssistantMessageItem(System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.OutputTextContentPart> content) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.OutputTextContentPart> Content { get { throw null; } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AssistantMessageItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AssistantMessageItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AssistantMessageItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AssistantMessageItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AssistantMessageItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AssistantMessageItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AssistantMessageItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AudioEchoCancellation : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioEchoCancellation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioEchoCancellation>
    {
        public AudioEchoCancellation() { }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.AudioEchoCancellation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AudioEchoCancellation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AudioEchoCancellation System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioEchoCancellation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioEchoCancellation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AudioEchoCancellation System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioEchoCancellation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioEchoCancellation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioEchoCancellation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioFormat : System.IEquatable<Azure.AI.VoiceLive.AudioFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioFormat(string value) { throw null; }
        public static Azure.AI.VoiceLive.AudioFormat G711Alaw { get { throw null; } }
        public static Azure.AI.VoiceLive.AudioFormat G711Ulaw { get { throw null; } }
        public static Azure.AI.VoiceLive.AudioFormat Pcm16 { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.AudioFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.AudioFormat left, Azure.AI.VoiceLive.AudioFormat right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.AudioFormat (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.AudioFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.AudioFormat left, Azure.AI.VoiceLive.AudioFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioInputTranscriptionSettings : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>
    {
        public AudioInputTranscriptionSettings(Azure.AI.VoiceLive.AudioInputTranscriptionSettingsModel model, bool enabled, bool customModel) { }
        public bool CustomModel { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioInputTranscriptionSettingsModel Model { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.AudioInputTranscriptionSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AudioInputTranscriptionSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AudioInputTranscriptionSettings System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AudioInputTranscriptionSettings System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioInputTranscriptionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AudioInputTranscriptionSettingsModel
    {
        Whisper1 = 0,
        AzureFastTranscription = 1,
        S2sIngraph = 2,
    }
    public partial class AudioNoiseReduction : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioNoiseReduction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioNoiseReduction>
    {
        public AudioNoiseReduction() { }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.AudioNoiseReduction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AudioNoiseReduction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AudioNoiseReduction System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioNoiseReduction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AudioNoiseReduction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AudioNoiseReduction System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioNoiseReduction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioNoiseReduction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AudioNoiseReduction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioTimestampType : System.IEquatable<Azure.AI.VoiceLive.AudioTimestampType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioTimestampType(string value) { throw null; }
        public static Azure.AI.VoiceLive.AudioTimestampType Word { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.AudioTimestampType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.AudioTimestampType left, Azure.AI.VoiceLive.AudioTimestampType right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.AudioTimestampType (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.AudioTimestampType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.AudioTimestampType left, Azure.AI.VoiceLive.AudioTimestampType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AvatarConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AvatarConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AvatarConfig>
    {
        public AvatarConfig(string character, bool customized) { }
        public string Character { get { throw null; } set { } }
        public bool Customized { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.IceServer> IceServers { get { throw null; } }
        public string Style { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VideoParams Video { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.AvatarConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AvatarConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AvatarConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AvatarConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AvatarConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AvatarConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AvatarConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AvatarConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AvatarConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIVoiceLiveContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIVoiceLiveContext() { }
        public static Azure.AI.VoiceLive.AzureAIVoiceLiveContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureCustomVoice : Azure.AI.VoiceLive.AzureVoice, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureCustomVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureCustomVoice>
    {
        public AzureCustomVoice(string name, string endpointId) { }
        public string CustomLexiconUri { get { throw null; } set { } }
        public string EndpointId { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Pitch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferLocales { get { throw null; } }
        public string Rate { get { throw null; } set { } }
        public string Style { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public string Volume { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.AzureVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.AzureVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureCustomVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureCustomVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureCustomVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureCustomVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureCustomVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureCustomVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureCustomVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureMultilingualSemanticVad : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>
    {
        public AzureMultilingualSemanticVad() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        public int? DistinctCiPhones { get { throw null; } set { } }
        public Azure.AI.VoiceLive.EOUDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public float? NegThreshold { get { throw null; } set { } }
        public int? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public bool? RequireVowel { get { throw null; } set { } }
        public int? SilenceDurationMs { get { throw null; } set { } }
        public int? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public int? WindowSize { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureMultilingualSemanticVad System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureMultilingualSemanticVad System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureMultilingualSemanticVad>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzurePersonalVoice : Azure.AI.VoiceLive.AzureVoice, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePersonalVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePersonalVoice>
    {
        public AzurePersonalVoice(string name, Azure.AI.VoiceLive.AzurePersonalVoiceModel model) { }
        public Azure.AI.VoiceLive.AzurePersonalVoiceModel Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.AzureVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.AzureVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzurePersonalVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePersonalVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePersonalVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzurePersonalVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePersonalVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePersonalVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePersonalVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AzurePersonalVoiceModel
    {
        DragonLatestNeural = 0,
        PhoenixLatestNeural = 1,
        PhoenixV2Neural = 2,
    }
    public partial class AzurePlatformVoice : Azure.AI.VoiceLive.AzureVoice, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePlatformVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePlatformVoice>
    {
        public AzurePlatformVoice(string name) { }
        public string CustomLexiconUrl { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Pitch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferLocales { get { throw null; } }
        public string Rate { get { throw null; } set { } }
        public string Style { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public string Volume { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.AzureVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.AzureVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzurePlatformVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePlatformVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzurePlatformVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzurePlatformVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePlatformVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePlatformVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzurePlatformVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticDetection : Azure.AI.VoiceLive.EOUDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetection>
    {
        public AzureSemanticDetection() { }
        public bool? DisableRules { get { throw null; } set { } }
        public bool? ExtraImendCheck { get { throw null; } set { } }
        public float? SecondaryThreshold { get { throw null; } set { } }
        public float? SecondaryTimeout { get { throw null; } set { } }
        public float? SrBoost { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public float? Timeout { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.EOUDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.EOUDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticDetectionEn : Azure.AI.VoiceLive.EOUDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>
    {
        public AzureSemanticDetectionEn() { }
        public bool? DisableRules { get { throw null; } set { } }
        public bool? ExtraImendCheck { get { throw null; } set { } }
        public float? SecondaryThreshold { get { throw null; } set { } }
        public float? SecondaryTimeout { get { throw null; } set { } }
        public float? SrBoost { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public float? Timeout { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.EOUDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.EOUDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticDetectionEn System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticDetectionEn System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionEn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticDetectionMultilingual : Azure.AI.VoiceLive.EOUDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>
    {
        public AzureSemanticDetectionMultilingual() { }
        public bool? DisableRules { get { throw null; } set { } }
        public bool? ExtraImendCheck { get { throw null; } set { } }
        public float? SecondaryThreshold { get { throw null; } set { } }
        public float? SecondaryTimeout { get { throw null; } set { } }
        public float? SrBoost { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public float? Timeout { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.EOUDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.EOUDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticVad : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVad>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVad>
    {
        public AzureSemanticVad() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        public int? DistinctCiPhones { get { throw null; } set { } }
        public Azure.AI.VoiceLive.EOUDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public float? NegThreshold { get { throw null; } set { } }
        public int? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public bool? RequireVowel { get { throw null; } set { } }
        public int? SilenceDurationMs { get { throw null; } set { } }
        public int? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public int? WindowSize { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticVad System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVad>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVad>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticVad System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVad>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVad>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVad>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticVadEn : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadEn>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadEn>
    {
        public AzureSemanticVadEn() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        public int? DistinctCiPhones { get { throw null; } set { } }
        public Azure.AI.VoiceLive.EOUDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public float? NegThreshold { get { throw null; } set { } }
        public int? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public bool? RequireVowel { get { throw null; } set { } }
        public int? SilenceDurationMs { get { throw null; } set { } }
        public int? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public int? WindowSize { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticVadEn System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadEn>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadEn>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticVadEn System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadEn>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadEn>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadEn>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureSemanticVadServer : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadServer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadServer>
    {
        public AzureSemanticVadServer() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        public int? DistinctCiPhones { get { throw null; } set { } }
        public Azure.AI.VoiceLive.EOUDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public float? NegThreshold { get { throw null; } set { } }
        public int? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public bool? RequireVowel { get { throw null; } set { } }
        public int? SilenceDurationMs { get { throw null; } set { } }
        public int? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public int? WindowSize { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureSemanticVadServer System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureSemanticVadServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureSemanticVadServer System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureSemanticVadServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStandardVoice : Azure.AI.VoiceLive.AzureVoice, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureStandardVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureStandardVoice>
    {
        public AzureStandardVoice(string name) { }
        public string CustomLexiconUrl { get { throw null; } set { } }
        public string Locale { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Pitch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferLocales { get { throw null; } }
        public string Rate { get { throw null; } set { } }
        public string Style { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public string Volume { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.AzureVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.AzureVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureStandardVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureStandardVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureStandardVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureStandardVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureStandardVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureStandardVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureStandardVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AzureVoice : Azure.AI.VoiceLive.VoiceType, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureVoice>
    {
        internal AzureVoice() { }
        protected virtual Azure.AI.VoiceLive.AzureVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.AzureVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.AzureVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.AzureVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.AzureVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.AzureVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConversationRequestItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ConversationRequestItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ConversationRequestItem>
    {
        internal ConversationRequestItem() { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ConversationRequestItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ConversationRequestItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ConversationRequestItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ConversationRequestItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ConversationRequestItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ConversationRequestItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ConversationRequestItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmotionCandidate : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EmotionCandidate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EmotionCandidate>
    {
        internal EmotionCandidate() { }
        public float Confidence { get { throw null; } }
        public string Emotion { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.EmotionCandidate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.EmotionCandidate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.EmotionCandidate System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EmotionCandidate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EmotionCandidate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.EmotionCandidate System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EmotionCandidate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EmotionCandidate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EmotionCandidate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EOUDetection : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EOUDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EOUDetection>
    {
        internal EOUDetection() { }
        protected virtual Azure.AI.VoiceLive.EOUDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.EOUDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.EOUDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EOUDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.EOUDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.EOUDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EOUDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EOUDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.EOUDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionCallItem : Azure.AI.VoiceLive.ConversationRequestItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallItem>
    {
        public FunctionCallItem(string name, string callId, string arguments) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.VoiceLive.ItemParamStatus? Status { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.FunctionCallItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.FunctionCallItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionCallOutputItem : Azure.AI.VoiceLive.ConversationRequestItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallOutputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallOutputItem>
    {
        public FunctionCallOutputItem(string callId, string output) { }
        public string CallId { get { throw null; } }
        public string Output { get { throw null; } }
        public Azure.AI.VoiceLive.ItemParamStatus? Status { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.FunctionCallOutputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallOutputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.FunctionCallOutputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.FunctionCallOutputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallOutputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallOutputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.FunctionCallOutputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IceServer : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.IceServer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.IceServer>
    {
        public IceServer(System.Collections.Generic.IEnumerable<System.Uri> uris) { }
        public string Credential { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Uri> Uris { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.IceServer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.IceServer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.IceServer System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.IceServer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.IceServer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.IceServer System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.IceServer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.IceServer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.IceServer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputAudio : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudio>
    {
        public InputAudio() { }
        public string Model { get { throw null; } }
        public System.Collections.Generic.IList<string> PhraseList { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.InputAudio JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.InputAudio PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.InputAudio System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.InputAudio System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputAudioContentPart : Azure.AI.VoiceLive.UserContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudioContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudioContentPart>
    {
        public InputAudioContentPart(string audio) { }
        public string Audio { get { throw null; } }
        public string Transcript { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.UserContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.UserContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.InputAudioContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudioContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputAudioContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.InputAudioContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudioContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudioContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputAudioContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputModality : System.IEquatable<Azure.AI.VoiceLive.InputModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputModality(string value) { throw null; }
        public static Azure.AI.VoiceLive.InputModality Animation { get { throw null; } }
        public static Azure.AI.VoiceLive.InputModality Audio { get { throw null; } }
        public static Azure.AI.VoiceLive.InputModality Avatar { get { throw null; } }
        public static Azure.AI.VoiceLive.InputModality Text { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.InputModality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.InputModality left, Azure.AI.VoiceLive.InputModality right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.InputModality (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.InputModality? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.InputModality left, Azure.AI.VoiceLive.InputModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InputTextContentPart : Azure.AI.VoiceLive.UserContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTextContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTextContentPart>
    {
        public InputTextContentPart(string text) { }
        public string Text { get { throw null; } }
        protected override Azure.AI.VoiceLive.UserContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.UserContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.InputTextContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTextContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTextContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.InputTextContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTextContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTextContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTextContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTokenDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTokenDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTokenDetails>
    {
        internal InputTokenDetails() { }
        public int AudioTokens { get { throw null; } }
        public int CachedTokens { get { throw null; } }
        public int TextTokens { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.InputTokenDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.InputTokenDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.InputTokenDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTokenDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.InputTokenDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.InputTokenDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTokenDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTokenDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.InputTokenDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ItemParamStatus
    {
        Completed = 0,
        Incomplete = 1,
    }
    public partial class LogProbProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.LogProbProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.LogProbProperties>
    {
        internal LogProbProperties() { }
        public System.Collections.Generic.IList<int> Bytes { get { throw null; } }
        public float Logprob { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.LogProbProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.LogProbProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.LogProbProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.LogProbProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.LogProbProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.LogProbProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.LogProbProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.LogProbProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.LogProbProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageItem : Azure.AI.VoiceLive.ConversationRequestItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.MessageItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.MessageItem>
    {
        public MessageItem(string role) { }
        public Azure.AI.VoiceLive.ItemParamStatus? Status { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.MessageItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.MessageItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.MessageItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.MessageItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.MessageItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.MessageItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.MessageItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoTurnDetection : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.NoTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.NoTurnDetection>
    {
        public NoTurnDetection() { }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.NoTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.NoTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.NoTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.NoTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.NoTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.NoTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.NoTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OAIVoice
    {
        Alloy = 0,
        Ash = 1,
        Ballad = 2,
        Coral = 3,
        Echo = 4,
        Sage = 5,
        Shimmer = 6,
        Verse = 7,
    }
    public partial class OpenAIVoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OpenAIVoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OpenAIVoice>
    {
        public OpenAIVoice(Azure.AI.VoiceLive.OAIVoice name) { }
        public Azure.AI.VoiceLive.OAIVoice Name { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.OpenAIVoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.OpenAIVoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.OpenAIVoice System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OpenAIVoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OpenAIVoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.OpenAIVoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OpenAIVoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OpenAIVoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OpenAIVoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputTextContentPart : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTextContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTextContentPart>
    {
        public OutputTextContentPart(string text) { }
        public string Text { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.OutputTextContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.OutputTextContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.OutputTextContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTextContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTextContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.OutputTextContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTextContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTextContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTextContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputTokenDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTokenDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTokenDetails>
    {
        internal OutputTokenDetails() { }
        public int AudioTokens { get { throw null; } }
        public int TextTokens { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.OutputTokenDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.OutputTokenDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.OutputTokenDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTokenDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.OutputTokenDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.OutputTokenDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTokenDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTokenDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.OutputTokenDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum Phi4mmVoice
    {
        Cosyvoice = 0,
    }
    public partial class RequestAudioContentPart : Azure.AI.VoiceLive.VoiceLiveContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestAudioContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestAudioContentPart>
    {
        internal RequestAudioContentPart() { }
        public string Transcript { get { throw null; } }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.RequestAudioContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestAudioContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestAudioContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.RequestAudioContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestAudioContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestAudioContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestAudioContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequestSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestSession>
    {
        public RequestSession() { }
        public Azure.AI.VoiceLive.AnimationOptions Animation { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AvatarConfig Avatar { get { throw null; } set { } }
        public Azure.AI.VoiceLive.InputAudio InputAudio { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioEchoCancellation InputAudioEchoCancellation { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioFormat? InputAudioFormat { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioNoiseReduction InputAudioNoiseReduction { get { throw null; } set { } }
        public int? InputAudioSamplingRate { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioInputTranscriptionSettings InputAudioTranscription { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public int? MaxResponseOutputTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.InputModality> Modalities { get { throw null; } }
        public string Model { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioFormat? OutputAudioFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.AudioTimestampType> OutputAudioTimestampTypes { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public string ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.VoiceLiveToolDefinition> Tools { get { throw null; } }
        public Azure.AI.VoiceLive.TurnDetection TurnDetection { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VoiceType Voice { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.RequestSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.RequestSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.RequestSession System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.RequestSession System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequestTextContentPart : Azure.AI.VoiceLive.VoiceLiveContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestTextContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestTextContentPart>
    {
        internal RequestTextContentPart() { }
        public string Text { get { throw null; } }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.RequestTextContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestTextContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RequestTextContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.RequestTextContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestTextContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestTextContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RequestTextContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RespondingAgentConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RespondingAgentConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RespondingAgentConfig>
    {
        internal RespondingAgentConfig() { }
        public string AgentId { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.RespondingAgentConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.RespondingAgentConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.RespondingAgentConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RespondingAgentConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.RespondingAgentConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.RespondingAgentConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RespondingAgentConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RespondingAgentConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.RespondingAgentConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseAudioContentPart : Azure.AI.VoiceLive.VoiceLiveContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseAudioContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseAudioContentPart>
    {
        internal ResponseAudioContentPart() { }
        public string Transcript { get { throw null; } }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseAudioContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseAudioContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseAudioContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseAudioContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseAudioContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseAudioContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseAudioContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseCancelledDetails : Azure.AI.VoiceLive.ResponseStatusDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseCancelledDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseCancelledDetails>
    {
        internal ResponseCancelledDetails() { }
        public Azure.AI.VoiceLive.ResponseCancelledDetailsReason Reason { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseCancelledDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseCancelledDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseCancelledDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseCancelledDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseCancelledDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseCancelledDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseCancelledDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResponseCancelledDetailsReason
    {
        TurnDetected = 0,
        ClientCancelled = 1,
    }
    public partial class ResponseFailedDetails : Azure.AI.VoiceLive.ResponseStatusDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFailedDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFailedDetails>
    {
        internal ResponseFailedDetails() { }
        public System.BinaryData Error { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseFailedDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFailedDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFailedDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseFailedDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFailedDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFailedDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFailedDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFunctionCallItem : Azure.AI.VoiceLive.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>
    {
        internal ResponseFunctionCallItem() { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseItemStatus Status { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseFunctionCallItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseFunctionCallItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFunctionCallOutputItem : Azure.AI.VoiceLive.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>
    {
        internal ResponseFunctionCallOutputItem() { }
        public string CallId { get { throw null; } }
        public string Output { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseFunctionCallOutputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseFunctionCallOutputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseFunctionCallOutputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseIncompleteDetails : Azure.AI.VoiceLive.ResponseStatusDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>
    {
        internal ResponseIncompleteDetails() { }
        public Azure.AI.VoiceLive.ResponseIncompleteDetailsReason Reason { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseStatusDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResponseIncompleteDetailsReason
    {
        MaxOutputTokens = 0,
        ContentFilter = 1,
    }
    public abstract partial class ResponseItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseItem>
    {
        internal ResponseItem() { }
        public string Id { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseItemStatus : System.IEquatable<Azure.AI.VoiceLive.ResponseItemStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseItemStatus(string value) { throw null; }
        public static Azure.AI.VoiceLive.ResponseItemStatus Completed { get { throw null; } }
        public static Azure.AI.VoiceLive.ResponseItemStatus Incomplete { get { throw null; } }
        public static Azure.AI.VoiceLive.ResponseItemStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.ResponseItemStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.ResponseItemStatus left, Azure.AI.VoiceLive.ResponseItemStatus right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ResponseItemStatus (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ResponseItemStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.ResponseItemStatus left, Azure.AI.VoiceLive.ResponseItemStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseMessageItem : Azure.AI.VoiceLive.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseMessageItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseMessageItem>
    {
        internal ResponseMessageItem() { }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.VoiceLiveContentPart> Content { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseMessageRole Role { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseItemStatus Status { get { throw null; } }
        protected override Azure.AI.VoiceLive.ResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseMessageItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseMessageItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseMessageItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseMessageItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseMessageItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseMessageItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseMessageItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseMessageRole : System.IEquatable<Azure.AI.VoiceLive.ResponseMessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseMessageRole(string value) { throw null; }
        public static Azure.AI.VoiceLive.ResponseMessageRole Assistant { get { throw null; } }
        public static Azure.AI.VoiceLive.ResponseMessageRole System { get { throw null; } }
        public static Azure.AI.VoiceLive.ResponseMessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.ResponseMessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.ResponseMessageRole left, Azure.AI.VoiceLive.ResponseMessageRole right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ResponseMessageRole (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ResponseMessageRole? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.ResponseMessageRole left, Azure.AI.VoiceLive.ResponseMessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResponseModality
    {
        Text = 0,
        Audio = 1,
    }
    public enum ResponseOutputAudioFormat
    {
        Pcm16 = 0,
        G711Ulaw = 1,
        G711Alaw = 2,
    }
    public partial class ResponseSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseSession>
    {
        internal ResponseSession() { }
        public Azure.AI.VoiceLive.RespondingAgentConfig Agent { get { throw null; } }
        public Azure.AI.VoiceLive.AnimationOptions Animation { get { throw null; } }
        public Azure.AI.VoiceLive.AvatarConfig Avatar { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.VoiceLive.InputAudio InputAudio { get { throw null; } }
        public Azure.AI.VoiceLive.AudioEchoCancellation InputAudioEchoCancellation { get { throw null; } }
        public Azure.AI.VoiceLive.AudioFormat? InputAudioFormat { get { throw null; } }
        public Azure.AI.VoiceLive.AudioNoiseReduction InputAudioNoiseReduction { get { throw null; } }
        public int? InputAudioSamplingRate { get { throw null; } }
        public Azure.AI.VoiceLive.AudioInputTranscriptionSettings InputAudioTranscription { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.BinaryData MaxResponseOutputTokens { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.InputModality> Modalities { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.VoiceLive.AudioFormat? OutputAudioFormat { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.AudioTimestampType> OutputAudioTimestampTypes { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.VoiceLiveToolDefinition> Tools { get { throw null; } }
        public Azure.AI.VoiceLive.TurnDetection TurnDetection { get { throw null; } }
        public System.BinaryData Voice { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.ResponseSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ResponseSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseSession System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseSession System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ResponseStatusDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseStatusDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseStatusDetails>
    {
        internal ResponseStatusDetails() { }
        protected virtual Azure.AI.VoiceLive.ResponseStatusDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ResponseStatusDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseStatusDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseStatusDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseStatusDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseStatusDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseStatusDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseStatusDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseStatusDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseTextContentPart : Azure.AI.VoiceLive.VoiceLiveContentPart, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTextContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTextContentPart>
    {
        internal ResponseTextContentPart() { }
        public string Text { get { throw null; } }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.VoiceLiveContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseTextContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTextContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTextContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseTextContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTextContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTextContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTextContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseTokenStatistics : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTokenStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTokenStatistics>
    {
        internal ResponseTokenStatistics() { }
        public Azure.AI.VoiceLive.InputTokenDetails InputTokenDetails { get { throw null; } }
        public int InputTokens { get { throw null; } }
        public Azure.AI.VoiceLive.OutputTokenDetails OutputTokenDetails { get { throw null; } }
        public int OutputTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.ResponseTokenStatistics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ResponseTokenStatistics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ResponseTokenStatistics System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTokenStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ResponseTokenStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ResponseTokenStatistics System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTokenStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTokenStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ResponseTokenStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ServerEventBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventBase>
    {
        internal ServerEventBase() { }
        public virtual string EventId { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventBase System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemCreated : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>
    {
        internal ServerEventConversationItemCreated() { }
        public Azure.AI.VoiceLive.ResponseItem Item { get { throw null; } }
        public string PreviousItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemCreated System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemCreated System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemCreated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemDeleted : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>
    {
        internal ServerEventConversationItemDeleted() { }
        public override string EventId { get { throw null; } }
        public string ItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemDeleted System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemDeleted System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemDeleted>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemInputAudioTranscriptionCompleted : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>
    {
        internal ServerEventConversationItemInputAudioTranscriptionCompleted() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string Transcript { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemInputAudioTranscriptionDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>
    {
        internal ServerEventConversationItemInputAudioTranscriptionDelta() { }
        public int? ContentIndex { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.LogProbProperties> Logprobs { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemInputAudioTranscriptionFailed : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>
    {
        internal ServerEventConversationItemInputAudioTranscriptionFailed() { }
        public int ContentIndex { get { throw null; } }
        public Azure.AI.VoiceLive.VoiceLiveErrorDetails Error { get { throw null; } }
        public string ItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemRetrieved : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>
    {
        internal ServerEventConversationItemRetrieved() { }
        public override string EventId { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseItem Item { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemRetrieved System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemRetrieved System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemRetrieved>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventConversationItemTruncated : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>
    {
        internal ServerEventConversationItemTruncated() { }
        public int AudioEndMs { get { throw null; } }
        public int ContentIndex { get { throw null; } }
        public override string EventId { get { throw null; } }
        public string ItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventConversationItemTruncated System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventConversationItemTruncated System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventConversationItemTruncated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventError : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventError>
    {
        internal ServerEventError() { }
        public Azure.AI.VoiceLive.ServerEventErrorError Error { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventError System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventError System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventErrorError : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventErrorError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventErrorError>
    {
        internal ServerEventErrorError() { }
        public string Code { get { throw null; } }
        public string EventId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Param { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.ServerEventErrorError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ServerEventErrorError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventErrorError System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventErrorError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventErrorError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventErrorError System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventErrorError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventErrorError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventErrorError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventInputAudioBufferCleared : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>
    {
        internal ServerEventInputAudioBufferCleared() { }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventInputAudioBufferCommitted : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>
    {
        internal ServerEventInputAudioBufferCommitted() { }
        public string ItemId { get { throw null; } }
        public string PreviousItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventInputAudioBufferSpeechStarted : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>
    {
        internal ServerEventInputAudioBufferSpeechStarted() { }
        public int AudioStartMs { get { throw null; } }
        public string ItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventInputAudioBufferSpeechStopped : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>
    {
        internal ServerEventInputAudioBufferSpeechStopped() { }
        public int AudioEndMs { get { throw null; } }
        public string ItemId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAnimationBlendshapeDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>
    {
        internal ServerEventResponseAnimationBlendshapeDelta() { }
        public int ContentIndex { get { throw null; } }
        public int FrameIndex { get { throw null; } }
        public System.BinaryData Frames { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAnimationBlendshapeDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>
    {
        internal ServerEventResponseAnimationBlendshapeDone() { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAnimationVisemeDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>
    {
        internal ServerEventResponseAnimationVisemeDelta() { }
        public int AudioOffsetMs { get { throw null; } }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public int VisemeId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAnimationVisemeDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>
    {
        internal ServerEventResponseAnimationVisemeDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone (Azure.Response result) { throw null; }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>
    {
        internal ServerEventResponseAudioDelta() { }
        public int ContentIndex { get { throw null; } }
        public System.BinaryData Delta { get { throw null; } }
        public override string EventId { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>
    {
        internal ServerEventResponseAudioDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioTimestampDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>
    {
        internal ServerEventResponseAudioTimestampDelta() { }
        public int AudioDurationMs { get { throw null; } }
        public int AudioOffsetMs { get { throw null; } }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public string Text { get { throw null; } }
        public string TimestampType { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioTimestampDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>
    {
        internal ServerEventResponseAudioTimestampDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioTranscriptDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>
    {
        internal ServerEventResponseAudioTranscriptDelta() { }
        public int ContentIndex { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseAudioTranscriptDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>
    {
        internal ServerEventResponseAudioTranscriptDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public string Transcript { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseContentPartAdded : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>
    {
        internal ServerEventResponseContentPartAdded() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.VoiceLive.VoiceLiveContentPart Part { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseContentPartAdded System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseContentPartAdded System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartAdded>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseContentPartDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>
    {
        internal ServerEventResponseContentPartDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.VoiceLive.VoiceLiveContentPart Part { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseContentPartDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseContentPartDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseContentPartDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseCreated : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseCreated>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseCreated>
    {
        internal ServerEventResponseCreated() { }
        public Azure.AI.VoiceLive.VoiceLiveResponse Response { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseCreated System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseCreated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseCreated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseCreated System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseCreated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseCreated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseCreated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseDone>
    {
        internal ServerEventResponseDone() { }
        public Azure.AI.VoiceLive.VoiceLiveResponse Response { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseEmotionHypothesis : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>
    {
        internal ServerEventResponseEmotionHypothesis() { }
        public int AudioDurationMs { get { throw null; } }
        public int AudioOffsetMs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.EmotionCandidate> Candidates { get { throw null; } }
        public string Emotion { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseFunctionCallArgumentsDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>
    {
        internal ServerEventResponseFunctionCallArgumentsDelta() { }
        public string CallId { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseFunctionCallArgumentsDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>
    {
        internal ServerEventResponseFunctionCallArgumentsDone() { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string Name { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseOutputItemAdded : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>
    {
        internal ServerEventResponseOutputItemAdded() { }
        public Azure.AI.VoiceLive.ResponseItem Item { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseOutputItemDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>
    {
        internal ServerEventResponseOutputItemDone() { }
        public Azure.AI.VoiceLive.ResponseItem Item { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseOutputItemDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseOutputItemDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseOutputItemDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseTextDelta : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>
    {
        internal ServerEventResponseTextDelta() { }
        public int ContentIndex { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseTextDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseTextDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventResponseTextDone : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>
    {
        internal ServerEventResponseTextDone() { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public string Text { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventResponseTextDone System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventResponseTextDone System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventResponseTextDone>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventSessionAvatarConnecting : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>
    {
        internal ServerEventSessionAvatarConnecting() { }
        public string ServerSdp { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventSessionCreated : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionCreated>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionCreated>
    {
        internal ServerEventSessionCreated() { }
        public Azure.AI.VoiceLive.ResponseSession Session { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventSessionCreated System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionCreated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionCreated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventSessionCreated System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionCreated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionCreated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionCreated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEventSessionUpdated : Azure.AI.VoiceLive.ServerEventBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>
    {
        internal ServerEventSessionUpdated() { }
        public Azure.AI.VoiceLive.ResponseSession Session { get { throw null; } }
        protected override Azure.AI.VoiceLive.ServerEventBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ServerEventBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerEventSessionUpdated System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerEventSessionUpdated System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerEventSessionUpdated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerVad : Azure.AI.VoiceLive.TurnDetection, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerVad>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerVad>
    {
        public ServerVad() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        public Azure.AI.VoiceLive.EOUDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public int? PrefixPaddingMs { get { throw null; } set { } }
        public int? SilenceDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ServerVad System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerVad>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ServerVad>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ServerVad System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerVad>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerVad>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ServerVad>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionOptions
    {
        public SessionOptions() { }
        public System.Collections.Generic.IList<string> CustomVocabulary { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioEchoCancellation EchoCancellation { get { throw null; } set { } }
        public bool IncludeConfidenceScores { get { throw null; } set { } }
        public bool IncludeTimestamps { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioFormat? InputAudioFormat { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioInputTranscriptionSettings InputAudioTranscription { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public int? MaxResponseOutputTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.InputModality> Modalities { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioNoiseReduction NoiseReduction { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioFormat? OutputAudioFormat { get { throw null; } set { } }
        public bool ParallelToolCalls { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public string ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.VoiceLiveToolDefinition> Tools { get { throw null; } set { } }
        public Azure.AI.VoiceLive.TurnDetection TurnDetection { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VoiceType Voice { get { throw null; } set { } }
    }
    public partial class SystemMessageItem : Azure.AI.VoiceLive.MessageItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.SystemMessageItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.SystemMessageItem>
    {
        public SystemMessageItem(System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.InputTextContentPart> content) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.InputTextContentPart> Content { get { throw null; } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.SystemMessageItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.SystemMessageItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.SystemMessageItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.SystemMessageItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.SystemMessageItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.SystemMessageItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.SystemMessageItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceFunctionObject : Azure.AI.VoiceLive.ToolChoiceObject, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>
    {
        public ToolChoiceFunctionObject(Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction function) { }
        public Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction Function { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.ToolChoiceObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ToolChoiceObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ToolChoiceFunctionObject System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ToolChoiceFunctionObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceFunctionObjectFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>
    {
        public ToolChoiceFunctionObjectFunction(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToolChoiceLiteral : System.IEquatable<Azure.AI.VoiceLive.ToolChoiceLiteral>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToolChoiceLiteral(string value) { throw null; }
        public static Azure.AI.VoiceLive.ToolChoiceLiteral Auto { get { throw null; } }
        public static Azure.AI.VoiceLive.ToolChoiceLiteral None { get { throw null; } }
        public static Azure.AI.VoiceLive.ToolChoiceLiteral Required { get { throw null; } }
        public bool Equals(Azure.AI.VoiceLive.ToolChoiceLiteral other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.VoiceLive.ToolChoiceLiteral left, Azure.AI.VoiceLive.ToolChoiceLiteral right) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ToolChoiceLiteral (string value) { throw null; }
        public static implicit operator Azure.AI.VoiceLive.ToolChoiceLiteral? (string value) { throw null; }
        public static bool operator !=(Azure.AI.VoiceLive.ToolChoiceLiteral left, Azure.AI.VoiceLive.ToolChoiceLiteral right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ToolChoiceObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceObject>
    {
        internal ToolChoiceObject() { }
        protected virtual Azure.AI.VoiceLive.ToolChoiceObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.ToolChoiceObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.ToolChoiceObject System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.ToolChoiceObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.ToolChoiceObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.ToolChoiceObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TurnDetection : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.TurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.TurnDetection>
    {
        internal TurnDetection() { }
        protected virtual Azure.AI.VoiceLive.TurnDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.TurnDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.TurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.TurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.TurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.TurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.TurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.TurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.TurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class UserContentPart : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserContentPart>
    {
        internal UserContentPart() { }
        protected virtual Azure.AI.VoiceLive.UserContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.UserContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.UserContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.UserContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserMessageItem : Azure.AI.VoiceLive.MessageItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserMessageItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserMessageItem>
    {
        public UserMessageItem(System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.UserContentPart> content) : base (default(string)) { }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.UserContentPart> Content { get { throw null; } }
        protected override Azure.AI.VoiceLive.ConversationRequestItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.ConversationRequestItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.UserMessageItem System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserMessageItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.UserMessageItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.UserMessageItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserMessageItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserMessageItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.UserMessageItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoCrop : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoCrop>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoCrop>
    {
        public VideoCrop(System.Collections.Generic.IEnumerable<int> topLeftInternal, System.Collections.Generic.IEnumerable<int> bottomRightInternal) { }
        public VideoCrop(System.Drawing.Point topLeft, System.Drawing.Point bottomRight) { }
        public System.Drawing.Point BottomRight { get { throw null; } set { } }
        public System.Drawing.Point TopLeft { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.VideoCrop JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VideoCrop PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VideoCrop System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoCrop>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoCrop>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VideoCrop System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoCrop>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoCrop>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoCrop>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoParams>
    {
        public VideoParams() { }
        public int? Bitrate { get { throw null; } set { } }
        public string Codec { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VideoCrop Crop { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VideoResolution Resolution { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.VideoParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VideoParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VideoParams System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VideoParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VideoResolution : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoResolution>
    {
        public VideoResolution(int width, int height) { }
        public int Height { get { throw null; } set { } }
        public int Width { get { throw null; } set { } }
        protected virtual Azure.AI.VoiceLive.VideoResolution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VideoResolution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VideoResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VideoResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VideoResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VideoResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceLiveClient
    {
        protected VoiceLiveClient() { }
        public VoiceLiveClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public VoiceLiveClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.VoiceLive.VoiceLiveClientOptions options) { }
        public VoiceLiveClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public VoiceLiveClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.VoiceLive.VoiceLiveClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.VoiceLive.VoiceLiveSession StartSession(Azure.AI.VoiceLive.RequestSession sessionConfig, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.VoiceLive.VoiceLiveSession StartSession(string model, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.VoiceLive.VoiceLiveSession> StartSessionAsync(Azure.AI.VoiceLive.RequestSession sessionConfig, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.VoiceLive.VoiceLiveSession> StartSessionAsync(string model, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VoiceLiveClientOptions : Azure.Core.ClientOptions
    {
        public VoiceLiveClientOptions(Azure.AI.VoiceLive.VoiceLiveClientOptions.ServiceVersion version = Azure.AI.VoiceLive.VoiceLiveClientOptions.ServiceVersion.V2025_05_01_Preview) { }
        public enum ServiceVersion
        {
            V2025_05_01_Preview = 1,
        }
    }
    public abstract partial class VoiceLiveContentPart : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveContentPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveContentPart>
    {
        internal VoiceLiveContentPart() { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveContentPart JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveContentPart PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VoiceLiveContentPart System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveContentPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveContentPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VoiceLiveContentPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveContentPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveContentPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveContentPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceLiveErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>
    {
        internal VoiceLiveErrorDetails() { }
        public string Code { get { throw null; } }
        public string EventId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Param { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.VoiceLiveErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VoiceLiveErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VoiceLiveErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VoiceLiveFunctionDefinition : Azure.AI.VoiceLive.VoiceLiveToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>
    {
        public VoiceLiveFunctionDefinition(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected override Azure.AI.VoiceLive.VoiceLiveToolDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.VoiceLive.VoiceLiveToolDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VoiceLiveFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VoiceLiveFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class VoiceLiveModelFactory
    {
        public static Azure.AI.VoiceLive.AnimationOptions AnimationOptions(string modelName = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.AnimationOutputType> outputs = null, int? emotionDetectionIntervalMs = default(int?)) { throw null; }
        public static Azure.AI.VoiceLive.AssistantMessageItem AssistantMessageItem(string id = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?), System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.OutputTextContentPart> content = null) { throw null; }
        public static Azure.AI.VoiceLive.AudioEchoCancellation AudioEchoCancellation(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.AudioInputTranscriptionSettings AudioInputTranscriptionSettings(Azure.AI.VoiceLive.AudioInputTranscriptionSettingsModel model = Azure.AI.VoiceLive.AudioInputTranscriptionSettingsModel.Whisper1, string language = null, bool enabled = false, bool customModel = false) { throw null; }
        public static Azure.AI.VoiceLive.AudioNoiseReduction AudioNoiseReduction(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.AvatarConfig AvatarConfig(System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.IceServer> iceServers = null, string character = null, string style = null, bool customized = false, Azure.AI.VoiceLive.VideoParams video = null) { throw null; }
        public static Azure.AI.VoiceLive.AzureCustomVoice AzureCustomVoice(string name = null, string endpointId = null, float? temperature = default(float?), string customLexiconUri = null, System.Collections.Generic.IEnumerable<string> preferLocales = null, string locale = null, string style = null, string pitch = null, string rate = null, string volume = null) { throw null; }
        public static Azure.AI.VoiceLive.AzureMultilingualSemanticVad AzureMultilingualSemanticVad(float? threshold = default(float?), int? prefixPaddingMs = default(int?), int? silenceDurationMs = default(int?), Azure.AI.VoiceLive.EOUDetection endOfUtteranceDetection = null, float? negThreshold = default(float?), int? speechDurationMs = default(int?), int? windowSize = default(int?), int? distinctCiPhones = default(int?), bool? requireVowel = default(bool?), bool? removeFillerWords = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null, bool? autoTruncate = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzurePersonalVoice AzurePersonalVoice(string name = null, float? temperature = default(float?), Azure.AI.VoiceLive.AzurePersonalVoiceModel model = Azure.AI.VoiceLive.AzurePersonalVoiceModel.DragonLatestNeural) { throw null; }
        public static Azure.AI.VoiceLive.AzurePlatformVoice AzurePlatformVoice(string name = null, float? temperature = default(float?), string customLexiconUrl = null, System.Collections.Generic.IEnumerable<string> preferLocales = null, string locale = null, string style = null, string pitch = null, string rate = null, string volume = null) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticDetection AzureSemanticDetection(float? threshold = default(float?), float? timeout = default(float?), float? secondaryThreshold = default(float?), float? secondaryTimeout = default(float?), bool? disableRules = default(bool?), float? srBoost = default(float?), bool? extraImendCheck = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticDetectionEn AzureSemanticDetectionEn(float? threshold = default(float?), float? timeout = default(float?), float? secondaryThreshold = default(float?), float? secondaryTimeout = default(float?), bool? disableRules = default(bool?), float? srBoost = default(float?), bool? extraImendCheck = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticDetectionMultilingual AzureSemanticDetectionMultilingual(float? threshold = default(float?), float? timeout = default(float?), float? secondaryThreshold = default(float?), float? secondaryTimeout = default(float?), bool? disableRules = default(bool?), float? srBoost = default(float?), bool? extraImendCheck = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticVad AzureSemanticVad(float? threshold = default(float?), int? prefixPaddingMs = default(int?), int? silenceDurationMs = default(int?), Azure.AI.VoiceLive.EOUDetection endOfUtteranceDetection = null, float? negThreshold = default(float?), int? speechDurationMs = default(int?), int? windowSize = default(int?), int? distinctCiPhones = default(int?), bool? requireVowel = default(bool?), bool? removeFillerWords = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null, bool? autoTruncate = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticVadEn AzureSemanticVadEn(float? threshold = default(float?), int? prefixPaddingMs = default(int?), int? silenceDurationMs = default(int?), Azure.AI.VoiceLive.EOUDetection endOfUtteranceDetection = null, float? negThreshold = default(float?), int? speechDurationMs = default(int?), int? windowSize = default(int?), int? distinctCiPhones = default(int?), bool? requireVowel = default(bool?), bool? removeFillerWords = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null, bool? autoTruncate = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureSemanticVadServer AzureSemanticVadServer(float? threshold = default(float?), int? prefixPaddingMs = default(int?), int? silenceDurationMs = default(int?), Azure.AI.VoiceLive.EOUDetection endOfUtteranceDetection = null, float? negThreshold = default(float?), int? speechDurationMs = default(int?), int? windowSize = default(int?), int? distinctCiPhones = default(int?), bool? requireVowel = default(bool?), bool? removeFillerWords = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null, bool? autoTruncate = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.AzureStandardVoice AzureStandardVoice(string name = null, float? temperature = default(float?), string customLexiconUrl = null, System.Collections.Generic.IEnumerable<string> preferLocales = null, string locale = null, string style = null, string pitch = null, string rate = null, string volume = null) { throw null; }
        public static Azure.AI.VoiceLive.AzureVoice AzureVoice(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.ConversationRequestItem ConversationRequestItem(string type = null, string id = null) { throw null; }
        public static Azure.AI.VoiceLive.EmotionCandidate EmotionCandidate(string emotion = null, float confidence = 0f) { throw null; }
        public static Azure.AI.VoiceLive.EOUDetection EOUDetection(string model = null) { throw null; }
        public static Azure.AI.VoiceLive.FunctionCallItem FunctionCallItem(string id = null, string name = null, string callId = null, string arguments = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?)) { throw null; }
        public static Azure.AI.VoiceLive.FunctionCallOutputItem FunctionCallOutputItem(string id = null, string callId = null, string output = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?)) { throw null; }
        public static Azure.AI.VoiceLive.IceServer IceServer(System.Collections.Generic.IEnumerable<System.Uri> uris = null, string username = null, string credential = null) { throw null; }
        public static Azure.AI.VoiceLive.InputAudio InputAudio(string model = null, System.Collections.Generic.IEnumerable<string> phraseList = null) { throw null; }
        public static Azure.AI.VoiceLive.InputAudioContentPart InputAudioContentPart(string audio = null, string transcript = null) { throw null; }
        public static Azure.AI.VoiceLive.InputTextContentPart InputTextContentPart(string text = null) { throw null; }
        public static Azure.AI.VoiceLive.InputTokenDetails InputTokenDetails(int cachedTokens = 0, int textTokens = 0, int audioTokens = 0) { throw null; }
        public static Azure.AI.VoiceLive.LogProbProperties LogProbProperties(string token = null, float logprob = 0f, System.Collections.Generic.IEnumerable<int> bytes = null) { throw null; }
        public static Azure.AI.VoiceLive.MessageItem MessageItem(string id = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?)) { throw null; }
        public static Azure.AI.VoiceLive.NoTurnDetection NoTurnDetection() { throw null; }
        public static Azure.AI.VoiceLive.OpenAIVoice OpenAIVoice(string type = null, Azure.AI.VoiceLive.OAIVoice name = Azure.AI.VoiceLive.OAIVoice.Alloy) { throw null; }
        public static Azure.AI.VoiceLive.OutputTextContentPart OutputTextContentPart(string type = null, string text = null) { throw null; }
        public static Azure.AI.VoiceLive.OutputTokenDetails OutputTokenDetails(int textTokens = 0, int audioTokens = 0) { throw null; }
        public static Azure.AI.VoiceLive.RequestAudioContentPart RequestAudioContentPart(string transcript = null) { throw null; }
        public static Azure.AI.VoiceLive.RequestSession RequestSession(string model = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.InputModality> modalities = null, Azure.AI.VoiceLive.AnimationOptions animation = null, string instructions = null, Azure.AI.VoiceLive.InputAudio inputAudio = null, int? inputAudioSamplingRate = default(int?), Azure.AI.VoiceLive.AudioFormat? inputAudioFormat = default(Azure.AI.VoiceLive.AudioFormat?), Azure.AI.VoiceLive.AudioFormat? outputAudioFormat = default(Azure.AI.VoiceLive.AudioFormat?), Azure.AI.VoiceLive.TurnDetection turnDetection = null, Azure.AI.VoiceLive.AudioNoiseReduction inputAudioNoiseReduction = null, Azure.AI.VoiceLive.AudioEchoCancellation inputAudioEchoCancellation = null, Azure.AI.VoiceLive.AvatarConfig avatar = null, Azure.AI.VoiceLive.AudioInputTranscriptionSettings inputAudioTranscription = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.AudioTimestampType> outputAudioTimestampTypes = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.VoiceLiveToolDefinition> tools = null, float? temperature = default(float?), System.BinaryData serviceVoice = null, System.BinaryData maxResponseOutputTokens = null, System.BinaryData toolChoice = null) { throw null; }
        public static Azure.AI.VoiceLive.RequestTextContentPart RequestTextContentPart(string text = null) { throw null; }
        public static Azure.AI.VoiceLive.RespondingAgentConfig RespondingAgentConfig(string type = null, string name = null, string description = null, string agentId = null, string threadId = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseAudioContentPart ResponseAudioContentPart(string transcript = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseCancelledDetails ResponseCancelledDetails(Azure.AI.VoiceLive.ResponseCancelledDetailsReason reason = Azure.AI.VoiceLive.ResponseCancelledDetailsReason.TurnDetected) { throw null; }
        public static Azure.AI.VoiceLive.ResponseFailedDetails ResponseFailedDetails(System.BinaryData error = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseFunctionCallItem ResponseFunctionCallItem(string id = null, string @object = null, string name = null, string callId = null, string arguments = null, Azure.AI.VoiceLive.ResponseItemStatus status = default(Azure.AI.VoiceLive.ResponseItemStatus)) { throw null; }
        public static Azure.AI.VoiceLive.ResponseFunctionCallOutputItem ResponseFunctionCallOutputItem(string id = null, string @object = null, string callId = null, string output = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseIncompleteDetails ResponseIncompleteDetails(Azure.AI.VoiceLive.ResponseIncompleteDetailsReason reason = Azure.AI.VoiceLive.ResponseIncompleteDetailsReason.MaxOutputTokens) { throw null; }
        public static Azure.AI.VoiceLive.ResponseItem ResponseItem(string type = null, string id = null, string @object = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseMessageItem ResponseMessageItem(string id = null, string @object = null, Azure.AI.VoiceLive.ResponseMessageRole role = default(Azure.AI.VoiceLive.ResponseMessageRole), System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.VoiceLiveContentPart> content = null, Azure.AI.VoiceLive.ResponseItemStatus status = default(Azure.AI.VoiceLive.ResponseItemStatus)) { throw null; }
        public static Azure.AI.VoiceLive.ResponseSession ResponseSession(string id = null, string model = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.InputModality> modalities = null, string instructions = null, Azure.AI.VoiceLive.AnimationOptions animation = null, System.BinaryData voice = null, Azure.AI.VoiceLive.InputAudio inputAudio = null, Azure.AI.VoiceLive.AudioFormat? inputAudioFormat = default(Azure.AI.VoiceLive.AudioFormat?), Azure.AI.VoiceLive.AudioFormat? outputAudioFormat = default(Azure.AI.VoiceLive.AudioFormat?), int? inputAudioSamplingRate = default(int?), Azure.AI.VoiceLive.TurnDetection turnDetection = null, Azure.AI.VoiceLive.AudioNoiseReduction inputAudioNoiseReduction = null, Azure.AI.VoiceLive.AudioEchoCancellation inputAudioEchoCancellation = null, Azure.AI.VoiceLive.AvatarConfig avatar = null, Azure.AI.VoiceLive.AudioInputTranscriptionSettings inputAudioTranscription = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.AudioTimestampType> outputAudioTimestampTypes = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.VoiceLiveToolDefinition> tools = null, System.BinaryData toolChoice = null, float? temperature = default(float?), System.BinaryData maxResponseOutputTokens = null, Azure.AI.VoiceLive.RespondingAgentConfig agent = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseStatusDetails ResponseStatusDetails(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseTextContentPart ResponseTextContentPart(string text = null) { throw null; }
        public static Azure.AI.VoiceLive.ResponseTokenStatistics ResponseTokenStatistics(int totalTokens = 0, int inputTokens = 0, int outputTokens = 0, Azure.AI.VoiceLive.InputTokenDetails inputTokenDetails = null, Azure.AI.VoiceLive.OutputTokenDetails outputTokenDetails = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventBase ServerEventBase(string type = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemCreated ServerEventConversationItemCreated(string eventId = null, string previousItemId = null, Azure.AI.VoiceLive.ResponseItem item = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemDeleted ServerEventConversationItemDeleted(string itemId = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionCompleted ServerEventConversationItemInputAudioTranscriptionCompleted(string eventId = null, string itemId = null, int contentIndex = 0, string transcript = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionDelta ServerEventConversationItemInputAudioTranscriptionDelta(string eventId = null, string itemId = null, int? contentIndex = default(int?), string delta = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.LogProbProperties> logprobs = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemInputAudioTranscriptionFailed ServerEventConversationItemInputAudioTranscriptionFailed(string eventId = null, string itemId = null, int contentIndex = 0, Azure.AI.VoiceLive.VoiceLiveErrorDetails error = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemRetrieved ServerEventConversationItemRetrieved(Azure.AI.VoiceLive.ResponseItem item = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventConversationItemTruncated ServerEventConversationItemTruncated(string itemId = null, int contentIndex = 0, int audioEndMs = 0, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventError ServerEventError(string eventId = null, Azure.AI.VoiceLive.ServerEventErrorError error = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventErrorError ServerEventErrorError(string type = null, string code = null, string message = null, string param = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventInputAudioBufferCleared ServerEventInputAudioBufferCleared(string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventInputAudioBufferCommitted ServerEventInputAudioBufferCommitted(string eventId = null, string previousItemId = null, string itemId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStarted ServerEventInputAudioBufferSpeechStarted(string eventId = null, int audioStartMs = 0, string itemId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventInputAudioBufferSpeechStopped ServerEventInputAudioBufferSpeechStopped(string eventId = null, int audioEndMs = 0, string itemId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDelta ServerEventResponseAnimationBlendshapeDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, System.BinaryData frames = null, int frameIndex = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAnimationBlendshapeDone ServerEventResponseAnimationBlendshapeDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDelta ServerEventResponseAnimationVisemeDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, int audioOffsetMs = 0, int visemeId = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAnimationVisemeDone ServerEventResponseAnimationVisemeDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioDelta ServerEventResponseAudioDelta(string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, System.BinaryData delta = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioDone ServerEventResponseAudioDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDelta ServerEventResponseAudioTimestampDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, int audioOffsetMs = 0, int audioDurationMs = 0, string text = null, string timestampType = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioTimestampDone ServerEventResponseAudioTimestampDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDelta ServerEventResponseAudioTranscriptDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, string delta = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseAudioTranscriptDone ServerEventResponseAudioTranscriptDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, string transcript = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseContentPartAdded ServerEventResponseContentPartAdded(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, Azure.AI.VoiceLive.VoiceLiveContentPart part = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseContentPartDone ServerEventResponseContentPartDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, Azure.AI.VoiceLive.VoiceLiveContentPart part = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseCreated ServerEventResponseCreated(string eventId = null, Azure.AI.VoiceLive.VoiceLiveResponse response = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseDone ServerEventResponseDone(string eventId = null, Azure.AI.VoiceLive.VoiceLiveResponse response = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseEmotionHypothesis ServerEventResponseEmotionHypothesis(string eventId = null, string emotion = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.EmotionCandidate> candidates = null, int audioOffsetMs = 0, int audioDurationMs = 0, string responseId = null, string itemId = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDelta ServerEventResponseFunctionCallArgumentsDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, string callId = null, string delta = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseFunctionCallArgumentsDone ServerEventResponseFunctionCallArgumentsDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, string callId = null, string arguments = null, string name = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseOutputItemAdded ServerEventResponseOutputItemAdded(string eventId = null, string responseId = null, int outputIndex = 0, Azure.AI.VoiceLive.ResponseItem item = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseOutputItemDone ServerEventResponseOutputItemDone(string eventId = null, string responseId = null, int outputIndex = 0, Azure.AI.VoiceLive.ResponseItem item = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseTextDelta ServerEventResponseTextDelta(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, string delta = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventResponseTextDone ServerEventResponseTextDone(string eventId = null, string responseId = null, string itemId = null, int outputIndex = 0, int contentIndex = 0, string text = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventSessionAvatarConnecting ServerEventSessionAvatarConnecting(string eventId = null, string serverSdp = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventSessionCreated ServerEventSessionCreated(string eventId = null, Azure.AI.VoiceLive.ResponseSession session = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerEventSessionUpdated ServerEventSessionUpdated(string eventId = null, Azure.AI.VoiceLive.ResponseSession session = null) { throw null; }
        public static Azure.AI.VoiceLive.ServerVad ServerVad(float? threshold = default(float?), int? prefixPaddingMs = default(int?), int? silenceDurationMs = default(int?), Azure.AI.VoiceLive.EOUDetection endOfUtteranceDetection = null, bool? autoTruncate = default(bool?)) { throw null; }
        public static Azure.AI.VoiceLive.SystemMessageItem SystemMessageItem(string id = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?), System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.InputTextContentPart> content = null) { throw null; }
        public static Azure.AI.VoiceLive.ToolChoiceFunctionObject ToolChoiceFunctionObject(Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction function = null) { throw null; }
        public static Azure.AI.VoiceLive.ToolChoiceFunctionObjectFunction ToolChoiceFunctionObjectFunction(string name = null) { throw null; }
        public static Azure.AI.VoiceLive.ToolChoiceObject ToolChoiceObject(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.TurnDetection TurnDetection(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.UserContentPart UserContentPart(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.UserMessageItem UserMessageItem(string id = null, Azure.AI.VoiceLive.ItemParamStatus? status = default(Azure.AI.VoiceLive.ItemParamStatus?), System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.UserContentPart> content = null) { throw null; }
        public static Azure.AI.VoiceLive.VideoCrop VideoCrop(System.Collections.Generic.IEnumerable<int> topLeftInternal = null, System.Collections.Generic.IEnumerable<int> bottomRightInternal = null) { throw null; }
        public static Azure.AI.VoiceLive.VideoParams VideoParams(int? bitrate = default(int?), string codec = null, Azure.AI.VoiceLive.VideoCrop crop = null, Azure.AI.VoiceLive.VideoResolution resolution = null) { throw null; }
        public static Azure.AI.VoiceLive.VideoResolution VideoResolution(int width = 0, int height = 0) { throw null; }
        public static Azure.AI.VoiceLive.VoiceLiveContentPart VoiceLiveContentPart(string type = null) { throw null; }
        public static Azure.AI.VoiceLive.VoiceLiveErrorDetails VoiceLiveErrorDetails(string code = null, string message = null, string param = null, string type = null, string eventId = null) { throw null; }
        public static Azure.AI.VoiceLive.VoiceLiveFunctionDefinition VoiceLiveFunctionDefinition(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.VoiceLive.VoiceLiveResponse VoiceLiveResponse(string id = null, string @object = null, Azure.AI.VoiceLive.VoiceLiveResponseStatus? status = default(Azure.AI.VoiceLive.VoiceLiveResponseStatus?), Azure.AI.VoiceLive.ResponseStatusDetails statusDetails = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.ResponseItem> output = null, Azure.AI.VoiceLive.ResponseTokenStatistics usage = null, string conversationId = null, System.BinaryData voice = null, System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.ResponseModality> modalities = null, Azure.AI.VoiceLive.ResponseOutputAudioFormat? outputAudioFormat = default(Azure.AI.VoiceLive.ResponseOutputAudioFormat?), float? temperature = default(float?), System.BinaryData maxOutputTokens = null) { throw null; }
        public static Azure.AI.VoiceLive.VoiceLiveToolDefinition VoiceLiveToolDefinition(string type = null) { throw null; }
    }
    public partial class VoiceLiveResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveResponse>
    {
        internal VoiceLiveResponse() { }
        public string ConversationId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData MaxOutputTokens { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.ResponseModality> Modalities { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.ResponseItem> Output { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseOutputAudioFormat? OutputAudioFormat { get { throw null; } }
        public Azure.AI.VoiceLive.VoiceLiveResponseStatus? Status { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseStatusDetails StatusDetails { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.VoiceLive.ResponseTokenStatistics Usage { get { throw null; } }
        public System.BinaryData Voice { get { throw null; } }
        protected virtual Azure.AI.VoiceLive.VoiceLiveResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VoiceLiveResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VoiceLiveResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VoiceLiveResponseStatus
    {
        Completed = 0,
        Cancelled = 1,
        Failed = 2,
        Incomplete = 3,
        InProgress = 4,
    }
    public partial class VoiceLiveSession : System.IAsyncDisposable, System.IDisposable
    {
        protected internal VoiceLiveSession(Azure.AI.VoiceLive.VoiceLiveClient parentClient, System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public System.Net.WebSockets.WebSocketState ConnectionState { get { throw null; } }
        public bool IsConnected { get { throw null; } }
        public System.Net.WebSockets.WebSocket WebSocket { get { throw null; } protected set { } }
        public virtual void AddItem(Azure.AI.VoiceLive.ConversationRequestItem item, string previousItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void AddItem(Azure.AI.VoiceLive.ConversationRequestItem item, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task AddItemAsync(Azure.AI.VoiceLive.ConversationRequestItem item, string previousItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task AddItemAsync(Azure.AI.VoiceLive.ConversationRequestItem item, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void AppendAudioToTurn(string turnId, System.BinaryData audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void AppendAudioToTurn(string turnId, byte[] audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task AppendAudioToTurnAsync(string turnId, System.BinaryData audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task AppendAudioToTurnAsync(string turnId, byte[] audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void CancelAudioTurn(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelAudioTurnAsync(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void CancelResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CancelResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ClearInputAudio(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ClearInputAudioAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ClearStreamingAudio(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ClearStreamingAudioAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void Close(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void CommitInputAudio(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task CommitInputAudioAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ConfigureConversationSession(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ConfigureConversationSessionAsync(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ConfigureSession(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ConfigureSessionAsync(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ConfigureTranscriptionSession(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ConfigureTranscriptionSessionAsync(Azure.AI.VoiceLive.SessionOptions sessionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected internal virtual void Connect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        protected internal virtual System.Threading.Tasks.Task ConnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void ConnectAvatar(string clientSdp, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task ConnectAvatarAsync(string clientSdp, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void DeleteItem(string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task DeleteItemAsync(string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        protected virtual System.Threading.Tasks.ValueTask DisposeAsyncCore() { throw null; }
        public virtual void EndAudioTurn(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task EndAudioTurnAsync(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<Azure.AI.VoiceLive.ServerEventBase> GetUpdates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.VoiceLive.ServerEventBase> GetUpdatesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<T> GetUpdatesAsync<T>([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.AI.VoiceLive.ServerEventBase { throw null; }
        public virtual System.Collections.Generic.IEnumerable<System.BinaryData> ReceiveUpdates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<System.BinaryData> ReceiveUpdatesAsync([System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void RequestItemRetrieval(string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task RequestItemRetrievalAsync(string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void SendCommand(System.BinaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task SendCommandAsync(Azure.Core.RequestContent data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendCommandAsync(System.BinaryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void SendInputAudio(System.BinaryData audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void SendInputAudio(byte[] audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void SendInputAudio(System.IO.Stream audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task SendInputAudioAsync(System.BinaryData audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendInputAudioAsync(byte[] audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendInputAudioAsync(System.IO.Stream audio, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void StartAudioTurn(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StartAudioTurnAsync(string turnId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void StartResponse(Azure.AI.VoiceLive.VoiceLiveSessionOptions responseOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void StartResponse(string additionalInstructions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual void StartResponse(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task StartResponseAsync(Azure.AI.VoiceLive.VoiceLiveSessionOptions responseOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StartResponseAsync(string additionalInstructions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task StartResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void TruncateConversation(string itemId, int contentIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public virtual System.Threading.Tasks.Task TruncateConversationAsync(string itemId, int contentIndex, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Threading.Tasks.Task<T> WaitForUpdateAsync<T>(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) where T : Azure.AI.VoiceLive.ServerEventBase { throw null; }
    }
    public partial class VoiceLiveSessionOptions
    {
        public VoiceLiveSessionOptions() { }
        public bool? CancelPrevious { get { throw null; } set { } }
        public bool? Commit { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public int? MaxOutputTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.InputModality> Modalities { get { throw null; } set { } }
        public Azure.AI.VoiceLive.AudioFormat? OutputAudioFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public string ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.VoiceLive.VoiceLiveToolDefinition> Tools { get { throw null; } set { } }
        public Azure.AI.VoiceLive.VoiceType Voice { get { throw null; } set { } }
    }
    public abstract partial class VoiceLiveToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>
    {
        internal VoiceLiveToolDefinition() { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveToolDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.VoiceLive.VoiceLiveToolDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.VoiceLive.VoiceLiveToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.VoiceLive.VoiceLiveToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.VoiceLive.VoiceLiveToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VoiceType
    {
        protected VoiceType() { }
        internal abstract System.BinaryData ToBinaryData();
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class VoiceLiveClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.VoiceLive.VoiceLiveClient, Azure.AI.VoiceLive.VoiceLiveClientOptions> AddVoiceLiveClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
