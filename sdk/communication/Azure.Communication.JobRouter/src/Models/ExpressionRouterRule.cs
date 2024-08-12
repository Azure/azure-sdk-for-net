// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ExpressionRouterRule
    {
        /// <summary> The expression language to compile to and execute. </summary>
        internal string Language { get; }

        /// <summary> Initializes a new instance of an expression rule. </summary>
        /// <param name="expression"> An expression to evaluate. Should contain return statement with calculated values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="expression"/> is null. </exception>
        public ExpressionRouterRule(string expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Kind = RouterRuleKind.Expression;
            Language = ExpressionRouterRuleLanguage.PowerFx.ToString();
            Expression = expression;
        }
    }
}
