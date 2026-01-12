// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Avs.Models
{
    public abstract partial class ScriptExecutionParameterDetails
    {
        /// <summary> Initializes a new instance of <see cref="ScriptExecutionParameterDetails"/>. </summary>
        /// <param name="name"> The parameter name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected ScriptExecutionParameterDetails(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }
    }
}
