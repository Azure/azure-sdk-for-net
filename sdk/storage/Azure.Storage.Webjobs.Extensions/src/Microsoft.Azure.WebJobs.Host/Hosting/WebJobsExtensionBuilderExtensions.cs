// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs
{
    public static class WebJobsExtensionBuilderExtensions
    {
        /// <summary>
        /// Binds the options type specified in <typeparamref name="TOptions"/> to an extension specific configuration
        /// section.
        /// </summary>
        /// <typeparam name="TOptions">The type of options to bind.</typeparam>
        /// <param name="builder">The <see cref="IWebJobsExtensionBuilder"/> to configure.</param>
        /// <returns>The configured <see cref="IWebJobsExtensionBuilder"</returns>
        public static IWebJobsExtensionBuilder BindOptions<TOptions>(this IWebJobsExtensionBuilder builder) where TOptions : class
        {
            builder.ConfigureOptions<TOptions>((section, options) =>
            {
                if (section.Exists())
                {
                    section.Bind(options);
                }
            });

            return builder;
        }

        /// <summary>
        /// Configures an action that will be invoked when configuring the specified <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of options to bind.</typeparam>
        /// <param name="builder">The <see cref="IWebJobsExtensionBuilder"/> to configure.</param>
        /// <param name="configure">The <see cref="Action{IConfigurationSection, TOptions}"/> that will be invoked when configuring the options.</param>
        /// <returns>The configured <see cref="IWebJobsExtensionBuilder"</returns>
        public static IWebJobsExtensionBuilder ConfigureOptions<TOptions>(this IWebJobsExtensionBuilder builder, Action<IConfigurationSection, TOptions> configure) where TOptions : class
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.ConfigureOptions<TOptions>((config, path, options) =>
            {
                IConfigurationSection section = config.GetSection(path);
                configure(section, options);
            });
            
            return builder;
        }

        /// <summary>
        /// Configures an action that will be invoked when configuring the specified <typeparamref name="TOptions"/>.
        /// </summary>
        /// <typeparam name="TOptions">The type of options to bind.</typeparam>
        /// <param name="builder">The <see cref="IWebJobsExtensionBuilder"/> to configure.</param>
        /// <param name="configure">The <see cref="Action{IConfiguration, string, TOptions}"/> that will be invoked when configuring the options, providing the root configuration, the
        /// extension configuration section path and the option to configure.</param>
        /// <returns>The configured <see cref="IWebJobsExtensionBuilder"</returns>
        public static IWebJobsExtensionBuilder ConfigureOptions<TOptions>(this IWebJobsExtensionBuilder builder, Action<IConfiguration, string, TOptions> configure) where TOptions : class
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.Services.AddSingleton<IConfigureOptions<TOptions>>(p =>
                new WebJobsExtensionOptionsConfiguration<TOptions>(p.GetService<IConfiguration>(), builder.ExtensionInfo.ConfigurationSectionName, configure));

            return builder;
        }
    }
}
