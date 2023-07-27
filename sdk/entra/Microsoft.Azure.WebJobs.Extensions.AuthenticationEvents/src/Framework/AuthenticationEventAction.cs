// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Abstract class for response actions.</summary>
    public abstract class AuthenticationEventAction
    {
        /// <summary>Gets the type of the action.
        /// This will be used as the name of the action in the response Json.</summary>
        /// <value>The type of the action.</value>
        [JsonPropertyName("actionType")]
        internal abstract string ActionType { get; }
        internal virtual string TypeProperty => "@odata.type";
        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventAction" /> class.</summary>
        public AuthenticationEventAction() { }

        /// <summary>Builds the action body.</summary>
        /// <returns>The return will be the json of the action.</returns>
        internal abstract AuthenticationEventJsonElement BuildActionBody();

        /// <summary>Creates the action from Json.</summary>
        /// <param name="actionBody">The action body.</param>
        internal abstract void FromJson(AuthenticationEventJsonElement actionBody);
    }
}
