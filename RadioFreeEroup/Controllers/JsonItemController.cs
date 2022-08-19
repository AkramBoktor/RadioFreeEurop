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

  

        /// <summary>
		/// Handles the request to process data.
		/// </summary>
		/// <param name="id">Id to identify the request</param>
		/// <param name="data">The base64 encoded data in Json format</param>
		/// <returns>Data was stored</returns>
        /// <response code="201">When the data was stored</response>
        /// <response code="400">If the item is null or any error</response>
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

        /// <summary>
		/// Handles the request to process data.
		/// </summary>
		/// <param name="id">Id to identify the request</param>
		/// <param name="data">The base64 encoded data in Json format</param>
		/// <returns>Data was stored</returns>
        /// <response code="201">When the data was stored</response>
        /// <response code="400">If the item is null or any error</response>
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

        /// <summary>
		/// Request the comparison between two data sent as left and right (route) using same id. 
		/// </summary>
		/// <param name="id">Id of the request.</param>
		/// <returns><see cref="JsonDiffDto"/>Information about the comparison of the data.</returns>
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
