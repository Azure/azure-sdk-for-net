// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Azure.SameBoundary.Input.Tests
{
    public static class TestHelper
    {
        // I expected to call ModerReaderWriter.Write(), however, IsJsonFormatRequested haven't supported "JMP" options. So I have to call IJsonModel.Write.
        public static string ReadJsonFromModel<T>(IJsonModel<T> model)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.Write(writer, new ModelReaderWriterOptions("JMP"));
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static bool AreEqualJson(dynamic expected, dynamic actual)
        {
            if (expected == actual)
            {
                return true;
            }
            if (expected == null && actual != null || expected != null && actual == null)
            {
                return false;
            }

            var expectedObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(expected);
            var actualObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(actual);

            if (expectedObject.Count != actualObject.Count)
            {
                return false;
            }

            foreach (var key in expectedObject.Keys)
            {
                if (!actualObject.ContainsKey(key) || !AreEqualJson(expectedObject[key], actualObject[key]))
                {
                    return false;
                }
            }

            return true;
        }

        public static string ReadJsonFromFile(string file)
        {
            var path = Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", file));
            return File.ReadAllText(path);
        }
    }
}
