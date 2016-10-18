using StaffMicroService.Models.Entities;
using System.Threading.Tasks;

namespace StaffMicroService.Repositories.Interfaces
{
    /// <summary>s
    /// 
    /// </summary>
    public interface ISalesBorrowerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <param name="_borrowerId"></param>
        /// <returns></returns>
        Task<SalesBorrower> GetSingleById(int _staffId, int _borrowerId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <returns></returns>
        Task<SalesBorrower> GetSingleByStaffId(int _staffId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_borrowerId"></param>
        /// <returns></returns>
        Task<SalesBorrower> GetSingleBorrowerId(int _borrowerId);
    }
}
