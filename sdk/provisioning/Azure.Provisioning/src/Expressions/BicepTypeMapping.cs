// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Collect the primary logic for mapping .NET types to Bicep types in one place.
/// </summary>
internal static class BicepTypeMapping
{
    /// <summary>
    /// Map standard Azure types into Bicep primitive type names like bool,
    /// int, string, object, or array.  More complex types are not supported.
    /// </summary>
    /// <param name="type">A .NET type.</param>
    /// <returns>A corresponding Bicep type name or null.</returns>
    public static string? GetBicepTypeName(Type type) =>
        type == typeof(bool) ? "bool" :
        type == typeof(int) ? "int" :
        type == typeof(long) ? "int" :
        type == typeof(string) ? "string" :
        type == typeof(object) ? "object" :
        type == typeof(Uri) ? "string" :
        type == typeof(DateTimeOffset) ? "string" :
        type == typeof(TimeSpan) ? "string" :
        type == typeof(Guid) ? "string" :
        type == typeof(IPAddress) ? "string" :
        type == typeof(ETag) ? "string" :
        type == typeof(ResourceIdentifier) ? "string" :
        type == typeof(ResourceType) ? "string" :
        type == typeof(AzureLocation) ? "string" :
        type.IsSubclassOf(typeof(Enum)) ? "string" :
        type.IsSubclassOf(typeof(System.Collections.IEnumerable)) ? "array" :
        type.IsSubclassOf(typeof(System.Collections.IDictionary)) ? "object" :
        null;

    /// <summary>
    /// Convert a .NET object into a literal Bicep string.
    /// </summary>
    /// <param name="value">The .NET value.</param>
    /// <param name="format">Optional format.</param>
    /// <returns>The corresponding Bicep literal string.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when we cannot convert a value to a literal Bicep string.
    /// </exception>
    public static string ToLiteralString(object value, string? format) =>
        value switch
        {
            bool b => b.ToString(),
            int i => i.ToString(),
            long i => i.ToString(),
            float f => f.ToString(),
            double d => d.ToString(),
            string s => s,
            Uri u => u.AbsoluteUri,
            DateTimeOffset d => d.ToString("o"),
            TimeSpan t when format == "P" => XmlConvert.ToString(t),
            TimeSpan t => t.ToString(),
            Guid g => g.ToString(),
            IPAddress a => a.ToString(),
            ETag e => e.ToString(),
            ResourceIdentifier i => i.ToString(),
            Enum e => GetEnumValue(e),
            // Extensible enums like Azure.Location
            // TODO: Can we either tag or special case all that we care about because ValueType is too broad
            ValueType ee => ee.ToString()!,
            _ => throw new InvalidOperationException($"Cannot convert {value} to a literal Bicep string.")
        };

