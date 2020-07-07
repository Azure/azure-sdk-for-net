// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// A wrapper factory that allows us to log when creating options.
    /// </summary>
    /// <typeparam name="TOptions">The options type to create.</typeparam>
    internal class WebJobsOptionsFactory<TOptions> : IOptionsFactory<TOptions> where TOptions : class, new()
    {
        private readonly OptionsFactory<TOptions> _innerFactory;
        private readonly IOptionsLoggingSource _logSource;
        private readonly IOptionsFormatter<TOptions> _optionsFormatter;

        public WebJobsOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures, IOptionsLoggingSource logSource) :
            this(setups, postConfigures, logSource, null)
        {
        }

        public WebJobsOptionsFactory(IEnumerable<IConfigureOptions<TOptions>> setups, IEnumerable<IPostConfigureOptions<TOptions>> postConfigures,
            IOptionsLoggingSource logSource, IOptionsFormatter<TOptions> optionsFormatter)
        {
            _innerFactory = new OptionsFactory<TOptions>(setups, postConfigures);
            _logSource = logSource;

            // This allows us to wrap behavior around an existing type. It will be null for types we don't log.
            _optionsFormatter = optionsFormatter;
        }

        public TOptions Create(string name)
        {
            TOptions options = _innerFactory.Create(name);

            string formattedOptions = null;

            // See if we need to format these options, either from one of our Options
            // or from a registered IOptionsFormatter<TOptions>
            if (_optionsFormatter != null)
            {
                formattedOptions = _optionsFormatter.Format(options);
            }
            else if (options is IOptionsFormatter optionsFormatter)
            {
                formattedOptions = optionsFormatter.Format();
            }

            if (formattedOptions != null)
            {
                string logString = $"{typeof(TOptions).Name}{Environment.NewLine}{formattedOptions}";
                _logSource.LogOptions(logString);
            }

            return options;
        }
    }
}