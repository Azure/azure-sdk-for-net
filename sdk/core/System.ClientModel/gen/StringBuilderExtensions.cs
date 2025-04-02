﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace System.ClientModel.SourceGeneration;

internal static class StringBuilderExtensions
{
    public static void AppendLine(this StringBuilder builder, int indent, string value)
    {
        if (indent > 0)
        {
            builder.Append(' ', indent * 4);
        }

        builder.AppendLine(value);
    }

    public static void Append(this StringBuilder builder, int indent, string value)
    {
        if (indent > 0)
        {
            builder.Append(' ', indent * 4);
        }

        builder.Append(value);
    }

    public static void RemoveLastLine(this StringBuilder builder)
    {
        if (builder.Length == 0)
            return;

        int length = builder.Length;

        int lastNewlineIndex = builder.ToString().LastIndexOf('\n');

        if (lastNewlineIndex == -1)
        {
            return;
        }

        // Handle Windows "\r\n" case
        if (lastNewlineIndex > 0 && builder[lastNewlineIndex - 1] == '\r')
        {
            lastNewlineIndex--;
        }

        builder.Length = lastNewlineIndex;
    }

    public static void AppendVariableList(this StringBuilder builder, int rank, string elementName)
    {
        for (int i = 0; i < rank; i++)
        {
            builder.Append("List<");
        }
        builder.Append(elementName);
        builder.Append('>', rank);
    }
}
