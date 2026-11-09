// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that adds <see cref="ExperimentalAttribute"/> to generated models and members whose
    /// Foundry metadata requires preview features, while retaining stable surfaces with conditional preview variants.
    /// </summary>
    /// <remarks>
    /// This visitor mirrors the pattern established by the upstream OpenAI library's codegen plugin
    /// (ExperimentalAttributeVisitor), adapted for Azure.AI.Extensions.OpenAI conventions.
    /// </remarks>
    public class ExperimentalAttributeVisitor : ScmLibraryVisitor
    {
        private const string DiagnosticId = "AAIP001";

        private readonly HashSet<string> _experimentalClasses = new(StringComparer.Ordinal);
        private readonly HashSet<string> _experimentalProperties = new(StringComparer.Ordinal);
        private readonly HashSet<string> _conditionalClasses = new(StringComparer.Ordinal);

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        private bool ImplementsExperimrental(TypeProvider theType)
        {
            foreach (CSharpType theInterface in theType.Implements)
            {
                if (IsListed(theInterface.FullyQualifiedName))
                {
                    return true;
                }
                if (theInterface.IsGenericType)
                {
                    foreach (CSharpType generic in theInterface.Arguments)
                    {
                        if (IsListed(generic.FullyQualifiedName))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool HasExperimentalAncestor(CSharpType theType)
        {
            if (theType.BaseType is null)
            {
                return false;
            }
            return IsListed(theType.BaseType.FullyQualifiedName) || HasExperimentalAncestor(theType.BaseType);
        }

        public bool IsExperimental(CSharpType theType)
        {
            if (theType is null)
            {
                return false;
            }
            theType = theType.GetNestedElementType();
            if (IsListed(theType.FullyQualifiedName))
            {
                return true;
            }
            if (theType.IsGenericType)
            {
                foreach (CSharpType generic in theType.Arguments)
                {
                    if (IsExperimental(generic))
                    {
                        return true;
                    }
                }
            }
            return HasExperimentalAncestor(theType);
        }

        private static (bool Required, bool Conditional) GetPreviewMetadata(IEnumerable<InputDecoratorInfo> decorators)
        {
            bool requiredPreview = false;
            bool conditionalPreview = false;
            foreach (InputDecoratorInfo decorator in decorators)
            {
                if (decorator.Name != "TypeSpec.OpenAPI.@extension" ||
                    decorator.Arguments == null ||
                    !decorator.Arguments.TryGetValue("key", out BinaryData key))
                {
                    continue;
                }
                using JsonDocument keyDocument = JsonDocument.Parse(key);
                if (keyDocument.RootElement.ValueKind != JsonValueKind.String ||
                    keyDocument.RootElement.GetString() != "x-ms-foundry-meta")
                {
                    continue;
                }
                if (!decorator.Arguments.TryGetValue("value", out BinaryData metadata))
                {
                    throw new InvalidOperationException("Foundry metadata extension must have a value.");
                }
                using JsonDocument document = JsonDocument.Parse(metadata);
                JsonElement value = document.RootElement;
                bool hasPreviewMetadata = false;
                if (value.ValueKind == JsonValueKind.Object &&
                    value.TryGetProperty("required_previews", out JsonElement required))
                {
                    if (required.ValueKind != JsonValueKind.Array)
                    {
                        throw new InvalidOperationException("required_previews must be an array.");
                    }
                    requiredPreview |= required.GetArrayLength() > 0;
                    hasPreviewMetadata = true;
                }
                // Conditional metadata describes preview variants on a GA surface, not a preview base type.
                if (value.ValueKind == JsonValueKind.Object &&
                    value.TryGetProperty("conditional_previews", out JsonElement conditional))
                {
                    if (conditional.ValueKind != JsonValueKind.Array)
                    {
                        throw new InvalidOperationException("conditional_previews must be an array.");
                    }
                    conditionalPreview |= conditional.GetArrayLength() > 0;
                    hasPreviewMetadata = true;
                }
                if (!hasPreviewMetadata)
                {
                    requiredPreview = true;
                }
            }
            return (requiredPreview, conditionalPreview);
        }

        internal static void SuppressExperimentalImplementationReferences(TypeProvider type, string diagnosticId)
        {
            const string justification = "Model initialization and serialization support experimental members and variants.";
            foreach (ConstructorProvider constructor in type.Constructors)
            {
                constructor.Update(suppressions:
                    [.. constructor.Suppressions, new SuppressionStatement(null, Snippet.Literal(diagnosticId), justification)]);
            }
            foreach (TypeProvider serializer in type.SerializationProviders)
            {
                foreach (MethodProvider method in serializer.Methods)
                {
                    method.Update(suppressions:
                        [.. method.Suppressions, new SuppressionStatement(null, Snippet.Literal(diagnosticId), justification)]);
                }
            }
        }

        private static bool IsLiveDecisionDependency(InputModelType modelType, ModelProvider type)
        {
            // These upstream Live models lack Foundry preview metadata and are only exposed by Live.
            // Scope the fallback to exact source identities in Agents, not arbitrary dependencies of Live
            // models: those can be shared with stable APIs. Existing inheritance and factory handling below
            // also cover the QuestionParam, LiveDecisionQuestion, and AnswerResource descendants.
            return type?.Type.Namespace == "Azure.AI.Projects.Agents"
                && modelType.CrossLanguageDefinitionId is
                    "OpenAI.QuestionParam" or
                    "OpenAI.ChoiceOptionParam" or
                    "OpenAI.ScoreLevelParam" or
                    "OpenAI.LiveDecisionQuestion" or
                    "OpenAI.LiveDecisionChoiceParam" or
                    "OpenAI.LiveDecisionScoreLevelParam" or
                    "OpenAI.LiveDecisionInputJsonParam" or
                    "OpenAI.LiveDecisionJsonObject" or
                    "OpenAI.LiveSessionCreateParamsDelegationLiveClientDelegationParam" or
                    "OpenAI.LiveSessionUpdateParamsDelegationLiveClientDelegationParam" or
                    "OpenAI.DecisionResponse" or
                    "OpenAI.AnswerResource" or
                    "OpenAI.ChoiceProbabilityResource" or
                    "OpenAI.ScoreProbabilityResource" or
                    "OpenAI.ResponseUsageResource" or
                    "OpenAI.InputTokensDetailsResource" or
                    "OpenAI.OutputTokensDetailsResource";
        }

        private static string ToCapitalizedCamelCase(string value)
        {
            // Convert snake_case to CapitalizedCamelCase.
            string[] parts = value.Split('_');
            StringBuilder sb = new();
            foreach (string part in parts)
            {
                sb.Append(part[0..1].ToUpper());
                sb.Append(part.AsSpan(1, part.Length - 1));
            }
            return sb.ToString();
        }

        /// <inheritdoc />
        protected override ModelProvider PreVisitModel(InputModelType modelType, ModelProvider type)
        {
            var preview = GetPreviewMetadata(modelType.Decorators);
            if (preview.Required || IsLiveDecisionDependency(modelType, type))
            {
                _experimentalClasses.Add(type.Type.FullyQualifiedName);
            }
            if (preview.Conditional)
            {
                _conditionalClasses.Add(type.Type.FullyQualifiedName);
            }
            return base.PreVisitModel(modelType, type);
        }

        protected override EnumProvider PreVisitEnum(InputEnumType enumType, EnumProvider type)
        {
            bool isLiveEnum = type?.Type.Namespace == "Azure.AI.Projects.Agents"
                && (enumType.CrossLanguageDefinitionId?.StartsWith("OpenAI.Live", StringComparison.Ordinal) == true ||
                    // Literal helper enums have no source ID; these belong only to Live initial-message models.
                    (string.IsNullOrEmpty(enumType.CrossLanguageDefinitionId) && enumType.Name is
                        "LiveInitialAssistantMessageItemParamType" or
                        "LiveInitialDeveloperMessageItemParamType" or
                        "LiveInitialInputTextContentPartParamType" or
                        "LiveInitialTextContentPartParamType" or
                        "LiveInitialUserMessageItemParamType"));
            if (GetPreviewMetadata(enumType.Decorators).Required || isLiveEnum)
            {
                _experimentalClasses.Add(type.Type.FullyQualifiedName);
            }
            return base.PreVisitEnum(enumType, type);
        }

        protected override PropertyProvider PreVisitProperty(InputProperty property, PropertyProvider propertyProvider)
        {
            string fixedPropertyName = ToCapitalizedCamelCase(property.Name);
            if (GetPreviewMetadata(property.Decorators).Required)
            {
                _experimentalProperties.Add($"{propertyProvider.EnclosingType.Type.FullyQualifiedName}.{fixedPropertyName}");
            }
            return base.PreVisitProperty(property, propertyProvider);
        }

        public bool IsListed(string type)
        {
            if (type is null)
            {
                return false;
            }
            return _experimentalClasses.Contains(type);
        }

        public bool IsPropertyListed(string property) => _experimentalProperties.Contains(property);

        private bool HasOnlyExperimentalConstructors(TypeProvider type)
            => type.Constructors.Count > 0 &&
                type.Constructors.All(constructor => constructor.Signature.Parameters.Any(parameter => IsExperimental(parameter.Type)));

        /// <summary>
        /// Return true if the class is marked as experimental in custom code.
        /// </summary>
        /// <param name="type">The type provider for class.</param>
        /// <returns>If the class already have experimental tag.</returns>
        private static bool HasCustomExperimentalMark(TypeProvider type)
        {
            // Get the class name according to typespec
            IEnumerable<AttributeStatement> allAttributes =
            [
                .. type.Attributes,
                .. type.CustomCodeView?.Attributes ?? [],
                .. type.SerializationProviders.SelectMany(serializer => serializer.Attributes),
                .. type.SerializationProviders.SelectMany(serializer => serializer.CustomCodeView?.Attributes ?? []),
            ];
            // 
            return allAttributes
                .Where(x => string.Equals(x.Type.Name, "ExperimentalAttribute") && x.Arguments.Count == 1 && x.Arguments[0] is LiteralExpression)
                .Select(x => (x.Arguments[0] as LiteralExpression).Literal.ToString())
                .Where(x => string.Equals(x, DiagnosticId)).Any();
        }

        /// <inheritdoc />
        protected override TypeProvider VisitType(TypeProvider type)
        {
            if (HasCustomExperimentalMark(type))
            {
                _attributedTypes.Add(type.Type.FullyQualifiedName);
            }
            // Diagnostic code for troubleshooting.
            //if (string.Equals(type.Type.Name, "AIProjectMemoryStores"))
            //{
            //    throw new InvalidOperationException(
            //        $"================================================\n" +
            //        $"{type.Type.FullyQualifiedName}\n" +
            //        $"Is already experimental: {_attributedTypes.Contains(type.Type.FullyQualifiedName)}\n" +
            //        $"Has experimental parent: {HasExperimentalAncestor(type.Type)}\n" +
            //        $"Implements experimental interface: {ImplementsExperimrental(type)}\n" +
            //        $"Has the experimental attribute: {type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))}\n" +
            //        $"Is explicitly marked as experimental: {IsListed(type.Type.FullyQualifiedName)}\n" +
            //        $"================================================\n");
            //}
            // First check if the whole class needs to be marked as experimental.
            if ((IsListed(type.Type.FullyQualifiedName) || HasExperimentalAncestor(type.Type) || ImplementsExperimrental(type))
                && !type.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))
                && _attributedTypes.Add(type.Type.FullyQualifiedName))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }
            // If the whole class was already marked as experimental, no need to mark methods/constructors/properties.
            if (_attributedTypes.Contains(type.Type.FullyQualifiedName))
            {
                return base.VisitType(type);
            }
            bool supportsPreviewVariants = _conditionalClasses.Contains(type.Type.FullyQualifiedName) ||
                type is ModelProvider model && model.DerivedModels.Any(derived =>
                    IsExperimental(derived.Type) || HasOnlyExperimentalConstructors(derived));
            if (supportsPreviewVariants)
            {
                SuppressExperimentalImplementationReferences(type, DiagnosticId);
            }
            bool isDirty = false;
            // Constructors
            List<ConstructorProvider> constructors = [];
            // In a first run we will check if all the constructors are experimental and if it is the case, mark class experimental.
            if (HasOnlyExperimentalConstructors(type))
            {
                type.Update(
                    attributes: [.. type.Attributes,
                        new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]);
                return type;
            }
            // If there is at least one constructor without experimental argument, just update experimental constructors.
            foreach (ConstructorProvider constructor in type.Constructors)
            {
                if (constructor.Signature.Parameters.Any(x => IsExperimental(x.Type)))
                {
                    constructor.Signature.Update(
                        attributes: [.. constructor.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                constructors.Add(constructor);
            }
            // Methods
            List<MethodProvider> methods = [];
            foreach (MethodProvider method in type.Methods)
            {
                if (method.Signature.Parameters.Any(x => IsExperimental(x.Type)) || IsExperimental(method.Signature.ReturnType))
                {
                    method.Signature.Update(
                        attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                methods.Add(method);
            }
            // Fields
            List<FieldProvider> fields = [];
            foreach (FieldProvider field in type.Fields)
            {
                if (IsExperimental(field.Type) || IsPropertyListed($"{type.Type.FullyQualifiedName}.{field.Name}"))
                {
                    field.Update(
                        attributes: [.. field.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                fields.Add(field);
            }
            List<PropertyProvider> properties = [];
            foreach (PropertyProvider property in type.Properties)
            {
                // Diagnostics code for troubleshooting.
                //if (string.Equals(type.Type.Name, "MCPToolboxTool"))//(string.Equals(property.Name, "RequireApproval"))
                //{
                //    throw new InvalidOperationException(
                //        $"================================================\n" +
                //        $"{GetRealName(type)}\n" +
                //        $"Property name: {property.Name}\n" +
                //        $"Property type: {property.Type.FullyQualifiedName}\n" +
                //        $"Property full name: {GetRealNameForProperty(property, typeRealName)}\n" +
                //        $"Is experimental {IsPropertyListed(GetRealNameForProperty(property, typeRealName))} \n" +
                //        $"Is of experimental type {IsExperimental(property.Type)}\n" +
                //        $"================================================\n");
                //}
                if (IsExperimental(property.Type) || IsPropertyListed($"{type.Type.FullyQualifiedName}.{property.Name}"))
                {
                    property.Update(
                        attributes: [.. property.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                    );
                    isDirty = true;
                }
                properties.Add(property);
            }
            if (isDirty)
            {
                type.Update(
                    constructors: constructors,
                    methods: methods,
                    fields: fields,
                    properties: properties
                );
                if (!supportsPreviewVariants)
                {
                    SuppressExperimentalImplementationReferences(type, DiagnosticId);
                }
                return type;
            }
            return base.VisitType(type);
        }

        protected override MethodProvider VisitMethod(MethodProvider method)
        {
            // Diagnostics code for troubleshooting.
            //if (string.Equals(method.Signature.Name, "CodeBasedEvaluatorDefinition"))
            //{
            //    throw new InvalidOperationException(
            //        $"================================================\n" +
            //        $"Is already experimental: {method.Signature.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute)))}\n" +
            //        $"Return type is experimental: {Listed(method.Signature.ReturnType?.FullyQualifiedName)}\n" +
            //        $"Parameters were previously marked as experimental (include renames): {method.Signature.Parameters.Any(x => _attributedTypes.Contains(x.Type.FullyQualifiedName))}\n" +
            //        $"Parameters are explicitly marked as experimental: {method.Signature.Parameters.Any(x => IsListed(x.Type.FullyQualifiedName))}\n" +
            //        $"{(method.Signature.Attributes[0].Arguments[0] as ScopedApi).Original}.\n" +
            //        $"================================================\n");
            //}
            // If the whole class was already marked as experimental, no need to mark methods.
            if (_attributedTypes.Contains(method.EnclosingType.Type.FullyQualifiedName))
            {
                return base.VisitMethod(method);
            }
            if (!method.Signature.Attributes.Any(attr => attr.Type.Equals(typeof(ExperimentalAttribute))) && (
                method.Signature.Parameters.Any(x => _attributedTypes.Contains(x.Type.FullyQualifiedName) || IsListed(x.Type.FullyQualifiedName))
                || _attributedTypes.Contains(method.Signature.ReturnType?.FullyQualifiedName)
                || IsListed(method.Signature.ReturnType?.FullyQualifiedName)))
            {
                method.Signature.Update(
                    attributes: [.. method.Signature.Attributes, new(typeof(ExperimentalAttribute), Snippet.Literal(DiagnosticId))]
                );
                return method;
            }
            return base.VisitMethod(method);
        }
    }
}