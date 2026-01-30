// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that renames "maxpagesize" parameter to "maxPageSize" in ScmMethodProvider parameters.
    /// </summary>
    internal class MaxPageSizeParameterVisitor : ScmLibraryVisitor
    {
        private const string MaxPageSizeWireName = "maxpagesize";
        private const string MaxPageSizeCamelCaseName = "maxPageSize";

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            // Find if the service method has a maxpagesize parameter
            var hasMaxPageSizeParameter = serviceMethod.Parameters.Any(p =>
                p.SerializedName.Equals(MaxPageSizeWireName, System.StringComparison.OrdinalIgnoreCase));

            var hasMaxPageSizeOperationParameter = serviceMethod.Operation.Parameters.Any(p =>
                p.SerializedName.Equals(MaxPageSizeWireName, System.StringComparison.OrdinalIgnoreCase));

            if (hasMaxPageSizeParameter || hasMaxPageSizeOperationParameter)
            {
                // Update the service method parameters
                if (hasMaxPageSizeParameter)
                {
                    var updatedParameters = serviceMethod.Parameters.Select(p =>
                    {
                        if (p.SerializedName.Equals(MaxPageSizeWireName, System.StringComparison.OrdinalIgnoreCase))
                        {
                            // Create a new parameter with the updated name
                            return new InputMethodParameter(
                                name: MaxPageSizeCamelCaseName,
                                summary: p.Summary,
                                doc: p.Doc,
                                type: p.Type,
                                location: p.Location,
                                isRequired: p.IsRequired,
                                isReadOnly: p.IsReadOnly,
                                isApiVersion: p.IsApiVersion,
                                defaultValue: p.DefaultValue,
                                serializedName: p.SerializedName,
                                scope: p.Scope,
                                access: null);
                        }
                        return p;
                    }).ToArray();

                    serviceMethod.Update(parameters: updatedParameters);
                }

                // Update the operation parameters
                if (hasMaxPageSizeOperationParameter)
                {
                    var updatedOperationParameters = serviceMethod.Operation.Parameters.Select(p =>
                    {
                        if (p.SerializedName.Equals(MaxPageSizeWireName, System.StringComparison.OrdinalIgnoreCase) && p is InputQueryParameter queryParam)
                        {
                            // Create a new parameter with the updated name
                            return new InputQueryParameter(
                                name: MaxPageSizeCamelCaseName,
                                summary: queryParam.Summary,
                                doc: queryParam.Doc,
                                type: queryParam.Type,
                                isRequired: queryParam.IsRequired,
                                isReadOnly: queryParam.IsReadOnly,
                                isApiVersion: queryParam.IsApiVersion,
                                defaultValue: queryParam.DefaultValue,
                                serializedName: queryParam.SerializedName,
                                arraySerializationDelimiter: null,
                                scope: queryParam.Scope,
                                access: null,
                                collectionFormat: null,
                                explode: queryParam.Explode);
                        }
                        return p;
                    }).ToArray();

                    serviceMethod.Operation.Update(parameters: updatedOperationParameters);
                }
            }

            return methods;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            // Reset the collection definition if it exists so any changes are properly reflected
            if (type is CollectionResultDefinition)
            {
                type.Reset();
            }

            return base.VisitType(type);
        }
    }
}
