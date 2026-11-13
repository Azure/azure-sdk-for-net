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

// ROOT CAUSE: GA 1.5.0 shipped GetContainerLogsZip, GetWebSiteContainerLogs,
// and GetPublishingProfileXmlWithSecrets returning Response<Stream>. The new
// TypeSpec generator emits these as Response<BinaryData>. Suppress the
// generated members and redeclare with the GA Stream-returning contract using
// the underlying REST client directly.
namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("GetContainerLogsZipAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetContainerLogsZip", typeof(CancellationToken))]
    [CodeGenSuppress("GetWebSiteContainerLogsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetWebSiteContainerLogs", typeof(CancellationToken))]
    [CodeGenSuppress("GetPublishingProfileXmlWithSecretsAsync", typeof(CsmPublishingProfile), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublishingProfileXmlWithSecrets", typeof(CsmPublishingProfile), typeof(CancellationToken))]
    public partial class WebSiteResource
    {
        /// <summary> Description for Gets the ZIP archived docker log files for the given site. </summary>
        public virtual async Task<Response<Stream>> GetContainerLogsZipAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetContainerLogsZip");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetContainerLogsZipRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the ZIP archived docker log files for the given site. </summary>
        public virtual Response<Stream> GetContainerLogsZip(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetContainerLogsZip");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetContainerLogsZipRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the last lines of docker logs for the given site. </summary>
        public virtual async Task<Response<Stream>> GetWebSiteContainerLogsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetWebSiteContainerLogs");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetWebSiteContainerLogsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the last lines of docker logs for the given site. </summary>
        public virtual Response<Stream> GetWebSiteContainerLogs(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetWebSiteContainerLogs");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetWebSiteContainerLogsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the publishing profile XML with secrets for the app. </summary>
        public virtual async Task<Response<Stream>> GetPublishingProfileXmlWithSecretsAsync(CsmPublishingProfile publishingProfileOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(publishingProfileOptions, nameof(publishingProfileOptions));
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetPublishingProfileXmlWithSecrets");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetPublishingProfileXmlWithSecretsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CsmPublishingProfile.ToRequestContent(publishingProfileOptions), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(result.ContentStream, result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Description for Gets the publishing profile XML with secrets for the app. </summary>
        public virtual Response<Stream> GetPublishingProfileXmlWithSecrets(CsmPublishingProfile publishingProfileOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(publishingProfileOptions, nameof(publishingProfileOptions));
            using DiagnosticScope scope = _sitesClientDiagnostics.CreateScope("WebSiteResource.GetPublishingProfileXmlWithSecrets");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _sitesRestClient.CreateGetPublishingProfileXmlWithSecretsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, CsmPublishingProfile.ToRequestContent(publishingProfileOptions), context);
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
