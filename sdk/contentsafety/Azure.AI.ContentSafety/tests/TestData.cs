// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests
{
    internal class TestData
    {
        public static string TestText = "You are an idiot";

        public static string TestImageLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "Samples", "sample_data", "image.jpg");
    }
}
