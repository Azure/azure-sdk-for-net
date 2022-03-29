// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Azure.IoT.ModelsRepository.Tests
{
    /// <summary>
    /// This class will initialize settings for ModelsRepositoryClient tests.
    /// </summary>
    public abstract class ModelsRepositoryTestBase
    {
        public ModelsRepositoryTestBase()
        {
        }

        public static string ParseRootDtmiFromJson(string json)
        {
            var options = new JsonDocumentOptions
            {
                AllowTrailingCommas = true
            };

            string dtmi = string.Empty;
            using (JsonDocument document = JsonDocument.Parse(json, options))
            {
                dtmi = document.RootElement.GetProperty("@id").GetString();
            }
            return dtmi;
        }

        public static void AddMetadataToLocalRepository(bool supportsExpanded = true)
        {
            var metadata = new ModelsRepositoryMetadata();
            metadata.Features.Expanded = supportsExpanded;
            string metadataFilePath = DtmiConventions.GetMetadataUri(new Uri(TestLocalModelsRepository)).LocalPath;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string metadataJsonString = JsonSerializer.Serialize(metadata, options);
            File.WriteAllText(metadataFilePath, metadataJsonString);
        }

        public static void RemoveMetadataFromLocalRepository()
        {
            string metadataFilePath = DtmiConventions.GetMetadataUri(new Uri(TestLocalModelsRepository)).LocalPath;
            if (File.Exists(metadataFilePath))
            {
                File.Delete(metadataFilePath);
            }
        }

        // The global endpoint contains metadata.
        public static readonly string ProdRemoteModelsRepositoryCDN = ModelsRepositoryConstants.DefaultModelsRepository;

        // The GitHub repo does not contain metadata.
        public static readonly string ProdRemoteModelsRepositoryGithub = "https://raw.githubusercontent.com/Azure/iot-plugandplay-models/main/";

        public static string TestDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        // Does not contain metadata.
        public static string TestLocalModelsRepository = Path.Combine(TestDirectoryPath, "TestModelRepo");

        // Contains metadata.
        public static string TestLocalModelsRepositoryWithMetadata = Path.Combine(TestDirectoryPath, "TestModelRepo", "MetadataModelRepo");

        public enum ClientType
        {
            Local,
            Remote
        }
    }
}
