using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        Task<Contact> GetSingleById(int _contactId, int _personalIdentityTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        Task<Contact> GetSingleByContactId(int _contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_personalIdentityTypeId"></param>
        /// <returns></returns>
        Task<Contact> GetSingleByPersonalIdentityTypeId(int _personalIdentityTypeId);

    }
}
