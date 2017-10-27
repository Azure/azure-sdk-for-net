// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectsOperationsExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataMigration
{
    public static partial class ProjectsOperationsExtensions
    {
        private const string AzureClientRequestId = "x-ms-client-request-id";

        /// <summary>
        /// Upload project artifacts
        /// </summary>
        /// <param name="operations"><see cref="IProjectsOperations"/> instance</param>
        /// <param name="groupName">Resource group name</param>
        /// <param name="serviceName">Service name</param>
        /// <param name="projectName">Project name</param>
        /// <param name="data"><see cref="Stream"/> containing project artifacts to be uploaded</param>
        /// <param name="cancelToken">Cancellation token</param>
        /// <returns><see cref="HttpResponseMessage"/> containing status of upload request</returns>
        public static async Task<HttpResponseMessage> UploadProjectArtifacts(
            this IProjectsOperations operations,
            string groupName,
            string serviceName,
            string projectName,
            Stream data,
            CancellationToken cancelToken)
        {
            var projectArtifacts
                = await operations.AccessArtifactsAsync(groupName, serviceName, projectName, cancelToken);

            using (var content = new StreamContent(data))
            {
                using (var httpClient = new HttpClient())
                {
                    var httpRequest = new HttpRequestMessage(HttpMethod.Put, projectArtifacts.ArtifactsLocation)
                    {
                        Content = content,
                        Headers =
                        {
                            { AzureClientRequestId, Guid.NewGuid().ToString() }
                        }
                    };
                    return await httpClient.SendAsync(httpRequest, cancelToken);
                }
            }
        }

        /// <summary>
        /// Download project artifacts
        /// </summary>
        /// <param name="operations"><see cref="IProjectsOperations"/> instance</param>
        /// <param name="groupName">Resource group name</param>
        /// <param name="serviceName">Service name</param>
        /// <param name="projectName">Project name</param>
        /// <param name="target"><see cref="Stream"/> to download the project artifact to</param>
        /// <param name="cancelToken">Cancellation token</param>
        /// <returns><see cref="Task"/> representing the download work</returns>
        public static async Task DownloadProjectArtifacts(
            this IProjectsOperations operations,
            string groupName,
            string serviceName,
            string projectName,
            Stream target,
            CancellationToken cancelToken)
        {
            var projectArtifacts
                = await operations.AccessArtifactsAsync(groupName, serviceName, projectName, cancelToken);

            using (var httpClient = new HttpClient
            {
                DefaultRequestHeaders =
                {
                    { AzureClientRequestId, Guid.NewGuid().ToString() }
                }
            })
            {
                using (var response =
                    await
                        httpClient.GetAsync(projectArtifacts.ArtifactsLocation, HttpCompletionOption.ResponseHeadersRead,
                            cancelToken))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        using (var data = await response.Content.ReadAsStreamAsync())
                        {
                            await data.CopyToAsync(target, ushort.MaxValue * 2, cancelToken);
                        }
                    }
                }
            }
        }
    }
}
