// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    public class TestClientModelReaderWriterContext : ModelReaderWriterContext
    {
        private AvailabilitySetData_Info? _availabilitySetData_Info;
        private BaseModel_Info? _baseModel_Info;
        private ModelAsStruct_Info? _modelAsStruct_Info;
        private ModelWithPersistableOnly_Info? _modelWithPersistableOnly_Info;
        private ModelX_Info? _modelX_Info;
        private ResourceProviderData_Info? _resourceProviderData_Info;
        private UnknownBaseModel_Info? _unknownBaseModel_Info;

        public override ModelInfo? GetModelInfo(Type type)
        {
            return type switch
            {
                Type t when t == typeof(AvailabilitySetData) => _availabilitySetData_Info ??= new(),
                Type t when t == typeof(BaseModel) => _baseModel_Info ??= new(),
                Type t when t == typeof(ModelAsStruct) => _modelAsStruct_Info ??= new(),
                Type t when t == typeof(ModelWithPersistableOnly) => _modelWithPersistableOnly_Info ??= new(),
                Type t when t == typeof(ModelX) => _modelX_Info ??= new(),
                Type t when t == typeof(ResourceProviderData) => _resourceProviderData_Info ??= new(),
                Type t when t == typeof(UnknownBaseModel) => _unknownBaseModel_Info ??= new(),
                _ => null
            };
        }

        private class UnknownBaseModel_Info : ModelInfo
        {
            public override object CreateObject() => new UnknownBaseModel();
        }

        private class ResourceProviderData_Info : ModelInfo
        {
            public override object CreateObject() => new ResourceProviderData();
        }

        private class ModelX_Info : ModelInfo
        {
            public override object CreateObject() => new ModelX();
        }

        private class ModelWithPersistableOnly_Info : ModelInfo
        {
            public override object CreateObject() => new ModelWithPersistableOnly();
        }

        private class ModelAsStruct_Info : ModelInfo
        {
            public override object CreateObject() => new ModelAsStruct();
        }

        private class BaseModel_Info : ModelInfo
        {
            public override object CreateObject() => new UnknownBaseModel();
        }

        private class AvailabilitySetData_Info : ModelInfo
        {
            public override object CreateObject() => new AvailabilitySetData();
        }
    }
}
