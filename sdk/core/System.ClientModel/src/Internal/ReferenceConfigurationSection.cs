// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace System.ClientModel.Primitives;

internal readonly struct ReferenceConfigurationSection : IConfigurationSection
{
    private readonly IConfiguration _config;
    private readonly IConfigurationSection _section;

    public ReferenceConfigurationSection(IConfiguration config, string sectionName)
    {
        if (config is null)
        {
            throw new ArgumentNullException(nameof(config));
        }

        if (sectionName is null)
        {
            throw new ArgumentNullException(nameof(sectionName));
        }

        _config = config;
        _section = config.GetSection(sectionName);
    }

    private ReferenceConfigurationSection(IConfiguration config, IConfigurationSection section)
    {
        _config = config;
        _section = section;
    }

    public string? this[string key]
    {
        get => GetSection(key).Value;
        set => GetSection(key).Value = value;
    }

    public string Key => _section.Key;

    public string Path => _section.Path;

    public string? Value
    {
        get => DereferenceValue(_section.Value, null);
        set => _section.Value = value;
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        foreach (IConfigurationSection? child in _section.GetChildren())
        {
            if (child is not null)
            {
                yield return new ReferenceConfigurationSection(_config, child);
            }
        }
    }

    public IChangeToken GetReloadToken() => _section.GetReloadToken();

    public IConfigurationSection GetSection(string key) => new ReferenceConfigurationSection(_config, DereferenceSection(_section.GetSection(key), null));

    private IConfigurationSection DereferenceSection(IConfigurationSection section, HashSet<string>? visited)
    {
        if (!section.Exists())
        {
            return section;
        }

        string? value = section.Value;
        if (string.IsNullOrEmpty(value))
        {
            return section;
        }

        if (value![0] != '$' || value.Length < 2)
        {
            return section;
        }

        string referencePath = value.Substring(1);
        visited ??= new HashSet<string>();

        if (!visited.Add(referencePath))
            throw new InvalidOperationException($"Circular reference detected in configuration path. The reference chain includes section '{referencePath}' more than once.");

        IConfigurationSection dereferencedSection = _config.GetSection(referencePath);

        return dereferencedSection.Exists() ? DereferenceSection(dereferencedSection, visited) : section;
    }

    private string? DereferenceValue(string? value, HashSet<string>? visited)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value![0] != '$' || value.Length < 2)
        {
            return value;
        }

        string referencePath = value.Substring(1);
        visited ??= new HashSet<string>();

        if (!visited.Add(referencePath))
            throw new InvalidOperationException($"Circular reference detected in configuration path. The reference chain includes section '{referencePath}' more than once.");

        IConfigurationSection section = _config.GetSection(referencePath);

        return section.Exists() ? DereferenceValue(section.Value, visited) : value;
    }
}
