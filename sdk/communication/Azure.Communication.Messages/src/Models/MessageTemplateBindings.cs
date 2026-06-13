// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Communication.Messages
{
    /// <summary>
    /// The binding object to link values to the template specific locations.
    /// </summary>
    public abstract partial class MessageTemplateBindings
    {
        /// <summary> Initializes a new instance of <see cref="MessageTemplateBindings"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MessageTemplateBindings()
            : this(default(MessageTemplateBindingsKind), null)
        {
        }
    }
}
