using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        Task<UserContact> GetSingleById(int _userId, int _contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_userId"></param>
        /// <returns></returns>
        Task<UserContact> GetSingleByUserId(int _userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        Task<UserContact> GetSingleByContactId(int _contactId);
    }
}
