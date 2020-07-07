// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Properties;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host.Bindings
{
    // General rule for binding to input parameters.
    // Can invoke Converter manager. 
    // Can leverage OpenTypes for pattern matchers.
    internal class BindToInputBindingProvider<TAttribute, TType> : FluentBindingProvider<TAttribute>, IBindingProvider, IBindingRuleProvider
        where TAttribute : Attribute
    {
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;
        private readonly IConverterManager _converterManager;
        private readonly PatternMatcher _patternMatcher;

        public BindToInputBindingProvider(
            IConfiguration configuration,
            INameResolver nameResolver,
            IConverterManager converterManager,
            PatternMatcher patternMatcher)
        {
            _configuration = configuration;
            _nameResolver = nameResolver;
            _converterManager = converterManager;
            _patternMatcher = patternMatcher;
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var parameter = context.Parameter;
            var typeUser = parameter.ParameterType;

            if (typeUser.IsByRef)
            {
                return Task.FromResult<IBinding>(null);
            }

            var binding = ExactBinding.TryBuild(this, context);

            return Task.FromResult<IBinding>(binding);
        }

        public IEnumerable<BindingRule> GetRules()
        {
            var cm = (ConverterManager)_converterManager;
            var types = cm.GetPossibleDestinationTypesFromSource(typeof(TAttribute), typeof(TType));

            if (typeof(TType).IsPublic)
            {
                yield return new BindingRule
                {
                    SourceAttribute = typeof(TAttribute),
                    UserType = OpenType.FromType<TType>()
                };
            }

            var converters = new Type[] { typeof(TType) };

            foreach (OpenType type in types)
            {
                yield return new BindingRule
                {
                    SourceAttribute = typeof(TAttribute),
                    Converters = converters,
                    UserType = type
                };
            }
        }

        // DefaultTypes (in precedence order) that we check for input bindings. 
        private static readonly Type[] DefaultTypes = new Type[]
        {
            typeof(string),
            typeof(JObject),
            typeof(JArray),
            typeof(byte[]),
            typeof(Stream)
        };

        public Type GetDefaultType(Attribute attribute, FileAccess access, Type requestedType)
        {
            if (!(attribute is TAttribute))
            {
                return null;
            }
            IEnumerable<Type> targets = (requestedType != typeof(object)) ? new Type[] { requestedType } : DefaultTypes;

            if (access == FileAccess.Write)
            {
                return null;
            }

            // if no requestedType, then search for string, JObject, byte[], stream            
            foreach (var rule in GetRules())
            {
                foreach (var target in targets)
                {
                    if (rule.UserType.IsMatch(target))
                    {
                        return target;
                    }
                }
            }

            return null;
        }

        private class ExactBinding : BindingBase<TAttribute>
        {
            private readonly FuncAsyncConverter _buildFromAttribute;
            private readonly FuncAsyncConverter _converter;
            private readonly Type _parameterType;

            public ExactBinding(
                AttributeCloner<TAttribute> cloner,
                ParameterDescriptor param,
                FuncAsyncConverter buildFromAttribute,
                FuncAsyncConverter converter,
                Type parameterType) : base(cloner, param)
            {
                this._buildFromAttribute = buildFromAttribute;
                this._converter = converter;
                this._parameterType = parameterType;
            }

            public static ExactBinding TryBuild(
                BindToInputBindingProvider<TAttribute, TType> parent,
                BindingProviderContext context)
            {
                var cm = parent._converterManager;
                var patternMatcher = parent._patternMatcher;

                var parameter = context.Parameter;
                var userType = parameter.ParameterType;
                var attributeSource = TypeUtility.GetResolvedAttribute<TAttribute>(parameter);

                var cloner = new AttributeCloner<TAttribute>(attributeSource, context.BindingDataContract, parent._configuration, parent._nameResolver);

                FuncAsyncConverter buildFromAttribute;
                FuncAsyncConverter converter = null;

                // Prefer the shortest route to creating the user type.
                // If TType matches the user type directly, then we should be able to directly invoke the builder in a single step. 
                //   TAttribute --> TUserType
                var checker = OpenType.FromType<TType>();
                if (checker.IsMatch(userType))
                {
                    buildFromAttribute = patternMatcher.TryGetConverterFunc(typeof(TAttribute), userType);
                }
                else
                {
                    // Try with a converter
                    // Find a builder for :   TAttribute --> TType
                    // and then couple with a converter:  TType --> TParameterType
                    converter = cm.GetConverter<TAttribute>(typeof(TType), userType);
                    if (converter == null)
                    {
                        var targetType = typeof(TType);
                        context.BindingErrors.Add(String.Format(Resource.BindingAssemblyConflictMessage, targetType.AssemblyQualifiedName, userType.AssemblyQualifiedName));
                        return null;
                    }

                    buildFromAttribute = patternMatcher.TryGetConverterFunc(typeof(TAttribute), typeof(TType));
                }

                if (buildFromAttribute == null)
                {
                    return null;
                }

                ParameterDescriptor param;
                if (parent.BuildParameterDescriptor != null)
                {
                    param = parent.BuildParameterDescriptor(attributeSource, parameter, parent._nameResolver);
                }
                else
                {
                    param = new ParameterDescriptor
                    {
                        Name = parameter.Name,
                        DisplayHints = new ParameterDisplayHints
                        {
                            Description = "input"
                        }
                    };
                }

                return new ExactBinding(cloner, param, buildFromAttribute, converter, userType);
            }

            protected override async Task<IValueProvider> BuildAsync(
                TAttribute attrResolved,
                ValueBindingContext context)
            {
                string invokeString = Cloner.GetInvokeString(attrResolved);

                object obj = await _buildFromAttribute(attrResolved, null, context);
                object finalObj;
                if (_converter == null)
                {
                    finalObj = obj;
                }
                else
                {
                    finalObj = await _converter(obj, attrResolved, context);
                }

                IValueProvider vp = new ConstantValueProvider(finalObj, _parameterType, invokeString);

                return vp;
            }
        }
    }
}
