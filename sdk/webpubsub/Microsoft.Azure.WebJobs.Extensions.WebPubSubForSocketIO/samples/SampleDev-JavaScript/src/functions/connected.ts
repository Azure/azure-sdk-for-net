import { app, InvocationContext, trigger } from "@azure/functions";

export async function connected(request: any, context: InvocationContext): Promise<void> {
    context.log(`SocketIO trigger for connected`);
}

// Trigger for connected
app.generic('connected', {
    trigger: trigger.generic({
        type: 'socketiotrigger',
        hub: 'hub',
        eventName: 'connected'
    }),
    handler: connected
});
