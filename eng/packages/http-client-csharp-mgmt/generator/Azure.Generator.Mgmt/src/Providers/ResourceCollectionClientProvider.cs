// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Providers
{
    internal class ResourceCollectionClientProvider : ResourceClientProvider
    {
        private ResourceClientProvider _resource;

        public ResourceCollectionClientProvider(InputClient inputClient, ResourceClientProvider resource) : base(inputClient)
        {
            _resource = resource;
        }

        protected override string BuildName() => $"{SpecName}Collection";

        protected override CSharpType[] BuildImplements() => [typeof(ArmCollection), new CSharpType(typeof(IEnumerable<>), _resource.Type), new CSharpType(typeof(IAsyncEnumerable<>), _resource.Type)];

        protected override PropertyProvider[] BuildProperties() => [];

        protected override FieldProvider[] BuildFields() => [_clientDiagonosticsField, _restClientField];

        protected override ConstructorProvider[] BuildConstructors()
            => [ConstructorProviderHelper.BuildMockingConstructor(this), BuildInitializationConstructor()];

        protected override ValueExpression ExpectedResourceTypeForValidation => Static(typeof(ResourceGroupResource)).Property("ResourceType");

        protected override ValueExpression ResourceTypeExpression => Static(_resource.Type).Property("ResourceType");

        // TODO: implement list/getall, get/exists methods
        protected override MethodProvider[] BuildMethods() => [BuildValidateResourceIdMethod()];
    }
}
