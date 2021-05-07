﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        public async Task OnExecuteAsync()
        {
            var baseDirectory = new DirectoryInfo(BasePath).Name;
            if (baseDirectory.Equals("sdk"))
            {
                var tasks = new List<Task>();
                foreach (var sdkDir in Directory.GetDirectories(BasePath))
                {
                    tasks.Add(new DirectoryProcessor(sdkDir).ProcessAsync());
                }

                await Task.WhenAll(tasks);
            }
            else
            {
                await new DirectoryProcessor(BasePath).ProcessAsync();
            }
        }

        public static int Main(string[] args)
        {
            ConsoleColor foreground = Console.ForegroundColor;

            try
            {
                return CommandLineApplication.Execute<Program>(args);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.Error.WriteLine(e.ToString());
                return 1;
            }
            finally
            {
                Console.ForegroundColor = foreground;
            }
        }
    }
}
