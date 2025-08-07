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
                "Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportCollectionGetAllOptions",
                "Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportEvidenceCollectionGetAllOptions",
                "Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportSnapshotCollectionGetAllOptions",
                "Azure.ResourceManager.AppComplianceAutomation.Models.AppComplianceReportWebhookCollectionGetAllOptions"
            };
        }
    }
}
