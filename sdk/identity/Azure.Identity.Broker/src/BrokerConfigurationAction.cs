// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Broker;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Action to configure the <see cref="PublicClientApplicationBuilder"/> to use the system authentication broker.
    /// </summary>
    public class BrokerConfigurationAction
    {
        private readonly Action<PublicClientApplicationBuilder> _action;

        /// <summary>
        /// Creates a new instance of <see cref="BrokerConfigurationAction"/> to configure a <see cref="PublicClientApplicationBuilder"/> for broker authentication.
        /// </summary>
        public BrokerConfigurationAction()
        {
            _action = builder =>
            {
                builder.WithParentActivityOrWindow(() => IntPtr.Zero);
                var options = new BrokerOptions(BrokerOptions.OperatingSystems.Windows);
                builder.WithBroker(options);
            };
        }

        // /// <summary>
        // /// Implicitly converts the <see cref="BrokerConfigurationAction"/> to an <see cref="Action{PublicClientApplicationBuilder}"/>.
        // /// </summary>
        // public static implicit operator Action<PublicClientApplicationBuilder>(BrokerConfigurationAction action)
        // {
        //     return action._action;
        // }

        /// <summary>
        /// Explicitly converts the <see cref="BrokerConfigurationAction"/> to an <see cref="Action{PublicClientApplicationBuilder}"/>.
        /// </summary>
        public static explicit operator Action<PublicClientApplicationBuilder>(BrokerConfigurationAction action)
        {
            return action._action;
        }
    }
}
