using System;
using System.Threading.Tasks;
using StaffMicroService.Repositories.Implements;

namespace StaffMicroService.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> Save();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ContactRepository Contacts();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ContactEmailAddressRepository ContactEmailAddresses();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        EmailAddressRepository EmailAddresses();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        MemberPersonalIdentityTypeRepository MemberPersonalIdentityTypes();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SalesBorrowerRepository SalesBorrowers();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        StaffRepository Staffs();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        UserContactRepository UserContacts();
    }
}
