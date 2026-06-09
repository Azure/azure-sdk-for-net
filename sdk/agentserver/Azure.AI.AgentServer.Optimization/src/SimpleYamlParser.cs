// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.AI.AgentServer.Optimization;

internal static class SimpleYamlParser
{
    public static Dictionary<string, object> ParseKeyValuePairs(string content)
    {
        var result = new Dictionary<string, object>(StringComparer.Ordinal);

        foreach (string rawLine in content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
        {
            string line = rawLine.Trim();
            if (line.Length == 0)
            {
                continue;
            }

            int separatorIndex = line.IndexOf(':');
            if (separatorIndex < 0)
            {
                throw new FormatException($"Invalid key/value line: '{line}'");
            }

            string key = line.Substring(0, separatorIndex).Trim();
            if (key.Length == 0)
            {
                throw new FormatException($"Invalid key/value line: '{line}'");
            }

            string value = line.Substring(separatorIndex + 1).Trim();
            result[key] = value;
        }

        return result;
    }

    public static string SerializeKeyValuePairs(Dictionary<string, string> data)
    {
        var builder = new StringBuilder();
        foreach (var pair in data)
        {
            builder.Append(pair.Key);
            builder.Append(": ");
            builder.Append(pair.Value);
            builder.Append('\n');
        }

        return builder.ToString();
    }
}
