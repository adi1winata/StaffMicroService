using System;
using System.Threading.Tasks;
using StaffMicroService.Models;
using StaffMicroService.Models.Entities;
using StaffMicroService.Repositories.Interfaces;

namespace StaffMicroService.Repositories.Implements
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactEmailAddressRepository : FSRepository<ContactEmailAddress>, IContactEmailAddressRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public ContactEmailAddressRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public ContactEmailAddressRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        public async Task<ContactEmailAddress> GetSingleByContactId(int _contactId)
        {
            return await FindSingle(x => x.contactid == _contactId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        public async Task<ContactEmailAddress> GetSingleByEmailAddressId(int _emailAddressId)
        {
            return await FindSingle(x => x.emailaddressid == _emailAddressId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        public async Task<ContactEmailAddress> GetSingleById(int _contactId, int _emailAddressId)
        {
            return await FindSingle(x => x.contactid == _contactId && x.emailaddressid == _emailAddressId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(ContactEmailAddress _entity, ContactEmailAddress _value)
        {
            _entity.isprimary = _value.isprimary;
            _entity.createdby = _value.createdby;
            _entity.createddate = _value.createddate;
            _entity.createdfrom = _value.createdfrom;
            _entity.modifiedby = _value.modifiedby;
            _entity.modifieddate = _value.modifieddate;
            _entity.modifiedfrom = _value.modifiedfrom;
            Update(_entity);
        }
    }
}
