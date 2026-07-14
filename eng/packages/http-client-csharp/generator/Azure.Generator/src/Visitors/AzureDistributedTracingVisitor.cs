// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Azure-specific distributed tracing visitor that handles paging methods
    /// returning <see cref="Pageable{T}"/> or <see cref="AsyncPageable{T}"/>.
    /// </summary>
    internal class AzureDistributedTracingVisitor : DistributedTracingVisitor
    {
        public AzureDistributedTracingVisitor()
            : base(new CSharpType(typeof(ClientDiagnostics)), new CSharpType(typeof(DiagnosticScope)))
        {
        }

        protected override bool ShouldPassScopeToPageableConstructor(ScmMethodProvider method)
        {
            var returnType = method.Signature.ReturnType;
            if (returnType == null || !returnType.IsFrameworkType)
            {
                return false;
            }

            return returnType.FrameworkType == typeof(Pageable<>) ||
                   returnType.FrameworkType == typeof(AsyncPageable<>);
        }
    }
}
