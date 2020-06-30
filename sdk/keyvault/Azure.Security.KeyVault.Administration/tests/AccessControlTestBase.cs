// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class AccessControlTestBase : RecordedTestBase<KeyVaultTestEnvironment>
    {
        public KeyVaultAccessControlClient Client { get; set; }

        public Uri VaultUri { get; set; }

        private readonly ConcurrentQueue<(string Name, string Scope)> _roleAssignmentsToDelete = new ConcurrentQueue<(string Name, string Scope)>();

        public AccessControlTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        { }

        public AccessControlTestBase(bool isAsync) : base(isAsync)
        { }

        internal KeyVaultAccessControlClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new KeyVaultAccessControlClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    TestEnvironment.Credential,
                    recording.InstrumentClientOptions(new KeyVaultAccessControlClientOptions())));
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            Client = GetClient();

            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                ChallengeBasedAuthenticationPolicy.AuthenticationChallenge.ClearCache();
            }
        }

        [TearDown]
        public async Task Cleanup()
        {
            // Start deleting resources as soon as possible.
            while (_roleAssignmentsToDelete.TryDequeue(out var assignment))
            {
                await DeleteRoleAssignment(assignment);
            }
        }

        protected async Task DeleteRoleAssignment((string Name, string Scope) assignment)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.DeleteRoleAssignmentAsync(assignment.Scope, assignment.Name).ConfigureAwait(false);
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }
        }

        protected void RegisterForCleanup(RoleAssignment assignment)
        {
            _roleAssignmentsToDelete.Enqueue((assignment.Name, assignment.Properties.Scope));
        }
    }
}
