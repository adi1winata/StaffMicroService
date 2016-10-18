using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStaffRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <param name="_contactId"></param>
        /// <param name="_leaderId"></param>
        /// <returns></returns>
        Task<Staff> GetSingleById(int _staffId, int _contactId, int _leaderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <returns></returns>
        Task<Staff> GetSingleByStaffId(int _staffId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        Task<Staff> GetSingleByContactId(int _contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_leaderId"></param>
        /// <returns></returns>
        Task<Staff> GetSingleByLeaderId(int _leaderId);
    }
}
