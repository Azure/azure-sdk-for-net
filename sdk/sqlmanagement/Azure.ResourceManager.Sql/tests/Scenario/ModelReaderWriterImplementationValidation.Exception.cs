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
                "Azure.ResourceManager.Sql.Models.ManagedInstanceResourceGetTopQueriesOptions",
                "Azure.ResourceManager.Sql.Models.SqlServerJobAgentResourceGetJobExecutionsByAgentOptions",
                "Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetAllOptions",
                "Azure.ResourceManager.Sql.Models.SqlServerJobExecutionCollectionGetJobTargetExecutionsOptions",
                "Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepCollectionGetAllOptions",
                "Azure.ResourceManager.Sql.Models.SqlServerJobExecutionStepTargetCollectionGetAllOptions"
            };
        }
    }
}
