// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Host.Config
{
    /// <summary>
    /// Context object passed to <see cref="IExtensionConfigProvider"/> instances when
    /// they are initialized.
    /// </summary>
    public class ExtensionConfigContext : FluentConverterRules<Attribute, ExtensionConfigContext>
    {

        // List of actions to flush from the fluent configuration. 
        private List<Action> _updates = new List<Action>();

        // Map of tyepof(TAttribute) --> FluentBindingRule<TAttribute>
        private readonly Dictionary<Type, object> _rules = new Dictionary<Type, object>();
        private readonly IConfiguration _configuration;
        private readonly IConverterManager _converterManager;
        private readonly IWebHookProvider _webHookProvider;
        private readonly IExtensionRegistry _extensionRegistry;
        private readonly INameResolver _nameResolver;

        public ExtensionConfigContext(IConfiguration configuration, INameResolver nameResolver, IConverterManager converterManager, IWebHookProvider webHookProvider, IExtensionRegistry extensionRegistry)
        {
            _configuration = configuration;
            _converterManager = converterManager;
            _webHookProvider = webHookProvider;
            _extensionRegistry = extensionRegistry;
            _nameResolver = nameResolver;
        }

        internal IExtensionConfigProvider Current { get; set; }

        internal override ConverterManager ConverterManager => (ConverterManager)_converterManager;

        /// <summary>
        /// Get a fully qualified URL that the host will resolve to this extension 
        /// </summary>
        /// <returns>null if http handlers are not supported in this environment</returns>
        /// $$$ Shouldn't be here
        [Obsolete("preview")]
        public Uri GetWebhookHandler()
        {
            if (_webHookProvider == null)
            {
                return null;
            }
            return _webHookProvider.GetUrl(this.Current);
        }

        // Ensure that multiple attempts bind to the same attribute, they get the same rule object. 
        private FluentBindingRule<TAttribute> GetOrCreate<TAttribute>()
              where TAttribute : Attribute
        {
            FluentBindingRule<TAttribute> rule;
            if (!this._rules.TryGetValue(typeof(TAttribute), out object temp))
            {
                // Create and register
                rule = new FluentBindingRule<TAttribute>(_configuration, _nameResolver, _converterManager, _extensionRegistry);
                this._rules[typeof(TAttribute)] = rule;

                _updates.Add(rule.ApplyRules);
            }
            else
            {
                // Return existing.
                rule = (FluentBindingRule<TAttribute>)temp;
            }
            return rule;
        }

        /// <summary>
        /// Add a binding rule for the given attribute. 
        /// Multiple extensions can add rules to the same attribute. 
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public FluentBindingRule<TAttribute> AddBindingRule<TAttribute>() where TAttribute : Attribute
        {
            var bindingAttrs = typeof(TAttribute).GetCustomAttributes(typeof(BindingAttribute), false);
            if (!bindingAttrs.Any())
            {
                throw new InvalidOperationException($"Can't add a binding rule for '{typeof(TAttribute).Name}' since it is missing the a {typeof(BindingAttribute).Name}");
            }

            var isTrigger = typeof(TAttribute).Name.EndsWith("TriggerAttribute", StringComparison.OrdinalIgnoreCase);
            if (!isTrigger && ((BindingAttribute)bindingAttrs.First()).TriggerHandlesReturnValue)
            {
                throw new InvalidOperationException($"Only declare {nameof(BindingAttribute.TriggerHandlesReturnValue)} property true for trigger bindings.");
            }

            var fluent = GetOrCreate<TAttribute>();
            return fluent;
        }

        // Called once after all extensions. 
        internal void ApplyRules()
        {
            foreach (var func in _updates)
            {
                func();
            }
            _updates.Clear();
        }
    }
}
