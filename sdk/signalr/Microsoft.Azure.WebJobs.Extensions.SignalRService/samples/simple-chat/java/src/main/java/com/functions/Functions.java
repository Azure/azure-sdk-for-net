package com.functions;

import java.util.*;
import com.microsoft.azure.functions.annotation.*;
import com.microsoft.azure.functions.*;
import com.microsoft.azure.functions.signalr.annotation.*;
import com.microsoft.azure.functions.signalr.*;

public class Functions {
    @FunctionName("negotiate")
    public SignalRConnectionInfo negotiate(
            @HttpTrigger(
                name = "req", 
                methods = { HttpMethod.POST, HttpMethod.GET },
                authLevel = AuthorizationLevel.ANONYMOUS) 
                HttpRequestMessage<Optional<String>> req,
            @SignalRConnectionInfoInput(name = "connectionInfo", hubName = "simplechat", userId = "{headers.x-ms-signalr-userid}") SignalRConnectionInfo connectionInfo) {
                
        return connectionInfo;
    }

    @FunctionName("messages")
    public void sendMessage(
            @HttpTrigger(
                name = "req", 
                methods = { HttpMethod.POST },
                authLevel = AuthorizationLevel.ANONYMOUS) 
                HttpRequestMessage<ChatMessage> req,
            @SignalROutput(name = "sendMessages", hubName = "simplechat") OutputBinding<SignalRMessage> signalRMessage) {

        SignalRMessage message = new SignalRMessage("newMessage", req.getBody());
        message.groupName = req.getBody().groupname;
        message.userId = req.getBody().recipient;
        signalRMessage.setValue(message);
    }

    @FunctionName("addToGroup")
    public void addToGroup(
            @HttpTrigger(
                name = "req", 
                methods = { HttpMethod.POST },
                authLevel = AuthorizationLevel.ANONYMOUS) 
                HttpRequestMessage<ChatMessage> req,
            @SignalROutput(name = "addToGroup", hubName = "simplechat") OutputBinding<SignalRGroupAction> signalRGroupAction) {

        SignalRGroupAction groupAction = new SignalRGroupAction("add", req.getBody().groupname, req.getBody().recipient);
        signalRGroupAction.setValue(groupAction);
    }

    @FunctionName("removeFromGroup")
    public void removeFromGroup(
            @HttpTrigger(
                name = "req", 
                methods = { HttpMethod.POST },
                authLevel = AuthorizationLevel.ANONYMOUS) 
                HttpRequestMessage<ChatMessage> req,
            @SignalROutput(name = "removeFromGroup", hubName = "simplechat") OutputBinding<SignalRGroupAction> signalRGroupAction) {

        SignalRGroupAction groupAction = new SignalRGroupAction("remove", req.getBody().groupname, req.getBody().recipient);
        signalRGroupAction.setValue(groupAction);
    }

    public static class ChatMessage
    {
        public String sender;
        public String text;
        public String groupname;
        public String recipient;
        public Boolean isPrivate;
    }
}

