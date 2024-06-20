// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json.Linq;
using System.ClientModel.Primitives;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text;
using System;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public static class TestHelper
    {
        // I expected to call ModelReaderWriter.Write(), however, IsJsonFormatRequested haven't supported "JMP" options. So I have to call IJsonModel.Write.
        public static string ReadJsonFromModel<T>(IJsonModel<T> model)
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.Write(writer, new ModelReaderWriterOptions("JMP"));
            writer.Flush();
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        public static T ReadModelFromFile<T>(string file) where T : IPersistableModel<T>
        {
            var path = Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", file));
            T model = ModelReaderWriter.Read<T>(new BinaryData(File.ReadAllBytes(path)));
            return model;
        }

        public static bool AreEqualJson(string expected, string actual)
        {
            var expectedObject = JToken.Parse(expected);
            var actualObject = JToken.Parse(actual);

            return JToken.DeepEquals(expectedObject, actualObject);
        }

        public static string ReadJsonFromFile(string file)
        {
            var path = Path.Combine(Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "TestData", file));
            return File.ReadAllText(path);
        }
    }
}
