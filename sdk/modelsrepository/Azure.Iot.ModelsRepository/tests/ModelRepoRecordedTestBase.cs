// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Iot.ModelsRepository.Tests
{
    public class ModelRepoRecordedTestBase : RecordedTestBase<ModelRepoTestEnvironment>
    {
        protected const string TestModeEnvVariable = "AZURE_TEST_MODE";

        protected static RecordedTestMode TestMode => (RecordedTestMode)Enum.Parse(
            typeof(RecordedTestMode),
            Environment.GetEnvironmentVariable(TestModeEnvVariable));

        public ModelRepoRecordedTestBase(bool isAsync) : base(isAsync, TestMode)
        {
        }

        [SetUp]
        public virtual void SetupE2eTestBase()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected ResolverClient GetClient(ModelRepoTestBase.ClientType clientType, ResolverClientOptions options = null)
        {
            if (options == null)
            {
                options = new ResolverClientOptions();
            }

            return
                clientType == ModelRepoTestBase.ClientType.Local
                ? InstrumentClient(
                    new ResolverClient(
                        new Uri(ModelRepoTestBase.TestLocalModelRepository),
                        InstrumentClientOptions(options)))
                : InstrumentClient(
                    new ResolverClient(
                        new Uri(ModelRepoTestBase.TestRemoteModelRepository),
                        InstrumentClientOptions(options)));
        }
    }
}
