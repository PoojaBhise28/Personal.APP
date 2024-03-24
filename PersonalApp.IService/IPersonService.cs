using PersonalApp.Dto;
using PersonalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.IService
{
    public interface IPersonService
    {

        public Task<IEnumerable<GetPerson>> GetPerson();

        public Task<GetPerson> GetPersonByIdAsync(int id);
        public Task<GetPerson> CreatePersonAsync(CreatePerson persondto);
       
        public Task<GetPerson> UpdatePersonAsync(int id , UpdatePerson persondto);

        public Task<bool> DeletePersonAsync(int id);

    }
}
