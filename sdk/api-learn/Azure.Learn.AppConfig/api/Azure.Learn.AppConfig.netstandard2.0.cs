namespace Azure.Learn.AppConfig
{
    public partial class ConfigurationClient
    {
        protected ConfigurationClient() { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConfigurationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Learn.AppConfig.ConfigurationClientOptions options) { }
        public virtual Azure.Response<Azure.Learn.AppConfig.ConfigurationSetting> GetConfigurationSetting(Azure.Learn.AppConfig.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Learn.AppConfig.ConfigurationSetting> GetConfigurationSetting(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Learn.AppConfig.ConfigurationSetting>> GetConfigurationSettingAsync(Azure.Learn.AppConfig.ConfigurationSetting setting, bool onlyIfChanged = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Learn.AppConfig.ConfigurationSetting>> GetConfigurationSettingAsync(string key, string label = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigurationClientOptions : Azure.Core.ClientOptions
    {
        public ConfigurationClientOptions(Azure.Learn.AppConfig.ConfigurationClientOptions.ServiceVersion version = Azure.Learn.AppConfig.ConfigurationClientOptions.ServiceVersion.V1_0) { }
        public enum ServiceVersion
        {
            V1_0 = 0,
        }
    }
    public partial class ConfigurationSetting
    {
        public ConfigurationSetting() { }
        public string ContentType { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } set { } }
        public bool? Locked { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
}
namespace Azure.Learn.AppConfig.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum4 : System.IEquatable<Azure.Learn.AppConfig.Models.Enum4>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum4(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Enum4 ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum4 Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Enum4 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Enum4 left, Azure.Learn.AppConfig.Models.Enum4 right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Enum4 (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Enum4 left, Azure.Learn.AppConfig.Models.Enum4 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Enum5 : System.IEquatable<Azure.Learn.AppConfig.Models.Enum5>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Enum5(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Enum5 ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Enum5 Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Enum5 other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Enum5 left, Azure.Learn.AppConfig.Models.Enum5 right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Enum5 (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Enum5 left, Azure.Learn.AppConfig.Models.Enum5 right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Get6ItemsItem : System.IEquatable<Azure.Learn.AppConfig.Models.Get6ItemsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Get6ItemsItem(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get6ItemsItem Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Get6ItemsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Get6ItemsItem left, Azure.Learn.AppConfig.Models.Get6ItemsItem right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Get6ItemsItem (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Get6ItemsItem left, Azure.Learn.AppConfig.Models.Get6ItemsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Get7ItemsItem : System.IEquatable<Azure.Learn.AppConfig.Models.Get7ItemsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Get7ItemsItem(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Get7ItemsItem Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Get7ItemsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Get7ItemsItem left, Azure.Learn.AppConfig.Models.Get7ItemsItem right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Get7ItemsItem (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Get7ItemsItem left, Azure.Learn.AppConfig.Models.Get7ItemsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Head6ItemsItem : System.IEquatable<Azure.Learn.AppConfig.Models.Head6ItemsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Head6ItemsItem(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head6ItemsItem Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Head6ItemsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Head6ItemsItem left, Azure.Learn.AppConfig.Models.Head6ItemsItem right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Head6ItemsItem (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Head6ItemsItem left, Azure.Learn.AppConfig.Models.Head6ItemsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Head7ItemsItem : System.IEquatable<Azure.Learn.AppConfig.Models.Head7ItemsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Head7ItemsItem(string value) { throw null; }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem ContentType { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Etag { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Key { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Label { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem LastModified { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Locked { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Tags { get { throw null; } }
        public static Azure.Learn.AppConfig.Models.Head7ItemsItem Value { get { throw null; } }
        public bool Equals(Azure.Learn.AppConfig.Models.Head7ItemsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Learn.AppConfig.Models.Head7ItemsItem left, Azure.Learn.AppConfig.Models.Head7ItemsItem right) { throw null; }
        public static implicit operator Azure.Learn.AppConfig.Models.Head7ItemsItem (string value) { throw null; }
        public static bool operator !=(Azure.Learn.AppConfig.Models.Head7ItemsItem left, Azure.Learn.AppConfig.Models.Head7ItemsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Key
    {
        internal Key() { }
        public string Name { get { throw null; } }
    }
    public partial class KeyListResult
    {
        internal KeyListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Learn.AppConfig.Models.Key> Items { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class KeyValueListResult
    {
        internal KeyValueListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Learn.AppConfig.ConfigurationSetting> Items { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
    public partial class Label
    {
        internal Label() { }
        public string Name { get { throw null; } }
    }
    public partial class LabelListResult
    {
        internal LabelListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Learn.AppConfig.Models.Label> Items { get { throw null; } }
        public string NextLink { get { throw null; } }
    }
}
