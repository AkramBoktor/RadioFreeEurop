using RadioFreeEroup.Domain.Entities;
using RadioFreeEroup.Domain.Enums;
using RadioFreeEroup.Domain.Interfaces;
using RadioFreeEurop.Apllication.Service.DTO;
using RadioFreeEurop.Apllication.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioFreeEurop.Apllication.Service.Service
{
    public class JsonItemDiffService : IJsonItemDiffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JsonItemDiffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<JsonDiffDto> GetComparison(string id)
        {
            JsonItemDTO itemLeft = await Select(id, JsonItemEnum.Left);
            JsonItemDTO itemRight = await Select(id, JsonItemEnum.Right);

            JsonDiffDto result = new JsonDiffDto();
            result.Id = id;

            if (itemLeft == null || itemRight == null)
            {
                result.Message = "Data not found..";
                return result;
            }

            if (itemLeft.Data.Length != itemRight.Data.Length)
            {
                result.Message = "The data is not the same size";
                return result;
            }

            result.Message = "The data is the same";

            byte[] leftArray = Convert.FromBase64String(itemLeft.Data);
            byte[] right = Convert.FromBase64String(itemRight.Data);
            List<int> offsetList = new List<int>();

            for (int i = 0; i < leftArray.Length; i++)
            {
                if (leftArray[i] != right[i])
                {
                    offsetList.Add(i);
                }
            }

            result.Length = offsetList.Count;

            return result;
        }
        public async Task<JsonItemDTO> Select(string id, JsonItemEnum position)
        {
            string _position = position == JsonItemEnum.Left ? "Left" : "Right";
            return ConvertToDto(await _unitOfWork.JsonItemRepository.Find(x=>x.Id == id && x.Position == _position));
        }

        private JsonItemDTO ConvertToDto(JsonItem item)
        {
            if (item == null)
                return null;
            else
            {
                JsonItemDTO itemDto = new JsonItemDTO()
                {
                    Id = item.Id,
                    Data = item.Data,
                    Position = (item.Position == "L" ? JsonItemEnum.Left : JsonItemEnum.Right)
                };

                return itemDto;
            }
        }
        public async Task<bool> Save(JsonItemDTO entity)
        {
            JsonItem item = new JsonItem()
            {
                Id = entity.Id,
                Data = entity.Data,
                Position = (entity.Position == 0 ? "Left" : "Right")
            };

           await  _unitOfWork.JsonItemRepository.Add(item);

            return _unitOfWork.CompleteAsync() == 1 ? true : false;
        }

     
    }
}
