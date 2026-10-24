// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Azure.Provisioning.Expressions;
using NUnit.Framework;
using Assert = NUnit.Framework.Legacy.ClassicAssert;
using StringAssert = NUnit.Framework.Legacy.StringAssert;

namespace Azure.Provisioning.Tests.Serialization;

public class SchemaCompatibilityTests
{
    private static BicepExpression Read(string json) =>
        ModelReaderWriter.Read<BicepExpression>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;

    private static string Write(BicepExpression expression) =>
        ModelReaderWriter.Write(expression, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default).ToString();

    private static string Bicep(BicepExpression expression) =>
        ModelReaderWriter.Write(expression, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default).ToString().Replace("\r\n", "\n");

    private static string Compact(string json)
    {
        using JsonDocument doc = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(doc.RootElement);
    }

    private static string Write(ParameterStatement statement) =>
        ModelReaderWriter.Write<BicepStatement>(statement, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default).ToString();

    private static Infrastructure ReadParameter(string decorators)
    {
        string json = """{"fileName":"main.bicep","parameters":{"p":{"bicepIdentifier":"p","valueType":{"kind":"primitive-type","name":"string"},"decorators":"""
            + decorators + "}}}";
        return ModelReaderWriter.Read<Infrastructure>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
    }

    private static string Write(Infrastructure infra)
    {
        using JsonDocument doc = JsonDocument.Parse(ModelReaderWriter.Write(infra, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default));
        return doc.RootElement.GetProperty("parameters").GetProperty("p").GetRawText();
    }

    private static string Bicep(Infrastructure infra) =>
        ModelReaderWriter.Write(infra, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default).ToString().Replace("\r\n", "\n");

    [TestCase("-9223372036854775808")]
    [TestCase("-2147483649")]
    [TestCase("-2147483648")]
    [TestCase("2147483647")]
    [TestCase("2147483648")]
    [TestCase("9223372036854775807")]
    public void IntegerValuesPreserveFullInt64Range(string value)
    {
        string json = """{"kind":"integer","value":""" + JsonSerializer.Serialize(value) + "}";
        BicepExpression expression = Read(json);
        Assert.AreEqual(json, Write(expression));
        Assert.AreEqual(value, Bicep(expression));
        Assert.AreEqual(expression, Read(Write(expression)));
        Assert.AreEqual(expression.GetHashCode(), Read(json).GetHashCode());
        if (long.Parse(value, CultureInfo.InvariantCulture) is >= int.MinValue and <= int.MaxValue)
            Assert.IsInstanceOf<IntLiteralExpression>(expression);
    }

    [TestCase("9223372036854775808")]
    [TestCase("-9223372036854775809")]
    public void IntegerOverflowIsRejected(string value) =>
        Assert.Throws<OverflowException>(() => Read("""{"kind":"integer","value":""" + JsonSerializer.Serialize(value) + "}"));

    [TestCase("minValue")]
    [TestCase("maxValue")]
    [TestCase("minLength")]
    [TestCase("maxLength")]
    [TestCase("batchSize")]
    public void NumericDecoratorsPreserveSafeIntegerRange(string name)
    {
        foreach (long value in new[] { -9007199254740991L, -2147483649L, 2147483648L, 9007199254740991L })
        {
            string decorators = "{\"" + name + "\":" + value.ToString(CultureInfo.InvariantCulture) + "}";
            Infrastructure statement = ReadParameter(decorators);
            using JsonDocument output = JsonDocument.Parse(Write(statement));
            SchemaOracle.AssertMatchesType(output.RootElement, "ParameterDeclarationNode");
            Assert.AreEqual(value, output.RootElement.GetProperty("decorators").GetProperty(name).GetInt64());
            StringAssert.Contains($"@{name}({value.ToString(CultureInfo.InvariantCulture)})", Bicep(statement));
        }
    }

