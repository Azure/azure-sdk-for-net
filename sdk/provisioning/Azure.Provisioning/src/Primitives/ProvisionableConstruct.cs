// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Provisioning.Expressions;

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Base class for all provisionable constructs that represent Azure infrastructure components.
/// </summary>
public abstract class ProvisionableConstruct : Provisionable, IBicepValue
{
    /// <summary>
    /// Gets the parent infrastructure construct, if any.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Infrastructure? ParentInfrastructure { get; set; }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override IEnumerable<Provisionable> GetProvisionableResources() =>
        base.GetProvisionableResources();

    /// <summary>
    /// Gets the properties of the construct.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IDictionary<string, IBicepValue> ProvisionableProperties { get; } =
        new Dictionary<string, IBicepValue>();

    /// <summary>
    /// Set a property on the construct.  This is primarily intended for
    /// resolvers to avoid reflection.
    /// </summary>
    /// <param name="property">The property to set.</param>
    /// <param name="value">The property value.</param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void SetProvisioningProperty(IBicepValue property, BicepValue value)
    {
        if (ProvisionableProperties.TryGetValue(property.Self!.PropertyName!, out IBicepValue? existing) &&
            existing != property)
        {
            throw new ArgumentException($"Property {property.Self!.PropertyName} is not defined on construct {GetType().Name}.", nameof(property));
        }
        property.Assign(value);
    }

    /// <inheritdoc/>
    protected internal override void Resolve(ProvisioningBuildOptions? options = null)
    {
        Initialize();

        options ??= new();
        base.Resolve(options);

        // Resolve any property values
        foreach (InfrastructureResolver resolver in options.InfrastructureResolvers)
        {
            resolver.ResolveProperties(this, options);
        }
    }

    /// <inheritdoc/>
    protected internal override void Validate(ProvisioningBuildOptions? options = null)
    {
        options ??= new();
        base.Validate(options);
    }

    private protected virtual void ValidateProperties()
    {
        foreach (IBicepValue property in ProvisionableProperties.Values)
        {
            RequireProperty(property);
        }
    }

    private protected void RequireProperty(IBicepValue value)
    {
        if (value.IsRequired && value.Kind == BicepValueKind.Unset)
        {
            throw new InvalidOperationException($"{GetType().Name} definition is missing required property {value.Self?.PropertyName}");
        }
    }

    /// <inheritdoc/>
    protected internal override IEnumerable<BicepStatement> Compile() =>
        [new ExpressionStatement(CompileProperties())];

    private protected BicepExpression CompileProperties()
    {
        if (_kind == BicepValueKind.Expression)
        {
            return _expression ?? BicepSyntax.Null();
        }

        // Aggregate all the properties into a single nested dictionary
        Dictionary<string, object> body = [];
        foreach (IBicepValue property in ProvisionableProperties.Values.Where(p => !p.IsEmpty))
        {
            // Some of the properties are nested paths and need to be expanded
            // into multiple levels of hierarchy
            Dictionary<string, object> obj = body;
            for (int i = 0; i < property.Self!.BicepPath!.Count - 1; i++) // Properties always have Self/BicepPath defined
            {
                if (!obj.TryGetValue(property.Self.BicepPath[i], out object? next) ||
                    next is not Dictionary<string, object> dict)
                {
                    dict = [];
                    obj[property.Self.BicepPath[i]] = dict;
                }
                obj = dict;
            }
            obj[property.Self.BicepPath[property.Self.BicepPath.Count - 1]] = property;
        }
        return CompileValues(body);

        // Collapse those nested dictionaries into nested ObjectExpressions,
        // compiling values along the way
        static ObjectExpression CompileValues(IDictionary<string, object> dict)
        {
            Dictionary<string, BicepExpression> bicep = [];
            foreach (KeyValuePair<string, object> pair in dict)
            {
                if (pair.Value is Dictionary<string, object> nested)
                {
                    bicep[pair.Key] = CompileValues(nested);
                }
                else if (pair.Value is BicepValue value)
                {
                    bicep[pair.Key] = value.Compile();
                }
                else if (pair.Value is ProvisionableConstruct construct)
                {
                    bicep[pair.Key] = construct.CompileProperties();
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected property value {pair.Value} for {pair.Key}.");
                }
            }
            return BicepSyntax.Object(bicep);
        }
    }

    /// <inheritdoc />
    BicepValueKind IBicepValue.Kind => _kind;
    private BicepValueKind _kind = BicepValueKind.Unset;

