using System;

namespace CompatibilityFixture;

[AttributeUsage(AttributeTargets.All)]
public sealed class MarkerAttribute : Attribute
{
#line 100 "Logical.cs"
    public MarkerAttribute(int value) => Value = value;
#line default
    public int Value { get; }
}
