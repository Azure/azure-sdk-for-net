// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

public class ModuleImport : NamedProvisionableConstruct
{
    private readonly BicepValue<string> _name;
    public BicepValue<string> Name { get => _name; set => _name.Assign(value); }

    private readonly BicepValue<string> _path;
    public BicepValue<string> Path { get => _path; set => _path.Assign(value); }

    private readonly BicepValue<string> _scope;
    public BicepValue<string> Scope { get => _scope; set => _scope.Assign(value); }

    public BicepDictionary<object> Parameters { get; }

    public ModuleImport(string bicepIdentifier, BicepValue<string> path) : base(bicepIdentifier)
    {
        _name = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
        _path = DefineProperty<string>(nameof(Path), ["path"], defaultValue: path);
        _scope = DefineProperty<string>(nameof(Scope), ["scope"]);
        Parameters = DefineDictionaryProperty<object>(nameof(Parameters), ["params"]);
    }

    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        base.Validate(options);
        ValidateProperties();
    }

    protected internal override IEnumerable<BicepStatement> Compile()
    {
        List<BicepStatement> statements = [];
        Dictionary<string, BicepExpression> properties = new() { { "name", _name.Compile() } };
        if (((IBicepValue)_scope).Kind != BicepValueKind.Unset) { properties.Add("scope", _scope.Compile()); }
        if (Parameters.Count > 0) { properties.Add("params", Parameters.Compile()); }
        ModuleStatement module = BicepSyntax.Declare.Module(BicepIdentifier, _path.Compile(), BicepSyntax.Object(properties));
        statements.Add(module);
        return statements;
    }
}
