using System;
using System.Collections.Generic;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD01_WebApi_Core.Controllers
{
    [Route("api/service/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IUow _unitOfWork;

        public CommentController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("getall/{grantId}"),HttpGet]
        public IActionResult GetAllComments(int grantId){
            try
            {
                IEnumerable<CommentModel> commentList = _unitOfWork.CommentRepository.Get(p => p.FK_Grant_Id == grantId);
                Console.WriteLine("Message returned successfully.");

                return Ok(commentList);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [Route("new"), HttpPost]
        public IActionResult NewComment(CommentModel comment){
            try
            {
                _unitOfWork.CommentRepository.Insert(comment);
                Console.WriteLine("Message sent successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving message.");
                return BadRequest();
            }
        }
    }
}