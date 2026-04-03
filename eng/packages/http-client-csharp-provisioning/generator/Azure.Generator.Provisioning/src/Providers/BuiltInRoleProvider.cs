// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// Generates a readonly struct that defines built-in RBAC roles for a provisioning service.
    /// The struct follows the pattern of existing BuiltInRole types (e.g., StorageBuiltInRole)
    /// and aggregates roles from all resources in the service.
    /// </summary>
    internal class BuiltInRoleProvider : TypeProvider
    {
        private readonly string _serviceName;
        private readonly IReadOnlyList<(string Name, string Value)> _roles;

        private static readonly ValueExpression EditorNeverAttribute = new MemberExpression(
            Static(typeof(EditorBrowsableState)),
            nameof(EditorBrowsableState.Never));

        /// <summary>
        /// Creates a BuiltInRoleProvider if there are any RBAC roles across the given resources.
        /// Returns null if no roles are defined.
        /// </summary>
        internal static BuiltInRoleProvider? TryCreate(
            string serviceName,
            IEnumerable<ArmResourceMetadata> resources)
        {
            // Step 1: Collect all roles with sanitized names
            var allRoles = new List<(string Name, string Value)>();
            foreach (var resource in resources)
            {
                foreach (var role in resource.RbacRoles)
                {
                    allRoles.Add((Name: role.Name.ToIdentifierName(), Value: role.Value));
                }
            }

            if (allRoles.Count == 0)
                return null;

            // Step 2: Deduplicate by value (GUID). If two entries share the same GUID
            // but have different names, warn and keep the first one.
            var rolesByValue = new Dictionary<string, (string Name, string Value)>(StringComparer.OrdinalIgnoreCase);
            foreach (var role in allRoles)
            {
                if (rolesByValue.TryGetValue(role.Value, out var existing))
                {
                    if (!string.Equals(role.Name, existing.Name, StringComparison.Ordinal))
                    {
                        ProvisioningGenerator.Instance.Emitter.ReportDiagnostic(
                            "rbac-role-guid-conflict",
                            $"RBAC role GUID '{role.Value}' has conflicting names: '{existing.Name}' and '{role.Name}'. Using '{existing.Name}'.");
                    }
                }
                else
                {
                    rolesByValue.Add(role.Value, role);
                }
            }

            // Step 3: Deduplicate by name. If two entries share the same sanitized name
            // but have different GUIDs, this is an error — stop generation for this type.
            // Report all collisions so users can fix them all at once.
            var guidsByName = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal);
            foreach (var role in rolesByValue.Values)
            {
                if (!guidsByName.TryGetValue(role.Name, out var guids))
                {
                    guids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    guidsByName[role.Name] = guids;
                }
                guids.Add(role.Value);
            }

            bool hasNameCollision = false;
            foreach (var (name, guids) in guidsByName)
            {
                if (guids.Count > 1)
                {
                    hasNameCollision = true;
                    ProvisioningGenerator.Instance.Emitter.ReportDiagnostic(
                        "rbac-role-name-collision",
                        $"RBAC role name collision: '{name}' maps to different GUIDs [{string.Join(", ", guids.Select(g => $"'{g}'"))}]. Cannot generate BuiltInRole type.");
                }
            }

            if (hasNameCollision)
                return null;

            // Sort by name for deterministic output — take one entry per name from rolesByValue
            var sortedRoles = rolesByValue.Values
                .GroupBy(r => r.Name, StringComparer.Ordinal)
                .Select(g => g.First())
                .OrderBy(r => r.Name, StringComparer.Ordinal)
                .ToList();
            return new BuiltInRoleProvider(serviceName, sortedRoles);
        }

        private BuiltInRoleProvider(string serviceName, IReadOnlyList<(string Name, string Value)> roles)
        {
            _serviceName = serviceName;
            _roles = roles;
        }

        protected override string BuildName() => $"{_serviceName}BuiltInRole";

        protected override FormattableString BuildDescription()
            => $"Defines the built-in roles for {_serviceName} resources.";

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.ReadOnly | TypeSignatureModifiers.Struct;

        protected override CSharpType[] BuildImplements()
            => [new CSharpType(typeof(IEquatable<>)).MakeGenericType([Type])];

        protected override ConstructorProvider[] BuildConstructors()
        {
            var valueParam = new ParameterProvider("value", $"The ID value of the role.", typeof(string));
            var sig = new ConstructorSignature(
                Type,
                null,
                MethodSignatureModifiers.Public,
                [valueParam],
                null,
                null);

            MethodBodyStatement body = new MethodBodyStatement[]
            {
                new AssignmentExpression(
                    new MemberExpression(null, "_value"),
                    new BinaryOperatorExpression("??",
                        (ValueExpression)valueParam,
                        ThrowExpression(New.Instance(typeof(ArgumentNullException), [Nameof(valueParam)])))).Terminate()
            };

            return [new ConstructorProvider(sig, body, this)];
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();

            // Private _value field
            fields.Add(new FieldProvider(
                FieldModifiers.Private | FieldModifiers.ReadOnly,
                typeof(string),
                "_value",
                this));

            // For each role: an internal const string
            foreach (var role in _roles)
            {
                var constFieldName = $"{role.Name}Value";

                // internal const string XxxValue = "guid";
                fields.Add(new FieldProvider(
                    FieldModifiers.Internal | FieldModifiers.Const,
                    typeof(string),
                    constFieldName,
                    this,
                    initializationValue: Literal(role.Value)));
            }

            return [.. fields];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();

            foreach (var role in _roles)
            {
                var constFieldName = $"{role.Name}Value";

                properties.Add(new PropertyProvider(
                    null,
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    Type,
                    role.Name,
                    new ExpressionPropertyBody(New.Instance(Type, [new MemberExpression(null, constFieldName)])),
                    this));
            }

            return [.. properties];
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>();

            // GetBuiltInRoleName static method
            methods.Add(BuildGetBuiltInRoleNameMethod());

            // Equality operators and methods
            methods.Add(BuildEqualsOperator(true));
            methods.Add(BuildEqualsOperator(false));
            methods.Add(BuildImplicitStringOperator());
            methods.Add(BuildEqualsObjectMethod());
            methods.Add(BuildEqualsTypedMethod());
            methods.Add(BuildGetHashCodeMethod());
            methods.Add(BuildToStringMethod());

            return [.. methods];
        }

        private MethodProvider BuildGetBuiltInRoleNameMethod()
        {
            var valueParam = new ParameterProvider("value", $"The role value.", Type);

            var switchCases = new List<SwitchCaseExpression>();
            foreach (var role in _roles)
            {
                switchCases.Add(new SwitchCaseExpression(
                    new MemberExpression(null, $"{role.Name}Value"),
                    Nameof(new MemberExpression(null, role.Name))));
            }
            // Default case returns value._value
            switchCases.Add(SwitchCaseExpression.Default(
                new MemberExpression(valueParam, "_value")));

            var switchExpr = new SwitchExpression(
                new MemberExpression(valueParam, "_value"),
                [.. switchCases]);

            var sig = new MethodSignature(
                "GetBuiltInRoleName",
                $"Try to get the name of a built-in {_serviceName} role from its ID value.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                typeof(string),
                $"The name of the built-in {_serviceName} role if known, otherwise the ID will be returned.",
                [valueParam],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), [EditorNeverAttribute])]);

            return new MethodProvider(sig, switchExpr, this);
        }

        private MethodProvider BuildEqualsOperator(bool equals)
        {
            var left = new ParameterProvider("left", $"The first {Name} to compare.", Type);
            var right = new ParameterProvider("right", $"The second {Name} to compare.", Type);
            var opName = equals ? "==" : "!=";

            var sig = new MethodSignature(
                opName,
                $"Determines if two {Name} values are {(equals ? "the same" : "different")}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Operator,
                typeof(bool),
                $"True if <paramref name=\"left\"/> and <paramref name=\"right\"/> are {(equals ? "the same" : "different")}; otherwise, false.",
                [left, right]);

            ValueExpression leftExpr = left;
            ValueExpression rightExpr = right;
            ValueExpression body = equals
                ? leftExpr.Invoke("Equals", [rightExpr])
                : new UnaryOperatorExpression("!", leftExpr.Invoke("Equals", [rightExpr]), false);

            return new MethodProvider(sig, body, this);
        }

        private MethodProvider BuildImplicitStringOperator()
        {
            var valueParam = new ParameterProvider("value", $"The string value to convert.", typeof(string));

            var sig = new MethodSignature(
                "implicit operator",
                $"Converts a string to a {Name}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static | MethodSignatureModifiers.Implicit | MethodSignatureModifiers.Operator,
                Type,
                null,
                [valueParam]);

            return new MethodProvider(sig, New.Instance(Type, [(ValueExpression)valueParam]), this);
        }

        private MethodProvider BuildEqualsObjectMethod()
        {
            var objParam = new ParameterProvider("obj", $"The object to compare.", typeof(object));

            var sig = new MethodSignature(
                "Equals",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                typeof(bool),
                null,
                [objParam],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), [EditorNeverAttribute])]);

            // obj is XxxBuiltInRole other && Equals(other)
            ValueExpression objExpr = objParam;
            var isCheck = objExpr.Is(new DeclarationExpression(Type, "other", out var otherVar));
            var body = new BinaryOperatorExpression("&&",
                isCheck,
                This.Invoke("Equals", [otherVar]));

            return new MethodProvider(sig, body, this);
        }

        private MethodProvider BuildEqualsTypedMethod()
        {
            var otherParam = new ParameterProvider("other", $"The value to compare.", Type);

            var sig = new MethodSignature(
                "Equals",
                null,
                MethodSignatureModifiers.Public,
                typeof(bool),
                null,
                [otherParam]);

            // string.Equals(_value, other._value, StringComparison.Ordinal)
            var body = Static(typeof(string)).Invoke(
                "Equals",
                [
                    new MemberExpression(null, "_value"),
                    new MemberExpression(otherParam, "_value"),
                    new MemberExpression(Static(typeof(StringComparison)), nameof(StringComparison.Ordinal))
                ]);

            return new MethodProvider(sig, body, this);
        }

        private MethodProvider BuildGetHashCodeMethod()
        {
            var sig = new MethodSignature(
                "GetHashCode",
                $"Returns the hash code for this {Name}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                typeof(int),
                null,
                [],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), [EditorNeverAttribute])]);

            // _value?.GetHashCode() ?? 0
            var body = new BinaryOperatorExpression("??",
                new MemberExpression(null, "_value").NullConditional().Invoke("GetHashCode", []),
                Literal(0));

            return new MethodProvider(sig, body, this);
        }

        private MethodProvider BuildToStringMethod()
        {
            var sig = new MethodSignature(
                "ToString",
                $"Returns the string representation of this {Name}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                typeof(string),
                null,
                []);

            return new MethodProvider(sig, new MemberExpression(null, "_value"), this);
        }
    }
}
