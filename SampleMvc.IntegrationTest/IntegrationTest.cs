using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SampleMvc.IntegrationTest;

public class IntegrationTest(WebApplicationFactory<Program> fixture) : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _fixture = fixture;

    [Theory]
    [InlineData(data: "api/Pet")]
    public async void Should_Return_Non_Document_Security_Headers(string requestUri)
    {
        var client = _fixture.CreateClient();

        var response = await client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();

        response.Headers.Should().HaveCount(3);
        response.Headers.Should().ContainKey("X-Content-Type-Options").WhoseValue.Should().BeEquivalentTo("nosniff");
        response.Headers.Should().ContainKey("Cross-Origin-Resource-Policy").WhoseValue.Should()
            .BeEquivalentTo("same-origin");
        response.Headers.Should().ContainKey("Pragma").WhoseValue.Should().BeEquivalentTo("no-cache");
    }
}