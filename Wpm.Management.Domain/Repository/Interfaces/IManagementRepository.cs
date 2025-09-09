namespace Wpm.Management.Domain.Repository.Interfaces
{
    public interface IManagementRepository
    {
        Pet? GetById(Guid id);
        IEnumerable<Pet> GetAll();
        void Insert(Pet pet);
        void Update(Pet pet);
        void Delete(Guid id);

    }
}
