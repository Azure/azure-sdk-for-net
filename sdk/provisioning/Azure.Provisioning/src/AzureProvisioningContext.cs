// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning;

/// <summary>
/// Context class used by <see cref="ModelReaderWriter"/> to read and write provisioning models in an AOT compatible way.
/// </summary>
[ModelReaderWriterBuildable(typeof(Infrastructure))]
[ModelReaderWriterBuildable(typeof(BicepExpression))]
[ModelReaderWriterBuildable(typeof(BicepStatement))]
public partial class AzureProvisioningContext : ModelReaderWriterContext
{
}
