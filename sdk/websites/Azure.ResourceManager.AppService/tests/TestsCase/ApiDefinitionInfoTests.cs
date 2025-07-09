// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.AppService.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    public class ApiDefinitionInfoTests
    {
        [TestCase("{\"url\":null}")]
        [TestCase("{\"url\":\"\"}")]
        public void DeserializeAppServiceApiDefinitionInfo_UrlNullOrEmpty_ResultsInNullUri(string json)
        {
            var options = new ModelReaderWriterOptions("J");
            using var doc = JsonDocument.Parse(json);
            var result = AppServiceApiDefinitionInfo.DeserializeAppServiceApiDefinitionInfo(doc.RootElement, options);
            Assert.IsNull(result.Uri);
        }

        [Test]
        public void Serialize_OmitsUrl_WhenUriIsNull()
        {
            var info = new AppServiceApiDefinitionInfo();
            using var memoryStream = new MemoryStream();
            var writer = new Utf8JsonWriter(memoryStream);
            var options = new ModelReaderWriterOptions("J");

            ((IJsonModel<AppServiceApiDefinitionInfo>)info).Write(writer, options);
            writer.Flush();

            string output = Encoding.UTF8.GetString(memoryStream.ToArray());
            StringAssert.DoesNotContain("\"url\"", output);
        }
    }
}
