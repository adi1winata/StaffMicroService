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
    [Route("api/staffs")]
    public class StaffsController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_unitOfWork"></param>
        public StaffsController(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(FSResponseData<IEnumerable<Staff>>), 200)]
        public async Task<IActionResult> Get([FromQuery]int page = 1, [FromQuery]int size = 10)
        {
            page = (page < 1) ? 1 : page;
            size = (size < 1) ? 10 : size;
            try
            {
                var _data = (await unitOfWorks.Staffs().Get()).Skip((page - 1) * size).Take(size);
                httpResult = new FSResponseData<IEnumerable<Staff>>(FSStatusCode.OK, FSStatusMessage.success, _data);
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
        /// <param name="staffid"></param>
        /// <param name="contactid"></param>
        /// <param name="leaderid"></param>
        /// <returns></returns>
        [HttpGet("staffid/{staffid}/contactid/{contactid}/leaderid/{leaderid}")]
        [ProducesResponseType(typeof(FSResponseData<Staff>), 200)]
        public async Task<IActionResult> GetSingleById([FromRoute]int staffid,[FromRoute]int contactid,[FromRoute]int leaderid)
        {
            try
            {
                var _data = await unitOfWorks.Staffs().GetSingleById(staffid, contactid, leaderid);
                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                }
                else
                {
                    httpResult = new FSResponseData<Staff>(FSStatusCode.OK, FSStatusMessage.success, _data);
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
        public async Task<IActionResult> Create([FromBody]Staff model)
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
                unitOfWorks.Staffs().Add(model);

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

        private async Task<bool> ValidateCreateModel(Staff _model)
        {
            var _contact = await unitOfWorks.Contacts().GetSingleByContactId(_model.contactid);
            if (_contact == null)
            {
                ModelState.AddModelError("contactid", "Contact not found.");
            }

            return ModelState.IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffid"></param>
        /// <param name="contactid"></param>
        /// <param name="leaderid"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("staffid/{staffid}/contactid/{contactid}/leaderid/{leaderid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Update([FromRoute]int staffid, [FromRoute]int contactid, [FromRoute]int leaderid, [FromBody]Staff model)
        {
            if (model == null)
            {
                httpResult = new FSResponseMessage(FSStatusCode.BadRequest, FSStatusMessage.fail, HttpResponseMessageKey.ArgsNull);
                goto response;
            }

            try
            {
                var _data = await unitOfWorks.Staffs().GetSingleById(staffid, contactid, leaderid);

                if (_data == null)
                {
                    httpResult = new FSResponseMessage(FSStatusCode.NotFound, FSStatusMessage.fail, HttpResponseMessageKey.NotFound);
                    goto response;
                }

                if (!await ValidateUpdateModel(staffid, contactid, leaderid, model))
                {
                    var _modelState = ModelState
                        .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                        .ToDictionary(x => x.Key, x => x.Value.Errors[0].ErrorMessage);

                    httpResult = new FSResponseData<Dictionary<string, string>>(FSStatusCode.UnprocessableEntity, FSStatusMessage.fail, _modelState);
                    goto response;
                }

                unitOfWorks.Staffs().Update(_data, model);

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

        private async Task<bool> ValidateUpdateModel(int _staffid, int _contactid, int _leaderid, Staff _model)
        {
            var _contact = await unitOfWorks.Contacts().GetSingleByContactId(_model.contactid);
            if (_contact == null)
            {
                ModelState.AddModelError("contactid", "Contact not found.");
            }

            return ModelState.IsValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffid"></param>
        /// <param name="contactid"></param>
        /// <param name="leaderid"></param>
        /// <returns></returns>
        [HttpDelete("staffid/{staffid}/contactid/{contactid}/leaderid/{leaderid}")]
        [ProducesResponseType(typeof(FSResponseMessage), 200)]
        public async Task<IActionResult> Delete([FromRoute]int staffid, [FromRoute]int contactid, [FromRoute]int leaderid)
        {
            try
            {
                var _data = await unitOfWorks.Staffs().GetSingleById(staffid, contactid, leaderid);

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

                unitOfWorks.Staffs().Delete(_data);

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

        private async Task<bool> IsValidToDeleteModel(Staff _model)
        {
            return true;
        }
    }
}
