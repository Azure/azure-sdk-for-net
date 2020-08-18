// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Learn.AppConfig.Samples
{
    public class AppConfigClientTestEnvironment : TestEnvironment
    {
        public AppConfigClientTestEnvironment() : base("api-learn")
        {
        }
    }
}
