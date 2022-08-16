// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Abstract class that handles payload strongly typed payloads conversions.</summary>
    public abstract class CloudEventData : AuthEventData
    {
        /// <summary>De-serializes the json the its associated typed object.</summary>
        /// <param name="cloudEvent">The json containing the typed structure.</param>
        /// <returns>Returns the typed structure that inherits EventData.</returns>
        internal override AuthEventData FromJson(AuthEventJsonElement cloudEvent)
        {
            //TODO: REMOVE!!!! THis is temporary to handle the legacy payload.
            if (cloudEvent != null)
            {
                if (cloudEvent.Properties.ContainsKey("data"))
                {
                    return base.FromJson(cloudEvent.GetPropertyValue<AuthEventJsonElement>("data"));
                }
                else if (cloudEvent.Properties.ContainsKey("context"))
                {
                    cloudEvent.Properties.Add("authenticationContext", cloudEvent.FindFirstElementNamed("context"));
                    cloudEvent.Properties.Remove("context");
                    return base.FromJson(cloudEvent);
                }
            }

            return base.FromJson(cloudEvent);

            //Proper implementation
            //return cloudEvent == null || !cloudEvent.Properties.ContainsKey("data") ? base.FromJson(cloudEvent): base.FromJson(cloudEvent.GetPropertyValue<EventJsonElement>("data"));
        }
    }
}
