// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTAINERREGISTRY_ENDPOINT");
        public string UserName => GetRecordedVariable("CONTAINERREGISTRY_USERNAME", options => options.IsSecret());
        public string Password => GetRecordedVariable("CONTAINERREGISTRY_PASSWORD", options => options.IsSecret());
        public string Registry => GetRecordedVariable("CONTAINERREGISTRY_REGISTRY_NAME");
    }
}
