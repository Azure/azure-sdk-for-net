using System.ComponentModel;
using System.Globalization;

namespace Azure.AI.AgentServer.Core.Context;

[TypeConverter(typeof(FoundryProjectInfoConverter))]
public record FoundryProjectInfo(string Account, string Project)
{
    public Uri ProjectEndpoint { get; } = new Uri($"https://{Account}.services.ai.azure.com/api/projects/{Project}");

    public static FoundryProjectInfo? Parse(string? foundryProject)
    {
        if (string.IsNullOrWhiteSpace(foundryProject))
        {
            return null;
        }

        var lastPart = foundryProject.Split('/').Last();
        var parts = lastPart.Split('@');
        if (parts.Length < 2)
        {
            throw new ArgumentException($"Invalid foundry project format: {foundryProject}");
        }

        return new FoundryProjectInfo(parts[0], parts[1]);
    }
}

public sealed class FoundryProjectInfoConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        => value is string s ? FoundryProjectInfo.Parse(s) : null;
}
