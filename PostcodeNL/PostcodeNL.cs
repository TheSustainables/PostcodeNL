using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeNL {
    /// <summary>
    /// Represents a wrapper around the Postcode.NL Adress API.
    /// </summary>
    public class AddressApi {
        private readonly HttpClient Client;
        private readonly Uri ApiUrl = new Uri("https://api.postcode.nl/rest/addresses/");
        private readonly string ApiKey;
        private readonly string ApiSecret;

        /// <summary>
        /// Initializes a new instance of the AddressApi class.
        /// </summary>
        /// <param name="apiKey">The API key</param>
        /// <param name="apiSecret">The API secret</param>
        public AddressApi(string apiKey, string apiSecret) {
            ApiKey = apiKey;
            ApiSecret = apiSecret;
            Client = new HttpClient();

            var byteArray = Encoding.ASCII.GetBytes(ApiKey + ":" + ApiSecret);
            var authHeader = Convert.ToBase64String(byteArray);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
        }

        /// <summary>
        /// Execute an adress lookup
        /// </summary>
        /// <param name="postCode">Four number neighborhoodcode plus two character lettercombination</param>
        /// <param name="houseNumber">House number. Range: 0-99999</param>
        /// <param name="houseNumberAddition">Addition of the house number to uniquely define a location</param>
        /// <returns>A PostcodeResponse object.</returns>
        public async Task<PostcodeResponse> LookupAsync(string postCode, int houseNumber, string houseNumberAddition = null) {
            var requestUrl = ApiUrl.ToString() + postCode + "/" + houseNumber.ToString();
            if (!string.IsNullOrWhiteSpace(houseNumberAddition)) {
                requestUrl += "/" + houseNumberAddition;
            }

            var httpResponse = await Client.GetAsync(requestUrl).ConfigureAwait(false);
            PostcodeResponse response;

            if (httpResponse.IsSuccessStatusCode) {
                response = await httpResponse.Content.ReadAsAsync<PostcodeResponse>();
                response.IsSuccess = true;
            }
            else {
                response = new PostcodeResponse { IsSuccess = false };
            }

            return response;
        }
    }
}