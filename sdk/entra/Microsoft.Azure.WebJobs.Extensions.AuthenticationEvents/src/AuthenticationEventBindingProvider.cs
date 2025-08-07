// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>The main trigger binding provider class.<br /></summary>
    /// <seealso cref="ITriggerBindingProvider" />
    internal class AuthenticationEventBindingProvider : ITriggerBindingProvider
    {
        private readonly AuthenticationEventConfigProvider _config;
        /// <summary>Initializes a new instance of the <see cref="AuthenticationEventBindingProvider" /> class.</summary>
        /// <param name="configProvider">The configuration provider.</param>
        internal AuthenticationEventBindingProvider(AuthenticationEventConfigProvider configProvider)
        {
            _config = configProvider;
        }

        /// <summary>This is called from the WebJobs framework, where we look for our attribute and create and new instance of our trigger binding.</summary>
        /// <param name="context">The context that we get from the framework.</param>
        /// <returns>A new instance of EventsTriggerBinding.</returns>
        /// <exception cref="System.MissingFieldException">Is thrown when we cannot find the correct event definition attribute attached to the trigger attribute.</exception>
        /// <exception cref="System.InvalidOperationException">Is thrown when the object model is out of event sync or the wrong parameter for the event is specified on the function signature. </exception>
        /// <seealso cref="AuthenticationEventBinding" />
        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            WebJobsAuthenticationEventsTriggerAttribute attribute = context.Parameter.GetCustomAttribute<WebJobsAuthenticationEventsTriggerAttribute>(false);
            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            attribute.IsParameterString = context.Parameter.ParameterType == typeof(string);

            return Task.FromResult<ITriggerBinding>(new AuthenticationEventBinding(attribute, _config, context.Parameter));
        }
    }
}
