using StaffMicroService.Models;
using StaffMicroService.Models.Entities;
using StaffMicroService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Implements
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactRepository : FSRepository<Contact>, IContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public ContactRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public ContactRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        public async Task<Contact> GetSingleById(int _contactId, int _personalIdentityTypeId)
        {
            return await FindSingle(x => x.contactid == _contactId && x.personalidentitytypeid == _personalIdentityTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        public async Task<Contact> GetSingleByContactId(int _contactId)
        {
            return await FindSingle(x => x.contactid == _contactId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        public async Task<Contact> GetSingleByPersonalIdentityTypeId(int _personalIdentityTypeId)
        {
            return await FindSingle(x => x.personalidentitytypeid == _personalIdentityTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(Contact _entity, Contact _value)
        {
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
