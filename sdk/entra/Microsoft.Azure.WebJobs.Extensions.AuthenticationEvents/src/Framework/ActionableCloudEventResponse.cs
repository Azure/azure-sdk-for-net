// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Abstract class for any responses that implement an cloud event payload and has actions on it.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="AuthenticationEventAction" />
    public abstract class ActionableCloudEventResponse<T> : ActionableResponse<T> where T : AuthenticationEventAction
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
            Actions.RemoveAll(a => a == null);
            AuthenticationEventJsonElement eventJsonElement = new AuthenticationEventJsonElement(Body);
            if (eventJsonElement.SetProperty<string>(ODataType, "data", "@odata.type"))
            {
                Body = eventJsonElement.ToString();
            }

            base.Invalidate();
        }
    }
}
