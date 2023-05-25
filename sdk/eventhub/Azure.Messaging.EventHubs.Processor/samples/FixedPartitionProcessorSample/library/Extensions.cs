namespace EventHubProcessors;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// Extension methods.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// This adds an EventHubFixedPartitionProcessorFactory.
    /// </summary>
    /// <typeparam name="T">The type of the configuration object in the service collection.</typeparam>
    /// <param name="services">The service collection.</param>
    public static void AddEventHubFixedPartitionProcessor<T>(this IServiceCollection services)
    {
        services.TryAddSingleton(provider => (IEventHubFixedPartitionProcessorConfig)provider.GetService<T>());
        services.TryAddSingleton<IEventHubFixedPartitionProcessorFactory, EventHubFixedPartitionProcessorFactory>();
    }
}