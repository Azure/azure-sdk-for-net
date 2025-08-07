// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Provisioning.Expressions;

internal class BicepWriter
{
    private readonly StringBuilder _text = new();
    private int _indent = 0;
    public override string ToString() => _text.ToString();
    public BicepWriter Append(char ch) { _text.Append(ch); return this; }
    public BicepWriter Append(string text) { _text.Append(text); return this; }
    public BicepWriter Indent(Func<BicepWriter, BicepWriter> write)
    {
        _indent++;
        BicepWriter writer = write(this);
        _indent--;
        return writer;
    }
    public BicepWriter AppendLine()
    {
        _text.AppendLine();
        int indent = _indent;
        while (indent-- > 0)
        {
            _text.Append("  ");
        }
        return this;
    }
    public BicepWriter AppendEscaped(string text)
    {
        foreach (char ch in text)
        {
            _ = ch switch
            {
                '\\' => Append("\\\\"),
                '\'' => Append("\\'"),
                '\n' => Append("\\n"),
                '\r' => Append("\\r"),
                '\t' => Append("\\t"),
                '$' => Append("\\$"),
                _ => Append(ch)
            };
        }
        return this;
    }
    public BicepWriter AppendIf(bool condition, Func<BicepWriter, BicepWriter> write) => condition ? write(this) : this;
    public BicepWriter AppendAll<T>(IEnumerable<T> values, Func<BicepWriter, T, BicepWriter> append, Func<BicepWriter, BicepWriter>? separate = null)
        where T : BicepExpression
    {
        bool first = true;
        BicepWriter writer = this;
        if (values != null)
        {
            foreach (T value in values)
            {
                if (!first && separate != null) { writer = separate(writer); }
                first = false;

                writer = append(writer, value);
            }
        }
        return writer;
    }
    public BicepWriter Append(BicepExpression expr) => expr.Write(this);
    public BicepWriter Append(BicepStatement stmt) => stmt.Write(this);
}
