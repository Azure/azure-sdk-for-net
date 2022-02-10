// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;

namespace Samples
{
    /// <summary>
    /// Content factory.
    /// </summary>
    public class ContentFactory
    {
        /// <summary>
        /// Creates payload file.
        /// </summary>
        /// <param name="fileName">Filename of the file.</param>
        /// <returns>
        /// The new payload file.
        /// </returns>
        public string CreateAduPayloadFile(string fileName)
        {
            var content = new
            {
                name = "apt-update-test",
                version = "1.0",
                packages = new[]
                {
                    new
                    {
                        name = "libcurl4-doc"
                    }
                }
            };

            var filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, JsonSerializer.Serialize(content));

            return filePath;
        }

        /// <summary>
        /// Creates import manifest file.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="fileName">Filename of the file.</param>
        /// <param name="fileSize">Size of the file.</param>
        /// <param name="fileHash">The file hash.</param>
        /// <returns>
        /// The new import manifest file.
        /// </returns>
        public string CreateImportManifestContent(string manufacturer, string name, string version, string fileName, long fileSize, string fileHash)
        {
            var aduContent = new
            {
                UpdateId = new
                {
                    Provider = manufacturer,
                    Name = name,
                    Version = version
                },
                Compatibility = new[]
                {
                    new
                    {
                        DeviceManufacturer = manufacturer,
                        DeviceModel = name
                    }
                },
                UpdateType = "microsoft/apt:1",
                InstalledCriteria = $"apt-update-test-{version}",
                Files = new[]
                {
                    new
                    {
                        FileName = fileName,
                        SizeInBytes = fileSize,
                        Hashes = new { SHA256 = fileHash },
                        MimeType = "application/octet-stream",
                    }
                },
                CreatedDateTime = DateTime.UtcNow.ToString("O"),
                ManifestVersion = "3.0",
            };

            var filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, JsonSerializer.Serialize(aduContent));

            return filePath;
        }

        /// <summary>
        /// Creates import request body.
        /// </summary>
        /// <param name="importManifestUrl">URL of the import manifest.</param>
        /// <param name="importManifestFileSize">Size of the import manifest file.</param>
        /// <param name="importManifestFileHash">The import manifest file hash.</param>
        /// <param name="fileName">Filename of the file.</param>
        /// <param name="payloadUrl">URL of the payload.</param>
        /// <returns>
        /// The new import request body.
        /// </returns>
        public string CreateImportBody(string importManifestUrl, long importManifestFileSize, string importManifestFileHash, string fileName, string payloadUrl)
        {
            var content = new[]
            {
                new
                {
                    ImportManifest = new
                    {
                        Url = importManifestUrl,
                        SizeInBytes = importManifestFileSize,
                        Hashes = new
                        {
                            SHA256 = importManifestFileHash
                        }
                    },
                    Files = new[]
                    {
                        new
                        {
                            FileName = fileName,
                            Url = payloadUrl
                        }
                    },
                }
            };

            return JsonSerializer.Serialize(content);
        }
    }
}
