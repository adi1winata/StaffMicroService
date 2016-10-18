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
    [Route("api/contacts")]
    public class ContactsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public ContactsController(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(FSResponseData<IEnumerable<Contact>>), 200)]
        public async Task<IActionResult> Get([FromQuery]int page = 1, [FromQuery]int size = 10)
        {
            page = (page < 1) ? 1 : page;
            size = (size < 1) ? 10 : size;
            try
            {
                var _data = (await unitOfWorks.Contacts().Get()).Skip((page - 1) * size).Take(size);
                httpResult = new FSResponseData<IEnumerable<Contact>>(FSStatusCode.OK, FSStatusMessage.success, _data);
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
        /// <param name="contactid"></param>
        /// <param name="personalidentitytypeid"></param>
        /// <returns></returns>
        [HttpGet("contactid/{contactid}/personalidentitytypeid/{personalidentitytypeid}")]
        [ProducesResponseType(typeof(FSResponseData<Contact>), 200)]
        public async Task<IActionResult> GetSingleById([FromRoute]int contactid, [FromRoute]int personalidentitytypeid)
        {
            try
            {
                var _data = await unitOfWorks.Contacts().GetSingleById(contactid, personalidentitytypeid);
                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                }
                else
                {
                    httpResult = new FSResponseData<Contact>(FSStatusCode.OK, FSStatusMessage.success, _data);
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
        public async Task<IActionResult> Create([FromBody]Contact model)
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
                unitOfWorks.Contacts().Add(model);

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

        private async Task<bool> ValidateCreateModel(Contact _model)
        {
            var _personalIdentityType = await unitOfWorks.MemberPersonalIdentityTypes().GetSingleByPersonalidentityTypeId(_model.personalidentitytypeid);
            if (_personalIdentityType == null)
            {
                ModelState.AddModelError("personalidentitytypeid", "Personal Identity Type not found.");
            }

            return ModelState.IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactid"></param>
        /// <param name="personalidentitytypeid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("contactid/{contactid}/personalidentitytypeid/{personalidentitytypeid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Update([FromRoute]int contactid, [FromRoute]int personalidentitytypeid, [FromBody]Contact model)
        {
            if (model == null)
            {
                httpResult = new FSResponseMessage(FSStatusCode.BadRequest, FSStatusMessage.fail, HttpResponseMessageKey.ArgsNull);
                goto response;
            }

            try
            {
                var _data = await unitOfWorks.Contacts().GetSingleById(contactid, personalidentitytypeid);

                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                    goto response;
                }

                if (!await ValidateUpdateModel(contactid, personalidentitytypeid, model))
                {
                    var _modelState = ModelState
                        .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                        .ToDictionary(x => x.Key, x => x.Value.Errors[0].ErrorMessage);

                    httpResult = new FSResponseData<Dictionary<string, string>>(FSStatusCode.UnprocessableEntity, FSStatusMessage.fail, _modelState);
                    goto response;
                }

                unitOfWorks.Contacts().Update(_data, model);

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

        private async Task<bool> ValidateUpdateModel(int _contactId, int _personalidentitytypeid, Contact _model)
        {
            var _contact = await unitOfWorks.Contacts().GetSingleByContactId(_contactId);
            if (_contact == null)
            {
                ModelState.AddModelError("contact", "Contact not found.");
            }

            var _personalIdentityType = await unitOfWorks.MemberPersonalIdentityTypes().GetSingleByPersonalidentityTypeId(_personalidentitytypeid);
            if (_personalIdentityType == null)
            {
                ModelState.AddModelError("personalidentitytypeid", "Personal Identity Type not found.");
            }

            return ModelState.IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactid"></param>
        /// <param name="personalidentitytypeid"></param>
        /// <returns></returns>
        [HttpDelete("contactid/{contactid}/personalidentitytypeid/{personalidentitytypeid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Delete([FromRoute]int contactid, [FromRoute]int personalidentitytypeid)
        {
            try
            {
                var _data = await unitOfWorks.Contacts().GetSingleById(contactid, personalidentitytypeid);

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

                unitOfWorks.Contacts().Delete(_data);

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

        private async Task<bool> IsValidToDeleteModel(Contact _model)
        {
            return true;
        }
    }
}
