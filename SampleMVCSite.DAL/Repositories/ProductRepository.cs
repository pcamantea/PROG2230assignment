using SampleMVCSite.DAL.Data;
using SampleMVCSite.Models;
using System;

namespace SampleMVCSite.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        public ProductRepository(DataContext context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }//end ProductRepository

}//end namespace

