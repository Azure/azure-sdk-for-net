// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers.Samples;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System.Collections.Generic;

namespace Azure.Generator.Management.Primitives;

internal class ServiceMethodProvider : MethodProvider
{
    public ResourceOperationSample? Sample
    {
        get;
        internal set; // we need to include this MethodProvider instance in the sample instance in order to call it, therefore we must make this settable to resolve the cyclic reference.
    }

    public ServiceMethodProvider(MethodSignature signature, MethodBodyStatement bodyStatements, TypeProvider enclosingType, XmlDocProvider? xmlDocProvider = null, IEnumerable<SuppressionStatement>? suppressions = null)
        : base(signature, bodyStatements, enclosingType, xmlDocProvider, suppressions)
    {
    }

    public ServiceMethodProvider(MethodSignature signature, ValueExpression bodyExpression, TypeProvider enclosingType, XmlDocProvider? xmlDocProvider = null, IEnumerable<SuppressionStatement>? suppressions = null)
        : base(signature, bodyExpression, enclosingType, xmlDocProvider, suppressions)
    {
    }
}
