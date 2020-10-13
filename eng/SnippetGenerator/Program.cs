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
            var baseDirectory = new DirectoryInfo(BasePath).Name;
            var baseDirParent = Directory.GetParent(BasePath).Name;
            if (baseDirectory.Equals("sdk") || baseDirParent.Equals("sdk"))
            {
                foreach (var sdkDir in Directory.GetDirectories(BasePath))
                {
                    new DirectoryProcessor(sdkDir).Process();
                }
            }
            else 
            {
                new DirectoryProcessor(BasePath).Process();
            }
        }

        public static int Main(string[] args)
        {
            return CommandLineApplication.Execute<Program>(args);
        }
    }
}
