// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.Sql
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CreateOrUpdate", typeof(Azure.WaitUntil), typeof(System.Guid), typeof(System.Threading.CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CreateOrUpdateAsync", typeof(Azure.WaitUntil), typeof(System.Guid), typeof(System.Threading.CancellationToken))]
    public partial class SqlServerJobExecutionCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid jobExecutionId, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}
