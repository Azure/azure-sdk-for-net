// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>And abstract class for responses that implements actions.</summary>
    /// <typeparam name="T">Of type EventAction.</typeparam>
    /// <seealso cref="AuthEventAction" />
    ///

    public abstract class ActionableResponse<T> : AuthEventResponse where T : AuthEventAction
    {
        /// <summary>Gets or sets the actions.</summary>
        /// <value>The actions.</value>
        [JsonPropertyName("actions")]
        public List<T> Actions { get; set; } = new List<T>();

        /// <summary>Invalidates this instance.
        /// Subsequently invalidates the actions.</summary>
        /// <seealso cref="AuthEventResponse" />
        internal override void Invalidate()
        {
            InvalidateActions();
        }

        /// <summary>Invalidates the actions.</summary>
        internal void InvalidateActions()
        {
            string actionElement = "actions";
            string typeProperty = "type";

            AuthEventJsonElement jPayload = new AuthEventJsonElement(Body);
            AuthEventJsonElement jActions = jPayload.FindFirstElementNamed(actionElement);
            if (jActions == null)
            {
                jActions = new AuthEventJsonElement();
                jPayload.Properties.Add(actionElement, jActions);
            }

            foreach (T action in Actions)
            {
                AuthEventJsonElement jBody = action.BuildActionBody();
                AuthEventJsonElement jAction = jActions.FindFirstElementWithPropertyNamed(typeProperty);

                if (jAction == null || !jAction.Properties[typeProperty].ToString().Equals(action.ActionType, StringComparison.OrdinalIgnoreCase))
                {
                    jAction = new AuthEventJsonElement();
                    jActions.Elements.Add(jAction);
                }
                else
                {
                    jAction.RemoveAll();
                }

                jAction.Properties.Add(typeProperty, action.ActionType);
                jAction.Merge(jBody);
            }

            Body = jPayload.ToString();
        }
    }
}
