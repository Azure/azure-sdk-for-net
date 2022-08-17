// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Abstract class for any responses that implement an cloud event payload and has actions on it.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="AuthEventAction" />
    public abstract class ActionableCloudEventResponse<T> : ActionableResponse<T> where T : AuthEventAction
    {
        /// <summary>Gets the Cloud Event @odata.type.</summary>
        /// <value>Gets the Cloud Event @odata.type.</value>
        [JsonPropertyName("oDataType")]
        [Required]
        public string ODataType { get { return DataTypeIdentifier; } }
        internal abstract string DataTypeIdentifier { get; }

        /// <summary>Invalidates this instance.
        /// Subsequently invalidates the actions.</summary>
        internal override void Invalidate()
        {
            AuthEventJsonElement eventJsonElement = new AuthEventJsonElement(Body);
            if (eventJsonElement.SetProperty<string>(ODataType, "data", "@odata.type"))
            {
                Body = eventJsonElement.ToString();
            }

            base.Invalidate();
        }
    }
}
