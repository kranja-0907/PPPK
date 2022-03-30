using CosmosStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CosmosStorage.Dao
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Person>> GetPeopleAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task AddPersonAsync(Person person);
        Task DeletePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
    }
}