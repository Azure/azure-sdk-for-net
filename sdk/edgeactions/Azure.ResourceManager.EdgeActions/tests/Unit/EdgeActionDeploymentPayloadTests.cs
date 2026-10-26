// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionDeploymentPayloadTests
    {
        [Test]
        public void FilePayloadContainsHandler()
        {
            byte[] payload = Convert.FromBase64String(EdgeActionLifecycleTests.CreateCode("file"));
            Assert.That(Encoding.UTF8.GetString(payload), Is.EqualTo("function handler(event) { return event; }"));
        }

        [Test]
        public void ZipPayloadContainsSameHandlerWithFixedMetadata()
        {
            byte[] payload = Convert.FromBase64String(EdgeActionLifecycleTests.CreateCode("zip"));
            using var stream = new MemoryStream(payload);
            using var archive = new ZipArchive(stream, ZipArchiveMode.Read);
            Assert.That(archive.Entries.Count, Is.EqualTo(1));
            ZipArchiveEntry entry = archive.Entries[0];
            Assert.That(entry.FullName, Is.EqualTo("handler.js"));
            Assert.That(entry.LastWriteTime.DateTime, Is.EqualTo(new DateTime(1980, 1, 1)));
            Assert.That(entry.ExternalAttributes, Is.Zero);
            using var reader = new StreamReader(entry.Open());
            Assert.That(reader.ReadToEnd(), Is.EqualTo(Encoding.UTF8.GetString(
                Convert.FromBase64String(EdgeActionLifecycleTests.CreateCode("file")))));
        }
    }
}
