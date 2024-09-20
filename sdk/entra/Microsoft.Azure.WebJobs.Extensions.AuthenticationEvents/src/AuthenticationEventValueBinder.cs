// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Our response value binder that has reference the EventResponse.</summary>
    /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
    internal class AuthenticationEventValueBinder : IValueBinder
    {
        private object _value;
        private readonly WebJobsAuthenticationEventsTriggerAttribute _attr;
        /// <summary>Gets the type.</summary>
        /// <value>The type.</value>
        public Type Type => _attr.IsParameterString ? typeof(string) : typeof(WebJobsAuthenticationEventRequestBase);

        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventValueBinder" /> class.</summary>
        /// <param name="value">The EventRequest event as the value.</param>
        /// <param name="attribute">The event trigger attribute assign to the function that we are assigning the value from.</param>
        internal AuthenticationEventValueBinder(object value, WebJobsAuthenticationEventsTriggerAttribute attribute)
        {
            _attr = attribute;
            _value = _attr.IsParameterString ? value.ToString() : value;
        }

        /// <summary>Gets the value asynchronous.</summary>
        /// <returns>The EventRequest.<br /></returns>
        /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
        public Task<object> GetValueAsync()
        {
            return Task.FromResult(_value);
        }

        /// <summary>Sets the value asynchronous.</summary>
        /// <param name="value">The EventResponse as the value.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task flagged as completed.</returns>
        /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            _value = value;
            return Task.CompletedTask;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>The string representation of the EventResponse.</returns>
        /// <seealso cref="WebJobsAuthenticationEventRequestBase" />
        public string ToInvokeString()
        {
            return _value.ToString();
        }
    }
}