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
    public class SalesBorrowerRepository : FSRepository<SalesBorrower>, ISalesBorrowerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        public SalesBorrowerRepository() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public SalesBorrowerRepository(ApplicationDbContext _context) : base(_context) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_borrowerId"></param>
        /// <returns></returns>
        public async Task<SalesBorrower> GetSingleBorrowerId(int _borrowerId)
        {
            return await FindSingle(x => x.borrowerid == _borrowerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <param name="_borrowerId"></param>
        /// <returns></returns>
        public async Task<SalesBorrower> GetSingleById(int _staffId, int _borrowerId)
        {
            return await FindSingle(x => x.staffid == _staffId && x.borrowerid == _borrowerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_staffId"></param>
        /// <returns></returns>
        public async Task<SalesBorrower> GetSingleByStaffId(int _staffId)
        {
            return await FindSingle(x => x.staffid == _staffId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_entity"></param>
        /// <param name="_value"></param>
        public override void Update(SalesBorrower _entity, SalesBorrower _value)
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
