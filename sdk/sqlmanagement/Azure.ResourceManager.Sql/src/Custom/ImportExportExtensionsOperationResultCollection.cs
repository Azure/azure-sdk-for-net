// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

namespace Azure.ResourceManager.Sql
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Get", typeof(string), typeof(System.Threading.CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetAsync", typeof(string), typeof(System.Threading.CancellationToken))]
    public partial class ImportExportExtensionsOperationResultCollection
    {
        [Azure.Core.ForwardsClientCalls]
        public virtual Azure.Response Get(string extensionName, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }

        [Azure.Core.ForwardsClientCalls]
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default)
        {
            throw new System.NotSupportedException("This API is preserved for binary compatibility with the previous SQL management SDK surface. Use the generated replacement API for new code.");
        }
    }
}
