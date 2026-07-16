// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// ROOT CAUSE: GA 1.5.0 shipped the *Slot variants of GetContainerLogsZip,
// GetWebSiteContainerLogs, and GetPublishingProfileXmlWithSecrets returning
// Response<Stream>. The new TypeSpec generator emits these as
// Response<BinaryData>. Suppress and redeclare with GA Stream contract.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetContainerLogsZipSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerLogsZipSlot", typeof(CancellationToken))]
    [CodeGenSuppress("GetWebSiteContainerLogsSlotAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetWebSiteContainerLogsSlot", typeof(CancellationToken))]
    [CodeGenSuppress("GetPublishingProfileXmlWithSecretsSlotAsync", typeof(CsmPublishingProfile), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublishingProfileXmlWithSecretsSlot", typeof(CsmPublishingProfile), typeof(CancellationToken))]
    public partial class WebSiteSlotResource
    {
        /// <summary> Description for Gets the ZIP archived docker log files for the given site (slot). </summary>
        public virtual async Task<Response<Stream>> GetContainerLogsZipSlotAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetContainerLogsZipSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetContainerLogsZipSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the ZIP archived docker log files for the given site (slot). </summary>
        public virtual Response<Stream> GetContainerLogsZipSlot(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetContainerLogsZipSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetContainerLogsZipSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the last lines of docker logs for the given site (slot). </summary>
        public virtual async Task<Response<Stream>> GetWebSiteContainerLogsSlotAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetWebSiteContainerLogsSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetWebSiteContainerLogsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the last lines of docker logs for the given site (slot). </summary>
        public virtual Response<Stream> GetWebSiteContainerLogsSlot(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetWebSiteContainerLogsSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetWebSiteContainerLogsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the publishing profile XML with secrets for the app (slot). </summary>
        public virtual async Task<Response<Stream>> GetPublishingProfileXmlWithSecretsSlotAsync(CsmPublishingProfile publishingProfileOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(publishingProfileOptions, nameof(publishingProfileOptions));
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetPublishingProfileXmlWithSecretsSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetPublishingProfileXmlWithSecretsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, CsmPublishingProfile.ToRequestContent(publishingProfileOptions), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the publishing profile XML with secrets for the app (slot). </summary>
        public virtual Response<Stream> GetPublishingProfileXmlWithSecretsSlot(CsmPublishingProfile publishingProfileOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(publishingProfileOptions, nameof(publishingProfileOptions));
            using DiagnosticScope scope = _webAppsClientDiagnostics.CreateScope("WebSiteSlotResource.GetPublishingProfileXmlWithSecretsSlot");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _webAppsRestClient.CreateGetPublishingProfileXmlWithSecretsSlotRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, CsmPublishingProfile.ToRequestContent(publishingProfileOptions), context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
