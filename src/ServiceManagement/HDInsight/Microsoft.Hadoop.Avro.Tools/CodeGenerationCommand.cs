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
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Tools.Properties;
    using Microsoft.Hadoop.Avro.Utils;

    internal class CodeGenerationCommand : ICommand
    {
        private const string InputArgumentPrefix = "/I:";
        private const string OutputArgumentPrefix = "/O:";
        private const string NamespaceArgumentPrefix = "/N[F]:";
        private const string NamespaceArgumentRegexPattern = "/N[F]?:";

        public void Execute(string[] args, IExecutionContext context)
        {
            var configuration = this.ParseArguments(args, context);

            try
            {
                IEnumerable<TypeSchema> schemas =
                    configuration.JsonSchemas.SelectMany(CodeGenerator.ResolveCodeGeneratingSchemas)
                        .GroupBy(t => t.ToString())
                        .Select(g => g.First())
                        .ToList();

                if (schemas.Any())
                {
                    foreach (var schema in schemas)
                    {
                        var filePath = Path.Combine(configuration.OutputDirectory, ((NamedSchema)schema).Name + ".cs");
                        using (var memoryStream = new MemoryStream())
                        {
                            CodeGenerator.Generate(schema, configuration.Namespace, configuration.ForceNamespace, memoryStream);
                            context.WriteFile(filePath, memoryStream);
                        }

                        context.Out(string.Format(CultureInfo.InvariantCulture, Resources.GenerationInfoMessage, filePath));
                    }
                    context.Out(Resources.GenerationFinishedMessage);
                }
                else
                {
                    context.Out(Resources.NoSchemataForGeneration);
                }
            }
            catch (Exception exception)
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.GenerationError, exception.Message),
                    string.Empty,
                    ExitCode.InvalidOperation);
            }
        }

        public string GetSyntax()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.CodeGenerationCommandSyntax,
                this.Name,
                InputArgumentPrefix,
                OutputArgumentPrefix,
                NamespaceArgumentPrefix);
        }

        public string GetSynopsis()
        {
            return Resources.CodeGenerationCommandSynopsis;
        }

        public string GetUsage()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                Resources.CodeGenerationCommandDescription,
                this.GetSynopsis(),
                this.GetSyntax(),
                InputArgumentPrefix,
                OutputArgumentPrefix,
                NamespaceArgumentPrefix,
                this.Name);
        }

        private CodeGenConfiguration ParseArguments(ICollection<string> args, IExecutionContext context)
        {
            this.Sanitize(args);

            var result = new CodeGenConfiguration();
            foreach (string arg in args)
            {
                if (arg.StartsWith(InputArgumentPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    this.SetInputFiles(arg, result, context);
                }
                else if (arg.StartsWith(OutputArgumentPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    this.SetOutputDirectory(arg, result, context);
                }
                else if (Regex.Match(arg, NamespaceArgumentRegexPattern, RegexOptions.IgnoreCase).Success)
                {
                    this.SetNamespace(arg, result);
                }
            }
            return result;
        }

        private void Sanitize(ICollection<string> args)
        {
            if (args.Count < 2)
            {
                throw new ToolException(Resources.MissingArgumentsError, ExitCode.InvalidArguments);
            }

            if (args.Count > 3)
            {
                throw new ToolException(Resources.ErrorTooManyArguments, ExitCode.InvalidArguments);
            }

            if (args.Count(arg => arg.StartsWith(InputArgumentPrefix, StringComparison.OrdinalIgnoreCase)) == 0)
            {
                throw new ToolException(Resources.ErrorMissingInputArguments, ExitCode.InvalidArguments);
            }

            if (args.Count(arg => arg.StartsWith(OutputArgumentPrefix, StringComparison.OrdinalIgnoreCase)) == 0)
            {
                throw new ToolException(Resources.ErrorMissingOutputArguments, ExitCode.InvalidArguments);
            }

            if (args.Count(arg => !arg.StartsWith(InputArgumentPrefix, StringComparison.OrdinalIgnoreCase) &&
                                  !arg.StartsWith(OutputArgumentPrefix, StringComparison.OrdinalIgnoreCase) &&
                                  !Regex.Match(arg, NamespaceArgumentRegexPattern, RegexOptions.IgnoreCase).Success) > 0)
            {
                throw new ToolException(Resources.ErrorSomeArgumentsInvalid, ExitCode.InvalidArguments);
            }
        }

        private void SetNamespace(string argument, CodeGenConfiguration configuration)
        {
            configuration.ForceNamespace = argument.IndexOf(':') > 2;
            var nspace = argument.Substring(argument.IndexOf(':') + 1);

            if (string.IsNullOrEmpty(nspace))
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.ErrorArgumentMissingItsValue, argument),
                    ExitCode.InvalidArguments);
            }

            configuration.Namespace = nspace;
        }

        private void SetInputFiles(string argument, CodeGenConfiguration configuration, IExecutionContext context)
        {
            if (argument.Length < 4)
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.ErrorArgumentMissingItsValue, argument),
                    ExitCode.InvalidArguments);
            }

            string inputFiles = argument.Substring(3);
            try
            {
                configuration.JsonSchemas = inputFiles.Split(',').Select(context.ReadFile).ToList();
            }
            catch (Exception exception)
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.ErrorReadFile, inputFiles, exception.Message),
                    ExitCode.InvalidOperation);
            }
        }

        private void SetOutputDirectory(string argument, CodeGenConfiguration configuration, IExecutionContext context)
        {
            if (argument.Length < 4)
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.ErrorArgumentMissingItsValue, argument),
                    ExitCode.InvalidArguments);
            }

            string outputDirectory = argument.Substring(3);
            try
            {
                context.SetOutputDirectory(outputDirectory);
                configuration.OutputDirectory = outputDirectory;
            }
            catch (Exception exception)
            {
                throw new ToolException(
                    string.Format(CultureInfo.InvariantCulture, Resources.ErrorWriteDirectory, outputDirectory, exception.Message),
                    ExitCode.InvalidOperation);
            }
        }

        public string Name
        {
            get { return "CodeGen"; }
        }

        private class CodeGenConfiguration
        {
            private string defaultNamespace = "Avro.CodeGen";

            public List<string> JsonSchemas { get; set; }

            public string Namespace
            {
                get { return this.defaultNamespace; }
                set { this.defaultNamespace = value; }
            }

            public string OutputDirectory { get; set; }

            public bool ForceNamespace { get; set; }
        }
    }
}
