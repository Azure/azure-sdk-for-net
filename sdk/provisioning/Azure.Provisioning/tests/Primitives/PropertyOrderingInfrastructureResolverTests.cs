// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives;

public class PropertyOrderingInfrastructureResolverTests
{
    [Test]
    public async Task OrdersPropertiesRecursively()
    {
        await using Trycep test = new(orderProperties: true);

        test.Define(
            new TestResource("example")
            {
                Zulu = "last",
                Child = new TestModel
                {
                    Zulu = "last",
                    Alpha = "first",
                },
                Alpha = "first",
                Values =
                {
                    ["zulu"] = "last",
                    ["alpha"] = "first",
                },
                Models =
                {
                    new TestModel
                    {
                        Zulu = "last",
                        Alpha = "first",
                    }
                }
            })
            .Compare(
                """
                resource example 'Microsoft.Test/examples@2025-01-01' = {
                  alpha: 'first'
                  child: {
                    alpha: 'first'
                    zulu: 'last'
                  }
                  models: [
                    {
                      alpha: 'first'
                      zulu: 'last'
                    }
                  ]
                  values: {
                    alpha: 'first'
                    zulu: 'last'
                  }
                  zulu: 'last'
                }
                """);
    }

    private sealed class TestResource(string bicepIdentifier)
        : ProvisionableResource(
            bicepIdentifier,
            new ResourceType("Microsoft.Test/examples"),
            "2025-01-01")
    {
        public BicepValue<string> Zulu
        {
            get { Initialize(); return _zulu!; }
            set { Initialize(); _zulu!.Assign(value); }
        }
        private BicepValue<string>? _zulu;

        public TestModel Child
        {
            get { Initialize(); return _child!; }
            set { Initialize(); AssignOrReplace(ref _child, value); }
        }
        private TestModel? _child;

        public BicepValue<string> Alpha
        {
            get { Initialize(); return _alpha!; }
            set { Initialize(); _alpha!.Assign(value); }
        }
        private BicepValue<string>? _alpha;

        public BicepDictionary<string> Values
        {
            get { Initialize(); return _values!; }
            set { Initialize(); _values!.Assign(value); }
        }
        private BicepDictionary<string>? _values;

        public BicepList<TestModel> Models
        {
            get { Initialize(); return _models!; }
            set { Initialize(); _models!.Assign(value); }
        }
        private BicepList<TestModel>? _models;

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _zulu = DefineProperty<string>("Zulu", ["zulu"]);
            _child = DefineModelProperty<TestModel>("Child", ["child"]);
            _alpha = DefineProperty<string>("Alpha", ["alpha"]);
            _values = DefineDictionaryProperty<string>("Values", ["values"]);
            _models = DefineListProperty<TestModel>("Models", ["models"]);
        }
    }

    private sealed class TestModel : ProvisionableConstruct
    {
        public BicepValue<string> Zulu
        {
            get { Initialize(); return _zulu!; }
            set { Initialize(); _zulu!.Assign(value); }
        }
        private BicepValue<string>? _zulu;

        public BicepValue<string> Alpha
        {
            get { Initialize(); return _alpha!; }
            set { Initialize(); _alpha!.Assign(value); }
        }
        private BicepValue<string>? _alpha;

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _zulu = DefineProperty<string>("Zulu", ["zulu"]);
            _alpha = DefineProperty<string>("Alpha", ["alpha"]);
        }
    }
}
