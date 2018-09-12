// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace GuestConfiguration.Tests.Helpers
{

    using Microsoft.Azure.Management.GuestConfiguration.Models;

    public class GuestConfigurationAssignmentForPutDefinition
    {
        public GuestConfigurationAssignmentForPutDefinition(string resourceGroupName, string vmName, GuestConfigurationAssignment parameters)
        {
            this.ResourceGroupName = resourceGroupName;
            this.VmName = vmName;
            this.Parameters = parameters;
        }

        public string ResourceGroupName { get; private set; }

        public string VmName { get; private set; }

        public GuestConfigurationAssignment Parameters { get; private set; }

        public GuestConfigurationAssignment GetParametersForUpdate()
        {
            if(this.Parameters != null && this.Parameters.Properties != null && this.Parameters.Properties.Context != null)
            {
                this.Parameters.Properties.Context = "Azure Policy B";
            }
            return this.Parameters;
        }
    }
}
