// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Providers;
using System;

namespace Azure.Generator.Providers
{
    internal class SystemObjectProvider : TypeProvider
    {
        private readonly Type _type;
        private const string InitializationCtorAttributeName = "InitializationConstructorAttribute";
        private const string SerializationCtorAttributeName = "SerializationConstructorAttribute";

        public SystemObjectProvider(Type type) : base()
        {
            _type = type;
        }

        protected override string BuildName() => _type.Name;

        protected override string BuildRelativeFilePath() => throw new InvalidOperationException("This type should not be writing in generation");

        protected override ConstructorProvider[] BuildConstructors()
        {
            // TODO: get initialization constructor and serialization constructor
            return base.BuildConstructors();
        }
    }
}
