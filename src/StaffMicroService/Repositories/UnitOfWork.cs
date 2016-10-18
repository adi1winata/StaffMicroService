using Microsoft.Extensions.Configuration;
using StaffMicroService.Models;
using System;
using System.Threading.Tasks;
using StaffMicroService.Repositories.Implements;

namespace StaffMicroService.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        internal ApplicationDbContext context;

        internal IConfiguration config;        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public UnitOfWork(ApplicationDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }        

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Disposed(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DisposingProperties();
                }
            }

            disposed = true;
        }

        private void DisposingProperties()
        {
            if(context != null)
                context.Dispose();

            if (_contact != null)
                _contact.Dispose();

            if (_contactEmailAddresses != null)
                _contactEmailAddresses.Dispose();

            if (_emailAddresses != null)
                _emailAddresses.Dispose();

            if (_memberPersonalIdentityTypes != null)
                _memberPersonalIdentityTypes.Dispose();

            if (_salesBorrowers != null)
                _salesBorrowers.Dispose();

            if (_staffs != null)
                _staffs.Dispose();

            if (_userContacts != null)
                _userContacts.Dispose();
        }

        private ContactRepository _contact;
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContactRepository Contacts()
        {
            if (_contact == null)
            {
                _contact = new ContactRepository(context);
            }
            return _contact;
        }

        private ContactEmailAddressRepository _contactEmailAddresses;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ContactEmailAddressRepository ContactEmailAddresses()
        {
            if (_contactEmailAddresses == null)
            {
                _contactEmailAddresses = new ContactEmailAddressRepository(context);
            }
            return _contactEmailAddresses;
        }

        private EmailAddressRepository _emailAddresses;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public EmailAddressRepository EmailAddresses()
        {
            if (_emailAddresses == null)
            {
                _emailAddresses = new EmailAddressRepository(context);
            }
            return _emailAddresses;
        }

        private MemberPersonalIdentityTypeRepository _memberPersonalIdentityTypes;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MemberPersonalIdentityTypeRepository MemberPersonalIdentityTypes()
        {
            if (_memberPersonalIdentityTypes == null)
            {
                _memberPersonalIdentityTypes = new MemberPersonalIdentityTypeRepository(context);
            }
            return _memberPersonalIdentityTypes;
        }


        private SalesBorrowerRepository _salesBorrowers;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SalesBorrowerRepository SalesBorrowers()
        {
            if (_salesBorrowers == null)
            {
                _salesBorrowers = new SalesBorrowerRepository(context);
            }
            return _salesBorrowers;
        }

        private StaffRepository _staffs;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StaffRepository Staffs()
        {
            if (_staffs == null)
            {
                _staffs = new StaffRepository(context);
            }
            return _staffs;
        }

        private UserContactRepository _userContacts;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserContactRepository UserContacts()
        {
            if (_userContacts == null)
            {
                _userContacts = new UserContactRepository(context);
            }
            return _userContacts;
        }
    }
}
