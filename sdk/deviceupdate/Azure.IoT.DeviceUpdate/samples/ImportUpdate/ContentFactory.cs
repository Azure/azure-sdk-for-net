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
                updateId = new
                {
                    provider = manufacturer,
                    name = name,
                    version = version
                },
                compatibility = new[]
                {
                    new
                    {
                        deviceManufacturer = manufacturer,
                        deviceModel = name
                    }
                },
                instructions = new
                {
                    steps = new[]
                    {
                        new
                        {
                            type = "inline",
                            handler = "microsoft/apt:1",
                            files = new [] { fileName },
                            handlerProperties = new
                            {
                                installedCriteria = $"apt-update-test-{version}",
                            }
                        }
                    }
                },
                files = new[]
                {
                    new
                    {
                        fileName = fileName,
                        sizeInBytes = fileSize,
                        hashes = new { SHA256 = fileHash },
                    }
                },
                createdDateTime = DateTime.UtcNow.ToString("O"),
                manifestVersion = "5.0",
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
                    importManifest = new
                    {
                        url = importManifestUrl,
                        sizeInBytes = importManifestFileSize,
                        hashes = new
                        {
                            SHA256 = importManifestFileHash
                        }
                    },
                    files = new[]
                    {
                        new
                        {
                            fileName = fileName,
                            url = payloadUrl
                        }
                    },
                }
            };

            return JsonSerializer.Serialize(content);
        }
    }
}
