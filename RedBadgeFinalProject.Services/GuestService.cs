using RedBadgeFinalProject.Data;
using RedBadgeFinalProject.Models.GuestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinalProject.Services
{
    public class GuestService
    {
        private readonly Guid _userId;

        public GuestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateGuest(GuestCreate model)
        {
            var entity =
                new Guest()
                {
                    OwnerId = _userId,
                    FullName = model.FullName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    IsAttending = model.IsAttending
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Guests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GuestListItem> GetGuests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Guests
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new GuestListItem
                            {
                                GuestId = e.GuestId,
                                FullName = e.FullName,
                                Address = e.Address,
                                IsAttending = e.IsAttending
                            }
                        );

                return query.ToArray();

            }
        }

        public GuestDetail GetGuestById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == id && e.OwnerId == _userId);
                return
                    new GuestDetail
                    {
                        GuestId = entity.GuestId,
                        FullName = entity.FullName,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber,
                        IsAttending = entity.IsAttending
                    };
            }

        }

        public bool UpdateGuest(GuestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == model.GuestId && e.OwnerId == _userId);

                entity.FullName = model.FullName;
                entity.Address = model.Address;
                entity.PhoneNumber = model.PhoneNumber;
                entity.IsAttending = model.IsAttending;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGuest(int guestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Guests
                        .Single(e => e.GuestId == guestId && e.OwnerId == _userId);

                ctx.Guests.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
