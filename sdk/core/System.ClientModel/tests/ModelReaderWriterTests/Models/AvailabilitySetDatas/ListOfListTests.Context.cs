// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.AvailabilitySetDatas
{
    public partial class ListOfListTests
    {
#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private static readonly Lazy<ListTests.LocalContext> s_availabilitySetData_ListTests_LocalContext = new(() => new());

            private List_List_AvailabilitySetData_Builder _list_list_AvailabilitySet_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<List<AvailabilitySetData>>) => _list_list_AvailabilitySet_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                if (s_availabilitySetData_ListTests_LocalContext.Value.TryGetTypeBuilder(type, out builder))
                    return builder;
                return null;
            }

            private class List_List_AvailabilitySetData_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<List<AvailabilitySetData>>);

                protected override Type ItemType => typeof(List<AvailabilitySetData>);

                protected override object CreateInstance() => new List<List<AvailabilitySetData>>();

                protected override void AddItem(object collection, object item)
                    => ((List<List<AvailabilitySetData>>)collection).Add((List<AvailabilitySetData>)item);
            }
        }
#nullable enable
    }
}
