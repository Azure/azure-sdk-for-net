// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Logic;

namespace Azure.Provisioning.Generator.Specifications;

public class LogicSpecification() :
    Specification("Logic", typeof(LogicExtensions), serviceDirectory: "logic")
{
    protected override void Customize()
    { }
}
