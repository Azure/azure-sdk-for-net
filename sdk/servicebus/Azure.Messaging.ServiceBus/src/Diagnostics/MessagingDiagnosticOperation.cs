// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Shared;

internal readonly partial struct MessagingDiagnosticOperation
{
    public static MessagingDiagnosticOperation RenewMessageLock = new("renew_message_lock");
    public static MessagingDiagnosticOperation RenewSessionLock = new("renew_session_lock");
    public static MessagingDiagnosticOperation GetSessionState = new("get_session_state");
    public static MessagingDiagnosticOperation SetSessionState = new("set_session_state");
    public static MessagingDiagnosticOperation Settle = new("settle");
    public static MessagingDiagnosticOperation CreateRule = new("create_rule");
    public static MessagingDiagnosticOperation DeleteRule = new("delete_rule");
    public static MessagingDiagnosticOperation GetRules = new("get_rules");
    public static MessagingDiagnosticOperation CancelScheduled = new("cancel_scheduled");
}