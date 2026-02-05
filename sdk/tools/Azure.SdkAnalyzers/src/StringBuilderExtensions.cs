// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Xml;

internal static class StringBuilderExtensions
{
    private const char Newline = '\n';
    public static StringBuilder AppendNormalizedLine(this StringBuilder sb, string value)
    {
        sb.Append(value);
        sb.Append(Newline);
        return sb;
    }
}