// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExpressionRouterRule")]
    [CodeGenSuppress("ExpressionRouterRule", typeof(string), typeof(string))]
    public partial class ExpressionRouterRule : RouterRule
    {
        /// <summary> The available expression languages that can be configured. </summary>
        public string Language { get; }

        /// <summary> Initializes a new instance of ExpressionRule. </summary>
        /// <param name="expression"> The string containing the expression to evaluate. Should contain return statement with calculated values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="expression"/> is null. </exception>
        public ExpressionRouterRule(string expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Language = ExpressionRouterRuleLanguage.PowerFx.ToString();
            Expression = expression;
            Kind = "expression-rule";
        }
    }
}
