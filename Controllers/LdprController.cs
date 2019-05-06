using System.Collections.Generic;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/ldpr")]
    [ApiController]
    public class LdprController : ControllerBase
    {
        private IUow _unitOfWork;
        public LdprController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("new"), HttpPost]
        public IActionResult NewLdpr([FromBody] LdprModel ldpr){
            try
            {
                _unitOfWork.LdprRepository.Insert(ldpr);
                _unitOfWork.Save();
                return Ok("Message received successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [Route("update"), HttpPut]
        public IActionResult UpdateLdpr([FromBody] LdprModel model){
            try
            {
                _unitOfWork.LdprRepository.Update(model);
                _unitOfWork.Save();
                return Ok(model);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("delete/{id}"),HttpDelete]
        public IActionResult Delete(int id){
            try
            {
                _unitOfWork.LdprRepository.Delete(id);
                _unitOfWork.Save();
                return Ok("Message received successfully.");
            }
            catch (System.Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("get/{id}"), HttpGet]
        public IActionResult Get(int id){
            try
            {
                LdprModel result =  _unitOfWork.LdprRepository.GetById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("getAll/{grantId}"), HttpGet]
        public IActionResult GetAll(int grantId){
            try
            {
                IEnumerable<LdprModel> result = _unitOfWork.LdprRepository.Get(p => p.FK_Grant_Id == grantId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
    }
}