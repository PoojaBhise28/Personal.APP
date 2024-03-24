using PersonalApp.Data;
using PersonalApp.IRepository;
using PersonalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalApp.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(MyAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
