// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // File may only contain a single type
namespace Azure.Communication.Messages.Models.Channels
{
    [CodeGenType("WhatsAppMessageButtonSubType")]
    public partial struct WhatsAppMessageButtonSubType { }

    [CodeGenType("WhatsAppMessageTemplateBindings")]
    public partial class WhatsAppMessageTemplateBindings { }

    [CodeGenType("WhatsAppMessageTemplateBindingsButton")]
    public partial class WhatsAppMessageTemplateBindingsButton
    {
        /// <summary> The WhatsApp button sub type. </summary>
        [CodeGenMember("SubType")]
        public string SubType { get; }
    }

    [CodeGenType("WhatsAppMessageTemplateBindingsComponent")]
    public partial class WhatsAppMessageTemplateBindingsComponent { }

    [CodeGenType("WhatsAppMessageTemplateItem")]
    public partial class WhatsAppMessageTemplateItem { }

    [CodeGenType("WhatsAppContact")]
    public partial class WhatsAppContact { }

    [CodeGenType("WhatsAppButtonActionBindings")]
    public partial class WhatsAppButtonActionBindings { }

    [CodeGenType("WhatsAppListActionBindings")]
    public partial class WhatsAppListActionBindings { }

    [CodeGenType("WhatsAppUrlActionBindings")]
    public partial class WhatsAppUrlActionBindings { }
}
#pragma warning restore SA1402 // File may only contain a single type
