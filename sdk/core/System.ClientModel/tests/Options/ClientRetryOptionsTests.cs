﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class ClientRetryOptionsTests
{
    [Test]
    public void PolicyConstructorThrowsIfUnsupportedOptionSet_UnspecifiedVersionPolicy()
    {
        ClientRetryOptions options = new ClientRetryOptions()
        {
            // Setting this V1_2_0 option causes constructor to throw.
            MaxRetries = 5
        };

        Assert.Throws<NotSupportedException>(() =>
            new CustomRetryPolicyWithUnspecifiedVersion(options));
    }

    [Test]
    public void PolicyConstructorDoesNotThrowIfOnlySupportedOptionsSet_UnspecifiedVersionPolicy()
    {
        // No options are set, so policy constructor shouldn't throw.
        ClientRetryOptions options = new ClientRetryOptions();

        Assert.DoesNotThrow(() => new CustomRetryPolicyWithUnspecifiedVersion(options));
    }

    [Test]
    public void PolicyConstructorThrowsIfUnsupportedOptionSet_LowerVersionPolicy()
    {
        ClientRetryOptions options = new ClientRetryOptions()
        {
            // Setting this V1_2_0 option causes constructor to throw.
            MaxRetries = 5
        };

        Assert.Throws<NotSupportedException>(() =>
            new CustomRetryPolicyWithLowerVersion(options));
    }

    [Test]
    public void PolicyConstructorDoesNotThrowIfOnlySupportedOptionsSet_LowerVersionPolicy()
    {
        // No options are set, so policy constructor shouldn't throw.
        ClientRetryOptions options = new ClientRetryOptions();

        Assert.DoesNotThrow(() => new CustomRetryPolicyWithLowerVersion(options));
    }

    [Test]
    public void PolicyConstructorDoesNotThrowForBaseRetryPolicy()
    {
        ClientRetryOptions options = new ClientRetryOptions();

        Assert.DoesNotThrow(() => new ClientRetryPolicy(options));
    }

    #region Helpers

    internal class CustomRetryPolicyWithUnspecifiedVersion : ClientRetryPolicy
    {
        public CustomRetryPolicyWithUnspecifiedVersion(ClientRetryOptions options)
            : base(options)
        {
        }

        // No supported version provided
        protected override ClientRetryOptionsVersion? SupportedOptionsVersion =>
            default;
    }

    internal class CustomRetryPolicyWithLowerVersion : ClientRetryPolicy
    {
        public CustomRetryPolicyWithLowerVersion(ClientRetryOptions options)
            : base(options)
        {
        }

        // Base type supports higher version than V1_1_0
        protected override ClientRetryOptionsVersion? SupportedOptionsVersion =>
            ClientRetryOptionsVersion.V1_1_0;
    }

    #endregion
}
