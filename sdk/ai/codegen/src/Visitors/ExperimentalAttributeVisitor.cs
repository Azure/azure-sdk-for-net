// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
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
using System.Text.RegularExpressions;

namespace Extensions.Plugin.Visitors
{
    /// <summary>
    /// A visitor that adds <see cref="ExperimentalAttribute"/> to generated public types that are not
    /// present in the stable-types baseline. This ensures that newly introduced generated types are
    /// automatically tagged as experimental until explicitly promoted.
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

        private readonly HashSet<string> _attributedTypes = new(StringComparer.Ordinal);

        // Maps a model's fully qualified name to its experimental members. Each entry maps the member
        // name to the simple name of the experimental type that makes it experimental. Generated
        // serialization statements that reference these members must have an inline AAIP001
        // suppression emitted at the tightest possible scope.
        private readonly Dictionary<string, Dictionary<string, string>> _experimentalMembersByModel = new(StringComparer.Ordinal);

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

        private static bool HasExperimentalDecorator(IEnumerable<InputDecoratorInfo> decorators) => decorators
                .Where(x => string.Equals(x.Name, "TypeSpec.OpenAPI.@extension"))
                .Where(x => x.Arguments.ContainsKey("key"))
                .Select(x => x.Arguments["key"])
                .Where(x => x.ToString().Contains("x-ms-foundry-meta"))
                .Any();

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
            bool hasExperimental = HasExperimentalDecorator(modelType.Decorators);
            if (hasExperimental)
            {
                _experimentalClasses.Add(type.Type.FullyQualifiedName);
            }
            return base.PreVisitModel(modelType, type);
        }

        protected override EnumProvider PreVisitEnum(InputEnumType enumType, EnumProvider type)
        {
            if (HasExperimentalDecorator(enumType.Decorators))
            {
                _experimentalClasses.Add(type.Type.FullyQualifiedName);
            }
            return base.PreVisitEnum(enumType, type);
        }

        protected override PropertyProvider PreVisitProperty(InputProperty property, PropertyProvider propertyProvider)
        {
            string fixedPropertyName = ToCapitalizedCamelCase(property.Name);
            if (HasExperimentalDecorator(property.Decorators))
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
            bool isDirty = false;
            // Collects the experimental properties/fields declared on this type, mapping each member
            // name to the simple name of the experimental type that makes it experimental. Generated
            // serialization statements that reference these members later have an inline AAIP001
            // suppression emitted at the tightest possible scope (see the statement visitors below).
            Dictionary<string, string> experimentalMembers = new(StringComparer.Ordinal);
            // Constructors
            List<ConstructorProvider> constructors = [];
            // In a first run we will check if all the constructors are experimental and if it is the case, mark class experimental.
            if (type.Constructors.Count > 0 && type.Constructors.All(x => x.Signature.Parameters.Any(x => IsExperimental(x.Type))))
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
                    experimentalMembers[field.Name] = field.Type.Name;
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
                    experimentalMembers[property.Name] = property.Type.Name;
                }
                properties.Add(property);
            }
            // Even when the type itself is not experimental, its generated serialization code may
            // reference experimental members (its own experimental properties/fields, or the
            // experimental subtypes of a discriminated base). Record the experimental members so that
            // the statement visitors below can emit inline #pragma warning disable directives around
            // the individual serialization statements that reference them, keeping the whole type
            // opt-in-free while external consumers still receive the diagnostic.
            if (experimentalMembers.Count > 0)
            {
                _experimentalMembersByModel[type.Type.FullyQualifiedName] = experimentalMembers;
            }
            if (isDirty)
            {
                type.Update(
                    constructors: constructors,
                    methods: methods,
                    fields: fields,
                    properties: properties
                );
                return type;
            }
            return base.VisitType(type);
        }

        /// <inheritdoc />
        protected override MethodBodyStatement VisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
        {
            if (TryGetExperimentalMembers(method, out Dictionary<string, string> members)
                && ReferencesExperimental(statement.ToDisplayString(), members, out string experimentalType))
            {
                return CreateExperimentalSuppression(statement, experimentalType);
            }
            return base.VisitExpressionStatement(statement, method);
        }

        /// <inheritdoc />
        protected override MethodBodyStatement VisitIfStatement(IfStatement statement, MethodProvider method)
        {
            // When the condition itself references an experimental member, the whole if-statement is
            // the tightest scope that can be suppressed. Otherwise recurse so that only the individual
            // statements inside the body that reference experimental members are suppressed.
            if (TryGetExperimentalMembers(method, out Dictionary<string, string> members)
                && ReferencesExperimental(new ExpressionStatement(statement.Condition).ToDisplayString(), members, out string experimentalType))
            {
                return CreateExperimentalSuppression(statement, experimentalType);
            }
            return base.VisitIfStatement(statement, method);
        }

        /// <inheritdoc />
        protected override MethodBodyStatement VisitSwitchStatement(SwitchStatement statement, MethodProvider method)
        {
            // As with if-statements, only wrap the whole switch when the value being switched on
            // references an experimental member; otherwise recurse into the individual cases.
            if (TryGetExperimentalMembers(method, out Dictionary<string, string> members)
                && ReferencesExperimental(new ExpressionStatement(statement.MatchExpression).ToDisplayString(), members, out string experimentalType))
            {
                return CreateExperimentalSuppression(statement, experimentalType);
            }
            return base.VisitSwitchStatement(statement, method);
        }

        /// <summary>
        /// Determines the experimental members visible from the supplied serialization method, mapping
        /// each member name to the simple name of the experimental type that makes it experimental.
        /// Returns <see langword="false"/> when the method is not part of a model's generated
        /// serialization code, or when the model itself is experimental (in which case its generated
        /// members already live in an experimental context and require no inline suppression).
        /// </summary>
        private bool TryGetExperimentalMembers(MethodProvider method, out Dictionary<string, string> members)
        {
            members = null;
            if (method.EnclosingType is not MrwSerializationTypeDefinition serialization)
            {
                return false;
            }
            // The serialization type definition is a partial of the model, so its Type is the model
            // type. When the model itself is experimental its generated members already live in an
            // experimental context and require no inline suppression.
            CSharpType modelType = serialization.Type;
            if (IsExperimental(modelType))
            {
                return false;
            }
            // members may remain null when the model has no experimental members of its own; callers
            // still need to check for experimental type references (e.g. discriminated base deserializers).
            _experimentalMembersByModel.TryGetValue(modelType.FullyQualifiedName, out members);
            return true;
        }

        /// <summary>
        /// Returns true if the supplied rendered statement text references an experimental type (by its
        /// fully qualified name) or an experimental member of the enclosing model (by name), reporting
        /// the simple name of the experimental type responsible.
        /// </summary>
        private bool ReferencesExperimental(string text, Dictionary<string, string> members, out string experimentalType)
        {
            if (ReferencesExperimentalType(text, out experimentalType))
            {
                return true;
            }
            return ReferencesExperimentalMember(text, members, out experimentalType);
        }

        private bool ReferencesExperimentalType(string text, out string experimentalType)
        {
            foreach (string fullyQualifiedName in _experimentalClasses)
            {
                if (text.Contains(fullyQualifiedName, StringComparison.Ordinal))
                {
                    experimentalType = SimpleName(fullyQualifiedName);
                    return true;
                }
            }
            foreach (string fullyQualifiedName in _attributedTypes)
            {
                if (text.Contains(fullyQualifiedName, StringComparison.Ordinal))
                {
                    experimentalType = SimpleName(fullyQualifiedName);
                    return true;
                }
            }
            experimentalType = null;
            return false;
        }

        private static bool ReferencesExperimentalMember(string text, Dictionary<string, string> members, out string experimentalType)
        {
            if (members != null)
            {
                foreach (KeyValuePair<string, string> member in members)
                {
                    // Match the member name as a whole identifier so that, for example, "Draft" does not
                    // match "DraftCount" and "Name" does not match "WritePropertyName".
                    if (GetMemberRegex(member.Key).IsMatch(text))
                    {
                        experimentalType = member.Value;
                        return true;
                    }
                }
            }
            experimentalType = null;
            return false;
        }

        private static readonly Dictionary<string, Regex> _memberRegexCache = new(StringComparer.Ordinal);

        private static Regex GetMemberRegex(string member)
        {
            if (!_memberRegexCache.TryGetValue(member, out Regex regex))
            {
                regex = new Regex($@"(?<![A-Za-z0-9_]){Regex.Escape(member)}(?![A-Za-z0-9_])", RegexOptions.CultureInvariant);
                _memberRegexCache[member] = regex;
            }
            return regex;
        }

        private static string SimpleName(string fullyQualifiedName)
        {
            int lastDot = fullyQualifiedName.LastIndexOf('.');
            return lastDot < 0 ? fullyQualifiedName : fullyQualifiedName[(lastDot + 1)..];
        }

        private static SuppressionStatement CreateExperimentalSuppression(MethodBodyStatement inner, string experimentalType) =>
            new(inner, Snippet.Literal(DiagnosticId), $"`{experimentalType}` is experimental and may change in future versions");

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