    /// <inheritdoc />
    BicepExpression? IBicepValue.Expression
    {
        get => _kind == BicepValueKind.Expression ? _expression : null;
        set
        {
            Initialize();

            _kind = BicepValueKind.Expression;
            _expression = value;

            // Unlink from any group, if necessary, as expressions carry their
            // own context
            ParentInfrastructure?.Remove(this);

            // Reset all the properties as accessors off the current expr
            foreach (IBicepValue property in ProvisionableProperties.Values)
            {
                property.Expression = property.Self?.BicepPath?.Aggregate(_expression, (expr, segment) => expr?.Get(segment));
                property.SetReadOnly();
            }
        }
    }
    private BicepExpression? _expression;

    /// <inheritdoc />
    object? IBicepValue.LiteralValue => _kind == BicepValueKind.Literal ? this : null;

    /// <inheritdoc />
    BicepValueReference? IBicepValue.Self { get => _self; set => _self = value; }
    private BicepValueReference? _self;

    /// <inheritdoc />
    BicepValueReference? IBicepValue.Source => _source;
    private BicepValueReference? _source = null;

    /// <inheritdoc />
    bool IBicepValue.IsOutput => _isOutput;
    private bool _isOutput = false;

    /// <inheritdoc />
    bool IBicepValue.IsRequired => _isRequired;
    private bool _isRequired = false;

    /// <inheritdoc />
    bool IBicepValue.IsSecure => _isSecure;
    private bool _isSecure = false;

    // Optional format defining how values should be serialized
    internal string? Format { get; set; } = null;

    /// <inheritdoc />
    bool IBicepValue.IsEmpty =>
        _kind == BicepValueKind.Unset ||
        _kind == BicepValueKind.Literal && ProvisionableProperties.All(p => p.Value.IsEmpty);

    /// <inheritdoc />
    BicepExpression IBicepValue.Compile() => CompileProperties();

    /// <inheritdoc />
    void IBicepValue.SetReadOnly()
    {
        // Reset all the properties as accessors off the current expr
        foreach (IBicepValue property in ProvisionableProperties.Values)
        {
            property.SetReadOnly();
        }
    }

    /// <inheritdoc />
    void IBicepValue.Assign(IBicepValue source)
    {
        // TODO: Do we want to add a more explicit notion of readonly
        // (especially for expr ref resources)?
        if (_isOutput)
        {
            throw new InvalidOperationException($"Cannot assign to output value {_self?.PropertyName}");
        }

        // Track the source so we can correctly link references across modules
        _source = source?.Self;

        // Copy over the common values (but rely on derived classes for other values)
        _kind = source?.Kind ?? BicepValueKind.Unset;
        _expression = source?.Expression;
        _isSecure = source?.IsSecure ?? false;

        // If we're being assigned an Unset value that references a specific
        // resource, we'll consider this an expression referencing that property
        // (i.e., this is like referencing the unset Id property of a resource
        // you created moments ago).
        if (_kind == BicepValueKind.Unset && _source is not null)
        {
            _kind = BicepValueKind.Expression;
            _expression = _source.GetReference();
        }
    }

    /// <summary>
    /// Assigns a value to a property, either replacing the property instance or assigning through the existing one.
    /// </summary>
    /// <typeparam name="T">The property type.</typeparam>
    /// <param name="property">A reference to the property field.</param>
    /// <param name="value">The value to assign.</param>
    protected virtual void AssignOrReplace<T>(ref T? property, T value) where T : IBicepValue
    {
        if (value.Self is null)
        {
            value.Self = property!.Self;
            ProvisionableProperties[property.Self!.PropertyName] = value;
            property = value;
        }
        else
        {
            property!.Assign(value);
        }
    }

    /// <summary>
    /// Overrides this construct's value with a Bicep expression reference.
    /// </summary>
    /// <param name="reference">The Bicep expression to use as this construct's value.</param>
    protected internal void OverrideWithExpression(BicepExpression reference)
    {
        ((IBicepValue)this).Expression = reference;
    }

    /// <summary>
    /// Initialize this construct.
    /// </summary>
    protected void Initialize()
    {
        if (_kind == BicepValueKind.Unset && ProvisionableProperties.Count == 0)
        {
            _kind = BicepValueKind.Literal;
            DefineProvisionableProperties();
        }
    }

    /// <summary>
    /// Define the provisionable properties for this construct.
    /// </summary>
    protected virtual void DefineProvisionableProperties() { }

