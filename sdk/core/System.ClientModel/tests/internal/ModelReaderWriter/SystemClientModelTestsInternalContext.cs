// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    [ModelReaderWriterBuildable(typeof(int))]
    internal partial class SystemClientModelTestsInternalContext : ModelReaderWriterContext
    {
        partial void AddAdditionalFactories(Dictionary<Type, Func<ModelReaderWriterTypeBuilder>> factories)
        {
            factories.Add(typeof(JsonModelConverterTests.PersistableModel), () => new PersistableModelInfo());
        }

        private class PersistableModelInfo : ModelReaderWriterTypeBuilder
        {
            protected override Type BuilderType => typeof(JsonModelConverterTests.DoesNotImplementPersistableModel);

            protected override object CreateInstance() => new JsonModelConverterTests.DoesNotImplementPersistableModel();
        }
    }
}
