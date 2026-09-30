// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Projects.Agents;

[EditorBrowsable(EditorBrowsableState.Never)]
public partial class AzureFunctionDefinitionFunction
{
    /// <summary> Initializes a function definition using the legacy model. </summary>
    /// <param name="name"> The name of the function. </param>
    /// <param name="parameters"> The function's JSON schema. </param>
    public AzureFunctionDefinitionFunction(string name, BinaryData parameters)
    {
        Argument.AssertNotNull(name, nameof(name));
        Argument.AssertNotNull(parameters, nameof(parameters));
        Name = name;
        Parameters = parameters;
    }

    /// <summary> Gets or sets the name of the function. </summary>
    public string Name { get; set; }

    /// <summary> Gets or sets the description of the function. </summary>
    public string Description { get; set; }

    /// <summary> Gets or sets the function's JSON schema. </summary>
    public BinaryData Parameters { get; set; }
}
