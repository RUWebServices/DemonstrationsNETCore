using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RentAWorld.Models.Dtos;
using RentAWorld.Models.Entities;
using RentAWorld.Models.InputModels;
using RentAWorld.Repositories.Data;

namespace RentAWorld.Repositories
{
    public class RentalRepository
    {
        public int CreateNewRental(RentalInputModel rental)
        {
            var nextId = DataProvider.Rentals.Count() + 1;
            var entity = Mapper.Map<Rental>(rental);
            entity.Id = nextId;
            DataProvider.Rentals.Add(entity);
            return nextId;
        }

        public void DeleteRental(RentalDto rental)
        {
            DataProvider.Rentals.Remove(Mapper.Map<Rental>(rental));
        }

        public IEnumerable<RentalDto> GetAllRentals(bool containUnavailable)
        {
            return Mapper.Map<IEnumerable<RentalDto>>(DataProvider.Rentals.Where(r => containUnavailable ? true : r.Available));
        }

        public RentalDto GetRentalById(int id)
        {
            return Mapper.Map<RentalDto>(DataProvider.Rentals.FirstOrDefault(r => r.Id == id));
        }

        public void UpdateRentalById(RentalInputModel rental, int id)
        {
            var updateRental = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);

            if (updateRental == null) { return; /* Throw some exception */ }

            // Update properties
            updateRental.Title = rental.Title;
            updateRental.Description = rental.Description;
            updateRental.AskingPrice = rental.AskingPrice;
            updateRental.Available = rental.Available.HasValue ? rental.Available.Value : false;
            updateRental.Address = rental.Address;
            updateRental.City = rental.City;
            updateRental.DateModified = DateTime.Now;
        }

        public void UpdateRentalPartiallyById(RentalInputModel rental, int id)
        {
            var updateRental = DataProvider.Rentals.FirstOrDefault(r => r.Id == id);

            if (updateRental == null) { return; /* Throw some exception */ }

            // Update properties (partially)
            if (!string.IsNullOrEmpty(rental.Address)) { updateRental.Address = rental.Address; }
            if (!string.IsNullOrEmpty(rental.Title)) { updateRental.Title = rental.Title; }
            if (!string.IsNullOrEmpty(rental.City)) { updateRental.City = rental.City; }
            if (!string.IsNullOrEmpty(rental.Description)) { updateRental.Description = rental.Description; }
            if (rental.AskingPrice > 0) { updateRental.AskingPrice = rental.AskingPrice; }
            if (rental.Available.HasValue) { updateRental.Available = rental.Available.Value; }
        }
    }
}