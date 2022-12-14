using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadioFreeEurop.Apllication.Service.DTO;
using RadioFreeEurop.Apllication.Service.Helper;
using RadioFreeEurop.Apllication.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioFreeEroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonItemController : ControllerBase
    {
        private readonly IJsonItemDiffService _service;

        public JsonItemController(IJsonItemDiffService service)
        {
            _service = service;
        }

  

   
		[HttpPost]
        [Route("{id}/left")]
        public async Task<IActionResult> Left(string id, [FromBody] string jsonData)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(jsonData))
                return StatusCode(400,new DiffDataResponse  { Message = "Required data not found" });

            JsonItemDTO entity = new JsonItemDTO() { Id = id, Position = Domain.Enums.JsonItemEnum.Left, Data = jsonData };

            try
            {
                bool success = await _service.Save(entity);

                if (success)
                    return StatusCode(201, new DiffDataResponse() { Message = "OK" });
                else
                    return StatusCode(400, new DiffDataResponse() { Message = "Error when input data" });
            }
            catch (Exception)
            {
                //write log error
                return StatusCode(400, new DiffDataResponse() { Message = "Error when input data" });
            }

        }

		[HttpPost]
        [Route("{id}/right")]
        public async Task<IActionResult> Right(string id, [FromBody] string jsonData)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(jsonData))
                return StatusCode(200);

            JsonItemDTO entity = new JsonItemDTO() { Id = id, Position = Domain.Enums.JsonItemEnum.Right, Data = jsonData };

            try
            {
                bool success = await _service.Save(entity);

                if (success)
                    return StatusCode(201, new DiffDataResponse() { Message = "OK" });
                else
                    return StatusCode(400, new DiffDataResponse() { Message = "Error when input data" });
            }
            catch (Exception)
            {
                //write log error
                return StatusCode(400, "Error when input data");
            }

        }

       
		[HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Diff(string id)
        {
            if (string.IsNullOrEmpty(id))
                return StatusCode(400);

            try
            {
                JsonDiffDto diffResult = await _service.GetComparison(id);
                return StatusCode(200, diffResult);
            }
            catch (Exception)
            {
                return StatusCode(400, "Error when input data");
            }
        }

    }

}