    [TestCase("9007199254740992")]
    [TestCase("-9007199254740992")]
    public void UnsafeDecoratorIntegersAreRejectedOnReadAndWrite(string value)
    {
        Assert.Throws<FormatException>(() => ReadParameter("{\"maxValue\":" + value + "}"));
        ParameterStatement statement = new("p", new TypeExpression(typeof(int)), null);
        statement.Decorators.Add(new DecoratorExpression(new FunctionCallExpression(new IdentifierExpression("maxValue"),
            Read("""{"kind":"integer","value":""" + JsonSerializer.Serialize(value) + "}"))));
        Assert.Throws<FormatException>(() => Write(statement));
    }

    [Test]
    public void LegacyDecoratorNumbersAreReadButWrittenAsNumbers()
    {
        Infrastructure statement = ReadParameter("""{"maxValue":"2147483648"}""");
        using JsonDocument output = JsonDocument.Parse(Write(statement));
        Assert.AreEqual(JsonValueKind.Number, output.RootElement.GetProperty("decorators").GetProperty("maxValue").ValueKind);
    }

    [Test]
    public void AllowedAndMetadataHaveUnwrappedSchemaShapes()
    {
        const string decorators = """
            {"allowed":[{"kind":"string","value":"one"},{"kind":"string","value":"two"}],
             "metadata":{"owner":{"kind":"string","value":"team"}}}
            """;
        Infrastructure statement = ReadParameter(decorators);
        using JsonDocument output = JsonDocument.Parse(Write(statement));
        SchemaOracle.AssertMatchesType(output.RootElement, "ParameterDeclarationNode");
        Assert.AreEqual(Compact(decorators), JsonSerializer.Serialize(output.RootElement.GetProperty("decorators")));
        Assert.AreEqual("""
            @allowed([
              'one'
              'two'
            ])
            @metadata({
              owner: 'team'
            })
            param p string
            """.Replace("\r\n", "\n"), Bicep(statement));
    }

    [TestCase("secure")]
    [TestCase("sealed")]
    [TestCase("export")]
    public void FlagDecoratorsRequireLiteralTrue(string name)
    {
        Assert.Throws<FormatException>(() => ReadParameter("{\"" + name + "\":false}"));
        Infrastructure statement = ReadParameter("{\"" + name + "\":true}");
        using JsonDocument output = JsonDocument.Parse(Write(statement));
        SchemaOracle.AssertMatchesType(output.RootElement, "ParameterDeclarationNode");
        StringAssert.Contains("@" + name + "()", Bicep(statement));
    }

    [Test]
    public void UnrepresentableDecoratorsFailExplicitly()
    {
        Assert.Throws<NotSupportedException>(() => ReadParameter("""{"onlyIfNotExists":true}"""));
        foreach (BicepExpression expression in new BicepExpression[]
        {
            new IdentifierExpression("secure"),
            new FunctionCallExpression(new IdentifierExpression("onlyIfNotExists")),
            new FunctionCallExpression(new IdentifierExpression("description"), new IntLiteralExpression(1)),
            new FunctionCallExpression(new IdentifierExpression("allowed"), new StringLiteralExpression("one"), new StringLiteralExpression("two")),
            new FunctionCallExpression(new IdentifierExpression("metadata"), new StringLiteralExpression("owner")),
        })
        {
            ParameterStatement statement = new("p", new TypeExpression(typeof(string)), null);
            statement.Decorators.Add(new DecoratorExpression(expression));
            Assert.Throws<NotSupportedException>(() => Write(statement));
        }
        ParameterStatement duplicate = new("p", new TypeExpression(typeof(string)), null);
        duplicate.Decorators.Add(new DecoratorExpression(new FunctionCallExpression(new IdentifierExpression("secure"))));
        duplicate.Decorators.Add(duplicate.Decorators[0]);
        Assert.Throws<NotSupportedException>(() => Write(duplicate));
    }

