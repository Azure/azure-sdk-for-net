// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    internal static class JsonHelper
    {
        public static string ReadJson(string filepath)
        {
            string content = File.ReadAllText(filepath);
            using var document = JsonDocument.Parse(content);
            return JsonSerializer.Serialize(document);
        }
    }
}
