using ExampleProject.Core.Repository;

namespace ExampleProject.Data.DataRepository
{
    public partial class DataRepository : IDataRepository
    {
        private readonly ExampleContext _dbContext;

        public DataRepository(ExampleContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
