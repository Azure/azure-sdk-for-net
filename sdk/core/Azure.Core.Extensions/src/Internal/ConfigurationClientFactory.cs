// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Azure.Core.Extensions
{
    internal class ClientFactory
    {
        public static object CreateClient(Type clientType, Type optionsType, object options, IConfiguration configuration, TokenCredential credential)
        {
            List<object> arguments = new List<object>();
            foreach (var constructor in clientType.GetConstructors())
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
                        arguments.Add(credential);
                        continue;
                    }

                    if (IsOptionsParameter(parameter, optionsType))
                    {
                        break;
                    }

                    var value = configuration[parameter.Name];
                    if (value == null)
                    {
                        match = false;
                        break;
                    }

                    arguments.Add(ConvertArgument(value, parameter));
                }

                if (!match)
                {
                    continue;
                }

                arguments.Add(options);

                return constructor.Invoke(arguments.ToArray());
            }

            throw new InvalidOperationException(BuildErrorMessage(clientType, optionsType));
        }

        internal static TokenCredential CreateCredentials(IConfiguration configuration, IdentityClientOptions identityClientOptions = null)
        {
            var clientId = configuration["clientId"];
            var tenantId = configuration["tenantId"];
            var clientSecret = configuration["clientSecret"];
            var certificate = configuration["clientCertificate"];
            var certificateStoreName = configuration["clientCertificateStoreName"];
            var certificateStoreLocation = configuration["clientCertificateStoreLocation"];

            if (!string.IsNullOrWhiteSpace(tenantId) &&
                !string.IsNullOrWhiteSpace(clientId) &&
                !string.IsNullOrWhiteSpace(clientSecret))
            {
                return new ClientSecretCredential(tenantId, clientId, clientSecret, identityClientOptions);
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

                var credential = new ClientCertificateCredential(tenantId, clientId, certs[0], identityClientOptions);
                store.Close();

                return credential;
            }

            // TODO: More logging
            return null;
        }

        private static bool IsCredentialParameter(ParameterInfo parameter)
        {
            return parameter.ParameterType == typeof(TokenCredential);
        }

        private static bool IsOptionsParameter(ParameterInfo parameter, Type optionsType)
        {
            return parameter.ParameterType.IsAssignableFrom(optionsType) &&
                   parameter.Position == ((ConstructorInfo)parameter.Member).GetParameters().Length - 1;
        }

        private static string BuildErrorMessage(Type clientType, Type optionsType)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Unable to find matching constructor. Define one of the follow sets of configuration parameters:");

            int counter = 1;

            foreach (var constructor in clientType.GetConstructors())
            {
                if (!IsApplicableConstructor(constructor, optionsType))
                {
                    continue;
                }

                builder.Append(counter).Append(". ");

                bool first = true;

                foreach (var parameter in constructor.GetParameters())
                {
                    if (IsOptionsParameter(parameter, optionsType))
                    {
                        break;
                    }

                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        builder.Append(", ");
                    }

                    builder.Append(parameter.Name);
                }

                builder.AppendLine();
                counter++;
            }

            return builder.ToString();
        }
        private static bool IsApplicableConstructor(ConstructorInfo constructorInfo, Type optionsType)
        {
            var parameters = constructorInfo.GetParameters();

            return constructorInfo.IsPublic &&
                   parameters.Length > 0 &&
                   IsOptionsParameter(parameters[parameters.Length - 1], optionsType);
        }

        private static object ConvertArgument(string value, ParameterInfo parameter)
        {
            if (parameter.ParameterType == typeof(string))
            {
                return value;
            }

            if (parameter.ParameterType == typeof(Uri))
            {
                return new Uri(value);
            }

            throw new InvalidOperationException($"Unable to convert value '{value}' to parameter type {parameter.ParameterType.FullName}");
        }
    }
}