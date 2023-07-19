// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Extensions.Configuration;
using BindingData = System.Collections.Generic.IReadOnlyDictionary<string, object>;
using BindingDataContract = System.Collections.Generic.IReadOnlyDictionary<string, System.Type>;
// Func to transform Attribute,BindingData into value for cloned attribute property/constructor arg
// Attribute is the new cloned attribute - null if constructor arg (new cloned attr not created yet)
using BindingDataResolver = System.Func<System.Attribute, System.Collections.Generic.IReadOnlyDictionary<string, object>, object>;

using Validator = System.Action<object>;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    /// <summary>
    /// Copy from: https://github.com/Azure/azure-webjobs-sdk/blob/v3.0.29/src/Microsoft.Azure.WebJobs.Host/Bindings/AttributeCloner.cs.
    /// </summary>
    // Clone an attribute and resolve it.
    // This can be tricky since some read-only properties are set via the constructor.
    // This assumes that the property name matches the constructor argument name.
    internal class AttributeCloner<TAttribute>
        where TAttribute : Attribute
    {
        private readonly TAttribute _source;

        // Which constructor do we invoke to instantiate the new attribute?
        // The attribute is configured through a) constructor arguments, b) settable properties.
        private readonly ConstructorInfo _matchedCtor;

        // Compute the arguments to pass to the chosen constructor. Arguments are based on binding data.
        private readonly BindingDataResolver[] _ctorParamResolvers;

        // Compute the values to apply to Settable properties on newly created attribute.
        private readonly Action<TAttribute, BindingData>[] _propertySetters;

        private readonly Dictionary<PropertyInfo, AutoResolveAttribute> _autoResolves = new();

        private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public;
        private readonly IConfiguration _configuration;

        internal AttributeCloner(
            TAttribute source,
            BindingDataContract bindingDataContract,
            IConfiguration configuration,
            INameResolver nameResolver = null)
        {
            _configuration = configuration;

            nameResolver ??= new EmptyNameResolver();
            _source = source;

            Type attributeType = typeof(TAttribute);

            PropertyInfo[] allProperties = attributeType.GetProperties(Flags);

            // Create dictionary of all non-null properties on source attribute.
            Dictionary<string, PropertyInfo> nonNullProps = allProperties
                .Where(prop => prop.GetValue(source) != null)
                .ToDictionary(prop => prop.Name, prop => prop, StringComparer.OrdinalIgnoreCase);

            // Pick the ctor with the longest parameter list where all are matched to non-null props.
            var ctorAndParams = attributeType.GetConstructors(Flags)
                .Select(ctor => new { ctor, parameters = ctor.GetParameters() })
                .OrderByDescending(tuple => tuple.parameters.Length)
                .FirstOrDefault(tuple => tuple.parameters.All(param => nonNullProps.ContainsKey(param.Name)));

            if (ctorAndParams == null)
            {
                throw new InvalidOperationException("Can't figure out which ctor to call.");
            }

            _matchedCtor = ctorAndParams.ctor;

            // Get appropriate binding data resolver (appsetting, autoresolve, or originalValue) for each constructor parameter
            _ctorParamResolvers = ctorAndParams.parameters
                .Select(param => GetResolver(nonNullProps[param.Name], nameResolver, bindingDataContract))
                .ToArray();

            // Get appropriate binding data resolver (appsetting, autoresolve, or originalValue) for each writeable property
            _propertySetters = allProperties
                .Where(prop => prop.CanWrite)
                .Select(prop =>
                {
                    var resolver = GetResolver(prop, nameResolver, bindingDataContract);
                    return (Action<TAttribute, BindingData>)((attr, data) => prop.SetValue(attr, resolver(attr, data)));
                })
                .ToArray();
        }

        // transforms binding data to appropriate resolver (appsetting, autoresolve, or originalValue)
        private BindingDataResolver GetResolver(PropertyInfo propInfo, INameResolver nameResolver, BindingDataContract contract)
        {
            // Do the attribute lookups once upfront, and then cache them (via func closures) for subsequent runtime usage.
            object originalValue = propInfo.GetValue(_source);
            ConnectionStringAttribute connStrAttr = propInfo.GetCustomAttribute<ConnectionStringAttribute>();
            AppSettingAttribute appSettingAttr = propInfo.GetCustomAttribute<AppSettingAttribute>();
            AutoResolveAttribute autoResolveAttr = propInfo.GetCustomAttribute<AutoResolveAttribute>();
            Validator validator = GetValidatorFunc(propInfo, appSettingAttr != null);

            if (appSettingAttr == null && autoResolveAttr == null && connStrAttr == null)
            {
                validator(originalValue);

                // No special attributes, treat as literal.
                return (newAttr, bindingData) => originalValue;
            }

            int attrCount = new Attribute[] { connStrAttr, appSettingAttr, autoResolveAttr }.Count(a => a != null);
            if (attrCount > 1)
            {
                throw new InvalidOperationException($"Property '{propInfo.Name}' can only be annotated with one of the types {nameof(AppSettingAttribute)}, {nameof(AutoResolveAttribute)}, and {nameof(ConnectionStringAttribute)}.");
            }

            // attributes only work on string properties.
            if (propInfo.PropertyType != typeof(string))
            {
                throw new InvalidOperationException($"{nameof(ConnectionStringAttribute)}, {nameof(AutoResolveAttribute)}, or {nameof(AppSettingAttribute)} property '{propInfo.Name}' must be of type string.");
            }

            var str = (string)originalValue;

            // first try to resolve with connection string
            if (connStrAttr != null)
            {
                return GetConfigurationResolver(str, connStrAttr.Default, propInfo, validator, s => _configuration.GetConnectionStringOrSetting(nameResolver.ResolveWholeString(s)));
            }

            // then app setting
            if (appSettingAttr != null)
            {
                return GetConfigurationResolver(str, appSettingAttr.Default, propInfo, validator, s => _configuration[s]);
            }

            // Must have an [AutoResolve]
            // try to resolve with auto resolve ({...}, %...%)
            return GetAutoResolveResolver(str, autoResolveAttr, nameResolver, propInfo, contract, validator);
        }

        // Apply AutoResolve attribute
        internal BindingDataResolver GetAutoResolveResolver(string originalValue, AutoResolveAttribute autoResolveAttr, INameResolver nameResolver, PropertyInfo propInfo, BindingDataContract contract, Validator validator)
        {
            if (string.IsNullOrWhiteSpace(originalValue))
            {
                if (autoResolveAttr.Default != null)
                {
                    return GetBuiltinTemplateResolver(autoResolveAttr.Default, nameResolver, validator);
                }
                else
                {
                    validator(originalValue);
                    return (newAttr, bindingData) => originalValue;
                }
            }
            else
            {
                _autoResolves[propInfo] = autoResolveAttr;
                return GetTemplateResolver(originalValue, autoResolveAttr, nameResolver, propInfo, contract, validator);
            }
        }

        // Both ConnectionString and AppSetting have the same behavior, but perform the lookup differently.
        internal static BindingDataResolver GetConfigurationResolver(string propertyValue, string defaultValue, PropertyInfo propInfo, Validator validator, Func<string, string> resolveValue)
        {
            string configurationKey = propertyValue ?? defaultValue;
            string resolvedValue = null;

            if (!string.IsNullOrEmpty(configurationKey))
            {
                resolvedValue = resolveValue(configurationKey);
            }

            // If a value is non-null and cannot be found, we throw to match the behavior
            // when %% values are not found in ResolveWholeString below.
            if (resolvedValue == null && propertyValue != null)
            {
                // It's important that we only log the attribute property name, not the actual value to ensure
                // that in cases where users accidentally use a secret key *value* rather than indirect setting name
                // that value doesn't get written to logs.
                throw new InvalidOperationException($"Unable to resolve the value for property '{propInfo.DeclaringType.Name}.{propInfo.Name}'. Make sure the setting exists and has a valid value.");
            }

            // validate after the %% is substituted.
            validator(resolvedValue);

            return (newAttr, bindingData) => resolvedValue;
        }

        // Run validition. This needs to be run at different stages.
        // In general, run as early as possible. If there are { } tokens, then we can't run until runtime.
        // But if there are no { }, we can run statically.
        // If there's no [AutoResolve], [AppSettings], then we can run immediately.
        private static Validator GetValidatorFunc(PropertyInfo propInfo, bool dontLogValues)
        {
            // This implicitly caches the attribute lookup once and then shares for each runtime invocation.
            var attrs = propInfo.GetCustomAttributes<ValidationAttribute>();

            return (value) =>
            {
                foreach (var attr in attrs)
                {
                    try
                    {
                        attr.Validate(value, propInfo.Name);
                    }
                    catch (Exception e)
                    {
                        if (dontLogValues)
                        {
                            throw new InvalidOperationException($"Validation failed for property '{propInfo.Name}'. {e.Message}");
                        }
                        else
                        {
                            throw new InvalidOperationException($"Validation failed for property '{propInfo.Name}', value '{value}'. {e.Message}");
                        }
                    }
                }
            };
        }

        // Resolve for AutoResolve.Default templates.
        // These only have access to the {sys} builtin variable and don't get access to trigger binding data.
        internal static BindingDataResolver GetBuiltinTemplateResolver(string originalValue, INameResolver nameResolver, Validator validator)
        {
            string resolvedValue = nameResolver.ResolveWholeString(originalValue);

            var template = BindingTemplate.FromString(resolvedValue);
            if (!template.HasParameters)
            {
                // No { } tokens, bind eagerly up front.
                validator(originalValue);
            }

            SystemBindingData.ValidateStaticContract(template);

            // For static default contracts, we only have access to the built in binding data.
            return (newAttr, bindingData) =>
            {
                var newValue = template.Bind(SystemBindingData.GetSystemBindingData(bindingData));
                validator(newValue);
                return newValue;
            };
        }

        // AutoResolve
        internal static BindingDataResolver GetTemplateResolver(string originalValue, AutoResolveAttribute attr, INameResolver nameResolver, PropertyInfo propInfo, BindingDataContract contract, Validator validator)
        {
            string resolvedValue = nameResolver.ResolveWholeString(originalValue);
            var template = BindingTemplate.FromString(resolvedValue);

            if (!template.HasParameters)
            {
                // No { } tokens, bind eagerly up front.
                validator(resolvedValue);
            }

#pragma warning disable CS0618 // IResolutionPolicy is obsolete
            IResolutionPolicy policy = GetPolicy(attr.ResolutionPolicyType, propInfo);
            template.ValidateContractCompatibility(contract);
            return (newAttr, bindingData) => TemplateBind(policy, propInfo, newAttr, template, bindingData, validator);
        }

        // Get a attribute with %% resolved, but not runtime {} resolved.
        public TAttribute GetNameResolvedAttribute()
        {
            TAttribute attr = ResolveFromBindings(null);
            return attr;
        }

        public string GetInvokeString(TAttribute attributeResolved)
        {
            string invokeString;

            if (_source is not IAttributeInvokeDescriptor<TAttribute> resolver)
            {
                invokeString = DefaultAttributeInvokerDescriptor<TAttribute>.ToInvokeString(_autoResolves, attributeResolved);
            }
            else
            {
                invokeString = resolver.ToInvokeString();
            }
            return invokeString;
        }

        public TAttribute ResolveFromInvokeString(string invokeString)
        {
            TAttribute attr;
            if (_source is not IAttributeInvokeDescriptor<TAttribute> resolver)
            {
                attr = DefaultAttributeInvokerDescriptor<TAttribute>.FromInvokeString(this, invokeString);
            }
            else
            {
                attr = resolver.FromInvokeString(invokeString);
            }
            return attr;
        }

        public TAttribute ResolveFromBindingData(BindingContext ctx)
        {
            var attr = ResolveFromBindings(ctx.BindingData);
            return attr;
        }

        // When there's only 1 resolvable property
        internal TAttribute New(string invokeString)
        {
            if (_autoResolves.Count != 1)
            {
                throw new InvalidOperationException("Invalid invoke string format for attribute.");
            }
            var overrideProps = _autoResolves.Select(pair => pair.Key)
                .ToDictionary(prop => prop.Name, prop => invokeString, StringComparer.OrdinalIgnoreCase);
            return New(overrideProps);
        }

        // Clone the source attribute, but override the properties with the supplied.
        internal TAttribute New(IDictionary<string, string> overrideProperties)
        {
            IDictionary<string, object> propertyValues = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            // Populate inititial properties from the source
            Type t = typeof(TAttribute);
            var properties = t.GetProperties(Flags);
            foreach (var prop in properties)
            {
                propertyValues[prop.Name] = prop.GetValue(_source);
            }

            foreach (var kv in overrideProperties)
            {
                propertyValues[kv.Key] = kv.Value;
            }

            var ctorArgs = Array.ConvertAll(_matchedCtor.GetParameters(), param => propertyValues[param.Name]);
            var newAttr = (TAttribute)_matchedCtor.Invoke(ctorArgs);

            foreach (var prop in properties)
            {
                if (prop.CanWrite)
                {
                    var val = propertyValues[prop.Name];
                    prop.SetValue(newAttr, val);
                }
            }
            return newAttr;
        }

        internal TAttribute ResolveFromBindings(BindingData bindingData)
        {
            // Invoke ctor
            var ctorArgs = Array.ConvertAll(_ctorParamResolvers, func => func(_source, bindingData));
            var newAttr = (TAttribute)_matchedCtor.Invoke(ctorArgs);

            foreach (var setProp in _propertySetters)
            {
                setProp(newAttr, bindingData);
            }

            return newAttr;
        }

        private static string TemplateBind(IResolutionPolicy policy, PropertyInfo prop, Attribute attr, BindingTemplate template, BindingData bindingData, Validator validator)
        {
            if (bindingData == null)
            {
                // Skip validation if no binding data provided. We can't do the { } substitutions.
                return template?.Pattern;
            }

            var newValue = policy.TemplateBind(prop, attr, template, bindingData);
            validator(newValue);
            return newValue;
        }

        internal static IResolutionPolicy GetPolicy(Type formatterType, PropertyInfo propInfo)
        {
            if (formatterType != null)
            {
                if (!typeof(IResolutionPolicy).IsAssignableFrom(formatterType))
                {
                    throw new InvalidOperationException($"The {nameof(AutoResolveAttribute.ResolutionPolicyType)} on {propInfo.Name} must derive from {typeof(IResolutionPolicy).Name}.");
                }

                try
                {
                    var obj = Activator.CreateInstance(formatterType);
                    return (IResolutionPolicy)obj;
                }
                catch (MissingMethodException)
                {
                    throw new InvalidOperationException($"The {nameof(AutoResolveAttribute.ResolutionPolicyType)} on {propInfo.Name} must derive from {typeof(IResolutionPolicy).Name} and have a default constructor.");
                }
            }

            // return the default policy
            return new DefaultResolutionPolicy();
        }
#pragma warning restore CS0618 // Type or member is obsolete

        // If no name resolver is specified, then any %% becomes an error.
        private class EmptyNameResolver : INameResolver
        {
            public string Resolve(string name) => null;
        }
    }
}