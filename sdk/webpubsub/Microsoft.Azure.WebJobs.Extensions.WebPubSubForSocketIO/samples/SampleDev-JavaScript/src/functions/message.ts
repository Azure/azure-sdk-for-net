import { app, InvocationContext, trigger, output } from "@azure/functions";

const socketio = output.generic({
  type: 'socketio',
  hub: 'hub',
})

export async function chat(request: any, context: InvocationContext): Promise<void> {
    context.log(`SocketIO trigger for newMessage`);
    context.extraOutputs.set(socketio, {
      actionName: 'sendToNamespace',
      namespace: '/',
      eventName: 'new message',
      parameters: [
        context.triggerMetadata.userId,
        context.triggerMetadata.message
      ],
      exceptRooms: [request.socketId],
    });
}

// Trigger for new message
app.generic('chat', {
    trigger: trigger.generic({
        type: 'socketiotrigger',
        hub: 'hub',
        eventName: 'chat',
        parameterNames: ['message'],
    }),
    extraOutputs: [socketio],
    handler: chat
});