    [TestCase(false, false, "arr[1]")]
    [TestCase(false, true, "arr[^1]")]
    [TestCase(true, false, "arr[?1]")]
    [TestCase(true, true, "arr[?^1]")]
    public void IndexFlagsRoundTripIntoJsonAndBicep(bool nullish, bool fromEnd, string bicep)
    {
        string json = """{"kind":"array-access","base":{"kind":"identifier","id":"arr"},"index":{"kind":"integer","value":"1"},"nullish":"""
            + (nullish ? "true" : "false") + ",\"fromEnd\":" + (fromEnd ? "true" : "false") + "}";
        BicepExpression expression = Read(json);
        Assert.AreEqual(json, Write(expression));
        Assert.AreEqual(bicep, Bicep(expression));
        Assert.AreEqual(expression, Read(json));
        Assert.AreEqual(expression.GetHashCode(), Read(json).GetHashCode());
        BicepExpression forward = nullish
            ? new SafeIndexExpression(new IdentifierExpression("arr"), new IntLiteralExpression(1))
            : new IndexExpression(new IdentifierExpression("arr"), new IntLiteralExpression(1));
        Assert.AreEqual(!fromEnd, expression.Equals(forward));
        using JsonDocument output = JsonDocument.Parse(Write(expression));
        SchemaOracle.AssertMatchesType(output.RootElement, "ExpressionNode");
    }

    private static IEnumerable<TestCaseData> TypeNodes()
    {
        yield return new("""{"kind":"primitive-type","name":"any"}""", "any");
        yield return new("""{"kind":"type-reference","name":"MyType"}""", "MyType");
        yield return new("""{"kind":"string-type-literal","value":"one"}""", "'one'");
        yield return new("""{"kind":"integer-type-literal","value":"2147483648"}""", "2147483648");
        yield return new("""{"kind":"boolean-type-literal","value":true}""", "true");
        yield return new("""{"kind":"null-type-literal","value":null}""", "null");
        yield return new("""{"kind":"array-type","item":{"kind":"primitive-type","name":"string"}}""", "string[]");
        yield return new("""{"kind":"object-type-property","key":"name","valueType":{"kind":"primitive-type","name":"string"},"optional":true}""", "'name': string?");
        yield return new("""{"kind":"object-type-additional-properties","valueType":{"kind":"primitive-type","name":"int"}}""", "*: int");
        yield return new("""{"kind":"object-type","properties":[{"kind":"object-type-property","key":"name","valueType":{"kind":"primitive-type","name":"string"}}],"additionalProperties":{"kind":"object-type-additional-properties","valueType":{"kind":"primitive-type","name":"string"}}}""", "{\n  'name': string\n  *: string\n}");
        yield return new("""{"kind":"union-type-member","valueType":{"kind":"string-type-literal","value":"one"}}""", "'one'");
        yield return new("""{"kind":"union-type","members":[{"kind":"union-type-member","valueType":{"kind":"string-type-literal","value":"one"}},{"kind":"union-type-member","valueType":{"kind":"string-type-literal","value":"two"}}]}""", "'one' | 'two'");
        yield return new("""{"kind":"nullable-type","base":{"kind":"primitive-type","name":"string"}}""", "string?");
        yield return new("""{"kind":"parameterized-type-argument","valueType":{"kind":"string-type-literal","value":"Microsoft.Storage/storageAccounts@2024-01-01"}}""", "'Microsoft.Storage/storageAccounts@2024-01-01'");
        yield return new("""{"kind":"parameterized-type-instantiation","base":{"kind":"type-reference","name":"resource"},"args":[{"kind":"parameterized-type-argument","valueType":{"kind":"string-type-literal","value":"Microsoft.Storage/storageAccounts@2024-01-01"}}]}""", "resource<'Microsoft.Storage/storageAccounts@2024-01-01'>");
    }

