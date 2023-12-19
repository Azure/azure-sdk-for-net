// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary> The binding object to link values to the template specific locations. </summary>
    public abstract partial class MessageTemplateBindings
    {
        internal abstract MessageTemplateBindingsInternal ToMessageTemplateBindingsInternal();
    }
}
