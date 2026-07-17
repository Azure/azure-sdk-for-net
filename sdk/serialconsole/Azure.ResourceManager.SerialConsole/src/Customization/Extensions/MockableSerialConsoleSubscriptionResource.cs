// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SerialConsole.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SerialConsole.Mocking
{
    [CodeGenSuppress("DisableConsoleAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DisableConsole", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("EnableConsoleAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("EnableConsole", typeof(string), typeof(CancellationToken))]
    public partial class MockableSerialConsoleSubscriptionResource
    {
        private const string ConsoleServiceName = "default";

        /// <summary> Disables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DisableSerialConsoleResult>> DisableConsoleAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = SerialConsoleOperationGroupClientDiagnostics.CreateScope("MockableSerialConsoleSubscriptionResource.DisableConsole");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = SerialConsoleOperationGroupRestClient.CreateDisableConsoleRequest(Guid.Parse(Id.SubscriptionId), ConsoleServiceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DisableSerialConsoleResult> response = Response.FromValue(DisableSerialConsoleResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Disables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DisableSerialConsoleResult> DisableConsole(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = SerialConsoleOperationGroupClientDiagnostics.CreateScope("MockableSerialConsoleSubscriptionResource.DisableConsole");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = SerialConsoleOperationGroupRestClient.CreateDisableConsoleRequest(Guid.Parse(Id.SubscriptionId), ConsoleServiceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DisableSerialConsoleResult> response = Response.FromValue(DisableSerialConsoleResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Enables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<EnableSerialConsoleResult>> EnableConsoleAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = SerialConsoleOperationGroupClientDiagnostics.CreateScope("MockableSerialConsoleSubscriptionResource.EnableConsole");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = SerialConsoleOperationGroupRestClient.CreateEnableConsoleRequest(Guid.Parse(Id.SubscriptionId), ConsoleServiceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<EnableSerialConsoleResult> response = Response.FromValue(EnableSerialConsoleResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Enables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<EnableSerialConsoleResult> EnableConsole(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = SerialConsoleOperationGroupClientDiagnostics.CreateScope("MockableSerialConsoleSubscriptionResource.EnableConsole");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = SerialConsoleOperationGroupRestClient.CreateEnableConsoleRequest(Guid.Parse(Id.SubscriptionId), ConsoleServiceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<EnableSerialConsoleResult> response = Response.FromValue(EnableSerialConsoleResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
