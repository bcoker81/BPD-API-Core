using System.Collections.Generic;
using BPD01_WebApi_Core.Domain;
using BPD01_WebApi_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BPD_API_Core.Controllers
{
    [Route("api/service/picklist")]
    [ApiController]
    public class PickListController : ControllerBase
    {
        private IUow _unitOfWork;

        public PickListController(IUow unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("new"), HttpPost]
        public PickListModel NewPicklistItem([FromBody] PickListModel list)
        {
            try
            {
                _unitOfWork.PickListRepository.Insert(list);
                _unitOfWork.Save();
                return list;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [Route("getList/{list}")]
        public IEnumerable<PickListModel> GetList(string list)
        {
            try
            {
                return _unitOfWork.PickListRepository.Get(p => p.PickList == list);
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}