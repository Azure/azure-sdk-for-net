// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Azure.IoT.ModelsRepository.Tests
{
    /// <summary>
    /// This class will initialize all the settings and create and instance of the ModelsRepoClient.
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

        public static readonly string FallbackTestRemoteRepo = ModelsRepositoryConstants.DefaultModelsRepository;

        public static string TestDirectoryPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TestLocalModelRepository => Path.Combine(TestDirectoryPath, "TestModelRepo");

        public static string TestRemoteModelRepository => Environment.GetEnvironmentVariable("PNP_TEST_REMOTE_REPO") ?? FallbackTestRemoteRepo;

        public enum ClientType
        {
            Local,
            Remote
        }
    }
}
