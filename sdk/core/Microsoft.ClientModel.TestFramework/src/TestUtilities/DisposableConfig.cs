// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Abstract base class for test configuration utilities that need to temporarily modify system state
/// and ensure proper cleanup when disposed. This class provides thread-safe access to configuration
/// changes and automatically restores original values on disposal.
/// </summary>
public abstract class DisposableConfig : IDisposable
{
    /// <summary>
    /// Semaphore used to ensure thread-safe access to configuration changes.
    /// Prevents concurrent modifications that could interfere with each other.
    /// </summary>
    private readonly SemaphoreSlim _lock;

    /// <summary>
    /// Dictionary storing the original values of configuration items before they were modified.
    /// Used to restore the original state when the instance is disposed.
    /// </summary>
    protected readonly Dictionary<string, string> OriginalValues = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="DisposableConfig"/> class with a single configuration item.
    /// Acquires a lock to ensure thread-safe modification and stores the original value for later restoration.
    /// </summary>
    /// <param name="name">The name/key of the configuration item to modify.</param>
    /// <param name="value">The new value to set for the configuration item.</param>
    /// <param name="sem">The semaphore to use for thread synchronization.</param>
    /// <exception cref="Exception">
    /// Thrown when the semaphore cannot be acquired immediately, indicating that another instance
    /// is currently modifying configuration. Consider marking conflicting tests as NonParallelizable.
    /// </exception>
    public DisposableConfig(string name, string value, SemaphoreSlim sem)
    {
        _lock = sem;
        var acquired = _lock.Wait(TimeSpan.Zero);
        if (!acquired)
        {
            throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
        }

        InitValues();
        SetValue(name, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DisposableConfig"/> class with multiple configuration items.
    /// Acquires a lock to ensure thread-safe modification and stores the original values for later restoration.
    /// </summary>
    /// <param name="values">A dictionary containing the configuration items to modify (key-value pairs).</param>
    /// <param name="sem">The semaphore to use for thread synchronization.</param>
    /// <exception cref="Exception">
    /// Thrown when the semaphore cannot be acquired immediately, indicating that another instance
    /// is currently modifying configuration. Consider marking conflicting tests as NonParallelizable.
    /// </exception>
    public DisposableConfig(Dictionary<string, string> values, SemaphoreSlim sem)
    {
        _lock = sem;
        var acquired = _lock.Wait(TimeSpan.Zero);
        if (!acquired)
        {
            throw new Exception($"Concurrent use of {nameof(TestEnvVar)}. Consider marking these tests as NonParallelizable.");
        }

        InitValues();
        SetValues(values);
    }

    /// <summary>
    /// Sets a single configuration value. This method must be implemented by derived classes
    /// to define how configuration values are actually modified in the target system.
    /// </summary>
    /// <param name="name">The name/key of the configuration item to set.</param>
    /// <param name="value">The new value to assign to the configuration item.</param>
    internal abstract void SetValue(string name, string value);

    /// <summary>
    /// Sets multiple configuration values. This method must be implemented by derived classes
    /// to define how multiple configuration values are modified in the target system.
    /// </summary>
    /// <param name="values">A dictionary containing the configuration items to set (key-value pairs).</param>
    internal abstract void SetValues(Dictionary<string, string> values);

    /// <summary>
    /// Initializes any additional state required by the derived class before configuration
    /// values are modified. This method is called during construction.
    /// </summary>
    internal abstract void InitValues();

    /// <summary>
    /// Restores the original configuration values that were stored before modification.
    /// This method must be implemented by derived classes to define how the original
    /// state is restored in the target system.
    /// </summary>
    internal abstract void Cleanup();

    /// <summary>
    /// Restores the original configuration values and releases the semaphore lock.
    /// This method is automatically called when the instance is disposed, ensuring
    /// that the system state is properly restored even if an exception occurs during testing.
    /// </summary>
    public void Dispose()
    {
        Cleanup();
        _lock.Release();
    }
}