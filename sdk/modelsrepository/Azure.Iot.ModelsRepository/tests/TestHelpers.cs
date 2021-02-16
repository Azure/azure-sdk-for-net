// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class TestHelpers
    {
        private static readonly string s_fallbackTestRemoteRepo = "https://devicemodels.azure.com/";

        public enum ClientType
        {
            Local,
            Remote
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

        public static ResolverClient GetTestClient(ClientType clientType, ResolverClientOptions clientOptions = null)
        {
            if (clientOptions == null)
            {
                clientOptions = new ResolverClientOptions();
            }

            if (clientType == ClientType.Local)
            {
                return new ResolverClient(TestLocalModelRepository, clientOptions);
            }

            if (clientType == ClientType.Remote)
            {
                return new ResolverClient(TestRemoteModelRepository, clientOptions);
            }

            throw new ArgumentException();
        }

        public static string TestDirectoryPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string TestLocalModelRepository => Path.Combine(TestDirectoryPath, "TestModelRepo");

        public static string TestRemoteModelRepository => Environment.GetEnvironmentVariable("PNP_TEST_REMOTE_REPO") ?? s_fallbackTestRemoteRepo;
    }
}
