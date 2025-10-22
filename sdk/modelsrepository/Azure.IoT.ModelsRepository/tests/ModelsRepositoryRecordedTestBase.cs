// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.IoT.ModelsRepository.Tests
{
    public class ModelsRepositoryRecordedTestBase : RecordedTestBase<ModelsRepositoryTestEnvironment>
    {
        protected const string TestModeEnvVariable = "AZURE_TEST_MODE";

        protected static RecordedTestMode TestMode => (RecordedTestMode)Enum.Parse(
            typeof(RecordedTestMode),
            Environment.GetEnvironmentVariable(TestModeEnvVariable) ?? "Playback");

        public ModelsRepositoryRecordedTestBase(bool isAsync) : base(isAsync, TestMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
#if NETFRAMEWORK
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
        }

        protected ModelsRepositoryClient GetClient(
            ModelsRepositoryTestBase.ClientType clientType,
            bool hasMetadata,
            ModelsRepositoryClientOptions options = default)
        {
            string targetLocation;

            if (clientType == ModelsRepositoryTestBase.ClientType.Local)
            {
                targetLocation = hasMetadata
                    ? ModelsRepositoryTestBase.TestLocalModelsRepositoryWithMetadata
                    : ModelsRepositoryTestBase.TestLocalModelsRepository;
            }
            else
            {
                targetLocation = hasMetadata
                    ? ModelsRepositoryTestBase.ProdRemoteModelsRepositoryCDN
                    : ModelsRepositoryTestBase.ProdRemoteModelsRepositoryGithub;
            }

            return GetClient(repositoryLocation: targetLocation, options: options);
        }

        protected ModelsRepositoryClient GetClient(
            ModelsRepositoryTestBase.ClientType clientType = ModelsRepositoryTestBase.ClientType.Local,
            string repositoryLocation = null,
            ModelsRepositoryClientOptions options = default)
        {
            if (options == null)
            {
                options = new ModelsRepositoryClientOptions();
            }

            if (string.IsNullOrEmpty(repositoryLocation))
            {
                repositoryLocation = clientType == ModelsRepositoryTestBase.ClientType.Local
                    ? ModelsRepositoryTestBase.TestLocalModelsRepository
                    : ModelsRepositoryTestBase.ProdRemoteModelsRepositoryCDN;
            }

            return InstrumentClient(new ModelsRepositoryClient(new Uri(repositoryLocation), InstrumentClientOptions(options)));
        }
    }
}
