namespace Azure.Core.Expressions.DataFactory
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryElementKind : System.IEquatable<Azure.Core.Expressions.DataFactory.DataFactoryElementKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryElementKind(string kind) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind Expression { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind KeyVaultSecretReference { get { throw null; } }
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
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<System.String?> FromKeyVaultSecretReference(Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference keyVaultSecretReference) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromLiteral(T? literal) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<System.String?> FromSecretString(Azure.Core.Expressions.DataFactory.DataFactorySecretString secretString) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryElement<T> (T literal) { throw null; }
        public override string? ToString() { throw null; }
    }
    public partial class DataFactoryKeyVaultSecretReference : Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition
    {
        public DataFactoryKeyVaultSecretReference(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference store, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> secretName) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SecretName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryElement<string> SecretVersion { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference Store { get { throw null; } set { } }
    }
    public partial class DataFactoryLinkedServiceReference
    {
        public DataFactoryLinkedServiceReference(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType referenceType, string referenceName) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData?> Parameters { get { throw null; } }
        public string? ReferenceName { get { throw null; } set { } }
        public Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType ReferenceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryLinkedServiceReferenceType : System.IEquatable<Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryLinkedServiceReferenceType(string value) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType left, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType right) { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType left, Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class DataFactoryModelFactory
    {
        public static Azure.Core.Expressions.DataFactory.DataFactoryKeyVaultSecretReference DataFactoryKeyVaultSecretReference(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference store, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> secretName, Azure.Core.Expressions.DataFactory.DataFactoryElement<string> secretVersion) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReference DataFactoryLinkedServiceReference(Azure.Core.Expressions.DataFactory.DataFactoryLinkedServiceReferenceType referenceType, string? referenceName, System.Collections.Generic.IDictionary<string, System.BinaryData?> parameters) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition DataFactorySecretBaseDefinition(string secretBaseType) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactorySecretString DataFactorySecretString(string value) { throw null; }
    }
    public abstract partial class DataFactorySecretBaseDefinition
    {
        protected DataFactorySecretBaseDefinition() { }
    }
    public partial class DataFactorySecretString : Azure.Core.Expressions.DataFactory.DataFactorySecretBaseDefinition
    {
        public DataFactorySecretString(string value) { }
        public string? Value { get { throw null; } set { } }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactorySecretString (string literal) { throw null; }
    }
}
