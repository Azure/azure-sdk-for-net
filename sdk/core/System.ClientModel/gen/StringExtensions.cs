// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;

namespace System.ClientModel.SourceGeneration;

internal static class StringExtensions
{
    private const int Generic = 1;
    private const int Array = 2;

    private static readonly Dictionary<char, string?> s_toIdentifierReplacements = new()
    {
        { '.', "_" },
        { '<', "_" },
        { '>', "" },
        { '[', "_Array" },
        { ']', "" },
    };

    public static string ToCamelCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return value;
        }
        return char.ToLowerInvariant(value[0]) + value.Substring(1);
    }

    public static string ToIdentifier(this string input, bool toCamelCase)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        string identifier = input.ReplaceCharacters(s_toIdentifierReplacements);
        if (toCamelCase)
        {
            identifier = identifier.ToCamelCase();
        }
        return identifier;
    }

    public static string RemovePeriods(this string input)
        => input.RemoveCharacters('.');

    public static string RemoveAsterisks(this string input)
        => input.RemoveCharacters('*');

    public static string RemoveCharacters(this string input, char character)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        Span<char> buffer = stackalloc char[input.Length];
        int index = 0;

        foreach (char c in input)
        {
            if (c != character)
                buffer[index++] = c;
        }

        return buffer.Slice(0, index).ToString();
    }

    public static string ReplaceCharacters(this string input, Dictionary<char, string?> replacements)
    {
        Stack<int> state = [];
        int length = input.Length;
        if (length == 0)
        {
            return input;
        }
        int dimensions = 0;

        StringBuilder buffer = new(length);

        for (int i = 0; i < length; i++)
        {
            switch (input[i])
            {
                case '<':
                    state.Push(Generic);
                    break;
                case '>':
                    state.Pop();
                    break;
                case '[':
                    state.Push(Array);
                    break;
                case ']':
                    state.Pop();
                    break;
            }

            if (!replacements.TryGetValue(input[i], out var replacement))
            {
                if (input[i] == ',')
                {
                    var current = state.Peek();
                    if (current == Generic)
                    {
                        buffer.Append('_');
                        if (i + 1 < length && input[i + 1] == ' ')
                        {
                            i++;
                        }
                    }
                    else
                    {
                        buffer.Append("_d");
                        buffer.Append(++dimensions);
                    }
                }
                else
                {
                    buffer.Append(input[i]);
                }
            }
            else
            {
                if (replacement is not null)
                {
                    buffer.Append(replacement);
                }
            }
        }

        buffer.Append('_');

        return buffer.ToString();
    }
}
