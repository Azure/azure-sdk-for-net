// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials
{
    /// <summary>
    /// Shared base for credential creation/priority tests.
    /// Provides common helpers for creating credentials from IConfiguration
    /// and reading internal properties/fields via reflection.
    /// </summary>
    internal abstract class CredentialCreationTestBase<TCredential>
        where TCredential : Azure.Core.TokenCredential
    {
        protected ConfigurableCredentialTestHelper<TCredential> Helper { get; private set; }

        protected abstract string CredentialSource { get; }

        [SetUp]
        public void Setup()
        {
            Helper = new ConfigurableCredentialTestHelper<TCredential>(CredentialSource);
        }

        protected ConfigurableCredential CreateFromConfig(IConfiguration config)
            => Helper.GetCredentialFromConfig(config);

        protected TCredential GetUnderlying(ConfigurableCredential credential)
            => Helper.GetUnderlyingCredential(credential);

        /// <summary>
        /// Reads an internal/private property by walking the type hierarchy.
        /// </summary>
        protected static T ReadProperty<T>(object target, string name)
        {
            var type = target.GetType();
            while (type != null)
            {
                var prop = type.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (prop != null)
                    return (T)prop.GetValue(target);
                type = type.BaseType;
            }
            throw new InvalidOperationException($"Property '{name}' not found on {target.GetType().Name} or its base types.");
        }

        /// <summary>
        /// Reads an internal/private field by walking the type hierarchy.
        /// </summary>
        protected static T ReadField<T>(object target, string name)
        {
            var type = target.GetType();
            while (type != null)
            {
                var field = type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
                if (field != null)
                    return (T)field.GetValue(target);
                type = type.BaseType;
            }
            throw new InvalidOperationException($"Field '{name}' not found on {target.GetType().Name} or its base types.");
        }
    }
}
