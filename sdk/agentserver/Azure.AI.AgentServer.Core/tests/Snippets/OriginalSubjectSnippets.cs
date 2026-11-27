// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    [TestFixture]
    [Explicit("Snippets are compiled to prevent doc rot; they are not executed.")]
    public class OriginalSubjectSnippets
    {
        [Test]
        public void ModelAttribution()
        {
            #region Snippet:Core_OriginalSubject_ModelAttribution

#pragma warning disable AAAS005
            var options = new System.ClientModel.Primitives.RequestOptions();
            foreach (var header in FoundryAgentRequestContext.Current.ModelAttributionHeaders())
            {
                options.SetHeader(header.Key, header.Value);
            }
            // Pass options to the model SDK's per-call protocol operation.
#pragma warning restore AAAS005

            #endregion
        }

        [Test]
        public void DetachedWorkDoesNotInheritContextFlow()
        {
            #region Snippet:Core_OriginalSubject_SuppressContextFlow

            using (ExecutionContext.SuppressFlow())
            {
                _ = Task.Run(DetachedWorkAsync);
            }

            #endregion
        }

        private static Task DetachedWorkAsync() => Task.CompletedTask;
    }
}
