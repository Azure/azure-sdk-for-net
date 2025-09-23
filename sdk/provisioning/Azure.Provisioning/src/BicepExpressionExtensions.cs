// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Provide extension methods for working with Bicep expressions.
/// </summary>
public static class BicepExpressionExtensions
{
    public static BicepExpression ToBicepExpression(this IBicepValue bicepValue)
    {
        // if self is set, we could build an expression as a reference of this member
        if (bicepValue.Self is not null)
        {
            return bicepValue.Self.GetReference();
        }
        // if self is not set, but the value of this is an expression, we return that expression
        else if (bicepValue.Kind == BicepValueKind.Expression)
        {
            return bicepValue.Expression ?? BicepSyntax.Null();
        }
        // otherwise, we return whatever this compiles into
        else
        {
            return bicepValue.Compile();
        }
    }
}