    [TestCaseSource(nameof(TypeNodes))]
    public void AllTypeNodesRoundTrip(string json, string bicep)
    {
        using JsonDocument input = JsonDocument.Parse(json);
        SchemaOracle.AssertMatchesType(input.RootElement, "TypeNode");
        BicepExpression expression = Read(json);
        Assert.AreEqual(json, Write(expression));
        Assert.AreEqual(bicep, Bicep(expression));
        Assert.AreEqual(expression, Read(Write(expression)));
        Assert.AreEqual(expression.GetHashCode(), Read(json).GetHashCode());
    }

    [Test]
    public void TypeFixturesCoverEverySchemaKind()
    {
        HashSet<string> kinds = new();
        foreach (TestCaseData test in TypeNodes())
        {
            using JsonDocument doc = JsonDocument.Parse((string)test.Arguments[0]!);
            kinds.Add(doc.RootElement.GetProperty("kind").GetString()!);
        }
        Assert.IsTrue(SchemaOracle.TypeKinds.Value.SetEquals(kinds));
    }

    [Test]
    public void UnionPrecedenceIsPreservedInArrayAndNullableTypes()
    {
        const string union = """{"kind":"union-type","members":[{"kind":"union-type-member","valueType":{"kind":"string-type-literal","value":"one"}},{"kind":"union-type-member","valueType":{"kind":"string-type-literal","value":"two"}}]}""";
        Assert.AreEqual("('one' | 'two')[]", Bicep(Read("""{"kind":"array-type","item":""" + union + "}")));
        Assert.AreEqual("('one' | 'two')?", Bicep(Read("""{"kind":"nullable-type","base":""" + union + "}")));
    }

    [Test]
    public void TypePropertyDecoratorsArePreserved()
    {
        const string json = """{"kind":"object-type-property","key":"name","valueType":{"kind":"primitive-type","name":"string"},"decorators":{"description":"A name","minLength":2147483648}}""";
        BicepExpression expression = Read(json);
        Assert.AreEqual(json, Write(expression));
        Assert.AreEqual("@description('A name')\n@minLength(2147483648)\n'name': string", Bicep(expression));
    }

    [Test]
    public void TypePropertyLegacyDecoratorNumbersAreNormalized()
    {
        const string json = """{"kind":"object-type-property","key":"name","valueType":{"kind":"primitive-type","name":"string"},"decorators":{"minLength":"2147483648"}}""";
        using JsonDocument output = JsonDocument.Parse(Write(Read(json)));
        SchemaOracle.AssertMatchesType(output.RootElement, "TypeNode");
        Assert.AreEqual(JsonValueKind.Number, output.RootElement.GetProperty("decorators").GetProperty("minLength").ValueKind);
    }

