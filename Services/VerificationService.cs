using BlockVerify.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlockVerify.Services;

public class VerificationService
{
    private readonly HttpClient httpClient;
    public VerificationService()
    {
        httpClient = new HttpClient()
        {
            BaseAddress = new Uri(AppConstants.BaseUrl)
        };
    }

    public async Task<VerificationResult?> Verify(string code)
    {
        try
        {
            var result = await httpClient.GetAsync($"verify/document?client=mobile&cid={code}");
            if (!result.IsSuccessStatusCode)
            {
                return null;
            }

            VerificationResult? verificationResult = await result.Content.ReadFromJsonAsync<VerificationResult>();

            return verificationResult;
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex);
            return null;
        }

    }
}
