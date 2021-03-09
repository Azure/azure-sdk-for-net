namespace Azure.Containers.ContainerRegistry
{
    public partial class AccessToken
    {
        internal AccessToken() { }
        public string AccessTokenValue { get { throw null; } }
    }
    public partial class AcrManifests
    {
        internal AcrManifests() { }
        public string ImageName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerRegistry.ManifestAttributesBase> ManifestsAttributes { get { throw null; } }
        public string Registry { get { throw null; } }
    }
    public partial class Annotations : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public Annotations() { }
        public string Authors { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Documentation { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string Licenses { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Revision { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public string Vendor { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class ChangeableAttributes
    {
        public ChangeableAttributes() { }
        public bool? DeleteEnabled { get { throw null; } set { } }
        public bool? ListEnabled { get { throw null; } set { } }
        public bool? ReadEnabled { get { throw null; } set { } }
        public bool? WriteEnabled { get { throw null; } set { } }
    }
    public partial class DeletedRepository
    {
        internal DeletedRepository() { }
        public System.Collections.Generic.IReadOnlyList<string> ManifestsDeleted { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TagsDeleted { get { throw null; } }
    }
    public partial class Descriptor
    {
        public Descriptor() { }
        public Azure.Containers.ContainerRegistry.Annotations Annotations { get { throw null; } set { } }
        public string Digest { get { throw null; } set { } }
        public string MediaType { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Urls { get { throw null; } }
    }
    public partial class FsLayer
    {
        public FsLayer() { }
        public string BlobSum { get { throw null; } set { } }
    }
    public partial class History
    {
        public History() { }
        public string V1Compatibility { get { throw null; } set { } }
    }
    public partial class ImageSignature
    {
        public ImageSignature() { }
        public Azure.Containers.ContainerRegistry.JWK Header { get { throw null; } set { } }
        public string Protected { get { throw null; } set { } }
        public string Signature { get { throw null; } set { } }
    }
    public partial class JWK
    {
        public JWK() { }
        public string Alg { get { throw null; } set { } }
        public Azure.Containers.ContainerRegistry.JWKHeader Jwk { get { throw null; } set { } }
    }
    public partial class JWKHeader
    {
        public JWKHeader() { }
        public string Crv { get { throw null; } set { } }
        public string Kid { get { throw null; } set { } }
        public string Kty { get { throw null; } set { } }
        public string X { get { throw null; } set { } }
        public string Y { get { throw null; } set { } }
    }
    public partial class Manifest
    {
        public Manifest() { }
        public int? SchemaVersion { get { throw null; } set { } }
    }
    public partial class ManifestAttributes
    {
        internal ManifestAttributes() { }
        public Azure.Containers.ContainerRegistry.ManifestAttributesBase Attributes { get { throw null; } }
        public string ImageName { get { throw null; } }
        public string Registry { get { throw null; } }
    }
    public partial class ManifestAttributesBase
    {
        internal ManifestAttributesBase() { }
        public string Architecture { get { throw null; } }
        public Azure.Containers.ContainerRegistry.ChangeableAttributes ChangeableAttributes { get { throw null; } }
        public string ConfigMediaType { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string Digest { get { throw null; } }
        public long? ImageSize { get { throw null; } }
        public string LastUpdateTime { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Os { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tags { get { throw null; } }
    }
    public partial class ManifestList : Azure.Containers.ContainerRegistry.Manifest
    {
        public ManifestList() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.ManifestListAttributes> Manifests { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
    }
    public partial class ManifestListAttributes
    {
        public ManifestListAttributes() { }
        public string Digest { get { throw null; } set { } }
        public string MediaType { get { throw null; } set { } }
        public Azure.Containers.ContainerRegistry.Platform Platform { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
    }
    public partial class ManifestWrapper : Azure.Containers.ContainerRegistry.Manifest
    {
        public ManifestWrapper() { }
        public Azure.Containers.ContainerRegistry.Annotations Annotations { get { throw null; } set { } }
        public string Architecture { get { throw null; } set { } }
        public Azure.Containers.ContainerRegistry.Descriptor Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.FsLayer> FsLayers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.History> History { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.Descriptor> Layers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.ManifestListAttributes> Manifests { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.ImageSignature> Signatures { get { throw null; } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class OCIIndex : Azure.Containers.ContainerRegistry.Manifest
    {
        public OCIIndex() { }
        public Azure.Containers.ContainerRegistry.Annotations Annotations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.ManifestListAttributes> Manifests { get { throw null; } }
    }
    public partial class OCIManifest : Azure.Containers.ContainerRegistry.Manifest
    {
        public OCIManifest() { }
        public Azure.Containers.ContainerRegistry.Annotations Annotations { get { throw null; } set { } }
        public Azure.Containers.ContainerRegistry.Descriptor Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.Descriptor> Layers { get { throw null; } }
    }
    public partial class Platform
    {
        public Platform() { }
        public string Architecture { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Features { get { throw null; } }
        public string Os { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OsFeatures { get { throw null; } }
        public string OsVersion { get { throw null; } set { } }
        public string Variant { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostContentSchemaGrantType : System.IEquatable<Azure.Containers.ContainerRegistry.PostContentSchemaGrantType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostContentSchemaGrantType(string value) { throw null; }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType AccessToken { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType AccessTokenRefreshToken { get { throw null; } }
        public static Azure.Containers.ContainerRegistry.PostContentSchemaGrantType RefreshToken { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType left, Azure.Containers.ContainerRegistry.PostContentSchemaGrantType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerRegistry.PostContentSchemaGrantType (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerRegistry.PostContentSchemaGrantType left, Azure.Containers.ContainerRegistry.PostContentSchemaGrantType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RefreshToken
    {
        internal RefreshToken() { }
        public string RefreshTokenValue { get { throw null; } }
    }
    public partial class Repositories
    {
        internal Repositories() { }
        public System.Collections.Generic.IReadOnlyList<string> Names { get { throw null; } }
    }
    public partial class RepositoryAttributes
    {
        internal RepositoryAttributes() { }
        public Azure.Containers.ContainerRegistry.ChangeableAttributes ChangeableAttributes { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string ImageName { get { throw null; } }
        public string LastUpdateTime { get { throw null; } }
        public int? ManifestCount { get { throw null; } }
        public string Registry { get { throw null; } }
        public int? TagCount { get { throw null; } }
    }
    public partial class TagAttributes
    {
        internal TagAttributes() { }
        public Azure.Containers.ContainerRegistry.TagAttributesBase Attributes { get { throw null; } }
        public string ImageName { get { throw null; } }
        public string Registry { get { throw null; } }
    }
    public partial class TagAttributesBase
    {
        internal TagAttributesBase() { }
        public Azure.Containers.ContainerRegistry.ChangeableAttributes ChangeableAttributes { get { throw null; } }
        public string CreatedTime { get { throw null; } }
        public string Digest { get { throw null; } }
        public string LastUpdateTime { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Signed { get { throw null; } }
    }
    public partial class TagList
    {
        internal TagList() { }
        public string ImageName { get { throw null; } }
        public string Registry { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerRegistry.TagAttributesBase> Tags { get { throw null; } }
    }
    public partial class V1Manifest : Azure.Containers.ContainerRegistry.Manifest
    {
        public V1Manifest() { }
        public string Architecture { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.FsLayer> FsLayers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.History> History { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.ImageSignature> Signatures { get { throw null; } }
        public string Tag { get { throw null; } set { } }
    }
    public partial class V2Manifest : Azure.Containers.ContainerRegistry.Manifest
    {
        public V2Manifest() { }
        public Azure.Containers.ContainerRegistry.Descriptor Config { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerRegistry.Descriptor> Layers { get { throw null; } }
        public string MediaType { get { throw null; } set { } }
    }
}
