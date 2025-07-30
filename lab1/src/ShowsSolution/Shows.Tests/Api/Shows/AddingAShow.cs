using Alba;
using Microsoft.Extensions.Hosting;
using Shows.Tests.Api.Fixtures;
using static Shows.Api.Shows.Controller;

namespace Shows.Tests.Api.Shows;

[Collection("SystemTestFixture")]
[Trait("Category", "SystemTest")]
public class AddingAShow(SystemTestFixture fixture)
{
    private readonly IAlbaHost _host = fixture.Host;

    [Fact]
    public async Task AddShow() 
    {
        var showToCreate = new AddShowRequest
        {
            Name = "Breaking Bad",
            Description = "Best show ever",
            StreamingService = "Paramount+"
        };

        var response = await _host.Scenario(async myApi =>
        {
            myApi.Post.Json(showToCreate).ToUrl("/shows");
            myApi.StatusCodeShouldBeOk();
        });

        var postBodyResponse = await response.ReadAsJsonAsync<AddShowResponse>();

        Assert.NotNull(postBodyResponse);

        var getResponse = await _host.Scenario(myApi =>
        {
            myApi.Get.Url($"/shows/{postBodyResponse.Id}");
            myApi.StatusCodeShouldBeOk();
        });


        var getResponseBody = await getResponse.ReadAsJsonAsync<AddShowResponse>();

        Assert.NotNull(getResponseBody);


        Assert.Equal(postBodyResponse, getResponseBody);
    }
    
}