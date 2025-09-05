// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure
{
    /// <summary>
    /// Represents an inner error.
    /// </summary>
    internal sealed partial class ResponseInnerError
    {
        private readonly JsonElement _innerErrorElement;

        internal ResponseInnerError()
        {
        }

        internal ResponseInnerError(string? code, ResponseInnerError? innerError, JsonElement innerErrorElement)
        {
            _innerErrorElement = innerErrorElement;
            Code = code;
            InnerError = innerError;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string? Code { get; }

        /// <summary>
        /// Gets the inner error.
        /// </summary>
        public ResponseInnerError? InnerError { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            var builder = new StringBuilder();

            Append(builder);

            return builder.ToString();
        }

        internal void Append(StringBuilder builder)
        {
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}", Code, Environment.NewLine);
            if (InnerError != null)
            {
                builder.AppendLine("Inner Error:");
                builder.Append(InnerError);
            }
        }
    }
}
