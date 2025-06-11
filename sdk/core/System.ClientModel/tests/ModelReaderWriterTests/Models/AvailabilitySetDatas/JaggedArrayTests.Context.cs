// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public partial class JaggedArrayTests
    {
#nullable disable
        private class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ArrayTests.LocalContext> s_availabilitySetData_ArrayTests_LocalContext = new(() => new());

            private Array_Array_AvailabilitySetData_Builder _array_Array_AvailabilitySetData_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(AvailabilitySetData[][]) => _array_Array_AvailabilitySetData_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_ArrayTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class Array_Array_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<AvailabilitySetData[]>);

                protected override Type ItemType => typeof(AvailabilitySetData[]);

                protected override object CreateInstance() => new List<AvailabilitySetData[]>();

                protected override void AddItem(object collection, object item)
                    => ((List<AvailabilitySetData[]>)collection).Add((AvailabilitySetData[])item);

                protected override object ConvertCollectionBuilder(object builder)
                    => ((List<AvailabilitySetData[]>)builder).ToArray();
            }
        }
#nullable enable
    }
}
