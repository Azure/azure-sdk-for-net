namespace Azure.Core.Expressions.DataFactory
{
    public sealed partial class DataFactoryExpression<T>
    {
        public DataFactoryExpression(T? literal) { }
        public bool HasLiteral { get { throw null; } }
        public T? Literal { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object? obj) { throw null; }
        public static Azure.Core.Expressions.DataFactory.DataFactoryExpression<T> FromExpression(string expression) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static implicit operator Azure.Core.Expressions.DataFactory.DataFactoryExpression<T> (T literal) { throw null; }
        public override string? ToString() { throw null; }
    }
}
