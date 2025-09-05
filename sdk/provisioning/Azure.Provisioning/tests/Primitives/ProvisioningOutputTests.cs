// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives;

public class ProvisioningOutputTests
{
    [Test]
    public async Task ArrayOutput()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                Infrastructure infra = new();
                ProvisioningParameter ips = new(nameof(ips), typeof(string))
                {
                    Description = "Comma-separated list of IPs, e.g. \"1.2.3.4/32,10.0.0.0/24\"",
                    Value = "",
                };
                infra.Add(ips);
                ProvisioningVariable ipArray = new(nameof(ipArray), typeof(string[]))
                {
                    Value = new FunctionCallExpression(new IdentifierExpression("split"), new IdentifierExpression(ips.BicepIdentifier), ",")
                };
                infra.Add(ipArray);
                ProvisioningOutput result = new(nameof(result), typeof(string[]))
                {
                    Value = new IdentifierExpression(ipArray.BicepIdentifier)
                };
                infra.Add(result);
                return infra;
            })
        .Compare(
            """
            @description('Comma-separated list of IPs, e.g. "1.2.3.4/32,10.0.0.0/24"')
            param ips string = ''

            var ipArray = split(ips, ',')

            output result array = ipArray
            """);
    }

    [Test]
    public async Task DictionaryOutput()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                Infrastructure infra = new();
                ProvisioningParameter tags = new(nameof(tags), typeof(object))
                {
                    Value = new BicepDictionary<string>()
                    {
                        ["env"] = "prod",
                        ["dept"] = "finance",
                    },
                };
                infra.Add(tags);
                ProvisioningOutput result = new(nameof(result), typeof(Dictionary<string, string>))
                {
                    Value = new IdentifierExpression(tags.BicepIdentifier)
                };
                infra.Add(result);
                return infra;
            })
        .Compare(
            """
            param tags object = {
              env: 'prod'
              dept: 'finance'
            }

            output result object = tags
            """);
    }
}
