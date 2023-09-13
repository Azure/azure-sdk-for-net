// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct)]
    internal class CodeGenModelAttribute : CodeGenTypeAttribute
    {
        /// <summary>
        /// Gets or sets a coma separated list of additional model usage modes. Allowed values: model, error, intput, output.
        /// </summary>
        public string[]? Usage { get; set; }

        /// <summary>
        /// Gets or sets a coma separated list of additional model serialization formats.
        /// </summary>
        public string[]? Formats { get; set; }

        public CodeGenModelAttribute() : base(null)
        {
        }

        public CodeGenModelAttribute(string originalName): base(originalName)
        {
        }
    }
}
