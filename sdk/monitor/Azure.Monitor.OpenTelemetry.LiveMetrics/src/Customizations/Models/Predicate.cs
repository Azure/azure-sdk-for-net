namespace Microsoft.ApplicationInsights.Extensibility.Filtering
{
    internal enum Predicate
    {
        Equal = 0,

        NotEqual = 1,

        LessThan = 2,

        GreaterThan = 3,

        LessThanOrEqual = 4,

        GreaterThanOrEqual = 5,

        Contains = 6,

        DoesNotContain = 7,
    }
}
