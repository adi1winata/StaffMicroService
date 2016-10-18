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
    public class MemberPersonalIdentityTypeRepository : FSRepository<MemberPersonalIdentityType>, IMemberPersonalIdentityTypeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public MemberPersonalIdentityTypeRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public MemberPersonalIdentityTypeRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberPersonalIdentityTypeId"></param>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        public async Task<MemberPersonalIdentityType> GetSingleById(int _memberPersonalIdentityTypeId, int _personalIdentityTypeId)
        {
            return await FindSingle(x => x.memberpersonalidentitytypeid == _memberPersonalIdentityTypeId && x.personalidentitytypeid == _personalIdentityTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberPersonalIdentityTypeId"></param>
        /// <returns></returns>
        public async Task<MemberPersonalIdentityType> GetSingleByMemberPersonalIdentityTypeId(int _memberPersonalIdentityTypeId)
        {
            return await FindSingle(x => x.memberpersonalidentitytypeid == _memberPersonalIdentityTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        public async Task<MemberPersonalIdentityType> GetSingleByPersonalidentityTypeId(int _personalIdentityTypeId)
        {
            return await FindSingle(x => x.personalidentitytypeid == _personalIdentityTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(MemberPersonalIdentityType _entity, MemberPersonalIdentityType _value)
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
