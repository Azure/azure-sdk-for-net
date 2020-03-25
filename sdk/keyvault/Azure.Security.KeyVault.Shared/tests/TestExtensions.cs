// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    internal static class TestExtensions
    {
        public static TestCaseData ConditionalIgnore(this TestCaseData source, bool condition, string reason)
        {
            if (condition)
            {
                return source.Ignore(reason);
            }

            return source;
        }
    }
}
