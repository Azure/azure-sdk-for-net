// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.Entra.Authentication
{
    /// <summary>The base class for Event Actions that holds the type.</summary>
    public abstract class EventAction
    {
        /// <summary>
        /// Generate OData name for the action based on the action name and event name.
        /// </summary>
        /// <param name="actionName">The Action Name.</param>
        /// <param name="eventName">The Optional Event Name</param>
        /// <returns>The OData Name.</returns>
        protected static string GetODataName(string actionName, string eventName = null)
        {
            eventName = string.IsNullOrWhiteSpace(eventName) ? string.Empty : $"{eventName}.";
            return $"{APIModelConstants.MicrosoftGraphPrefix}{eventName}{actionName}".ToUpperInvariant();
        }

        /// <summary>Gets the type of the event action.</summary>
        /// <value>The type of the event action.</value>
        [JsonProperty(APIModelConstants.ODataType)]
        public string ODataType { get; set; }
    }
}
