// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;

namespace Microsoft.TypeSpec.Generator.Mcp.Tests;

public sealed class ContractTypesTests
{
    private static ContractTypes Types => new(new McpManifest("Example", []));

    [TestCase(InputPrimitiveTypeKind.String, typeof(string))]
    [TestCase(InputPrimitiveTypeKind.Url, typeof(Uri))]
    [TestCase(InputPrimitiveTypeKind.Boolean, typeof(bool))]
    [TestCase(InputPrimitiveTypeKind.Int32, typeof(int))]
    [TestCase(InputPrimitiveTypeKind.Int64, typeof(long))]
    [TestCase(InputPrimitiveTypeKind.UInt64, typeof(ulong))]
    [TestCase(InputPrimitiveTypeKind.Decimal128, typeof(decimal))]
    [TestCase(InputPrimitiveTypeKind.Float32, typeof(float))]
    [TestCase(InputPrimitiveTypeKind.PlainDate, typeof(DateOnly))]
    [TestCase(InputPrimitiveTypeKind.PlainTime, typeof(TimeOnly))]
    [TestCase(InputPrimitiveTypeKind.Bytes, typeof(byte[]))]
    public void JsonContractPrimitivesRetainTheirClrType(InputPrimitiveTypeKind kind, Type expected)
    {
        Assert.That(Types.Resolve(new InputPrimitiveType(kind, kind.ToString(), "Example.Value")).FrameworkType, Is.EqualTo(expected));
    }

    [TestCase(InputPrimitiveTypeKind.Unknown)]
    [TestCase(InputPrimitiveTypeKind.Stream)]
    [TestCase(InputPrimitiveTypeKind.Numeric)]
    [TestCase(InputPrimitiveTypeKind.Integer)]
    public void UnsupportedPrimitivesFailExplicitly(InputPrimitiveTypeKind kind)
    {
        Assert.That(() => Types.Resolve(new InputPrimitiveType(kind, kind.ToString(), "Example.Value")),
            Throws.InvalidOperationException.With.Message.Contains("Unsupported contract primitive"));
    }

    [Test]
    public void NullableTypesRetainTheirNullability()
    {
        var type = Types.Resolve(new InputNullableType(InputPrimitiveType.String));
        Assert.That(type.FrameworkType, Is.EqualTo(typeof(string)));
        Assert.That(type.IsNullable, Is.True);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void OpenEnumWireValuesAreSupportedAndClosedEnumsAreRejected(bool extensible)
    {
        var input = new InputEnumType("Access", "Example", "Example.Access", "public", null, null, null,
            InputModelTypeUsage.Input, InputPrimitiveType.String, [], extensible);
        if (extensible)
        {
            Assert.That(Types.Resolve(input).FrameworkType, Is.EqualTo(typeof(string)));
        }
        else
        {
            Assert.That(() => Types.Resolve(input), Throws.InvalidOperationException.With.Message.Contains("Unsupported contract type"));
        }
    }
}
