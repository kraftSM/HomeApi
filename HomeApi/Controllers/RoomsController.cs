using System;
using System.Threading.Tasks;
using AutoMapper;
using HomeApi.Contracts.Models.Devices;
using HomeApi.Contracts.Models.Rooms;
using HomeApi.Data.Models;
using HomeApi.Data.Queries;
using HomeApi.Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HomeApi.Controllers
{
    /// <summary>
    /// Контроллер комнат
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _repository;
        private IMapper _mapper;
        
        public RoomsController(IRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //TODO: Задание - добавить метод на получение всех существующих комнат
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _repository.GetRooms();

            var resp = new GetRoomsResponse
            {
                RoomAmount = rooms.Length,//_mapper.Map<Device[], DeviceView[]>(devices)
                Rooms = _mapper.Map<Room[], RoomView[]>(rooms)
            };

            return StatusCode(200, resp);
        }

        /// <summary>
        /// Добавление комнаты
        /// </summary>
        [HttpPost] 
        [Route("")] 
        public async Task<IActionResult> Add([FromBody] AddRoomRequest request)
        {
            var existingRoom = await _repository.GetRoomByName(request.Name);
            if (existingRoom == null)
            {
                var newRoom = _mapper.Map<AddRoomRequest, Room>(request);
                await _repository.AddRoom(newRoom);
                return StatusCode(201, $"Комната {request.Name} добавлена!");
            }
            
            return StatusCode(409, $"Ошибка: Комната {request.Name} уже существует.");
        }
        /// <summary>
        /// Обновление существующей комнаты
        /// </summary>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Edit(
            [FromRoute] Guid id,
            [FromBody] EditRoomRequest request)
        {
            var room = await _repository.GetRoomById(id);
            if (room == null)
                return StatusCode(400, $"Ошибка: Комната {request.NewName} не подключена. Сначала подключите комнату!");

            //var device = await _devices.GetDeviceById(id);
            //if (device == null)
            //    return StatusCode(400, $"Ошибка: Устройство с идентификатором {id} не существует.");

            //var withSameName = await _devices.GetDeviceByName(request.NewName);
            //if (withSameName != null)
            //    return StatusCode(400, $"Ошибка: Устройство с именем {request.NewName} уже подключено. Выберите другое имя!");

            await _repository.UpdateRoom(
                room,
                new UpdateRoomQuery(request.NewName, request.NewArea, request.NewGasConnected, request.NewVoltage)
            );

            return StatusCode(200, $"Комната обновленf! Имя - {room.Name}, площадь - {room.Area}, напряжение - {room.Voltage}, ufp - {room.GasConnected}");
        }
    }
}