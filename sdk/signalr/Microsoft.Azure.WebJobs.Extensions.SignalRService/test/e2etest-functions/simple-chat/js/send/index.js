module.exports = async function (context, req) {
    context.bindings.signalRMessages = [req.body];
    context.done();
}