    /// <summary>
    /// Defines a scalar property on this construct.
    /// </summary>
    /// <typeparam name="T">The property value type.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <param name="isSecure">Whether the property contains sensitive data.</param>
    /// <param name="defaultValue">An optional default value.</param>
    /// <param name="format">An optional serialization format.</param>
    /// <returns>The defined <see cref="BicepValue{T}"/>.</returns>
    protected BicepValue<T> DefineProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        bool isSecure = false,
        BicepValue<T>? defaultValue = null,
        string? format = null)
    {
        BicepValue<T> val =
            new(new BicepValueReference(this, propertyName, bicepPath))
            {
                _isOutput = isOutput,
                _isRequired = isRequired,
                _isSecure = isSecure,
                Format = format
            };
        if (defaultValue is not null)
        {
            val.Assign(defaultValue);
        }
        ProvisionableProperties[propertyName] = val;
        return val;
    }

    /// <summary>
    /// Defines a list property on this construct.
    /// </summary>
    /// <typeparam name="T">The list element type.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <param name="format">
    /// The optional serialization format token to pass to literal leaf values while compiling
    /// this list to Bicep. When set, this format takes precedence over formats stored on
    /// nested literal values.
    /// </param>
    /// <returns>The defined <see cref="BicepList{T}"/>.</returns>
    protected BicepList<T> DefineListProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        string? format = null)
    {
        BicepList<T> values =
            new(new BicepValueReference(this, propertyName, bicepPath), values: null) // we call this ctor to initialize an "uninitialized" list
            {
                _isOutput = isOutput,
                _isRequired = isRequired,
                Format = format
            };
        ProvisionableProperties[propertyName] = values;
        return values;
    }

    /// <summary>
    /// Defines a list property on this construct.
    /// </summary>
    /// <typeparam name="T">The list element type.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <returns>The defined <see cref="BicepList{T}"/>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected BicepList<T> DefineListProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput,
        bool isRequired)
        => DefineListProperty<T>(propertyName, bicepPath, isOutput, isRequired, format: null);

    /// <summary>
    /// Defines a dictionary property on this construct.
    /// </summary>
    /// <typeparam name="T">The dictionary value type.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <param name="format">
    /// The optional serialization format token to pass to literal leaf values while compiling
    /// this dictionary to Bicep. When set, this format takes precedence over formats stored on
    /// nested literal values.
    /// </param>
    /// <returns>The defined <see cref="BicepDictionary{T}"/>.</returns>
    protected BicepDictionary<T> DefineDictionaryProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        string? format = null)
    {
        BicepDictionary<T> values =
            new(new BicepValueReference(this, propertyName, bicepPath), values: null) // we call this ctor to initialize an "uninitialized" dictionary
            {
                _isOutput = isOutput,
                _isRequired = isRequired,
                Format = format
            };
        ProvisionableProperties[propertyName] = values;
        return values;
    }

    /// <summary>
    /// Defines a dictionary property on this construct.
    /// </summary>
    /// <typeparam name="T">The dictionary value type.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <returns>The defined <see cref="BicepDictionary{T}"/>.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected BicepDictionary<T> DefineDictionaryProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput,
        bool isRequired)
        => DefineDictionaryProperty<T>(propertyName, bicepPath, isOutput, isRequired, format: null);

    /// <summary>
    /// Defines a model property on this construct using a provided instance.
    /// </summary>
    /// <typeparam name="T">The model type, which must derive from <see cref="ProvisionableConstruct"/>.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="value">The model instance to use.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <param name="isSecure">Whether the property contains sensitive data.</param>
    /// <param name="format">An optional serialization format.</param>
    /// <returns>The configured model instance.</returns>
    protected T DefineModelProperty<T>(
        string propertyName,
        string[]? bicepPath,
        T value,
        bool isOutput = false,
        bool isRequired = false,
        bool isSecure = false,
        string? format = null)
        where T : ProvisionableConstruct
    {
        value._self = new BicepValueReference(this, propertyName, bicepPath);
        value._isOutput = isOutput;
        value._isRequired = isRequired;
        value._isSecure = isSecure;
        value.Format = format;
        ProvisionableProperties[propertyName] = value;
        return value;
    }

    /// <summary>
    /// Defines a model property on this construct, creating a new instance of the model type.
    /// </summary>
    /// <typeparam name="T">The model type, which must derive from <see cref="ProvisionableConstruct"/> and have a parameterless constructor.</typeparam>
    /// <param name="propertyName">The property name.</param>
    /// <param name="bicepPath">The Bicep path segments for this property.</param>
    /// <param name="isOutput">Whether the property is an output.</param>
    /// <param name="isRequired">Whether the property is required.</param>
    /// <param name="isSecure">Whether the property contains sensitive data.</param>
    /// <param name="format">An optional serialization format.</param>
    /// <returns>The configured model instance.</returns>
    protected T DefineModelProperty<T>(
        string propertyName,
        string[]? bicepPath,
        bool isOutput = false,
        bool isRequired = false,
        bool isSecure = false,
        string? format = null)
        where T : ProvisionableConstruct, new()
        => DefineModelProperty(propertyName, bicepPath, new T(), isOutput, isRequired, isSecure, format);
}
