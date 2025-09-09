using Wpm.Management.Domain;
using Wpm.Management.Domain.Repository.Interfaces;

namespace Wpm.Infra.Data.Repository
{
    public class ManagementRepository(ManagementDbContext dbContext) : IManagementRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pet? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
