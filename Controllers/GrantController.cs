using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD01_WebApi_Core.Controllers
{
    [Route("api/service/grant")]
    [ApiController]
    public class GrantController : ControllerBase
    {
        private IUow _unitOfWork;

        public GrantController(IUow unitOfWork){
            _unitOfWork = unitOfWork;
        }

        [Route("getall"),HttpGet]
        public IActionResult GetAllGrants(){
            try
            {
                List<GrantModel> grantList = _unitOfWork.GrantRepository.Get();
                Console.WriteLine("Message returned successfully.");

                return Ok(grantList);
            }
            catch (System.Exception ex)
            {
              Console.WriteLine(ex.Message);
              return BadRequest();
            }
        }

        [Route("getDetails/{id}"),HttpGet]
        public IActionResult GetGrantDetails(int id)
        {
            try
            {
                Expression<Func<GrantModel, object>> comments = c => c.Comments;
                Expression<Func<GrantModel, object>> ldpr = l => l.LdprProjectNumbers;
                Expression<Func<GrantModel, object>> gans = g => g.GanList;
                Expression<Func<GrantModel, object>> reports = r => r.ReportDates;
                Expression<Func<GrantModel, object>> extensions = e => e.ExtensionDates;
                Expression<Func<GrantModel, object>> categories = c => c.Categories;
                Expression<Func<GrantModel, object>>[] parameterArray = new Expression<Func<GrantModel, object>>[] { comments, ldpr, gans, reports, extensions, categories };
                IEnumerable<GrantModel> grant = _unitOfWork.GrantRepository.Get(m => m.Id == id, includes: parameterArray);
                Console.WriteLine("Message returned successfully.");

                return Ok(grant);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Route("grantstatus/{search}")]
        public IEnumerable<GrantModel> GetGrantsByAStatus(int search){
            try
            {
                IEnumerable<GrantModel> grantList = new List<GrantModel>();
                grantList = _unitOfWork.GrantRepository.Get(p => p.Status == search).Where(p => p.IsDeleted == false);
                return grantList;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [Route("newGrant"), HttpPost]
        public IActionResult NewGrant([FromBody] GrantModel newGrant)
        {
            try
            {
                _unitOfWork.GrantRepository.Insert(newGrant);

                foreach (var comment in newGrant.Comments)
                {
                    _unitOfWork.CommentRepository.Insert(comment);
                }

                foreach (var report in newGrant.ReportDates)
                {
                    _unitOfWork.ReportRepository.Insert(report);
                }
                
                _unitOfWork.Save();
                Console.WriteLine("Message returned successfully.");
                return Ok("Message received successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }            
        }
    }
}