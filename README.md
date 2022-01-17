# dnsclient-api
A .NET core API built using Swagger, DnsClient.NET, and Rollbar.

Saw someone post on UpWork that they wanted an API to retrieve DNS information for a domain, specifically TXT records. I never heard back from them, so I took on the challenge anyway. I created this is in less than 24 hours spread out over 2 days. Its free for anyone to use now but remember it’s still rough around the edges.

I created a YAML file built on OpenAPI 3.0 standards for my endpoints(paths) and models. I generated the stub code on https://editor.swagger.io/ then tweaked, fixed, and updated the code. Creating the stub code really gives a great head start.

I kept authentication simple, it’s using an API key sent in the header request. Currently the API key is hardcoded to "1" but maybe later I'll use a database or something to store API keys. I might host this somewhere if it’s something I find interesting to host. Tie it maybe to a MySQL/MariaDB database.

The library being used to retrieve DNS information is called DnsClient.NET https://github.com/MichaCo/DnsClient.NET and available as a nuget package.

I'm also using https://rollbar.com/ which is an easy way to log errors and information. Maybe if I host it on Azure I'll use Application Insights.

There are 3 available endpoints for A, MX, and TXT records.


![alt text](https://xavier.cc/wp-content/uploads/2022/01/DnsApiCapture1.jpg)

![alt text](https://xavier.cc/wp-content/uploads/2022/01/DnsApiCapture2.jpg)
