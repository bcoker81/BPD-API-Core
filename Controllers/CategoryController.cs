using System.Collections.Generic;
using System.Linq;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUow _unitOfWork;

        public CategoryController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("new"), HttpPost]
        public CategoryModel NewCategory([FromBody]CategoryModel category)
        {
            try
            {
                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Save();
                return category;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [Route("getByGrant/{grantId}"),HttpGet]
        public IEnumerable<CategoryModel> GetCategories(int grantId){
            try
            {
                return _unitOfWork.CategoryRepository.Get(p => p.FK_Grant_Id == grantId);
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        [Route("getCategory/{id}"),HttpGet]
        public CategoryModel GetCategory(int id){
            try
            {
                return _unitOfWork.CategoryRepository.Get(p => p.CatId == id).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [Route("update"),HttpPut]
        public CategoryModel UpdateCategory([FromBody] CategoryModel category){
            try
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return category;
            }
            catch (System.Exception ex)
            {
               return null;
            }
        }

        [Route("delete/{id}"),HttpGet]
        public void DeleteCategory(int id){
            try
            {
                _unitOfWork.CategoryRepository.Delete(id);
                _unitOfWork.Save();
            }
            catch (System.Exception ex)
            {
                
            }
        }
    }
}