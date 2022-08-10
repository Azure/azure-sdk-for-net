// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Host.Triggers;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>The main trigger binding provider class.<br /></summary>
    /// <seealso cref="ITriggerBindingProvider" />
    internal class AuthEventBindingProvider : ITriggerBindingProvider
    {
        private readonly AuthEventConfigProvider _config;
        /// <summary>Initializes a new instance of the <see cref="AuthEventBindingProvider" /> class.</summary>
        /// <param name="configProvider">The configuration provider.</param>
        internal AuthEventBindingProvider(AuthEventConfigProvider configProvider)
        {
            _config = configProvider;
        }

        /// <summary>This is called from the WebJobs framework, where we look for our attribute and create and new instance of our trigger binding.</summary>
        /// <param name="context">The context that we get from the framework.</param>
        /// <returns>A new instance of EventsTriggerBinding.</returns>
        /// <exception cref="System.MissingFieldException">Is thrown when we cannot find the correct event definition attribute attached to the trigger attribute.</exception>
        /// <exception cref="System.InvalidOperationException">Is thrown when the object model is out of event sync or the wrong parameter for the event is specified on the function signature. </exception>
        /// <seealso cref="AuthEventBinding" />
        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            AuthenticationEventsTriggerAttribute attribute = context.Parameter.GetCustomAttribute<AuthenticationEventsTriggerAttribute>(false);
            if (attribute == null) return Task.FromResult<ITriggerBinding>(null);

            attribute.IsString = context.Parameter.ParameterType != typeof(string);

            return Task.FromResult<ITriggerBinding>(new AuthEventBinding(attribute, _config, context.Parameter));
        }
    }
}
