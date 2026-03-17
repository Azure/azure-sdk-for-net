// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.Expressions.DataFactory;
using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.DataFactory;

namespace Azure.Provisioning.Generator.Specifications;

public class DataFactorySpecification() :
    Specification("DataFactory", typeof(DataFactoryExtensions), ignorePropertiesWithoutPath: true)
{
    protected override IReadOnlyList<Assembly> AdditionalAllowedAssemblies { get; } =
        [typeof(DataFactoryLinkedServiceReference).Assembly];

    protected internal override Type? ResolveExternalGenericType(Type armType)
    {
        // Unwrap DataFactoryElement<T> to T
        if (armType.IsGenericType && armType.GetGenericTypeDefinition() == typeof(DataFactoryElement<>))
            return armType.GetGenericArguments()[0];
        return null;
    }

    protected override void Customize()
    {
        // Rename to avoid namespace conflict
        CustomizeModel<DataFactoryResource>(m => m.Name = "DataFactoryService");

        // Naming requirements
        AddNameRequirements<DataFactoryResource>(min: 3, max: 63, lower: true, upper: true, digits: true, hyphen: true);
    }
}
