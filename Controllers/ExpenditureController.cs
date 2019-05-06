using System.Collections.Generic;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/expenditure")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
       private IUow _unitOfWork;
        private const string success = "Message returned successfully.";
        public ExpenditureController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("new")]
        public IActionResult New([FromBody] ExpenditureModel expenditure){
            try
            {
                _unitOfWork.ExpenditureRepository.Insert(expenditure);
                _unitOfWork.Save();
                return Ok(success);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("getall/{catId}"), HttpGet]
        public IActionResult GetAll(int catId){
            try
            {
                IEnumerable<ExpenditureModel> result = _unitOfWork.ExpenditureRepository.Get(p => p.FK_Category_Id == catId);
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
                ExpenditureModel result = _unitOfWork.ExpenditureRepository.GetById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("update"), HttpPut]
        public IActionResult Update([FromBody] ExpenditureModel expenditure){
            try
            {
                _unitOfWork.ExpenditureRepository.Update(expenditure);
                _unitOfWork.Save();
                return Ok(success);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [Route("delete/{id}"), HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                ExpenditureModel result = _unitOfWork.ExpenditureRepository.GetById(id);
                _unitOfWork.ExpenditureRepository.Delete(result);
                _unitOfWork.Save();
                return Ok(success);
            }
            catch (System.Exception)
            {
                return BadRequest();
                throw;
            }
        }
    }
}