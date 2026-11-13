// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
    internal override BicepWriter Write(BicepWriter writer) => Properties.Length == 0 ?
        writer.Append("{ }") :
        writer.Append('{')
            .Indent(w => w.AppendLine().AppendAll(Properties, (w, p) =>
            {
                if (Infrastructure.IsValidBicepIdentifier(p.Name))
                {
                    w.Append(p.Name);
                }
                else
                {
                    w.Append(new StringLiteralExpression(p.Name));
                }
                return w.Append(": ").Append(p.Value);
            },
            w => w.AppendLine()))
            .AppendLine().Append('}');
}
