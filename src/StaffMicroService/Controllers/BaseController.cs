using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FSLib.Http;
using StaffMicroService.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffMicroService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [ProducesResponseType(typeof(FSResponseMessage), 500)]
    [ProducesResponseType(typeof(FSResponseMessage), 404)]
    [ProducesResponseType(typeof(FSResponseData<Dictionary<string, string>>), 422)]
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected FSHttpResult httpResult;

        /// <summary>
        /// 
        /// </summary>
        protected IUnitOfWork unitOfWorks;

        /// <summary>
        /// 
        /// </summary>
        public BaseController(IUnitOfWork _unitOfWork)
        {
            unitOfWorks = _unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ObjectResult FSHttpResponse(FSHttpResult result)
        {
            ObjectResult _object = new ObjectResult(result);

            _object.StatusCode = result.GetResponseStatusCode();
            _object.Value = result;

            return _object;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            unitOfWorks.Dispose();
            base.Dispose(disposing);
        }
    }
}
