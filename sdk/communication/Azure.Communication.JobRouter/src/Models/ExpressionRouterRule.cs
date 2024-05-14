// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ExpressionRouterRule : IUtf8JsonSerializable
    {
        /// <summary> The expression language to compile to and execute. </summary>
        internal string Language { get; }

        /// <summary> Initializes a new instance of an expression rule. </summary>
        /// <param name="expression"> An expression to evaluate. Should contain return statement with calculated values. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="expression"/> is null. </exception>
        public ExpressionRouterRule(string expression) : this(RouterRuleKind.Expression, ExpressionRouterRuleLanguage.PowerFx.ToString(), expression)
        {
            Argument.AssertNotNull(expression, nameof(expression));
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Language))
            {
                writer.WritePropertyName("language"u8);
                writer.WriteStringValue(Language);
            }
            writer.WritePropertyName("expression"u8);
            writer.WriteStringValue(Expression);
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind.ToString());
            writer.WriteEndObject();
        }
    }
}
