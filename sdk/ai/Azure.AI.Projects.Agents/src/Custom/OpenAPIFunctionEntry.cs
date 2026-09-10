// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Projects.Agents
{
    public partial class OpenAPIFunctionEntry
    {
        /// <summary> Initializes a new instance of <see cref="OpenAPIFunctionEntry"/>. </summary>
        /// <param name="name"> The name of the function to be called. </param>
        /// <param name="parameters"> The parameters the functions accepts, described as a JSON Schema object. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="parameters"/> is null. </exception>
        public OpenAPIFunctionEntry(string name, IDictionary<string, BinaryData> parameters)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(parameters, nameof(parameters));

            Name = name;
            Parameters = parameters;
        }

        /// <summary> The name of the function to be called. </summary>
        public string Name { get; set; }

        /// <summary> A description of what the function does, used by the model to choose when and how to call the function. </summary>
        public string Description { get; set; }
    }
}
