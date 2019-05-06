using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/attachment")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
         private IUow _unitOfWork;
        private const string success = "Message returned successfully.";

        public AttachmentController(IUow unitOfwork){
            _unitOfWork = unitOfwork;
        }

        [Route("new"), HttpPost]
        public IActionResult New([FromBody] AttachmentModel attachment){
            try
            {
                _unitOfWork.AttachmentRepository.Insert(attachment);
                _unitOfWork.Save();
                return Ok(success);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("delete"), HttpPut]
        public IActionResult Delete([FromBody] ExpenditureModel attachment){
            try
            {
                _unitOfWork.AttachmentRepository.Delete(attachment);
                _unitOfWork.Save();
                return Ok(success);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("getall/{table}/{id}"), HttpGet]
        public IActionResult GetAll(string table, int id){
            try
            {
                IEnumerable<AttachmentModel> result = _unitOfWork.AttachmentRepository.Get(p => p.FK_Id == id).Where(p => p.FK_Table == table);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("get/{id}"), HttpGet]
        public IActionResult Get(int id){
            try
            {
                AttachmentModel result = _unitOfWork.AttachmentRepository.GetById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}