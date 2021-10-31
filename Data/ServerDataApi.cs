using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Assignment_1.Models;

namespace Assignment_1.Data
{
    public class ServerDataApi : IServerData
    {
        private IHttpClientFactory httpClientFactory;

        public ServerDataApi(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        

        public async Task<IList<Family>> getAllFamily(int? minAdultAge, int? maxAdultAge, bool? hasChild, bool?hasPet)
        {
            
            
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"families?minAdultAge={minAdultAge}&maxAdultAge={maxAdultAge}&hasChild={hasChild}&hasPet={hasPet}"); 
            

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch family Family");
            }

            var family = await response.Content.ReadAsStringAsync();

            var families = JsonConvert.DeserializeObject<IList<Family>>(family);


            return families;

        }

        public async Task AddNewAdult(int fId, Adult adult)
        {
            string requestBody = JsonConvert.SerializeObject(adult);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"adults?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Adult not added");
            }
        }

        public async Task AddNewChild(int fId, Child child)
        {
            string requestBody = JsonConvert.SerializeObject(child);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"children?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not added");
            }
        }

        public async Task AddNewPet(int fId, Pet pet)
        {
            string requestBody = JsonConvert.SerializeObject(pet);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"pets?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not added");
            }
        }

        public async Task AddNewChildPet(int fId, int childId, Pet pet)
        {
            string requestBody = JsonConvert.SerializeObject(pet);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"children/pets?fId={fId}&cId={childId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not added");
            }
        }

        public async Task UpdateAdult(int fId, Adult adult)
        {
            string requestBody = JsonConvert.SerializeObject(adult);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"adults?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Adult not updated");
            }
        }

        public async Task UpdateChild(int fId, Child child)
        {
            string requestBody = JsonConvert.SerializeObject(child);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"children?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not updated");
            }
        }

        public async Task UpdatePet(int fId, Pet pet)
        {
            string requestBody = JsonConvert.SerializeObject(pet);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"pets?fId={fId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not updated");
            }
        }

        public async Task UpdateChildPet(int fId, int childId, Pet pet)
        {
            string requestBody = JsonConvert.SerializeObject(pet);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"children/pets?fId={fId}&cId={childId}");
            httpRequestMessage.Content = new StringContent(requestBody);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("child not updated");
            }
        }

        public Task UpdateAddress(int fId, string StName, int HouseNumebr)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Adult> GetAdult(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"adults?fId={fId}&aId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch adult");
            }

            var adultjson = await response.Content.ReadAsStringAsync();

            var adult = JsonConvert.DeserializeObject<Adult>(adultjson);


            return adult;
        }

        public async Task<Child> GetChild(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"children?fId={fId}&id={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch child");
            }

            var childjson = await response.Content.ReadAsStringAsync();
            var child = JsonConvert.DeserializeObject<Child>(childjson);

            return child;
        }

        public async Task<Pet> GetPet(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"pets?fId={fId}&pId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch child");
            }

            var petjson = await response.Content.ReadAsStringAsync();
            var pet = JsonConvert.DeserializeObject<Pet>(petjson);

            return pet;
        }

        public async Task<Pet> GetChildPet(int fId, int childId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"children/pets?fId={fId}&cId={childId}&pId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch child");
            }

            var petjson = await response.Content.ReadAsStringAsync();
            var pet = JsonConvert.DeserializeObject<Pet>(petjson);

            return pet;
        }

        public async Task RemoveAdult(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete,
                $"adults?fId={fId}&aId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch adult");
            }
        }

        public async Task RemoveChild(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete,
                $"children?fId={fId}&cId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch child");
            }
        }

        public async Task RemovePet(int fId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete,
                $"pets?fId={fId}&pId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch pet");
            }
        }

        public async Task RemoveChildPet(int fId, int childId, int id)
        {
            HttpRequestMessage  httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete,
                $"children/pets?fId={fId}&cId={childId}&pId={id}");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (!response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                throw new Exception("Couldn't fetch pet");
            }
        }

        public async Task<User> RegisterNewUser(User user)
        {
            var serializerUser = JsonConvert.SerializeObject(user);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "users/register");
            httpRequestMessage.Content = new StringContent(serializerUser);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            var responseStautsCode = response.StatusCode.ToString().ToLower();
            if (responseStautsCode.Equals("ok"))
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                User userResponse = JsonConvert.DeserializeObject<User>(stringResponse);

                return userResponse;
            }

            return null;

        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User user = new User(userName, password);
            string seralizerUser = JsonConvert.SerializeObject(user);

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "users/login");
            httpRequestMessage.Content = new StringContent(seralizerUser);
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            var client = httpClientFactory.CreateClient("service");
            var response = await client.SendAsync(httpRequestMessage);
            if (response.StatusCode.ToString().ToLower().Equals("ok"))
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                User user1 = JsonConvert.DeserializeObject<User>(stringResponse);

                return user1;
            }

            return null;

        }
    }
}