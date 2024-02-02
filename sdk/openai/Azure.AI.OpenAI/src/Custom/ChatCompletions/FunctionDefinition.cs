// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class FunctionDefinition
{
    // CUSTOM CODE NOTES:
    //   - These customizations allow "init" style use of the definition via a public default constructor and
    //     accessible setters
    //   - These changes merge "presets" into static class members for ease of use

    /// <inheritdoc cref="FunctionCallPreset.Auto"/>
    public static FunctionDefinition Auto
        = CreatePredefinedFunctionDefinition(FunctionCallPreset.Auto.ToString());

    /// <inheritdoc cref="FunctionCallPreset.None"/>
    public static FunctionDefinition None
        = CreatePredefinedFunctionDefinition(FunctionCallPreset.None.ToString());

    /// <summary>
    /// Initializes a new instance of FunctionDefinition.
    /// </summary>
    public FunctionDefinition()
    {}

    /// <summary> The name of the function to be called. </summary>
    public string Name { get; set; }

    internal bool IsPredefined { get; set; } = false;

    internal static FunctionDefinition CreatePredefinedFunctionDefinition(string functionName)
        => new FunctionDefinition(functionName)
        {
            IsPredefined = true
        };
}
