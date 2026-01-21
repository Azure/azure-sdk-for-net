// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    public partial class ConversationAuthoringProject
    {
        /// <summary>
        /// Triggers a job to import a project using raw JSON string input.
        /// This is an alternative to the structured import method, and is useful when importing directly from exported project files.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectJson">
        /// A raw JSON string representing the entire project to import.
        /// This string should match the format of an exported Analyze Conversations project.
        /// </param>
        /// <param name="projectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Operation> ImportAsync(WaitUntil waitUntil, string projectJson, ConversationAuthoringExportedProjectFormat? projectFormat = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(projectJson, nameof(projectJson));

            using RequestContent content = RequestContent.Create(Encoding.UTF8.GetBytes(projectJson));
            RequestContext context = cancellationToken.ToRequestContext();
            return await ImportAsync(waitUntil, content, projectFormat?.ToString(), context).ConfigureAwait(false);
        }

        /// <summary>
        /// Triggers a job to import a project using raw JSON string input.
        /// This is an alternative to the structured import method, and is useful when importing directly from exported project files.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectJson">
        /// A raw JSON string representing the entire project to import.
        /// This string should match the format of an exported Analyze Conversations project.
        /// </param>
        /// <param name="projectFormat"> The format of the exported project file to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Operation Import(WaitUntil waitUntil, string projectJson, ConversationAuthoringExportedProjectFormat? projectFormat = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(_projectName, nameof(_projectName));
            Argument.AssertNotNullOrEmpty(projectJson, nameof(projectJson));

            using RequestContent content = RequestContent.Create(Encoding.UTF8.GetBytes(projectJson));
            RequestContext context = cancellationToken.ToRequestContext();
            return Import(waitUntil, content, projectFormat?.ToString(), context);
        }

        /// <summary> Creates a new project or replaces an existing one. </summary>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CreateProjectAsync(
            ConversationAuthoringCreateProjectDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = ToRequestContent(details);
            RequestContext context = cancellationToken.ToRequestContext();
            return await CreateProjectAsync(content, context).ConfigureAwait(false);
        }

        /// <summary> Creates a new project or replaces an existing one. </summary>
        /// <param name="details"> The new deployment info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CreateProject(
            ConversationAuthoringCreateProjectDetails details,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using RequestContent content = ToRequestContent(details);
            RequestContext context = cancellationToken.ToRequestContext();
            return CreateProject(content, context);
        }

        private static RequestContent ToRequestContent(ConversationAuthoringCreateProjectDetails details)
        {
            if (details == null)
            {
                return null;
            }
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(details, ModelSerializationExtensions.WireOptions);
            return content;
        }
    }
}
