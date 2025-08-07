// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.Collections.Generic;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models.BaseModels
{
    public partial class ListTests
    {
#nullable disable
        public class LocalContext : ModelReaderWriterContext
        {
            private static readonly Lazy<TestClientModelReaderWriterContext> s_libraryContext = new(() => new());
            private List_BaseModel_Builder _list_BaseModel_Builder;

            protected override bool TryGetTypeBuilderCore(Type type, out ModelReaderWriterTypeBuilder builder)
            {
                builder = type switch
                {
                    Type t when t == typeof(List<BaseModel>) => _list_BaseModel_Builder ??= new(),
                    _ => GetFromDependencies(type)
                };
                return builder is not null;
            }

            private ModelReaderWriterTypeBuilder GetFromDependencies(Type type)
            {
                if (s_libraryContext.Value.TryGetTypeBuilder(type, out ModelReaderWriterTypeBuilder builder))
                    return builder;
                return null;
            }

            private class List_BaseModel_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(List<BaseModel>);

                protected override Type ItemType => typeof(BaseModel);

                protected override object CreateInstance() => new List<BaseModel>();

                protected override void AddItem(object collection, object item)
                    => ((List<BaseModel>)collection).Add((BaseModel)item);
            }
        }
#nullable enable
    }
}
