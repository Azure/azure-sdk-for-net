// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class SignalRTriggerBindingProvider : ITriggerBindingProvider
    {
        private readonly ISignalRTriggerDispatcher _dispatcher;
        private readonly INameResolver _nameResolver;
        private readonly IServiceManagerStore _managerStore;
        private readonly Exception _webhookException;

        public SignalRTriggerBindingProvider(ISignalRTriggerDispatcher dispatcher, INameResolver nameResolver, IServiceManagerStore managerStore, Exception webhookException)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _managerStore = managerStore ?? throw new ArgumentNullException(nameof(managerStore));
            _webhookException = webhookException;
        }

        public async Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var parameterInfo = context.Parameter;
            var attribute = parameterInfo.GetCustomAttribute<SignalRTriggerAttribute>(false);
            if (attribute == null)
            {
                return null;
            }

            if (_webhookException != null)
            {
                throw new NotSupportedException($"SignalR trigger is disabled due to 'AzureWebJobsStorage' connection string is not set or invalid. {_webhookException}");
            }

            var resolvedAttribute = GetParameterResolvedAttribute(attribute, parameterInfo);
            ValidateSignalRTriggerAttributeBinding(resolvedAttribute);

            var hubContextStore = _managerStore.GetOrAddByConnectionStringKey(resolvedAttribute.ConnectionStringSetting);

            var hubContext = await hubContextStore.GetAsync(resolvedAttribute.HubName).ConfigureAwait(false);

            return new SignalRTriggerBinding(parameterInfo, resolvedAttribute, _dispatcher, hubContextStore.SignatureValidationOptions, hubContext as ServiceHubContext);
        }

        internal SignalRTriggerAttribute GetParameterResolvedAttribute(SignalRTriggerAttribute attribute, ParameterInfo parameterInfo)
        {
            //TODO: AutoResolve more properties in attribute
            var hubName = attribute.HubName;
            var category = attribute.Category;
            var @event = attribute.Event;
            var parameterNames = attribute.ParameterNames ?? Array.Empty<string>();
            var connectionStringSetting = attribute.ConnectionStringSetting;

            // We have two models for C#, one is function based model which also work in multiple language
            // Another one is class based model, which is highly close to SignalR itself but must keep some conventions.
            var method = (MethodInfo)parameterInfo.Member;
            var declaredType = method.DeclaringType;
            string[] parameterNamesFromAttribute;

            if (declaredType != null && IsServerlessHub(declaredType))
            {
                // Class based model
                if (!string.IsNullOrEmpty(hubName) ||
                    !string.IsNullOrEmpty(category) ||
                    !string.IsNullOrEmpty(@event) ||
                    parameterNames.Length != 0)
                {
                    throw new ArgumentException($"{nameof(SignalRTriggerAttribute)} must use parameterless constructor in class based model.");
                }
                parameterNamesFromAttribute = method.GetParameters().Where(IsLegalClassBasedParameter).Select(p => p.Name).ToArray();
                hubName = declaredType.Name;
                category = GetCategoryFromMethodName(method.Name);
                @event = GetEventFromMethodName(method.Name, category);
                connectionStringSetting = SignalRTriggerUtils.GetConnectionNameFromAttribute(declaredType) ?? attribute.ConnectionStringSetting;
            }
            else
            {
                parameterNamesFromAttribute = method.GetParameters().
                    Where(p => p.GetCustomAttribute<SignalRParameterAttribute>(false) != null).
                    Select(p => p.Name).ToArray();

                if (parameterNamesFromAttribute.Length != 0 && parameterNames.Length != 0)
                {
                    throw new InvalidOperationException(
                        $"{nameof(SignalRTriggerAttribute)}.{nameof(SignalRTriggerAttribute.ParameterNames)} and {nameof(SignalRParameterAttribute)} can not be set in the same Function.");
                }

                // If we aren't using the class-based model, make sure we resolve binding expressions for attribute properties here.
                hubName = _nameResolver.ResolveWholeString(hubName);
                category = _nameResolver.ResolveWholeString(category);
                @event = _nameResolver.ResolveWholeString(@event);
            }

            parameterNames = parameterNamesFromAttribute.Length != 0
                ? parameterNamesFromAttribute
                : parameterNames;

            return new SignalRTriggerAttribute(hubName, category, @event, parameterNames) { ConnectionStringSetting = connectionStringSetting };
        }

        private static void ValidateSignalRTriggerAttributeBinding(SignalRTriggerAttribute attribute)
        {
            if (string.IsNullOrWhiteSpace(attribute.ConnectionStringSetting))
            {
                throw new InvalidOperationException(
                    $"{nameof(SignalRTriggerAttribute)}.{nameof(SignalRConnectionInfoAttribute.ConnectionStringSetting)} is not allowed to be null or whitespace.");
            }
            ValidateParameterNames(attribute.ParameterNames);
        }

        private static string GetCategoryFromMethodName(string name)
        {
            if (string.Equals(name, Constants.OnConnected, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(name, Constants.OnDisconnected, StringComparison.OrdinalIgnoreCase))
            {
                return SignalRTriggerCategories.Connections;
            }

            return SignalRTriggerCategories.Messages;
        }

        private static string GetEventFromMethodName(string name, string category)
        {
            if (category == SignalRTriggerCategories.Connections)
            {
                if (string.Equals(name, Constants.OnConnected, StringComparison.OrdinalIgnoreCase))
                {
                    return SignalRTriggerEvents.Connected;
                }
                if (string.Equals(name, Constants.OnDisconnected, StringComparison.OrdinalIgnoreCase))
                {
                    return SignalRTriggerEvents.Disconnected;
                }
            }

            return name;
        }

        private static void ValidateParameterNames(string[] parameterNames)
        {
            if (parameterNames == null || parameterNames.Length == 0)
            {
                return;
            }

            if (parameterNames.Length != parameterNames.Distinct(StringComparer.OrdinalIgnoreCase).Count())
            {
                throw new ArgumentException("Elements in ParameterNames should be ignore case unique.");
            }
        }

        private bool IsLegalClassBasedParameter(ParameterInfo parameter)
        {
            // In class based model, we treat all the parameters as a legal parameter except the cases below
            // 1. Parameter decorated by [SignalRIgnore]
            // 2. Parameter decorated Attribute that has BindingAttribute
            // 3. Two special type ILogger and CancellationToken

            if (parameter.ParameterType.IsAssignableFrom(typeof(ILogger)) ||
                parameter.ParameterType.IsAssignableFrom(typeof(CancellationToken)))
            {
                return false;
            }
            if (parameter.GetCustomAttribute<SignalRIgnoreAttribute>() != null)
            {
                return false;
            }
            if (HasBindingAttribute(parameter.GetCustomAttributes()))
            {
                return false;
            }

            return true;
        }

        private static bool HasBindingAttribute(IEnumerable<Attribute> attributes)
        {
            return attributes.Any(attribute => attribute.GetType().GetCustomAttribute<BindingAttribute>(false) != null);
        }

        private static bool IsServerlessHub(Type type)
        {
            if (type == null)
            {
                return false;
            }
            if (type.IsSubclassOf(typeof(ServerlessHub)))
            {
                return true;
            }
            var baseType = type.BaseType;
            while (baseType != null)
            {
                if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(ServerlessHub<>))
                {
                    return true;
                }
                baseType = baseType.BaseType;
            }
            return false;
        }
    }
}