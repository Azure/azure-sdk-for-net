import { app, InvocationContext, trigger, output } from "@azure/functions";

const socketio = output.generic({
  type: 'socketio',
  hub: 'hub',
})

const connStore = new Map<string, object>();

export async function newMessage(request: any, context: InvocationContext): Promise<void> {
    context.log(`SocketIO trigger for newMessage`);
    context.extraOutputs.set(socketio, {
      actionName: 'sendToNamespace',
      namespace: '/',
      eventName: 'new message',
      parameters: [
        {
          username: "abc",
          message: request.parameters,
        }
      ],
      exceptRooms: [request.socketId],
    });
}

export async function addUser(request: any, context: InvocationContext): Promise<void> {
    context.log(`SocketIO trigger for adduser`);

    context.extraOutputs.set(socketio, [
        {
            actionName: 'sendToSocket',
            namespace: '/',
            socketId: request.socketId,
            eventName: 'login',
            parameters: [
                {
                    numUsers: 2,
                }
            ]
        },
        {
            actionName: 'sendToNamespace',
            namespace: '/',
            eventName: 'user joined',
            parameters: [
                {
                username: "abc",
                message: request.parameters,
                }
            ],
            exceptRooms: [request.socketId],
      }
    ]);
}

// Trigger for new message
app.generic('newMessage', {
    trigger: trigger.generic({
        type: 'socketiotrigger',
        hub: 'hub',
        eventName: 'new message'
    }),
    extraOutputs: [socketio],
    handler: newMessage
});

// Trigger for add user
app.generic('addUser', {
  trigger: trigger.generic({
      type: 'socketiotrigger',
      hub: 'hub',
      eventName: 'add user'
  }),
  extraOutputs: [socketio],
  handler: addUser
});