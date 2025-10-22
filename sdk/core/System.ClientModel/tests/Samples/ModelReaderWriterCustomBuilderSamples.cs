// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel.Tests.Samples.CustomBuilder
{
    internal class ModelReaderWriterCustomBuilderSamples
    {
        #region Snippet:ModelReaderWriterContext_CustomBuilder
        public partial class MyContext : ModelReaderWriterContext
        {
            partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
            {
                factories.Add(typeof(CustomCollection<MyPersistableModel>), () => new CustomCollection_MyType_Builder());
            }

            private class CustomCollection_MyType_Builder : ModelReaderWriterTypeBuilder
            {
                protected override Type BuilderType => typeof(CustomCollection<MyPersistableModel>);

                protected override Type ItemType => typeof(MyPersistableModel);

                protected override object CreateInstance() => new CustomCollection<MyPersistableModel>();

                protected override void AddItem(object collection, object? item)
                    => ((CustomCollection<MyPersistableModel>)collection).Add((MyPersistableModel)item!);
            }
        }
        #endregion

        private class CustomCollection<T> : List<T> { }

        public partial class MyContext : ModelReaderWriterContext
        {
            partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories);
        }

        private class MyPersistableModel : IPersistableModel<MyPersistableModel>
        {
            MyPersistableModel IPersistableModel<MyPersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            string IPersistableModel<MyPersistableModel>.GetFormatFromOptions(ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }

            BinaryData IPersistableModel<MyPersistableModel>.Write(ModelReaderWriterOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
