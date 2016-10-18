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
    public class EmailAddressRepository : FSRepository<EmailAddress>, IEmailAddressRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public EmailAddressRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public EmailAddressRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <param name="_memberEmailAddressTypeId"></param>
        /// <returns></returns>
        public async Task<EmailAddress> GetSingleById(int _emailAddressId, int _memberEmailAddressTypeId)
        {
            return await FindSingle(x => x.emailaddressid == _emailAddressId && x.memberemailaddresstypeid == _memberEmailAddressTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        public async Task<EmailAddress> GetSingleByEmailAddressId(int _emailAddressId)
        {
            return await FindSingle(x => x.emailaddressid == _emailAddressId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberEmailAddressTypeId"></param>
        /// <returns></returns>
        public async Task<EmailAddress> GetSingleByMemberEmailAddressTypeId(int _memberEmailAddressTypeId)
        {
            return await FindSingle(x => x.memberemailaddresstypeid == _memberEmailAddressTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(EmailAddress _entity, EmailAddress _value)
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
