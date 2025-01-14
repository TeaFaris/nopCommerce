﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using FluentAssertions;
using Nop.Core.Http;
using NUnit.Framework;

namespace Nop.Tests.Nop.Services.Tests.Common;

[TestFixture]
internal class NopLinksDefaultsTests : ServiceTest
{
    private IHttpClientFactory _httpClientFactory;

    [OneTimeSetUp]
    public void SetUp()
    {
        _httpClientFactory = GetService<IHttpClientFactory>();
    }

    protected async Task TestUrlsAsync(IList<PropertyInfo> properties)
    {
        var client = _httpClientFactory.CreateClient(NopHttpDefaults.DefaultHttpClient);

        foreach (var propertyInfo in properties)
        {
            var url = propertyInfo.GetValue(null)?.ToString();

            if (string.IsNullOrEmpty(url))
                continue;

            var res = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            res.StatusCode.Should().BeOneOf(new[]
            {
                HttpStatusCode.OK , HttpStatusCode.Found
            }, $"{url} {res.ReasonPhrase}");
        }
    }
}