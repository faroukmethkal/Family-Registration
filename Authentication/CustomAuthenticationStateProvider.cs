using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Assignment_1.Data;
using Assignment_1.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Assignment_1.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsonRuntime;
        private readonly IServerData serverData;
        private User cachedUser;

        public CustomAuthenticationStateProvider(IJSRuntime jsonRuntime, IServerData serverData)
        {
            this.jsonRuntime = jsonRuntime;
            this.serverData = serverData;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsonRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User tmp = JsonConvert.DeserializeObject<User>(userAsJson);
                    ValidateLogin(tmp.Username, tmp.Password);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }
        
        public async Task ValidateLogin(string username, string password) {
           
            if (string.IsNullOrEmpty(username)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(password)) throw new Exception("Enter password");

            ClaimsIdentity identity = new ClaimsIdentity();
            try {
                User user = await serverData.ValidateUser(username, password);
                
                identity = SetupClaimsForUser(user);
                string serialisedData = JsonConvert.SerializeObject(user);
                jsonRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
                cachedUser = user;
            } catch (Exception e) {
                throw e;
            }

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }
        public void Logout() {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsonRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        private ClaimsIdentity SetupClaimsForUser(User user) {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            claims.Add(new Claim("Role", user.Role));
            ClaimsIdentity identity = new ClaimsIdentity(claims, "apiauth_type");
            return identity;
        }

     
    }
}