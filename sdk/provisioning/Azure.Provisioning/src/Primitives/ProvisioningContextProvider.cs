// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

// TODO: Decide which of these implementations we want to keep or if there's
// anything else we should consider adding.
// - FreshProvisioningContextProvider might be more problematic than it's worth.
// - I love LocalProvisioningContextProvider, but maybe we don't need both it
//   and SharedProvisioningContextProvider.  We could always add it back just
//   for our unit tests (so they can run in parallel without stomping each
//   others' context).
// - Should we prefer AsyncLocal over ThreadLocal?
// - We're not using env vars or IConfig by default today.  It might make sense
//   to either do that automatically or at least offer a provider that does.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Provides a default <see cref="ProvisioningContext"/> instance to use for
/// composing, building, and deploying resources.  Many methods take an
/// optional <see cref="ProvisioningContext"/> parameter, but if not provided
/// it will default the value to what's returned from
/// <see cref="ProvisioningContext.Provider"/>.  You can easily customize the
/// default behavior by setting <see cref="ProvisioningContext.Provider"/> to
/// one of the built-in providers or implement your own.
/// </summary>
/// <remarks>
/// Available built-in providers include:
/// <list type="bullet">
///   <item>
///     <see cref="SharedProvisioningContextProvider" /> allows you to use
///     the same <see cref="ProvisioningContext"/> instance for all operations.
///   </item>
///   <item>
///     <see cref="LocalProvisioningContextProvider" /> will create a
///     thread local context to share between operations on the same thread.
///   </item>
///   <item>
///     <see cref="FreshProvisioningContextProvider" /> allows you to get a new
///     <see cref="ProvisioningContext"/> on every request.
///   </item>
///   <item>
///     <see cref="NoImplicitProvisioningContextProvider" /> will throw if used
///     which forces you to explicitly pass a <see cref="ProvisioningContext"/>
///     to each operation.
///   </item>
/// </list>
/// </remarks>
public abstract class ProvisioningContextProvider
{
    /// <summary>
    /// Get the <see cref="ProvisioningContext"/> instance to use for composing,
    /// building, and deploying resources.
    /// </summary>
    /// <returns>
    /// The <see cref="ProvisioningContext"/> instance to use for composing,
    /// building, and deploying resources.
    /// </returns>
    public abstract ProvisioningContext GetProvisioningContext();
}

/// <summary>
/// Uses the same <see cref="ProvisioningContext"/> instance by default for all
/// infrastructure.
/// </summary>
/// <param name="context">
/// Optional <see cref="ProvisioningContext"/> instance to use.  Otherwise a
/// new, default instance will be created.
/// </param>
public class SharedProvisioningContextProvider(ProvisioningContext? context = default)
    : ProvisioningContextProvider
{
    private readonly ProvisioningContext _context = context ?? new();

    /// <inheritdoc/>
    public override ProvisioningContext GetProvisioningContext() => _context;
}

/// <summary>
/// Creates a thread local <see cref="ProvisioningContext"/> instance that can
/// easily be shared with operations on the same thread without impacting
/// anything else happening on other threads.
/// </summary>
/// <param name="contextFactory">
/// Optional factory that will be called to construct new instances of
/// <see cref="ProvisioningContext"/>.  This allows you to customize the
/// settings of each instance.
/// </param>
/// <remarks>
/// Because this is using thread local storage to share the context, you need
/// to be careful with async code and ensure any awaits are configured to
/// resume on the same thread.
/// </remarks>
public class LocalProvisioningContextProvider(Func<ProvisioningContext>? contextFactory = default)
    : ProvisioningContextProvider
{
    private readonly ThreadLocal<ProvisioningContext> _current = new(contextFactory ?? (() => new()));

    /// <inheritdoc/>
    public override ProvisioningContext GetProvisioningContext() => _current.Value;
}

/// <summary>
/// Get a fresh <see cref="ProvisioningContext"/> instance every time it is
/// required.  This can be useful for scenarios where you want to ensure
/// nothing is unintentionally shared between different operations.
/// </summary>
/// <param name="contextFactory">
/// Optional factory that will be called to construct new instances of
/// <see cref="ProvisioningContext"/>.  This allows you to customize the
/// settings of each instance.
/// </param>
/// <remarks>
/// If your goal is to ensure context isn't inadvertently shared between
/// operations, you might also consider using
/// <see cref="NoImplicitProvisioningContextProvider"/> that will throw an
/// exception if the <see cref="ProvisioningContext"/> isn't explicitly passed.
/// </remarks>
public class FreshProvisioningContextProvider(Func<ProvisioningContext>? contextFactory = default)
    : ProvisioningContextProvider
{
    private readonly Func<ProvisioningContext> _factory =
        contextFactory ?? (() => new());

    /// <inheritdoc/>
    public override ProvisioningContext GetProvisioningContext() => _factory();
}

/// <summary>
/// Throws an exception every time the <see cref="ProvisioningContext"/> is
/// requested, ensuring the context is always explicitly passed to every
/// operation.
/// </summary>
public class NoImplicitProvisioningContextProvider : ProvisioningContextProvider
{
    /// <summary>
    /// Throws an exception every time the <see cref="ProvisioningContext"/> is
    /// requested to ensure it's explicitly passed in to every operation.
    /// </summary>
    /// <returns>Nothing will ever be returned; this always throw.</returns>
    /// <exception cref="InvalidOperationException">
    /// Throws an exception declaring that the ProvisioningContext must be
    /// explicitly passed to all operations every time this is called.
    /// </exception>
    public override ProvisioningContext GetProvisioningContext() =>
        throw new InvalidOperationException("ProvisioningContext must be explicitly passed to all operations.");
}
