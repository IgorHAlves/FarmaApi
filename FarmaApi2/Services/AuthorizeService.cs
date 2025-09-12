using System.Runtime.InteropServices.Marshalling;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FarmaApi2.DTOs;

namespace FarmaApi2.Services;

public class AuthorizeService
{
    public async Task<string> PostToken(PostTokenDTO dto)
    {
        using var client = new HttpClient();
        
        var url = "http://localhost:8080/realms/farmacia/protocol/openid-connect/token";
        
        var formData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id", "farmacia-api"),
            new KeyValuePair<string, string>("username", dto.Usuario),
            new KeyValuePair<string, string>("password", dto.Senha),
            new KeyValuePair<string, string>("client_secret", "DdyPeRA3FvocwpQQznJUPEhQOVbX7I7Z")
        });
        
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = formData
        };

        // Enviando a requisição
        var response = await client.SendAsync(request);

        // Lendo a resposta
        var responseBody = await response.Content.ReadAsStringAsync();
        
        return responseBody;
    }
    

}