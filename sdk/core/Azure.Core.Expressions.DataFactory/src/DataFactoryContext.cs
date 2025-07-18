// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.Core.Expressions.DataFactory
{
    /// <summary>
    /// Context class used by <see cref="ModelReaderWriter"/> to read and write models in an AOT compatible way.
    /// </summary>
    [ModelReaderWriterBuildable(typeof(DataFactorySecretString))]
    [ModelReaderWriterBuildable(typeof(DataFactoryKeyVaultSecret))]
    [ModelReaderWriterBuildable(typeof(DataFactoryLinkedServiceReference))]
    [ModelReaderWriterBuildable(typeof(DataFactorySecret))]
    [ModelReaderWriterBuildable(typeof(UnknownSecret))]
    public partial class DataFactoryContext : ModelReaderWriterContext
    {
    }
}
