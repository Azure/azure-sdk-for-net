// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents a Bicep module import that references an external Bicep file.
/// </summary>
public class ModuleImport : NamedProvisionableConstruct
{
    private readonly BicepValue<string> _name;
    /// <summary>
    /// Gets or sets the display name of the module.
    /// </summary>
    public BicepValue<string> Name { get => _name; set => _name.Assign(value); }

    private readonly BicepValue<string> _path;
    /// <summary>
    /// Gets or sets the path to the Bicep module file.
    /// </summary>
    public BicepValue<string> Path { get => _path; set => _path.Assign(value); }

    private readonly BicepValue<string> _scope;
    /// <summary>
    /// Gets or sets the deployment scope for the module.
    /// </summary>
    public BicepValue<string> Scope { get => _scope; set => _scope.Assign(value); }

    /// <summary>
    /// Gets the parameters to pass to the module.
    /// </summary>
    public BicepDictionary<object> Parameters { get; }

    /// <summary>
    /// Creates a new <see cref="ModuleImport"/>.
    /// </summary>
    /// <param name="bicepIdentifier">The Bicep identifier for this module.</param>
    /// <param name="path">The path to the Bicep module file.</param>
    public ModuleImport(string bicepIdentifier, BicepValue<string> path) : base(bicepIdentifier)
    {
        _name = DefineProperty<string>(nameof(Name), ["name"], isRequired: true);
        _path = DefineProperty<string>(nameof(Path), ["path"], defaultValue: path);
        _scope = DefineProperty<string>(nameof(Scope), ["scope"]);
        Parameters = DefineDictionaryProperty<object>(nameof(Parameters), ["params"]);
    }

    /// <inheritdoc />
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        base.Validate(options);
        ValidateProperties();
    }

    /// <inheritdoc />
    protected internal override IEnumerable<BicepStatement> Compile()
    {
        List<BicepStatement> statements = [];
        Dictionary<string, BicepExpression> properties = new() { { "name", _name.Compile() } };
        if (((IBicepValue)_scope).Kind != BicepValueKind.Unset)
        { properties.Add("scope", _scope.Compile()); }
        if (Parameters.Count > 0)
        { properties.Add("params", Parameters.Compile()); }
        ModuleStatement module = BicepSyntax.Declare.Module(BicepIdentifier, _path.Compile(), BicepSyntax.Object(properties));
        statements.Add(module);
        return statements;
    }
}
