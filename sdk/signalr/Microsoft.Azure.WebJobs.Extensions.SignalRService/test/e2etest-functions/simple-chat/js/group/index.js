module.exports = async function (context, req) {
    context.bindings.signalRGroupActions = [req.body];
    context.done();
}