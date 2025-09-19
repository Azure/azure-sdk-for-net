// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Runtime.Serialization;
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

    [Test]
    public async Task EnumOutput()
    {
        await using Trycep trycep = new();
        trycep.Define(
            ctx =>
            {
                Infrastructure infra = new();
                ProvisioningParameter standard = new(nameof(standard), typeof(TestSku))
                {
                    Value = TestSku.Standard,
                };
                infra.Add(standard);
                ProvisioningParameter premium = new(nameof(premium), typeof(TestSku))
                {
                    Value = TestSku.Premium,
                };
                infra.Add(premium);
                ProvisioningOutput standardResult = new(nameof(standardResult), typeof(TestSku))
                {
                    Value = new IdentifierExpression(standard.BicepIdentifier)
                };
                infra.Add(standardResult);
                ProvisioningOutput premiumResult = new(nameof(premiumResult), typeof(TestSku))
                {
                    Value = new IdentifierExpression(premium.BicepIdentifier)
                };
                infra.Add(premiumResult);
                return infra;
            })
        .Compare(
            """
            param standard string = 'Standard'

            param premium string = 'premium'

            output standardResult string = standard

            output premiumResult string = premium
            """);
    }

    /// <summary>
    /// This is an enum type mimicking one that we would see in the real provisioning library.
    /// </summary>
    private enum TestSku
    {
        Free,
        Standard,
        [DataMember(Name = "premium")]
        Premium
    }
}
