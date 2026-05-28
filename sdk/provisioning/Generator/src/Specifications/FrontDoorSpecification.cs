// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.FrontDoor;

namespace Azure.Provisioning.Generator.Specifications;

public class FrontDoorSpecification() :
    Specification("FrontDoor", typeof(FrontDoorExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
        CustomizeResource<FrontDoorResource>(r =>
        {
            r.Name = "FrontDoorResource";
        });
        AddNameRequirements<FrontDoorResource>(
            max: 64,
            min: 5,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorExperimentResource>(
            max: int.MaxValue,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: true,
            period: true,
            parens: true);
        AddNameRequirements<FrontDoorRulesEngineResource>(
            max: 90,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: false,
            period: false,
            parens: false);
        AddNameRequirements<FrontDoorNetworkExperimentProfileResource>(
            max: int.MaxValue,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: true,
            period: true,
            parens: true);
        AddNameRequirements<FrontDoorWebApplicationFirewallPolicyResource>(
            max: 128,
            min: 1,
            lower: true,
            upper: true,
            digits: true,
            hyphen: true,
            underscore: true,
            period: true,
            parens: true);
    }
}
