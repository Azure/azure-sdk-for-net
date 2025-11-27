// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Represents an existing type we're not going to generate, like System.String
/// or Azure.ETag.
/// </summary>
public class ExternalModel : ModelBase
{
    public ExternalModel(Type type) :
        base(
            name: type.Name,
            ns: type.Namespace,
            armType: type)
    {
        IsExternal = true;
    }

    public override string GetTypeReference() =>
        ArmType == typeof(object) ? "object" :
        ArmType == typeof(bool) ? "bool" :
        ArmType == typeof(int) ? "int" :
        ArmType == typeof(long) ? "long" :
        ArmType == typeof(float) ? "float" :
        ArmType == typeof(double) ? "double" :
        ArmType == typeof(string) ? "string" :
        base.GetTypeReference();

    public override void GenerateSchema(IndentWriter writer)
    {
        if (ArmType == typeof(bool))
        {
            writer.WriteLine("'boolean'");
        }
        else if (ArmType == typeof(int) || ArmType == typeof(long) || ArmType == typeof(float) || ArmType == typeof(double))
        {
            writer.WriteLine("'number'");
        }
        else if (ArmType == typeof(string))
        {
            writer.WriteLine("'string'");
        }
        else
        {
            writer.WriteLine("'object'");
        }
    }
}
