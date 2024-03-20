// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>
    /// The base abstract class for TokenIssuanceStart actions.
    /// </summary>
    public abstract class TokenIssuanceStartAction : EventAction
    {
        /// <summary>
        /// Generate OData name for the action based on the action name.
        /// </summary>
        /// <param name="actionName">The action name.</param>
        protected static string GetODataName(string actionName)
        {
            return GetODataName(
                actionName: actionName,
                eventName: "TokenIssuanceStart");
        }
    }
}
