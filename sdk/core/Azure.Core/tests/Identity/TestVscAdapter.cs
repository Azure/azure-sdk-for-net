// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using NUnit.Framework;
namespace Azure.Core.Tests.Identity
{
    public sealed class TestVscAdapter : IVisualStudioCodeAdapter
    {
        private readonly string _expectedServiceName;
        private readonly string _expectedAccountName;
        private readonly string _refreshToken;

        public TestVscAdapter(string expectedServiceName, string expectedAccountName, string refreshToken)
        {
            _expectedServiceName = expectedServiceName;
            _expectedAccountName = expectedAccountName;
            _refreshToken = refreshToken;
        }

        public string GetUserSettingsPath() => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public string GetCredentials(string serviceName, string accountName)
        {
            Assert.AreEqual(_expectedServiceName, serviceName);
            Assert.AreEqual(_expectedAccountName, accountName);
            return _refreshToken ?? throw new InvalidOperationException("No token found");
        }
    }
}
