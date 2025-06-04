// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Provisioning.Generator;

public static class TextExtensions
{
    public static string? ToPascalCase(this string? name) =>
        string.IsNullOrEmpty(name) ?
            name :
            $"{char.ToUpperInvariant(name[0])}{name[1..]}";

    public static string? ToCamelCase(this string? name) =>
    string.IsNullOrEmpty(name) ?
        name :
        $"{char.ToLowerInvariant(name[0])}{name[1..]}";

    public static string? TrimSuffix(this string? name, string suffix) =>
        name is null || !name.EndsWith(suffix) ?
            name :
            name[..^suffix.Length];

    /// <summary>
    /// Word wrap a string of text to a given width.
    /// </summary>
    /// <param name='text'>The text to word wrap.</param>
    /// <param name='width'>Width available to wrap.</param>
    /// <returns>Lines of word wrapped text.</returns>
    public static IEnumerable<string> WordWrap(this string text, int width = 100)
    {
        int start = 0;      // Start of the current line
        int end = 0;        // End of the current line
        char last = ' ';    // Last character processed

        // Walk the entire string, processing line by line
        for (int i = 0; i < text.Length; i++)
        {
            // Support newlines inside the comment text.
            if (text[i] == '\n')
            {
                yield return text.Substring(start, i - start + 1).Trim();

                start = i + 1;
                end = start;
                last = ' ';

                continue;
            }

            // If our current line is longer than the desired wrap width,
            // we'll stop the line here
            if (i - start >= width && start != end)
            {
                // Yield the current line
                yield return text.Substring(start, end - start + 1).Trim();

                // Set things up for the next line
                start = end + 1;
                end = start;
                last = ' ';
            }

            // If the last character was a space, mark that spot as a
            // candidate for a potential line break
            if (!char.IsWhiteSpace(last) && char.IsWhiteSpace(text[i]))
            {
                end = i - 1;
            }

            last = text[i];
        }

        // Don't forget to include the last line of text
        if (start < text.Length)
        {
            yield return text[start..].Trim();
        }
    }
}