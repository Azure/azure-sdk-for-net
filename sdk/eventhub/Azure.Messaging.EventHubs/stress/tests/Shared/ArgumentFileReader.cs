using System;
using System.Collections.Generic;
using System.IO;

internal static class ArgumentFileReader
{
    public static IEnumerable<string> Read(string filePath)
    {
        if ((String.IsNullOrEmpty(filePath)) || (!File.Exists(filePath)))
        {
            yield break;
        }

        using var reader = new StringReader(File.ReadAllText(filePath));

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            yield return line;
        }

        yield break;
    }

}