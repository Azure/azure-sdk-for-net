// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>And abstract class for responses that implements actions.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="WebJobsAuthenticationEventsAction" />
    public abstract class WebJobsActionableResponse<T> : WebJobsAuthenticationEventResponse where T : WebJobsAuthenticationEventsAction
    {
        /// <summary>Gets or sets the actions.</summary>
        /// <value>The actions.</value>
        [JsonPropertyName("actions")]
        [OneOrMoreRequired]
        [EnumerableItemsNotNull]
        public List<T> Actions { get; set; } = new List<T>();

        /// <summary>Build AuthenticationEventJsonElement and set body to it.</summary>
        /// <seealso cref="WebJobsAuthenticationEventResponse" />
        internal override void BuildJsonElement()
        {
            BuildAndSetActions();
        }

        /// <summary>Build and sets the actions</summary>
        internal void BuildAndSetActions()
        {
            string actionElement = "actions";

            AuthenticationEventJsonElement jPayload = new AuthenticationEventJsonElement(Body);
            AuthenticationEventJsonElement jActions = jPayload.FindFirstElementNamed(actionElement);
            if (jActions == null)
            {
                jActions = new AuthenticationEventJsonElement();
                jPayload.Properties.Add(actionElement, jActions);
            }

            foreach (T action in Actions)
            {
                AuthenticationEventJsonElement jBody = action.BuildActionBody();
                AuthenticationEventJsonElement jAction = jActions.FindFirstElementWithPropertyNamed(action.TypeProperty);

                if (jAction == null || !jAction.Properties[action.TypeProperty].ToString().Equals(action.ActionType, StringComparison.OrdinalIgnoreCase))
                {
                    jAction = new AuthenticationEventJsonElement();
                    jActions.Elements.Add(jAction);
                }
                else
                {
                    jAction.RemoveAll();
                }

                jAction.Properties.Add(action.TypeProperty, action.ActionType);
                jAction.Merge(jBody);
            }

            Body = jPayload.ToString();
        }
    }
}
