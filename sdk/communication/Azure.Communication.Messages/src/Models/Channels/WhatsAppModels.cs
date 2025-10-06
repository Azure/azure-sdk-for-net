// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable SA1402 // File may only contain a single type
namespace Azure.Communication.Messages.Models.Channels
{
    [CodeGenModel("WhatsAppMessageButtonSubType")]
    public partial struct WhatsAppMessageButtonSubType { }

    [CodeGenModel("WhatsAppMessageTemplateBindings")]
    public partial class WhatsAppMessageTemplateBindings { }

    [CodeGenModel("WhatsAppMessageTemplateBindingsButton")]
    public partial class WhatsAppMessageTemplateBindingsButton
    {
        /// <summary> The WhatsApp button sub type. </summary>
        [CodeGenMember("SubType")]
        public string SubType { get; }
    }

    [CodeGenModel("WhatsAppMessageTemplateBindingsComponent")]
    public partial class WhatsAppMessageTemplateBindingsComponent { }

    [CodeGenModel("WhatsAppMessageTemplateItem")]
    public partial class WhatsAppMessageTemplateItem { }

    [CodeGenModel("WhatsAppContact")]
    public partial class WhatsAppContact { }

    [CodeGenModel("WhatsAppButtonActionBindings")]
    public partial class WhatsAppButtonActionBindings { }

    [CodeGenModel("WhatsAppListActionBindings")]
    public partial class WhatsAppListActionBindings { }

    [CodeGenModel("WhatsAppUrlActionBindings")]
    public partial class WhatsAppUrlActionBindings { }
}
#pragma warning restore SA1402 // File may only contain a single type
