import { app } from '@azure/functions';

app.setup({
    enableHttpStream: true,
});
