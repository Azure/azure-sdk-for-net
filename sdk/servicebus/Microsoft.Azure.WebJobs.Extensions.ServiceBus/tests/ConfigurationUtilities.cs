// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.ServiceBus.Tests
{
    public static class ConfigurationUtilities
    {
        public static IConfiguration CreateConfiguration(params KeyValuePair<string, string>[] data)
        {
            return new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        }
    }
}
