// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Provisioning-specific view over one or more compatible management resource
    /// metadata entries that should emit as one provisioning resource type.
    /// </summary>
    internal sealed class ProvisioningResourceProjection
    {
        internal ProvisioningResourceProjection(
            InputModelType resourceModel,
            string resourceName,
            string resourceType,
            string? singletonResourceName,
            RequestPathPattern? parentResourceId,
            ArmResourceNameConstraints nameConstraints,
            IReadOnlyList<RequestPathPattern> resourceIdPatterns,
            IReadOnlyList<string> apiVersions,
            IReadOnlyList<ResourceMethod> methods,
            IReadOnlyList<ArmResourceRbacRole> rbacRoles,
            IReadOnlyList<ResourceScope> readableScopes,
            IReadOnlyList<ResourceScope> writableScopes,
            bool isExtensionResource)
        {
            ResourceModel = resourceModel;
            ResourceName = resourceName;
            ResourceType = resourceType;
            SingletonResourceName = singletonResourceName;
            ParentResourceId = parentResourceId;
            NameConstraints = nameConstraints;
            ResourceIdPatterns = resourceIdPatterns;
            ApiVersions = apiVersions;
            Methods = methods;
            RbacRoles = rbacRoles;
            ReadableScopes = readableScopes;
            WritableScopes = writableScopes;
            IsExtensionResource = isExtensionResource;
        }

        /// <summary>
        /// Gets the resource body model shared by all collapsed metadata entries.
        /// </summary>
        internal InputModelType ResourceModel { get; }

        /// <summary>
        /// Gets the generated provisioning resource type name.
        /// </summary>
        internal string ResourceName { get; }

        /// <summary>
        /// Gets the concrete ARM resource type emitted in Bicep.
        /// </summary>
        internal string ResourceType { get; }

        /// <summary>
        /// Gets the fixed singleton resource name when all collapsed metadata
        /// entries agree on the same singleton name; otherwise null.
        /// </summary>
        internal string? SingletonResourceName { get; }

        /// <summary>
        /// Gets the detected structural parent resource ID pattern.
        /// </summary>
        internal RequestPathPattern? ParentResourceId { get; }

        /// <summary>
        /// Gets the resource name constraints when all collapsed metadata entries
        /// agree on the same constraints; otherwise conservative defaults.
        /// </summary>
        internal ArmResourceNameConstraints NameConstraints { get; }

        /// <summary>
        /// Gets all ARM resource ID patterns collapsed into this projection.
        /// </summary>
        internal IReadOnlyList<RequestPathPattern> ResourceIdPatterns { get; }

        /// <summary>
        /// Gets all API versions available across the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<string> ApiVersions { get; }

        /// <summary>
        /// Gets all resource methods from the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<ResourceMethod> Methods { get; }

        /// <summary>
        /// Gets all RBAC roles declared on the collapsed metadata entries.
        /// </summary>
        internal IReadOnlyList<ArmResourceRbacRole> RbacRoles { get; }

        /// <summary>
        /// Gets deployment scopes where the resource can be read.
        /// </summary>
        internal IReadOnlyList<ResourceScope> ReadableScopes { get; }

        /// <summary>
        /// Gets deployment scopes where the resource can be written.
        /// </summary>
        internal IReadOnlyList<ResourceScope> WritableScopes { get; }

        /// <summary>
        /// Gets whether this resource should be emitted as a Bicep extension
        /// resource with a language-level <c>scope</c> relationship.
        /// </summary>
        internal bool IsExtensionResource { get; }

        internal static ProvisioningResourceProjection Deserialize(
            JsonElement element,
            IReadOnlyDictionary<string, InputModelType> modelsById,
            IReadOnlyDictionary<string, ResourceMethod> methodsById)
        {
            var resourceModelId = GetRequiredString(element, "resourceModelId");
            if (!modelsById.TryGetValue(resourceModelId, out var resourceModel))
            {
                throw new JsonException($"Provisioning resource model '{resourceModelId}' was not found in the code model.");
            }

            var methods = new List<ResourceMethod>();
            foreach (var methodIdElement in element.GetProperty("methodIds").EnumerateArray())
            {
                var methodId = methodIdElement.GetString()
                    ?? throw new JsonException("A provisioning resource method ID cannot be null.");
                if (!methodsById.TryGetValue(methodId, out var method))
                {
                    throw new JsonException($"Provisioning resource method '{methodId}' was not found in the ARM provider schema.");
                }
                methods.Add(method);
            }

            var nameConstraintsElement = element.GetProperty("nameConstraints");
            var nameConstraints = new ArmResourceNameConstraints(
                GetOptionalString(nameConstraintsElement, "pattern"),
                GetOptionalInt32(nameConstraintsElement, "minLength"),
                GetOptionalInt32(nameConstraintsElement, "maxLength"));

            var rbacRoles = new List<ArmResourceRbacRole>();
            foreach (var roleElement in element.GetProperty("rbacRoles").EnumerateArray())
            {
                rbacRoles.Add(new ArmResourceRbacRole(
                    GetRequiredString(roleElement, "name"),
                    GetRequiredString(roleElement, "value")));
            }

            return new(
                resourceModel,
                GetRequiredString(element, "resourceName"),
                GetRequiredString(element, "resourceType"),
                GetOptionalString(element, "singletonResourceName"),
                GetOptionalString(element, "parentResourceId") is string parentResourceId
                    ? new RequestPathPattern(parentResourceId)
                    : null,
                nameConstraints,
                DeserializeRequestPaths(element.GetProperty("resourceIdPatterns")),
                DeserializeStrings(element.GetProperty("apiVersions")),
                methods,
                rbacRoles,
                DeserializeScopes(element.GetProperty("readableScopes")),
                DeserializeScopes(element.GetProperty("writableScopes")),
                element.GetProperty("isExtensionResource").GetBoolean());
        }

        private static IReadOnlyList<RequestPathPattern> DeserializeRequestPaths(JsonElement element)
        {
            var paths = new List<RequestPathPattern>();
            foreach (var item in element.EnumerateArray())
            {
                paths.Add(new RequestPathPattern(
                    item.GetString() ?? throw new JsonException("A provisioning resource path cannot be null.")));
            }
            return paths;
        }

        private static IReadOnlyList<string> DeserializeStrings(JsonElement element)
        {
            var values = new List<string>();
            foreach (var item in element.EnumerateArray())
            {
                values.Add(item.GetString() ?? throw new JsonException("A provisioning string value cannot be null."));
            }
            return values;
        }

        private static IReadOnlyList<ResourceScope> DeserializeScopes(JsonElement element)
        {
            var scopes = new List<ResourceScope>();
            foreach (var item in element.EnumerateArray())
            {
                var value = item.GetString() ?? throw new JsonException("A provisioning resource scope cannot be null.");
                if (!Enum.TryParse<ResourceScope>(value, out var scope))
                {
                    throw new JsonException($"Provisioning resource scope '{value}' is invalid.");
                }
                scopes.Add(scope);
            }
            return scopes;
        }

        private static string GetRequiredString(JsonElement element, string propertyName)
            => element.GetProperty(propertyName).GetString()
                ?? throw new JsonException($"Required provisioning property '{propertyName}' cannot be null.");

        private static string? GetOptionalString(JsonElement element, string propertyName)
            => element.TryGetProperty(propertyName, out var property) && property.ValueKind != JsonValueKind.Null
                ? property.GetString()
                : null;

        private static int? GetOptionalInt32(JsonElement element, string propertyName)
            => element.TryGetProperty(propertyName, out var property) && property.ValueKind != JsonValueKind.Null
                ? property.GetInt32()
                : null;
    }
}
