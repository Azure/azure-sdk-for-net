// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable enable

namespace Azure.Core.Pipeline
{
    internal class ClientDiagnostics : DiagnosticScopeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients; use default (null)
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(ClientOptions options, bool? suppressNestedClientActivities = null)
                    : this(options.GetType().Namespace!,
                    GetResourceProviderNamespace(options.GetType().Assembly),
                    options.Diagnostics,
                    suppressNestedClientActivities)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDiagnostics"/> class.
        /// </summary>
        /// <param name="optionsNamespace">Namespace of the client class, such as Azure.Storage or Azure.AppConfiguration.</param>
        /// <param name="providerNamespace">Azure Resource Provider namespace of the Azure service SDK is primarily used for.</param>
        /// <param name="diagnosticsOptions">The customer provided client diagnostics options.</param>
        /// <param name="suppressNestedClientActivities">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by this <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients, use default (null) for old clients
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        public ClientDiagnostics(string optionsNamespace, string? providerNamespace, DiagnosticsOptions diagnosticsOptions, bool? suppressNestedClientActivities = null)
            : base(optionsNamespace, providerNamespace, diagnosticsOptions.IsDistributedTracingEnabled, suppressNestedClientActivities.GetValueOrDefault(true), true)
        {
        }

        internal static HttpMessageSanitizer CreateMessageSanitizer(DiagnosticsOptions diagnostics)
        {
            return new HttpMessageSanitizer(
                diagnostics.LoggedQueryParameters.ToArray(),
                diagnostics.LoggedHeaderNames.ToArray());
        }

        internal static string? GetResourceProviderNamespace(Assembly assembly)
        {
            foreach (var customAttribute in assembly.GetCustomAttributesData())
            {
                // Weak bind internal shared type
                Type attributeType = customAttribute.AttributeType!;
                if (attributeType.FullName == ("Azure.Core.AzureResourceProviderNamespaceAttribute"))
                {
                    IList<CustomAttributeTypedArgument> namedArguments = customAttribute.ConstructorArguments;
                    return namedArguments.Single().Value as string;
                }
            }

            return null;
        }
    }
}
