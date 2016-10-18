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
    public class UserContactRepository : FSRepository<UserContact>, IUserContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public UserContactRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public UserContactRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        public async Task<UserContact> GetSingleByContactId(int _contactId)
        {
            return await FindSingle(x => x.contactid == _contactId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        public async Task<UserContact> GetSingleById(int _userId, int _contactId)
        {
            return await FindSingle(x => x.userid == _userId && x.contactid == _contactId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public async Task<UserContact> GetSingleByUserId(int _userId)
        {
            return await FindSingle(x => x.userid == _userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(UserContact _entity, UserContact _value)
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
