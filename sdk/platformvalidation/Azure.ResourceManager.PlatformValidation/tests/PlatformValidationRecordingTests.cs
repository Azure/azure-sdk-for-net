// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Azure.ResourceManager.PlatformValidation.Tests
{
    public class PlatformValidationRecordingTests
    {
        [Test]
        public void SanitizeVhdInEmbeddedDocuments(
            [Values(0, 1, 2)] int depth,
            [Values("https://example.invalid/private.vhd?sp=r&sig=fake-secret",
                "https://example.invalid/private-image?sig=fake-secret",
                "https://example.invalid/archive.vhd/private.vhd?sig=fake-secret")] string sourceVhdUri)
        {
            const string testStoreUri = "https://example.invalid/artifact.vhd?download=1";
            string body = JsonSerializer.Serialize(new
            {
                sourceVhdUri,
                testStoreUri
            });
            for (int i = 0; i < depth; i++)
            {
                body = JsonSerializer.Serialize(new { planConfigurationJson = body });
            }

            body = Regex.Replace(body, PlatformValidationManagementTestBase.SourceVhdUriPattern,
                PlatformValidationManagementTestEnvironment.SanitizedSourceVhdUri);
            Assert.That(body, Does.Not.Contain("fake-secret"));
            for (int i = 0; i < depth; i++)
            {
                using JsonDocument document = JsonDocument.Parse(body);
                body = document.RootElement.GetProperty("planConfigurationJson").GetString();
            }

            using JsonDocument configuration = JsonDocument.Parse(body);
            Assert.That(configuration.RootElement.GetProperty("sourceVhdUri").GetString(),
                Is.EqualTo(PlatformValidationManagementTestEnvironment.SanitizedSourceVhdUri));
            Assert.That(configuration.RootElement.GetProperty("testStoreUri").GetString(),
                Is.EqualTo(testStoreUri));
        }
    }
}
