using Newtonsoft.Json;
using qaapispecflow.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        [Given(@"the user sends a post request with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAPostRequestWithUrlAs(string url)
        {
            UserPostSuccess userPostSuccess = new UserPostSuccess()
            {
                Name = "Test Complete Name",
                Job = "Leader"
            };
            string data = JsonConvert.SerializeObject(userPostSuccess);
            var contentData = new StringContent(data);

            response = await httpClient.PostAsync(url, contentData);
            responseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responseBody);

        }

        [Given(@"the user sends a get request for single user with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAGetRequestWithUrlAs(string url)
        {
            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responseBody);
        }

        [Given(@"the user sends a get request for list users with url as ""([^""]*)""")]
        public async Task GivenTheUserSendsAGetRequestForListUsersWithUrlAs(string url)
        {
            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responseBody);         
        }

        [Then(@"the request should be success, return status code (.*) and displey thet total of users (.*)")]
        public void ThenTheRequestShouldBeSuccessAndReturnnStatusCode(int statusCode, int total)
        {
            var dsData = JsonConvert.DeserializeObject<DataModel>(responseBody);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(statusCode, (int)response.StatusCode);
            Assert.Equal(total, dsData?.Total);
        }

        [Then(@"the request should be success and return status code (.*)")]
        public void ThenTheRequestShouldBeSuccessAndReturnnStatusCode(int statusCode)
        {   
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(statusCode, (int)response.StatusCode);
        }

    }
}
