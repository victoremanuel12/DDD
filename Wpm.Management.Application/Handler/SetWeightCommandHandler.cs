using Wpm.Infra.Data;
using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Services.Interfaces;

namespace Wpm.Management.Application.Handler
{
    public class SetWeightCommandHandler(ManagementDbContext dbContext, IBreedService breedService) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await dbContext.Pets.FindAsync(command.Id);
            if (pet is null)
                throw new InvalidOperationException($"Pet {command.Id} não encontrado.");
            pet.SetWeight(command.Weight, breedService);
            await dbContext.SaveChangesAsync();
        }
    }
}
