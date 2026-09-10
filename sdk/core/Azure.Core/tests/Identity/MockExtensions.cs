// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.TestFramework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity
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
