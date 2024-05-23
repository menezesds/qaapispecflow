using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace qaapispecflow.StepDefinitions
{
    [Binding]
    public class HttpGetSingleUserRequestTest
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        string responseBody;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        public HttpGetSingleUserRequestTest(ISpecFlowOutputHelper _specFlowOutputHelper)
        {
            httpClient = new HttpClient();
            this._specFlowOutputHelper = _specFlowOutputHelper;
        }

        [Given(@"the user sends a get request with url as ""([^""]*)""")]
        public async Task WhenTheUserSendsAGetRequestWithUrlAs(string url)
        {
            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responseBody);
        }

        [Then(@"the request should be success and returnn status code (.*)")]
        public void ThenTheRequestShouldBeSuccessAndReturnnStatusCode(int statusCode)
        {
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(statusCode, (int)response.StatusCode);
        }

    }
}
