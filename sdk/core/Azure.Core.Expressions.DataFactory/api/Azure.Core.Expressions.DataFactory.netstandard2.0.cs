namespace Azure.Core.Expressions.DataFactory
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFactoryElementKind : System.IEquatable<Azure.Core.Expressions.DataFactory.DataFactoryElementKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFactoryElementKind(string kind) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind Expression { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind KeyVaultReference { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind Literal { get { throw null; } }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElementKind SecureString { get { throw null; } }
        public bool Equals(Azure.Core.Expressions.DataFactory.DataFactoryElementKind other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public bool Equals(string? other) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Core.Expressions.DataFactory.DataFactoryElementKind left, Azure.Core.Expressions.DataFactory.DataFactoryElementKind right) { throw null; }
        public static bool operator !=(Azure.Core.Expressions.DataFactory.DataFactoryElementKind left, Azure.Core.Expressions.DataFactory.DataFactoryElementKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public sealed partial class DataFactoryElement<T>
    {
        public DataFactoryElement(T? literal) { }
        public Azure.Core.Expressions.DataFactory.DataFactoryElementKind Kind { get { throw null; } }
        public T? Literal { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromExpression(string expression) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromKeyVaultReference(string keyVaultReference) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryElement<T> FromLiteral(T literal, bool asSecureString) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryElement<T> (T literal) { throw null; }
        public override string? ToString() { throw null; }
    }
}
