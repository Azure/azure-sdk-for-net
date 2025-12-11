// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Linq;
using System.Reflection;

namespace Azure.Generator.Visitors
{
    /// <summary>
    /// Visitor that renames "maxpagesize" parameter to "maxPageSize" in ScmMethodProvider parameters.
    /// </summary>
    internal class MaxPageSizeParameterVisitor : ScmLibraryVisitor
    {
        private const string MaxPageSizeSerializedName = "maxpagesize";
        private const string MaxPageSizeCamelCaseName = "maxPageSize";

        protected override ScmMethodProviderCollection? Visit(
            InputServiceMethod serviceMethod,
            ClientProvider client,
            ScmMethodProviderCollection? methods)
        {
            // Find if the service method has a maxpagesize parameter
            var hasMaxPageSizeParameter = serviceMethod.Parameters.Any(p =>
                p.SerializedName.Equals(MaxPageSizeSerializedName, System.StringComparison.OrdinalIgnoreCase)) ||
                serviceMethod.Operation.Parameters.Any(p =>
                p.SerializedName.Equals(MaxPageSizeSerializedName, System.StringComparison.OrdinalIgnoreCase));

            if (hasMaxPageSizeParameter)
            {
                // Update the parameter names using reflection since they are read-only
                UpdateParameterNames(serviceMethod.Parameters);
                UpdateParameterNames(serviceMethod.Operation.Parameters);

                // Create a new method collection with the updated service method
                methods = new ScmMethodProviderCollection(serviceMethod, client);

                // Reset the rest client so that its methods are rebuilt
                client.RestClient.Reset();
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

        private static void UpdateParameterNames(System.Collections.Generic.IReadOnlyList<InputMethodParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.SerializedName.Equals(MaxPageSizeSerializedName, System.StringComparison.OrdinalIgnoreCase))
                {
                    SetNameField(parameter, MaxPageSizeCamelCaseName);
                }
            }
        }

        private static void UpdateParameterNames(System.Collections.Generic.IReadOnlyList<InputParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.SerializedName.Equals(MaxPageSizeSerializedName, System.StringComparison.OrdinalIgnoreCase))
                {
                    SetNameField(parameter, MaxPageSizeCamelCaseName);
                }
            }
        }

        private static void SetNameField(object parameter, string newName)
        {
            // Use reflection to set the backing field for the Name property
            // Get all fields to find the right backing field
            var fields = parameter.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            
            // Try to find the Name backing field by common patterns
            var nameField = fields.FirstOrDefault(f => f.Name == "<Name>k__BackingField") ??
                           fields.FirstOrDefault(f => f.Name == "_name") ??
                           fields.FirstOrDefault(f => f.Name.ToLower().Contains("name"));
            
            if (nameField != null)
            {
                nameField.SetValue(parameter, newName);
            }
        }
    }
}
