// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

public class ModuleImport : NamedProvisioningConstruct
{
    private readonly BicepValue<string> _name;
    public BicepValue<string> Name { get => _name; set => _name.Assign(value); }

    private readonly BicepValue<string> _path;
    public BicepValue<string> Path { get => _path; set => _path.Assign(value); }

    private readonly BicepValue<string> _scope;
    public BicepValue<string> Scope { get => _scope; set => _scope.Assign(value); }

    public BicepDictionary<object> Parameters { get; }

    public ModuleImport(string resourceName, BicepValue<string> path) : base(resourceName)
    {
        _name = BicepValue<string>.DefineProperty(this, nameof(Name), ["name"], isRequired: true);
        _path = BicepValue<string>.DefineProperty(this, nameof(Path), ["path"], defaultValue: path);
        _scope = BicepValue<string>.DefineProperty(this, nameof(Scope), ["scope"]);
        Parameters = BicepDictionary<object>.DefineProperty(this, nameof(Parameters), ["params"]);
    }

    protected internal override void Validate(ProvisioningContext? context = null)
    {
        base.Validate(context);
        ValidateProperties();
    }

    protected internal override IEnumerable<Statement> Compile(ProvisioningContext? context = default)
    {
        List<Statement> statements = [];
        Dictionary<string, Expression> properties = new() { { "name", _name.Compile() } };
        if (_scope.Kind != BicepValueKind.Unset) { properties.Add("scope", _scope.Compile()); }
        if (Parameters.Count > 0) { properties.Add("params", Parameters.Compile()); }
        ModuleStatement module = BicepSyntax.Declare.Module(ResourceName, _path.Compile(), BicepSyntax.Object(properties));
        statements.Add(module);
        return statements;
    }
}
