# Service driven evolution

Some changes in Rest API are not breaking changes but could cause breaking changes in the generated SDK. In order to make the SDK backward compatible, we can add customized code such as overload methods. The following sections will show some examples of such scenarios and how to handle them.

## A method gets a new optional parameter

Generated code in a V1 client:

Generated code in a V2 client:

Add manual code in V2 so that V2 is backward compatible with V1:
Here we make the optional

## A new method is added (new path)

## A new method is added (path existed in the Swagger)

## A new body type is added (was JSON, and now JSON + JPEG)
