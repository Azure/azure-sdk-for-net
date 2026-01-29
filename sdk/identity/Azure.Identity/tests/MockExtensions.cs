// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.TestFramework;

namespace Azure.Identity.Tests
{
    internal static class MockExtensions
    {
        public static MockResponse WithContent(this MockResponse response, string content)
        {
            response.SetContent(content);

            return response;
        }
    }
}
