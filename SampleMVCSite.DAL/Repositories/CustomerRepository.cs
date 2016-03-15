using SampleMVCSite.DAL.Data;
using SampleMVCSite.Models;
using System;

namespace SampleMVCSite.DAL.Repositories
{
    public class CustomerRepository:RepositoryBase<Customer>
    {
        public CustomerRepository(DataContext context):base(context)
        {
            if (context==null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
