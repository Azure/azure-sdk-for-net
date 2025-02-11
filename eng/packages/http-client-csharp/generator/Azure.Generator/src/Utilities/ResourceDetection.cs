// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Mgmt.Models;
using Microsoft.Generator.CSharp.Input;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Azure.Generator.Utilities
{
    internal class ResourceDetection
    {
        private const string ResourceGroupScopePrefix = "/subscriptions/{subscriptionId}/resourceGroups";
        private const string SubscriptionScopePrefix = "/subscriptions";
        private const string TenantScopePrefix = "/tenants";

        private ConcurrentDictionary<RequestPath, (string Name, InputModelType? InputModel)?> _resourceDataSchemaCache = new ConcurrentDictionary<RequestPath, (string Name, InputModelType? InputModel)?>();

        public bool IsResource(OperationSet set) => TryGetResourceDataSchema(set, out _, out _);

        public static string GetResourceTypeFromPath(RequestPath requestPath)
        {
            var index = requestPath.IndexOfLastProviders;
            if (index < 0)
            {
                if (requestPath.SerializedPath.StartsWith(ResourceGroupScopePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return "Microsoft.Resources/resourceGroups";
                }
                else if (requestPath.SerializedPath.StartsWith(SubscriptionScopePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return "Microsoft.Resources/subscriptions";
                }
                else if (requestPath.SerializedPath.StartsWith(TenantScopePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return "Microsoft.Resources/tenants";
                }
                throw new InvalidOperationException($"Cannot find resource type from path {requestPath}");
            }

            var left = new RequestPath(requestPath.SerializedPath.Substring(index+RequestPath.Providers.Length));
            var result = new StringBuilder(left[0]);
            for (int i = 1; i < left.Count; i += 2)
            {
                result.Append($"/{left[i]}");
            }
            return result.ToString();
        }

        public bool TryGetResourceDataSchema(OperationSet set, [MaybeNullWhen(false)] out string resourceSpecName, out InputModelType? inputModel)
        {
            resourceSpecName = null;
            inputModel = null;

            // get the result from cache
            if (_resourceDataSchemaCache.TryGetValue(set.RequestPath, out var resourceSchemaTuple))
            {
                resourceSpecName = resourceSchemaTuple is null ? null : resourceSchemaTuple?.Name!;
                inputModel = resourceSchemaTuple?.InputModel;
                return resourceSchemaTuple != null;
            }

            // TODO: try to find it in the partial resource list

            // Check if the request path has even number of segments after the providers segment
            if (!CheckEvenSegments(set.RequestPath))
                return false;

            // before we are finding any operations, we need to ensure this operation set has a GET request.
            if (set.FindOperation(RequestMethod.Get) is null)
                return false;

            // try put operation to get the resource name
            if (TryOperationWithMethod(set, RequestMethod.Put, out inputModel))
            {
                resourceSpecName = inputModel.Name;
                _resourceDataSchemaCache.TryAdd(set.RequestPath, (resourceSpecName, inputModel));
                return true;
            }

            // try get operation to get the resource name
            if (TryOperationWithMethod(set, RequestMethod.Get, out inputModel))
            {
                resourceSpecName = inputModel.Name;
                _resourceDataSchemaCache.TryAdd(set.RequestPath, (resourceSpecName, inputModel));
                return true;
            }

            // We tried everything, this is not a resource
            _resourceDataSchemaCache.TryAdd(set.RequestPath, null);
            return false;
        }

        private static bool CheckEvenSegments(RequestPath requestPath)
        {
            var index = requestPath.IndexOfLastProviders;
            // this request path does not have providers segment - it can be a "ById" request, skip to next criteria
            if (index < 0)
                return true;
            // get whatever following the providers
            var following = new RequestPath(requestPath.Take(index));
            return following.Count % 2 == 0;
        }

        private bool TryOperationWithMethod(OperationSet set, RequestMethod method, [MaybeNullWhen(false)] out InputModelType inputModel)
        {
            inputModel = null;

            var operation = set.FindOperation(method);
            if (operation is null)
                return false;
            // find the response with code 200
            var response = operation.GetServiceResponse();
            if (response is null)
                return false;
            // find the response schema
            var responseType = response.BodyType?.GetImplementType() as InputModelType;
            if (responseType is null)
                return false;

            // we need to verify this schema has ID, type and name so that this is a resource model
            if (!IsResourceModel(responseType))
                return false;

            inputModel = responseType;
            return true;
        }

        private static bool IsResourceModel(InputModelType inputModelType)
        {
            var allProperties = inputModelType.GetAllProperties();
            bool idPropertyFound = false;
            bool typePropertyFound = false;
            bool namePropertyFound = false;

            foreach (var property in allProperties)
            {
                if (FoundPropertiesForResource())
                {
                    return true;
                }

                switch (property.Name)
                {
                    case "id":
                        if (property.Type.GetImplementType() is InputPrimitiveType { Kind: InputPrimitiveTypeKind.String } inputPrimitiveType)
                            idPropertyFound = true;
                        continue;
                    case "type":
                        if (property.Type.GetImplementType() is InputPrimitiveType { Kind: InputPrimitiveTypeKind.String } inputPrimitive)
                            typePropertyFound = true;
                        continue;
                    case "name":
                        if (property.Type.GetImplementType() is InputPrimitiveType { Kind: InputPrimitiveTypeKind.String } primitive)
                            namePropertyFound = true;
                        continue;
                }
            }

            return FoundPropertiesForResource();

            bool FoundPropertiesForResource() => idPropertyFound && typePropertyFound && namePropertyFound;
        }
    }
}
