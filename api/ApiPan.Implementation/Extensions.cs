using RestSharp;

namespace ApiPan.Implementation
{
    internal static class Extensions
    {
        internal static IRestResponse Execute(this IRestClient client, string resource)
        {
            return client.Execute(GetRequest(resource));
        }

        private static IRestRequest GetRequest(string resource = "")
        {
            IRestRequest request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            if (!string.IsNullOrEmpty(resource))
            {
                request.Resource = resource;
            }
            return request;
        }
    }
}
