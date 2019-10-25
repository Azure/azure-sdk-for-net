// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.CodeAnalysis.Options;

namespace SnippetGenerator
{
    public class Program
    {

        [Option(ShortName = "b")]
        public string BasePath { get; set; }

        public void OnExecuteAsync()
        {
            foreach (var sdkDir in Directory.GetDirectories(BasePath))
            {
                new DirectoryProcessor(sdkDir).Process();
            }
        }

        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }
}
