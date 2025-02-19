function foo() {
    return "Test content";
}

export function content(request) {
    return {
        statusCode: 200,
        body: {
            payload: foo(),
        },
    };
}