    [Test]
    public void NumericFormattingIsCultureIndependent()
    {
        CultureInfo previous = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo culture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            culture.NumberFormat.NegativeSign = "~";
            CultureInfo.CurrentCulture = culture;
            foreach (string value in new[] { "-123", "-2147483649" })
            {
                string json = """{"kind":"integer","value":""" + JsonSerializer.Serialize(value) + "}";
                Assert.AreEqual(json, Write(Read(json)));
                Assert.AreEqual(value, Bicep(Read(json)));
            }
        }
        finally
        {
            CultureInfo.CurrentCulture = previous;
        }
    }

    [Test]
    public void ParametersAndOutputsUseTypeNodes()
    {
        const string json = """
            {"fileName":"main.bicep","parameters":{"p":{"bicepIdentifier":"p","valueType":{"kind":"array-type","item":{"kind":"primitive-type","name":"string"}}}},
             "outputs":{"result":{"bicepIdentifier":"result","valueType":{"kind":"array-type","item":{"kind":"primitive-type","name":"string"}},"value":{"kind":"identifier","id":"p"}}}}
            """;
        Infrastructure infra = ModelReaderWriter.Read<Infrastructure>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureProvisioningContext.Default)!;
        using JsonDocument output = JsonDocument.Parse(ModelReaderWriter.Write(infra, ModelReaderWriterOptions.Json, AzureProvisioningContext.Default));
        SchemaOracle.AssertMatchesType(output.RootElement, "InfraNode");
        Assert.AreEqual("array-type", output.RootElement.GetProperty("parameters").GetProperty("p").GetProperty("valueType").GetProperty("kind").GetString());
        Assert.AreEqual("array-type", output.RootElement.GetProperty("outputs").GetProperty("result").GetProperty("valueType").GetProperty("kind").GetString());
        string bicep = ModelReaderWriter.Write(infra, new ModelReaderWriterOptions("bicep"), AzureProvisioningContext.Default).ToString();
        StringAssert.Contains("param p string[]", bicep);
        StringAssert.Contains("output result string[] = p", bicep);
    }

    [Test]
    public void NamedTypeReferencesUseSchemaTypeReferenceShape()
    {
        using JsonDocument output = JsonDocument.Parse(Write(new ParameterStatement("p", new IdentifierExpression("MyType"), null)));
        SchemaOracle.AssertMatchesType(output.RootElement, "ParameterDeclarationNode");
        Assert.AreEqual("type-reference", output.RootElement.GetProperty("valueType").GetProperty("kind").GetString());

        Infrastructure infra = new();
        infra.Add(new ProvisioningParameter("p", new IdentifierExpression("MyType")));
        SerializationTestHelpers.AssertJsonRoundTrip(infra);
        SerializationTestHelpers.AssertBicepEquivalence(infra);
    }

    [Test]
    public void OptionalNullablePropertyDoesNotDuplicateNullableSuffix()
    {
        const string json = """{"kind":"object-type-property","key":"name","valueType":{"kind":"nullable-type","base":{"kind":"primitive-type","name":"string"}},"optional":true}""";
        Assert.AreEqual("'name': string?", Bicep(Read(json)));
        Assert.AreEqual(json, Write(Read(json)));
    }

    [Test]
    public void UnsupportedPrimitiveMappingDoesNotSilentlyBecomeAny()
    {
        Assert.Throws<NotSupportedException>(() => Write(new TypeExpression(typeof(SchemaCompatibilityTests))));
        Assert.Throws<FormatException>(() => Read("""{"kind":"primitive-type","name":"invalid"}"""));
    }

    [Test]
    public void TypeNodesAreNotExpressionValues()
    {
        Assert.Throws<InvalidOperationException>(() =>
            Read("""{"kind":"array","items":[{"kind":"primitive-type","name":"string"}]}"""));
    }

    [Test]
    public void LoopsRemainExplicitlyUnsupported() =>
        Assert.Throws<NotSupportedException>(() =>
            Read("""{"kind":"for-expression","itemVariable":"item","collection":{"kind":"array","items":[]},"body":{"kind":"object","value":{}}}"""));

    [Test]
    public void StandaloneDecoratorsRejectJsonButKeepBicep()
    {
        BicepExpression expression = new DecoratorExpression(new FunctionCallExpression(new IdentifierExpression("secure")));
        Assert.Throws<NotSupportedException>(() => Write(expression));
        Assert.AreEqual("@secure()", Bicep(expression));
    }

    [TestCase("""{"kind":"array","value":[]}""", "ExpressionNode")]
    [TestCase("""{"allowed":{"kind":"array","items":[]}}""", "DecoratorsNode")]
    [TestCase("""{"metadata":{"kind":"object","value":{}}}""", "DecoratorsNode")]
    [TestCase("""{"secure":false}""", "DecoratorsNode")]
    [TestCase("""{"kind":"unary-operation","operator":"!*","argument":{"kind":"identifier","id":"x"}}""", "ExpressionNode")]
    public void SchemaOracleRejectsIncorrectShapes(string json, string type)
    {
        using JsonDocument doc = JsonDocument.Parse(json);
        Assert.Throws<AssertionException>(() => SchemaOracle.AssertMatchesType(doc.RootElement, type));
    }
}
