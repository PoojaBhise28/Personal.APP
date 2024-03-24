using PersonalApp.Dto;
using PersonalApp.IRepository;
using PersonalApp.IService;
using PersonalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Service
{
    public class PersonService :IPersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<GetPerson> CreatePersonAsync(CreatePerson persondto)
        {
            var person = await _personRepository.CreateAsync
                            (new Person()  {firstName = persondto.firstName, lastName = persondto.lastName,mobileNumber = persondto.mobileNumber ,
                             phoneNumber = persondto.phoneNumber,description = persondto.description });

            return new GetPerson(person.Id,person.firstName, person.lastName, person.phoneNumber, person.mobileNumber, person.description);
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var isFound = await _personRepository.GetByIdAsync(id);
            if (isFound != null)
            {
                return await _personRepository.DeleteAsync(isFound);
            }

            return false;
        }

        public async Task<IEnumerable<GetPerson>> GetPerson()
        {
            var persons = await _personRepository.GetAllAsyc();
            var personDto = persons.Select(person => new GetPerson(person.Id, person.firstName, person.lastName, person.phoneNumber, person.mobileNumber, person.description));
            return personDto;
        }
    

        public async Task<GetPerson> GetPersonByIdAsync(int id)
        {

        var person = await _personRepository.GetByIdAsync(id);


        return new GetPerson(person.Id, person.firstName, person.lastName, person.phoneNumber, person.mobileNumber, person.description);

    }



    public async Task<GetPerson> UpdatePersonAsync(int id, UpdatePerson persondto)
        {
           var oldPerson = await _personRepository.GetByIdAsync(id);

            if(oldPerson != null)
            {
                oldPerson.firstName = persondto.firstName;
                oldPerson.lastName = persondto.lastName;
                oldPerson.mobileNumber= persondto.mobileNumber;
                oldPerson.phoneNumber= persondto.phoneNumber;
                oldPerson.description = persondto.description;
                await _personRepository.UpdateAsync(oldPerson);
                return new GetPerson(oldPerson.Id, oldPerson.firstName, oldPerson.lastName, oldPerson.phoneNumber, oldPerson.mobileNumber, oldPerson.description);
            

        }
            return null;
        }
    }
}
