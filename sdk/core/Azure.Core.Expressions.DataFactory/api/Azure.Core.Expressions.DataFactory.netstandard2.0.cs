namespace Azure.Core.Expressions.DataFactory
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryElementKind : System.IEquatable<Azure.Core.Expressions.DataFactory.DataFactoryElementKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryElementKind(string kind) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind Expression { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind KeyVaultSecret { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind Literal { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind SecretString { get { throw null; } }
        public bool Equals(Azure.Core.Expressions.DataFactory.DataFactoryElementKind other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Expressions.DataFactory.DataFactoryElementKind left, Azure.Core.Expressions.DataFactory.DataFactoryElementKind right) { throw null; }
        public static bool operator !=(Azure.Core.Expressions.DataFactory.DataFactoryElementKind left, Azure.Core.Expressions.DataFactory.DataFactoryElementKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class DataFactoryElement<T>
    {
        internal DataFactoryElement() { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElementKind Kind { get { throw null; } }
        public T? Literal { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromExpression(string expression) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<System.String?> FromKeyVaultSecret(Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecret secret) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromLiteral(T? literal) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<System.String?> FromSecretString(Azure.Core.Expressions.DataFactory.DataFactorySecretString secretString) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryElement<T> (T literal) { throw null; }
        public override string? ToString() { throw null; }
    }
    public partial class DataFactoryKeyVaultSecret : Azure.Core.Expressions.DataFactory.DataFactorySecret
    {
        public DataFactoryKeyVaultSecret(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference store, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> secretName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SecretName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SecretVersion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference Store { get { throw null; } set { } }
    }
    public partial class DataFactoryLinkedServiceReference
    {
        public DataFactoryLinkedServiceReference(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind referenceKind, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData?> Parameters { get { throw null; } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind ReferenceKind { get { throw null; } set { } }
        public string? ReferenceName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryLinkedServiceReferenceKind : System.IEquatable<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryLinkedServiceReferenceKind(string value) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind left, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind right) { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind (string value) { throw null; }
        public static bool operator !=(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind left, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataFactorySecret
    {
        protected DataFactorySecret() { }
    }
    public partial class DataFactorySecretString : Azure.Core.Expressions.DataFactory.DataFactorySecret
    {
        public DataFactorySecretString(string value) { }
        public string? Value { get { throw null; } set { } }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactorySecretString (string literal) { throw null; }
    }
}
