// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// Record to combine client provider and related field providers
    /// </summary>
    internal record RestClientInfo(ClientProvider RestClientProvider, FieldProvider RestClientField, PropertyProvider? RestClientProperty, FieldProvider DiagnosticsField, PropertyProvider? DiagnosticProperty)
    {
        internal RestClientInfo(ClientProvider restClientProvider, FieldProvider restClientField, FieldProvider diagnosticsField)
            : this(restClientProvider, restClientField, null, diagnosticsField, null)
        {
        }

        public MemberExpression Diagnostics => DiagnosticProperty != null ? DiagnosticProperty : DiagnosticsField;
        public MemberExpression RestClient => RestClientProperty != null ? RestClientProperty : RestClientField;
    }
}
