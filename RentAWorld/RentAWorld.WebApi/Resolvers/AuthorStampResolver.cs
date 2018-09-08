using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;

namespace RentAWorld.WebApi.Resolvers
{
    public class AuthorStampResolver : IValueResolver<Rental, RentalDto, string>
    {
        public string Resolve(Rental source, RentalDto destination, string destMember, ResolutionContext context)
        {
            return $"{source.DateModified} - {source.ModifiedBy}";
        }
    }
}