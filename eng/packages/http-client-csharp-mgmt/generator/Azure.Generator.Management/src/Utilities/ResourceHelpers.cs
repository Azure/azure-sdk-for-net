﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Runtime.CompilerServices;

namespace Azure.Generator.Management.Utilities
{
    internal static class ResourceHelpers
    {
        public static string GetClientDiagnosticsFieldName(string clientName)
        {
            var fieldName = GetClientDiagnosticsName(clientName).ToVariableName();

            return $"_{fieldName}";
        }

        public static string GetClientDiagnosticsPropertyName(string clientName)
        {
            var propertyName = GetClientDiagnosticsName(clientName).ToIdentifierName();
            return propertyName;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetClientDiagnosticsName(string clientName) => $"{clientName}ClientDiagnostics";

        public static string GetRestClientFieldName(string clientName)
        {
            var fieldName = GetRestClientName(clientName).ToVariableName();
            return $"_{fieldName}";
        }

        public static string GetRestClientPropertyName(string clientName)
        {
            var propertyName = GetRestClientName(clientName).ToIdentifierName();
            return propertyName;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetRestClientName(string clientName) => $"{clientName}RestClient";

        /// <summary>
        /// Gets the appropriate method name for a resource operation based on its kind.
        /// </summary>
        /// <param name="operationKind">The kind of resource operation.</param>
        /// <param name="isAsync">Whether this is an async method.</param>
        /// <returns>The method name to use, or null if no override is needed.</returns>
        public static string? GetOperationMethodName(ResourceOperationKind operationKind, bool isAsync)
        {
            return operationKind switch
            {
                ResourceOperationKind.Create => isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate",
                ResourceOperationKind.List => isAsync ? "GetAllAsync" : "GetAll",
                _ => null
            };
        }

        /// <summary>
        /// Determines if the given resource operation kind should also be treated as an LRO (Long-Running Operation).
        /// When this happens, an operation is not a true long-running operation at the REST API level,
        /// but it is modeled as an LRO in the SDK for consistency and to provide a uniform developer experience.
        /// Only Create and Delete operations are forced to be LROs for now.
        /// </summary>
        public static bool ShouldMakeLro(ResourceOperationKind operationKind)
        {
            return operationKind == ResourceOperationKind.Create
                || operationKind == ResourceOperationKind.Delete;
        }

        public static CSharpType GetArmCoreTypeFromScope(ResourceScope scope) => scope switch
        {
            ResourceScope.ResourceGroup => typeof(ResourceGroupResource),
            ResourceScope.Subscription => typeof(SubscriptionResource),
            ResourceScope.Tenant => typeof(TenantResource),
            ResourceScope.ManagementGroup => typeof(ManagementGroupResource),
            _ => throw new InvalidOperationException($"Unhandled scope {scope}"),
        };
    }
}
