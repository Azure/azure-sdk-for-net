// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Client.Plugin
{
    /// <summary>
    /// System.ClientModel-specific distributed tracing visitor that provides
    /// the default <see cref="ClientDiagnostics"/> and <see cref="DiagnosticScope"/> types.
    /// </summary>
    internal class UnbrandedDistributedTracingVisitor : DistributedTracingVisitor
    {
        public UnbrandedDistributedTracingVisitor()
            : base(new CSharpType(typeof(ClientDiagnostics)), new CSharpType(typeof(DiagnosticScope)))
        {
        }
    }
}
