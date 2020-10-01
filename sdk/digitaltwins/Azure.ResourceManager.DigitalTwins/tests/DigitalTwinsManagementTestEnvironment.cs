// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.DigitalTwins.Tests
{
    public class DigitalTwinsManagementTestEnvironment : TestEnvironment
    {
        public DigitalTwinsManagementTestEnvironment()
            : base("digitaltwins")
        {
        }
    }
}
