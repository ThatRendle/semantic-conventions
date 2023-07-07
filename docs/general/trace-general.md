<!--- Hugo front matter used to generate the website version of this page:
linkTitle: Trace
--->

# Trace Semantic Conventions

**Status**: [Experimental][DocumentStatus]

In OpenTelemetry spans can be created freely and it’s up to the implementor to
annotate them with attributes specific to the represented operation. Spans
represent specific operations in and between systems. Some of these operations
represent calls that use well-known protocols like HTTP or database calls.
Depending on the protocol and the type of operation, additional information
is needed to represent and analyze a span correctly in monitoring systems. It is
also important to unify how this attribution is made in different languages.
This way, the operator will not need to learn specifics of a language and
telemetry collected from polyglot (multi-language) micro-service environments
can still be easily correlated and cross-analyzed.

The following semantic conventions for spans are defined:

* **[General](general-attributes.md): General semantic attributes that may be used in describing different kinds of operations.**
* [Compatibility](trace-compatibility.md): For spans generated by compatibility components, e.g. OpenTracing Shim layer.
* [CloudEvents](/docs/cloudevents/README.md): Semantic Conventions for the CloudEvents spans.
* [Cloud Providers](/docs/cloud-providers/README.md): Semantic Conventions for cloud providers spans.
* [Database](/docs/database/database-spans.md): For SQL and NoSQL client call spans.
* [Exceptions](/docs/exceptions/exceptions-spans.md): For recording exceptions associated with a span.
* [FaaS](/docs/faas/faas-spans.md): For [Function as a Service](https://en.wikipedia.org/wiki/Function_as_a_service) (e.g., AWS Lambda) spans.
* [Feature Flags](/docs/feature-flags/feature-flags-spans.md): For recording feature flag evaluations associated with a span.
* [HTTP](/docs/http/http-spans.md): For HTTP client and server spans.
* [Messaging](/docs/messaging/messaging-spans.md): For messaging systems (queues, publish/subscribe, etc.) spans.
* [Object Stores](/docs/object-stores/README.md): Semantic Conventions for object stores spans.
* [RPC/RMI](/docs/rpc/rpc-spans.md): For remote procedure call (e.g., gRPC) spans.

Apart from semantic conventions for traces, [metrics](metrics-general.md), [logs](logs-general.md), and [events](events-general.md),
OpenTelemetry also defines the concept of overarching [Resources](https://github.com/open-telemetry/opentelemetry-specification/tree/v1.21.0/specification/resource/sdk.md) with their own
[Resource Semantic Conventions](/docs/resource/README.md).