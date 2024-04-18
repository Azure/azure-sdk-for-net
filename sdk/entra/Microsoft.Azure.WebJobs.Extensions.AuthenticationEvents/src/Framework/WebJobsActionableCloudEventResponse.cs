// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Abstract class for any responses that implement an cloud event payload and has actions on it.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="WebJobsAuthenticationEventsAction" />
    public abstract class WebJobsActionableCloudEventResponse<T> : WebJobsActionableResponse<T>
        where T : WebJobsAuthenticationEventsAction
    {
        /// <summary>Gets the Cloud Event @odata.type.</summary>
        /// <value>Gets the Cloud Event @odata.type.</value>
        [JsonPropertyName("oDataType")]
        [Required]
        public string ODataType { get { return DataTypeIdentifier; } }

        internal abstract string DataTypeIdentifier { get; }

        /// <summary>Removes any null actions. Sets the parent level odata.type.</summary>
        internal override void BuildJsonElement()
        {
            Actions.RemoveAll(a => a == null);
            AuthenticationEventJsonElement eventJsonElement = new AuthenticationEventJsonElement(Body);
            if (eventJsonElement.SetProperty<string>(ODataType, "data", "@odata.type"))
            {
                Body = eventJsonElement.ToString();
            }

            base.BuildJsonElement();
        }
    }
}
