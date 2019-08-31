## *this project has been archived and is no longer in development ##
# Calamari Blog
A light-weight blogging client written in Angular and ASP.NET Core that reads from a headless CMS system called Squidex.


- Based off the the ASP.NET Core template for [Angular](https://angular.io/) included in Visual Studio 2017
- Serilog is used for logging events to [any location](https://github.com/serilog/serilog/wiki/Provided-Sinks) 
- Responses are gzipped
- Uses the [Milligram](http://milligram.io/) CSS framework

Caching
-------

The client will query the Squidex API for content when needed and cache it to an ICacheProvider. Cached items are cleared via a Webhook configured in Squidex.
