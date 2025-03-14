// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestClientModelReaderWriterContext : ModelReaderWriterContext
    {
        private AvailabilitySetData_Builder? _availabilitySetData_Builder;
        private BaseModel_Builder? _baseModel_Builder;
        private ModelAsStruct_Builder? _modelAsStruct_Builder;
        private ModelWithPersistableOnly_Builder? _modelWithPersistableOnly_Builder;
        private ModelX_Builder? _modelX_Builder;
        private ResourceProviderData_Builder? _resourceProviderData_Builder;
        private UnknownBaseModel_Builder? _unknownBaseModel_Builder;
        private ModelY_Builder? _modelY_Builder;

        public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? builder)
        {
            builder = type switch
            {
                Type t when t == typeof(AvailabilitySetData) => _availabilitySetData_Builder ??= new(),
                Type t when t == typeof(BaseModel) => _baseModel_Builder ??= new(),
                Type t when t == typeof(ModelAsStruct) => _modelAsStruct_Builder ??= new(),
                Type t when t == typeof(ModelWithPersistableOnly) => _modelWithPersistableOnly_Builder ??= new(),
                Type t when t == typeof(ModelX) => _modelX_Builder ??= new(),
                Type t when t == typeof(ResourceProviderData) => _resourceProviderData_Builder ??= new(),
                Type t when t == typeof(UnknownBaseModel) => _unknownBaseModel_Builder ??= new(),
                Type t when t == typeof(ModelY) => _modelY_Builder ??= new(),
                _ => null
            };
            return builder is not null;
        }

        private class ModelY_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new ModelY();
        }

        private class UnknownBaseModel_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new UnknownBaseModel();
        }

        private class ResourceProviderData_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new ResourceProviderData();
        }

        private class ModelX_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new ModelX();
        }

        private class ModelWithPersistableOnly_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new ModelWithPersistableOnly();
        }

        private class ModelAsStruct_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new ModelAsStruct();
        }

        private class BaseModel_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new UnknownBaseModel();
        }

        private class AvailabilitySetData_Builder : ModelBuilder
        {
            protected override object CreateInstance() => new AvailabilitySetData();
        }
    }
}
