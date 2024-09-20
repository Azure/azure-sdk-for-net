// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Abstract class that handles payload strongly typed payloads conversions.</summary>
    public abstract class WebJobsAuthenticationEventsTypedData : WebJobsAuthenticationEventData
    {
        /// <summary>De-serializes the json the its associated typed object.</summary>
        /// <param name="cloudEvent">The json containing the typed structure.</param>
        /// <returns>Returns the typed structure that inherits EventData.</returns>
        internal override WebJobsAuthenticationEventData FromJson(AuthenticationEventJsonElement cloudEvent)
        {
            //TODO: REMOVE!!!! THis is temporary to handle the legacy payload.
            if (cloudEvent != null)
            {
                if (cloudEvent.Properties.ContainsKey("data"))
                {
                    return base.FromJson(cloudEvent.GetPropertyValue<AuthenticationEventJsonElement>("data"));
                }
                else if (cloudEvent.Properties.ContainsKey("context"))
                {
                    cloudEvent.RenameProperty("context", "authenticationContext");
                    var authContext = cloudEvent.FindFirstElementNamed("authenticationContext");

                    if (authContext != null)
                    {
                        authContext.RenameProperty("authProtocol", "protocol");
                        if (authContext.PathExists("protocol", "type"))
                        {
                            authContext.Properties["protocol"] = authContext.GetPropertyValue("protocol", "type");
                        }
                    }

                    return base.FromJson(cloudEvent);
                }
            }

            return base.FromJson(cloudEvent);

            //Proper implementation
            //return cloudEvent == null || !cloudEvent.Properties.ContainsKey("data") ? base.FromJson(cloudEvent): base.FromJson(cloudEvent.GetPropertyValue<EventJsonElement>("data"));
        }
    }
}
