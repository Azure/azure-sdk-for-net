import "@typespec/http";

using TypeSpec.Http;

@service(#{ title: "Hello World" })
namespace HelloWorld.Service;

/** A simple greeting model. */
model Greeting {
  /** The greeting message. */
  message: string;
}

/** Returns a greeting. */
@route("/hello")
@get
op getGreeting(): Greeting;
