// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Azure.Internal;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Azure
{
    internal static class ClientFactory
    {
        private const string ServiceVersionParameterTypeName = "ServiceVersion";
        private const string ConnectionStringParameterName = "connectionString";
        private const char TenantDelimiter = ';';

        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static object CreateClient(
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type clientType,
            Type optionsType,
            object options,
            IConfiguration configuration,
            TokenCredential credential)
        {
            List<object> arguments = new List<object>();
            // Handle single values as connection strings
            if (configuration is IConfigurationSection section && (!string.IsNullOrEmpty(section.Value)))
            {
                var connectionString = section.Value;
                configuration = new ConfigurationBuilder()
                    .AddInMemoryCollection(
                    [
                        new KeyValuePair<string, string>(ConnectionStringParameterName, connectionString)
                    ])
                    .Build();
            }
            foreach (var constructor in clientType.GetConstructors().OrderByDescending(c => c.GetParameters().Length))
            {
                if (!IsApplicableConstructor(constructor, optionsType))
                {
                    continue;
                }

                arguments.Clear();

                bool match = true;
                foreach (var parameter in constructor.GetParameters())
                {
                    if (IsCredentialParameter(parameter))
                    {
                        if (credential == null)
                        {
                            match = false;
                            break;
                        }

                        arguments.Add(credential);
                        continue;
                    }

                    if (IsOptionsParameter(parameter, optionsType))
                    {
                        break;
                    }

                    if (!TryConvertArgument(configuration, parameter.Name, parameter.ParameterType, out object argument))
                    {
                        match = false;
                        break;
                    }

                    arguments.Add(argument);
                }

                if (!match)
                {
                    continue;
                }

                arguments.Add(options);

                return constructor.Invoke(arguments.ToArray());
            }

            throw new InvalidOperationException(BuildErrorMessage(configuration, clientType, optionsType));
        }

        internal static TokenCredential CreateCredential(IConfiguration configuration)
        {
            var credentialType = configuration["credential"];
            var clientId = configuration["clientId"];
            var tenantId = configuration["tenantId"];
            var serviceConnectionId = configuration["serviceConnectionId"];
            var resourceId = configuration["managedIdentityResourceId"];
            var objectId = configuration["managedIdentityObjectId"];
            var clientSecret = configuration["clientSecret"];
            var certificate = configuration["clientCertificate"];
            var certificateStoreName = configuration["clientCertificateStoreName"];
            var certificateStoreLocation = configuration["clientCertificateStoreLocation"];
            var systemAccessToken = configuration["systemAccessToken"];
            var additionallyAllowedTenants = configuration["additionallyAllowedTenants"];
            var tokenFilePath = configuration["tokenFilePath"];
            var azureCloud = configuration["azureCloud"];
            var managedIdentityClientId = configuration["managedIdentityClientId"];

            IEnumerable<string> additionallyAllowedTenantsList = null;

            if (!string.IsNullOrWhiteSpace(additionallyAllowedTenants))
            {
                // not relying on StringSplitOptions.RemoveEmptyEntries as we want to remove leading/trailing whitespace between entries
                additionallyAllowedTenantsList = additionallyAllowedTenants.Split(TenantDelimiter)
                    .Select(t => t.Trim())
                    .Where(t => t.Length > 0);
            }

            if (string.Equals(credentialType, "managedidentity", StringComparison.OrdinalIgnoreCase))
            {
                AssertSingleManagedIdentityIdentifier(clientId, managedIdentityClientId, resourceId, objectId, isFederated: false);

                if (!string.IsNullOrWhiteSpace(resourceId))
                {
                    return new ManagedIdentityCredential(new ResourceIdentifier(resourceId));
                }

                if (!string.IsNullOrWhiteSpace(objectId))
                {
                    return new ManagedIdentityCredential(ManagedIdentityId.FromUserAssignedObjectId(objectId));
                }

                if (!string.IsNullOrWhiteSpace(managedIdentityClientId))
                {
                    return new ManagedIdentityCredential(managedIdentityClientId);
                }

                return new ManagedIdentityCredential(clientId);
            }

            if (string.Equals(credentialType, "workloadidentity", StringComparison.OrdinalIgnoreCase))
            {
                // The WorkloadIdentityCredentialOptions object initialization populates its instance members
                // from the environment variables AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_FEDERATED_TOKEN_FILE
                var workloadIdentityOptions = new WorkloadIdentityCredentialOptions();

                if (!string.IsNullOrWhiteSpace(tenantId))
                {
                    workloadIdentityOptions.TenantId = tenantId;
                }

                if (!string.IsNullOrWhiteSpace(clientId))
                {
                    workloadIdentityOptions.ClientId = clientId;
                }

                if (!string.IsNullOrWhiteSpace(tokenFilePath))
                {
                    workloadIdentityOptions.TokenFilePath = tokenFilePath;
                }

                if (additionallyAllowedTenantsList != null)
                {
                    foreach (string tenant in additionallyAllowedTenantsList)
                    {
                        workloadIdentityOptions.AdditionallyAllowedTenants.Add(tenant);
                    }
                }

                if (!string.IsNullOrWhiteSpace(workloadIdentityOptions.TenantId) &&
                    !string.IsNullOrWhiteSpace(workloadIdentityOptions.ClientId) &&
                    !string.IsNullOrWhiteSpace(workloadIdentityOptions.TokenFilePath))
                {
                    return new WorkloadIdentityCredential(workloadIdentityOptions);
                }

                throw new ArgumentException("For workload identity, 'tenantId', 'clientId', and 'tokenFilePath' must be specified via the configuration.");
            }

            if (string.Equals(credentialType, "managedidentityasfederatedidentity", StringComparison.OrdinalIgnoreCase))
            {
                AssertSingleManagedIdentityIdentifier(clientId, managedIdentityClientId, resourceId, objectId, isFederated: true);

                if (string.IsNullOrWhiteSpace(tenantId) ||
                    string.IsNullOrWhiteSpace(clientId) ||
                    string.IsNullOrWhiteSpace(azureCloud))
                {
                    throw new ArgumentException("For managed identity as a federated identity credential, 'tenantId', 'clientId', 'azureCloud', and one of ['managedIdentityClientId', 'managedIdentityResourceId', 'managedIdentityObjectId'] must be specified via the configuration.");
                }

                if (!string.IsNullOrWhiteSpace(resourceId))
                {
                    return new ManagedFederatedIdentityCredential(tenantId, clientId, ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(resourceId)), azureCloud, additionallyAllowedTenantsList);
                }

                if (!string.IsNullOrWhiteSpace(objectId))
                {
                    return new ManagedFederatedIdentityCredential(tenantId, clientId, ManagedIdentityId.FromUserAssignedObjectId(objectId), azureCloud, additionallyAllowedTenantsList);
                }

                if (!string.IsNullOrWhiteSpace(managedIdentityClientId))
                {
                    return new ManagedFederatedIdentityCredential(tenantId, clientId, ManagedIdentityId.FromUserAssignedClientId(managedIdentityClientId), azureCloud, additionallyAllowedTenantsList);
                }
            }

            if (string.Equals(credentialType, "azurepipelines", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(tenantId) ||
                    string.IsNullOrWhiteSpace(clientId) ||
                    string.IsNullOrWhiteSpace(serviceConnectionId) ||
                    string.IsNullOrWhiteSpace(systemAccessToken))
                {
                    throw new ArgumentException("For Azure Pipelines, 'tenantId', 'clientId', 'serviceConnectionId', and 'systemAccessToken' must be specified via the configuration.");
                }

                var options = new AzurePipelinesCredentialOptions();

                if (additionallyAllowedTenantsList != null)
                {
                    foreach (string tenant in additionallyAllowedTenantsList)
                    {
                        options.AdditionallyAllowedTenants.Add(tenant);
                    }
                }

                return new AzurePipelinesCredential(tenantId, clientId, serviceConnectionId, systemAccessToken, options);
            }

            if (!string.IsNullOrWhiteSpace(tenantId) &&
                !string.IsNullOrWhiteSpace(clientId) &&
                !string.IsNullOrWhiteSpace(clientSecret))
            {
                var options = new ClientSecretCredentialOptions();

                if (additionallyAllowedTenantsList != null)
                {
                    foreach (string tenant in additionallyAllowedTenantsList)
                    {
                        options.AdditionallyAllowedTenants.Add(tenant);
                    }
                }
                return new ClientSecretCredential(tenantId, clientId, clientSecret, options);
            }

            if (!string.IsNullOrWhiteSpace(tenantId) &&
                !string.IsNullOrWhiteSpace(clientId) &&
                !string.IsNullOrWhiteSpace(certificate))
            {
                StoreLocation storeLocation = StoreLocation.CurrentUser;

                if (!string.IsNullOrWhiteSpace(certificateStoreLocation))
                {
                    storeLocation = (StoreLocation)Enum.Parse(typeof(StoreLocation), certificateStoreLocation, true);
                }

                if (string.IsNullOrWhiteSpace(certificateStoreName))
                {
                    certificateStoreName = "MY"; // MY is the default used in X509Store
                }

                using var store = new X509Store(certificateStoreName, storeLocation);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, certificate, false);

                if (certs.Count == 0)
                {
                    throw new InvalidOperationException($"Unable to find a certificate with thumbprint '{certificate}'");
                }

                var options = new ClientCertificateCredentialOptions();

                if (additionallyAllowedTenantsList != null)
                {
                    foreach (string tenant in additionallyAllowedTenantsList)
                    {
                        options.AdditionallyAllowedTenants.Add(tenant);
                    }
                }
                var credential = new ClientCertificateCredential(tenantId, clientId, certs[0], options);

                store.Close();

                return credential;
            }

            if (!string.IsNullOrWhiteSpace(objectId))
            {
                throw new ArgumentException("'managedIdentityObjectId' is only supported when the credential type is 'managedidentity'.");
            }

            if (additionallyAllowedTenantsList != null
                || !string.IsNullOrWhiteSpace(tenantId)
                || !string.IsNullOrWhiteSpace(clientId)
                || !string.IsNullOrWhiteSpace(managedIdentityClientId)
                || !string.IsNullOrWhiteSpace(resourceId))
            {
                var options = new DefaultAzureCredentialOptions();

                if (additionallyAllowedTenantsList != null)
                {
                    foreach (string tenant in additionallyAllowedTenantsList)
                    {
                        options.AdditionallyAllowedTenants.Add(tenant);
                    }
                }

                if (!string.IsNullOrWhiteSpace(tenantId))
                {
                    options.TenantId = tenantId;
                }

                if (!string.IsNullOrWhiteSpace(managedIdentityClientId))
                {
                    options.ManagedIdentityClientId = managedIdentityClientId;
                }
                else if (!string.IsNullOrWhiteSpace(clientId))
                {
                    options.ManagedIdentityClientId = clientId;
                }

                // validation that both clientId and ResourceId are not set happens in Azure.Identity
                if (!string.IsNullOrWhiteSpace(resourceId))
                {
                    options.ManagedIdentityResourceId = new ResourceIdentifier(resourceId);
                }

                return new DefaultAzureCredential(options);
            }
            return null;
        }

        internal static object CreateClientOptions(
            object version,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type optionsType)
        {
            ConstructorInfo parameterlessConstructor = null;
            int versionParameterIndex = 0;
            object[] constructorArguments = null;

            foreach (var constructor in optionsType.GetConstructors())
            {
                var parameters = constructor.GetParameters();
                if (parameters.Length == 0)
                {
                    parameterlessConstructor = constructor;
                    continue;
                }

                bool allParametersHaveDefaultValue = true;
                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo parameter = parameters[i];
                    if (parameter.HasDefaultValue)
                    {
                        if (IsServiceVersionParameter(parameter))
                        {
                            versionParameterIndex = i;
                        }
                    }
                    else
                    {
                        allParametersHaveDefaultValue = false;
                        break;
                    }
                }

                if (allParametersHaveDefaultValue)
                {
                    constructorArguments = new object[parameters.Length];

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        constructorArguments[i] = parameters[i].DefaultValue;
                    }
                }
            }

            if (version != null)
            {
                if (constructorArguments != null)
                {
                    constructorArguments[versionParameterIndex] = version;
                    return Activator.CreateInstance(optionsType, constructorArguments);
                }

                throw new InvalidOperationException("Unable to find constructor that takes service version");
            }

            if (parameterlessConstructor != null)
            {
                return Activator.CreateInstance(optionsType);
            }

            return Activator.CreateInstance(optionsType, constructorArguments);
        }

        private static void AssertSingleManagedIdentityIdentifier(string clientId, string managedIdentityClientId, string resourceId, string objectId, bool isFederated = false)
        {
            var idCount = 0;

            if (!isFederated)
            {
                idCount += string.IsNullOrWhiteSpace(clientId) ? 0 : 1;
            }

            idCount += string.IsNullOrWhiteSpace(managedIdentityClientId) ? 0 : 1;
            idCount += string.IsNullOrWhiteSpace(resourceId) ? 0 : 1;
            idCount += string.IsNullOrWhiteSpace(objectId) ? 0 : 1;

            var validIdentifiers = isFederated
                ? "'managedIdentityClientId', 'managedIdentityResourceId', or 'managedIdentityObjectId'"
                : "'clientId', 'managedIdentityClientId', 'managedIdentityResourceId', or 'managedIdentityObjectId'";

            if (idCount > 1)
            {
                throw new ArgumentException($"Only one of [{validIdentifiers}] can be specified for managed identity.");
            }

            if (idCount < 1)
            {
                var clientIdPart = isFederated ? "A clientId and exactly one" : "Exactly one";
                var federatedPart = isFederated ? "federated " : " ";

                throw new ArgumentException($"{clientIdPart} of [{validIdentifiers}] must be specified for {federatedPart}managed identity.");
            }
        }

        private static bool IsServiceVersionParameter(ParameterInfo parameter) =>
            parameter.ParameterType.Name == ServiceVersionParameterTypeName;

        private static bool IsCredentialParameter(ParameterInfo parameter)
        {
            return parameter.ParameterType == typeof(TokenCredential);
        }

        private static bool IsOptionsParameter(ParameterInfo parameter, Type optionsType)
        {
            return parameter.ParameterType.IsAssignableFrom(optionsType) &&
                   parameter.Position == ((ConstructorInfo)parameter.Member).GetParameters().Length - 1;
        }

        [RequiresUnreferencedCode("Walks the constructors of the type's constructor parameters, which can't be annotated for trimming.")]
        private static string BuildErrorMessage(
            IConfiguration configuration,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type clientType,
            Type optionsType)
        {
            var builder = new StringBuilder();

            void TrimTrailingDelimiter()
            {
                while (builder[builder.Length - 1] is '/' or ',' or ' ')
                {
                    builder.Length--;
                }
            }

            builder.Append("Unable to find matching constructor while trying to create an instance of ").Append(clientType.Name).AppendLine(".");
            builder.AppendLine("Expected one of the follow sets of configuration parameters:");

            int counter = 1;

            foreach (var constructor in clientType.GetConstructors())
            {
                if (!IsApplicableConstructor(constructor, optionsType))
                {
                    continue;
                }

                builder.Append(counter).Append(". ");

                foreach (var parameter in constructor.GetParameters())
                {
                    if (IsOptionsParameter(parameter, optionsType))
                    {
                        break;
                    }

                    if (parameter.ParameterType is { IsClass: true } parameterType &&
                        parameterType != typeof(string) &&
                        parameterType != typeof(Uri))
                    {
                        foreach (var parameterConstructor in GetApplicableParameterConstructors(parameterType))
                        {
                            foreach (var parameterConstructorParameter in parameterConstructor.GetParameters())
                            {
                                builder
                                    .Append(parameter.Name)
                                    .Append(':')
                                    .Append(parameterConstructorParameter.Name)
                                    .Append(", ");
                            }

                            TrimTrailingDelimiter();
                            builder.Append('/');
                        }

                        TrimTrailingDelimiter();
                    }
                    else
                    {
                        builder.Append(parameter.Name);
                    }

                    builder.Append(", ");
                }

                TrimTrailingDelimiter();

                builder.AppendLine();
                counter++;
            }

            builder.AppendLine();
            builder.Append("Found the following configuration keys: ");

            foreach (var child in configuration.AsEnumerable(true))
            {
                builder.Append(child.Key).Append(", ");
            }

            TrimTrailingDelimiter();

            return builder.ToString();
        }

        private static bool IsApplicableConstructor(ConstructorInfo constructorInfo, Type optionsType)
        {
            var parameters = constructorInfo.GetParameters();

            return constructorInfo.IsPublic &&
                   parameters.Length > 0 &&
                   IsOptionsParameter(parameters[parameters.Length - 1], optionsType);
        }

        [RequiresUnreferencedCode("Recursively walks the constructors of parameterType's constructor parameters, which can't be annotated for trimming.")]
        private static bool TryConvertArgument(
            IConfiguration configuration,
            string parameterName,
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type parameterType,
            out object value)
        {
            if (parameterType == typeof(string))
            {
                return TryConvertFromString(configuration, parameterName, s => s, out value);
            }

            if (parameterType == typeof(Uri))
            {
                return TryConvertFromString(configuration, parameterName, s => new Uri(s), out value);
            }

            if (parameterType == typeof(Guid))
            {
                return TryConvertFromString(configuration, parameterName, s => Guid.Parse(s), out value);
            }

            return TryCreateObject(parameterType, configuration.GetSection(parameterName), out value);
        }

        private static bool TryConvertFromString(IConfiguration configuration, string parameterName, Func<string, object> func, out object value)
        {
            string stringValue = configuration[parameterName];
            if (stringValue == null)
            {
                value = null;
                return false;
            }

            value = func(stringValue);
            return true;
        }

        [RequiresUnreferencedCode("Recursively walks the constructors of the type's constructor parameters, which can't be annotated for trimming.")]
        internal static bool TryCreateObject(
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type,
            IConfigurationSection configuration,
            out object value)
        {
            if (!configuration.GetChildren().Any())
            {
                value = null;
                return false;
            }

            List<object> arguments = new List<object>();
            foreach (var constructor in GetApplicableParameterConstructors(type))
            {
                arguments.Clear();

                bool match = true;
                foreach (var parameter in constructor.GetParameters())
                {
                    if (!TryConvertArgument(configuration, parameter.Name, parameter.ParameterType, out object argument))
                    {
                        match = false;
                        break;
                    }

                    arguments.Add(argument);
                }

                if (!match)
                {
                    continue;
                }

                value = constructor.Invoke(arguments.ToArray());
                return true;
            }

            value = null;
            return false;
        }

        private static IOrderedEnumerable<ConstructorInfo> GetApplicableParameterConstructors(
            [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] Type type)
        {
            return type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).OrderByDescending(c => c.GetParameters().Length);
        }
    }
}