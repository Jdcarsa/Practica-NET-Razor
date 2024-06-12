﻿


using BaseLibrary.DTOs;
using ClienteLibreria.Services.Contracts;

namespace ClienteLibreria.Helpers
{
    public class CustomHttpHandler(GetHttpClient getHttpClient , LocalStorageService localStorageService , IUserAccountService accountService) : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool loginUrl = request.RequestUri!.AbsoluteUri.Contains("login");
            bool registerUrl = request.RequestUri!.AbsoluteUri.Contains("register");
            bool refreshTokenUrl = request.RequestUri!.AbsoluteUri.Contains("refresh-token");

            if(loginUrl ||  registerUrl || refreshTokenUrl) return await base.SendAsync(request, cancellationToken);

            var result = await base.SendAsync(request, cancellationToken);
            if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var stringToken = await localStorageService.GetToken();
                if (stringToken == null) { return result; }

                string token = string.Empty;
                try
                {
                    token = request.Headers.Authorization!.Parameter!;
                }
                catch
                {

                }

                var deserializeToekn = Serializations.DeserializeJsonString<UserSession>(stringToken);
                if(deserializeToekn is null) { return result; }
                if (string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",deserializeToekn.Token);
                    return await base.SendAsync(request, cancellationToken);
                }

                var newJwtToken = await GetReshToken(deserializeToekn.RefreshToken!);
                if(string.IsNullOrEmpty(newJwtToken)) { return result; }

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializeToekn.Token);
                return await base.SendAsync(request, cancellationToken);
            }
            return result;
        }

        private async Task<string> GetReshToken(string refreshToken)
        {
            var result = await accountService.RefreshTokenAsync(new RefreshToken()
            {
                Token = refreshToken
            });
            string serializedToken = Serializations.SerializeObj(new UserSession()
            {
                Token = result.token, RefreshToken = result.refreshToken
            });
            await localStorageService.SetToken(serializedToken);
            return result.token; ;
        }
    }
}
