// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SkipIfNoConnectionStringAttribute : FactAttribute
    {
        public SkipIfNoConnectionStringAttribute()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWPS_CONNECTION_STRING")))
            {
                Skip = "Connection string is not available";
            }
        }
    }
}
