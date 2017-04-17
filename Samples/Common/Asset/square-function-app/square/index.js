module.exports = function (context, req) {
    context.log('JavaScript HTTP trigger function processed a request.');

    var num = parseInt(req.body);

    if (isNaN(num)) {
        context.res = {
            status: 400,
            body: req.body + " is not a number!"
        };
    }
    else {
        context.res = {
            status: 200,
            body: num * num
        }
    }
    context.done();
};