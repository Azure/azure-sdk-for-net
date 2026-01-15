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
        get => DereferenceValue(_section.Value);
        set => _section.Value = value;
    }

    public IEnumerable<IConfigurationSection> GetChildren()
    {
        foreach (var child in _section.GetChildren())
        {
            if (child is not null)
                yield return new ReferenceConfigurationSection(_section, child);
        }
    }

    public IChangeToken GetReloadToken() => _section.GetReloadToken();

    public IConfigurationSection GetSection(string key) => new ReferenceConfigurationSection(_config, DereferenceSection(_section.GetSection(key)));

    private IConfigurationSection DereferenceSection(IConfigurationSection section)
    {
        if (!section.Exists())
            return section;

        string? value = section.Value;
        if (value == null)
            return section;

        if (!value.AsSpan().StartsWith("$") || value.Length < 2)
            return section;

        IConfigurationSection dereferencedSection = _config.GetSection(value.Substring(1));

        return dereferencedSection.Exists() ? DereferenceSection(dereferencedSection) : section;
    }

    private string? DereferenceValue(string? value)
    {
        if (value == null)
            return null;

        if (!value.AsSpan().StartsWith("$") || value.Length < 2)
            return value;

        IConfigurationSection section = _config.GetSection(value.Substring(1));

        return section.Exists() ? DereferenceValue(section.Value) : value;
    }
}
