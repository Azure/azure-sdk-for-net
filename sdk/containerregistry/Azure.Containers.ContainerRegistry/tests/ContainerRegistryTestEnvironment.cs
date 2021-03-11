// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Containers.ContainerRegistry.Tests
{
    public class ContainerRegistryTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("CONTAINERREGISTRY_ENDPOINT");
    }
}
