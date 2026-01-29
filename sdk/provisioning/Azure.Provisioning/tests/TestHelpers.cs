// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests
{
    internal static class TestHelpers
    {
        public static string NormalizeLineEndings(this string input)
        {
            // Normalize line endings to LF
            return Regex.Replace(input, @"\r\n?", "\n");
        }

        public static void AssertExpression(string expected, IBicepValue bicepValue)
        {
            Assert.AreEqual(expected.NormalizeLineEndings(), bicepValue.ToString()?.NormalizeLineEndings());
        }

        public static void AssertExpression(string expected, BicepExpression expression)
        {
            Assert.AreEqual(expected.NormalizeLineEndings(), expression.ToString().NormalizeLineEndings());
        }
    }
}
