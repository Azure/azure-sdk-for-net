// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface
{
    internal interface ICloudRunErrorParser
    {
        void HandleScalableRunErrorMessage(string? message);
        bool TryPushMessageAndKey(string? message, string? key);
        void PushMessage(string message);
        void DisplayMessages();
        void PrintErrorToConsole(string message);
    }
}
