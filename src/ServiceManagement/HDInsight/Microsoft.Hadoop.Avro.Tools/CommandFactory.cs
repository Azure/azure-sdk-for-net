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

    internal sealed class CommandFactory
    {
        public static readonly Dictionary<string, Func<ICommand>> Commands = new Dictionary<string, Func<ICommand>>(StringComparer.CurrentCultureIgnoreCase)
        {
            { new CodeGenerationCommand().Name, () => new CodeGenerationCommand() },
            { new HelpCommand().Name, () => new HelpCommand() }
        };

        public ICommand Create(string command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (!Commands.ContainsKey(command))
            {
                throw new ArgumentException("Command does not exists.");
            }

            return Commands[command]();
        }
    }
}
