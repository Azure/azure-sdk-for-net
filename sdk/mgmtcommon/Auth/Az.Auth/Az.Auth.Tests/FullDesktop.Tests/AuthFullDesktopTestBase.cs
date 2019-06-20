// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Az.Auth.FullDesktop.Test
{
    using System;
    using System.IO;
    using System.Reflection;


    public class AuthFullDesktopTestBase
    {
        private bool IsLiteralDirty = false;
        private string _literalCnnString;
        string _testOutputDir;

        public string TestOutputDir
        {
            get
            {
                if (string.IsNullOrEmpty(_testOutputDir))
                {
                    string codeBasePath = Assembly.GetExecutingAssembly().CodeBase;
                    var uri = new UriBuilder(codeBasePath);
                    string path = Uri.UnescapeDataString(uri.Path);
                    _testOutputDir = Path.GetDirectoryName(path);
                }

                return _testOutputDir;
            }
        }

        public string TestOutputAssemblyLocation { get; set; }

        public AuthFullDesktopTestBase(string connectionString)
        {
            TestOutputAssemblyLocation = Assembly.GetExecutingAssembly().CodeBase;
        }

        public AuthFullDesktopTestBase() : this(connectionString: string.Empty) { }

        protected string GetProductAssemblyPath()
        {
            string prodAsmName = "Microsoft.Rest.ClientRuntime.Azure.Authentication.dll";
            string asmPath = Path.Combine(this.TestOutputDir, prodAsmName);

            if (File.Exists(asmPath))
            {
                return asmPath;
            }
            else
                return string.Empty;
        }
    }
}