﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ExpressionRule")]
    [CodeGenSuppress("ExpressionRule", typeof(string), typeof(string))]
    public partial class ExpressionRule : RouterRule
    {
        /// <summary> The available expression languages that can be configured. </summary>
        public string Language { get; }

        /// <summary> Initializes a new instance of ExpressionRule. </summary>
        /// <param name="expression"> The string containing the expression to evaluate. Should contain return statement with calculated values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="expression"/> is null. </exception>
        public ExpressionRule(string expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));

            Language = "powerFx";
            Expression = expression;
            Kind = "expression-rule";
        }
    }
}
