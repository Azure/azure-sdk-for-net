// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog language change event
    /// </summary>
    public class DialogLanguageChange : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogLanguageChange </summary>
        internal DialogLanguageChange()
        {
        }

        /// <summary> Initializes a new instance of DialogLanguageChange. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogLanguageChange. </param>
        internal DialogLanguageChange(DialogLanguageChangeInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            DialogInputType = internalEvent.DialogInputType;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            DialogId = internalEvent.DialogId;
            SelectedLanguage = internalEvent.SelectedLanguage;
            IvrContext = internalEvent.IvrContext;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }

        /// <summary> Dialog Id</summary>
        public string DialogId { get; }

        /// <summary> LanguageChange data </summary>
        public string SelectedLanguage { get; }

        /// <summary> IvrContext </summary>
        public object IvrContext { get; }

        /// <summary>
        /// Deserialize <see cref="DialogLanguageChange"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogLanguageChange"/> object.</returns>
        public static DialogLanguageChange Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogLanguageChangeInternal.DeserializeDialogLanguageChangeInternal(element);
            return new DialogLanguageChange(internalEvent);
        }
    }
}
