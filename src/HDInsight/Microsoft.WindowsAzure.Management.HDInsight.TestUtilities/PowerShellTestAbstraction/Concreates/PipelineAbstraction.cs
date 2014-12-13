// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.PowerShellTestAbstraction.Concreates
{
    using System.Linq;
    using System.Management.Automation.Runspaces;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.PowerShellTestAbstraction.Interfaces;

    public class PipelineAbstraction : RunspaceAbstraction, IPipeline
    {
        protected Pipeline Pipeline { get; private set; }

        internal PipelineAbstraction(Pipeline pipeline, Runspace runspace)
            : base(runspace)
        {
            this.Pipeline = pipeline;
        }

        public ICommand AddCommand(string commandName)
        {
            var command = new Command(commandName);
            this.Pipeline.Commands.Add(command);
            return Help.SafeCreate(() => new CommandAbstraction(command, this.Pipeline, this.Runspace));
        }

        public IPipelineResult Invoke()
        {
            var results = this.Pipeline.Invoke();
            return Help.SafeCreate(() => new PipelineResultsAbstraction(results, this.Runspace));
        }
    }
}
