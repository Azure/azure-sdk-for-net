// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTAINERREGISTRY_ENDPOINT");
        public string Registry => GetRecordedVariable("CONTAINERREGISTRY_REGISTRY_NAME");
        public string AnonymousAccessEndpoint => GetRecordedVariable("CONTAINERREGISTRY_ANONREGISTRY_ENDPOINT");
        public string AnonymousAccessRegistry => GetRecordedVariable("CONTAINERREGISTRY_ANONREGISTRY_NAME");
    }
}
