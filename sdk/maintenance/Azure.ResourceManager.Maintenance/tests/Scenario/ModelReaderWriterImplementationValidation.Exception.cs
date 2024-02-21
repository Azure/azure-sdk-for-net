// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions",
                "Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions",
                "Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceGetApplyUpdatesByParentOptions",
                "Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceGetConfigurationAssignmentByParentOptions",
            };
        }
    }
}
