// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class RetryOptionsTests
{
    [Test]
    public void ClientAuthorsCanSetServiceSpecificRetryBehaviors()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void ClientOptionsAreAppliedToClientRetryPolicy()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void ClientOptionsAreAppliedToCustomRetryPolicy()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CustomRetryPolicyCanOptOutOfClientOptions()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanConfigureRetriesFromConfigurationSettings()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanConfigureCustomRetryPolicyFromConfigurationSettings()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CustomRetryPolicyCanOptOutOfConfigurationSettings()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanUseHttpClientRetryBehaviorsInsteadOfClientRetryPolicy()
    {
        // If an HttpClient is injected that has retry behaviors specified
        // and an end-user or client-author has provided custom retry behaviors
        // these either compose, or we detect and throw an exception so that
        // the app developer can mitigate the situation according to their
        // desired application behavior.

        throw new NotImplementedException();
    }

    #region Helpers
    public class CustomRetryPolicy : ClientRetryPolicy
    {
        private readonly ClientRetryOptions _options;

        public CustomRetryPolicy(ClientPipelineOptions options) : base(options)
        {
            _options = options.Retries;
        }

        // public for tests
        public ClientRetryOptions Options => _options;
    }
    #endregion
}
