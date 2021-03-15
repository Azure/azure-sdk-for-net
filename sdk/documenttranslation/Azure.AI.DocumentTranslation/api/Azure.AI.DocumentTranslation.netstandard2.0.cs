namespace Azure.AI.DocumentTranslation.Models
{
    public partial class DocumentFilter
    {
        public DocumentFilter() { }
        public string Prefix { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DocumentStatusDetail
    {
        internal DocumentStatusDetail() { }
        public long? CharacterCharged { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.TranslationStatus Status { get { throw null; } }
        public string TranslateTo { get { throw null; } }
        public float TranslationProgress { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class DocumentTranslationError
    {
        internal DocumentTranslationError() { }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode? Code { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DocumentTranslationErrorCode : System.IEquatable<Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DocumentTranslationErrorCode(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InternalServerError { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InvalidArgument { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode InvalidRequest { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode RequestRateTooHigh { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode ResourceNotFound { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode ServiceUnavailable { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode Unauthorized { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode left, Azure.AI.DocumentTranslation.Models.DocumentTranslationErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DocumentTranslationInnerError
    {
        internal DocumentTranslationInnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationInnerError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageSource : System.IEquatable<Azure.AI.DocumentTranslation.Models.StorageSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageSource(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.StorageSource AzureBlob { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.StorageSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.StorageSource left, Azure.AI.DocumentTranslation.Models.StorageSource right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.StorageSource (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.StorageSource left, Azure.AI.DocumentTranslation.Models.StorageSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.AI.DocumentTranslation.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.StorageType File { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.StorageType Folder { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.StorageType left, Azure.AI.DocumentTranslation.Models.StorageType right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.StorageType left, Azure.AI.DocumentTranslation.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationConfiguration
    {
        public TranslationConfiguration(Azure.AI.DocumentTranslation.Models.TranslationSource source, System.Collections.Generic.IEnumerable<Azure.AI.DocumentTranslation.Models.TranslationTarget> targets) { }
        public Azure.AI.DocumentTranslation.Models.TranslationSource Source { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.StorageType? StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.Models.TranslationTarget> Targets { get { throw null; } }
    }
    public partial class TranslationGlossary
    {
        public TranslationGlossary(System.Uri glossaryUrl) { }
        public string FormatVersion { get { throw null; } set { } }
        public System.Uri GlossaryUrl { get { throw null; } }
        public string Version { get { throw null; } set { } }
    }
    public partial class TranslationSource
    {
        public TranslationSource(System.Uri sourceUrl) { }
        public Azure.AI.DocumentTranslation.Models.DocumentFilter Filter { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public System.Uri SourceUrl { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TranslationStatus : System.IEquatable<Azure.AI.DocumentTranslation.Models.TranslationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TranslationStatus(string value) { throw null; }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Cancelled { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Cancelling { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Failed { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus NotStarted { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Running { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus Succeeded { get { throw null; } }
        public static Azure.AI.DocumentTranslation.Models.TranslationStatus ValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.DocumentTranslation.Models.TranslationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.DocumentTranslation.Models.TranslationStatus left, Azure.AI.DocumentTranslation.Models.TranslationStatus right) { throw null; }
        public static implicit operator Azure.AI.DocumentTranslation.Models.TranslationStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.DocumentTranslation.Models.TranslationStatus left, Azure.AI.DocumentTranslation.Models.TranslationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TranslationStatusDetail
    {
        internal TranslationStatusDetail() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public int DocumentsCancelled { get { throw null; } }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsInProgress { get { throw null; } }
        public int DocumentsNotStarted { get { throw null; } }
        public int DocumentsSucceeded { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.DocumentTranslationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
        public Azure.AI.DocumentTranslation.Models.TranslationStatus Status { get { throw null; } }
        public long TotalCharacterCharged { get { throw null; } }
    }
    public partial class TranslationTarget
    {
        public TranslationTarget(System.Uri targetUrl, string language) { }
        public TranslationTarget(System.Uri targetUrl, string language, System.Collections.Generic.IList<Azure.AI.DocumentTranslation.Models.TranslationGlossary> glossaries) { }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.DocumentTranslation.Models.TranslationGlossary> Glossaries { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Uri TargetUrl { get { throw null; } }
    }
}
