// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Developer.DevCenter.Models;

namespace Azure.Developer.DevCenter
{
    [CodeGenSuppress("CreateDevBoxAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(DevBox), typeof(CancellationToken))]
    [CodeGenSuppress("CreateDevBox", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(DevBox), typeof(CancellationToken))]
    public partial class DevBoxesClient
    {
        /// <summary> Creates or replaces a Dev Box. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The DevCenter Project upon which to execute the operation. </param>
        /// <param name="userId"> The AAD object id of the user. If value is 'me', the identity is taken from the authentication context. </param>
        /// <param name="devBox"> Represents the body request of a Dev Box creation. Dev Box Pool name is required. Optionally set the owner of the Dev Box as local administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="userId"/> or <paramref name="devBox"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/DevBoxesClient.xml" path="doc/members/member[@name='CreateDevBoxAsync(WaitUntil,string,string,string,DevBox,CancellationToken)']/*" />
        public virtual async Task<Operation<DevBox>> CreateDevBoxAsync(WaitUntil waitUntil, string projectName, string userId, DevBox devBox, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            Argument.AssertNotNullOrEmpty(devBox.Name, nameof(devBox.Name));
            Argument.AssertNotNull(devBox, nameof(devBox));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = devBox.ToRequestContent();
            Operation<BinaryData> response = await CreateDevBoxAsync(waitUntil, projectName, userId, devBox.Name, content, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, DevBox.FromResponse, ClientDiagnostics, "DevBoxesClient.CreateDevBox");
        }

        /// <summary> Creates or replaces a Dev Box. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The DevCenter Project upon which to execute the operation. </param>
        /// <param name="userId"> The AAD object id of the user. If value is 'me', the identity is taken from the authentication context. </param>
        /// <param name="devBox"> Represents the body request of a Dev Box creation. Dev Box Pool name is required. Optionally set the owner of the Dev Box as local administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/>, <paramref name="userId"/> or <paramref name="devBox"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> or <paramref name="userId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/DevBoxesClient.xml" path="doc/members/member[@name='CreateDevBox(WaitUntil,string,string,string,DevBox,CancellationToken)']/*" />
        public virtual Operation<DevBox> CreateDevBox(WaitUntil waitUntil, string projectName, string userId, DevBox devBox, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(projectName, nameof(projectName));
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            Argument.AssertNotNullOrEmpty(devBox.Name, nameof(devBox.Name));
            Argument.AssertNotNull(devBox, nameof(devBox));

            RequestContext context = FromCancellationToken(cancellationToken);
            using RequestContent content = devBox.ToRequestContent();
            Operation<BinaryData> response = CreateDevBox(waitUntil, projectName, userId, devBox.Name, content, context);
            return ProtocolOperationHelpers.Convert(response, DevBox.FromResponse, ClientDiagnostics, "DevBoxesClient.CreateDevBox");
        }
    }
}
