// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Context class used by <see cref="ModelReaderWriter"/> to read and write models in an AOT compatible way.
    /// </summary>
    [ModelReaderWriterBuildable(typeof(DataFactoryElement<>))]
    public partial class DataFactoryContext : ModelReaderWriterContext
    {
    }
}
