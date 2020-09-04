// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    // Slightly adjusted copy of https://github.com/aspnet/Extensions/blob/master/src/Options/Options/src/OptionsFactory.cs
    internal class ClientOptionsFactory<TClient, TOptions> where TOptions : class
    {
        private readonly IEnumerable<IConfigureOptions<TOptions>> _setups;
        private readonly IEnumerable<IPostConfigureOptions<TOptions>> _postConfigures;

        private readonly IEnumerable<ClientRegistration<TClient>> _clientRegistrations;

        public ClientOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures, IEnumerable<ClientRegistration<TClient>> clientRegistrations)
        {
            _setups = setups;
            _postConfigures = postConfigures;
            _clientRegistrations = clientRegistrations;
        }

        private TOptions CreateOptions(string name)
        {
            object version = null;

            foreach (var clientRegistration in _clientRegistrations)
            {
                if (clientRegistration.Name == name)
                {
                    version = clientRegistration.Version;
                }
            }

            return (TOptions)ClientFactory.CreateClientOptions(version, typeof(TOptions));
        }

        /// <summary>
        /// Returns a configured <typeparamref name="TOptions"/> instance with the given <paramref name="name"/>.
        /// </summary>
        public TOptions Create(string name)
        {
            var options = CreateOptions(name);
            foreach (var setup in _setups)
            {
                if (setup is IConfigureNamedOptions<TOptions> namedSetup)
                {
                    namedSetup.Configure(name, options);
                }
                else if (name == Microsoft.Extensions.Options.Options.DefaultName)
                {
                    setup.Configure(options);
                }
            }
            foreach (var post in _postConfigures)
            {
                post.PostConfigure(name, options);
            }

            return options;
        }
    }
}