// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.Extensions.Configuration;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that removes System.ClientModel-based settings types and constructors that are incompatible with Azure.Core,
    /// and replaces AuthenticationPolicy parameters with HttpPipelinePolicy in internal client constructors.
    /// </summary>
    internal class AzureClientSettingsVisitor : ScmLibraryVisitor
    {
        /// <summary>
        /// Removes ClientSettingsProvider types from the output library since Azure.Core does not have an equivalent
        /// of System.ClientModel.Primitives.ClientSettings.
        /// </summary>
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is ClientSettingsProvider)
            {
                return null;
            }
            return type;
        }

        /// <summary>
        /// Fixes constructors that are incompatible with Azure.Core:
        /// 1. In ClientProvider: Replaces AuthenticationPolicy parameter with HttpPipelinePolicy in internal constructors.
        /// 2. Removes Settings-based constructors (marked with SCME0002 experimental attribute).
        /// 3. In ClientOptionsProvider: Removes IConfigurationSection-based constructors.
        /// </summary>
        protected override ConstructorProvider? VisitConstructor(ConstructorProvider constructor)
        {
            // Remove any constructor marked with the ExperimentalAttribute
            // (these are Settings-based constructors that use System.ClientModel experimental APIs)
            if (constructor.Signature.Attributes.Any(
                attr => attr is AttributeStatement attributeStatement
                    && attributeStatement.Type.Equals(typeof(System.Diagnostics.CodeAnalysis.ExperimentalAttribute))))
            {
                return null;
            }

            // In ClientProvider's internal constructors, replace AuthenticationPolicy parameter
            // with HttpPipelinePolicy since Azure.Core uses HttpPipelinePolicy-based pipeline.
            if (constructor.EnclosingType is ClientProvider
                && constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal))
            {
                var authPolicyParam = constructor.Signature.Parameters.FirstOrDefault(
                    p => p.Type.Equals(typeof(System.ClientModel.Primitives.AuthenticationPolicy)));

                if (authPolicyParam != null)
                {
                    authPolicyParam.Type = new CSharpType(typeof(HttpPipelinePolicy));
                }
            }

            // In ClientOptionsProvider, remove constructors that take IConfigurationSection
            // since Azure.Core.ClientOptions does not have a constructor that takes IConfigurationSection.
            if (constructor.EnclosingType is ClientOptionsProvider)
            {
                if (constructor.Signature.Parameters.Any(p => p.Type.Equals(typeof(IConfigurationSection))))
                {
                    return null;
                }
            }

            return constructor;
        }
    }
}
