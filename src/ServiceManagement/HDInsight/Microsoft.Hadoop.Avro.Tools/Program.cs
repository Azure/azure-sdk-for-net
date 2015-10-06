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
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    internal static class Program
    {
        public static int Main(string[] args)
        {
            return (int)Run(args, new ExecutionContext());
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exceptions are logged to stderr.")]
        internal static ExitCode Run(string[] args, IExecutionContext context)
        {
            try
            {
                var factory = new CommandFactory();
                factory.Create(args[0]).Execute(args.Skip(1).ToArray(), context);
                return ExitCode.Success;
            }
            catch (ToolException exception)
            {
                context.Error(exception.Message);
                if (!string.IsNullOrEmpty(exception.Out))
                {
                    context.Out(exception.Out);
                }
                return exception.ExitCode;
            }
            catch (Exception)
            {
                context.Error(Properties.Resources.InvalidArgsErrorMessage);
                context.Out(new HelpCommand().GetCommandsList());
                return ExitCode.InvalidArguments;
            }
        }
    }

    /// <summary>
    /// The exit codes.
    /// </summary>
    internal enum ExitCode
    {
        /// <summary>
        /// Indicates program success.
        /// </summary>
        Success = 0x0,

        /// <summary>
        /// Invalid operation.
        /// </summary>
        InvalidOperation = 0x1,

        /// <summary>
        /// Invalid arguments are provided by the user.
        /// </summary>
        InvalidArguments = 0xA0
    }
}