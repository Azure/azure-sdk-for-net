// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class SdkBuildTestBase
    {

        public string TestBinaryOutputDir { get; set; }
        public string TestDataRuntimeDir { get; set; }

        public SdkBuildTestBase()
        {
            string codeBasePath = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBasePath);
            string path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);

            TestBinaryOutputDir = path;
            TestDataRuntimeDir = Path.Combine(TestBinaryOutputDir, "TestData");
        }
    }
}
