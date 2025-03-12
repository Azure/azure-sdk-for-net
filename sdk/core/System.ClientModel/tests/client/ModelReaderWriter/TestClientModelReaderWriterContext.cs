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

        public override bool TryGetModelBuilder(Type type, [NotNullWhen(true)] out ModelBuilder? modelInfo)
        {
            modelInfo = type switch
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
            return modelInfo is not null;
        }

        private class ModelY_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new ModelY();
        }

        private class UnknownBaseModel_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new UnknownBaseModel();
        }

        private class ResourceProviderData_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new ResourceProviderData();
        }

        private class ModelX_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new ModelX();
        }

        private class ModelWithPersistableOnly_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new ModelWithPersistableOnly();
        }

        private class ModelAsStruct_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new ModelAsStruct();
        }

        private class BaseModel_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new UnknownBaseModel();
        }

        private class AvailabilitySetData_Builder : ModelBuilder
        {
            private Func<object>? _createInstance;
            protected override Func<object> CreateInstance => _createInstance ??= () => new AvailabilitySetData();
        }
    }
}
