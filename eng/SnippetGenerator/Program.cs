// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
                Parallel.ForEach(Directory.GetDirectories(BasePath), sdkDir => new DirectoryProcessor(sdkDir).Process());
            }
            else
            {
                new DirectoryProcessor(BasePath).Process();
            }
        }

        public static int Main(string[] args)
        {
            try
            {
                return CommandLineApplication.Execute<Program>(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                return 1;
            }

        }
    }
}
