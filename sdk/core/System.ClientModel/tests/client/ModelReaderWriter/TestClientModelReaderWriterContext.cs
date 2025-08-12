// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.ClientModel.Tests.ModelReaderWriterTests;

[assembly: ModelReaderWriterContextType(typeof(TestClientModelReaderWriterContext))]

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestClientModelReaderWriterContext : ModelReaderWriterContext
    {
        private static TestClientModelReaderWriterContext? _default;
        public static TestClientModelReaderWriterContext Default => _default ??= new TestClientModelReaderWriterContext();

        private AvailabilitySetData_Builder? _availabilitySetData_Builder;
        private BaseModel_Builder? _baseModel_Builder;
        private ModelAsStruct_Builder? _modelAsStruct_Builder;
        private ModelWithPersistableOnly_Builder? _modelWithPersistableOnly_Builder;
        private ModelX_Builder? _modelX_Builder;
        private ResourceProviderData_Builder? _resourceProviderData_Builder;
        private UnknownBaseModel_Builder? _unknownBaseModel_Builder;
        private ModelY_Builder? _modelY_Builder;
        private ExperimentalModel_Builder? _experimentalModel_Builder;

        protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder? builder)
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
                #pragma warning disable TEST001
                Type t when t == typeof(ExperimentalModel) => _experimentalModel_Builder ??= new ExperimentalModel_Builder(),
                #pragma warning restore TEST001
                _ => null
            };
            return builder is not null;
        }

        private class ModelY_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ModelY);

            protected override object CreateInstance() => new ModelY();
        }

        private class UnknownBaseModel_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(UnknownBaseModel);

            protected override object CreateInstance() => new UnknownBaseModel();
        }

        private class ResourceProviderData_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ResourceProviderData);

            protected override object CreateInstance() => new ResourceProviderData();
        }

        private class ModelX_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ModelX);

            protected override object CreateInstance() => new ModelX();
        }

        private class ModelWithPersistableOnly_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ModelWithPersistableOnly);

            protected override object CreateInstance() => new ModelWithPersistableOnly();
        }

        private class ModelAsStruct_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ModelAsStruct);

            protected override object CreateInstance() => new ModelAsStruct();
        }

        private class BaseModel_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(BaseModel);

            protected override object CreateInstance() => new UnknownBaseModel();
        }

        private class AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(AvailabilitySetData);

            protected override object CreateInstance() => new AvailabilitySetData();
        }

#pragma warning disable TEST001
        private class ExperimentalModel_Builder : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(ExperimentalModel);

            protected override object CreateInstance() => new ExperimentalModel();
        }
#pragma warning restore TEST001
    }
}
