using Wpm.Infra.Data;
using Wpm.Management.Application.Commands;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Application.Services
{
    public class ManagementApplicationService(IBreedService breedService, ManagementDbContext dbContext)
    {
        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.Id, breedService);
            var newPet = new Pet(
                              command.Id,
                              command.Name,
                              command.Age,
                              command.SexOfPet,
                              command.Color,
                              breedId
                              );
            await dbContext.Pets.AddAsync(newPet);
            await dbContext.SaveChangesAsync();
        }
    }
}
