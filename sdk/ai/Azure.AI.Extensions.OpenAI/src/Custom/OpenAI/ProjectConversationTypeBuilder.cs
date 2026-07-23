// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Extensions.OpenAI
{
    internal sealed class ProjectConversationTypeBuilder : ModelReaderWriterTypeBuilder
    {
        protected override Type BuilderType => typeof(ProjectConversation);

        protected override object CreateInstance() => new ProjectConversation();
    }
}
