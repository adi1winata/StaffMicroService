using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffMicroService.Repositories;
using StaffMicroService.Models.Entities;
using FSLib.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffMicroService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/emailaddresses")]
    public class EmailAddressesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public EmailAddressesController(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(FSResponseData<IEnumerable<EmailAddress>>), 200)]
        public async Task<IActionResult> Get([FromQuery]int page = 1, [FromQuery]int size = 10)
        {
            page = (page < 1) ? 1 : page;
            size = (size < 1) ? 10 : size;
            try
            {
                var _data = (await unitOfWorks.EmailAddresses().Get()).Skip((page - 1) * size).Take(size);
                httpResult = new FSResponseData<IEnumerable<EmailAddress>>(FSStatusCode.OK, FSStatusMessage.success, _data);
            }
            catch (Exception ex)
            {
                httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, ex.Message);
            }
            return FSHttpResponse(httpResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailaddressid"></param>
        /// <param name="memberemailaddresstypeid"></param>
        /// <returns></returns>
        [HttpGet("emailaddressid/{emailaddressid}/memberemailaddresstypeid/{memberemailaddresstypeid}")]
        [ProducesResponseType(typeof(FSResponseData<EmailAddress>), 200)]
        public async Task<IActionResult> GetSingleById([FromRoute]int emailaddressid, [FromRoute]int memberemailaddresstypeid)
        {
            try
            {
                var _data = await unitOfWorks.EmailAddresses().GetSingleById(emailaddressid, memberemailaddresstypeid);
                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                }
                else
                {
                    httpResult = new FSResponseData<EmailAddress>(FSStatusCode.OK, FSStatusMessage.success, _data);
                }
            }
            catch (Exception ex)
            {
                httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, ex.Message);
            }

            return FSHttpResponse(httpResult);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Create([FromBody]EmailAddress model)
        {
            if (model == null)
            {
                httpResult = new FSResponseMessage(FSStatusCode.BadRequest, FSStatusMessage.fail, HttpResponseMessageKey.ArgsNull);
                goto response;
            }

            if (!await ValidateCreateModel(model))
            {
                var _modelState = ModelState
                    .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                    .ToDictionary(x => x.Key, x => x.Value.Errors[0].ErrorMessage);

                httpResult = new FSResponseData<Dictionary<string, string>>(FSStatusCode.UnprocessableEntity, FSStatusMessage.fail, _modelState);
                goto response;
            }

            try
            {
                model.Init();
                unitOfWorks.EmailAddresses().Add(model);

                int _status = await unitOfWorks.Save();
                if (_status == 1)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.OK, FSStatusMessage.success, HttpResponseMessageKey.DataSuccessfullyCreated);
                }
                else
                {
                    httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, HttpResponseMessageKey.DataUnsuccessfullyCreated);
                }
            }
            catch (Exception ex)
            {
                httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, ex.Message);
            }

            response:
            return FSHttpResponse(httpResult);
        }

        private async Task<bool> ValidateCreateModel(EmailAddress _model)
        {
            return ModelState.IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailaddressid"></param>
        /// <param name="memberemailaddresstypeid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("emailaddressid/{emailaddressid}/memberemailaddresstypeid/{memberemailaddresstypeid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Update([FromRoute]int emailaddressid, [FromRoute]int memberemailaddresstypeid, [FromBody]EmailAddress model)
        {
            if (model == null)
            {
                httpResult = new FSResponseMessage(FSStatusCode.BadRequest, FSStatusMessage.fail, HttpResponseMessageKey.ArgsNull);
                goto response;
            }

            try
            {
                var _data = await unitOfWorks.EmailAddresses().GetSingleById(emailaddressid, memberemailaddresstypeid);

                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                    goto response;
                }

                if (!await ValidateUpdateModel(emailaddressid, memberemailaddresstypeid, model))
                {
                    var _modelState = ModelState
                        .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                        .ToDictionary(x => x.Key, x => x.Value.Errors[0].ErrorMessage);

                    httpResult = new FSResponseData<Dictionary<string, string>>(FSStatusCode.UnprocessableEntity, FSStatusMessage.fail, _modelState);
                    goto response;
                }

                unitOfWorks.EmailAddresses().Update(_data, model);

                int _status = await unitOfWorks.Save();
                if (_status == 1)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.OK, FSStatusMessage.success, HttpResponseMessageKey.DataSuccessfullyUpdated);
                }
                else
                {
                    httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, HttpResponseMessageKey.DataUnsuccessfullyUpdated);
                }
            }
            catch (Exception ex)
            {
                httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, ex.Message);
            }

            response:
            return FSHttpResponse(httpResult);
        }

        private async Task<bool> ValidateUpdateModel(int _emailaddressid, int _memberemailaddresstypeid, EmailAddress _model)
        {
            var _emailAddress = await unitOfWorks.EmailAddresses().GetSingleByEmailAddressId(_emailaddressid);
            if (_emailAddress == null)
            {
                ModelState.AddModelError("emailAddressid", "Email address not found.");
            }
            return ModelState.IsValid;
        }

        [HttpDelete("emailaddressid/{emailaddressid}/memberemailaddresstypeid/{memberemailaddresstypeid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Delete([FromRoute]int emailaddressid, [FromRoute]int memberemailaddresstypeid)
        {
            try
            {
                var _data = await unitOfWorks.EmailAddresses().GetSingleById(emailaddressid, memberemailaddresstypeid);

                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                    goto response;
                }

                if (!await IsValidToDeleteModel(_data))
                {
                    httpResult = new FSResponseMessage(FSStatusCode.BadRequest, FSStatusMessage.fail, HttpResponseMessageKey.DataHaveReferenced);
                    goto response;
                }

                unitOfWorks.EmailAddresses().Delete(_data);

                int _status = await unitOfWorks.Save();
                if (_status == 1)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.OK, FSStatusMessage.success, HttpResponseMessageKey.DataSuccessfullyDeleted);
                }
                else
                {
                    httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, HttpResponseMessageKey.DataUnsuccessfullyDeleted);
                }
            }
            catch (Exception ex)
            {
                httpResult = new FSResponseMessage(FSStatusCode.InternalServerErrorException, FSStatusMessage.error, ex.Message);
            }

            response:
            return FSHttpResponse(httpResult);
        }

        private async Task<bool> IsValidToDeleteModel(EmailAddress _model)
        {
            return true;
        }
    }
}
