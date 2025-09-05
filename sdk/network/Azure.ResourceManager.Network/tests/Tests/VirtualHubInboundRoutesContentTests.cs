// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Network.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class VirtualHubInboundRoutesContentTests
    {
        [Test]
        public void WriteResourceUri_WritesAbsoluteUri()
        {
            var model = new VirtualHubInboundRoutesContent();
            var absoluteUri = new Uri("https://example.com/resource");
            typeof(VirtualHubInboundRoutesContent)
                .GetProperty("ResourceUri")
                .SetValue(model, absoluteUri);

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.WriteResourceUri(writer, default);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Contains(absoluteUri.AbsoluteUri));
        }

        [Test]
        public void WriteResourceUri_WritesRelativeUri()
        {
            var model = new VirtualHubInboundRoutesContent();
            var relativeUri = new Uri("relative/path", UriKind.Relative);
            typeof(VirtualHubInboundRoutesContent)
                .GetProperty("ResourceUri")
                .SetValue(model, relativeUri);

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            model.WriteResourceUri(writer, default);
            writer.Flush();
            var json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.IsTrue(json.Contains(relativeUri.OriginalString));
        }

        [Test]
        public void DeserializeResourceUri_ParsesNonEmptyString()
        {
            var uriString = "https://example.com/resource";
            var json = $"{{\"resourceUri\":\"{uriString}\"}}";
            var doc = JsonDocument.Parse(json);
            var content = VirtualHubInboundRoutesContent.DeserializeVirtualHubInboundRoutesContent(doc.RootElement, default);
            Assert.AreEqual(content.ResourceUri, new Uri(uriString));

            uriString = "relative/path";
            json = $"{{\"resourceUri\":\"{uriString}\"}}";
            doc = JsonDocument.Parse(json);
            content = VirtualHubInboundRoutesContent.DeserializeVirtualHubInboundRoutesContent(doc.RootElement, default);
            Assert.AreEqual(content.ResourceUri.ToString(), uriString);
        }

        [Test]
        public void DeserializeResourceUri_ParsesEmptyStringAsRelative()
        {
            var json = "{\"resourceUri\":\"\"}";
            using var doc = JsonDocument.Parse(json);
            var property = doc.RootElement.GetProperty("resourceUri");
            var content = VirtualHubInboundRoutesContent.DeserializeVirtualHubInboundRoutesContent(doc.RootElement, default);
            Assert.AreEqual(content.ResourceUri, new Uri("", UriKind.Relative));
        }

        [Test]
        public void DeserializeResourceUri_NullValue()
        {
            var json = "{\"resourceUri\":null}";
            using var doc = JsonDocument.Parse(json);
            var property = doc.RootElement.GetProperty("resourceUri");
            var content = VirtualHubInboundRoutesContent.DeserializeVirtualHubInboundRoutesContent(doc.RootElement, default);
            Assert.IsNull(content.ResourceUri);
        }
    }
}
