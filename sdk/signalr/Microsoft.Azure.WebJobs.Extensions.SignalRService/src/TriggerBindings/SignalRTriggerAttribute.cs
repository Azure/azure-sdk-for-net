// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Attribute used to mark a function that should be triggered by messages sent from SignalR clients.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete
    public class SignalRTriggerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerAttribute"/> class.
        /// </summary>
        public SignalRTriggerAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerAttribute"/> class.
        /// </summary>
        public SignalRTriggerAttribute(string hubName, string category, string @event) : this(hubName, category, @event, Array.Empty<string>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRTriggerAttribute"/> class.
        /// </summary>
        public SignalRTriggerAttribute(string hubName, string category, string @event, params string[] parameterNames)
        {
            HubName = hubName;
            Category = category;
            Event = @event;
            ParameterNames = parameterNames;
        }

        /// <summary>
        /// Connection string that connect to Azure SignalR Service
        /// </summary>
        public string ConnectionStringSetting { get; set; } = Constants.AzureSignalRConnectionStringName;

        /// <summary>
        /// The hub of request belongs to.
        /// </summary>
        [AutoResolve]
        public string HubName { get; }

        /// <summary>
        /// The event of the request.
        /// </summary>
        [AutoResolve]
        public string Event { get; }

        /// <summary>
        /// Two optional value: connections and messages
        /// </summary>
        [AutoResolve]
        public string Category { get; }

        /// <summary>
        /// Used for messages category. All the name defined in <see cref="ParameterNames"/> will map to
        /// Arguments in InvocationMessage by order. And the name can be used in parameters of method
        /// directly.
        /// </summary>
        public string[] ParameterNames { get; }
    }
}