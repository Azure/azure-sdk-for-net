// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference
{
    public partial class FunctionDefinition
    {
        // CUSTOM CODE NOTES:
        //   - These customizations allow "init" style use of the definition via a public default constructor and
        //     accessible setters
        //   - These changes merge "presets" into static class members for ease of use

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.Auto"/>
        public static FunctionDefinition Auto
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.Auto.ToString());

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.None"/>
        public static FunctionDefinition None
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.None.ToString());

        /// <inheritdoc cref="ChatCompletionsToolChoicePreset.Required"/>
        public static FunctionDefinition Required
            = CreatePredefinedFunctionDefinition(ChatCompletionsToolChoicePreset.Required.ToString());

        /// <summary>
        /// Initializes a new instance of FunctionDefinition.
        /// </summary>
        public FunctionDefinition()
        { }

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
