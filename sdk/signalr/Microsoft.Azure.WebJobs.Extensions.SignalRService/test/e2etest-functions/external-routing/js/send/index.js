module.exports = async function (context, req, endpoints) {
    var id = req.query.endpointId;
    var target = req.query.target;
    var endpoint = endpoints[id % endpoints.length];
    context.bindings.signalRMessages = [{
        "target": target,
        "endpoints": [endpoint],
        "arguments": [endpoint]
    }];

    context.done();
}