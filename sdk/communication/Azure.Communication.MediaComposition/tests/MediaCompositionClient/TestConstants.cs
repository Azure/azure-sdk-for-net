// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.MediaComposition.Tests
{
    public static class TestConstants
    {
        public static class ErrorMessage
        {
            public const string InputOutputNotSameKind = "Call input and output must be of the same kind and referencing the same call.";
            public const string InvalidInputId = "Input with id: InvalidInputId not defined. If using a selector, check if your syntax is correct.";
            public const string InputIdNotDefined = "Inputs are required to be defined for media composition";
            public const string LayoutNotDefined = "Layout is required to be defined for media composition";
            public const string OutputNotDefined = "Outputs are required to be defined for media composition";
            public const string NoInputAvailable = "Must have exactly one media input of type ACS Group Call, Room or Teams Call; less than one is defined.";
            public const string ResourceNotFound = "Not Found";
        }
    }
}
