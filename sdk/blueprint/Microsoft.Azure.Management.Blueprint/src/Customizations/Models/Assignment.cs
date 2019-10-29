// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Blueprint.Models
{
    public partial class Assignment : TrackedResource
    {
        public bool IsTerminalState()
        {
            if (this.ProvisioningState == AssignmentProvisioningState.Succeeded ||
                this.ProvisioningState == AssignmentProvisioningState.Failed ||
                this.ProvisioningState == AssignmentProvisioningState.Canceled)
            {
                return true;
            }

            return false;
        }
    }
}
