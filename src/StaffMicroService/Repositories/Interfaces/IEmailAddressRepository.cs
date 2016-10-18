using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmailAddressRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <param name="_memberEmailAddressTypeId"></param>
        /// <returns></returns>
        Task<EmailAddress> GetSingleById(int _emailAddressId, int _memberEmailAddressTypeId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_emailAddressId"></param>
        /// <returns></returns>
        Task<EmailAddress> GetSingleByEmailAddressId(int _emailAddressId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_memberEmailAddressTypeId"></param>
        /// <returns></returns>
        Task<EmailAddress> GetSingleByMemberEmailAddressTypeId(int _memberEmailAddressTypeId);
    }
}
