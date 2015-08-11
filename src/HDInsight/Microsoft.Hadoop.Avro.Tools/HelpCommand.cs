// Copyright (c) Microsoft Corporation
// All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Tools
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Properties;

    internal class HelpCommand : ICommand
    {
        internal static readonly string CommandPrefix = "/C:";

        public void Execute(string[] args, IExecutionContext context)
        {
            if (!args.Any())
            {
                context.Out(this.GetCommandsList());
                return;
            }

            if (args[0].Length > 3 && args[0].StartsWith(CommandPrefix, StringComparison.OrdinalIgnoreCase))
            {
                var command = string.Concat(args[0].Skip(3));
                var usage = new CommandFactory().Create(command).GetUsage();
                context.Out(usage);
                return;
            }

            throw new ToolException(Resources.InvalidArgsErrorMessage, this.GetCommandsList(), ExitCode.InvalidArguments);
        }

        public string GetCommandsList()
        {
            var commands = CommandFactory.Commands.Select(pair => new CommandFactory().Create(pair.Key)).ToList();

            var result = string.Format(
                CultureInfo.InvariantCulture,
                Resources.HelpCommandExecListCommands,
                GetApplictionName(),
                commands.Aggregate(
                    string.Empty,
                    (current, command) =>
                    current
                    + (string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.HelpCommandExecListCommandsListLineFormat,
                        command.Name,
                        command.GetSynopsis()) + '\n')));

            return result + 
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.HelpCommandExecHowTo,
                    GetApplictionName(),
                    this.Name);
        }

        public string GetUsage()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.HelpCommandUsage,
                this.GetSynopsis(),
                this.GetSyntax(),
                CommandPrefix,
                this.Name,
                CommandPrefix,
                new CodeGenerationCommand().Name,
                new CodeGenerationCommand().Name);
        }

        public string GetSyntax()
        {
            return string.Format(CultureInfo.InvariantCulture,
                Resources.HelpCommandSyntax,
                this.Name,
                CommandPrefix);
        }

        public string GetSynopsis()
        {
            return Resources.HelpCommandSynopsis;
        }

        private static string GetApplictionName()
        {
            string fullName = Environment.GetCommandLineArgs()[0];
            return fullName.Substring(fullName.LastIndexOf('\\') + 1);
        }

        public string Name
        {
            get { return "Help"; }
        }
    }
}
