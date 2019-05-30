// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Azure.Core.Extensions
{
    internal class ConfigurationClientFactory
    {
        public object CreateClient(Type clientType, Type optionsType, object options, IConfiguration configuration)
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

        private bool IsOptionsParameter(ParameterInfo parameter, Type optionsType)
        {
            return parameter.ParameterType.IsAssignableFrom(optionsType) &&
                   parameter.Position == ((ConstructorInfo)parameter.Member).GetParameters().Length - 1;
        }

        private string BuildErrorMessage(Type clientType, Type optionsType)
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
        private bool IsApplicableConstructor(ConstructorInfo constructorInfo, Type optionsType)
        {
            var parameters = constructorInfo.GetParameters();

            return constructorInfo.IsPublic &&
                   parameters.Length > 0 &&
                   IsOptionsParameter(parameters[parameters.Length - 1], optionsType);
        }

        private object ConvertArgument(string value, ParameterInfo parameter)
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