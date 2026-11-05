<!-- BEGIN MICROSOFT SECURITY.MD V0.0.5 BLOCK -->

## Security

Microsoft takes the security of our software products and services seriously, which includes all source code repositories managed through [our GitHub organizations](https://opensource.microsoft.com/), which include [Microsoft](https://github.com/Microsoft), [Azure](https://github.com/Azure), [DotNet](https://github.com/dotnet), and [AspNet](https://github.com/aspnet).  

If you believe you have found a security vulnerability in any Microsoft-owned repository that meets [Microsoft's definition of a security vulnerability](https://learn.microsoft.com/previous-versions/tn-archive/cc751383(v=technet.10)), please report it to us as described in [Reporting Security Issues](#reporting-security-issues).

## Policy

Microsoft follows the principle of [Coordinated Vulnerability Disclosure](https://www.microsoft.com/msrc/cvd).

## Reporting Security Issues

> [!IMPORTANT]
> **Please do not report security vulnerabilities through public GitHub issues.**

Instead, please report them to the Microsoft Security Response Center (MSRC) at [https://msrc.microsoft.com/report/vulnerability/new](https://msrc.microsoft.com/report/vulnerability/new).

If you are unable to sign in, follow the alternative submission instructions on the [MSRC reporting page](https://msrc.microsoft.com/report/vulnerability/new).

You should receive a response within 24 hours. If for some reason you do not, please follow up via email to ensure we received your original message. Additional information can be found at [microsoft.com/msrc](https://www.microsoft.com/msrc).

### Evidence Required for a Report

Please include the following information to help us understand the nature and scope of the possible issue. This information will help us triage your report more quickly.

* Type of issue (e.g. buffer overflow, SQL injection, cross-site scripting, etc.)

* The affected client or tool and full paths of source files related to the issue

* The exact revision of the affected source code, with a direct URL if available. Eligible revisions are the current HEAD of `main` or an active feature branch.

* The attacker's access and the trust boundary crossed, including how input controlled by an untrusted party reaches the affected operation in its intended environment

* Any special configuration required to reproduce the issue, including diagnostic settings or caller customizations

* Step-by-step instructions and a reproducible demonstration of the issue

* Proof-of-concept or exploit code (if possible)

* Evidence of impact, including how an attacker might exploit the issue

Verify claims against the current code and authoritative service documentation, and clearly highlight what you could not verify. Reports must reproduce on an eligible revision, as findings limited to other revisions are not vulnerabilities or defense-in-depth enhancements. A hypothetical deployment or a caller deliberately supplying unsafe configuration is not sufficient evidence of a vulnerability.

### Preferred Languages

We prefer all communications to be in English.

## Trust Boundaries

Azure SDK clients are intentionally light and minimal. They are network clients with built-in retries, authentication hooks, and diagnostics. Their goal is to transform caller data into service requests and service responses into client results. Wherever possible, this data is intentionally treated as opaque. The clients are not a boundary for enforcing service security checks, business rules, or payload sanitization.  Likewise, the clients are not responsible for sanitizing or validating the service response.  Azure service responses are implicitly trusted by design.

### Scope of Reports

* An in-scope vulnerability report must demonstrate that an untrusted party can violate a security responsibility owned by an Azure SDK client or Azure SDK development infrastructure in their intended environments. The sections below, starting with [Service Requests and Responses](#service-requests-and-responses), identify the protections the SDK owns and those owned by services and callers.

* Do not report vulnerabilities or defense-in-depth enhancements that require first compromising the host environment, the network, or an Azure service. These preconditions already cross the relevant trust boundary.

* Do not report findings that require the authentication or authorization privileges of maintainers or trusted partners. Additional restrictions on actions available only to these trusted parties are, at most, low-risk and low-value defense-in-depth enhancements rather than vulnerabilities.

### Service Requests and Responses

* Azure SDK service clients use the credential supplied by the caller, whether it is a built-in Azure credential or a custom implementation. Authentication generally uses keys, SAS, or Microsoft Entra ID tokens. The clients treat these values as opaque and do not issue them, determine their validity, or evaluate the permissions they grant. The Azure service is responsible for validating the supplied authentication information and performing authorization.

* It is the responsibility of the Azure service to analyze, validate, and sanitize request payloads. Services cannot assume that an Azure SDK client is calling them and must enforce their own security boundaries.

* Azure SDK clients perform light client-side validation to ensure that requests are well-formed. They intentionally do not replicate service validation, as described in the [Azure SDK parameter validation guidelines](https://azure.github.io/azure-sdk/general_implementation.html#parameter-validation).

* It is the responsibility of the Azure service to ensure that returned data is valid and safe.

* Azure SDK clients implicitly trust responses from the configured service, including values used for protocol follow-up requests. They do not provide a security boundary against malicious or malformed service responses.

* It is the responsibility of callers to inspect, validate, and sanitize input and returned data before using it in ways that may impact their local environment. Callers must perform any additional validation and safety checks needed by their application.

### Client Configuration and the Host Environment

* Callers control the endpoints, credentials, and options used to configure a client. Callers are responsible for validating configured URLs to ensure that they correspond to the intended Azure resource.

* Azure does not publish an authoritative list of all service URLs, and some services support caller-owned domains. An Azure SDK client cannot determine whether an arbitrary configured URL belongs to an official Azure service.

* Azure SDK clients do not uniformly enforce HTTPS for every authentication mode; for example, key-based policies can send requests to a caller-configured HTTP endpoint. Individual clients or authentication policies may add HTTPS checks, while callers remain responsible for selecting HTTPS endpoints and not overriding certificate validation. Unsafe behavior resulting from caller configuration is not an SDK vulnerability.

* Azure SDK clients run within a host application and cannot guard against tampering by that environment. Their input, output, and behavior should not be trusted if the host environment may have been compromised.

For example, a demonstration in which the caller deliberately configures a client with an attacker-owned endpoint does not establish an SDK vulnerability. The caller has selected the destination rather than demonstrated a failure of an SDK protection.

### Safe Defaults and Customization

* Azure SDK clients are responsible for ensuring that their default configuration does not perform unsafe actions. For example, clients do not follow redirects by default.

  * An individual Azure SDK client may enable redirects when required by its service and is responsible for handling those redirects safely. Reports for redirect issues must identify the client that enables redirects and demonstrate a failure of its redirect protections. Scope the report to that client, not the presence of redirect support in shared pipeline infrastructure.

  * Before reporting a cross-host redirect issue, authoritatively confirm that the associated Azure service actually returns cross-host redirects and the associated client opts into them without the required local safety adjustments needed. Reports for cross-host redirect issues must identify the client that enables redirects and demonstrate a failure of its redirect protections. Scope the report to that client, not the presence of redirect support in shared pipeline infrastructure.

* Retry policies have safe defaults and can be disabled or tuned by the host application. Callers are responsible for choosing settings appropriate for their application's resource and availability requirements. Expected retry behavior, including delays caused by the configured policy, is not evidence of a denial-of-service vulnerability.

* Callers can override defaults and extend clients with custom behavior. When they do, they have sole responsibility for the security of those customizations, including any additional validation and sanitization they require.

### Diagnostic Logging and Telemetry

* The Azure SDK redacts and sanitizes industry-standard sensitive fields and well-known Azure sensitive fields in headers and URL components by default for diagnostic logging and telemetry. Request and response content logging is disabled by default and, when enabled, is not sanitized by the shared pipeline; callers must protect and redact that output as needed.

* An individual Azure SDK client is responsible for extending the diagnostic sanitizers when its associated service uses non-standard sensitive fields. For example, if an Azure service includes a SAS key in the response body, its associated client should ensure that value is sanitized. Reports for missed non-standard fields must identify the specific client package and demonstrate a failure of its service-specific sanitization. Scope the report to that client package, not the shared diagnostic infrastructure.

* Callers can opt into logging sensitive data and configure the sanitizers. For example, if a caller removes sanitization for the `Authorization` header, logging that value is a consequence of the caller's configuration and is not reportable as an SDK vulnerability.

* Diagnostic logging and telemetry operate within the context of the host application, which controls diagnostic destinations, storage, and access. Callers are responsible for protecting that output and performing any additional redaction their environment requires. If the application makes that output publicly accessible through its storage or logging configuration, that exposure is an application issue, not an SDK vulnerability.

### Development Tools and Automation

* Repository scripts, tools, actions, test runners, and pipeline configuration are intended for SDK development and automation. Development scripts are intentionally permissive to preserve flexibility and reduce friction during development. More restrictive input handling may offer defense-in-depth, but these enhancements are generally low-risk and low-value.

* Tools such as the Azure SDK test proxy and test frameworks are used locally by SDK developers and in GitHub Actions and Azure DevOps pipelines. They are not public-facing services or components intended for customer production applications.

* Azure services are required to maintain their specifications in the [Azure REST API specifications repository](https://github.com/Azure/azure-rest-api-specs). These specifications are the authoritative source for SDK generation and are implicitly trusted. Specifications obtained from other sources are non-authoritative, and callers are responsible for the risks of using them.

* Emitters, generator plugins, and other executable extensions run as code in the development environment. Callers are responsible for selecting trusted extensions. Loading an extension does not isolate its behavior, and any required isolation belongs to the host environment or sandbox rather than the SDK tool.

* Azure SDK pipeline and test runs in the ephemeral Azure DevOps sandbox have no access to secrets, Microsoft resources, or the company network. The sandbox also constrains resource use and limits execution time. The sandbox is the primary trust boundary.

* Findings confined to that sandbox are generally defense-in-depth enhancements rather than vulnerabilities. An exploit that depends on a failure of sandbox isolation is a flaw in the sandbox, not the SDK tooling running within it. Reports for such failures must target the sandbox rather than the SDK tool used to demonstrate them.

For example, a developer choosing a command for a local script to execute does not demonstrate an untrusted party crossing a boundary. When that script runs in a pipeline, the sandbox provides isolation rather than restrictions on the commands the script accepts.

Similarly, a developer passing a relative path such as `..\..\output` that resolves above the execution directory is not demonstrating a vulnerability. This applies whether the caller supplies the path directly or the tool reads it from an input file specified by the caller. The script or tool is honoring the caller's instructions, and the caller is responsible for validating paths from either source to prevent unintended access.

## Automated Security Scanning

AI-based scanners and other automated security tools must apply the [trust boundaries](#trust-boundaries) above before classifying or reporting a finding. Automated findings must meet the same [evidence requirements](#evidence-required-for-a-report) as other security reports.

Reporters are responsible for reviewing and validating generated findings before submitting them. A suspicious code pattern or an unverified model response is not evidence of a vulnerability.

* Run the proposed reproduction and confirm that its observed result supports the claimed impact.

* Check the generated analysis against the affected code and the intended environment. Confirm the attacker's access and the path across the identified trust boundary.

* Remove unsupported claims and state any remaining uncertainty. Do not present assumptions or model-generated conclusions as verified facts.

* Submit a concise report using the shared [evidence requirements](#evidence-required-for-a-report), rather than forwarding unreviewed scanner output.

<!-- END MICROSOFT SECURITY.MD BLOCK -->
