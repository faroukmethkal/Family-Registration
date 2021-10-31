using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Data
{
    public interface IServerData
    {
        Task<IList<Family>> getAllFamily();
        Task AddNewAdult(int fId, Adult adult);
        Task AdNewChild(int fId, Child child);
        Task AddNewPet(int fId, Pet pet);
        Task AddNewChildPet(int fId, int childId, Pet pet);

        Task UpdateAdult(int fId, Adult adult);
        Task UpdateChild(int fId, Child child);
        Task UpdatePet(int fId, Pet pet);
        Task UpdateChildPet(int fId, int childId, Pet pet);
        Task UpdateAddress(int fId, string StName, int HouseNumebr);

        Task<Adult> GetAdult(int fId, int id);
        Task<Child> GetChild(int fId, int id);
        Task<Pet> GetPet(int fId, int id);
        Task<Pet> GetChildPet(int fId, int childId, int id);


        Task RemoveAdult(int fId, int id);

        Task RemoveChild(int fId, int id);

        Task RemovePet(int fId, int id);

        Task RemoveChildPet(int fId, int childId, int id);

        Task<User> RegisterNewUser(User user);
        Task<User> ValidateUser(string userName, string password);
    }
}