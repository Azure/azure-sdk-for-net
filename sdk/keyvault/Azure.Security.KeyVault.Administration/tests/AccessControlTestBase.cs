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
        public AccessControlClient Client { get; set; }

        public Uri VaultUri { get; set; }

        private readonly ConcurrentQueue<(string Name, string Scope)> _roleAssignmentsToDelete = new ConcurrentQueue<(string Name, string Scope)>();

        public AccessControlTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        { }

        public AccessControlTestBase(bool isAsync) : base(isAsync)
        { }

        internal AccessControlClient GetClient(TestRecording recording = null)
        {
            recording ??= Recording;

            return InstrumentClient
                (new AccessControlClient(
                    new Uri(TestEnvironment.KeyVaultUrl),
                    TestEnvironment.Credential,
                    recording.InstrumentClientOptions(new AccessControlClientOptions())));
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
