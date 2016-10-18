using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactEmailAddressRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        Task<ContactEmailAddress> GetSingleById(int _contactId, int _emailAddressId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_contactId"></param>
        /// <returns></returns>
        Task<ContactEmailAddress> GetSingleByContactId(int _contactId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        Task<ContactEmailAddress> GetSingleByEmailAddressId(int _emailAddressId);
    }
}
