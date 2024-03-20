// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// Internal API Model Constants to be used across the API DataModels.
    /// </summary>
    internal static class APIModelConstants
    {
        /// <summary>
        /// string to represent the ODataType key in the json payload.
        /// </summary>
        public const string ODataType = "@odata.type";

        /// <summary>
        /// Microsoft Graph namespace prefix.
        /// </summary>
        public const string MicrosoftGraphPrefix = "microsoft.graph.";

        /// <summary>
        /// Microsoft Graph namespace prefix for authentication events.
        /// </summary>
        public const string MicrosoftGraphPrefixAuthEvent = MicrosoftGraphPrefix + "authenticationEvent.";
    }
}
