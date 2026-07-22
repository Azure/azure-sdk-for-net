// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        // These are data models (not ARM resources) whose names end in "Resource",
        // so they are exempt from the ArmResource inheritance convention.
        [OneTimeSetUp]
        public void SetExceptionList()
        {
            ExceptionList = new string[]
            {
                "Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceExtensionResource",
                "Azure.ResourceManager.Compute.BulkActions.Models.OccurrenceResource",
                "Azure.ResourceManager.Compute.BulkActions.Models.ScheduledActionResource",
                "Azure.ResourceManager.Compute.BulkActions.Models.SubResource",
            };
        }
    }
}
