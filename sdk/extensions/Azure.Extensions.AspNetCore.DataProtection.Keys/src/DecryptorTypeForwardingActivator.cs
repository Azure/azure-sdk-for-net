// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Microsoft.AspNetCore.DataProtection
{
    /// <summary>
    /// This type is a copy of https://github.com/dotnet/aspnetcore/blob/e1bf38ccaf2a98f95e48bf22b8b76d996a0c33ea/src/DataProtection/DataProtection/test/TypeForwardingActivatorTests.cs
    /// with addition of AzureKeyVaultXmlDecryptor forwarding logic.
    /// </summary>
    internal class DecryptorTypeForwardingActivator : IActivator
    {
        private readonly IServiceProvider _services;
        private const string OldNamespace = "Microsoft.AspNet.DataProtection";
        private const string CurrentNamespace = "Microsoft.AspNetCore.DataProtection";
        private const string CurrentAzureNamespace = "Azure.Extensions.AspNetCore.DataProtection.Keys";

        private const string OldDecryptor = "Microsoft.AspNetCore.DataProtection.AzureKeyVault.AzureKeyVaultXmlDecryptor";
        private const string OldDecryptorAssembly = "Microsoft.AspNetCore.DataProtection.AzureKeyVault";
        private const string NewDecryptor = "Azure.Extensions.AspNetCore.DataProtection.Keys.AzureKeyVaultXmlDecryptor";
        private const string NewDecryptorAssembly = "Azure.Extensions.AspNetCore.DataProtection.Keys";

        private readonly ILogger _logger;
        private static readonly Regex _versionPattern = new Regex(@",\s?Version=[0-9]+(\.[0-9]+){0,3}", RegexOptions.Compiled, TimeSpan.FromSeconds(2));
        private static readonly Regex _tokenPattern = new Regex(@",\s?PublicKeyToken=[\w\d]+", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        public DecryptorTypeForwardingActivator(IServiceProvider services)
            : this(services, NullLoggerFactory.Instance)
        {
        }

        public DecryptorTypeForwardingActivator(IServiceProvider services, ILoggerFactory loggerFactory)
        {
            _services = services;
            _logger = loggerFactory.CreateLogger(typeof(DecryptorTypeForwardingActivator));
        }

        public object CreateInstance(Type expectedBaseType, string originalTypeName)
            => CreateInstance(expectedBaseType, originalTypeName, out var _);

        // for testing
        internal object CreateInstance(Type expectedBaseType, string originalTypeName, out bool forwarded)
        {
            var forwardedTypeName = originalTypeName;
            var candidate = false;
            if (originalTypeName.Contains(OldNamespace))
            {
                candidate = true;
                forwardedTypeName = originalTypeName.Replace(OldNamespace, CurrentNamespace);
            }

            if (originalTypeName.Contains(OldDecryptor))
            {
                candidate = true;
                forwardedTypeName = originalTypeName
                    .Replace(OldDecryptor, NewDecryptor)
                    .Replace(OldDecryptorAssembly, NewDecryptorAssembly);
            }

            if ((candidate || forwardedTypeName.StartsWith(CurrentNamespace + ".", StringComparison.Ordinal)) ||
                forwardedTypeName.StartsWith(CurrentAzureNamespace + ".", StringComparison.Ordinal))
            {
                candidate = true;
                forwardedTypeName = RemoveVersionFromAssemblyName(forwardedTypeName);
                forwardedTypeName = RemovePublicKeyTokenFromAssemblyName(forwardedTypeName);
            }

            if (candidate)
            {
                var type = Type.GetType(forwardedTypeName, false);
                if (type != null)
                {
                    _logger.LogDebug("Forwarded activator type request from {FromType} to {ToType}",
                        originalTypeName,
                        forwardedTypeName);
                    forwarded = true;
                    return CreateInstanceImpl(expectedBaseType, forwardedTypeName);
                }
            }

            forwarded = false;
            return CreateInstanceImpl(expectedBaseType, originalTypeName);
        }

        private static string RemovePublicKeyTokenFromAssemblyName(string forwardedTypeName)
            => _tokenPattern.Replace(forwardedTypeName, "");

        internal static string RemoveVersionFromAssemblyName(string forwardedTypeName)
            => _versionPattern.Replace(forwardedTypeName, "");

        private object CreateInstanceImpl(Type expectedBaseType, string implementationTypeName)
        {
            // Would the assignment even work?
            var implementationType = Type.GetType(implementationTypeName, throwOnError: true);

            if (!expectedBaseType.IsAssignableFrom(implementationType))
            {
                // It might seem a bit strange to throw an InvalidCastException explicitly rather than
                // to let the CLR generate one, but searching through NetFX there is indeed precedent
                // for this pattern when the caller knows ahead of time the operation will fail.
                throw new InvalidCastException($"The type '{implementationType.AssemblyQualifiedName}' is not assignable to '{expectedBaseType.AssemblyQualifiedName}'.");
            }

            // If no IServiceProvider was specified, prefer .ctor() [if it exists]
            if (_services == null)
            {
                var ctorParameterless = implementationType.GetConstructor(Type.EmptyTypes);
                if (ctorParameterless != null)
                {
                    return Activator.CreateInstance(implementationType);
                }
            }

            // If an IServiceProvider was specified or if .ctor() doesn't exist, prefer .ctor(IServiceProvider) [if it exists]
            var ctorWhichTakesServiceProvider = implementationType.GetConstructor(new Type[] { typeof(IServiceProvider) });
            if (ctorWhichTakesServiceProvider != null)
            {
                return ctorWhichTakesServiceProvider.Invoke(new[] { _services });
            }

            // Finally, prefer .ctor() as an ultimate fallback.
            // This will throw if the ctor cannot be called.
            return Activator.CreateInstance(implementationType);
        }
    }
}