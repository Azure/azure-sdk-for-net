// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.SourceGeneration.Tests
{
    internal class ModelReaderWriterInvocations
    {
        public void Invoke()
        {
            object dict = new Dictionary<string, AvailabilitySetData>();
            ModelReaderWriter.Read<List<AvailabilitySetData>>(BinaryData.Empty, ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Write(dict, ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Read<AvailabilitySetData[]>(BinaryData.Empty, ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Write<List<List<AvailabilitySetData>>>([], ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Read<AvailabilitySetData[][]>(BinaryData.Empty, ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Read<AvailabilitySetData[,]>(BinaryData.Empty, ModelReaderWriterOptions.Json, BasicContext.Default);
            ModelReaderWriter.Read(BinaryData.Empty, typeof(ReadOnlyMemory<AvailabilitySetData>), ModelReaderWriterOptions.Json, BasicContext.Default);
        }
    }
}