    /// <summary>
    /// Convert a .NET object into a Bicep expression.
    /// </summary>
    /// <param name="value">The .NET value.</param>
    /// <param name="format">Optional format.</param>
    /// <returns>The corresponding Bicep expression.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when we cannot convert a value to a Bicep expression.
    /// </exception>
    public static BicepExpression ToBicep(object? value, string? format)
    {
        return value switch
        {
            null => BicepSyntax.Null(),
            bool b => BicepSyntax.Value(b),
            int i => BicepSyntax.Value(i),
            long l => FromLong(l),
            // Note: bicep does not offically support floating numbers
            // therefore for floating numbers we are taking a workaround from
            // https://github.com/Azure/bicep/issues/1386#issuecomment-818077233
            float f => FromDouble(f),
            double d => FromDouble(d),
            string s => BicepSyntax.Value(s),
            Uri u => BicepSyntax.Value(ToLiteralString(u, format)),
            DateTimeOffset d => BicepSyntax.Value(ToLiteralString(d, format)),
            TimeSpan t => BicepSyntax.Value(ToLiteralString(t, format)),
            Guid g => BicepSyntax.Value(ToLiteralString(g, format)),
            IPAddress a => BicepSyntax.Value(ToLiteralString(a, format)),
            ETag e => BicepSyntax.Value(ToLiteralString(e, format)),
            ResourceIdentifier i => BicepSyntax.Value(ToLiteralString(i, format)),
            Enum e => BicepSyntax.Value(ToLiteralString(e, format)),
            ProvisionableConstruct c => CompileNestedConstruct(c),
            IDictionary<string, IBicepValue> d =>
                d is IBicepValue b && b.Kind == BicepValueKind.Expression ? b.Expression! : ToObject(d),
            IEnumerable seq =>
                seq is IBicepValue b && b.Kind == BicepValueKind.Expression ? b.Expression! : ToArray(seq.OfType<object>()),
            // Extensible enums like Azure.Location
            ValueType ee => BicepSyntax.Value(ToLiteralString(ee, format)),
            // Unwrap BicepValue after collections so it doesn't loop forever
            IBicepValue v when (v.Kind == BicepValueKind.Expression) => v.Expression!,
            IBicepValue v when (v.Source is not null) => v.Source.GetReference(),
            IBicepValue v when (v.Kind == BicepValueKind.Literal) => ToBicep(v.LiteralValue, format),
            IBicepValue v when (v.Self is not null) => v.Self.GetReference(),
            IBicepValue v when (v.Kind == BicepValueKind.Unset) => BicepSyntax.Null(),
            _ => throw new InvalidOperationException($"Cannot convert {value} to a Bicep expression.")
        };

        BicepExpression FromLong(long l)
        {
            // see if the value falls into the int range
            if (l >= int.MinValue && l <= int.MaxValue)
            {
                return BicepSyntax.Value((int)l);
            }
            // otherwise we use the workaround from https://github.com/Azure/bicep/issues/1386#issuecomment-818077233
            return BicepFunction.ParseJson(BicepSyntax.Value(l.ToString())).Compile();
        }

        BicepExpression FromDouble(double d)
        {
            // see if the value is a whole number
            if (d >= int.MinValue && d <= int.MaxValue && d == Math.Floor(d))
            {
                return BicepSyntax.Value((int)d);
            }
            // otherwise we use the workaround from https://github.com/Azure/bicep/issues/1386#issuecomment-818077233
            return BicepFunction.ParseJson(BicepSyntax.Value(d.ToString())).Compile();
        }

        ArrayExpression ToArray(IEnumerable<object> seq) =>
            BicepSyntax.Array([.. seq.Select(v => ToBicep(v, v is BicepValue b ? b.Format : null))]);

        ObjectExpression ToObject(IDictionary<string, IBicepValue> dict)
        {
            Dictionary<string, BicepExpression> values = [];
            foreach (KeyValuePair<string, IBicepValue> pair in dict)
            {
                string? format = null;
                if (pair.Value is BicepValue v)
                {
                    format = v.Format;
                }
                values[pair.Key] = ToBicep(pair.Value, format);
            }
            return BicepSyntax.Object(values);
        }

        BicepExpression CompileNestedConstruct(ProvisionableConstruct construct)
        {
            IList<BicepStatement> statements = [.. construct.Compile()];
            if (statements.Count != 1)
            {
                throw new InvalidOperationException($"Cannot convert {construct} into a Bicep expression because it contains multiple statements.");
            }
            // TODO -- this is a workaround until https://github.com/Azure/azure-sdk-for-net/issues/52277 is resolved
            if (statements[0] is ResourceStatement resource)
            {
                // handle the case when we are using a resource as property of other resources
                return resource.Body;
            }
            if (statements[0] is not ExpressionStatement expr)
            {
                throw new InvalidOperationException($"Cannot convert {construct} into a Bicep expression because it compiles to {statements[0]} instead.");
            }
            return expr.Expression;
        }
    }

    /// <summary>
    /// Get the value of an enum.  This is either the name of the enum value or
    /// optionally overridden by a DataMember attribute when the wire value
    /// is different from the .NET name.
    /// </summary>
    /// <param name="value">An enum value.</param>
    /// <returns>The enum value's string representation.</returns>
    private static string GetEnumValue(Enum value)
    {
        Type type = value.GetType();
        string? name = Enum.GetName(type, value);
        if (name != null)
        {
            DataMemberAttribute? member = type.GetField(name)?.GetCustomAttribute<DataMemberAttribute>();
            return member?.Name ?? value.ToString();
        }
        return value.ToString();
    }
}
