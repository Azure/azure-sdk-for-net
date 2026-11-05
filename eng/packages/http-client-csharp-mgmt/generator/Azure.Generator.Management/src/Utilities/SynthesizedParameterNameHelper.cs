// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Generator.Management.Utilities
{
    internal static class SynthesizedParameterNameHelper
    {
        internal static ParameterProvider PreserveName(ParameterProvider parameter)
        {
            // Materialize the argument before Update so historical uppercase names are not camel-cased independently.
            _ = (VariableExpression)parameter;
            parameter.Update(name: parameter.Name);
            return parameter;
        }

        internal static string Normalize(string name)
        {
            var leadingAcronym = Regex.Match(name, "^(?:IPv[46]|Ipv[46]|IpV[46]|iPv[46]|[Ii][Pp]|[Dd][Bb]|[Oo][Ss])(?=[A-Z]|$)");
            if (leadingAcronym.Success)
            {
                return leadingAcronym.Value.ToLowerInvariant() + NormalizeEmbedded(name.Substring(leadingAcronym.Length));
            }
            return NormalizeEmbedded(name).ToVariableName();
        }

        private static string NormalizeEmbedded(string name)
        {
            name = Regex.Replace(name, "(?:Ipv|iPv|IpV)([46])(?=[A-Z]|$)", "IPv$1");
            return Regex.Replace(name, "(Ip|Db|Os)(?=[A-Z]|$)", match => match.Value.ToUpperInvariant());
        }

        internal static InputMethodParameter? GetPathParameter(string serializedName, InputServiceMethod method)
            => method.Parameters.FirstOrDefault(p => p.Location == InputRequestLocation.Path && p.SerializedName == serializedName);

        internal static string GetPathParameterName(string serializedName, InputServiceMethod method)
        {
            var parameter = GetPathParameter(serializedName, method);
            return parameter?.IsExactName == true ? parameter.Name : Normalize(parameter?.Name ?? serializedName);
        }

        internal static string? GetExistingParameterName(
            TypeProvider enclosingType,
            string methodName,
            IReadOnlyList<ParameterProvider> parameters,
            int parameterIndex)
            => parameters[parameterIndex].InputParameter?.IsExactName == true
                ? null
                : GetExistingParameterName(enclosingType, methodName, parameters.Select(parameter => parameter.Type).ToArray(), parameterIndex);

        internal static string? GetExistingParameterName(
            TypeProvider provider,
            string methodName,
            IReadOnlyList<CSharpType> parameterTypes,
            int parameterIndex,
            int parameterOffset = 0,
            IReadOnlyList<CSharpType>? prefixParameterTypes = null)
        {
            if (parameterOffset != (prefixParameterTypes?.Count ?? 0))
            {
                return null;
            }
            foreach (var method in (provider.CustomCodeView?.Methods ?? []).Concat(provider.LastContractView?.Methods ?? []))
            {
                var signature = method.Signature;
                if (signature.Name == methodName &&
                    signature.GenericArguments is not { Count: > 0 } &&
                    !signature.Parameters.Any(parameter => parameter.IsRef || parameter.IsOut || parameter.IsIn) &&
                    signature.Parameters.Count == parameterTypes.Count + parameterOffset &&
                    (prefixParameterTypes?.Select((type, index) => type.AreNamesEqual(signature.Parameters[index].Type)).All(matches => matches) ?? true) &&
                    parameterTypes.Select((type, index) => type.AreNamesEqual(signature.Parameters[index + parameterOffset].Type)).All(matches => matches))
                {
                    return signature.Parameters[parameterIndex + parameterOffset].Name;
                }
            }
            return null;
        }
    }
}
