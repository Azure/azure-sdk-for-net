// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Management
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                TransformResource(model, type);
            }
            return type;
        }

        private void TransformResource(InputModelType model, TypeProvider type)
        {
            if (type is ModelProvider && ManagementClientGenerator.Instance.InputLibrary.IsResourceModel(model))
            {
                type.Update(
                    relativeFilePath: TransformRelativeFilePath(type),
                    name: TransformName(type));

                foreach (var serialization in type.SerializationProviders)
                {
                    serialization.Update(
                        relativeFilePath: TransformRelativeFilePathForSerialization(serialization),
                        name: TransformName(serialization));
                }
            }
        }

        // Because we have NamespaceVisitor with VisitType in Azure.Generater, we need to override the namespace with VisitType here
        protected override TypeProvider? VisitType(TypeProvider type)
        {
            if (type is not null)
            {
                TransformNamespaceForResource(type);
            }
            return type;
        }

        private void TransformNamespaceForResource(TypeProvider type)
        {
            if (type is ModelProvider model && ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(model.Type))
            {
                type.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);

                foreach (var serialization in type.SerializationProviders)
                {
                    serialization.Update(@namespace: ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace);
                }
            }
        }

        // TODO: Go back and enable this when we have a way to handle the resource model parameters renaming via VisitMethod.
        // protected override MethodProvider? VisitMethod(MethodProvider method)
        // {
        //     foreach (var parameter in method.Signature.Parameters)
        //     {
        //         if (ManagementClientGenerator.Instance.OutputLibrary.IsResourceModelType(parameter.Type))
        //         {
        //             parameter.Update("data");
        //         }
        //     }
        //     return base.VisitMethod(method);
        // }

        private static string TransformName(TypeProvider model) => $"{model.Name}Data";

        private static string TransformRelativeFilePath(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.cs");

        private static string TransformRelativeFilePathForSerialization(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.Serialization.cs");
    }
}
