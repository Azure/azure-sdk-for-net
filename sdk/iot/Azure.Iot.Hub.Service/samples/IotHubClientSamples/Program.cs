// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using CommandLine;

namespace Azure.Iot.Hub.Service.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static void Main(string[] args)
        {
            // Parse and validate paramters

            CommandLineOptions options = null;
            ParserResult<CommandLineOptions> result = Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(parsedOptions =>
                {
                    options = parsedOptions;
                })
                .WithNotParsed(errors =>
                {
                    Environment.Exit(1);
                });
        }
    }
}
