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
    using System.Diagnostics.CodeAnalysis;
    using System.Management.Automation.Runspaces;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.PowerShellTestAbstraction.Interfaces;
    using Fx = Microsoft.WindowsAzure.Management.HDInsight.Framework;

    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly",
        Justification = "Anything derived from Disposable Object is correct. [tgs]")]
    public class RunspaceAbstraction : Disposable.DisposableObject, IRunspace
    {
        protected Runspace Runspace { get; private set; }

        public RunspaceAbstraction(Runspace runspace)
        {
            this.Runspace = runspace;
        }

        public static IRunspace Create()
        {
            var runspace = Help.SafeCreate(() => RunspaceFactory.CreateRunspace());
            runspace.Open();
            return new RunspaceAbstraction(runspace);
        }

        public IPipeline NewPipeline()
        {
            return Help.SafeCreate(() => new PipelineAbstraction(this.Runspace.CreatePipeline(), this.Runspace));
        }
    }
}
