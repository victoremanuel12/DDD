using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Application
{
    public record CreatePetCommand(Guid Id, string Name, string Color, SexOfPet SexOfPet, Guid BreedId);

}
