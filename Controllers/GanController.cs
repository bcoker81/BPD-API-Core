using System;
using System.Collections.Generic;
using System.Linq;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/gan")]
    [ApiController]
    public class GanController : ControllerBase
    {
        private IUow _unitOfWork;

        public GanController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("getGans/{grantId}"),HttpGet]
        public IEnumerable<GANModel> GetGansByGrant(int grantId)
        {
            try
            {
                return _unitOfWork.GANRepository.Get(p => p.FK_Grant_Id == grantId);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);                
                return null;
            }
        }

        [Route("getGan/{ganId}"), HttpGet]
        public GANModel GetGan(int ganId){
            return _unitOfWork.GANRepository.Get(p => p.GANId == ganId).FirstOrDefault();
        }

        [Route("new"),HttpPost]
        public GANModel NewGan([FromBody] GANModel gan){
            try
            {
                _unitOfWork.GANRepository.Insert(gan);
                _unitOfWork.Save();
                return gan;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [Route("update/{id}"), HttpPut]
        public GANModel UpdateGan(GANModel gan){
            try
            {
                _unitOfWork.GANRepository.Update(gan);
                _unitOfWork.Save();
                return gan;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }
    }
}