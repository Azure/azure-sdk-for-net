// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Mgmt.Models;
using Microsoft.Generator.CSharp.Input;
using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal class ResourceDetection
    {
        private const string ProvidersSegment = "/providers/";
        private ConcurrentDictionary<string, (string Name, InputModelType? InputModel)?> _resourceDataSchemaCache = new ConcurrentDictionary<string, (string Name, InputModelType? InputModel)?>();

        private static InputModelType? FindObjectSchemaWithName(string name)
            => AzureClientPlugin.Instance.InputLibrary.InputNamespace.Models.OfType<InputModelType>().FirstOrDefault(inputModel => inputModel.Name == name);

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

        private static bool CheckEvenSegments(string requestPath)
        {
            var index = requestPath.LastIndexOf(ProvidersSegment);
            // this request path does not have providers segment - it can be a "ById" request, skip to next criteria
            if (index < 0)
                return true;
            // get whatever following the providers
            var following = requestPath.Substring(index);
            var segments = following.Split("/", StringSplitOptions.RemoveEmptyEntries);
            return segments.Length % 2 == 0;
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

                switch (property.SerializedName)
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
