// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.Blobs.Stress;

/// <summary>
///   Allows for reading and parsing a set of environment information in the
///   dotenv format.
/// </summary>
///
/// <seealso href="https://www.dotenv.org/"/>
///
internal static class EnvironmentReader
{
    /// <summary>
    ///   Loads a dotenv file and parses the contents.
    /// </summary>
    ///
    /// <param name="filePath">The full path, including filename, to the dotenv file.</param>
    ///
    /// <returns>The set of environment content parsed from the file.</returns>
    ///
    /// <exception cref="ArgumentException">Occurs when <paramref name="filePath"/> is <c>null</c> or empty.</exception>
    /// <exception cref="FileNotFoundException">Occurs when <paramref name="filePath" /> does not exist.</exception>
    /// <exception cref="FormatException">Occurs when a line of the file is malformed or the file contains duplicate environment variables.</exception>
    ///
    public static Dictionary<string, string> LoadFromFile(string filePath)
    {
        Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The environment file was not found.in '{filePath}'");
        }

        var environment = new Dictionary<string, string>();
        var count = 0;

        foreach (var fileLine in ReadFileLines(filePath))
        {
            ++count;

            var line = fileLine.AsSpan();
            var firstCharacterPos = FindFirstCharacterIndex(line);

            if ((firstCharacterPos == -1) || (line[firstCharacterPos] == '#'))
            {
                continue;
            }

            var separator = line.IndexOf('=');

            if (separator == -1)
            {
                throw new FormatException($"The environment file is malformed at line {count}: '{line.ToString()}'");
            }

            try
            {
                var parsedKey = line.Slice(firstCharacterPos, separator).Trim().ToString();
                var parsedValue = line.Slice(separator + 1).Trim().Trim('"').ToString();

                if (environment.ContainsKey(parsedKey))
                {
                    environment[parsedKey] = parsedValue;
                }
                else
                {
                    environment.Add(parsedKey, parsedValue);
                }
            }
            catch (ArgumentException ex)
            {
                throw new FormatException(ex.Message, ex);
            }
        }

        return environment;
    }

    /// <summary>
    ///  Reads all lines from a file.
    /// </summary>
    ///
    /// <param name="filePath">The full path, including filename, to the file to be read.</param>
    ///
    /// <returns>An enumerable of the lines in a file.</returns>
    ///
    private static IEnumerable<string> ReadFileLines(string filePath)
    {
        using var reader = new StreamReader(filePath);

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }

    /// <summary>
    ///   Finds the first non-whitespace character in a line of text.
    /// </summary>
    ///
    /// <param name="line">The line of text to consider.</param>
    ///
    /// <returns>The index of the first non-whitespace character; -1, if no character was found.</returns>
    ///
    private static int FindFirstCharacterIndex(ReadOnlySpan<char> line)
    {
        var position = 0;
        var length = line.Length;

        while ((position < length) && (char.IsWhiteSpace(line[position])))
        {
            ++position;
        }

        return (position < length) ? position : -1;
    }
}
