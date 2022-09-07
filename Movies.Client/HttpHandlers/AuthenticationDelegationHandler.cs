using IdentityModel.Client;

namespace Movies.Client.HttpHandlers
{
    public class AuthenticationDelegationHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ClientCredentialsTokenRequest _clientCredentialsTokenRequest;

        public AuthenticationDelegationHandler(ClientCredentialsTokenRequest clientCredentialsTokenRequest, IHttpClientFactory httpClientFactory)
        {
            _clientCredentialsTokenRequest = clientCredentialsTokenRequest ?? throw new ArgumentNullException(nameof(clientCredentialsTokenRequest));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("IDPClient");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(_clientCredentialsTokenRequest, cancellationToken);
            if (tokenResponse.IsError)
            {
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }
            request.SetBearerToken(tokenResponse.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
