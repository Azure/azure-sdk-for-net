import { app, InvocationContext, input, trigger } from "@azure/functions";


export async function connect(request: any, context: InvocationContext): Promise<any> {
    context.log(`SocketIO trigger for connect`);
    return {};
}

// Trigger for connect
app.generic('connect', {
  trigger: trigger.generic({
    type: 'socketiotrigger',
    hub: 'hub',
    eventName: 'connect'
  }),
  handler: connect
});
