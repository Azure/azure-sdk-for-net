// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    public partial class AutomationAccountPython2PackageResource
    {
        /// <summary>
        /// Update the python 2 package identified by package name.
        /// </summary>
        /// <param name="patch"> The update parameters for python package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AutomationAccountPython2PackageResource>> UpdateAsync(AutomationAccountPython2PackagePatch patch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(patch?.ToAutomationPythonPackagePatch(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update the python 2 package identified by package name.
        /// </summary>
        /// <param name="patch"> The update parameters for python package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AutomationAccountPython2PackageResource> Update(AutomationAccountPython2PackagePatch patch, CancellationToken cancellationToken = default)
        {
            return Update(patch?.ToAutomationPythonPackagePatch(), cancellationToken);
        }
    }
}