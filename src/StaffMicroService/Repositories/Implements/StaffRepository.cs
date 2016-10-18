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
    public class StaffRepository : FSRepository<Staff>, IStaffRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public StaffRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public StaffRepository(ApplicationDbContext _context) : base(_context) { }

        public async Task<Staff> GetSingleByContactId(int _contactId)
        {
            return await FindSingle(x => x.contactid == _contactId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <param name="_contactId"></param>
        /// <param name="_leaderId"></param>
        /// <returns></returns>
        public async Task<Staff> GetSingleById(int _staffId, int _contactId, int _leaderId)
        {
            return await FindSingle(x => x.staffid == _staffId && x.contactid == _contactId && x.leaderid == _leaderId);
        }

        public async Task<Staff> GetSingleByLeaderId(int _leaderId)
        {
            return await FindSingle(x => x.leaderid == _leaderId);
        }

        public async Task<Staff> GetSingleByStaffId(int _staffId)
        {
            return await FindSingle(x => x.staffid == _staffId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(Staff _entity, Staff _value)
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
