// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.Automation.Models;

namespace Azure.ResourceManager.Automation
{
    public partial class AutomationAccountPython2PackageCollection
    {
        /// <summary>
        /// Create or Update the python 2 package identified by package name.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="packageName"> The python package name. </param>
        /// <param name="content"> The create or update parameters for python package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<AutomationAccountPython2PackageResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string packageName, AutomationAccountPython2PackageCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, packageName, content?.ToAutomationPythonPackageCreateOrUpdateContent(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create or Update the python 2 package identified by package name.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="packageName"> The python package name. </param>
        /// <param name="content"> The create or update parameters for python package. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<AutomationAccountPython2PackageResource> CreateOrUpdate(WaitUntil waitUntil, string packageName, AutomationAccountPython2PackageCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, packageName, content?.ToAutomationPythonPackageCreateOrUpdateContent(), cancellationToken);
        }
    }
}
