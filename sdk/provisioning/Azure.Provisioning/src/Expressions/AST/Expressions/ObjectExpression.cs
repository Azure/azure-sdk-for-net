// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Expressions;

public class ObjectExpression(params PropertyExpression[] properties) : BicepExpression
{
    public PropertyExpression[] Properties { get; } = properties;
    private static bool IsIdentifierChar(char c) => char.IsLetterOrDigit(c) || c == '_';
    private static bool IsIdentifier(string value)
    {
        if (value.Length == 0 || (!char.IsLetter(value[0]) && value[0] != '_'))
        {
            return false;
        }
        for (int i = 1; i < value.Length; i++)
        {
            if (!IsIdentifierChar(value[i]))
            {
                return false;
            }
        }
        return true;
    }
    internal override BicepWriter Write(BicepWriter writer) => Properties.Length == 0 ?
        writer.Append("{ }") :
        writer.Append('{')
            .Indent(w => w.AppendLine().AppendAll(Properties, (w, p) =>
            {
                if (p.AllowRawName && p.Name.Length > 0 && p.Name[0] == '\'')
                {
                    w.Append(p.Name);
                }
                else
                {
                    bool quote = !IsIdentifier(p.Name);
                    if (quote)
                    {
                        w.Append('\'');
                    }
                    w.AppendEscaped(p.Name);
                    if (quote)
                    {
                        w.Append('\'');
                    }
                }
                return w.Append(": ").Append(p.Value);
            },
            w => w.AppendLine()))
            .AppendLine().Append('}');
}
