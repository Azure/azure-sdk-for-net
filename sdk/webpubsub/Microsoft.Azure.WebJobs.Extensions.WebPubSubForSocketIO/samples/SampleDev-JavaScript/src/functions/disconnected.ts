import { app, InvocationContext, trigger } from "@azure/functions";

export async function disconnected(request: any, context: InvocationContext): Promise<void> {
    context.log(`SocketIO trigger for disconnected`);
}

// Trigger for disconnected
app.generic('disconnected', {
    trigger: trigger.generic({
        type: 'socketiotrigger',
        hub: 'hub',
        eventName: 'disconnected'
    }),
    handler: disconnected
});
