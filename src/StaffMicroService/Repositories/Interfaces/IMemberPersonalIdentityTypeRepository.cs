using StaffMicroService.Models.Entities;
using System.Threading.Tasks;


namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMemberPersonalIdentityTypeRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberPersonalIdentityTypeId"></param>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        Task<MemberPersonalIdentityType> GetSingleById(int _memberPersonalIdentityTypeId, int _personalIdentityTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberPersonalIdentityTypeId"></param>
        /// <returns></returns>
        Task<MemberPersonalIdentityType> GetSingleByMemberPersonalIdentityTypeId(int _memberPersonalIdentityTypeId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        Task<MemberPersonalIdentityType> GetSingleByPersonalidentityTypeId(int _personalIdentityTypeId);
    }
}
