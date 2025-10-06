// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure.Core;

namespace Azure.Health.Deidentification
{
    // Data plane customized client.
    /// <summary> The Deidentification service client. </summary>
    public partial class DeidentificationClient
    {
        /// <summary> List de-identification jobs. </summary>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Resource list operation template. </remarks>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DeidentificationJob> GetJobsAsync(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobs");
            scope.Start();
            return GetJobsInternalAsync(maxpagesize, null, cancellationToken);
        }

        /// <summary> List de-identification jobs. </summary>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Resource list operation template. </remarks>
        [ForwardsClientCalls]
        public virtual Pageable<DeidentificationJob> GetJobs(int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobs");
            scope.Start();
            return GetJobsInternal(maxpagesize, null, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] List de-identification jobs.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobsAsync(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<BinaryData> GetJobsAsync(int? maxpagesize, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobs");
            scope.Start();
            return GetJobsInternalAsync(maxpagesize, null, context);
        }

        /// <summary>
        /// [Protocol Method] List de-identification jobs.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobs(int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<BinaryData> GetJobs(int? maxpagesize, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobs");
            scope.Start();
            return GetJobsInternal(maxpagesize, null, context);
        }

        /// <summary> List processed documents within a job. </summary>
        /// <param name="jobName"> The name of a job. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> The most basic operation. </remarks>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DeidentificationDocumentDetails> GetJobDocumentsAsync(string jobName, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobDocuments");
            scope.Start();
            return GetJobDocumentsInternalAsync(jobName, maxpagesize, null, cancellationToken);
        }

        /// <summary> List processed documents within a job. </summary>
        /// <param name="jobName"> The name of a job. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> The most basic operation. </remarks>
        [ForwardsClientCalls]
        public virtual Pageable<DeidentificationDocumentDetails> GetJobDocuments(string jobName, int? maxpagesize = null, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobDocuments");
            scope.Start();
            return GetJobDocumentsInternal(jobName, maxpagesize, null, cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] List processed documents within a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobDocumentsAsync(string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobName"> The name of a job. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<BinaryData> GetJobDocumentsAsync(string jobName, int? maxpagesize, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobDocuments");
            scope.Start();
            return GetJobDocumentsInternalAsync(jobName, maxpagesize, null, context);
        }

        /// <summary>
        /// [Protocol Method] List processed documents within a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobDocuments(string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobName"> The name of a job. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        [ForwardsClientCalls]
        public virtual Pageable<BinaryData> GetJobDocuments(string jobName, int? maxpagesize, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("DeidentificationClient.GetJobDocuments");
            scope.Start();
            return GetJobDocumentsInternal(jobName, maxpagesize, null, context);
        }
    }
}
