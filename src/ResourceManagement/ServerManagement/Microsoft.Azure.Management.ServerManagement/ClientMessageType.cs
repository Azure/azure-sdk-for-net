// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ServerManagement
{
    public enum ClientMessageType
    {
        /// <summary>
        /// Indicates a message of type CommandCompletedMessage
        /// </summary>
        CommandCompleted = 0,

        // *************************************
        // *                                   *
        // *         PsHost Messages           *
        // *                                   *
        // *************************************

        /// <summary>
        /// Indicates a message of type ExitMessage
        /// </summary>
        Exit = 100,

        // *************************************
        // *                                   *
        // *   PsHostUserInterface Messages    *
        // *                                   *
        // *************************************

        /// <summary>
        /// Indicates a message of type PromptMessage
        /// </summary>
        Prompt = 101,

        /// <summary>
        /// Indicates a message of type PromptForChoiceMessage
        /// </summary>
        PromptForChoice = 102,

        /// <summary>
        /// Indicates a message of type PromptForCredentialMessage
        /// </summary>
        PromptForCredential = 103,

        /// <summary>
        /// Indicates a message of type ReadLineMessage
        /// </summary>
        ReadLine = 104,

        /// <summary>
        /// Indicates a message of type ReadLineAsSecureStringMessage
        /// </summary>
        ReadLineAsSecureString = 105,

        /// <summary>
        /// Indicates a message of type WriteMessage
        /// </summary>
        Write = 106,

        /// <summary>
        /// Indicates a message of type WriteLineMessage
        /// </summary>
        WriteLine = 107,

        /// <summary>
        /// Indicates a message of type WriteProgressMessage
        /// </summary>
        WriteProgress = 108,

        // *************************************
        // *                                   *
        // *  PsHostRawUserInterface Messages  *
        // *                                   *
        // *************************************

        /// <summary>
        /// Indicates a message of type ClearBufferMessage
        /// </summary>
        ClearBuffer = 109,

        /// <summary>
        /// Indicates a message of type SetBackgroundColorMessage
        /// </summary>
        SetBackgroundColor = 110,

        /// <summary>
        /// Indicates a message of type SetBufferSizeMessage
        /// </summary>
        SetBufferSize = 111,

        /// <summary>
        /// Indicates a message of type SetForegroundColorMessage
        /// </summary>
        SetForegroundColor = 112,

        /// <summary>
        /// Indicates a message of type SetWindowSizeMessage
        /// </summary>
        SetWindowSize = 113,

        /// <summary>
        /// Indicates a message of type SetWindowTitleMessage
        /// </summary>
        SetWindowTitle = 114,

        // **********************
        // *                    *
        // *  Session Messages  *
        // *                    *
        // **********************

        /// <summary>
        /// Indicates a message of type SessionTerminatedMessage
        /// </summary>
        SessionTerminated = 115,

        // ***************************************************
        // *                                                 *
        // *   PsHostUserInterface User Response Messages    *
        // *                                                 *
        // ***************************************************

        /// <summary>
        /// Indicates response message type for Prompt
        /// </summary>
        PromptResponse = 120,

        /// <summary>
        /// Indicates response message type for Choice Prompt
        /// </summary>
        PromptChoiceResponse = 121,

        /// <summary>
        /// Indicates response message type for ReadLine
        /// </summary>
        ReadLineResponse = 122,

        /// <summary>
        /// Indicates response message type for ReadLineAsSecureString
        /// </summary>
        ReadLineAsSecureStringResponse = 123,

        /// <summary>
        /// Indicates response message type for PromptCredentialMessageReponse
        /// </summary>
        PromptCredentialResponse = 124,
    }
}
