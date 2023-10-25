// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    /// <summary> The definition of a caller-specified function that chat completions may invoke in response to matching user input. </summary>
    public partial class FunctionDefinition
    {
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
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
        }

        /// <summary> The name of the function to be called. </summary>
        public string Name { get; set; }

        internal bool IsPredefined { get; set; } = false;

        internal static FunctionDefinition CreatePredefinedFunctionDefinition(string functionName)
            => new FunctionDefinition(functionName)
            {
                IsPredefined = true
            };
    }
}
