// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.Sql
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Update", typeof(Azure.WaitUntil), typeof(System.Threading.CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("UpdateAsync", typeof(Azure.WaitUntil), typeof(System.Threading.CancellationToken))]
    public partial class SqlServerJobExecutionResource
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Sql.SqlServerJobExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}
