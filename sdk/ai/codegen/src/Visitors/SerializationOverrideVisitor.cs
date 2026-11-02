// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that fixes generated serialization methods that are declared as <c>virtual</c>
    /// even though the model's base type already declares the same method. In that case the method
    /// should be declared as <c>override</c> rather than re-declared as <c>virtual</c>.
    /// Also acknowledges implementation references to preview members and variants inside GA
    /// serialization and constructor bodies, without suppressing diagnostics on public signatures.
    /// </summary>
    /// <remarks>
    /// This situation occurs when a generated model derives from a base type that lives in another
    /// assembly (for example <c>BingGroundingToolCall : OpenAI.Responses.ResponseItem</c>). The
    /// generator emits some of the Model-Reader-Writer "core" methods (such as
    /// <c>PersistableModelCreateCore</c>, <c>PersistableModelWriteCore</c> and
    /// <c>JsonModelCreateCore</c>) as <c>virtual</c> instead of <c>override</c>, which breaks
    /// polymorphic serialization dispatch. For models whose base type is generated in the same
    /// library the generator already emits <c>override</c> correctly, so those methods are not
    /// flagged here.
    ///
    /// The base type is external (it comes from a referenced assembly), so it is not represented as a
    /// framework <see cref="System.Type"/> and the assembly that declares it is not loaded in the
    /// generator process. We therefore cannot reflect over the base type. Instead we rely on the
    /// structural evidence the generator already produces for a model that derives from a serializable
    /// base:
    /// <list type="number">
    ///   <item><description>It emits at least one serialization "core" method as <c>override</c>
    ///   (typically <c>JsonModelWriteCore</c>, which calls <c>base.JsonModelWriteCore</c>).</description></item>
    ///   <item><description>Its <c>...CreateCore</c> methods return the model's base type rather than
    ///   the model's own type.</description></item>
    /// </list>
    /// When either signal is present the model has a serializable base, so every remaining
    /// <c>virtual</c> "core" method in the serialization partial is rewritten to <c>override</c>.
    /// </remarks>
    public class SerializationOverrideVisitor : ScmLibraryVisitor
    {
        private readonly Dictionary<string, ModelProvider> _models = new();

        protected override ModelProvider PreVisitModel(InputModelType input, ModelProvider model)
        {
            if (model != null)
            {
                _models[model.Type.FullyQualifiedName] = model;
            }
            return base.PreVisitModel(input, model);
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            if (type is MrwSerializationTypeDefinition serialization && HasSerializableBase(serialization))
            {
                foreach (var method in serialization.Methods)
                {
                    ConvertVirtualToOverride(method);
                }
            }

            return base.VisitType(type);
        }

        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            if (method.EnclosingType is MrwSerializationTypeDefinition && method.BodyStatements != null &&
                _models.TryGetValue(method.EnclosingType.Type.FullyQualifiedName, out ModelProvider model) &&
                !HasExperimentalAttribute(model.Attributes) &&
                (HasExperimentalMembers(model) || model.DerivedModels.Any(derived => HasExperimentalAttribute(derived.Attributes))))
            {
                // GA models can serialize preview members and variants without making their public API preview.
                method.Update(bodyStatements: AcknowledgeImplementationReferences(method.BodyStatements));
            }
            return base.VisitMethod(method);
        }

        protected override ConstructorProvider VisitConstructor(ConstructorProvider constructor)
        {
            if (constructor.EnclosingType is ModelProvider model && constructor.BodyStatements != null &&
                !HasExperimentalAttribute(model.Attributes) && !HasExperimentalAttribute(constructor.Signature.Attributes) &&
                HasExperimentalMembers(model))
            {
                // Initializing optional preview-backed collections does not make a parameterless constructor preview.
                constructor.Update(bodyStatements: AcknowledgeImplementationReferences(constructor.BodyStatements));
            }
            return base.VisitConstructor(constructor);
        }

        private static MethodBodyStatement AcknowledgeImplementationReferences(MethodBodyStatement body)
            => new SuppressionStatement(
                new SuppressionStatement(body, Literal("AAIP002"),
                    "Implementation accesses OpenAI-dependent members."),
                Literal("AAIP001"), "Implementation preserves preview variants of GA models.");

        private static bool HasExperimentalAttribute(IEnumerable<AttributeStatement> attributes)
            => attributes.Any(attribute => attribute.Type.Equals(typeof(ExperimentalAttribute)));

        private static bool HasExperimentalMembers(ModelProvider model)
            => model.Properties.Any(property => HasExperimentalAttribute(property.Attributes)) ||
                model.Fields.Any(field => HasExperimentalAttribute(field.Attributes));

        private static bool HasSerializableBase(MrwSerializationTypeDefinition serialization)
        {
            CSharpType baseType = serialization.Type?.BaseType;
            if (baseType is null || baseType.Equals(typeof(object)))
            {
                return false;
            }

            foreach (var method in serialization.Methods)
            {
                MethodSignature signature = method.Signature;

                // The generator already overrode a serialization core method (e.g. JsonModelWriteCore),
                // which proves the base type participates in the same serialization hierarchy.
                if (signature.Modifiers.HasFlag(MethodSignatureModifiers.Override))
                {
                    return true;
                }

                // A create-core method returns the model's base type only for a derived model; for a
                // root model it returns the model's own type.
                if (signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual)
                    && signature.ReturnType is not null
                    && signature.ReturnType.Equals(baseType))
                {
                    return true;
                }
            }

            return false;
        }

        private static void ConvertVirtualToOverride(MethodProvider method)
        {
            MethodSignature signature = method.Signature;

            // Only re-declarations matter: the method must be virtual, not already an override, and not
            // an explicit interface implementation (which is never virtual/override).
            if (!signature.Modifiers.HasFlag(MethodSignatureModifiers.Virtual)
                || signature.Modifiers.HasFlag(MethodSignatureModifiers.Override)
                || signature.ExplicitInterface is not null)
            {
                return;
            }

            MethodSignatureModifiers updatedModifiers =
                (signature.Modifiers & ~MethodSignatureModifiers.Virtual) | MethodSignatureModifiers.Override;

            method.Signature.Update(modifiers: updatedModifiers);
        }
    }
}
