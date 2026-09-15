// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Represents a Bicep object expression composed of named properties.
/// </summary>
/// <param name="properties">The property expressions that make up the object.</param>
public class ObjectExpression(params PropertyExpression[] properties) : BicepExpression
{
    /// <summary>
    /// Gets the property expressions that make up the object.
    /// </summary>
    public PropertyExpression[] Properties { get; } = properties;
    private static bool IsIdentifierChar(char c) => char.IsLetterOrDigit(c) || c == '_';
    internal override BicepWriter Write(BicepWriter writer) => Properties.Length == 0 ?
        writer.Append("{ }") :
        writer.Append('{')
            .Indent(w => w.AppendLine().AppendAll(Properties, (w, p) =>
            {
                bool quote = p.Name[0] != '\'' && !p.Name.All(IsIdentifierChar);
                if (quote)
                {
                    w.Append('\'');
                }
                w.Append(p.Name);
                if (quote)
                {
                    w.Append('\'');
                }
                return w.Append(": ").Append(p.Value);
            },
            w => w.AppendLine()))
            .AppendLine().Append('}');
}
