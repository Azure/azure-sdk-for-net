import { app, HttpRequest, HttpResponseInit, InvocationContext, input, } from "@azure/functions";

const socketIONegotiate = input.generic({
    type: 'socketionegotiation',
    direction: 'in',
    name: 'result',
    hub: 'hub',
    userId: '{query.userId}'
});

export async function negotiate(request: HttpRequest, context: InvocationContext): Promise<HttpResponseInit> {
    context.log(`Http function processed request for url "${request.url}"`);

    let result = context.extraInputs.get(socketIONegotiate);
    return { jsonBody: result };
};

// Negotiation
app.http('negotiate', {
    methods: ['GET', 'POST'],
    authLevel: 'anonymous',
    extraInputs: [socketIONegotiate],
    handler: negotiate
});
