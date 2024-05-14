// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>And abstract class for responses that implements actions.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="AuthenticationEventAction" />
    public abstract class ActionableResponse<T> : AuthenticationEventResponse where T : AuthenticationEventAction
    {
        /// <summary>Gets or sets the actions.</summary>
        /// <value>The actions.</value>
        [JsonPropertyName("actions")]
        [OneOrMoreRequired]
        [EnumerableItemsNotNull]
        public List<T> Actions { get; set; } = new List<T>();

        /// <summary>Invalidates this instance.
        /// Subsequently invalidates the actions.</summary>
        /// <seealso cref="AuthenticationEventResponse" />
        internal override void Invalidate()
        {
            InvalidateActions();
        }

        /// <summary>Invalidates the actions.</summary>
        internal void InvalidateActions()
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
