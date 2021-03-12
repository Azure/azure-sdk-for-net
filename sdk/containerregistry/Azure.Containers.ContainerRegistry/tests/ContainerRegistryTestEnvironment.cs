// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetOptionalVariable("CONTAINERREGISTRY_ENDPOINT") ?? "SANITIZED";
        public string UserName => GetOptionalVariable("CONTAINERREGISTRY_USERNAME") ?? "SANITIZED";
        public string Password => GetOptionalVariable("CONTAINERREGISTRY_PASSWORD") ?? "SANITIZED";
    }
}
