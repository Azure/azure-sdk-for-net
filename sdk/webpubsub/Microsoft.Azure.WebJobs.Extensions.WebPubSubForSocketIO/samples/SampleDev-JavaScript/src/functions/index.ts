import { app, HttpRequest, HttpResponseInit, InvocationContext } from "@azure/functions";

const fs = require('fs').promises;
const path = require('path')

export async function index(request: HttpRequest, context: InvocationContext): Promise<HttpResponseInit> {
    try {
        context.log(`Http function processed request for url "${request.url}"`);

        const filePath = path.join(__dirname,'../public/index.html');
        const html = await fs.readFile(filePath);
        return {
            body: html,
            headers: {
                'Content-Type': 'text/html'
            }
        };
    } catch (error) {
        context.log(error);
        return {
            status: 500,
            jsonBody: error
        }
    }
};

app.http('index', {
    methods: ['GET', 'POST'],
    authLevel: 'anonymous',
    handler: index
});
